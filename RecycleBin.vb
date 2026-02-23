Imports MySql.Data.MySqlClient

Public Class RecycleBin
    ' Connection
    Private conn As New MySqlConnection(modDB.strConnection)

    ' Paging
    Private Const PageSize As Integer = 50
    Private lastInventoryId As Integer? = Nothing
    Private lastWastageId As Integer? = Nothing
    Private lastOrderNo As Integer? = Nothing
    Private lastUserId As Integer? = Nothing
    Private isLoading As Boolean = False
    Private allDataLoaded As Boolean = False

    ' ===============================
    ' ======== Form Events ==========
    ' ===============================
    Private Sub RecycleBin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDefaultIndex(0, ComboBox1)
        LoadRecycleBin()
    End Sub

    Private Sub RecycleBin_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadRecycleBin(TextBox1.Text, True)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        LoadRecycleBin(TextBox1.Text, True)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadRecycleBin(TextBox1.Text, True)
    End Sub

    Private Sub recycleBinDgv_MouseDown(sender As Object, e As MouseEventArgs) Handles recycleBinDgv.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hit = recycleBinDgv.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                recycleBinDgv.ClearSelection()
                recycleBinDgv.Rows(hit.RowIndex).Selected = True
                ContextMenuStrip1.Show(recycleBinDgv, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    ' ===============================
    ' ======== Helpers ==============
    ' ===============================
    Private Sub SetDefaultIndex(index As Integer, ParamArray combos() As ComboBox)
        For Each cb As ComboBox In combos
            cb.SelectedIndex = index
        Next
    End Sub

    Private Function FormatDeletedAt(value As Object) As String
        If IsDBNull(value) Then Return ""
        Return Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    Private Function GetOrderByClause() As String
        Select Case ComboBox1.Text
            Case "All Deletes", "Recent"
                Return " ORDER BY deleted_at DESC"
            Case "Source"
                Return " ORDER BY entity_type ASC"
            Case "Name"
                Return " ORDER BY name ASC"
            Case Else
                Return " ORDER BY deleted_at DESC"
        End Select
    End Function

    Private Function ResolveEntityName(entityType As String, entityId As Integer) As String
        Try
            Dim query As String = ""
            Select Case entityType.ToLower()
                Case "inventory" : query = "SELECT item_name FROM inventory WHERE id=@id"
                Case "order" : query = "SELECT customer FROM `order` WHERE order_no=@id"
                Case "user" : query = "SELECT CONCAT(first_name,' ',last_name) FROM users WHERE id=@id"
                Case "wastage" : query = "SELECT item FROM wastage WHERE id=@id"
                Case Else : Return "(Unknown Source)"
            End Select

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", entityId)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    If entityType.ToLower() = "order" Then Return "Ordered by: " & result.ToString()
                    Return result.ToString()
                End If
            End Using
        Catch
            Return "(Unavailable)"
        End Try
        Return "(Not Found)"
    End Function

    ' ===============================
    ' ======== Load DataGridView =====
    ' ===============================
    Private Sub LoadRecycleBin(Optional searchText As String = "", Optional reset As Boolean = False)
        If isLoading Or allDataLoaded Then Return
        isLoading = True

        If reset Then
            recycleBinDgv.Rows.Clear()
            lastInventoryId = Nothing
            lastWastageId = Nothing
            lastOrderNo = Nothing
            lastUserId = Nothing
            allDataLoaded = False
        End If

        Try
            conn.Open()
            Dim rowsLoaded As Integer = 0

            ' ===== INVENTORY =====
            Dim invQuery As String = "SELECT i.id, i.item_name, IFNULL(u.username,'(Unknown)') AS deleted_by_name, i.deleted_at
                                  FROM inventory i
                                  LEFT JOIN users u ON i.deleted_by = u.id
                                  WHERE i.is_deleted = 1"
            If lastInventoryId.HasValue Then invQuery &= " AND i.id > @lastId"
            If Not String.IsNullOrWhiteSpace(searchText) Then invQuery &= " AND (i.item_name LIKE @search OR u.username LIKE @search)"
            invQuery &= " ORDER BY i.deleted_at DESC LIMIT @PageSize"

            Using cmd As New MySqlCommand(invQuery, conn)
                If lastInventoryId.HasValue Then cmd.Parameters.AddWithValue("@lastId", lastInventoryId.Value)
                If Not String.IsNullOrWhiteSpace(searchText) Then cmd.Parameters.AddWithValue("@search", $"%{searchText}%")
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        Dim currentId As Integer = Convert.ToInt32(dr("id"))
                        recycleBinDgv.Rows.Add("Inventory", currentId.ToString("D6"), dr("item_name"), dr("deleted_by_name"), FormatDeletedAt(dr("deleted_at")))
                        lastInventoryId = currentId
                        rowsLoaded += 1
                    End While
                End Using
            End Using

            ' ===== WASTAGE =====
            Dim wastQuery As String = "SELECT w.id, w.item, IFNULL(u.username,'(Unknown)') AS deleted_by_name, w.deleted_at
                                  FROM wastage w
                                  LEFT JOIN users u ON w.deleted_by = u.id
                                  WHERE w.is_deleted = 1"
            If lastWastageId.HasValue Then wastQuery &= " AND w.id > @lastId"
            If Not String.IsNullOrWhiteSpace(searchText) Then wastQuery &= " AND (w.item LIKE @search OR u.username LIKE @search)"
            wastQuery &= " ORDER BY w.deleted_at DESC LIMIT @PageSize"

            Using cmd As New MySqlCommand(wastQuery, conn)
                If lastWastageId.HasValue Then cmd.Parameters.AddWithValue("@lastId", lastWastageId.Value)
                If Not String.IsNullOrWhiteSpace(searchText) Then cmd.Parameters.AddWithValue("@search", $"%{searchText}%")
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        Dim currentId As Integer = Convert.ToInt32(dr("id"))
                        recycleBinDgv.Rows.Add("Wastage", currentId.ToString("D6"), dr("item"), dr("deleted_by_name"), FormatDeletedAt(dr("deleted_at")))
                        lastWastageId = currentId
                        rowsLoaded += 1
                    End While
                End Using
            End Using

            ' ===== ORDERS =====
            Dim ordQuery As String = "SELECT o.order_no, o.customer, IFNULL(u.username,'(Unknown)') AS deleted_by_name, o.deleted_at
                                  FROM `order` o
                                  LEFT JOIN users u ON o.deleted_by = u.id
                                  WHERE o.is_deleted = 1"
            If lastOrderNo.HasValue Then ordQuery &= " AND o.order_no > @lastId"
            If Not String.IsNullOrWhiteSpace(searchText) Then ordQuery &= " AND (o.customer LIKE @search OR u.username LIKE @search)"
            ordQuery &= " ORDER BY o.deleted_at DESC LIMIT @PageSize"

            Using cmd As New MySqlCommand(ordQuery, conn)
                If lastOrderNo.HasValue Then cmd.Parameters.AddWithValue("@lastId", lastOrderNo.Value)
                If Not String.IsNullOrWhiteSpace(searchText) Then cmd.Parameters.AddWithValue("@search", $"%{searchText}%")
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        Dim currentId As Integer = Convert.ToInt32(dr("order_no"))
                        recycleBinDgv.Rows.Add("Order", currentId.ToString("D6"), dr("customer"), dr("deleted_by_name"), FormatDeletedAt(dr("deleted_at")))
                        lastOrderNo = currentId
                        rowsLoaded += 1
                    End While
                End Using
            End Using

            ' ===== USERS =====
            Dim userQuery As String = "SELECT u1.id, CONCAT(u1.first_name,' ',u1.last_name) AS fullname, IFNULL(u2.username,'(Unknown)') AS deleted_by_name, u1.deleted_at
                                  FROM users u1
                                  LEFT JOIN users u2 ON u1.deleted_by = u2.id
                                  WHERE u1.is_deleted = 1"
            If lastUserId.HasValue Then userQuery &= " AND u1.id > @lastId"
            If Not String.IsNullOrWhiteSpace(searchText) Then userQuery &= " AND (CONCAT(u1.first_name,' ',u1.last_name) LIKE @search OR u2.username LIKE @search)"
            userQuery &= " ORDER BY u1.deleted_at DESC LIMIT @PageSize"

            Using cmd As New MySqlCommand(userQuery, conn)
                If lastUserId.HasValue Then cmd.Parameters.AddWithValue("@lastId", lastUserId.Value)
                If Not String.IsNullOrWhiteSpace(searchText) Then cmd.Parameters.AddWithValue("@search", $"%{searchText}%")
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr = cmd.ExecuteReader()
                    While dr.Read()
                        Dim currentId As Integer = Convert.ToInt32(dr("id"))
                        recycleBinDgv.Rows.Add("User", currentId.ToString("D6"), dr("fullname"), dr("deleted_by_name"), FormatDeletedAt(dr("deleted_at")))
                        lastUserId = currentId
                        rowsLoaded += 1
                    End While
                End Using
            End Using

            ' If fewer than PageSize rows loaded, mark allDataLoaded = True
            If rowsLoaded < PageSize Then allDataLoaded = True

        Catch ex As Exception
            MessageBox.Show("Error loading recycle bin: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
            isLoading = False
        End Try
    End Sub


    ' ===============================
    ' ======== Restore / Delete =====
    ' ===============================
    ' (Keep your existing RestoreToolStripMenuItem_Click and PermanentlyDeleteToolStripMenuItem_Click)
End Class
