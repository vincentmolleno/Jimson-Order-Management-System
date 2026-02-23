<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        loginBtn = New Button()
        logo = New PictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        passwordTb = New TextBox()
        Label5 = New Label()
        usernameTb = New TextBox()
        Label1 = New Label()
        configBtn = New Button()
        CType(logo, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' loginBtn
        ' 
        loginBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        loginBtn.BackColor = Color.FromArgb(CByte(214), CByte(48), CByte(49))
        loginBtn.FlatStyle = FlatStyle.Flat
        loginBtn.ForeColor = Color.White
        loginBtn.Location = New Point(118, 187)
        loginBtn.Name = "loginBtn"
        loginBtn.Size = New Size(110, 44)
        loginBtn.TabIndex = 5
        loginBtn.Text = "LOGIN"
        loginBtn.UseVisualStyleBackColor = False
        ' 
        ' logo
        ' 
        logo.Image = My.Resources.Resources.download
        logo.Location = New Point(116, 12)
        logo.Name = "logo"
        logo.Size = New Size(100, 85)
        logo.SizeMode = PictureBoxSizeMode.Zoom
        logo.TabIndex = 0
        logo.TabStop = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 84F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8F))
        TableLayoutPanel1.Controls.Add(passwordTb, 1, 3)
        TableLayoutPanel1.Controls.Add(Label5, 1, 2)
        TableLayoutPanel1.Controls.Add(usernameTb, 1, 1)
        TableLayoutPanel1.Controls.Add(Label1, 1, 0)
        TableLayoutPanel1.Controls.Add(loginBtn, 1, 4)
        TableLayoutPanel1.Location = New Point(-1, 132)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 5
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.Size = New Size(348, 234)
        TableLayoutPanel1.TabIndex = 6
        ' 
        ' passwordTb
        ' 
        passwordTb.Dock = DockStyle.Fill
        passwordTb.Location = New Point(30, 141)
        passwordTb.Multiline = True
        passwordTb.Name = "passwordTb"
        passwordTb.PasswordChar = "s"c
        passwordTb.PlaceholderText = "Enter your Password"
        passwordTb.Size = New Size(286, 40)
        passwordTb.TabIndex = 14
        passwordTb.UseSystemPasswordChar = True
        passwordTb.WordWrap = False
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Left
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label5.Location = New Point(30, 107)
        Label5.Name = "Label5"
        Label5.Size = New Size(59, 15)
        Label5.TabIndex = 11
        Label5.Text = "Password"
        Label5.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' usernameTb
        ' 
        usernameTb.Dock = DockStyle.Fill
        usernameTb.Location = New Point(30, 49)
        usernameTb.Multiline = True
        usernameTb.Name = "usernameTb"
        usernameTb.PlaceholderText = "Enter your Username"
        usernameTb.Size = New Size(286, 40)
        usernameTb.TabIndex = 9
        usernameTb.WordWrap = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(30, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 15)
        Label1.TabIndex = 6
        Label1.Text = "Username"
        Label1.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' configBtn
        ' 
        configBtn.Location = New Point(264, 12)
        configBtn.Name = "configBtn"
        configBtn.Size = New Size(75, 23)
        configBtn.TabIndex = 9
        configBtn.Text = "Configure"
        configBtn.UseVisualStyleBackColor = True
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(351, 367)
        Controls.Add(configBtn)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(logo)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "Login"
        Text = "Login"
        CType(logo, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents loginBtn As Button
    Friend WithEvents logo As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents configBtn As Button
    Friend WithEvents passwordTb As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents usernameTb As TextBox
    Friend WithEvents Label1 As Label

End Class
