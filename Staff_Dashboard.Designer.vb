<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Staff_Dashboard
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
        TableLayoutPanel1 = New TableLayoutPanel()
        lowStockLbl = New Label()
        dashboardHead = New Label()
        dashboardSubhead = New Label()
        Label1 = New Label()
        Label2 = New Label()
        totalItemsLbl = New Label()
        Button1 = New Button()
        Button2 = New Button()
        staffDgv = New DataGridView()
        itemName = New DataGridViewTextBoxColumn()
        category = New DataGridViewTextBoxColumn()
        quantity = New DataGridViewTextBoxColumn()
        minStock = New DataGridViewTextBoxColumn()
        status = New DataGridViewTextBoxColumn()
        TableLayoutPanel1.SuspendLayout()
        CType(staffDgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 43.47826F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 43.47826F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 13.043478F))
        TableLayoutPanel1.Controls.Add(lowStockLbl, 1, 2)
        TableLayoutPanel1.Controls.Add(dashboardHead, 0, 0)
        TableLayoutPanel1.Controls.Add(dashboardSubhead, 0, 3)
        TableLayoutPanel1.Controls.Add(Label1, 0, 1)
        TableLayoutPanel1.Controls.Add(Label2, 1, 1)
        TableLayoutPanel1.Controls.Add(totalItemsLbl, 0, 2)
        TableLayoutPanel1.Controls.Add(Button1, 1, 3)
        TableLayoutPanel1.Controls.Add(Button2, 2, 3)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.Size = New Size(800, 220)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' lowStockLbl
        ' 
        lowStockLbl.AutoSize = True
        lowStockLbl.Location = New Point(350, 110)
        lowStockLbl.Name = "lowStockLbl"
        lowStockLbl.Size = New Size(69, 15)
        lowStockLbl.TabIndex = 9
        lowStockLbl.Text = "placeholder"
        ' 
        ' dashboardHead
        ' 
        dashboardHead.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        dashboardHead.AutoSize = True
        dashboardHead.Location = New Point(3, 0)
        dashboardHead.Name = "dashboardHead"
        dashboardHead.Size = New Size(116, 55)
        dashboardHead.TabIndex = 0
        dashboardHead.Text = "Dashboard Overview"
        dashboardHead.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' dashboardSubhead
        ' 
        dashboardSubhead.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        dashboardSubhead.AutoSize = True
        dashboardSubhead.Location = New Point(3, 165)
        dashboardSubhead.Name = "dashboardSubhead"
        dashboardSubhead.Size = New Size(113, 55)
        dashboardSubhead.TabIndex = 1
        dashboardSubhead.Text = "Recent Items Added"
        dashboardSubhead.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 55)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 15)
        Label1.TabIndex = 2
        Label1.Text = "Total Items"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(350, 55)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 15)
        Label2.TabIndex = 3
        Label2.Text = "Low Stock Items"
        ' 
        ' totalItemsLbl
        ' 
        totalItemsLbl.AutoSize = True
        totalItemsLbl.Location = New Point(3, 110)
        totalItemsLbl.Name = "totalItemsLbl"
        totalItemsLbl.Size = New Size(69, 15)
        totalItemsLbl.TabIndex = 4
        totalItemsLbl.Text = "placeholder"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Button1.Location = New Point(616, 194)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 11
        Button1.Text = "Add Item"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Button2.Location = New Point(697, 194)
        Button2.Name = "Button2"
        Button2.Size = New Size(100, 23)
        Button2.TabIndex = 12
        Button2.Text = "View All Items"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' staffDgv
        ' 
        staffDgv.BackgroundColor = SystemColors.ControlLightLight
        staffDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        staffDgv.Columns.AddRange(New DataGridViewColumn() {itemName, category, quantity, minStock, status})
        staffDgv.Dock = DockStyle.Fill
        staffDgv.Location = New Point(0, 220)
        staffDgv.Name = "staffDgv"
        staffDgv.RowHeadersVisible = False
        staffDgv.Size = New Size(800, 230)
        staffDgv.TabIndex = 4
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
        ' minStock
        ' 
        minStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        minStock.HeaderText = "Minimum Stock"
        minStock.Name = "minStock"
        minStock.Width = 107
        ' 
        ' status
        ' 
        status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        status.HeaderText = "Status"
        status.Name = "status"
        status.Width = 64
        ' 
        ' Staff_Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(staffDgv)
        Controls.Add(TableLayoutPanel1)
        Name = "Staff_Dashboard"
        Text = "Staff_Dashboard"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(staffDgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lowStockLbl As Label
    Friend WithEvents dashboardHead As Label
    Friend WithEvents dashboardSubhead As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents totalItemsLbl As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents staffDgv As DataGridView
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents minStock As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
