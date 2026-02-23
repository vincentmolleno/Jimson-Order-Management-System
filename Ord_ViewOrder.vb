Imports System.Text.Json
Imports Jimson_Order___Management_System.Orders
Imports MySql.Data.MySqlClient

Public Class Ord_ViewOrder
    Dim conn As New MySqlConnection(modDB.strConnection)

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
                customerNameLbl.Text = reader("customer").ToString()
                contactDetailsLbl.Text = reader("contact_details").ToString()
                shipAddrsLbl.Text = reader("shipping_address").ToString()
                shipFeeLbl.Text = Convert.ToDecimal(reader("shipping_fee")).ToString("0.00")
                totalLbl.Text = Convert.ToDecimal(reader("total_cost")).ToString("0.00")
                paymentLbl.Text = reader("payment").ToString()
                statusLbl.Text = reader("status").ToString()
                notesPh.Text = reader("notes").ToString()

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


    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub
End Class