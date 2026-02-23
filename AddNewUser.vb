Imports MySql.Data.MySqlClient

Public Class AddNewUser

    ' create function
    Private Sub create()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                ' 1️⃣ Insert user
                Dim cmd As New MySqlCommand(
                    "INSERT INTO `users`(`first_name`, `last_name`, `email`, `phone_number`, `type`, `username`, `password`, `created_by`) 
                     VALUES (@first_name,@last_name,@email,@phone_number,@type,@username,@password,@created_by); 
                     SELECT LAST_INSERT_ID();", conn)

                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@first_name", first_nameTb.Text.Trim())
                cmd.Parameters.AddWithValue("@last_name", last_nameTb.Text.Trim())
                cmd.Parameters.AddWithValue("@email", emailTb.Text.Trim())
                cmd.Parameters.AddWithValue("@phone_number", phoneTb.Text.Trim())
                cmd.Parameters.AddWithValue("@type", typeCb.Text.Trim())
                cmd.Parameters.AddWithValue("@username", usernameTb.Text.Trim())
                cmd.Parameters.AddWithValue("@password", modDB.Encrypt(passwordTb.Text.Trim()))
                cmd.Parameters.AddWithValue("@created_by", Session.UserID)

                ' Execute and get inserted user ID
                Dim newUserId As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                ' 2️⃣ Log creation in audit_log
                Using logCmd As New MySqlCommand(
                    "INSERT INTO audit_log 
                    (entity_id, entity_type, action, details, level, created_by, created_at) 
                    VALUES (@entity_id, @entity_type, @action, @details, @level, @created_by, @created_at)", conn)

                    logCmd.Parameters.AddWithValue("@entity_id", newUserId)
                    logCmd.Parameters.AddWithValue("@entity_type", "User")
                    logCmd.Parameters.AddWithValue("@action", "Create")
                    logCmd.Parameters.AddWithValue("@details", $"User {first_nameTb.Text.Trim()} {last_nameTb.Text.Trim()} (ID {newUserId:D6}) was created.")
                    logCmd.Parameters.AddWithValue("@level", Session.UserType)
                    logCmd.Parameters.AddWithValue("@created_by", Session.UserID)
                    logCmd.Parameters.AddWithValue("@created_at", DateTime.Now)

                    logCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("User added successfully!", "CURD", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    ' Cancel button
    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    ' Form closing validation
    Private Sub AddNewUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim hasChanges As Boolean =
            {first_nameTb, last_nameTb, emailTb, phoneTb, typeCb, usernameTb, passwordTb}.
            Any(Function(ctrl) Not String.IsNullOrWhiteSpace(ctrl.Text))

        If hasChanges Then
            Dim result As DialogResult =
                MessageBox.Show("Discard changes?", "Discard", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.No Then e.Cancel = True
        End If
    End Sub

    ' Create button
    Private Sub createBtn_Click(sender As Object, e As EventArgs) Handles createBtn.Click
        create()
        User_Accounts.dgv_load()
        RemoveHandler Me.FormClosing, AddressOf AddNewUser_FormClosing
        Me.Close()
    End Sub

    ' Password match check
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
        End If
    End Sub

    ' Required fields validation
    Private Sub RequiredFields_TextChanged(sender As Object, e As EventArgs) _
        Handles first_nameTb.TextChanged,
                last_nameTb.TextChanged,
                emailTb.TextChanged,
                phoneTb.TextChanged,
                typeCb.TextChanged,
                usernameTb.TextChanged
        ValidateForm()
    End Sub

    Private Sub ValidateForm()
        Dim requiredFilled As Boolean =
            first_nameTb.Text.Trim() <> "" AndAlso
            last_nameTb.Text.Trim() <> "" AndAlso
            emailTb.Text.Trim() <> "" AndAlso
            phoneTb.Text.Trim() <> "" AndAlso
            typeCb.Text.Trim() <> "" AndAlso
            usernameTb.Text.Trim() <> "" AndAlso
            passwordTb.Text.Trim() <> "" AndAlso
            confirmTb.Text.Trim() <> ""

        Dim passwordsMatch As Boolean = (passwordTb.Text = confirmTb.Text)

        createBtn.Enabled = requiredFilled AndAlso passwordsMatch
    End Sub

End Class
