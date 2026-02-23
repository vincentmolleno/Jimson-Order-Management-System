<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecycleBin
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
        TextBox1 = New TextBox()
        ComboBox1 = New ComboBox()
        recycleBinDgv = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        RestoreToolStripMenuItem = New ToolStripMenuItem()
        PermanentlyDeleteToolStripMenuItem = New ToolStripMenuItem()
        TableLayoutPanel1.SuspendLayout()
        CType(recycleBinDgv, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Controls.Add(Label1, 0, 0)
        TableLayoutPanel1.Controls.Add(TextBox1, 0, 2)
        TableLayoutPanel1.Controls.Add(ComboBox1, 1, 2)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Size = New Size(800, 121)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 15)
        Label1.TabIndex = 0
        Label1.Text = "Recycle Bin"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(3, 83)
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Search by name, id..."
        TextBox1.Size = New Size(394, 23)
        TextBox1.TabIndex = 2
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"All Deletes", "Recent", "Source", "Name"})
        ComboBox1.Location = New Point(403, 83)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(394, 23)
        ComboBox1.TabIndex = 3
        ' 
        ' recycleBinDgv
        ' 
        recycleBinDgv.BackgroundColor = SystemColors.ControlLightLight
        recycleBinDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        recycleBinDgv.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5})
        recycleBinDgv.Dock = DockStyle.Fill
        recycleBinDgv.Location = New Point(0, 121)
        recycleBinDgv.Name = "recycleBinDgv"
        recycleBinDgv.RowHeadersVisible = False
        recycleBinDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        recycleBinDgv.Size = New Size(800, 329)
        recycleBinDgv.TabIndex = 1
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column1.HeaderText = "Source"
        Column1.Name = "Column1"
        Column1.Width = 68
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column2.HeaderText = "Record ID"
        Column2.Name = "Column2"
        Column2.Width = 83
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column3.HeaderText = "Name"
        Column3.Name = "Column3"
        ' 
        ' Column4
        ' 
        Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column4.HeaderText = "Deleted By"
        Column4.Name = "Column4"
        Column4.Width = 88
        ' 
        ' Column5
        ' 
        Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Column5.HeaderText = "Deleted At"
        Column5.Name = "Column5"
        Column5.Width = 87
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {RestoreToolStripMenuItem, PermanentlyDeleteToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(181, 70)
        ' 
        ' RestoreToolStripMenuItem
        ' 
        RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        RestoreToolStripMenuItem.Size = New Size(180, 22)
        RestoreToolStripMenuItem.Text = "Restore"
        ' 
        ' PermanentlyDeleteToolStripMenuItem
        ' 
        PermanentlyDeleteToolStripMenuItem.Name = "PermanentlyDeleteToolStripMenuItem"
        PermanentlyDeleteToolStripMenuItem.Size = New Size(180, 22)
        PermanentlyDeleteToolStripMenuItem.Text = "Permanently Delete"
        ' 
        ' RecycleBin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(recycleBinDgv)
        Controls.Add(TableLayoutPanel1)
        Name = "RecycleBin"
        Text = "RecycleBin"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(recycleBinDgv, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents recycleBinDgv As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RestoreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PermanentlyDeleteToolStripMenuItem As ToolStripMenuItem
End Class
