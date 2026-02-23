Imports System.IO
Imports System.Text.Json
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient

Public Class Orders
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader

    Private Const PageSize As Integer = 50
    Private lastOrderNo As Integer? = Nothing
    Private isLoading As Boolean = False
    Private allDataLoaded As Boolean = False


    ' ===============================
    ' ======== Form Events ==========
    ' ===============================

    Private Sub Orders_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then dgv_load()
    End Sub

    Private Sub Orders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_load()
        SetDefaultIndex(0, paymentCb, statusCb)
    End Sub

    ' ===============================
    ' ======== Helpers ==============
    ' ===============================

    Private Sub SetDefaultIndex(index As Integer, ParamArray combos() As ComboBox)
        For Each cb As ComboBox In combos
            cb.SelectedIndex = index
        Next
    End Sub

    ' Load all orders
    Sub dgv_load(Optional searchText As String = "", Optional statusFilter As String = "", Optional paymentFilter As String = "", Optional reset As Boolean = False)
        If isLoading Or allDataLoaded Then Return

        If reset Then
            orderDgv.Rows.Clear()
            lastOrderNo = Nothing
            allDataLoaded = False
        End If

        isLoading = True
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
            SELECT order_no, order_date, customer, items, total_cost, payment, status
            FROM `order`
            WHERE is_deleted = 0
            /**ORDER_NO_CLAUSE**"

            ' Keyset pagination
            Dim orderNoClause As String = ""
            If lastOrderNo.HasValue Then
                orderNoClause = " AND order_no > @LastOrderNo"
            End If
            query = query.Replace("/**ORDER_NO_CLAUSE**", orderNoClause)

            ' Filters
            If Not String.IsNullOrEmpty(searchText) Then
                query &= " AND (order_no LIKE @search OR customer LIKE @search OR status LIKE @search)"
            End If
            If Not String.IsNullOrEmpty(statusFilter) AndAlso statusFilter <> "All" Then
                query &= " AND status = @status"
            End If
            If Not String.IsNullOrEmpty(paymentFilter) AndAlso paymentFilter <> "All" Then
                query &= " AND payment = @payment"
            End If

            query &= " ORDER BY order_no ASC LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                If lastOrderNo.HasValue Then cmd.Parameters.AddWithValue("@LastOrderNo", lastOrderNo.Value)
                If Not String.IsNullOrEmpty(searchText) Then cmd.Parameters.AddWithValue("@search", $"%{searchText}%")
                If Not String.IsNullOrEmpty(statusFilter) AndAlso statusFilter <> "All" Then cmd.Parameters.AddWithValue("@status", statusFilter)
                If Not String.IsNullOrEmpty(paymentFilter) AndAlso paymentFilter <> "All" Then cmd.Parameters.AddWithValue("@payment", paymentFilter)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    Dim rowsLoaded As Integer = 0
                    While dr.Read()
                        Dim orderNoFormatted As String = CInt(dr("order_no")).ToString("D6")
                        Dim customer As String = dr("customer").ToString()
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

                        Dim rowIndex = orderDgv.Rows.Add(orderNoFormatted, dr("order_date"), customer, prettyItems, dr("total_cost"), dr("payment"), dr("status"))
                        orderDgv.Rows(rowIndex).Tag = itemsJson

                        lastOrderNo = Convert.ToInt32(dr("order_no"))
                        rowsLoaded += 1
                    End While

                    If rowsLoaded < PageSize Then allDataLoaded = True
                End Using
            End Using

            orderDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            orderDgv.Columns("itemsCol").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
            isLoading = False
        End Try
    End Sub


    ' ===============================
    ' ======== OrderItem Class ======
    ' ===============================
    Public Class OrderItem
        Public Property Item As String
        Public Property Quantity As Integer
        Public Property Cost As Decimal
        Public Property Subtotal As Decimal
    End Class

    ' ===============================
    ' ======== New Order ============
    ' ===============================
    Private Sub newOrdBtn_Click(sender As Object, e As EventArgs) Handles newOrdBtn.Click
        Dim newOrderForm As New Ord_NewOrder()
        newOrderForm.TopMost = True
        newOrderForm.Show()
    End Sub

    ' ===============================
    ' ======== Right Click ==========
    ' ===============================
    Private Sub orderDgv_MouseDown(sender As Object, e As MouseEventArgs) Handles orderDgv.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = orderDgv.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                orderDgv.ClearSelection()
                orderDgv.Rows(hit.RowIndex).Selected = True
                orderMenu.Show(orderDgv, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    ' ===============================
    ' ======== View / Edit ==========
    ' ===============================
    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        If orderDgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an order first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedOrderNo As Integer = Convert.ToInt32(orderDgv.SelectedRows(0).Cells("id").Value)
        Dim viewForm As New Ord_ViewOrder()
        viewForm.LoadOrderInfo(selectedOrderNo)
        viewForm.TopMost = True
        viewForm.ShowDialog()
    End Sub

    Private Sub EditOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditOrderToolStripMenuItem.Click
        If orderDgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an order first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedOrderNo As Integer = Convert.ToInt32(orderDgv.SelectedRows(0).Cells("id").Value)
        Dim editForm As New Ord_Edit_Order()
        editForm.LoadOrderInfo(selectedOrderNo)
        editForm.TopMost = True
        editForm.ShowDialog()
    End Sub

    ' ===============================
    ' ======== Search / Filters =====
    ' ===============================
    Private Sub searchTb_TextChanged(sender As Object, e As EventArgs) Handles searchTb.TextChanged
        dgv_load(searchTb.Text, statusCb.Text, paymentCb.Text)
    End Sub

    Private Sub statusCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles statusCb.SelectedIndexChanged
        dgv_load(searchTb.Text, statusCb.Text, paymentCb.Text)
    End Sub

    Private Sub paymentCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles paymentCb.SelectedIndexChanged
        dgv_load(searchTb.Text, statusCb.Text, paymentCb.Text)
    End Sub

    ' ===============================
    ' ======== Delete Order =========
    ' ===============================
    Private Sub DeleteOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteOrderToolStripMenuItem.Click
        If orderDgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an order first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim orderNo As Integer = Convert.ToInt32(orderDgv.SelectedRows(0).Cells("id").Value)
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete Order #{orderNo:D6}?" & vbCrLf & "(This can be restored later)", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result <> DialogResult.Yes Then Return

        Try
            conn.Open()
            ' Soft delete + log
            Dim createdBy As String = ""
            Using cmd As New MySqlCommand("SELECT created_by FROM `order` WHERE order_no=@order_no", conn)
                cmd.Parameters.AddWithValue("@order_no", orderNo)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() AndAlso Not IsDBNull(dr("created_by")) Then createdBy = dr("created_by").ToString()
                End Using
            End Using

            Using cmd As New MySqlCommand("UPDATE `order` SET is_deleted=1, deleted_by=@deleted_by, deleted_at=@deleted_at WHERE order_no=@order_no", conn)
                cmd.Parameters.AddWithValue("@order_no", orderNo)
                cmd.Parameters.AddWithValue("@deleted_by", Session.UserID)
                cmd.Parameters.AddWithValue("@deleted_at", DateTime.Now)
                cmd.ExecuteNonQuery()
            End Using

            Using cmd As New MySqlCommand("INSERT INTO audit_log(entity_id, entity_type, action, details, level, deleted_by, deleted_at, created_by) VALUES(@entity_id,@entity_type,@action,@details,@level,@deleted_by,@deleted_at,@created_by)", conn)
                cmd.Parameters.AddWithValue("@entity_id", orderNo)
                cmd.Parameters.AddWithValue("@entity_type", "Order")
                cmd.Parameters.AddWithValue("@action", "Delete")
                cmd.Parameters.AddWithValue("@details", $"Order #{orderNo:D6} was deleted.")
                cmd.Parameters.AddWithValue("@level", Session.UserType)
                cmd.Parameters.AddWithValue("@deleted_by", Session.UserID)
                cmd.Parameters.AddWithValue("@deleted_at", DateTime.Now)
                cmd.Parameters.AddWithValue("@created_by", createdBy)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Order deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgv_load()

        Catch ex As Exception
            MessageBox.Show("Error deleting order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' ===============================
    ' ======== PDF Generation =======
    ' ===============================
    ' ===============================
    ' ======== PDF Generation =======
    ' ===============================
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If orderDgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an order first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataGridViewRow = orderDgv.SelectedRows(0)
        Dim orderNo As Integer = Convert.ToInt32(row.Cells("id").Value)
        Dim orderDate As String = row.Cells("dateCol").Value.ToString()
        Dim customer As String = row.Cells("customer").Value.ToString()
        Dim payment As String = row.Cells("payment").Value.ToString()
        Dim status As String = row.Cells("statusCol").Value.ToString()
        Dim totalCost As Decimal = Convert.ToDecimal(row.Cells("Column1").Value)

        ' Fetch JSON, shipping_fee, shipping_address from DB
        Dim itemsJson As String = ""
        Dim shippingFee As Decimal = 0
        Dim shippingAddress As String = ""

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Using cmd As New MySqlCommand("SELECT items, shipping_fee, shipping_address FROM `order` WHERE order_no=@order_no", conn)
                cmd.Parameters.AddWithValue("@order_no", orderNo)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        itemsJson = dr("items").ToString()
                        If Not IsDBNull(dr("shipping_fee")) Then shippingFee = Convert.ToDecimal(dr("shipping_fee"))
                        If Not IsDBNull(dr("shipping_address")) Then shippingAddress = dr("shipping_address").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving order info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            conn.Close()
        End Try

        ' Save PDF
        Dim saveDlg As New SaveFileDialog() With {
            .Filter = "PDF Files|*.pdf",
            .FileName = $"Receipt_Order_{orderNo:D6}.pdf"
        }
        If saveDlg.ShowDialog() <> DialogResult.OK Then Return

        Try
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(saveDlg.FileName, FileMode.Create))
            doc.Open()

            ' --- Title ---
            Dim title As New Paragraph($"Receipt - Order #{orderNo:D6}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)) With {
                .Alignment = Element.ALIGN_CENTER,
                .SpacingAfter = 10
            }
            doc.Add(title)

            ' --- Order Info Table ---
            Dim infoTable As New PdfPTable(2) With {.WidthPercentage = 80, .SpacingAfter = 10}
            infoTable.SetWidths({30, 70})
            Dim info = New Dictionary(Of String, String) From {
                {"Order No:", orderNo.ToString("D6")},
                {"Date:", orderDate},
                {"Customer:", customer},
                {"Payment:", payment},
                {"Status:", status},
                {"Shipping Address:", shippingAddress}
            }
            For Each kvp In info
                infoTable.AddCell(New PdfPCell(New Phrase(kvp.Key, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) With {.Border = Rectangle.NO_BORDER})
                infoTable.AddCell(New PdfPCell(New Phrase(kvp.Value, FontFactory.GetFont(FontFactory.HELVETICA, 12))) With {.Border = Rectangle.NO_BORDER})
            Next
            doc.Add(infoTable)

            ' --- Items Table ---
            Dim itemsTable As New PdfPTable(4) With {.WidthPercentage = 100, .SpacingAfter = 10}
            itemsTable.SetWidths({50, 15, 15, 20})
            Dim headers() As String = {"Item", "Quantity", "Cost", "Subtotal"}
            For Each h In headers
                Dim cell As New PdfPCell(New Phrase(h, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) With {
                    .BackgroundColor = BaseColor.LIGHT_GRAY,
                    .HorizontalAlignment = Element.ALIGN_CENTER
                }
                itemsTable.AddCell(cell)
            Next

            ' Parse JSON
            If Not String.IsNullOrEmpty(itemsJson) Then
                Try
                    Dim itemsList As List(Of OrderItem) = JsonSerializer.Deserialize(Of List(Of OrderItem))(itemsJson, New JsonSerializerOptions With {.PropertyNameCaseInsensitive = True})
                    For Each item In itemsList
                        itemsTable.AddCell(New Phrase(item.Item, FontFactory.GetFont(FontFactory.HELVETICA, 11)))
                        itemsTable.AddCell(New Phrase(item.Quantity.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 11)))
                        itemsTable.AddCell(New Phrase(item.Cost.ToString("0.00"), FontFactory.GetFont(FontFactory.HELVETICA, 11)))
                        itemsTable.AddCell(New Phrase(item.Subtotal.ToString("0.00"), FontFactory.GetFont(FontFactory.HELVETICA, 11)))
                    Next
                Catch
                    itemsTable.AddCell(New PdfPCell(New Phrase("Invalid JSON", FontFactory.GetFont(FontFactory.HELVETICA, 11))) With {.Colspan = 4, .HorizontalAlignment = Element.ALIGN_CENTER})
                End Try
            End If
            doc.Add(itemsTable)

            ' --- Shipping Fee & Total ---
            Dim shippingTable As New PdfPTable(2) With {.WidthPercentage = 100, .SpacingAfter = 5}
            shippingTable.SetWidths({80, 20})
            shippingTable.AddCell(New PdfPCell(New Phrase("Shipping Fee", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) With {.Border = Rectangle.NO_BORDER, .HorizontalAlignment = Element.ALIGN_RIGHT})
            shippingTable.AddCell(New PdfPCell(New Phrase($"{shippingFee:0.00}", FontFactory.GetFont(FontFactory.HELVETICA, 12))) With {.Border = Rectangle.NO_BORDER, .HorizontalAlignment = Element.ALIGN_RIGHT})
            doc.Add(shippingTable)

            Dim finalTotal As Decimal = totalCost + shippingFee
            Dim totalTable As New PdfPTable(2) With {.WidthPercentage = 100}
            totalTable.SetWidths({80, 20})
            totalTable.AddCell(New PdfPCell(New Phrase("Total", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) With {.Border = Rectangle.NO_BORDER, .HorizontalAlignment = Element.ALIGN_RIGHT})
            totalTable.AddCell(New PdfPCell(New Phrase($"{finalTotal:0.00}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) With {.Border = Rectangle.NO_BORDER, .HorizontalAlignment = Element.ALIGN_RIGHT})
            doc.Add(totalTable)

            doc.Close()

            ' --- Audit Logging ---
            LogOrderPDFExport(orderNo, saveDlg.FileName)

            MessageBox.Show($"Receipt for Order #{orderNo:D6} generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error generating receipt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ===============================
    ' ======== Audit Logging ========
    ' ===============================
    Private Sub LogOrderPDFExport(orderNo As Integer, fileName As String)
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "INSERT INTO audit_log 
                 (entity_id, entity_type, action, details, level, created_by, created_at)
                 VALUES (@entity_id, @entity_type, @action, @details, @level, @created_by, @created_at)", conn)

                    cmd.Parameters.AddWithValue("@entity_id", orderNo)
                    cmd.Parameters.AddWithValue("@entity_type", "Order")
                    cmd.Parameters.AddWithValue("@action", "Export")
                    cmd.Parameters.AddWithValue("@details", $"Generated PDF receipt for Order #{orderNo:D6}: {fileName}")
                    cmd.Parameters.AddWithValue("@level", Session.UserType)
                    cmd.Parameters.AddWithValue("@created_by", Session.UserID)
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' fail silently to not block PDF generation
        End Try
    End Sub



End Class
