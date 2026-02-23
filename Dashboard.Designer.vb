<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        TableLayoutPanel2 = New TableLayoutPanel()
        dashboardLogDgv = New DataGridView()
        dateClm = New DataGridViewTextBoxColumn()
        userClm = New DataGridViewTextBoxColumn()
        actionClm = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        TableLayoutPanel1 = New TableLayoutPanel()
        dashboardHead = New Label()
        dashboardSubhead = New Label()
        Label1 = New Label()
        Label2 = New Label()
        revenueLbl = New Label()
        pendingOrdersLbl = New Label()
        visitLogs = New Button()
        TableLayoutPanel3 = New TableLayoutPanel()
        TableLayoutPanel2.SuspendLayout()
        CType(dashboardLogDgv, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(dashboardLogDgv, 0, 1)
        TableLayoutPanel2.Controls.Add(TableLayoutPanel1, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(800, 450)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' dashboardLogDgv
        ' 
        dashboardLogDgv.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dashboardLogDgv.BackgroundColor = SystemColors.ControlLightLight
        dashboardLogDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dashboardLogDgv.Columns.AddRange(New DataGridViewColumn() {dateClm, userClm, actionClm, Column1})
        dashboardLogDgv.Location = New Point(3, 228)
        dashboardLogDgv.Name = "dashboardLogDgv"
        dashboardLogDgv.RowHeadersVisible = False
        dashboardLogDgv.Size = New Size(794, 219)
        dashboardLogDgv.TabIndex = 0
        ' 
        ' dateClm
        ' 
        dateClm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dateClm.HeaderText = "Date"
        dateClm.Name = "dateClm"
        dateClm.Width = 56
        ' 
        ' userClm
        ' 
        userClm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        userClm.HeaderText = "UserID"
        userClm.Name = "userClm"
        ' 
        ' actionClm
        ' 
        actionClm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        actionClm.HeaderText = "Action"
        actionClm.Name = "actionClm"
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column1.HeaderText = "Details"
        Column1.Name = "Column1"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(dashboardHead, 0, 0)
        TableLayoutPanel1.Controls.Add(dashboardSubhead, 0, 3)
        TableLayoutPanel1.Controls.Add(Label1, 0, 1)
        TableLayoutPanel1.Controls.Add(Label2, 1, 1)
        TableLayoutPanel1.Controls.Add(revenueLbl, 0, 2)
        TableLayoutPanel1.Controls.Add(pendingOrdersLbl, 1, 2)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 1, 3)
        TableLayoutPanel1.Location = New Point(3, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.7899551F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.8949776F))
        TableLayoutPanel1.Size = New Size(794, 219)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' dashboardHead
        ' 
        dashboardHead.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        dashboardHead.AutoSize = True
        dashboardHead.Font = New Font("Segoe UI", 18F)
        dashboardHead.Location = New Point(3, 0)
        dashboardHead.Name = "dashboardHead"
        dashboardHead.Size = New Size(235, 54)
        dashboardHead.TabIndex = 0
        dashboardHead.Text = "Dashboard Overview"
        dashboardHead.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' dashboardSubhead
        ' 
        dashboardSubhead.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        dashboardSubhead.AutoSize = True
        dashboardSubhead.Font = New Font("Segoe UI", 15F)
        dashboardSubhead.Location = New Point(3, 181)
        dashboardSubhead.Name = "dashboardSubhead"
        dashboardSubhead.Size = New Size(141, 38)
        dashboardSubhead.TabIndex = 1
        dashboardSubhead.Text = "Recent Activity"
        dashboardSubhead.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(3, 73)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 15)
        Label1.TabIndex = 2
        Label1.Text = "Revenue"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(400, 73)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 15)
        Label2.TabIndex = 3
        Label2.Text = "Pending Orders"
        ' 
        ' revenueLbl
        ' 
        revenueLbl.AutoSize = True
        revenueLbl.Location = New Point(3, 108)
        revenueLbl.Name = "revenueLbl"
        revenueLbl.Size = New Size(116, 15)
        revenueLbl.TabIndex = 4
        revenueLbl.Text = "revenue_placeholder"
        ' 
        ' pendingOrdersLbl
        ' 
        pendingOrdersLbl.AutoSize = True
        pendingOrdersLbl.Location = New Point(400, 108)
        pendingOrdersLbl.Name = "pendingOrdersLbl"
        pendingOrdersLbl.Size = New Size(153, 15)
        pendingOrdersLbl.TabIndex = 5
        pendingOrdersLbl.Text = "pendingOrders_placeholder"
        ' 
        ' visitLogs
        ' 
        visitLogs.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        visitLogs.Location = New Point(243, 4)
        visitLogs.Name = "visitLogs"
        visitLogs.Size = New Size(116, 23)
        visitLogs.TabIndex = 6
        visitLogs.Text = "Visit Logs"
        visitLogs.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 122F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 29F))
        TableLayoutPanel3.Controls.Add(visitLogs, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(400, 184)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Size = New Size(391, 32)
        TableLayoutPanel3.TabIndex = 7
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel2)
        Name = "Dashboard"
        Text = "Dashboard"
        TableLayoutPanel2.ResumeLayout(False)
        CType(dashboardLogDgv, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents dashboardLogDgv As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dashboardHead As Label
    Friend WithEvents dashboardSubhead As Label
    Friend WithEvents dateClm As DataGridViewTextBoxColumn
    Friend WithEvents userClm As DataGridViewTextBoxColumn
    Friend WithEvents actionClm As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents visitLogs As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents revenueLbl As Label
    Friend WithEvents pendingOrdersLbl As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
End Class
