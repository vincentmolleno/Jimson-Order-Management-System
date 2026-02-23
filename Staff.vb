Public Class Staff
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

    'default screen: inventory and handlers for OpenedFromStaff/LimitToStaff
    Private Sub Staff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dashboardBtn.Tag = New Staff_Dashboard()

        Dim inv As New Inventories()
        inv.LimitToStaffInventory()
        invBtn.Tag = inv

        Dim rep As New Reports()
        rep.LimitToStaffReports()
        reportsBtn.Tag = rep


        ' Default screen
        dashboardBtn.PerformClick()

    End Sub

    'Opens the pre-configured child form stored in the button’s Tag

    Private Sub NavButton_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click, invBtn.Click, reportsBtn.Click
        childform(DirectCast(sender, Button).Tag)
    End Sub

End Class