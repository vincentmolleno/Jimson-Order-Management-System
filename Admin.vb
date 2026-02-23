Imports Microsoft.VisualBasic.ApplicationServices
Imports Mysqlx.Crud

Public Class Admin

    'displayPnl content displayer
    Sub childform(ByVal panel As Form)
        displayPnl.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = FormBorderStyle.None

        ' Set initial size to parent client size
        panel.Location = New Point(0, 0)
        panel.Size = displayPnl.ClientSize

        ' Resize child panel when displayPnl changes size
        AddHandler displayPnl.Resize, Sub(sender, e)
                                          panel.Size = displayPnl.ClientSize
                                      End Sub

        displayPnl.Controls.Add(panel)
        panel.Show()
    End Sub

    'default screen: dashboard and setups tags for buttons
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dashboardBtn.Tag = Dashboard
        userAccsBtn.Tag = User_Accounts
        invBtn.Tag = Inventories
        ordersBtn.Tag = Orders
        reportsBtn.Tag = Reports
        loggingBtn.Tag = Logging
        backrecBtn.Tag = Backup_and_Recovery
        recycleBinBtn.Tag = RecycleBin

        dashboardBtn.PerformClick()
    End Sub

    'opens childforms through with the use of tags in button

    Private Sub NavButton_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click, userAccsBtn.Click, invBtn.Click, ordersBtn.Click, reportsBtn.Click, loggingBtn.Click, backrecBtn.Click, recycleBinBtn.Click
        childform(DirectCast(sender, Button).Tag)
    End Sub

End Class