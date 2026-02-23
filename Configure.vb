Imports System.Drawing.Drawing2D

Public Class Configure

    Private Sub Configure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fullscreen.AcceptButton = Button1

        ipAddressTextBox.Text = modDB.db_server
        usernameTextBox.Text = modDB.db_uid
        passwordTextBox.Text = modDB.db_pwd
        databaseNameTextBox.Text = modDB.db_name
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim newServer = ipAddressTextBox.Text.Trim
        Dim newUser = usernameTextBox.Text.Trim
        Dim newPass = passwordTextBox.Text
        Dim newDb = databaseNameTextBox.Text.Trim

        If newServer = "" Or newUser = "" Or newDb = "" Then
            MsgBox("Please fill in all required fields.")
            Exit Sub
        End If

        ' Update ONLY modDB values
        db_server = newServer
        db_uid = newUser
        db_pwd = newPass
        db_name = newDb

        ' IMPORTANT: rebuild connection string
        strConnection =
            "server=" & db_server &
            ";uid=" & db_uid &
            ";password=" & db_pwd &
            ";database=" & db_name &
            ";allowuservariables=True;"

        MsgBox("Database configuration updated successfully.")

        Button2.PerformClick()
    End Sub


    Public Sub MakeFormRounded(ctrl As Control, percent As Integer)
        Dim radius As Integer = CInt(Math.Min(ctrl.Width, ctrl.Height) * percent / 100)
        Dim path As New GraphicsPath()

        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(ctrl.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(ctrl.Width - radius, ctrl.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, ctrl.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ctrl.Region = New Region(path)
    End Sub

    Private Sub Config_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.FormBorderStyle = FormBorderStyle.None
        MakeFormRounded(Me, 7)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
        Fullscreen.display(Login)
    End Sub

End Class
