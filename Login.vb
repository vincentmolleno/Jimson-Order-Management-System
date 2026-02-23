Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class Login

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        Dim username As String = usernameTb.Text.Trim()
        Dim password As String = modDB.Encrypt(passwordTb.Text.Trim())

        If username = "" Or password = "" Then
            MsgBox("Please enter username and password.")
            Exit Sub
        End If

        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                Dim query As String = "SELECT * FROM users WHERE username=@username AND password=@password LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            MsgBox("Invalid username or password")
                            Exit Sub
                        End If

                        ' Read user data
                        Dim userId As Integer = CInt(reader("id"))
                        Dim fullName As String = reader("first_name") & " " & reader("last_name")
                        Dim userType As String = reader("type").ToString()

                        reader.Close()

                        ' Update last_active
                        Using updateCmd As New MySqlCommand(
                            "UPDATE users SET last_active=@lastActive WHERE id=@id", conn)
                            updateCmd.Parameters.AddWithValue("@lastActive", DateTime.Now)
                            updateCmd.Parameters.AddWithValue("@id", userId)
                            updateCmd.ExecuteNonQuery()
                        End Using

                        ' Audit log
                        AddAuditLog(userId, fullName, "Login", $"{fullName} logged in.", userType)

                        ' Save session
                        Session.UserID = userId
                        Session.UserFullName = fullName
                        Session.UserType = userType

                        MsgBox("Login successful! Welcome " & fullName)

                        ' Navigate to the correct form
                        Select Case userType.ToLower()
                            Case "admin" : Fullscreen.display(Admin)
                            Case "staff" : Fullscreen.display(Staff)
                            Case "cashier" : Fullscreen.display(Cashier)
                            Case Else
                                MsgBox("Unknown user type.")
                                Exit Sub
                        End Select

                        Me.Hide()
                    End Using
                End Using
            End Using

        Catch ex As MySqlException
            MsgBox("Database error: " & ex.Message)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub configBtn_Click(sender As Object, e As EventArgs) Handles configBtn.Click
        Fullscreen.display(Configure)
        Me.Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fullscreen.AcceptButton = loginBtn
        modDatabaseInit.EnsureDatabaseReady()
    End Sub

    Private Sub Login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.FormBorderStyle = FormBorderStyle.None
        MakeFormRounded(Me, 7)
    End Sub

    Public Sub MakeFormRounded(ctrl As Control, percent As Integer)
        Dim radius As Integer = CInt(Math.Min(ctrl.Width, ctrl.Height) * percent / 100)
        Dim path As New Drawing2D.GraphicsPath()
        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(ctrl.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(ctrl.Width - radius, ctrl.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, ctrl.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()
        ctrl.Region = New Region(path)
    End Sub

    Private Sub AddAuditLog(userId As Integer, fullName As String, action As String, details As String, level As String)
        Try
            Using auditConn As New MySqlConnection(modDB.strConnection)
                auditConn.Open()
                Dim query As String = "INSERT INTO audit_log (log_date, log_time, user_id, entity_type, action, details, level, created_by) " &
                                      "VALUES (@log_date, @log_time, @user_id, @entity_type, @action, @details, @level, @created_by)"
                Using cmd As New MySqlCommand(query, auditConn)
                    cmd.Parameters.AddWithValue("@log_date", DateTime.Now.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@log_time", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@user_id", userId)
                    cmd.Parameters.AddWithValue("@entity_type", "User")
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@details", details)
                    cmd.Parameters.AddWithValue("@level", level)
                    cmd.Parameters.AddWithValue("@created_by", "System")
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed to add audit log: " & ex.Message)
        End Try
    End Sub

End Class
