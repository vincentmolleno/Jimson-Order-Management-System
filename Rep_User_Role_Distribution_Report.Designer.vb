<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rep_User_Role_Distribution_Report
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
        userRoleReportDgv = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        CType(userRoleReportDgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' userRoleReportDgv
        ' 
        userRoleReportDgv.BackgroundColor = SystemColors.ControlLightLight
        userRoleReportDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        userRoleReportDgv.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3})
        userRoleReportDgv.Dock = DockStyle.Fill
        userRoleReportDgv.Location = New Point(0, 0)
        userRoleReportDgv.Name = "userRoleReportDgv"
        userRoleReportDgv.RowHeadersVisible = False
        userRoleReportDgv.Size = New Size(800, 450)
        userRoleReportDgv.TabIndex = 5
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column1.HeaderText = "Type"
        Column1.Name = "Column1"
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column2.HeaderText = "User Count"
        Column2.Name = "Column2"
        Column2.Width = 91
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column3.HeaderText = "Percentage"
        Column3.Name = "Column3"
        Column3.Width = 91
        ' 
        ' Rep_User_Role_Distribution_Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(userRoleReportDgv)
        Name = "Rep_User_Role_Distribution_Report"
        Text = "Rep_User_Role_Distribution_Report"
        CType(userRoleReportDgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents userRoleReportDgv As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
