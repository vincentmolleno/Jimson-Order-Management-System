<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User_Accounts
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
        components = New ComponentModel.Container()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label1 = New Label()
        addBtn = New Button()
        userAccDgv = New DataGridView()
        id = New DataGridViewTextBoxColumn()
        fullname = New DataGridViewTextBoxColumn()
        usertype = New DataGridViewTextBoxColumn()
        userMenu = New ContextMenuStrip(components)
        viewinf = New ToolStripMenuItem()
        editUser = New ToolStripMenuItem()
        logs = New ToolStripMenuItem()
        delete = New ToolStripMenuItem()
        TableLayoutPanel2 = New TableLayoutPanel()
        searchTb = New TextBox()
        TableLayoutPanel3 = New TableLayoutPanel()
        TableLayoutPanel1.SuspendLayout()
        CType(userAccDgv, ComponentModel.ISupportInitialize).BeginInit()
        userMenu.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(800, 51)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F)
        Label1.Location = New Point(3, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(165, 32)
        Label1.TabIndex = 0
        Label1.Text = "User Accounts"
        ' 
        ' addBtn
        ' 
        addBtn.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        addBtn.Location = New Point(209, 11)
        addBtn.Name = "addBtn"
        addBtn.Size = New Size(112, 23)
        addBtn.TabIndex = 1
        addBtn.Text = "Add New User"
        addBtn.UseVisualStyleBackColor = True
        ' 
        ' userAccDgv
        ' 
        userAccDgv.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        userAccDgv.BackgroundColor = SystemColors.Control
        userAccDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        userAccDgv.Columns.AddRange(New DataGridViewColumn() {id, fullname, usertype})
        userAccDgv.Location = New Point(0, 114)
        userAccDgv.MultiSelect = False
        userAccDgv.Name = "userAccDgv"
        userAccDgv.ReadOnly = True
        userAccDgv.RowHeadersVisible = False
        userAccDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        userAccDgv.Size = New Size(800, 336)
        userAccDgv.TabIndex = 1
        ' 
        ' id
        ' 
        id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        id.HeaderText = "ID"
        id.Name = "id"
        id.ReadOnly = True
        id.Width = 43
        ' 
        ' fullname
        ' 
        fullname.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        fullname.HeaderText = "Name"
        fullname.Name = "fullname"
        fullname.ReadOnly = True
        ' 
        ' usertype
        ' 
        usertype.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        usertype.HeaderText = "Type"
        usertype.Name = "usertype"
        usertype.ReadOnly = True
        ' 
        ' userMenu
        ' 
        userMenu.Items.AddRange(New ToolStripItem() {viewinf, editUser, logs, delete})
        userMenu.Name = "ContextMenuStrip1"
        userMenu.RenderMode = ToolStripRenderMode.System
        userMenu.Size = New Size(166, 92)
        ' 
        ' viewinf
        ' 
        viewinf.Name = "viewinf"
        viewinf.Size = New Size(165, 22)
        viewinf.Text = "View Information"
        ' 
        ' editUser
        ' 
        editUser.Name = "editUser"
        editUser.Size = New Size(165, 22)
        editUser.Text = "Edit User"
        ' 
        ' logs
        ' 
        logs.Name = "logs"
        logs.Size = New Size(165, 22)
        logs.Text = "Logs"
        ' 
        ' delete
        ' 
        delete.Name = "delete"
        delete.Size = New Size(165, 22)
        delete.Text = "Delete User"
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(searchTb, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Top
        TableLayoutPanel2.Location = New Point(0, 51)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(800, 57)
        TableLayoutPanel2.TabIndex = 2
        ' 
        ' searchTb
        ' 
        searchTb.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        searchTb.Location = New Point(3, 31)
        searchTb.Name = "searchTb"
        searchTb.PlaceholderText = "Search by ID, name, or type"
        searchTb.Size = New Size(394, 23)
        searchTb.TabIndex = 0
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 63.580246F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 36.419754F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 69F))
        TableLayoutPanel3.Controls.Add(addBtn, 1, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(403, 3)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Size = New Size(394, 45)
        TableLayoutPanel3.TabIndex = 1
        ' 
        ' User_Accounts
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(userAccDgv)
        Controls.Add(TableLayoutPanel1)
        Name = "User_Accounts"
        Text = "User_Accounts"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(userAccDgv, ComponentModel.ISupportInitialize).EndInit()
        userMenu.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel2.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents addBtn As Button
    Friend WithEvents userAccDgv As DataGridView
    Friend WithEvents userMenu As ContextMenuStrip
    Friend WithEvents viewinf As ToolStripMenuItem
    Friend WithEvents editUser As ToolStripMenuItem
    Friend WithEvents logs As ToolStripMenuItem
    Friend WithEvents delete As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents searchTb As TextBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fullname As DataGridViewTextBoxColumn
    Friend WithEvents usertype As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
End Class
