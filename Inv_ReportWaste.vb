Imports System.ComponentModel
Imports System.Timers
Imports MySql.Data.MySqlClient

Public Class Inv_ReportWaste

    Private autoCompleteTimer As Timer

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property WastageId As Integer = 0 ' 0 = new

    ' =========================
    ' SAVE / UPDATE WASTAGE
    ' =========================
    Private Sub reportBtn_Click(sender As Object, e As EventArgs) Handles reportBtn.Click
        SaveWastage()
    End Sub

    Private Sub SaveWastage()
        ' Validate inputs
        If String.IsNullOrWhiteSpace(itemNameTb.Text) OrElse String.IsNullOrWhiteSpace(quantityTb.Text) Then
            MsgBox("Please complete all required fields.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim newQty As Integer
        If Not Integer.TryParse(quantityTb.Text, newQty) Then
            MsgBox("Quantity must be a valid number.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using tx As MySqlTransaction = conn.BeginTransaction()
                    ' === GET INVENTORY ===
                    Dim category As String
                    Dim price As Decimal
                    Dim invQty As Integer

                    Using cmd As New MySqlCommand(
                    "SELECT category, price, quantity 
                     FROM inventory 
                     WHERE item_name=@item AND is_deleted=0 
                     FOR UPDATE", conn, tx)
                        cmd.Parameters.AddWithValue("@item", itemNameTb.Text.Trim())
                        Using r As MySqlDataReader = cmd.ExecuteReader()
                            If Not r.Read() Then
                                MsgBox("Item not found in inventory.", MsgBoxStyle.Exclamation)
                                tx.Rollback()
                                Exit Sub
                            End If
                            category = r("category").ToString()
                            price = CDec(r("price"))
                            invQty = CInt(r("quantity"))
                        End Using
                    End Using

                    ' Calculate difference for stock update
                    Dim diffQty As Integer = newQty
                    If WastageId > 0 Then
                        Using cmd As New MySqlCommand(
                        "SELECT quantity FROM wastage WHERE id=@id AND is_deleted=0", conn, tx)
                            cmd.Parameters.AddWithValue("@id", WastageId)
                            Dim oldQty As Object = cmd.ExecuteScalar()
                            If oldQty IsNot Nothing Then
                                diffQty -= CInt(oldQty)
                            End If
                        End Using
                    End If

                    ' Stock check
                    If diffQty > invQty Then
                        MsgBox("Not enough stock available.", MsgBoxStyle.Exclamation)
                        tx.Rollback()
                        Exit Sub
                    End If

                    Dim totalCost As Decimal = newQty * price

                    ' === INSERT OR UPDATE WASTAGE ===
                    If WastageId = 0 Then
                        ' New wastage
                        Using cmd As New MySqlCommand(
                        "INSERT INTO wastage
                        (item, category, quantity, reason, reported_by, total_cost, created_by, updated_by)
                        VALUES (@item,@cat,@qty,@reason,@uid,@cost,@uid,@uid)", conn, tx)
                            cmd.Parameters.AddWithValue("@item", itemNameTb.Text.Trim())
                            cmd.Parameters.AddWithValue("@cat", category)
                            cmd.Parameters.AddWithValue("@qty", newQty)
                            cmd.Parameters.AddWithValue("@reason", reasonTb.Text.Trim())
                            cmd.Parameters.AddWithValue("@uid", Session.UserID)
                            cmd.Parameters.AddWithValue("@cost", totalCost)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Audit log
                        Using logCmd As New MySqlCommand(
                        "INSERT INTO audit_log (user_id, action, details, level)
                         VALUES (@user_id, @action, @details, @level)", conn, tx)
                            logCmd.Parameters.AddWithValue("@user_id", Session.UserID)
                            logCmd.Parameters.AddWithValue("@action", "CREATE WASTAGE")
                            logCmd.Parameters.AddWithValue("@details",
                            $"Added wastage: {itemNameTb.Text.Trim()}, Qty: {newQty}, Reason: {reasonTb.Text.Trim()}")
                            logCmd.Parameters.AddWithValue("@level", "INFO")
                            logCmd.ExecuteNonQuery()
                        End Using

                    Else
                        ' Update existing wastage
                        Using cmd As New MySqlCommand(
                        "UPDATE wastage
                         SET quantity=@qty, reason=@reason, total_cost=@cost, updated_by=@uid
                         WHERE id=@id", conn, tx)
                            cmd.Parameters.AddWithValue("@qty", newQty)
                            cmd.Parameters.AddWithValue("@reason", reasonTb.Text.Trim())
                            cmd.Parameters.AddWithValue("@cost", totalCost)
                            cmd.Parameters.AddWithValue("@uid", Session.UserID)
                            cmd.Parameters.AddWithValue("@id", WastageId)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Audit log
                        Using logCmd As New MySqlCommand(
                        "INSERT INTO audit_log (user_id, action, details, level)
                         VALUES (@user_id, @action, @details, @level)", conn, tx)
                            logCmd.Parameters.AddWithValue("@user_id", Session.UserID)
                            logCmd.Parameters.AddWithValue("@action", "UPDATE WASTAGE")
                            logCmd.Parameters.AddWithValue("@details",
                            $"Updated wastage ID {WastageId}: {itemNameTb.Text.Trim()}, Qty: {newQty}, Reason: {reasonTb.Text.Trim()}")
                            logCmd.Parameters.AddWithValue("@level", "INFO")
                            logCmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' === UPDATE INVENTORY ===
                    Using cmd As New MySqlCommand(
                    "UPDATE inventory 
                     SET quantity = quantity - @diff 
                     WHERE item_name=@item AND is_deleted=0", conn, tx)
                        cmd.Parameters.AddWithValue("@diff", diffQty)
                        cmd.Parameters.AddWithValue("@item", itemNameTb.Text.Trim())
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Commit transaction
                    tx.Commit()
                End Using
            End Using

            MsgBox("Wastage saved successfully.", MsgBoxStyle.Information)
            Me.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub



    ' =========================
    ' LOAD FOR EDIT
    ' =========================
    Private Sub Inv_ReportWaste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAutoComplete()
        If WastageId > 0 Then LoadWastage()
    End Sub

    Private Sub LoadWastage()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT item, quantity, reason 
                     FROM wastage 
                     WHERE id=@id AND is_deleted=0", conn)

                    cmd.Parameters.AddWithValue("@id", WastageId)
                    Using r = cmd.ExecuteReader()
                        If r.Read() Then
                            itemNameTb.Text = r("item").ToString()
                            quantityTb.Text = r("quantity").ToString()
                            reasonTb.Text = r("reason").ToString()
                            itemNameTb.Enabled = False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed to load wastage: " & ex.Message)
        End Try
    End Sub

    ' =========================
    ' AUTOCOMPLETE
    ' =========================
    Private Sub itemNameTb_TextChanged(sender As Object, e As EventArgs) Handles itemNameTb.TextChanged
        If autoCompleteTimer Is Nothing Then
            autoCompleteTimer = New Timer(300)
            AddHandler autoCompleteTimer.Elapsed, AddressOf AutoCompleteTimerElapsed
            autoCompleteTimer.AutoReset = False
        End If
        autoCompleteTimer.Stop()
        autoCompleteTimer.Start()
    End Sub

    Private Sub AutoCompleteTimerElapsed(sender As Object, e As ElapsedEventArgs)
        If InvokeRequired Then
            Invoke(Sub() LoadAutoComplete())
        Else
            LoadAutoComplete()
        End If
    End Sub

    Private Sub LoadAutoComplete()
        Try
            Dim ac As New AutoCompleteStringCollection()
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT item_name FROM inventory WHERE is_deleted=0", conn)
                    Using r = cmd.ExecuteReader()
                        While r.Read()
                            ac.Add(r("item_name").ToString())
                        End While
                    End Using
                End Using
            End Using

            itemNameTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            itemNameTb.AutoCompleteSource = AutoCompleteSource.CustomSource
            itemNameTb.AutoCompleteCustomSource = ac
        Catch
        End Try
    End Sub

End Class
