<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports
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
        Panel1 = New Panel()
        Label1 = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label3 = New Label()
        Label2 = New Label()
        reportTypeCombo = New ComboBox()
        filterCombo = New ComboBox()
        generateReportBtn = New Button()
        rep_displayPnl = New Panel()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(783, 46)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(242, 32)
        Label1.TabIndex = 0
        Label1.Text = "Reports and Analytics"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Controls.Add(Label3, 1, 0)
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(reportTypeCombo, 0, 1)
        TableLayoutPanel1.Controls.Add(filterCombo, 1, 1)
        TableLayoutPanel1.Controls.Add(generateReportBtn, 2, 1)
        TableLayoutPanel1.Location = New Point(12, 52)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(606, 94)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label3.Location = New Point(205, 32)
        Label3.Name = "Label3"
        Label3.Size = New Size(52, 15)
        Label3.TabIndex = 1
        Label3.Text = "Filter by"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(3, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 15)
        Label2.TabIndex = 0
        Label2.Text = "Report Type"
        ' 
        ' reportTypeCombo
        ' 
        reportTypeCombo.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        reportTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList
        reportTypeCombo.FormattingEnabled = True
        reportTypeCombo.Items.AddRange(New Object() {"User Status Summary Report", "User Role Distribution Report", "Low Stock Alert Report", "Top Revenue Orders Report", "Order Status Report", "Order Trends Report", "Recent Order Summary Report", "Recent Wastage Summary Report", "Top Wasted Items Analysis Report"})
        reportTypeCombo.Location = New Point(3, 59)
        reportTypeCombo.Name = "reportTypeCombo"
        reportTypeCombo.Size = New Size(196, 23)
        reportTypeCombo.TabIndex = 2
        ' 
        ' filterCombo
        ' 
        filterCombo.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        filterCombo.DropDownStyle = ComboBoxStyle.DropDownList
        filterCombo.FormattingEnabled = True
        filterCombo.Items.AddRange(New Object() {"Type", "Last active", "24 hours", "Last active", "7 days", "Last active 30 days"})
        filterCombo.Location = New Point(205, 59)
        filterCombo.Name = "filterCombo"
        filterCombo.Size = New Size(196, 23)
        filterCombo.TabIndex = 3
        ' 
        ' generateReportBtn
        ' 
        generateReportBtn.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        generateReportBtn.Location = New Point(434, 59)
        generateReportBtn.Margin = New Padding(30, 3, 30, 3)
        generateReportBtn.Name = "generateReportBtn"
        generateReportBtn.Size = New Size(142, 23)
        generateReportBtn.TabIndex = 4
        generateReportBtn.Text = "Generate Report"
        generateReportBtn.UseVisualStyleBackColor = True
        ' 
        ' rep_displayPnl
        ' 
        rep_displayPnl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        rep_displayPnl.AutoScroll = True
        rep_displayPnl.Location = New Point(12, 152)
        rep_displayPnl.Name = "rep_displayPnl"
        rep_displayPnl.Size = New Size(606, 826)
        rep_displayPnl.TabIndex = 2
        ' 
        ' Reports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(800, 749)
        Controls.Add(rep_displayPnl)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Panel1)
        Name = "Reports"
        Text = "Reports"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents reportTypeCombo As ComboBox
    Friend WithEvents filterCombo As ComboBox
    Friend WithEvents generateReportBtn As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents rep_displayPnl As Panel
End Class
