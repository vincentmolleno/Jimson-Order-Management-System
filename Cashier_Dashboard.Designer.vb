<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cashier_Dashboard
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
        completedLbl = New Label()
        processingLbl = New Label()
        dashboardHead = New Label()
        dashboardSubhead = New Label()
        Label1 = New Label()
        Label2 = New Label()
        revenueLbl = New Label()
        Label3 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        cashDgv = New DataGridView()
        orderno = New DataGridViewTextBoxColumn()
        customer = New DataGridViewTextBoxColumn()
        itemsCol = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        payment = New DataGridViewTextBoxColumn()
        statusCol = New DataGridViewTextBoxColumn()
        TableLayoutPanel1.SuspendLayout()
        CType(cashDgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.Controls.Add(completedLbl, 2, 2)
        TableLayoutPanel1.Controls.Add(processingLbl, 1, 2)
        TableLayoutPanel1.Controls.Add(dashboardHead, 0, 0)
        TableLayoutPanel1.Controls.Add(dashboardSubhead, 0, 3)
        TableLayoutPanel1.Controls.Add(Label1, 0, 1)
        TableLayoutPanel1.Controls.Add(Label2, 1, 1)
        TableLayoutPanel1.Controls.Add(revenueLbl, 0, 2)
        TableLayoutPanel1.Controls.Add(Label3, 2, 1)
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
        TableLayoutPanel1.TabIndex = 2
        ' 
        ' completedLbl
        ' 
        completedLbl.AutoSize = True
        completedLbl.Location = New Point(535, 110)
        completedLbl.Name = "completedLbl"
        completedLbl.Size = New Size(69, 15)
        completedLbl.TabIndex = 10
        completedLbl.Text = "placeholder"
        ' 
        ' processingLbl
        ' 
        processingLbl.AutoSize = True
        processingLbl.Location = New Point(269, 110)
        processingLbl.Name = "processingLbl"
        processingLbl.Size = New Size(69, 15)
        processingLbl.TabIndex = 9
        processingLbl.Text = "placeholder"
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
        dashboardSubhead.Size = New Size(81, 55)
        dashboardSubhead.TabIndex = 1
        dashboardSubhead.Text = "Recent Orders"
        dashboardSubhead.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 55)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 15)
        Label1.TabIndex = 2
        Label1.Text = "Orders Pending"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(269, 55)
        Label2.Name = "Label2"
        Label2.Size = New Size(102, 15)
        Label2.TabIndex = 3
        Label2.Text = "Orders Processing"
        ' 
        ' revenueLbl
        ' 
        revenueLbl.AutoSize = True
        revenueLbl.Location = New Point(3, 110)
        revenueLbl.Name = "revenueLbl"
        revenueLbl.Size = New Size(69, 15)
        revenueLbl.TabIndex = 4
        revenueLbl.Text = "placeholder"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(535, 55)
        Label3.Name = "Label3"
        Label3.Size = New Size(104, 15)
        Label3.TabIndex = 6
        Label3.Text = "Orders Completed"
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Button1.Location = New Point(454, 194)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 11
        Button1.Text = "New Order"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Button2.Location = New Point(692, 194)
        Button2.Name = "Button2"
        Button2.Size = New Size(105, 23)
        Button2.TabIndex = 12
        Button2.Text = "View All Orders"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' cashDgv
        ' 
        cashDgv.BackgroundColor = SystemColors.ControlLightLight
        cashDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        cashDgv.Columns.AddRange(New DataGridViewColumn() {orderno, customer, itemsCol, Column1, payment, statusCol})
        cashDgv.Dock = DockStyle.Fill
        cashDgv.Location = New Point(0, 220)
        cashDgv.Name = "cashDgv"
        cashDgv.RowHeadersVisible = False
        cashDgv.Size = New Size(800, 230)
        cashDgv.TabIndex = 3
        ' 
        ' orderno
        ' 
        orderno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        orderno.HeaderText = "Order No."
        orderno.Name = "orderno"
        orderno.Width = 84
        ' 
        ' customer
        ' 
        customer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        customer.HeaderText = "Customer"
        customer.Name = "customer"
        ' 
        ' itemsCol
        ' 
        itemsCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        itemsCol.HeaderText = "Items"
        itemsCol.Name = "itemsCol"
        itemsCol.Width = 61
        ' 
        ' Column1
        ' 
        Column1.HeaderText = "Total Cost"
        Column1.Name = "Column1"
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
        ' Cashier_Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(800, 450)
        Controls.Add(cashDgv)
        Controls.Add(TableLayoutPanel1)
        Name = "Cashier_Dashboard"
        Text = "Cashier_Dashboard"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(cashDgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dashboardHead As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents revenueLbl As Label
    Friend WithEvents dashboardSubhead As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents completedLbl As Label
    Friend WithEvents processingLbl As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cashDgv As DataGridView
    Friend WithEvents orderno As DataGridViewTextBoxColumn
    Friend WithEvents customer As DataGridViewTextBoxColumn
    Friend WithEvents itemsCol As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents payment As DataGridViewTextBoxColumn
    Friend WithEvents statusCol As DataGridViewTextBoxColumn
End Class
