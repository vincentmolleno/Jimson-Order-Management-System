<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configure
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
        TableLayoutPanel3 = New TableLayoutPanel()
        ipAddressTextBox = New TextBox()
        Label2 = New Label()
        TableLayoutPanel4 = New TableLayoutPanel()
        usernameTextBox = New TextBox()
        Label9 = New Label()
        TableLayoutPanel5 = New TableLayoutPanel()
        passwordTextBox = New TextBox()
        Label12 = New Label()
        TableLayoutPanel6 = New TableLayoutPanel()
        Label6 = New Label()
        databaseNameTextBox = New TextBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        Button1 = New Button()
        Button2 = New Button()
        Label1 = New Label()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 0, 1)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel4, 0, 2)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel5, 0, 3)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel6, 0, 4)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 5)
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 6
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 10.5368528F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 19.7315712F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 19.7315712F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 19.7315712F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 19.7315712F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 10.5368547F))
        TableLayoutPanel1.Size = New Size(384, 463)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.163265F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 83.67347F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.163265F))
        TableLayoutPanel3.Controls.Add(ipAddressTextBox, 1, 1)
        TableLayoutPanel3.Controls.Add(Label2, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(3, 51)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Size = New Size(378, 85)
        TableLayoutPanel3.TabIndex = 22
        ' 
        ' ipAddressTextBox
        ' 
        ipAddressTextBox.Dock = DockStyle.Fill
        ipAddressTextBox.Location = New Point(33, 45)
        ipAddressTextBox.Name = "ipAddressTextBox"
        ipAddressTextBox.Size = New Size(310, 23)
        ipAddressTextBox.TabIndex = 16
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Location = New Point(33, 13)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 15)
        Label2.TabIndex = 12
        Label2.Text = "IP Address:"
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 3
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.163265F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 83.67347F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.163265F))
        TableLayoutPanel4.Controls.Add(usernameTextBox, 1, 1)
        TableLayoutPanel4.Controls.Add(Label9, 1, 0)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(3, 142)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(378, 85)
        TableLayoutPanel4.TabIndex = 20
        ' 
        ' usernameTextBox
        ' 
        usernameTextBox.Dock = DockStyle.Fill
        usernameTextBox.Location = New Point(33, 45)
        usernameTextBox.Name = "usernameTextBox"
        usernameTextBox.Size = New Size(310, 23)
        usernameTextBox.TabIndex = 18
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Left
        Label9.AutoSize = True
        Label9.Location = New Point(33, 13)
        Label9.Name = "Label9"
        Label9.Size = New Size(63, 15)
        Label9.TabIndex = 15
        Label9.Text = "Username:"
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 3
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.414991F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 83.17001F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.414991F))
        TableLayoutPanel5.Controls.Add(passwordTextBox, 1, 1)
        TableLayoutPanel5.Controls.Add(Label12, 1, 0)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(3, 233)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 2
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.Size = New Size(378, 85)
        TableLayoutPanel5.TabIndex = 18
        ' 
        ' passwordTextBox
        ' 
        passwordTextBox.Dock = DockStyle.Fill
        passwordTextBox.Location = New Point(34, 45)
        passwordTextBox.Name = "passwordTextBox"
        passwordTextBox.Size = New Size(308, 23)
        passwordTextBox.TabIndex = 18
        ' 
        ' Label12
        ' 
        Label12.Anchor = AnchorStyles.Left
        Label12.AutoSize = True
        Label12.Location = New Point(34, 13)
        Label12.Name = "Label12"
        Label12.Size = New Size(60, 15)
        Label12.TabIndex = 15
        Label12.Text = "Password:"
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 3
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.984252F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 82.03149F))
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.984256F))
        TableLayoutPanel6.Controls.Add(Label6, 1, 0)
        TableLayoutPanel6.Controls.Add(databaseNameTextBox, 1, 1)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(3, 324)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 2
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.Size = New Size(378, 85)
        TableLayoutPanel6.TabIndex = 16
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Left
        Label6.AutoSize = True
        Label6.Location = New Point(36, 13)
        Label6.Name = "Label6"
        Label6.Size = New Size(93, 15)
        Label6.TabIndex = 18
        Label6.Text = "Database Name:"
        ' 
        ' databaseNameTextBox
        ' 
        databaseNameTextBox.Dock = DockStyle.Fill
        databaseNameTextBox.Location = New Point(36, 45)
        databaseNameTextBox.Name = "databaseNameTextBox"
        databaseNameTextBox.Size = New Size(304, 23)
        databaseNameTextBox.TabIndex = 17
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 5
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 13.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 13.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 13.333333F))
        TableLayoutPanel2.Controls.Add(Button1, 1, 0)
        TableLayoutPanel2.Controls.Add(Button2, 3, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(3, 415)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(378, 45)
        TableLayoutPanel2.TabIndex = 14
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Button1.BackColor = Color.FromArgb(CByte(214), CByte(48), CByte(49))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.White
        Button1.Location = New Point(53, 11)
        Button1.Name = "Button1"
        Button1.Size = New Size(107, 23)
        Button1.TabIndex = 0
        Button1.Text = "Configure"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Button2.BackColor = Color.FromArgb(CByte(214), CByte(48), CByte(49))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.ForeColor = Color.White
        Button2.Location = New Point(216, 11)
        Button2.Name = "Button2"
        Button2.Size = New Size(107, 23)
        Button2.TabIndex = 1
        Button2.Text = "Cancel"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(3, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(137, 15)
        Label1.TabIndex = 21
        Label1.Text = "Database Configuration"
        ' 
        ' Configure
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 463)
        Controls.Add(TableLayoutPanel1)
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        MinimizeBox = False
        Name = "Configure"
        Text = "Configure"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel5.PerformLayout()
        TableLayoutPanel6.ResumeLayout(False)
        TableLayoutPanel6.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents databaseNameTextBox As TextBox
    Friend WithEvents ipAddressTextBox As TextBox
    Friend WithEvents usernameTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents passwordTextBox As TextBox
    Friend WithEvents Label12 As Label
End Class
