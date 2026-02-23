Imports System.Text.Json
Imports Jimson_Order___Management_System.Orders
Imports MySql.Data.MySqlClient
Imports System.Reflection

Public Class Cashier_Dashboard

    Private Const MaxRows As Integer = 50


    Private Sub Cashier_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableDoubleBuffering(cashDgv)
        dgv_load()
        LoadTotalRevenue()
        LoadProcessingOrders()
        LoadCompletedOrders()
    End Sub

    ' --- Enable double buffering to reduce flicker ---
    Private Sub EnableDoubleBuffering(dgv As DataGridView)
        Dim dgvType As Type = dgv.GetType()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, True, Nothing)
    End Sub

    ' --- Optimized DataGridView load ---
    Sub dgv_load(Optional searchText As String = "", Optional limit As Integer = MaxRows)
        Try
            cashDgv.Rows.Clear()

            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                Dim query As String =
            "SELECT order_no, customer, items, total_cost, payment, status " &
            "FROM `order` WHERE is_deleted = 0"

                ' Optional search filter
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    query &= " AND (customer LIKE @search OR order_no LIKE @search)"
                End If

                query &= " ORDER BY order_no DESC"

                ' Apply limit at SQL level
                If limit > 0 Then query &= $" LIMIT {limit}"

                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@search", $"%{searchText}%")
                    End If

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            ' Format order number
                            Dim formattedOrderNo As String = CInt(dr("order_no")).ToString("D6")

                            ' Parse JSON items
                            Dim itemsJson As String = If(dr("items") IsNot DBNull.Value, dr("items").ToString(), "")
                            Dim prettyItems As String = ""
                            If Not String.IsNullOrEmpty(itemsJson) Then
                                Try
                                    Dim itemsList As List(Of OrderItem) = JsonSerializer.Deserialize(Of List(Of OrderItem))(itemsJson)
                                    prettyItems = String.Join(vbCrLf, itemsList.Select(Function(i) $"{i.Item} x{i.Quantity} = {i.Subtotal:0.00}"))
                                Catch
                                    prettyItems = "Invalid JSON"
                                End Try
                            End If

                            ' Add row (matches exactly 6 columns)
                            cashDgv.Rows.Add(
                            formattedOrderNo,           ' order no
                            dr("customer").ToString(),  ' customer
                            prettyItems,                ' items
                            Convert.ToDecimal(dr("total_cost")).ToString("F2"), ' total cost
                            dr("payment").ToString(),   ' payment
                            dr("status").ToString()     ' status
                        )
                        End While
                    End Using
                End Using
            End Using

            ' Wrap text in Items column
            cashDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            cashDgv.Columns("itemsCol").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        Catch ex As Exception
            MsgBox("Error loading orders: " & ex.Message)
        End Try
    End Sub



    ' --- Revenue and counts remain unchanged ---
    Private Sub LoadTotalRevenue()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Dim query As String = "SELECT SUM(total_cost) FROM `order` WHERE `is_deleted` = 0"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    revenueLbl.Text = If(IsDBNull(result), "₱0.00", "₱" & Format(Convert.ToDecimal(result), "N2"))
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadProcessingOrders()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM `order` WHERE `status` = 'Processing' AND `is_deleted` = 0"
                Using cmd As New MySqlCommand(query, conn)
                    processingLbl.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCompletedOrders()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM `order` WHERE `status` = 'Completed' AND `is_deleted` = 0"
                Using cmd As New MySqlCommand(query, conn)
                    completedLbl.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class
