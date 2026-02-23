Imports System.Text.Json
Imports MySql.Data.MySqlClient

Public Class Rep_Order_Status_Report

    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader
    Private Const PageSize As Integer = 50  ' max rows to load

    Private Sub Rep_Order_Status_Report_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadOrderStatusReport()
    End Sub

    ' JSON class
    Public Class OrderItem
        Public Property Item As String
        Public Property Quantity As Integer
        Public Property Cost As Decimal
        Public Property Subtotal As Decimal
    End Class

    Sub LoadOrderStatusReport()
        Try
            orderStatusReportDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT order_no, customer, items, total_cost, payment, status, shipping_address " &
                "FROM `order` " &
                "WHERE is_deleted = 0 " &
                "ORDER BY order_date DESC " &
                "LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        AddOrderRow(dr)
                    End While
                End Using
            End Using

            WrapItemsColumn()

        Catch ex As Exception
            MsgBox("Error loading orders: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            orderStatusReportDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT order_no, customer, items, total_cost, payment, status, shipping_address " &
                "FROM `order` WHERE is_deleted = 0"

            ' Apply filter ordering
            Select Case filter
                Case "None"
                    query &= " ORDER BY order_date DESC"
                Case "Status"
                    query &= " ORDER BY status ASC"
                Case "Amount"
                    query &= " ORDER BY total_cost DESC"
                Case "Price"
                    query &= " ORDER BY total_cost ASC"
            End Select

            ' Add LIMIT
            query &= " LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        AddOrderRow(dr)
                    End While
                End Using
            End Using

            WrapItemsColumn()

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Helper: Add row to DataGridView
    Private Sub AddOrderRow(dr As MySqlDataReader)
        Dim formattedId As String = CInt(dr("order_no")).ToString("D6")
        Dim customer As String = dr("customer").ToString()

        ' Parse JSON items
        Dim itemsJson As String = dr("items").ToString()
        Dim prettyItems As String = ""
        If Not String.IsNullOrEmpty(itemsJson) Then
            Try
                Dim itemsList As List(Of OrderItem) =
                    JsonSerializer.Deserialize(Of List(Of OrderItem))(itemsJson)
                prettyItems = String.Join(vbCrLf, itemsList.Select(Function(i) $"{i.Item} x{i.Quantity} = {i.Subtotal:0.00}"))
            Catch
                prettyItems = "Invalid JSON"
            End Try
        End If

        Dim totalCost As Decimal = Convert.ToDecimal(dr("total_cost"))
        Dim formattedCost As String = totalCost.ToString("F2")

        orderStatusReportDgv.Rows.Add(
            dr("status"),
            formattedId,
            customer,
            prettyItems,
            formattedCost,
            dr("payment"),
            dr("shipping_address")
        )
    End Sub

    ' Helper: Wrap items column
    Private Sub WrapItemsColumn()
        orderStatusReportDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        orderStatusReportDgv.Columns("Column4").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        orderStatusReportDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub Rep_Order_Status_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrderStatusReport()
    End Sub

    Public ReadOnly Property Filters As String()
        Get
            Return New String() {"None", "Status", "Amount", "Price"}
        End Get
    End Property

End Class
