Imports MySql.Data.MySqlClient

Public Class User_Edit_User
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim i As Integer

    Private selectedUserId As Integer

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    Public Sub LoadUserInfo(userId As Integer)
        selectedUserId = userId ' save the ID for later use
        Try
            conn.Open()
            Dim query As String = "SELECT id, first_name, last_name, email, phone_number, type, username, last_active FROM users WHERE id=@id AND is_deleted=0"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", userId)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                ' Fill textboxes
                first_nameTb.Text = reader("first_name").ToString()
                last_nameTb.Text = reader("last_name").ToString()
                typeCb.Text = reader("type").ToString()
                emailTb.Text = reader("email").ToString()
                phoneTb.Text = reader("phone_number").ToString()
                usernameTb.Text = reader("username").ToString()


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

    Private Sub EditUser(userId As Integer)
        Try
            conn.Open()

            Dim query As String
            Dim cmd As New MySqlCommand()
            cmd.Connection = conn

            If passwordTb.Text.Trim() = "" Then
                ' Password left blank → do not update it
                query = "UPDATE `users` 
                     SET first_name=@first_name, 
                         last_name=@last_name, 
                         email=@email, 
                         phone_number=@phone_number, 
                         type=@type, 
                         username=@username,
                         updated_by=@updated_by,
                         updated_at=@updated_at
                     WHERE id=@id"
            Else
                ' Password provided → update it
                query = "UPDATE `users` 
                     SET first_name=@first_name, 
                         last_name=@last_name, 
                         email=@email, 
                         phone_number=@phone_number, 
                         type=@type, 
                         username=@username, 
                         password=@password,
                         updated_by=@updated_by,
                         updated_at=@updated_at
                     WHERE id=@id"
                cmd.Parameters.AddWithValue("@password", Encrypt(passwordTb.Text.Trim()))
            End If

            cmd.CommandText = query

            ' Common parameters
            cmd.Parameters.AddWithValue("@first_name", first_nameTb.Text)
            cmd.Parameters.AddWithValue("@last_name", last_nameTb.Text)
            cmd.Parameters.AddWithValue("@email", emailTb.Text)
            cmd.Parameters.AddWithValue("@phone_number", phoneTb.Text)
            cmd.Parameters.AddWithValue("@type", typeCb.Text)
            cmd.Parameters.AddWithValue("@username", usernameTb.Text)
            cmd.Parameters.AddWithValue("@id", userId)
            cmd.Parameters.AddWithValue("@updated_by", Session.UserID)
            cmd.Parameters.AddWithValue("@updated_at", DateTime.Now)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                ' --- Audit log entry ---
                Using logCmd As New MySqlCommand(
                "INSERT INTO audit_log 
                 (entity_id, entity_type, action, details, level, updated_by, updated_at) 
                 VALUES (@entity_id, @entity_type, @action, @details, @level, @updated_by, @updated_at)", conn)

                    logCmd.Parameters.AddWithValue("@entity_id", userId)
                    logCmd.Parameters.AddWithValue("@entity_type", "User")
                    logCmd.Parameters.AddWithValue("@action", "Update")
                    logCmd.Parameters.AddWithValue("@details", $"User {first_nameTb.Text} {last_nameTb.Text} (ID {userId.ToString("D6")}) was updated.")
                    logCmd.Parameters.AddWithValue("@level", Session.UserType)
                    logCmd.Parameters.AddWithValue("@updated_by", Session.UserID)
                    logCmd.Parameters.AddWithValue("@updated_at", DateTime.Now)

                    logCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("User updated!", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No changes made or failed to update!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub





    ' checks password match
    Private Sub passwordTb_TextChanged(sender As Object, e As EventArgs) Handles passwordTb.TextChanged
        ValidateForm()
    End Sub

    Private Sub confirmTb_TextChanged(sender As Object, e As EventArgs) Handles confirmTb.TextChanged
        ValidateForm()

        If confirmTb.Text = passwordTb.Text Then
            matchLbl.Text = "✔ Passwords match"
            matchLbl.ForeColor = Color.Green
        Else
            matchLbl.Text = "✘ Passwords do not match"
            matchLbl.ForeColor = Color.Red
            createBtn.Enabled = False
        End If
    End Sub

    Private Sub ValidateForm()
        ' Required fields
        Dim requiredFilled As Boolean =
        passwordTb.Text.Trim() <> "" AndAlso
        confirmTb.Text.Trim() <> ""

        Dim passwordsMatch As Boolean = (passwordTb.Text = confirmTb.Text)

        createBtn.Enabled = requiredFilled AndAlso passwordsMatch
    End Sub

    Private Sub createBtn_Click(sender As Object, e As EventArgs) Handles createBtn.Click
        EditUser(selectedUserId)
    End Sub
End Class