Imports MySql.Data.MySqlClient

Public Class User_Accounts
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim i As Integer
    Dim dr As MySqlDataReader

    Private Const PageSize As Integer = 50         ' Number of rows per page
    Private lastUserId As Integer? = Nothing      ' Tracks the last loaded user ID (for keyset)
    Private isLoading As Boolean = False          ' Prevent multiple loads at once
    Private allDataLoaded As Boolean = False      ' Stop when no more rows


    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            dgv_load()
        End If
    End Sub
    Private Sub User_Accounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_load()
    End Sub

    Sub dgv_load(Optional reset As Boolean = False)
        If isLoading Or allDataLoaded Then Return

        If reset Then
            userAccDgv.Rows.Clear()
            lastUserId = Nothing
            allDataLoaded = False
        End If

        isLoading = True
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Build query
            Dim query As String
            Dim whereClause As String = "WHERE is_deleted = 0"

            ' Keyset pagination
            If lastUserId.HasValue Then
                whereClause &= " AND id > @LastUserId"
            End If

            query = "
            SELECT id, first_name, last_name, type
            FROM users
            " & whereClause & "
            ORDER BY id ASC
            LIMIT @PageSize
        "

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                If lastUserId.HasValue Then cmd.Parameters.AddWithValue("@LastUserId", lastUserId.Value)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    Dim rowsLoaded As Integer = 0
                    While dr.Read()
                        Dim fullName As String = dr("first_name").ToString() & " " & dr("last_name").ToString()
                        Dim formattedId As String = CInt(dr("id")).ToString("D6")
                        userAccDgv.Rows.Add(formattedId, fullName, dr("type").ToString())

                        lastUserId = Convert.ToInt32(dr("id")) ' Update for next page
                        rowsLoaded += 1
                    End While

                    ' Stop loading if less than page size
                    If rowsLoaded < PageSize Then allDataLoaded = True
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading users: " & ex.Message)
        Finally
            conn.Close()
            isLoading = False
        End Try
    End Sub



    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        AddNewUser.TopMost = True
        AddNewUser.Show()
    End Sub

    Private Sub userAccDgv_MouseDown(sender As Object, e As MouseEventArgs) Handles userAccDgv.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = userAccDgv.HitTest(e.X, e.Y)

            ' Only show if clicked on a valid row
            If hit.Type = DataGridViewHitTestType.Cell Then
                userAccDgv.ClearSelection()
                userAccDgv.Rows(hit.RowIndex).Selected = True

                ' Show menu at mouse position
                userMenu.Show(userAccDgv, New Point(e.X, e.Y))
            End If
        End If
    End Sub



    Private Sub logs_Click(sender As Object, e As EventArgs) Handles logs.Click
        ' Make sure a row is selected
        If userAccDgv.SelectedRows.Count > 0 Then

            Dim selectedUserId As Integer =
            Convert.ToInt32(userAccDgv.SelectedRows(0).Cells("id").Value)

            Dim logsForm As New User_Activity_Logs()
            logsForm.LoadUserLogs(selectedUserId)

            logsForm.TopMost = True
            logsForm.ShowDialog()

        Else
            MessageBox.Show("Please select a user first.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub editUser_Click(sender As Object, e As EventArgs) Handles editUser.Click
        ' Make sure a row is selected
        If userAccDgv.SelectedRows.Count > 0 Then
            ' Get the ID from the selected row
            Dim selectedUserId As Integer = Convert.ToInt32(userAccDgv.SelectedRows(0).Cells("id").Value)

            ' Open the User_View_Info form and load user info
            Dim editForm As New User_Edit_User()
            editForm.LoadUserInfo(selectedUserId)

            ' Show it as a modal dialog
            editForm.TopMost = True
            editForm.ShowDialog()
        Else
            MessageBox.Show("Please select a user first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub viewinf_Click(sender As Object, e As EventArgs) Handles viewinf.Click
        ' Make sure a row is selected
        If userAccDgv.SelectedRows.Count > 0 Then
            ' Get the ID from the selected row
            Dim selectedUserId As Integer = Convert.ToInt32(userAccDgv.SelectedRows(0).Cells("id").Value)

            ' Open the User_View_Info form and load user info
            Dim viewForm As New User_View_Info()
            viewForm.LoadUserInfo(selectedUserId)

            ' Show it as a modal dialog
            viewForm.TopMost = True
            viewForm.ShowDialog()
        Else
            MessageBox.Show("Please select a user first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub searchTb_TextChanged(sender As Object, e As EventArgs) Handles searchTb.TextChanged
        SearchUsers(searchTb.Text)
    End Sub

    Private Sub SearchUsers(queryText As String)
        Try
            userAccDgv.Rows.Clear() ' Clear existing rows
            conn.Open()

            ' Include is_deleted = 0 in the WHERE clause
            Dim query As String = "SELECT id, first_name, last_name, type FROM `users` " &
                                  "WHERE is_deleted = 0 AND " &
                                  "(id LIKE @search OR first_name LIKE @search OR last_name LIKE @search OR type LIKE @search)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@search", "%" & queryText & "%")

                dr = cmd.ExecuteReader()
                While dr.Read()
                    Dim fullName As String = dr.Item("first_name") & " " & dr.Item("last_name")
                    Dim formattedId As String = CInt(dr.Item("id")).ToString("D6")
                    userAccDgv.Rows.Add(formattedId, fullName, dr.Item("type"))
                End While
                dr.Dispose()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        If userAccDgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim userId As Integer = Convert.ToInt32(userAccDgv.SelectedRows(0).Cells("id").Value)

        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete this user?" & vbCrLf &
            "(This action can be restored later)",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            DeleteUser(userId)
        End If

    End Sub

    Private Sub DeleteUser(userId As Integer)

        ' 🚫 Prevent self-delete
        If userId = Session.UserID Then
            MessageBox.Show(
                "You cannot delete your own account while logged in.",
                "Action Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Exit Sub
        End If

        Try
            conn.Open()

            ' 1️⃣ Get original creator
            Dim createdBy As Integer = 0
            Using getCreatorCmd As New MySqlCommand(
                "SELECT created_by FROM users WHERE id = @userId", conn)

                getCreatorCmd.Parameters.AddWithValue("@userId", userId)
                Dim result = getCreatorCmd.ExecuteScalar()

                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    createdBy = Convert.ToInt32(result)
                End If
            End Using

            ' 2️⃣ Soft delete user
            Using deleteCmd As New MySqlCommand(
                "UPDATE users
             SET is_deleted = 1,
                 deleted_by = @deleted_by,
                 deleted_at = NOW()
             WHERE id = @userId", conn)

                deleteCmd.Parameters.AddWithValue("@userId", userId)
                deleteCmd.Parameters.AddWithValue("@deleted_by", Session.UserID)
                deleteCmd.ExecuteNonQuery()
            End Using

            ' 3️⃣ Audit log (DELETE – exclusive)
            Using logCmd As New MySqlCommand(
                "INSERT INTO audit_log
            (entity_id, entity_type, action, details, level,
             deleted_by, deleted_at, created_by)
            VALUES
            (@entity_id, 'Users', 'DELETE',
             'User account was soft-deleted',
             @level, @deleted_by, NOW(), @created_by)", conn)

                logCmd.Parameters.AddWithValue("@entity_id", userId)
                logCmd.Parameters.AddWithValue("@level", Session.UserType)
                logCmd.Parameters.AddWithValue("@deleted_by", Session.UserID)
                logCmd.Parameters.AddWithValue("@created_by", createdBy)
                logCmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("User deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            dgv_load()

        Catch ex As Exception
            MessageBox.Show("Error deleting user: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub



End Class