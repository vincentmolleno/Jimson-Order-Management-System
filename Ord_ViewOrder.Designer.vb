<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ord_ViewOrder
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
        Label1 = New Label()
        Label14 = New Label()
        Label6 = New Label()
        TableLayoutPanel6 = New TableLayoutPanel()
        orderDateLbl = New Label()
        idLbl = New Label()
        Label4 = New Label()
        Label = New Label()
        ColumnHeader4 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader1 = New ColumnHeader()
        shipFeeLbl = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        statusLbl = New Label()
        Label10 = New Label()
        paymentLbl = New Label()
        Label5 = New Label()
        shipAddrsLbl = New Label()
        contactDetailsLbl = New Label()
        Label2 = New Label()
        Label3 = New Label()
        notesPh = New Label()
        customerNameLbl = New Label()
        totalLbl = New Label()
        cancelBtn = New Button()
        Label8 = New Label()
        Label9 = New Label()
        TableLayoutPanel5 = New TableLayoutPanel()
        cartLv = New ListView()
        TableLayoutPanel2 = New TableLayoutPanel()
        TableLayoutPanel6.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Location = New Point(3, 181)
        Label1.Name = "Label1"
        Label1.Size = New Size(99, 15)
        Label1.TabIndex = 1
        Label1.Text = "Shipping Address"
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.Left
        Label14.AutoSize = True
        Label14.Location = New Point(3, 265)
        Label14.Name = "Label14"
        Label14.Size = New Size(38, 15)
        Label14.TabIndex = 3
        Label14.Text = "Notes"
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
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 5
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 13.6094675F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.8382645F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 13.8067064F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 26.42998F))
        TableLayoutPanel6.Controls.Add(orderDateLbl, 4, 0)
        TableLayoutPanel6.Controls.Add(idLbl, 2, 0)
        TableLayoutPanel6.Controls.Add(Label6, 0, 0)
        TableLayoutPanel6.Controls.Add(Label4, 1, 0)
        TableLayoutPanel6.Controls.Add(Label, 3, 0)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(3, 3)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 1
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel6.Size = New Size(507, 36)
        TableLayoutPanel6.TabIndex = 3
        ' 
        ' orderDateLbl
        ' 
        orderDateLbl.Anchor = AnchorStyles.Left
        orderDateLbl.AutoSize = True
        orderDateLbl.Location = New Point(374, 10)
        orderDateLbl.Name = "orderDateLbl"
        orderDateLbl.Size = New Size(121, 15)
        orderDateLbl.TabIndex = 4
        orderDateLbl.Text = "orderDatePlaceholder"
        ' 
        ' idLbl
        ' 
        idLbl.Anchor = AnchorStyles.Left
        idLbl.AutoSize = True
        idLbl.Location = New Point(203, 10)
        idLbl.Name = "idLbl"
        idLbl.Size = New Size(84, 15)
        idLbl.TabIndex = 2
        idLbl.Text = "id_placeholder"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Location = New Point(138, 10)
        Label4.Name = "Label4"
        Label4.Size = New Size(59, 15)
        Label4.TabIndex = 1
        Label4.Text = "Order No."
        ' 
        ' Label
        ' 
        Label.Anchor = AnchorStyles.Right
        Label.AutoSize = True
        Label.Location = New Point(311, 3)
        Label.Name = "Label"
        Label.Size = New Size(57, 30)
        Label.TabIndex = 3
        Label.Text = "Date and Time:"
        ' 
        ' ColumnHeader4
        ' 
        ColumnHeader4.Text = "Subtotal"
        ColumnHeader4.Width = 90
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Cost"
        ColumnHeader3.Width = 70
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Quantity"
        ColumnHeader2.Width = 70
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Item"
        ColumnHeader1.Width = 270
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
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(statusLbl, 0, 11)
        TableLayoutPanel1.Controls.Add(Label10, 0, 10)
        TableLayoutPanel1.Controls.Add(paymentLbl, 0, 9)
        TableLayoutPanel1.Controls.Add(Label5, 0, 8)
        TableLayoutPanel1.Controls.Add(shipAddrsLbl, 0, 5)
        TableLayoutPanel1.Controls.Add(contactDetailsLbl, 0, 3)
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(Label1, 0, 4)
        TableLayoutPanel1.Controls.Add(Label3, 0, 2)
        TableLayoutPanel1.Controls.Add(notesPh, 0, 7)
        TableLayoutPanel1.Controls.Add(customerNameLbl, 0, 1)
        TableLayoutPanel1.Controls.Add(Label14, 0, 6)
        TableLayoutPanel1.Location = New Point(8, 4)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 12
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.Size = New Size(359, 511)
        TableLayoutPanel1.TabIndex = 12
        ' 
        ' statusLbl
        ' 
        statusLbl.Anchor = AnchorStyles.Left
        statusLbl.AutoSize = True
        statusLbl.Location = New Point(3, 479)
        statusLbl.Name = "statusLbl"
        statusLbl.Size = New Size(100, 15)
        statusLbl.TabIndex = 17
        statusLbl.Text = "statusPlaceholder"
        ' 
        ' Label10
        ' 
        Label10.Anchor = AnchorStyles.Left
        Label10.AutoSize = True
        Label10.Location = New Point(3, 433)
        Label10.Name = "Label10"
        Label10.Size = New Size(72, 15)
        Label10.TabIndex = 16
        Label10.Text = "Order Status"
        ' 
        ' paymentLbl
        ' 
        paymentLbl.Anchor = AnchorStyles.Left
        paymentLbl.AutoSize = True
        paymentLbl.Location = New Point(3, 391)
        paymentLbl.Name = "paymentLbl"
        paymentLbl.Size = New Size(116, 15)
        paymentLbl.TabIndex = 15
        paymentLbl.Text = "paymentPlaceholder"
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Left
        Label5.AutoSize = True
        Label5.Location = New Point(3, 349)
        Label5.Name = "Label5"
        Label5.Size = New Size(89, 15)
        Label5.TabIndex = 14
        Label5.Text = "Payment Status"
        ' 
        ' shipAddrsLbl
        ' 
        shipAddrsLbl.AutoSize = True
        shipAddrsLbl.Location = New Point(3, 210)
        shipAddrsLbl.Name = "shipAddrsLbl"
        shipAddrsLbl.Size = New Size(146, 15)
        shipAddrsLbl.TabIndex = 13
        shipAddrsLbl.Text = "shippingAddrsPlaceholder"
        ' 
        ' contactDetailsLbl
        ' 
        contactDetailsLbl.AutoSize = True
        contactDetailsLbl.Location = New Point(3, 126)
        contactDetailsLbl.Name = "contactDetailsLbl"
        contactDetailsLbl.Size = New Size(144, 15)
        contactDetailsLbl.TabIndex = 12
        contactDetailsLbl.Text = "contactDetailsPlaceholder"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Location = New Point(3, 13)
        Label2.Name = "Label2"
        Label2.Size = New Size(94, 15)
        Label2.TabIndex = 1
        Label2.Text = "Customer Name"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Left
        Label3.AutoSize = True
        Label3.Location = New Point(3, 97)
        Label3.Name = "Label3"
        Label3.Size = New Size(87, 15)
        Label3.TabIndex = 2
        Label3.Text = "Contact Details"
        ' 
        ' notesPh
        ' 
        notesPh.AutoSize = True
        notesPh.Dock = DockStyle.Fill
        notesPh.Location = New Point(3, 294)
        notesPh.Name = "notesPh"
        notesPh.Size = New Size(353, 42)
        notesPh.TabIndex = 10
        notesPh.Text = "notesPlaceholder"
        ' 
        ' customerNameLbl
        ' 
        customerNameLbl.AutoSize = True
        customerNameLbl.Location = New Point(3, 42)
        customerNameLbl.Name = "customerNameLbl"
        customerNameLbl.Size = New Size(151, 15)
        customerNameLbl.TabIndex = 11
        customerNameLbl.Text = "customerNamePlaceholder"
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
        ' cancelBtn
        ' 
        cancelBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        cancelBtn.Location = New Point(298, 53)
        cancelBtn.Name = "cancelBtn"
        cancelBtn.Size = New Size(206, 44)
        cancelBtn.TabIndex = 3
        cancelBtn.Text = "Close"
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
        TableLayoutPanel5.Location = New Point(370, 1)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 2
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TableLayoutPanel5.Size = New Size(513, 421)
        TableLayoutPanel5.TabIndex = 14
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
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 58.35749F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 41.6425133F))
        TableLayoutPanel2.Controls.Add(shipFeeLbl, 1, 0)
        TableLayoutPanel2.Controls.Add(totalLbl, 1, 1)
        TableLayoutPanel2.Controls.Add(cancelBtn, 1, 2)
        TableLayoutPanel2.Controls.Add(Label8, 0, 0)
        TableLayoutPanel2.Controls.Add(Label9, 0, 1)
        TableLayoutPanel2.Location = New Point(376, 425)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(507, 100)
        TableLayoutPanel2.TabIndex = 13
        ' 
        ' Ord_ViewOrder
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(895, 527)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(TableLayoutPanel5)
        Controls.Add(TableLayoutPanel2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Ord_ViewOrder"
        Text = "Ord_ViewOrder"
        TableLayoutPanel6.ResumeLayout(False)
        TableLayoutPanel6.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents shipFeeLbl As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents totalLbl As Label
    Friend WithEvents cancelBtn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents cartLv As ListView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents notesPh As Label
    Friend WithEvents idLbl As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents customerNameLbl As Label
    Friend WithEvents shipAddrsLbl As Label
    Friend WithEvents contactDetailsLbl As Label
    Friend WithEvents Label As Label
    Friend WithEvents orderDateLbl As Label
    Friend WithEvents statusLbl As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents paymentLbl As Label
    Friend WithEvents Label5 As Label
End Class
