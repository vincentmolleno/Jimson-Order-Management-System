<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cashier
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        headPnl = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        topLbl = New Label()
        logo = New PictureBox()
        logoutBtn = New Button()
        sidebarPnl = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        dashboardBtn = New Button()
        ordersBtn = New Button()
        reportsBtn = New Button()
        displayPnl = New Panel()
        headPnl.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(logo, ComponentModel.ISupportInitialize).BeginInit()
        sidebarPnl.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' headPnl
        ' 
        headPnl.BackColor = SystemColors.ControlLight
        headPnl.Controls.Add(TableLayoutPanel2)
        headPnl.Dock = DockStyle.Top
        headPnl.Location = New Point(0, 0)
        headPnl.Name = "headPnl"
        headPnl.Size = New Size(800, 38)
        headPnl.TabIndex = 2
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 4
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 5.75F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 44.25F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.Controls.Add(topLbl, 1, 0)
        TableLayoutPanel2.Controls.Add(logo, 0, 0)
        TableLayoutPanel2.Controls.Add(logoutBtn, 3, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(800, 38)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' topLbl
        ' 
        topLbl.Anchor = AnchorStyles.Left
        topLbl.AutoSize = True
        topLbl.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        topLbl.Location = New Point(49, 11)
        topLbl.Name = "topLbl"
        topLbl.Size = New Size(294, 15)
        topLbl.TabIndex = 1
        topLbl.Text = "Jimson Glass & Furniture Order & Management System"
        ' 
        ' logo
        ' 
        logo.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        logo.Image = My.Resources.Resources.download
        logo.Location = New Point(3, 3)
        logo.Name = "logo"
        logo.Size = New Size(40, 32)
        logo.SizeMode = PictureBoxSizeMode.Zoom
        logo.TabIndex = 0
        logo.TabStop = False
        ' 
        ' logoutBtn
        ' 
        logoutBtn.Anchor = AnchorStyles.Right
        logoutBtn.Location = New Point(722, 7)
        logoutBtn.Name = "logoutBtn"
        logoutBtn.Size = New Size(75, 23)
        logoutBtn.TabIndex = 2
        logoutBtn.Text = "Logout"
        logoutBtn.UseVisualStyleBackColor = True
        ' 
        ' sidebarPnl
        ' 
        sidebarPnl.BackColor = Color.FromArgb(CByte(214), CByte(48), CByte(49))
        sidebarPnl.Controls.Add(TableLayoutPanel1)
        sidebarPnl.Dock = DockStyle.Left
        sidebarPnl.Location = New Point(0, 38)
        sidebarPnl.Name = "sidebarPnl"
        sidebarPnl.Size = New Size(173, 412)
        sidebarPnl.TabIndex = 3
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(dashboardBtn, 0, 0)
        TableLayoutPanel1.Controls.Add(ordersBtn, 0, 1)
        TableLayoutPanel1.Controls.Add(reportsBtn, 0, 2)
        TableLayoutPanel1.Location = New Point(3, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TableLayoutPanel1.Size = New Size(167, 175)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' dashboardBtn
        ' 
        dashboardBtn.FlatAppearance.BorderSize = 0
        dashboardBtn.FlatStyle = FlatStyle.Flat
        dashboardBtn.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        dashboardBtn.ForeColor = Color.White
        dashboardBtn.Location = New Point(3, 3)
        dashboardBtn.Name = "dashboardBtn"
        dashboardBtn.Size = New Size(161, 47)
        dashboardBtn.TabIndex = 0
        dashboardBtn.Text = "Dashboard"
        dashboardBtn.UseVisualStyleBackColor = True
        ' 
        ' ordersBtn
        ' 
        ordersBtn.FlatAppearance.BorderSize = 0
        ordersBtn.FlatStyle = FlatStyle.Flat
        ordersBtn.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        ordersBtn.ForeColor = Color.White
        ordersBtn.Location = New Point(3, 61)
        ordersBtn.Name = "ordersBtn"
        ordersBtn.Size = New Size(161, 47)
        ordersBtn.TabIndex = 6
        ordersBtn.Text = "Orders"
        ordersBtn.UseVisualStyleBackColor = True
        ' 
        ' reportsBtn
        ' 
        reportsBtn.FlatAppearance.BorderSize = 0
        reportsBtn.FlatStyle = FlatStyle.Flat
        reportsBtn.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        reportsBtn.ForeColor = Color.White
        reportsBtn.Location = New Point(3, 119)
        reportsBtn.Name = "reportsBtn"
        reportsBtn.Size = New Size(161, 47)
        reportsBtn.TabIndex = 3
        reportsBtn.Text = "Reports"
        reportsBtn.UseVisualStyleBackColor = True
        ' 
        ' displayPnl
        ' 
        displayPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        displayPnl.BackColor = SystemColors.ControlLight
        displayPnl.Location = New Point(173, 38)
        displayPnl.Name = "displayPnl"
        displayPnl.Size = New Size(627, 412)
        displayPnl.TabIndex = 4
        ' 
        ' Cashier
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(displayPnl)
        Controls.Add(sidebarPnl)
        Controls.Add(headPnl)
        Name = "Cashier"
        Text = "Cashier"
        WindowState = FormWindowState.Maximized
        headPnl.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(logo, ComponentModel.ISupportInitialize).EndInit()
        sidebarPnl.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents headPnl As Panel
    Friend WithEvents sidebarPnl As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ordersBtn As Button
    Friend WithEvents dashboardBtn As Button
    Friend WithEvents reportsBtn As Button
    Friend WithEvents displayPnl As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents topLbl As Label
    Friend WithEvents logo As PictureBox
    Friend WithEvents logoutBtn As Button
End Class
