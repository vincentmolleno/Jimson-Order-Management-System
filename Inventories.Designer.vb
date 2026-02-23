<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventories
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
        TableLayoutPanel1 = New TableLayoutPanel()
        updateWasteBtn = New Button()
        Label1 = New Label()
        addItemBtn = New Button()
        Panel1 = New Panel()
        TableLayoutPanel3 = New TableLayoutPanel()
        searchTb = New TextBox()
        exportBtn = New Button()
        statusCb = New ComboBox()
        invDgv = New DataGridView()
        id = New DataGridViewTextBoxColumn()
        itemName = New DataGridViewTextBoxColumn()
        category = New DataGridViewTextBoxColumn()
        quantity = New DataGridViewTextBoxColumn()
        unit = New DataGridViewTextBoxColumn()
        minStock = New DataGridViewTextBoxColumn()
        price = New DataGridViewTextBoxColumn()
        status = New DataGridViewTextBoxColumn()
        invMenu = New ContextMenuStrip(components)
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        CType(invDgv, ComponentModel.ISupportInitialize).BeginInit()
        invMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.Controls.Add(updateWasteBtn, 2, 0)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(addItemBtn, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(800, 51)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' updateWasteBtn
        ' 
        updateWasteBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        updateWasteBtn.Location = New Point(675, 25)
        updateWasteBtn.Name = "updateWasteBtn"
        updateWasteBtn.Size = New Size(122, 23)
        updateWasteBtn.TabIndex = 2
        updateWasteBtn.Text = "Report Wastage"
        updateWasteBtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F)
        Label1.Location = New Point(3, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(265, 32)
        Label1.TabIndex = 0
        Label1.Text = "Inventory Management"
        ' 
        ' addItemBtn
        ' 
        addItemBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        addItemBtn.Location = New Point(472, 25)
        addItemBtn.Name = "addItemBtn"
        addItemBtn.Size = New Size(125, 23)
        addItemBtn.TabIndex = 1
        addItemBtn.Text = "Add/Update Item"
        addItemBtn.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel3)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 51)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 114)
        Panel1.TabIndex = 2
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 64.50883F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 17.7990875F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 17.6920872F))
        TableLayoutPanel3.Controls.Add(searchTb, 0, 0)
        TableLayoutPanel3.Controls.Add(exportBtn, 2, 0)
        TableLayoutPanel3.Controls.Add(statusCb, 1, 0)
        TableLayoutPanel3.Location = New Point(0, 32)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(800, 51)
        TableLayoutPanel3.TabIndex = 1
        ' 
        ' searchTb
        ' 
        searchTb.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        searchTb.Location = New Point(30, 14)
        searchTb.Margin = New Padding(30, 3, 30, 3)
        searchTb.Name = "searchTb"
        searchTb.PlaceholderText = "Search by ID, Item Name, Category, or Status..."
        searchTb.Size = New Size(456, 23)
        searchTb.TabIndex = 0
        ' 
        ' exportBtn
        ' 
        exportBtn.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        exportBtn.Location = New Point(688, 14)
        exportBtn.Margin = New Padding(30, 3, 30, 3)
        exportBtn.Name = "exportBtn"
        exportBtn.Size = New Size(82, 23)
        exportBtn.TabIndex = 1
        exportBtn.Text = "Export to Excel"
        exportBtn.UseVisualStyleBackColor = True
        ' 
        ' statusCb
        ' 
        statusCb.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        statusCb.DropDownStyle = ComboBoxStyle.DropDownList
        statusCb.FormattingEnabled = True
        statusCb.Items.AddRange(New Object() {"All", "Available", "Low Stock"})
        statusCb.Location = New Point(519, 14)
        statusCb.Name = "statusCb"
        statusCb.Size = New Size(136, 23)
        statusCb.TabIndex = 2
        ' 
        ' invDgv
        ' 
        invDgv.BackgroundColor = SystemColors.ControlLightLight
        invDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        invDgv.Columns.AddRange(New DataGridViewColumn() {id, itemName, category, quantity, unit, minStock, price, status})
        invDgv.Dock = DockStyle.Fill
        invDgv.Location = New Point(0, 165)
        invDgv.Name = "invDgv"
        invDgv.RowHeadersVisible = False
        invDgv.Size = New Size(800, 286)
        invDgv.TabIndex = 3
        ' 
        ' id
        ' 
        id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        id.HeaderText = "ID"
        id.Name = "id"
        id.Width = 43
        ' 
        ' itemName
        ' 
        itemName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        itemName.HeaderText = "Item Name"
        itemName.Name = "itemName"
        ' 
        ' category
        ' 
        category.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        category.HeaderText = "Category"
        category.Name = "category"
        category.Width = 80
        ' 
        ' quantity
        ' 
        quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        quantity.HeaderText = "Quantity"
        quantity.Name = "quantity"
        quantity.Width = 78
        ' 
        ' unit
        ' 
        unit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        unit.HeaderText = "Unit"
        unit.Name = "unit"
        unit.Width = 54
        ' 
        ' minStock
        ' 
        minStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        minStock.HeaderText = "Minimum Stock"
        minStock.Name = "minStock"
        minStock.Width = 107
        ' 
        ' price
        ' 
        price.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        price.HeaderText = "Price"
        price.Name = "price"
        price.Width = 58
        ' 
        ' status
        ' 
        status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        status.HeaderText = "Status"
        status.Name = "status"
        status.Width = 64
        ' 
        ' invMenu
        ' 
        invMenu.Items.AddRange(New ToolStripItem() {DeleteToolStripMenuItem})
        invMenu.Name = "invMenu"
        invMenu.Size = New Size(108, 26)
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.Size = New Size(107, 22)
        DeleteToolStripMenuItem.Text = "Delete"
        ' 
        ' Inventories
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(800, 451)
        Controls.Add(invDgv)
        Controls.Add(Panel1)
        Controls.Add(TableLayoutPanel1)
        Name = "Inventories"
        Text = "Inventories"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        Panel1.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        CType(invDgv, ComponentModel.ISupportInitialize).EndInit()
        invMenu.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents searchTb As TextBox
    Friend WithEvents invDgv As DataGridView
    Friend WithEvents exportBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents addItemBtn As Button
    Friend WithEvents statusCb As ComboBox
    Friend WithEvents updateWasteBtn As Button
    Friend WithEvents invMenu As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents minStock As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
