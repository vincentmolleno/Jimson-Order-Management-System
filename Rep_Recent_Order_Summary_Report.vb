Imports System.Text.Json
Imports MySql.Data.MySqlClient

Public Class Rep_Recent_Order_Summary_Report
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader
    Private Const PageSize As Integer = 50 ' Limit number of rows loaded

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadRecentOrderSummary()
    End Sub

    Private Sub Rep_Recent_Order_Summary_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRecentOrderSummary()
    End Sub

    Public Class OrderItem
        Public Property Item As String
        Public Property Quantity As Integer
        Public Property Cost As Decimal
        Public Property Subtotal As Decimal
    End Class

    Public ReadOnly Property Filters As String()
        Get
            Return New String() {"Alltime", "Today", "Last 7 days", "Last 30 days"}
        End Get
    End Property

    Public Sub LoadRecentOrderSummary()
        ApplyFilter("Alltime")
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            recentOrderSummaryDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Base query
            Dim query As String =
                "SELECT order_no, order_date, customer, items, total_cost, payment, status, created_by " &
                "FROM `order` " &
                "WHERE is_deleted = 0 "

            ' Apply filter
            Select Case filter
                Case "Today"
                    query &= " AND DATE(order_date) = CURDATE() "
                Case "Last 7 days"
                    query &= " AND order_date >= NOW() - INTERVAL 7 DAY "
                Case "Last 30 days"
                    query &= " AND order_date >= NOW() - INTERVAL 30 DAY "
                Case "Alltime"
                    ' no extra WHERE clause
            End Select

            query &= " ORDER BY order_date DESC LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim formattedOrderNo As String = CInt(dr("order_no")).ToString("D6")
                        Dim orderDate As String = Convert.ToDateTime(dr("order_date")).ToString("yyyy-MM-dd HH:mm")
                        Dim customer As String = dr("customer").ToString()
                        Dim payment As String = dr("payment").ToString()
                        Dim status As String = dr("status").ToString()
                        Dim cashier As String = dr("created_by").ToString()
                        Dim totalCost As Decimal = Convert.ToDecimal(dr("total_cost"))
                        Dim formattedTotalCost As String = totalCost.ToString("F2")

                        ' JSON conversion for items
                        Dim itemsJson As String = dr("items").ToString()
                        Dim prettyItems As String = ""
                        If Not String.IsNullOrEmpty(itemsJson) Then
                            Try
                                Dim itemsList As List(Of OrderItem) = JsonSerializer.Deserialize(Of List(Of OrderItem))(itemsJson)
                                prettyItems = String.Join(vbCrLf, itemsList.Select(Function(i) $"{i.Item} x{i.Quantity} = {i.Subtotal:0.00}"))
                            Catch
                                prettyItems = "Invalid JSON"
                            End Try
                        End If

                        recentOrderSummaryDgv.Rows.Add(formattedOrderNo, orderDate, customer, prettyItems, formattedTotalCost, payment, status, cashier)
                    End While
                End Using
            End Using

            ' Wrap text for Items column
            recentOrderSummaryDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            Dim itemsColumn = recentOrderSummaryDgv.Columns.Cast(Of DataGridViewColumn)() _
                              .FirstOrDefault(Function(c) c.HeaderText = "Items")
            If itemsColumn IsNot Nothing Then itemsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            recentOrderSummaryDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
