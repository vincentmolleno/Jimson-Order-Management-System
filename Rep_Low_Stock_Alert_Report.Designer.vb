<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rep_Low_Stock_Alert_Report
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
        lowStockDgv = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        CType(lowStockDgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lowStockDgv
        ' 
        lowStockDgv.BackgroundColor = SystemColors.ControlLightLight
        lowStockDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        lowStockDgv.Columns.AddRange(New DataGridViewColumn() {Column1, Column6, Column2, Column3, Column4, Column5})
        lowStockDgv.Dock = DockStyle.Fill
        lowStockDgv.Location = New Point(0, 0)
        lowStockDgv.Name = "lowStockDgv"
        lowStockDgv.RowHeadersVisible = False
        lowStockDgv.Size = New Size(800, 450)
        lowStockDgv.TabIndex = 4
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column1.HeaderText = "Item"
        Column1.Name = "Column1"
        ' 
        ' Column6
        ' 
        Column6.HeaderText = "Category"
        Column6.Name = "Column6"
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column2.HeaderText = "Current Stock"
        Column2.Name = "Column2"
        Column2.Width = 96
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column3.HeaderText = "Minimum Required"
        Column3.Name = "Column3"
        Column3.Width = 124
        ' 
        ' Column4
        ' 
        Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column4.HeaderText = "Total Value"
        Column4.Name = "Column4"
        Column4.Width = 81
        ' 
        ' Column5
        ' 
        Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column5.HeaderText = "Status"
        Column5.Name = "Column5"
        Column5.Width = 64
        ' 
        ' Rep_Low_Stock_Alert_Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lowStockDgv)
        Name = "Rep_Low_Stock_Alert_Report"
        Text = "Rep_Low_Stock_Alert_Report"
        CType(lowStockDgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lowStockDgv As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
End Class
