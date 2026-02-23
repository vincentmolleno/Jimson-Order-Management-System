<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_NewOrder
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
        itemNameTb = New TextBox()
        contactDetailsTb = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        customerNameTb = New TextBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        shipFeeLbl = New Label()
        totalLbl = New Label()
        orderBtn = New Button()
        cancelBtn = New Button()
        Label8 = New Label()
        Label9 = New Label()
        TableLayoutPanel5 = New TableLayoutPanel()
        cartLv = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        TableLayoutPanel6 = New TableLayoutPanel()
        Label6 = New Label()
        removeItemBtn = New Button()
        TableLayoutPanel4 = New TableLayoutPanel()
        quantityTb = New TextBox()
        Label5 = New Label()
        addItemBtn = New Button()
        TableLayoutPanel3 = New TableLayoutPanel()
        notesTb = New TextBox()
        shipFeeTb = New TextBox()
        Label1 = New Label()
        Label7 = New Label()
        Label14 = New Label()
        shipAddrsTb = New TextBox()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(itemNameTb, 0, 5)
        TableLayoutPanel1.Controls.Add(contactDetailsTb, 0, 3)
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(Label3, 0, 2)
        TableLayoutPanel1.Controls.Add(Label4, 0, 4)
        TableLayoutPanel1.Controls.Add(customerNameTb, 0, 1)
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 6
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(359, 202)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' itemNameTb
        ' 
        itemNameTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        itemNameTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        itemNameTb.AutoCompleteSource = AutoCompleteSource.CustomSource
        itemNameTb.Location = New Point(3, 168)
        itemNameTb.Name = "itemNameTb"
        itemNameTb.PlaceholderText = "Type here to find an item from inventory..."
        itemNameTb.Size = New Size(353, 23)
        itemNameTb.TabIndex = 10
        ' 
        ' contactDetailsTb
        ' 
        contactDetailsTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        contactDetailsTb.Location = New Point(3, 102)
        contactDetailsTb.Name = "contactDetailsTb"
        contactDetailsTb.Size = New Size(353, 23)
        contactDetailsTb.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(353, 33)
        Label2.TabIndex = 1
        Label2.Text = "Customer Name"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.Location = New Point(3, 66)
        Label3.Name = "Label3"
        Label3.Size = New Size(353, 33)
        Label3.TabIndex = 2
        Label3.Text = "Contact Details"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Location = New Point(3, 132)
        Label4.Name = "Label4"
        Label4.Size = New Size(353, 33)
        Label4.TabIndex = 3
        Label4.Text = "Item Name"
        ' 
        ' customerNameTb
        ' 
        customerNameTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        customerNameTb.Location = New Point(3, 36)
        customerNameTb.Name = "customerNameTb"
        customerNameTb.Size = New Size(353, 23)
        customerNameTb.TabIndex = 8
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 58.35749F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 41.6425133F))
        TableLayoutPanel2.Controls.Add(shipFeeLbl, 1, 0)
        TableLayoutPanel2.Controls.Add(totalLbl, 1, 1)
        TableLayoutPanel2.Controls.Add(orderBtn, 0, 2)
        TableLayoutPanel2.Controls.Add(cancelBtn, 1, 2)
        TableLayoutPanel2.Controls.Add(Label8, 0, 0)
        TableLayoutPanel2.Controls.Add(Label9, 0, 1)
        TableLayoutPanel2.Location = New Point(365, 424)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(507, 100)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' shipFeeLbl
        ' 
        shipFeeLbl.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        shipFeeLbl.AutoSize = True
        shipFeeLbl.Location = New Point(429, 0)
        shipFeeLbl.Name = "shipFeeLbl"
        shipFeeLbl.Size = New Size(75, 15)
        shipFeeLbl.TabIndex = 6
        shipFeeLbl.Text = "Shipping Fee"
        ' 
        ' totalLbl
        ' 
        totalLbl.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        totalLbl.AutoSize = True
        totalLbl.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        totalLbl.Location = New Point(470, 25)
        totalLbl.Name = "totalLbl"
        totalLbl.Size = New Size(34, 15)
        totalLbl.TabIndex = 7
        totalLbl.Text = "Total"
        ' 
        ' orderBtn
        ' 
        orderBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        orderBtn.Location = New Point(3, 53)
        orderBtn.Name = "orderBtn"
        orderBtn.Size = New Size(289, 44)
        orderBtn.TabIndex = 2
        orderBtn.Text = "Order"
        orderBtn.UseVisualStyleBackColor = True
        ' 
        ' cancelBtn
        ' 
        cancelBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        cancelBtn.Location = New Point(298, 53)
        cancelBtn.Name = "cancelBtn"
        cancelBtn.Size = New Size(206, 44)
        cancelBtn.TabIndex = 3
        cancelBtn.Text = "Cancel"
        cancelBtn.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label8.AutoSize = True
        Label8.Location = New Point(217, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(75, 15)
        Label8.TabIndex = 4
        Label8.Text = "Shipping Fee"
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label9.Location = New Point(258, 25)
        Label9.Name = "Label9"
        Label9.Size = New Size(34, 15)
        Label9.TabIndex = 5
        Label9.Text = "Total"
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel5.ColumnCount = 1
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.Controls.Add(cartLv, 0, 1)
        TableLayoutPanel5.Controls.Add(TableLayoutPanel6, 0, 0)
        TableLayoutPanel5.Location = New Point(359, 0)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 2
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TableLayoutPanel5.Size = New Size(513, 421)
        TableLayoutPanel5.TabIndex = 9
        ' 
        ' cartLv
        ' 
        cartLv.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4})
        cartLv.Dock = DockStyle.Fill
        cartLv.FullRowSelect = True
        cartLv.GridLines = True
        cartLv.Location = New Point(3, 45)
        cartLv.Name = "cartLv"
        cartLv.Size = New Size(507, 373)
        cartLv.TabIndex = 2
        cartLv.UseCompatibleStateImageBehavior = False
        cartLv.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Item"
        ColumnHeader1.Width = 270
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Quantity"
        ColumnHeader2.Width = 70
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Cost"
        ColumnHeader3.Width = 70
        ' 
        ' ColumnHeader4
        ' 
        ColumnHeader4.Text = "Subtotal"
        ColumnHeader4.Width = 90
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 2
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.Controls.Add(Label6, 0, 0)
        TableLayoutPanel6.Controls.Add(removeItemBtn, 1, 0)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(3, 3)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 1
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.Size = New Size(507, 36)
        TableLayoutPanel6.TabIndex = 3
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Left
        Label6.AutoSize = True
        Label6.Location = New Point(3, 10)
        Label6.Name = "Label6"
        Label6.Size = New Size(29, 15)
        Label6.TabIndex = 0
        Label6.Text = "Cart"
        ' 
        ' removeItemBtn
        ' 
        removeItemBtn.Anchor = AnchorStyles.Right
        removeItemBtn.Location = New Point(374, 6)
        removeItemBtn.Name = "removeItemBtn"
        removeItemBtn.Size = New Size(130, 23)
        removeItemBtn.TabIndex = 1
        removeItemBtn.Text = "Remove Item"
        removeItemBtn.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel4.ColumnCount = 3
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 31.03448F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 6.89655161F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 31.034483F))
        TableLayoutPanel4.Controls.Add(quantityTb, 0, 1)
        TableLayoutPanel4.Controls.Add(Label5, 0, 0)
        TableLayoutPanel4.Controls.Add(addItemBtn, 2, 1)
        TableLayoutPanel4.Location = New Point(5, 208)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(351, 77)
        TableLayoutPanel4.TabIndex = 10
        ' 
        ' quantityTb
        ' 
        quantityTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        quantityTb.Location = New Point(3, 41)
        quantityTb.Name = "quantityTb"
        quantityTb.Size = New Size(151, 23)
        quantityTb.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Location = New Point(3, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(151, 38)
        Label5.TabIndex = 4
        Label5.Text = "Quantity"
        ' 
        ' addItemBtn
        ' 
        addItemBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        addItemBtn.Location = New Point(195, 41)
        addItemBtn.Name = "addItemBtn"
        addItemBtn.Size = New Size(153, 33)
        addItemBtn.TabIndex = 12
        addItemBtn.Text = "Add Item"
        addItemBtn.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(notesTb, 0, 5)
        TableLayoutPanel3.Controls.Add(shipFeeTb, 0, 3)
        TableLayoutPanel3.Controls.Add(Label1, 0, 0)
        TableLayoutPanel3.Controls.Add(Label7, 0, 2)
        TableLayoutPanel3.Controls.Add(Label14, 0, 4)
        TableLayoutPanel3.Controls.Add(shipAddrsTb, 0, 1)
        TableLayoutPanel3.Location = New Point(0, 291)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 6
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 7.142857F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel3.Size = New Size(359, 233)
        TableLayoutPanel3.TabIndex = 11
        ' 
        ' notesTb
        ' 
        notesTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        notesTb.Location = New Point(3, 193)
        notesTb.Name = "notesTb"
        notesTb.Size = New Size(353, 23)
        notesTb.TabIndex = 10
        ' 
        ' shipFeeTb
        ' 
        shipFeeTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        shipFeeTb.Location = New Point(3, 117)
        shipFeeTb.Name = "shipFeeTb"
        shipFeeTb.Size = New Size(353, 23)
        shipFeeTb.TabIndex = 9
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(353, 38)
        Label1.TabIndex = 1
        Label1.Text = "Shipping Address"
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label7.AutoSize = True
        Label7.Location = New Point(3, 76)
        Label7.Name = "Label7"
        Label7.Size = New Size(353, 38)
        Label7.TabIndex = 2
        Label7.Text = "Shipping Fee"
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label14.AutoSize = True
        Label14.Location = New Point(3, 152)
        Label14.Name = "Label14"
        Label14.Size = New Size(353, 38)
        Label14.TabIndex = 3
        Label14.Text = "Notes (optional)"
        ' 
        ' shipAddrsTb
        ' 
        shipAddrsTb.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        shipAddrsTb.Location = New Point(3, 41)
        shipAddrsTb.Name = "shipAddrsTb"
        shipAddrsTb.Size = New Size(353, 23)
        shipAddrsTb.TabIndex = 8
        ' 
        ' Ord_NewOrder
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(875, 524)
        Controls.Add(TableLayoutPanel3)
        Controls.Add(TableLayoutPanel4)
        Controls.Add(TableLayoutPanel5)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel1)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Ord_NewOrder"
        Text = "New Order"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel6.ResumeLayout(False)
        TableLayoutPanel6.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents contactDetailsTb As TextBox
    Friend WithEvents customerNameTb As TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents orderBtn As Button
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents quantityTb As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents addItemBtn As Button
    Friend WithEvents itemNameTb As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents notesTb As TextBox
    Friend WithEvents shipFeeTb As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents shipAddrsTb As TextBox
    Friend WithEvents cancelBtn As Button
    Friend WithEvents cartLv As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents shipFeeLbl As Label
    Friend WithEvents totalLbl As Label
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents removeItemBtn As Button
End Class
