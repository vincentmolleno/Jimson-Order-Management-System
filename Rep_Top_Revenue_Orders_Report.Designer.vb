<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rep_Top_Revenue_Orders_Report
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
        topRevenueOrdersDgv = New DataGridView()
        Column4 = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        CType(topRevenueOrdersDgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' topRevenueOrdersDgv
        ' 
        topRevenueOrdersDgv.BackgroundColor = SystemColors.ControlLightLight
        topRevenueOrdersDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        topRevenueOrdersDgv.Columns.AddRange(New DataGridViewColumn() {Column4, Column1, Column2, Column3})
        topRevenueOrdersDgv.Dock = DockStyle.Fill
        topRevenueOrdersDgv.Location = New Point(0, 0)
        topRevenueOrdersDgv.Name = "topRevenueOrdersDgv"
        topRevenueOrdersDgv.RowHeadersVisible = False
        topRevenueOrdersDgv.Size = New Size(800, 450)
        topRevenueOrdersDgv.TabIndex = 4
        ' 
        ' Column4
        ' 
        Column4.HeaderText = "Customer"
        Column4.Name = "Column4"
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column1.HeaderText = "Items"
        Column1.Name = "Column1"
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column2.HeaderText = "Payment"
        Column2.Name = "Column2"
        Column2.Width = 79
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column3.HeaderText = "Revenue"
        Column3.Name = "Column3"
        Column3.Width = 77
        ' 
        ' Rep_Top_Revenue_Orders_Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(topRevenueOrdersDgv)
        Name = "Rep_Top_Revenue_Orders_Report"
        Text = "Rep_Top_Revenue_Orders_Report"
        CType(topRevenueOrdersDgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents topRevenueOrdersDgv As DataGridView
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
