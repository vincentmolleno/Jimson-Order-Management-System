<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Logging
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
        Panel1 = New Panel()
        Label2 = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        Label1 = New Label()
        searchTb = New TextBox()
        Label4 = New Label()
        levelsCb = New ComboBox()
        logDgv = New DataGridView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        NotesToolStripMenuItem = New ToolStripMenuItem()
        Column1 = New DataGridViewTextBoxColumn()
        timestamp = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        user = New DataGridViewTextBoxColumn()
        action = New DataGridViewTextBoxColumn()
        details = New DataGridViewTextBoxColumn()
        level = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        CType(logDgv, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 41)
        Panel1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label2.AutoSize = True
        Label2.Location = New Point(3, 23)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 15)
        Label2.TabIndex = 1
        Label2.Text = "System Logging"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(searchTb, 0, 1)
        TableLayoutPanel1.Controls.Add(Label4, 1, 0)
        TableLayoutPanel1.Controls.Add(levelsCb, 1, 1)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 41)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(800, 100)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label1.AutoSize = True
        Label1.Location = New Point(3, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(42, 15)
        Label1.TabIndex = 0
        Label1.Text = "Search"
        ' 
        ' searchTb
        ' 
        searchTb.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        searchTb.Location = New Point(3, 63)
        searchTb.Name = "searchTb"
        searchTb.PlaceholderText = "Search logs..."
        searchTb.Size = New Size(394, 23)
        searchTb.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label4.AutoSize = True
        Label4.Location = New Point(403, 35)
        Label4.Name = "Label4"
        Label4.Size = New Size(79, 15)
        Label4.TabIndex = 2
        Label4.Text = "Filter by Level"
        ' 
        ' levelsCb
        ' 
        levelsCb.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        levelsCb.DropDownStyle = ComboBoxStyle.DropDownList
        levelsCb.FormattingEnabled = True
        levelsCb.Items.AddRange(New Object() {"All Levels", "Admin", "Staff", "Cashier"})
        levelsCb.Location = New Point(403, 63)
        levelsCb.Name = "levelsCb"
        levelsCb.Size = New Size(394, 23)
        levelsCb.TabIndex = 5
        ' 
        ' logDgv
        ' 
        logDgv.BackgroundColor = SystemColors.ControlLightLight
        logDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        logDgv.Columns.AddRange(New DataGridViewColumn() {Column1, timestamp, Column2, user, action, details, level, Column3, Column4})
        logDgv.ContextMenuStrip = ContextMenuStrip1
        logDgv.Dock = DockStyle.Fill
        logDgv.Location = New Point(0, 141)
        logDgv.Name = "logDgv"
        logDgv.RowHeadersVisible = False
        logDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        logDgv.Size = New Size(800, 309)
        logDgv.TabIndex = 2
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {NotesToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(106, 26)
        ' 
        ' NotesToolStripMenuItem
        ' 
        NotesToolStripMenuItem.Name = "NotesToolStripMenuItem"
        NotesToolStripMenuItem.Size = New Size(105, 22)
        NotesToolStripMenuItem.Text = "Notes"
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column1.HeaderText = "LogID"
        Column1.Name = "Column1"
        Column1.Width = 63
        ' 
        ' timestamp
        ' 
        timestamp.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        timestamp.HeaderText = "Date"
        timestamp.Name = "timestamp"
        timestamp.Width = 56
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column2.HeaderText = "Time"
        Column2.Name = "Column2"
        Column2.Width = 58
        ' 
        ' user
        ' 
        user.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        user.HeaderText = "UserID"
        user.Name = "user"
        ' 
        ' action
        ' 
        action.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        action.HeaderText = "Action"
        action.Name = "action"
        action.Width = 67
        ' 
        ' details
        ' 
        details.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        details.HeaderText = "Details"
        details.Name = "details"
        ' 
        ' level
        ' 
        level.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        level.HeaderText = "Level"
        level.Name = "level"
        level.Width = 59
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column3.HeaderText = "DataID"
        Column3.Name = "Column3"
        Column3.Width = 67
        ' 
        ' Column4
        ' 
        Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column4.HeaderText = "Table Affected"
        Column4.Name = "Column4"
        Column4.Width = 107
        ' 
        ' Logging
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(logDgv)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Panel1)
        Name = "Logging"
        Text = "Logging"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(logDgv, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents searchTb As TextBox
    Friend WithEvents logDgv As DataGridView
    Friend WithEvents levelsCb As ComboBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents NotesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents timestamp As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents user As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewTextBoxColumn
    Friend WithEvents details As DataGridViewTextBoxColumn
    Friend WithEvents level As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
