Public Class Cashier
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

    Private Sub Cashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Prepare forms
        dashboardBtn.Tag = New Cashier_Dashboard()
        ordersBtn.Tag = New Orders()

        Dim rep As New Reports()
        rep.LimitToCashierReports()
        reportsBtn.Tag = rep


        ' Default screen
        dashboardBtn.PerformClick()
    End Sub

    'opens childforms through with the use of tags in button
    Private Sub NavButton_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click, ordersBtn.Click, reportsBtn.Click
        childform(DirectCast(sender, Button).Tag)
    End Sub

End Class