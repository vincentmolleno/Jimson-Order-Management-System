<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rep_User_Status_Summary_Report
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
        usrStatSumRepDgv = New DataGridView()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        CType(usrStatSumRepDgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' usrStatSumRepDgv
        ' 
        usrStatSumRepDgv.BackgroundColor = SystemColors.ControlLightLight
        usrStatSumRepDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        usrStatSumRepDgv.Columns.AddRange(New DataGridViewColumn() {Column3, Column4, Column5, Column1, Column2})
        usrStatSumRepDgv.Dock = DockStyle.Fill
        usrStatSumRepDgv.Location = New Point(0, 0)
        usrStatSumRepDgv.Name = "usrStatSumRepDgv"
        usrStatSumRepDgv.RowHeadersVisible = False
        usrStatSumRepDgv.Size = New Size(800, 450)
        usrStatSumRepDgv.TabIndex = 4
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column3.HeaderText = "Name"
        Column3.Name = "Column3"
        ' 
        ' Column4
        ' 
        Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column4.HeaderText = "Phone"
        Column4.Name = "Column4"
        Column4.Width = 66
        ' 
        ' Column5
        ' 
        Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column5.HeaderText = "Email"
        Column5.Name = "Column5"
        Column5.Width = 61
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column1.HeaderText = "Type"
        Column1.Name = "Column1"
        Column1.Width = 56
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column2.HeaderText = "Last Active"
        Column2.Name = "Column2"
        Column2.Width = 89
        ' 
        ' Rep_User_Status_Summary_Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(usrStatSumRepDgv)
        Name = "Rep_User_Status_Summary_Report"
        Text = "Rep_User_Status_Summary_Report"
        CType(usrStatSumRepDgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents usrStatSumRepDgv As DataGridView
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
