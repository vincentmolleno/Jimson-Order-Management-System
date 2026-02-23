Imports System.Text.Json
Imports Jimson_Order___Management_System.Orders
Imports MySql.Data.MySqlClient

Public Class Ord_Edit_Order
    Dim conn As New MySqlConnection(modDB.strConnection)

    Private Sub UpdateOrder()
        Try
            ' Convert cartLv items to JSON
            Dim itemsList As New List(Of Object)
            For Each lvi As ListViewItem In cartLv.Items
                itemsList.Add(New With {
                .Item = lvi.SubItems(0).Text,
                .Quantity = CInt(lvi.SubItems(1).Text),
                .Cost = Convert.ToDecimal(lvi.SubItems(2).Text),
                .Subtotal = Convert.ToDecimal(lvi.SubItems(3).Text)
            })
            Next

            Dim itemsJson As String = JsonSerializer.Serialize(itemsList)

            conn.Open()

            ' Update order with updated_by
            Dim query As String =
        "UPDATE `order` SET
            customer = @customer,
            contact_details = @contact_details,
            items = @items,
            shipping_address = @shipping_address,
            shipping_fee = @shipping_fee,
            total_cost = @total_cost,
            payment = @payment,
            status = @status,
            notes = @notes,
            updated_by = @updated_by
         WHERE order_no = @order_no AND is_deleted = 0"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.Clear()

            cmd.Parameters.AddWithValue("@customer", customerNameTb.Text)
            cmd.Parameters.AddWithValue("@contact_details", contactDetailsTb.Text)
            cmd.Parameters.AddWithValue("@items", itemsJson)
            cmd.Parameters.AddWithValue("@shipping_address", shipAddrsTb.Text)
            cmd.Parameters.Add("@shipping_fee", MySqlDbType.Decimal).Value = Decimal.Parse(shipFeeLbl.Text)
            cmd.Parameters.Add("@total_cost", MySqlDbType.Decimal).Value = Decimal.Parse(totalLbl.Text)
            cmd.Parameters.AddWithValue("@payment", paymentCb.Text)
            cmd.Parameters.AddWithValue("@status", statusCb.Text)
            cmd.Parameters.AddWithValue("@notes", notesTb.Text)
            cmd.Parameters.AddWithValue("@updated_by", Session.UserID) ' <-- added here
            cmd.Parameters.AddWithValue("@order_no", Integer.Parse(idLbl.Text))

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Order updated successfully!", "UPDATE",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' --- Audit log entry ---
                Dim logCmd As New MySqlCommand(
            "INSERT INTO `audit_log` (`user_id`, `action`, `details`, `level`) 
             VALUES (@user_id, @action, @details, @level)", conn)

                logCmd.Parameters.AddWithValue("@user_id", Session.UserID)
                logCmd.Parameters.AddWithValue("@action", "UPDATE ORDER")
                logCmd.Parameters.AddWithValue("@details", $"Updated order ID {idLbl.Text} for customer {customerNameTb.Text}")
                logCmd.Parameters.AddWithValue("@level", "INFO")
                logCmd.ExecuteNonQuery()

            Else
                MessageBox.Show("Order update failed.", "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Update error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    Public Sub LoadOrderInfo(userId As Integer)
        Try
            conn.Open()
            Dim query As String = "SELECT order_no, order_date, customer, contact_details, items, shipping_address, shipping_fee, total_cost, payment, status, notes FROM `order` WHERE order_no=@order_no AND is_deleted=0"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@order_no", userId)


            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim ordId As Integer = Convert.ToInt32(reader("order_no"))
                ' Fill the form label placeholders
                idLbl.Text = ordId.ToString("D6")
                orderDateLbl.Text = reader("order_date").ToString()
                customerNameTb.Text = reader("customer").ToString()
                contactDetailsTb.Text = reader("contact_details").ToString()
                shipAddrsTb.Text = reader("shipping_address").ToString()
                shipFeeLbl.Text = Convert.ToDecimal(reader("shipping_fee")).ToString("0.00")
                totalLbl.Text = Convert.ToDecimal(reader("total_cost")).ToString("0.00")
                ' Load payment safely
                Dim paymentValue As String = reader("payment").ToString().Trim()
                If paymentCb.Items.Contains(paymentValue) Then
                    paymentCb.SelectedItem = paymentValue
                Else
                    paymentCb.SelectedIndex = -1 ' fallback
                End If

                ' Load status safely
                Dim statusValue As String = reader("status").ToString().Trim()
                If statusCb.Items.Contains(statusValue) Then
                    statusCb.SelectedItem = statusValue
                Else
                    statusCb.SelectedIndex = -1 ' fallback
                End If
                notesTb.Text = reader("notes").ToString()

                Dim itemsJson As String = reader("items").ToString()
                LoadCartFromJson(itemsJson)
            Else
                MessageBox.Show("Order not found or deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading order info: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadCartFromJson(itemsJson As String)
        cartLv.Items.Clear()

        Dim itemsList As List(Of OrderItem) =
        JsonSerializer.Deserialize(Of List(Of OrderItem))(itemsJson)

        For Each itm As OrderItem In itemsList
            Dim lvi As New ListViewItem(itm.Item)
            lvi.SubItems.Add(itm.Quantity.ToString())
            lvi.SubItems.Add(itm.Cost.ToString("0.00"))
            lvi.SubItems.Add(itm.Subtotal.ToString("0.00"))

            cartLv.Items.Add(lvi)
        Next
    End Sub

    ' itemTb auto load item and complete
    Private Sub LoadItemAutoComplete()
        Try
            Dim ac As New AutoCompleteStringCollection()

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim cmd As New MySqlCommand("SELECT item_name FROM inventory", conn)
                Dim dr As MySqlDataReader = cmd.ExecuteReader()

                While dr.Read()
                    ac.Add(dr.GetString("item_name"))
            End While

            itemNameTb.AutoCompleteCustomSource = ac

            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub





    ' Add/Update item in ListView
    Private Sub addItemBtn_Click(sender As Object, e As EventArgs) Handles addItemBtn.Click
        Dim item As String = itemNameTb.Text.Trim()
        Dim quantity As Integer

        ' Validate input
        If item = "" Then
            MessageBox.Show("Enter an item name")
            Exit Sub
        End If

        If Not Integer.TryParse(quantityTb.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Enter a valid quantity")
            Exit Sub
        End If

        ' Fetch cost from inventory
        Dim cost As Decimal = 0
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT price FROM inventory WHERE item_name = @itemName LIMIT 1"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@itemName", item)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                cost = Convert.ToDecimal(result)
            Else
                MessageBox.Show("Item not found in inventory")
                conn.Close()
                Exit Sub
            End If

            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error fetching price: " & ex.Message)
            Exit Sub
        End Try

        ' Check if item already exists in ListView
        Dim found As Boolean = False
        For Each lvi As ListViewItem In cartLv.Items
            If lvi.SubItems(0).Text = item Then
                ' Update existing item
                Dim newQty As Integer = CInt(lvi.SubItems(1).Text) + quantity
                lvi.SubItems(1).Text = newQty.ToString()

                Dim newSubtotal As Decimal = newQty * cost
                lvi.SubItems(3).Text = newSubtotal.ToString("0.00")

                found = True
                Exit For
            End If
        Next

        ' If not found, add as new row
        If Not found Then
            Dim subtotal As Decimal = quantity * cost
            Dim lvi As New ListViewItem(item)
            lvi.SubItems.Add(quantity.ToString())
            lvi.SubItems.Add(cost.ToString("0.00"))
            lvi.SubItems.Add(subtotal.ToString("0.00"))

            cartLv.Items.Add(lvi)
        End If

        ' Clear input
        itemNameTb.Clear()
        quantityTb.Clear()
        itemNameTb.Focus()

        ' Recalculate total
        RecalculateTotal()
    End Sub


    ' Add Shipping Fee and Total row
    Private Sub RecalculateTotal()
        Dim total As Decimal = 0
        For Each lvi As ListViewItem In cartLv.Items
            total += Decimal.Parse(lvi.SubItems(3).Text) ' subtotal column
        Next

        Dim shipping As Decimal = 0
        Decimal.TryParse(shipFeeTb.Text, shipping)

        ' Sync shipFeeLbl with shipFeeTb
        shipFeeLbl.Text = shipping.ToString("0.00")

        ' Update totalLbl
        totalLbl.Text = (total + shipping).ToString("0.00")
    End Sub

    Private Sub shipFeeTb_TextChanged(sender As Object, e As EventArgs) Handles shipFeeTb.TextChanged
        RecalculateTotal()
    End Sub


    ' Remove selected item
    Private Sub removeItemBtn_Click(sender As Object, e As EventArgs) Handles removeItemBtn.Click
        For Each lvi As ListViewItem In cartLv.SelectedItems
            cartLv.Items.Remove(lvi)
        Next
        RecalculateTotal()
    End Sub

    Private Sub Ord_Edit_Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadItemAutoComplete()
    End Sub

    Private Sub orderBtn_Click(sender As Object, e As EventArgs) Handles orderBtn.Click
        UpdateOrder()
        Orders.dgv_load()
        Me.Close()
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub
End Class