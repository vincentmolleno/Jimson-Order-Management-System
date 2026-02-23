Imports MySql.Data.MySqlClient

Public Class Rep_Low_Stock_Alert_Report

    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader
    Private Const PageSize As Integer = 50 ' max rows to load

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            LoadLowStockItems()
        End If
    End Sub

    Private Sub LowStockAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLowStockItems()
    End Sub

    Private Sub LoadLowStockItems()
        Try
            ' Clear previous rows
            lowStockDgv.Rows.Clear()

            ' Open connection
            conn.Open()

            ' Select items where quantity is less than minimum_stock with a row limit
            Dim query As String =
                "SELECT item_name, category, quantity, minimum_stock, price " &
                "FROM inventory " &
                "WHERE is_deleted = 0 AND quantity < minimum_stock " &
                "ORDER BY quantity ASC " &
                "LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim itemName As String = dr("item_name").ToString()
                        Dim category As String = dr("category").ToString()
                        Dim currentStock As Integer = Convert.ToInt32(dr("quantity"))
                        Dim minimumRequired As Integer = Convert.ToInt32(dr("minimum_stock"))
                        Dim totalValue As Decimal = Convert.ToDecimal(dr("price")) * currentStock
                        Dim status As String = "Low Stock"

                        lowStockDgv.Rows.Add(itemName, category, currentStock, minimumRequired, totalValue.ToString("F2"), status)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading low stock items: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            lowStockDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT item_name, category, quantity, minimum_stock, price " &
                "FROM inventory " &
                "WHERE is_deleted = 0 AND quantity < minimum_stock"

            ' Apply filter ordering
            Select Case filter
                Case "None"
                    query &= " ORDER BY quantity ASC"
                Case "Category"
                    query &= " ORDER BY category ASC, quantity ASC"
                Case "Total Value"
                    query &= " ORDER BY (price * quantity) DESC"
                Case "Minimum Required"
                    query &= " ORDER BY minimum_stock ASC"
            End Select

            ' Add LIMIT
            query &= " LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim itemName As String = dr("item_name").ToString()
                        Dim category As String = dr("category").ToString()
                        Dim currentStock As Integer = Convert.ToInt32(dr("quantity"))
                        Dim minimumRequired As Integer = Convert.ToInt32(dr("minimum_stock"))
                        Dim totalValue As Decimal = Convert.ToDecimal(dr("price")) * currentStock
                        Dim status As String = "Low Stock"

                        lowStockDgv.Rows.Add(itemName, category, currentStock, minimumRequired, totalValue.ToString("F2"), status)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Property to expose filters to filterCombo
    Public ReadOnly Property Filters As String()
        Get
            Return New String() {"None", "Category", "Total Value", "Minimum Required"}
        End Get
    End Property

End Class
