Imports MySql.Data.MySqlClient

Public Class Inv_AddItem

    ' ---- CREATE OR UPDATE ITEM ----
    Private Sub create()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                ' First, check if item already exists
                Using checkCmd As New MySqlCommand("SELECT * FROM `inventory` WHERE `item_name` = @item_name AND `is_deleted` = 0", conn)
                    checkCmd.Parameters.AddWithValue("@item_name", itemNameTb.Text)
                    Using dr As MySqlDataReader = checkCmd.ExecuteReader()
                        If dr.HasRows Then
                            ' Item exists → update quantity and other fields
                            dr.Read()
                            Dim inventoryId As Integer = Convert.ToInt32(dr("id"))
                            Dim existingQty As Integer = Convert.ToInt32(dr("quantity"))
                            Dim newQty As Integer = existingQty + Convert.ToInt32(quantityTb.Text)
                            Dim minStock As Integer = Convert.ToInt32(minStockTb.Text)
                            dr.Close()

                            ' Determine status
                            Dim status As String = If(newQty < minStock, "Low Stock", "Available")

                            ' Update item
                            Using updateCmd As New MySqlCommand("
                                UPDATE `inventory` 
                                SET `quantity` = @quantity, `category` = @category, `unit` = @unit, 
                                    `minimum_stock` = @minimum_stock, `price` = @price, 
                                    `supplier` = @supplier, `note` = @note, `status` = @status,
                                    `updated_by` = @updated_by,
                                    `updated_at` = @updated_at
                                WHERE `id` = @id", conn)

                                updateCmd.Parameters.AddWithValue("@quantity", newQty)
                                updateCmd.Parameters.AddWithValue("@category", categoryCb.Text)
                                updateCmd.Parameters.AddWithValue("@unit", unitTb.Text)
                                updateCmd.Parameters.AddWithValue("@minimum_stock", minStockTb.Text)
                                updateCmd.Parameters.AddWithValue("@price", priceLbl.Text)
                                updateCmd.Parameters.AddWithValue("@supplier", supplierTb.Text)
                                updateCmd.Parameters.AddWithValue("@note", notesTb.Text)
                                updateCmd.Parameters.AddWithValue("@status", status)
                                updateCmd.Parameters.AddWithValue("@updated_by", Session.UserID)
                                updateCmd.Parameters.AddWithValue("@updated_at", DateTime.Now)
                                updateCmd.Parameters.AddWithValue("@id", inventoryId)
                                updateCmd.ExecuteNonQuery()
                            End Using

                            MessageBox.Show("Item updated!", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' --- Audit logging for update ---
                            Using logCmd As New MySqlCommand("
                                INSERT INTO audit_log 
                                (entity_id, entity_type, action, details, level, updated_by, updated_at) 
                                VALUES (@entity_id, @entity_type, @action, @details, @level, @updated_by, @updated_at)", conn)

                                logCmd.Parameters.AddWithValue("@entity_id", inventoryId)
                                logCmd.Parameters.AddWithValue("@entity_type", "Inventory")
                                logCmd.Parameters.AddWithValue("@action", "Update")
                                logCmd.Parameters.AddWithValue("@details", $"Inventory item '{itemNameTb.Text}' was updated. New quantity: {newQty}")
                                logCmd.Parameters.AddWithValue("@level", Session.UserType)
                                logCmd.Parameters.AddWithValue("@updated_by", Session.UserID)
                                logCmd.Parameters.AddWithValue("@updated_at", DateTime.Now)
                                logCmd.ExecuteNonQuery()
                            End Using

                        Else
                            ' Item does not exist → insert new
                            dr.Close()
                            Dim initialStatus As String = If(Convert.ToInt32(quantityTb.Text) < Convert.ToInt32(minStockTb.Text), "Low Stock", "Sufficient")

                            Using insertCmd As New MySqlCommand("
                                INSERT INTO `inventory`
                                (`item_name`, `category`, `quantity`, `unit`, `minimum_stock`, `price`, `supplier`, `note`, `status`, `created_by`, `created_at`) 
                                VALUES (@item_name, @category, @quantity, @unit, @minimum_stock, @price, @supplier, @note, @status, @created_by, @created_at)", conn)

                                insertCmd.Parameters.AddWithValue("@item_name", itemNameTb.Text)
                                insertCmd.Parameters.AddWithValue("@category", categoryCb.Text)
                                insertCmd.Parameters.AddWithValue("@quantity", quantityTb.Text)
                                insertCmd.Parameters.AddWithValue("@unit", unitTb.Text)
                                insertCmd.Parameters.AddWithValue("@minimum_stock", minStockTb.Text)
                                insertCmd.Parameters.AddWithValue("@price", priceLbl.Text)
                                insertCmd.Parameters.AddWithValue("@supplier", supplierTb.Text)
                                insertCmd.Parameters.AddWithValue("@note", notesTb.Text)
                                insertCmd.Parameters.AddWithValue("@status", initialStatus)
                                insertCmd.Parameters.AddWithValue("@created_by", Session.UserID)
                                insertCmd.Parameters.AddWithValue("@created_at", DateTime.Now)
                                insertCmd.ExecuteNonQuery()

                                Dim newItemId As Integer = Convert.ToInt32(insertCmd.LastInsertedId)

                                ' --- Audit logging for creation ---
                                Using logCmd As New MySqlCommand("
                                    INSERT INTO audit_log 
                                    (entity_id, entity_type, action, details, level, created_by, created_at) 
                                    VALUES (@entity_id, @entity_type, @action, @details, @level, @created_by, @created_at)", conn)

                                    logCmd.Parameters.AddWithValue("@entity_id", newItemId)
                                    logCmd.Parameters.AddWithValue("@entity_type", "Inventory")
                                    logCmd.Parameters.AddWithValue("@action", "Create")
                                    logCmd.Parameters.AddWithValue("@details", $"Inventory item '{itemNameTb.Text}' was created. Quantity: {quantityTb.Text}")
                                    logCmd.Parameters.AddWithValue("@level", Session.UserType)
                                    logCmd.Parameters.AddWithValue("@created_by", Session.UserID)
                                    logCmd.Parameters.AddWithValue("@created_at", DateTime.Now)
                                    logCmd.ExecuteNonQuery()
                                End Using
                            End Using

                            MessageBox.Show("Item added!", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    ' --- Load categories for ComboBox ---
    Private Sub LoadCategories()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT DISTINCT category FROM `inventory` WHERE is_deleted = 0 ORDER BY category ASC", conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        categoryCb.Items.Clear()
                        While dr.Read()
                            categoryCb.Items.Add(dr("category").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading categories: " & ex.Message)
        End Try
    End Sub

    ' --- Load AutoComplete for item names ---
    Private Sub LoadItemAutoComplete()
        Try
            Dim ac As New AutoCompleteStringCollection()
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT item_name FROM inventory WHERE is_deleted = 0", conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            ac.Add(dr.GetString("item_name"))
                        End While
                    End Using
                End Using
            End Using

            itemNameTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            itemNameTb.AutoCompleteSource = AutoCompleteSource.CustomSource
            itemNameTb.AutoCompleteCustomSource = ac
        Catch ex As Exception
            MsgBox("Error loading item names: " & ex.Message)
        End Try
    End Sub

    ' --- Load item details on text change ---
    Private Sub itemNameTb_TextChanged(sender As Object, e As EventArgs) Handles itemNameTb.TextChanged
        LoadItemDetails()
    End Sub

    Private Sub LoadItemDetails()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM `inventory` WHERE `item_name` = @item_name AND `is_deleted` = 0", conn)
                    cmd.Parameters.AddWithValue("@item_name", itemNameTb.Text)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            categoryCb.Text = dr("category").ToString()
                            unitTb.Text = dr("unit").ToString()
                            minStockTb.Text = dr("minimum_stock").ToString()
                            priceLbl.Text = dr("price").ToString()
                            supplierTb.Text = dr("supplier").ToString()
                            notesTb.Text = dr("note").ToString()
                            quantityTb.Text = dr("quantity").ToString()
                        Else
                            categoryCb.Text = ""
                            unitTb.Text = ""
                            minStockTb.Text = ""
                            priceLbl.Text = ""
                            supplierTb.Text = ""
                            notesTb.Text = ""
                            quantityTb.Text = ""
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading item details: " & ex.Message)
        End Try
    End Sub

    ' --- Form Load ---
    Private Sub Inv_AddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        LoadItemAutoComplete()
    End Sub

    ' --- Cancel ---
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    ' --- Save/Create ---
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        create()
        Inventories.dgv_load()
        Me.Close()
    End Sub

    ' --- Required fields validation ---
    Private Sub RequiredFields_TextChanged(sender As Object, e As EventArgs) _
    Handles itemNameTb.TextChanged,
            categoryCb.TextChanged,
            quantityTb.TextChanged,
            unitTb.TextChanged,
            minStockTb.TextChanged,
            priceLbl.TextChanged
        ValidateForm()
    End Sub

    Private Sub ValidateForm()
        Dim requiredFilled As Boolean =
            itemNameTb.Text.Trim() <> "" AndAlso
            categoryCb.Text.Trim() <> "" AndAlso
            quantityTb.Text.Trim() <> "" AndAlso
            unitTb.Text.Trim() <> "" AndAlso
            minStockTb.Text.Trim() <> "" AndAlso
            priceLbl.Text.Trim() <> ""
        Button1.Enabled = requiredFilled
    End Sub

End Class
