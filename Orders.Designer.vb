<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Orders
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
        Label4 = New Label()
        newOrdBtn = New Button()
        TableLayoutPanel2 = New TableLayoutPanel()
        paymentCb = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        searchTb = New TextBox()
        statusCb = New ComboBox()
        orderDgv = New DataGridView()
        id = New DataGridViewTextBoxColumn()
        dateCol = New DataGridViewTextBoxColumn()
        customer = New DataGridViewTextBoxColumn()
        itemsCol = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        payment = New DataGridViewTextBoxColumn()
        statusCol = New DataGridViewTextBoxColumn()
        orderMenu = New ContextMenuStrip(components)
        ViewToolStripMenuItem = New ToolStripMenuItem()
        EditOrderToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        DeleteOrderToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(orderDgv, ComponentModel.ISupportInitialize).BeginInit()
        orderMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Label4, 0, 0)
        TableLayoutPanel1.Controls.Add(newOrdBtn, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(800, 67)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 18F)
        Label4.Location = New Point(3, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(225, 32)
        Label4.TabIndex = 1
        Label4.Text = "Order Management"
        ' 
        ' newOrdBtn
        ' 
        newOrdBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        newOrdBtn.Location = New Point(722, 3)
        newOrdBtn.Name = "newOrdBtn"
        newOrdBtn.Size = New Size(75, 23)
        newOrdBtn.TabIndex = 2
        newOrdBtn.Text = "New Order"
        newOrdBtn.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 57.68199F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.1590061F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.1590061F))
        TableLayoutPanel2.Controls.Add(paymentCb, 2, 1)
        TableLayoutPanel2.Controls.Add(Label3, 1, 0)
        TableLayoutPanel2.Controls.Add(Label2, 0, 0)
        TableLayoutPanel2.Controls.Add(Label1, 2, 0)
        TableLayoutPanel2.Controls.Add(searchTb, 0, 1)
        TableLayoutPanel2.Controls.Add(statusCb, 1, 1)
        TableLayoutPanel2.Dock = DockStyle.Top
        TableLayoutPanel2.Location = New Point(0, 67)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 35F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 65F))
        TableLayoutPanel2.Size = New Size(800, 100)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' paymentCb
        ' 
        paymentCb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        paymentCb.DropDownStyle = ComboBoxStyle.DropDownList
        paymentCb.FormattingEnabled = True
        paymentCb.Items.AddRange(New Object() {"All", "Paid", "Unpaid"})
        paymentCb.Location = New Point(633, 38)
        paymentCb.Name = "paymentCb"
        paymentCb.Size = New Size(164, 23)
        paymentCb.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label3.Location = New Point(464, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 15)
        Label3.TabIndex = 2
        Label3.Text = "Filter by Status"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 15)
        Label2.TabIndex = 1
        Label2.Text = "Search Orders"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(633, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 15)
        Label1.TabIndex = 0
        Label1.Text = "Filter by Payment"
        ' 
        ' searchTb
        ' 
        searchTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        searchTb.Location = New Point(3, 38)
        searchTb.Name = "searchTb"
        searchTb.PlaceholderText = "Search by order no., customer, status"
        searchTb.Size = New Size(455, 23)
        searchTb.TabIndex = 3
        ' 
        ' statusCb
        ' 
        statusCb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        statusCb.DropDownStyle = ComboBoxStyle.DropDownList
        statusCb.FormattingEnabled = True
        statusCb.Items.AddRange(New Object() {"All", "Pending", "Processing", "Shipping", "Completed"})
        statusCb.Location = New Point(464, 38)
        statusCb.Name = "statusCb"
        statusCb.Size = New Size(163, 23)
        statusCb.TabIndex = 4
        ' 
        ' orderDgv
        ' 
        orderDgv.BackgroundColor = SystemColors.ControlLightLight
        orderDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        orderDgv.Columns.AddRange(New DataGridViewColumn() {id, dateCol, customer, itemsCol, Column1, payment, statusCol})
        orderDgv.Dock = DockStyle.Fill
        orderDgv.Location = New Point(0, 167)
        orderDgv.Name = "orderDgv"
        orderDgv.RowHeadersVisible = False
        orderDgv.Size = New Size(800, 283)
        orderDgv.TabIndex = 2
        ' 
        ' id
        ' 
        id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        id.HeaderText = "Order No."
        id.Name = "id"
        id.Width = 84
        ' 
        ' dateCol
        ' 
        dateCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dateCol.HeaderText = "Date and Time"
        dateCol.Name = "dateCol"
        dateCol.Width = 99
        ' 
        ' customer
        ' 
        customer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        customer.HeaderText = "Customer"
        customer.Name = "customer"
        ' 
        ' itemsCol
        ' 
        itemsCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        itemsCol.HeaderText = "Items"
        itemsCol.Name = "itemsCol"
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column1.HeaderText = "Total Cost"
        Column1.Name = "Column1"
        Column1.Width = 78
        ' 
        ' payment
        ' 
        payment.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        payment.HeaderText = "Payment"
        payment.Name = "payment"
        payment.Width = 79
        ' 
        ' statusCol
        ' 
        statusCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        statusCol.HeaderText = "Status"
        statusCol.Name = "statusCol"
        statusCol.Width = 64
        ' 
        ' orderMenu
        ' 
        orderMenu.Items.AddRange(New ToolStripItem() {ViewToolStripMenuItem, EditOrderToolStripMenuItem, ToolStripMenuItem1, DeleteOrderToolStripMenuItem})
        orderMenu.Name = "ContextMenuStrip1"
        orderMenu.Size = New Size(164, 92)
        ' 
        ' ViewToolStripMenuItem
        ' 
        ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        ViewToolStripMenuItem.Size = New Size(163, 22)
        ViewToolStripMenuItem.Text = "View"
        ' 
        ' EditOrderToolStripMenuItem
        ' 
        EditOrderToolStripMenuItem.Name = "EditOrderToolStripMenuItem"
        EditOrderToolStripMenuItem.Size = New Size(163, 22)
        EditOrderToolStripMenuItem.Text = "Edit Order"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(163, 22)
        ToolStripMenuItem1.Text = "Generate Receipt"
        ' 
        ' DeleteOrderToolStripMenuItem
        ' 
        DeleteOrderToolStripMenuItem.Name = "DeleteOrderToolStripMenuItem"
        DeleteOrderToolStripMenuItem.Size = New Size(163, 22)
        DeleteOrderToolStripMenuItem.Text = "Delete Order"
        ' 
        ' Orders
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(800, 450)
        Controls.Add(orderDgv)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel1)
        Name = "Orders"
        Text = "Orders"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        CType(orderDgv, ComponentModel.ISupportInitialize).EndInit()
        orderMenu.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents orderDgv As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents newOrdBtn As Button
    Friend WithEvents paymentCb As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents searchTb As TextBox
    Friend WithEvents statusCb As ComboBox
    Friend WithEvents orderMenu As ContextMenuStrip
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DeleteOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents dateCol As DataGridViewTextBoxColumn
    Friend WithEvents customer As DataGridViewTextBoxColumn
    Friend WithEvents itemsCol As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents payment As DataGridViewTextBoxColumn
    Friend WithEvents statusCol As DataGridViewTextBoxColumn
End Class
