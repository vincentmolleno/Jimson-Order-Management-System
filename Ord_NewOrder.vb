Imports MySql.Data.MySqlClient
Imports System.Text.Json

Public Class Ord_NewOrder
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim i As Integer
    Dim dr As MySqlDataReader

    ' create function
    Private Sub create()
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

            ' Insert into database
            ' Insert into database
            conn.Open()
            Dim cmd As New MySqlCommand(
                "INSERT INTO `order` 
                 (`customer`, `contact_details`, `items`, `total_cost`, `shipping_address`, `shipping_fee`, `notes`, `created_by`) 
                 VALUES (@customer, @contact_details, @items, @total_cost, @shipping_address, @shipping_fee, @notes, @created_by)", conn)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@customer", customerNameTb.Text)
            cmd.Parameters.AddWithValue("@contact_details", contactDetailsTb.Text)
            cmd.Parameters.AddWithValue("@items", itemsJson) ' JSON string
            cmd.Parameters.Add("@total_cost", MySqlDbType.Decimal).Value = Decimal.Parse(totalLbl.Text)
            cmd.Parameters.AddWithValue("@shipping_address", shipAddrsTb.Text)
            cmd.Parameters.Add("@shipping_fee", MySqlDbType.Decimal).Value = Decimal.Parse(shipFeeTb.Text)
            cmd.Parameters.AddWithValue("@notes", notesTb.Text)
            cmd.Parameters.AddWithValue("@created_by", Session.UserID) ' <-- new

            i = cmd.ExecuteNonQuery()

            If i > 0 Then
                MessageBox.Show("Order added!", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' --- Audit log entry ---
                Dim orderId As Long = cmd.LastInsertedId ' get the last inserted order ID
                Dim logCmd As New MySqlCommand(
                "INSERT INTO `audit_log` (`user_id`, `action`, `details`, `level`) 
                 VALUES (@user_id, @action, @details, @level)", conn)

                logCmd.Parameters.AddWithValue("@user_id", Session.UserID) ' logged-in user
                logCmd.Parameters.AddWithValue("@action", "CREATE ORDER")
                logCmd.Parameters.AddWithValue("@details", $"Created order ID {orderId} for {customerNameTb.Text}")
                logCmd.Parameters.AddWithValue("@level", "INFO")

                logCmd.ExecuteNonQuery()

            Else
                MessageBox.Show("Order failed to add!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
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
            conn.Close()

            itemNameTb.AutoCompleteCustomSource = ac

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

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    Private Sub orderBtn_Click(sender As Object, e As EventArgs) Handles orderBtn.Click
        create()
        Orders.dgv_load()
        Me.Close()
    End Sub

    Private Sub Ord_NewOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadItemAutoComplete()

        shipFeeLbl.Text = ""
        totalLbl.Text = ""
    End Sub

End Class