<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Backup_and_Recovery
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
        Panel1 = New Panel()
        Label1 = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label2 = New Label()
        TableLayoutPanel4 = New TableLayoutPanel()
        restoreBackupButton = New Button()
        createBackupButton = New Button()
        Label4 = New Label()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 29)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(12, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(127, 15)
        Label1.TabIndex = 0
        Label1.Text = "Backup and Recovery"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Label2, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel4, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 29)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 18.60465F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 63.4703178F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 18.2648411F))
        TableLayoutPanel1.Size = New Size(800, 253)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(3, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(48, 15)
        Label2.TabIndex = 0
        Label2.Text = "Backup"
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Controls.Add(restoreBackupButton, 0, 2)
        TableLayoutPanel4.Controls.Add(createBackupButton, 0, 1)
        TableLayoutPanel4.Controls.Add(Label4, 0, 0)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(3, 49)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 3
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 71.84466F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 28.15534F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Absolute, 28F))
        TableLayoutPanel4.Size = New Size(394, 154)
        TableLayoutPanel4.TabIndex = 9
        ' 
        ' restoreBackupButton
        ' 
        restoreBackupButton.Location = New Point(3, 128)
        restoreBackupButton.Name = "restoreBackupButton"
        restoreBackupButton.Size = New Size(379, 23)
        restoreBackupButton.TabIndex = 9
        restoreBackupButton.Text = "Restore Backup Now"
        restoreBackupButton.UseVisualStyleBackColor = True
        ' 
        ' createBackupButton
        ' 
        createBackupButton.Location = New Point(3, 93)
        createBackupButton.Name = "createBackupButton"
        createBackupButton.Size = New Size(379, 23)
        createBackupButton.TabIndex = 8
        createBackupButton.Text = "Create Backup Now"
        createBackupButton.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(3, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(340, 45)
        Label4.TabIndex = 3
        Label4.Text = "Backup and restore your system data with ease. Save all orders, inventory, and user accounts in a single step, and restore them whenever necessary."
        ' 
        ' Backup_and_Recovery
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Panel1)
        Name = "Backup_and_Recovery"
        Text = "Backup_and_Recovery"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents createBackupButton As Button
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents restoreBackupButton As Button
End Class
