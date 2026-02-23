Imports MySql.Data.MySqlClient

Public Class User_View_Info
    ' Connection
    Dim conn As New MySqlConnection(modDB.strConnection)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public Sub LoadUserInfo(userId As Integer)
        Try
            conn.Open()
            Dim query As String = "SELECT id, first_name, last_name, email, phone_number, type, username, last_active FROM users WHERE id=@id AND is_deleted=0"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", userId)


            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim usrId As Integer = Convert.ToInt32(reader("id"))
                ' Fill the form textboxes
                idTb.Text = usrId.ToString("D6")
                first_nameTb.Text = reader("first_name").ToString() & " " & reader("last_name").ToString()
                userTypeTb.Text = reader("type").ToString()
                emailTb.Text = reader("email").ToString()
                phoneTb.Text = reader("phone_number").ToString()

                ' Update last active in datetimePh
                If Not IsDBNull(reader("last_active")) Then
                    datetimePh.Text = Convert.ToDateTime(reader("last_active")).ToString("yyyy-MM-dd HH:mm:ss")
                Else
                    datetimePh.Text = "N/A"
                End If
            Else
                MessageBox.Show("User not found or deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading user info: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        User_Edit_User.TopMost = True
        User_Edit_User.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ' Ensure user is loaded
        If String.IsNullOrEmpty(idTb.Text) Then
            MessageBox.Show("No user selected.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim userId As Integer = Convert.ToInt32(idTb.Text)

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

        ' Confirm delete
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this user?" & vbCrLf &
            "(This action can be restored later)",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result <> DialogResult.Yes Then Exit Sub

        Try
            conn.Open()

            ' 1️⃣ Get creator of the user
            Dim createdBy As Integer = 0
            Using getCreatorCmd As New MySqlCommand(
                "SELECT created_by FROM users WHERE id = @userId", conn)

                getCreatorCmd.Parameters.AddWithValue("@userId", userId)
                Dim res = getCreatorCmd.ExecuteScalar()

                If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                    createdBy = Convert.ToInt32(res)
                End If
            End Using

            ' 2️⃣ Soft delete user (with deleted_by & deleted_at)
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

            MessageBox.Show("User deleted successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error deleting user: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

    End Sub


End Class