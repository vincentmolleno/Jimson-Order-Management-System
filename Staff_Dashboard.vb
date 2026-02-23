Imports MySql.Data.MySqlClient

Public Class Staff_Dashboard
    Dim conn As New MySqlConnection(modDB.strConnection)
    Private Const MaxRows As Integer = 50 ' Max rows to show in DataGridView

    ' ===============================
    ' ======== Form Events ==========
    ' ===============================
    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then dgv_load()
    End Sub

    Private Sub Staff_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_load()
        LoadTotalItems()
        LoadLowStockItems()
    End Sub

    ' ===============================
    ' ======== Load DataGridView =====
    ' ===============================
    Sub dgv_load(Optional searchText As String = "", Optional limit As Integer = MaxRows)
        Try
            staffDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT item_name, category, quantity, minimum_stock, status " &
                "FROM inventory " &
                "WHERE is_deleted = 0"

            ' Add search filter if provided
            If Not String.IsNullOrWhiteSpace(searchText) Then
                query &= " AND (item_name LIKE @search OR category LIKE @search)"
            End If

            query &= " ORDER BY created_at DESC, updated_at DESC"

            ' Apply row limit
            If limit > 0 Then query &= $" LIMIT {limit}"

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    cmd.Parameters.AddWithValue("@search", $"%{searchText}%")
                End If

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        staffDgv.Rows.Add(
                            dr("item_name"),
                            dr("category"),
                            dr("quantity"),
                            dr("minimum_stock"),
                            dr("status")
                        )
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading inventory: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' ===============================
    ' ======== Load Stats ===========
    ' ===============================
    Private Sub LoadTotalItems()
        totalItemsLbl.Text = ExecuteScalarInt("SELECT COUNT(*) FROM inventory WHERE is_deleted = 0").ToString()
    End Sub

    Private Sub LoadLowStockItems()
        lowStockLbl.Text = ExecuteScalarInt("SELECT COUNT(*) FROM inventory WHERE status = 'Low Stock' AND is_deleted = 0").ToString()
    End Sub

    ' Helper for scalar queries
    Private Function ExecuteScalarInt(query As String) As Integer
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd As New MySqlCommand(query, conn)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        Catch
            Return 0
        Finally
            conn.Close()
        End Try
    End Function

    ' ===============================
    ' ======== Buttons ==============
    ' ===============================
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Inv_AddItem.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Staff.invBtn.PerformClick()
    End Sub

End Class
