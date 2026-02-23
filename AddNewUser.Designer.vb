<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddNewUser
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
        TableLayoutPanel5 = New TableLayoutPanel()
        cancelBtn = New Button()
        createBtn = New Button()
        TableLayoutPanel3 = New TableLayoutPanel()
        phoneTb = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        emailTb = New TextBox()
        typeCb = New ComboBox()
        TableLayoutPanel2 = New TableLayoutPanel()
        last_nameTb = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        first_nameTb = New TextBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label1 = New Label()
        TableLayoutPanel4 = New TableLayoutPanel()
        confirmTb = New TextBox()
        passwordTb = New TextBox()
        usernameTb = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        matchLbl = New Label()
        Panel1.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(TableLayoutPanel5)
        Panel1.Controls.Add(TableLayoutPanel3)
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Controls.Add(TableLayoutPanel4)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(773, 421)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel5.ColumnCount = 2
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.Controls.Add(cancelBtn, 1, 0)
        TableLayoutPanel5.Controls.Add(createBtn, 0, 0)
        TableLayoutPanel5.Location = New Point(12, 686)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 1
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.Size = New Size(528, 61)
        TableLayoutPanel5.TabIndex = 9
        ' 
        ' cancelBtn
        ' 
        cancelBtn.Location = New Point(267, 3)
        cancelBtn.Name = "cancelBtn"
        cancelBtn.Size = New Size(75, 23)
        cancelBtn.TabIndex = 1
        cancelBtn.Text = "Cancel"
        cancelBtn.UseVisualStyleBackColor = True
        ' 
        ' createBtn
        ' 
        createBtn.Enabled = False
        createBtn.Location = New Point(3, 3)
        createBtn.Name = "createBtn"
        createBtn.Size = New Size(75, 23)
        createBtn.TabIndex = 0
        createBtn.Text = "Create"
        createBtn.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(phoneTb, 0, 3)
        TableLayoutPanel3.Controls.Add(Label4, 0, 0)
        TableLayoutPanel3.Controls.Add(Label5, 0, 2)
        TableLayoutPanel3.Controls.Add(Label6, 0, 4)
        TableLayoutPanel3.Controls.Add(emailTb, 0, 1)
        TableLayoutPanel3.Controls.Add(typeCb, 0, 5)
        TableLayoutPanel3.Location = New Point(12, 161)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 6
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.Size = New Size(528, 250)
        TableLayoutPanel3.TabIndex = 7
        ' 
        ' phoneTb
        ' 
        phoneTb.Location = New Point(3, 126)
        phoneTb.Name = "phoneTb"
        phoneTb.Size = New Size(339, 23)
        phoneTb.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(3, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(81, 15)
        Label4.TabIndex = 1
        Label4.Text = "Email Address"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(3, 82)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 15)
        Label5.TabIndex = 2
        Label5.Text = "Phone Number"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(3, 164)
        Label6.Name = "Label6"
        Label6.Size = New Size(31, 15)
        Label6.TabIndex = 3
        Label6.Text = "Type"
        ' 
        ' emailTb
        ' 
        emailTb.Location = New Point(3, 44)
        emailTb.Name = "emailTb"
        emailTb.Size = New Size(339, 23)
        emailTb.TabIndex = 4
        ' 
        ' typeCb
        ' 
        typeCb.FormattingEnabled = True
        typeCb.Items.AddRange(New Object() {"Admin", "Staff", "Cashier"})
        typeCb.Location = New Point(3, 208)
        typeCb.Name = "typeCb"
        typeCb.Size = New Size(176, 23)
        typeCb.TabIndex = 6
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(last_nameTb, 1, 1)
        TableLayoutPanel2.Controls.Add(Label3, 1, 0)
        TableLayoutPanel2.Controls.Add(Label2, 0, 0)
        TableLayoutPanel2.Controls.Add(first_nameTb, 0, 1)
        TableLayoutPanel2.Location = New Point(12, 66)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel2.Size = New Size(528, 89)
        TableLayoutPanel2.TabIndex = 6
        ' 
        ' last_nameTb
        ' 
        last_nameTb.Location = New Point(267, 47)
        last_nameTb.Name = "last_nameTb"
        last_nameTb.Size = New Size(258, 23)
        last_nameTb.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(267, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 15)
        Label3.TabIndex = 1
        Label3.Text = "Last Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 15)
        Label2.TabIndex = 0
        Label2.Text = "First Name"
        ' 
        ' first_nameTb
        ' 
        first_nameTb.Location = New Point(3, 47)
        first_nameTb.Name = "first_nameTb"
        first_nameTb.Size = New Size(258, 23)
        first_nameTb.TabIndex = 2
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(756, 58)
        TableLayoutPanel1.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Location = New Point(3, 43)
        Label1.Name = "Label1"
        Label1.Size = New Size(82, 15)
        Label1.TabIndex = 0
        Label1.Text = "Add New User"
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel4.Controls.Add(confirmTb, 0, 6)
        TableLayoutPanel4.Controls.Add(passwordTb, 0, 4)
        TableLayoutPanel4.Controls.Add(usernameTb, 0, 2)
        TableLayoutPanel4.Controls.Add(Label8, 0, 1)
        TableLayoutPanel4.Controls.Add(Label7, 0, 0)
        TableLayoutPanel4.Controls.Add(Label9, 0, 3)
        TableLayoutPanel4.Controls.Add(Label10, 0, 5)
        TableLayoutPanel4.Controls.Add(matchLbl, 0, 7)
        TableLayoutPanel4.Location = New Point(12, 417)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 8
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel4.Size = New Size(528, 263)
        TableLayoutPanel4.TabIndex = 8
        ' 
        ' confirmTb
        ' 
        confirmTb.Location = New Point(3, 195)
        confirmTb.Name = "confirmTb"
        confirmTb.Size = New Size(339, 23)
        confirmTb.TabIndex = 10
        ' 
        ' passwordTb
        ' 
        passwordTb.Location = New Point(3, 131)
        passwordTb.Name = "passwordTb"
        passwordTb.Size = New Size(334, 23)
        passwordTb.TabIndex = 9
        ' 
        ' usernameTb
        ' 
        usernameTb.Location = New Point(3, 67)
        usernameTb.Name = "usernameTb"
        usernameTb.Size = New Size(334, 23)
        usernameTb.TabIndex = 8
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(3, 32)
        Label8.Name = "Label8"
        Label8.Size = New Size(60, 15)
        Label8.TabIndex = 5
        Label8.Text = "Username"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(3, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 15)
        Label7.TabIndex = 4
        Label7.Text = "Login Credentials"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(3, 96)
        Label9.Name = "Label9"
        Label9.Size = New Size(57, 15)
        Label9.TabIndex = 6
        Label9.Text = "Password"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(3, 160)
        Label10.Name = "Label10"
        Label10.Size = New Size(104, 15)
        Label10.TabIndex = 7
        Label10.Text = "Confirm Password"
        ' 
        ' matchLbl
        ' 
        matchLbl.AutoSize = True
        matchLbl.Location = New Point(3, 224)
        matchLbl.Name = "matchLbl"
        matchLbl.Size = New Size(10, 15)
        matchLbl.TabIndex = 11
        matchLbl.Text = " "
        ' 
        ' AddNewUser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(773, 421)
        Controls.Add(Panel1)
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddNewUser"
        Text = "AddNewUser"
        Panel1.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents cancelBtn As Button
    Friend WithEvents createBtn As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents phoneTb As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents emailTb As TextBox
    Friend WithEvents typeCb As ComboBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents last_nameTb As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents first_nameTb As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents confirmTb As TextBox
    Friend WithEvents passwordTb As TextBox
    Friend WithEvents usernameTb As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents matchLbl As Label
End Class
