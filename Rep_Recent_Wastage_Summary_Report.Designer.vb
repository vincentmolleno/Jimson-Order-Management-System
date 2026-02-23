<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rep_Recent_Wastage_Summary_Report
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
        components = New ComponentModel.Container()
        recentWastageSummaryDgv = New DataGridView()
        cmsWastage = New ContextMenuStrip(components)
        EditToolStripMenuItem = New ToolStripMenuItem()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        id = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        CType(recentWastageSummaryDgv, ComponentModel.ISupportInitialize).BeginInit()
        cmsWastage.SuspendLayout()
        SuspendLayout()
        ' 
        ' recentWastageSummaryDgv
        ' 
        recentWastageSummaryDgv.BackgroundColor = SystemColors.ControlLightLight
        recentWastageSummaryDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        recentWastageSummaryDgv.Columns.AddRange(New DataGridViewColumn() {id, Column1, Column2, Column3, Column4, Column5, Column6})
        recentWastageSummaryDgv.ContextMenuStrip = cmsWastage
        recentWastageSummaryDgv.Dock = DockStyle.Fill
        recentWastageSummaryDgv.Location = New Point(0, 0)
        recentWastageSummaryDgv.Name = "recentWastageSummaryDgv"
        recentWastageSummaryDgv.RowHeadersVisible = False
        recentWastageSummaryDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        recentWastageSummaryDgv.Size = New Size(800, 450)
        recentWastageSummaryDgv.TabIndex = 5
        ' 
        ' cmsWastage
        ' 
        cmsWastage.Items.AddRange(New ToolStripItem() {EditToolStripMenuItem, DeleteToolStripMenuItem})
        cmsWastage.Name = "ContextMenuStrip1"
        cmsWastage.Size = New Size(108, 48)
        ' 
        ' EditToolStripMenuItem
        ' 
        EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        EditToolStripMenuItem.Size = New Size(107, 22)
        EditToolStripMenuItem.Text = "Edit"
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.Size = New Size(107, 22)
        DeleteToolStripMenuItem.Text = "Delete"
        ' 
        ' id
        ' 
        id.HeaderText = "id"
        id.Name = "id"
        id.Visible = False
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column1.HeaderText = "Date"
        Column1.Name = "Column1"
        Column1.Width = 56
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column2.HeaderText = "Item"
        Column2.Name = "Column2"
        Column2.Width = 56
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column3.HeaderText = "Quantity"
        Column3.Name = "Column3"
        Column3.Width = 78
        ' 
        ' Column4
        ' 
        Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column4.HeaderText = "Reason"
        Column4.Name = "Column4"
        ' 
        ' Column5
        ' 
        Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column5.HeaderText = "Reported By"
        Column5.Name = "Column5"
        Column5.Width = 96
        ' 
        ' Column6
        ' 
        Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column6.HeaderText = "Total Cost"
        Column6.Name = "Column6"
        Column6.Width = 84
        ' 
        ' Rep_Recent_Wastage_Summary_Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(recentWastageSummaryDgv)
        Name = "Rep_Recent_Wastage_Summary_Report"
        Text = "Rep_Recent_Wastage_Summary_Report"
        CType(recentWastageSummaryDgv, ComponentModel.ISupportInitialize).EndInit()
        cmsWastage.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents recentWastageSummaryDgv As DataGridView
    Friend WithEvents cmsWastage As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
End Class
