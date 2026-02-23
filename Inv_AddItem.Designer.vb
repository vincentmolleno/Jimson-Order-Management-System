<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_AddItem
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
        unitTb = New TextBox()
        minStockTb = New TextBox()
        quantityTb = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label5 = New Label()
        priceLbl = New Label()
        itemNameTb = New TextBox()
        priceTb = New TextBox()
        categoryCb = New ComboBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        Button1 = New Button()
        Button2 = New Button()
        TableLayoutPanel3 = New TableLayoutPanel()
        notesTb = New TextBox()
        supplierTb = New TextBox()
        SupplierLbl = New Label()
        Label8 = New Label()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(unitTb, 1, 3)
        TableLayoutPanel1.Controls.Add(minStockTb, 0, 5)
        TableLayoutPanel1.Controls.Add(quantityTb, 0, 3)
        TableLayoutPanel1.Controls.Add(Label2, 1, 0)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(Label4, 1, 2)
        TableLayoutPanel1.Controls.Add(Label3, 0, 2)
        TableLayoutPanel1.Controls.Add(Label5, 0, 4)
        TableLayoutPanel1.Controls.Add(priceLbl, 1, 4)
        TableLayoutPanel1.Controls.Add(itemNameTb, 0, 1)
        TableLayoutPanel1.Controls.Add(priceTb, 1, 5)
        TableLayoutPanel1.Controls.Add(categoryCb, 1, 1)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 6
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(378, 243)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' unitTb
        ' 
        unitTb.Location = New Point(192, 123)
        unitTb.Name = "unitTb"
        unitTb.Size = New Size(183, 23)
        unitTb.TabIndex = 13
        ' 
        ' minStockTb
        ' 
        minStockTb.Location = New Point(3, 203)
        minStockTb.Name = "minStockTb"
        minStockTb.Size = New Size(183, 23)
        minStockTb.TabIndex = 10
        ' 
        ' quantityTb
        ' 
        quantityTb.Location = New Point(3, 123)
        quantityTb.Name = "quantityTb"
        quantityTb.Size = New Size(183, 23)
        quantityTb.TabIndex = 8
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(192, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 15)
        Label2.TabIndex = 1
        Label2.Text = "Category"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(66, 15)
        Label1.TabIndex = 0
        Label1.Text = "Item Name"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(192, 80)
        Label4.Name = "Label4"
        Label4.Size = New Size(119, 15)
        Label4.TabIndex = 3
        Label4.Text = "Unit of Measurement"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(3, 80)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 15)
        Label3.TabIndex = 2
        Label3.Text = "Quantity"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(3, 160)
        Label5.Name = "Label5"
        Label5.Size = New Size(141, 15)
        Label5.TabIndex = 4
        Label5.Text = "Minimum Stock Quantity"
        ' 
        ' priceLbl
        ' 
        priceLbl.AutoSize = True
        priceLbl.Location = New Point(192, 160)
        priceLbl.Name = "priceLbl"
        priceLbl.Size = New Size(58, 15)
        priceLbl.TabIndex = 5
        priceLbl.Text = "Unit Price"
        ' 
        ' itemNameTb
        ' 
        itemNameTb.Location = New Point(3, 43)
        itemNameTb.Name = "itemNameTb"
        itemNameTb.Size = New Size(183, 23)
        itemNameTb.TabIndex = 6
        ' 
        ' priceTb
        ' 
        priceTb.Location = New Point(192, 203)
        priceTb.Name = "priceTb"
        priceTb.Size = New Size(183, 23)
        priceTb.TabIndex = 11
        ' 
        ' categoryCb
        ' 
        categoryCb.FormattingEnabled = True
        categoryCb.Items.AddRange(New Object() {"Select category"})
        categoryCb.Location = New Point(192, 43)
        categoryCb.Name = "categoryCb"
        categoryCb.Size = New Size(183, 23)
        categoryCb.TabIndex = 12
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(Button1, 0, 0)
        TableLayoutPanel2.Controls.Add(Button2, 1, 0)
        TableLayoutPanel2.Dock = DockStyle.Bottom
        TableLayoutPanel2.Location = New Point(0, 410)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(378, 40)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Enabled = False
        Button1.Location = New Point(3, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(183, 23)
        Button1.TabIndex = 0
        Button1.Text = "Add Inventory Item"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(192, 3)
        Button2.Name = "Button2"
        Button2.Size = New Size(183, 23)
        Button2.TabIndex = 1
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(notesTb, 0, 3)
        TableLayoutPanel3.Controls.Add(supplierTb, 0, 1)
        TableLayoutPanel3.Controls.Add(SupplierLbl, 0, 0)
        TableLayoutPanel3.Controls.Add(Label8, 0, 2)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(0, 243)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 4
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 22.2232056F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 22.22099F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 22.22099F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 33.334816F))
        TableLayoutPanel3.Size = New Size(378, 167)
        TableLayoutPanel3.TabIndex = 2
        ' 
        ' notesTb
        ' 
        notesTb.Location = New Point(3, 114)
        notesTb.Name = "notesTb"
        notesTb.Size = New Size(372, 23)
        notesTb.TabIndex = 9
        ' 
        ' supplierTb
        ' 
        supplierTb.Location = New Point(3, 40)
        supplierTb.Name = "supplierTb"
        supplierTb.Size = New Size(372, 23)
        supplierTb.TabIndex = 8
        ' 
        ' SupplierLbl
        ' 
        SupplierLbl.AutoSize = True
        SupplierLbl.Location = New Point(3, 0)
        SupplierLbl.Name = "SupplierLbl"
        SupplierLbl.Size = New Size(50, 15)
        SupplierLbl.TabIndex = 6
        SupplierLbl.Text = "Supplier"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(3, 74)
        Label8.Name = "Label8"
        Label8.Size = New Size(38, 15)
        Label8.TabIndex = 7
        Label8.Text = "Notes"
        ' 
        ' Inv_AddItem
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(378, 450)
        Controls.Add(TableLayoutPanel3)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel1)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Inv_AddItem"
        Text = "Add New Inventory Item"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents minStockTb As TextBox
    Friend WithEvents quantityTb As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents priceLbl As Label
    Friend WithEvents itemNameTb As TextBox
    Friend WithEvents priceTb As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents notesTb As TextBox
    Friend WithEvents supplierTb As TextBox
    Friend WithEvents SupplierLbl As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents categoryCb As ComboBox
    Friend WithEvents unitTb As TextBox
End Class
