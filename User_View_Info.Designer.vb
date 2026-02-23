<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User_View_Info
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
        TableLayoutPanel2 = New TableLayoutPanel()
        Label7 = New Label()
        userTypeTb = New TextBox()
        first_nameTb = New TextBox()
        Label2 = New Label()
        idTb = New TextBox()
        Label3 = New Label()
        emailTb = New TextBox()
        phoneTb = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        datetimePh = New Label()
        Label6 = New Label()
        Panel1 = New Panel()
        TableLayoutPanel5 = New TableLayoutPanel()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        Button1 = New Button()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Location = New Point(3, 43)
        Label1.Name = "Label1"
        Label1.Size = New Size(124, 15)
        Label1.TabIndex = 0
        Label1.Text = "User View Information"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.36871F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 38.3156471F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 38.3156471F))
        TableLayoutPanel2.Controls.Add(Label7, 1, 0)
        TableLayoutPanel2.Controls.Add(userTypeTb, 2, 1)
        TableLayoutPanel2.Controls.Add(first_nameTb, 1, 1)
        TableLayoutPanel2.Controls.Add(Label2, 0, 0)
        TableLayoutPanel2.Controls.Add(idTb, 0, 1)
        TableLayoutPanel2.Controls.Add(Label3, 2, 0)
        TableLayoutPanel2.Location = New Point(12, 66)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 2
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(255, 89)
        TableLayoutPanel2.TabIndex = 6
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(62, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(56, 15)
        Label7.TabIndex = 6
        Label7.Text = "Fullname"
        ' 
        ' userTypeTb
        ' 
        userTypeTb.Dock = DockStyle.Fill
        userTypeTb.Location = New Point(159, 47)
        userTypeTb.Name = "userTypeTb"
        userTypeTb.ReadOnly = True
        userTypeTb.Size = New Size(93, 23)
        userTypeTb.TabIndex = 5
        userTypeTb.TabStop = False
        ' 
        ' first_nameTb
        ' 
        first_nameTb.Dock = DockStyle.Fill
        first_nameTb.Location = New Point(62, 47)
        first_nameTb.Name = "first_nameTb"
        first_nameTb.ReadOnly = True
        first_nameTb.Size = New Size(91, 23)
        first_nameTb.TabIndex = 3
        first_nameTb.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(18, 15)
        Label2.TabIndex = 0
        Label2.Text = "ID"
        ' 
        ' idTb
        ' 
        idTb.Dock = DockStyle.Fill
        idTb.Location = New Point(3, 47)
        idTb.Name = "idTb"
        idTb.ReadOnly = True
        idTb.Size = New Size(53, 23)
        idTb.TabIndex = 2
        idTb.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(159, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 1
        Label3.Text = "User Type"
        ' 
        ' emailTb
        ' 
        emailTb.Dock = DockStyle.Fill
        emailTb.Location = New Point(3, 44)
        emailTb.Name = "emailTb"
        emailTb.ReadOnly = True
        emailTb.Size = New Size(249, 23)
        emailTb.TabIndex = 4
        emailTb.TabStop = False
        ' 
        ' phoneTb
        ' 
        phoneTb.Dock = DockStyle.Fill
        phoneTb.Location = New Point(3, 126)
        phoneTb.Name = "phoneTb"
        phoneTb.ReadOnly = True
        phoneTb.Size = New Size(249, 23)
        phoneTb.TabIndex = 5
        phoneTb.TabStop = False
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
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Controls.Add(datetimePh, 0, 5)
        TableLayoutPanel3.Controls.Add(phoneTb, 0, 3)
        TableLayoutPanel3.Controls.Add(Label4, 0, 0)
        TableLayoutPanel3.Controls.Add(Label5, 0, 2)
        TableLayoutPanel3.Controls.Add(emailTb, 0, 1)
        TableLayoutPanel3.Controls.Add(Label6, 0, 4)
        TableLayoutPanel3.Location = New Point(12, 161)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 6
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 16.666666F))
        TableLayoutPanel3.Size = New Size(255, 250)
        TableLayoutPanel3.TabIndex = 7
        ' 
        ' datetimePh
        ' 
        datetimePh.AutoSize = True
        datetimePh.Location = New Point(3, 205)
        datetimePh.Name = "datetimePh"
        datetimePh.Size = New Size(71, 15)
        datetimePh.TabIndex = 7
        datetimePh.Text = "loremipsum"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(3, 164)
        Label6.Name = "Label6"
        Label6.Size = New Size(71, 15)
        Label6.TabIndex = 6
        Label6.Text = "Last Activity"
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(TableLayoutPanel5)
        Panel1.Controls.Add(TableLayoutPanel3)
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 450)
        Panel1.TabIndex = 1
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TableLayoutPanel5.ColumnCount = 3
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19.7278919F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 46.7687073F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel5.Controls.Add(Button4, 2, 0)
        TableLayoutPanel5.Controls.Add(Button3, 1, 0)
        TableLayoutPanel5.Controls.Add(Button2, 0, 0)
        TableLayoutPanel5.Location = New Point(15, 417)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 1
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.Size = New Size(255, 61)
        TableLayoutPanel5.TabIndex = 9
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.Location = New Point(177, 3)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 4
        Button4.Text = "Delete User"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(53, 3)
        Button3.Name = "Button3"
        Button3.Size = New Size(113, 23)
        Button3.TabIndex = 3
        Button3.Text = "View Activity Logs"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(3, 3)
        Button2.Name = "Button2"
        Button2.Size = New Size(44, 23)
        Button2.TabIndex = 2
        Button2.Text = "Edit User"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(Button1, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(783, 58)
        TableLayoutPanel1.TabIndex = 5
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Bottom
        Button1.Location = New Point(499, 32)
        Button1.Name = "Button1"
        Button1.Size = New Size(176, 23)
        Button1.TabIndex = 1
        Button1.Text = "Back to User Accounts"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' User_View_Info
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(800, 450)
        Controls.Add(Panel1)
        MaximizeBox = False
        MinimizeBox = False
        Name = "User_View_Info"
        Text = "User_View_Info"
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        Panel1.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents first_nameTb As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents idTb As TextBox
    Friend WithEvents emailTb As TextBox
    Friend WithEvents phoneTb As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents userTypeTb As TextBox
    Friend WithEvents datetimePh As Label
End Class
