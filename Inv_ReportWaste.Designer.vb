<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_ReportWaste
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
        reasonTb = New TextBox()
        quantityTb = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        reportBtn = New Button()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoScroll = True
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Controls.Add(itemNameTb, 0, 2)
        TableLayoutPanel1.Controls.Add(reasonTb, 0, 6)
        TableLayoutPanel1.Controls.Add(quantityTb, 0, 4)
        TableLayoutPanel1.Controls.Add(Label2, 0, 1)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(Label3, 0, 3)
        TableLayoutPanel1.Controls.Add(Label4, 0, 5)
        TableLayoutPanel1.Controls.Add(reportBtn, 0, 7)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 8
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.523809F))
        TableLayoutPanel1.Size = New Size(448, 290)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' itemNameTb
        ' 
        itemNameTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        itemNameTb.AutoCompleteSource = AutoCompleteSource.CustomSource
        itemNameTb.Dock = DockStyle.Fill
        itemNameTb.Location = New Point(3, 75)
        itemNameTb.Name = "itemNameTb"
        itemNameTb.Size = New Size(442, 23)
        itemNameTb.TabIndex = 11
        ' 
        ' reasonTb
        ' 
        reasonTb.Dock = DockStyle.Fill
        reasonTb.Location = New Point(3, 219)
        reasonTb.Name = "reasonTb"
        reasonTb.Size = New Size(442, 23)
        reasonTb.TabIndex = 9
        ' 
        ' quantityTb
        ' 
        quantityTb.Dock = DockStyle.Fill
        quantityTb.Location = New Point(3, 147)
        quantityTb.Name = "quantityTb"
        quantityTb.Size = New Size(442, 23)
        quantityTb.TabIndex = 8
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(3, 36)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 15)
        Label2.TabIndex = 1
        Label2.Text = "Which item?"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(90, 15)
        Label1.TabIndex = 0
        Label1.Text = "Report Wastage"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(3, 108)
        Label3.Name = "Label3"
        Label3.Size = New Size(134, 15)
        Label3.TabIndex = 2
        Label3.Text = "How much was wasted?"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(3, 180)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 15)
        Label4.TabIndex = 3
        Label4.Text = "Reason"
        ' 
        ' reportBtn
        ' 
        reportBtn.Location = New Point(3, 255)
        reportBtn.Name = "reportBtn"
        reportBtn.Size = New Size(75, 23)
        reportBtn.TabIndex = 5
        reportBtn.Text = "Report"
        reportBtn.UseVisualStyleBackColor = True
        ' 
        ' Inv_ReportWaste
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(448, 290)
        Controls.Add(TableLayoutPanel1)
        Name = "Inv_ReportWaste"
        Text = "Inv_UpdateWaste"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents reportBtn As Button
    Friend WithEvents reasonTb As TextBox
    Friend WithEvents quantityTb As TextBox
    Friend WithEvents itemNameTb As TextBox
End Class
