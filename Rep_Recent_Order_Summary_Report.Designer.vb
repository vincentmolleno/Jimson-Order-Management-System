<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rep_Recent_Order_Summary_Report
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
        recentOrderSummaryDgv = New DataGridView()
        orderno = New DataGridViewTextBoxColumn()
        dateCol = New DataGridViewTextBoxColumn()
        customer = New DataGridViewTextBoxColumn()
        itemsCol = New DataGridViewTextBoxColumn()
        Column1 = New DataGridViewTextBoxColumn()
        payment = New DataGridViewTextBoxColumn()
        statusCol = New DataGridViewTextBoxColumn()
        cashierCol = New DataGridViewTextBoxColumn()
        CType(recentOrderSummaryDgv, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' recentOrderSummaryDgv
        ' 
        recentOrderSummaryDgv.BackgroundColor = SystemColors.ControlLightLight
        recentOrderSummaryDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        recentOrderSummaryDgv.Columns.AddRange(New DataGridViewColumn() {orderno, dateCol, customer, itemsCol, Column1, payment, statusCol, cashierCol})
        recentOrderSummaryDgv.Dock = DockStyle.Fill
        recentOrderSummaryDgv.Location = New Point(0, 0)
        recentOrderSummaryDgv.Name = "recentOrderSummaryDgv"
        recentOrderSummaryDgv.RowHeadersVisible = False
        recentOrderSummaryDgv.Size = New Size(800, 450)
        recentOrderSummaryDgv.TabIndex = 7
        ' 
        ' orderno
        ' 
        orderno.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        orderno.HeaderText = "Order No."
        orderno.Name = "orderno"
        orderno.Width = 84
        ' 
        ' dateCol
        ' 
        dateCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dateCol.HeaderText = "Date"
        dateCol.Name = "dateCol"
        dateCol.Width = 56
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
        ' cashierCol
        ' 
        cashierCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        cashierCol.HeaderText = "Cashier"
        cashierCol.Name = "cashierCol"
        cashierCol.Width = 71
        ' 
        ' Rep_Recent_Order_Summary_Report
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(recentOrderSummaryDgv)
        Name = "Rep_Recent_Order_Summary_Report"
        Text = "Rep_Recent_Order_Summary_Report"
        CType(recentOrderSummaryDgv, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents recentOrderSummaryDgv As DataGridView
    Friend WithEvents orderno As DataGridViewTextBoxColumn
    Friend WithEvents dateCol As DataGridViewTextBoxColumn
    Friend WithEvents customer As DataGridViewTextBoxColumn
    Friend WithEvents itemsCol As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents payment As DataGridViewTextBoxColumn
    Friend WithEvents statusCol As DataGridViewTextBoxColumn
    Friend WithEvents cashierCol As DataGridViewTextBoxColumn
End Class
