<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rep_Top_Wasted_Items_Analysis_Report
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
        topWastedItemsDgv = New DataGridView()
        cmsWastage = New ContextMenuStrip(components)
        EditToolStripMenuItem = New ToolStripMenuItem()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        id = New DataGridViewTextBoxColumn()
        item = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn2 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn3 = New DataGridViewTextBoxColumn()
        DataGridViewTextBoxColumn4 = New DataGridViewTextBoxColumn()
        CType(topWastedItemsDgv, ComponentModel.ISupportInitialize).BeginInit()
        cmsWastage.SuspendLayout()
        SuspendLayout()
        ' 
        ' topWastedItemsDgv
        ' 
        topWastedItemsDgv.BackgroundColor = SystemColors.ControlLightLight
        topWastedItemsDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        topWastedItemsDgv.Columns.AddRange(New DataGridViewColumn() {id, item, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4})
        topWastedItemsDgv.ContextMenuStrip = cmsWastage
        topWastedItemsDgv.Dock = DockStyle.Fill
        topWastedItemsDgv.Location = New Point(0, 0)
        topWastedItemsDgv.Name = "topWastedItemsDgv"
        topWastedItemsDgv.RowHeadersVisible = False
        topWastedItemsDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        topWastedItemsDgv.Size = New Size(800, 450)
        topWastedItemsDgv.TabIndex = 7
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
        id.HeaderText = "ID"
        id.Name = "id"
        id.Visible = False
        ' 
        ' item
        ' 
        item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        item.HeaderText = "Item"
        item.Name = "item"
        ' 
        ' DataGridViewTextBoxColumn2
        ' 
        DataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewTextBoxColumn2.HeaderText = "Category"
        DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        ' 
        ' DataGridViewTextBoxColumn3
        ' 
        DataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewTextBoxColumn3.HeaderText = "Incidents"
        DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        DataGridViewTextBoxColumn3.Width = 80
        ' 
        ' DataGridViewTextBoxColumn4
        ' 
        DataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewTextBoxColumn4.HeaderText = "Total Cost"
        DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        DataGridViewTextBoxColumn4.Width = 84
        ' 
        ' Rep_Top_Wasted_Items_Analysis_Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(topWastedItemsDgv)
        Name = "Rep_Top_Wasted_Items_Analysis_Report"
        Text = "Rep_Top_Wasted_Items_Analysis_Report"
        CType(topWastedItemsDgv, ComponentModel.ISupportInitialize).EndInit()
        cmsWastage.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents topWastedItemsDgv As DataGridView
    Friend WithEvents cmsWastage As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents item As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
End Class
