Imports System.Text.Json
Imports MySql.Data.MySqlClient

Public Class Rep_Top_Revenue_Orders_Report
    Dim conn As New MySqlConnection(modDB.strConnection)
    Private Const PageSize As Integer = 50 ' Limit rows loaded

    Dim dr As MySqlDataReader

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadTopRevenueOrders()
    End Sub

    Public Sub LoadTopRevenueOrders()
        ApplyFilter("Alltime")
    End Sub

    ' JSON class for items
    Public Class OrderItem
        Public Property Item As String
        Public Property Quantity As Integer
        Public Property Cost As Decimal
        Public Property Subtotal As Decimal
    End Class

    ' Filters for combo box
    Public ReadOnly Property Filters As String()
        Get
            Return New String() {
                "Alltime",
                "Today",
                "Last 7 days",
                "Last 30 days",
                "Paid",
                "Unpaid"
            }
        End Get
    End Property

    Public Sub ApplyFilter(filter As String)
        Try
            topRevenueOrdersDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Base query
            Dim query As String =
                "SELECT customer, items, payment, total_cost, order_date " &
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
                Case "Paid"
                    query &= " AND payment = 'Paid' "
                Case "Unpaid"
                    query &= " AND payment = 'Unpaid' "
                Case "Alltime"
                    ' no extra WHERE clause
            End Select

            ' Add limit
            query &= " ORDER BY total_cost DESC LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim customer As String = dr("customer").ToString()

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

                        Dim revenue As Decimal = Convert.ToDecimal(dr("total_cost"))
                        Dim formattedRevenue As String = revenue.ToString("F2")

                        topRevenueOrdersDgv.Rows.Add(customer, prettyItems, dr("payment").ToString(), formattedRevenue)
                    End While
                End Using
            End Using

            ' Wrap Items column
            topRevenueOrdersDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            Dim itemsColumn = topRevenueOrdersDgv.Columns.Cast(Of DataGridViewColumn)() _
                              .FirstOrDefault(Function(c) c.HeaderText = "Items")
            If itemsColumn IsNot Nothing Then itemsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            topRevenueOrdersDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Rep_Top_Revenue_Orders_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTopRevenueOrders()
    End Sub
End Class
