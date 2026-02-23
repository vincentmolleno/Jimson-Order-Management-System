Imports MySql.Data.MySqlClient

Public Class Fullscreen
    Private isFullscreen As Boolean = False
    Private normalBounds As Rectangle
    Private normalBorder As FormBorderStyle

    Sub display(ByVal panel As Form)
        displayPnl.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = FormBorderStyle.None

        ' Check if the panel has a control named "logoutBtn"
        Dim logoutBtn = TryCast(panel.Controls.Find("logoutBtn", True).FirstOrDefault(), Button)
        If logoutBtn IsNot Nothing Then
            ' Remove any previous handlers to avoid double-subscription
            RemoveHandler logoutBtn.Click, AddressOf ChildLogout_Click
            AddHandler logoutBtn.Click, AddressOf ChildLogout_Click
        End If

        displayPnl.Controls.Add(panel)
        panel.Show()

        ' Forms that should stay centered and small
        If TypeOf panel Is Login OrElse TypeOf panel Is Configure Then
            panel.Location = New Point(
            (displayPnl.ClientSize.Width - panel.Width) \ 2,
            (displayPnl.ClientSize.Height - panel.Height) \ 2
        )

            ' Optional: re-center when the parent panel resizes
            AddHandler displayPnl.Resize, Sub(sender, e)
                                              panel.Location = New Point(
                                              (displayPnl.ClientSize.Width - panel.Width) \ 2,
                                              (displayPnl.ClientSize.Height - panel.Height) \ 2
                                          )
                                          End Sub
        Else
            ' Other forms fill the panel
            panel.Location = New Point(0, 0)
            panel.Size = displayPnl.ClientSize
            AddHandler displayPnl.Resize, Sub(sender, e)
                                              panel.Size = displayPnl.ClientSize
                                          End Sub
        End If
    End Sub


    Private Sub Fullscreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable KeyPreview so the form catches F11
        Me.KeyPreview = True

        ' Enable double buffering to reduce flicker
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.UserPaint Or
                ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()

        displayPnl.GetType().GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance).SetValue(displayPnl, True, Nothing)

        ' make panel “transparent” so wallpaper shows
        displayPnl.BackColor = Color.Transparent

        ' Display the login form
        display(Login)

        ' start in fullscreen
        ToggleFullscreen()
    End Sub


    Private Sub Fullscreen_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            ToggleFullscreen()
        End If
    End Sub

    Private Sub ToggleFullscreen()
        If Not isFullscreen Then
            ' Save normal state
            normalBounds = Me.Bounds
            normalBorder = Me.FormBorderStyle

            ' Go fullscreen
            Me.FormBorderStyle = FormBorderStyle.None
            Me.WindowState = FormWindowState.Normal
            Me.Bounds = Screen.PrimaryScreen.Bounds ' covers taskbar
            Me.TopMost = False ' <-- remove this

            isFullscreen = True
        Else
            ' Restore normal state
            Me.FormBorderStyle = normalBorder
            Me.Bounds = normalBounds
            Me.WindowState = FormWindowState.Normal
            Me.TopMost = False

            isFullscreen = False
        End If
    End Sub


    Private Sub Fullscreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Only log if user is logged in
        If Session.UserID <> 0 AndAlso Not TypeOf displayPnl.Controls(0) Is Login Then
            ' Ask for confirmation
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ' Log the logout
            LogLogout(Session.UserID, Session.UserFullName, Session.UserType)
        End If
    End Sub

    ' Reusable method for logout logging
    Private Sub LogLogout(userId As Integer, fullName As String, userType As String)
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand("INSERT INTO audit_log (log_date, log_time, user_id, action, details, level, created_by) " &
                                          "VALUES (@date, @time, @user_id, @action, @details, @level, @created_by)", conn)
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date)
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay)
                    cmd.Parameters.AddWithValue("@user_id", userId)
                    cmd.Parameters.AddWithValue("@action", "Logout")
                    cmd.Parameters.AddWithValue("@details", $"{fullName} has logged out.")
                    cmd.Parameters.AddWithValue("@level", userType)
                    cmd.Parameters.AddWithValue("@created_by", "System")
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to log logout action: " & ex.Message)
        End Try
    End Sub



    Private Sub ChildLogout_Click(sender As Object, e As EventArgs)
        ' Ask for confirmation
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            LogLogout(Session.UserID, Session.UserFullName, Session.UserType)
            ' Clear session
            Session.Clear()

            ' Clear current panel
            displayPnl.Controls.Clear()

            ' Show Login form
            display(New Login())
        End If
    End Sub



End Class