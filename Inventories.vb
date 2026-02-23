Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient

Public Class Inventories
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader

    Private Const PageSize As Integer = 50          ' Number of rows per page
    Private lastInventoryId As Integer? = Nothing  ' Tracks the last loaded inventory ID (for keyset pagination)
    Private isLoading As Boolean = False           ' Prevent multiple loads at once
    Private allDataLoaded As Boolean = False       ' Stop when no more rows


    Private Sub Inventories_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then dgv_load()
    End Sub

    Public Sub LimitToStaffInventory()
        exportBtn.Visible = False
        exportBtn.Enabled = False
    End Sub

    Private Sub Inventories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_load()
        SetDefaultIndex(0, statusCb)
    End Sub

    Private Sub SetDefaultIndex(index As Integer, ParamArray combos() As ComboBox)
        For Each cb As ComboBox In combos
            cb.SelectedIndex = index
        Next
    End Sub

    Sub dgv_load(Optional reset As Boolean = False)
        If isLoading Or allDataLoaded Then Return

        If reset Then
            invDgv.Rows.Clear()
            lastInventoryId = Nothing
            allDataLoaded = False
        End If

        isLoading = True
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
            SELECT id, item_name, category, quantity, unit, minimum_stock, price, status
            FROM inventory
            WHERE is_deleted = 0
            /**ID_CLAUSE**/
            ORDER BY id ASC
            LIMIT @PageSize"

            ' Keyset pagination: only load items with id > lastInventoryId
            Dim idClause As String = ""
            If lastInventoryId.HasValue Then
                idClause = "AND id > @LastInventoryId"
            End If
            query = query.Replace("/**ID_CLAUSE**/", idClause)

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                If lastInventoryId.HasValue Then cmd.Parameters.AddWithValue("@LastInventoryId", lastInventoryId.Value)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    Dim rowsLoaded As Integer = 0
                    While dr.Read()
                        Dim formattedId As String = CInt(dr("id")).ToString("D6")
                        invDgv.Rows.Add(formattedId, dr("item_name"), dr("category"), dr("quantity"), dr("unit"), dr("minimum_stock"), dr("price"), dr("status"))

                        lastInventoryId = Convert.ToInt32(dr("id"))
                        rowsLoaded += 1
                    End While

                    If rowsLoaded < PageSize Then allDataLoaded = True
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading inventory: " & ex.Message)
        Finally
            conn.Close()
            isLoading = False
        End Try
    End Sub


    ' Right-click menu
    Private Sub invDgv_MouseDown(sender As Object, e As MouseEventArgs) Handles invDgv.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim hit As DataGridView.HitTestInfo = invDgv.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                invDgv.ClearSelection()
                invDgv.Rows(hit.RowIndex).Selected = True
                invMenu.Show(invDgv, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub addItemBtn_Click(sender As Object, e As EventArgs) Handles addItemBtn.Click
        Dim newAddItemForm As New Inv_AddItem()
        newAddItemForm.TopMost = True
        newAddItemForm.Show()
    End Sub

    Private Sub updateWasteBtn_Click(sender As Object, e As EventArgs) Handles updateWasteBtn.Click
        Dim newReportWasteForm As New Inv_ReportWaste()
        newReportWasteForm.TopMost = True
        newReportWasteForm.Show()
    End Sub

    Private Sub SearchInventory(queryText As String)
        Try
            invDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT id, item_name, category, quantity, unit, minimum_stock, price, status FROM inventory WHERE is_deleted = 0"
            If queryText.Trim() <> "" Then
                query &= " AND (id LIKE @search OR item_name LIKE @search OR category LIKE @search OR status LIKE @search)"
            End If

            Using cmd As New MySqlCommand(query, conn)
                If queryText.Trim() <> "" Then cmd.Parameters.AddWithValue("@search", "%" & queryText & "%")
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim formattedId As String = CInt(dr("id")).ToString("D6")
                        invDgv.Rows.Add(formattedId, dr("item_name"), dr("category"), dr("quantity"), dr("unit"), dr("minimum_stock"), dr("price"), dr("status"))
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub searchTb_TextChanged(sender As Object, e As EventArgs) Handles searchTb.TextChanged
        SearchInventory(searchTb.Text)
    End Sub

    Private Sub FilterInventoryByStatus(statusValue As String)
        Try
            invDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Using cmd As New MySqlCommand("SELECT id, item_name, category, quantity, unit, minimum_stock, price, status FROM inventory WHERE status = @status AND is_deleted = 0", conn)
                cmd.Parameters.AddWithValue("@status", statusValue)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim formattedId As String = CInt(dr("id")).ToString("D6")
                        invDgv.Rows.Add(formattedId, dr("item_name"), dr("category"), dr("quantity"), dr("unit"), dr("minimum_stock"), dr("price"), dr("status"))
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub statusCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles statusCb.SelectedIndexChanged
        If statusCb.Text = "All" Then
            dgv_load()
        Else
            FilterInventoryByStatus(statusCb.Text)
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If invDgv.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim itemId As Integer = Convert.ToInt32(invDgv.SelectedRows(0).Cells("id").Value)

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this inventory item?" & vbCrLf & "(This action can be restored later)",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result <> DialogResult.Yes Then Exit Sub

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Soft delete
            Using deleteCmd As New MySqlCommand("UPDATE inventory SET is_deleted = 1, deleted_by = @deleted_by, deleted_at = @deleted_at WHERE id = @id", conn)
                deleteCmd.Parameters.AddWithValue("@id", itemId)
                deleteCmd.Parameters.AddWithValue("@deleted_by", Session.UserID)
                deleteCmd.Parameters.AddWithValue("@deleted_at", DateTime.Now)
                deleteCmd.ExecuteNonQuery()
            End Using

            ' Audit log
            Using logCmd As New MySqlCommand("
                INSERT INTO audit_log (entity_id, entity_type, action, details, level, deleted_by, deleted_at)
                VALUES (@entity_id, @entity_type, @action, @details, @level, @deleted_by, @deleted_at)", conn)
                logCmd.Parameters.AddWithValue("@entity_id", itemId)
                logCmd.Parameters.AddWithValue("@entity_type", "Inventory")
                logCmd.Parameters.AddWithValue("@action", "Delete")
                logCmd.Parameters.AddWithValue("@details", $"Inventory item ID {itemId.ToString("D6")} was deleted.")
                logCmd.Parameters.AddWithValue("@level", Session.UserType)
                logCmd.Parameters.AddWithValue("@deleted_by", Session.UserID)
                logCmd.Parameters.AddWithValue("@deleted_at", DateTime.Now)
                logCmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Inventory item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgv_load()

        Catch ex As Exception
            MessageBox.Show("Error deleting inventory item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub exportBtn_Click(sender As Object, e As EventArgs) Handles exportBtn.Click
        ' Make sure there are rows to export
        If invDgv.Rows.Count = 0 Then
            MessageBox.Show("No inventory data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Ask user where to save PDF
        Dim saveDlg As New SaveFileDialog()
        saveDlg.Filter = "PDF Files|*.pdf"
        saveDlg.FileName = "Inventory_Report.pdf"

        If saveDlg.ShowDialog() <> DialogResult.OK Then Return

        Try
            ' Create PDF document
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(saveDlg.FileName, FileMode.Create))
            doc.Open()

            ' Add title
            Dim title As New Paragraph("Inventory Report", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
            title.Alignment = Element.ALIGN_CENTER
            title.SpacingAfter = 10
            doc.Add(title)

            ' Create PDF table
            Dim pdfTable As New PdfPTable(invDgv.Columns.Count)
            pdfTable.WidthPercentage = 100

            ' Add headers
            For Each col As DataGridViewColumn In invDgv.Columns
                Dim cell As New PdfPCell(New Phrase(col.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                cell.BackgroundColor = BaseColor.LIGHT_GRAY
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfTable.AddCell(cell)
            Next

            ' Add data rows
            For Each row As DataGridViewRow In invDgv.Rows
                If Not row.IsNewRow Then
                    For Each cell As DataGridViewCell In row.Cells
                        pdfTable.AddCell(New Phrase(If(cell.Value Is Nothing, "", cell.Value.ToString()), FontFactory.GetFont(FontFactory.HELVETICA, 11)))
                    Next
                End If
            Next

            doc.Add(pdfTable)
            doc.Close()

            ' --- Log PDF generation in audit_log ---
            LogInventoryExportAudit(saveDlg.FileName)

            MessageBox.Show("Inventory PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error exporting PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogInventoryExportAudit(fileName As String)
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                Using cmd As New MySqlCommand(
                    "INSERT INTO audit_log 
                 (entity_id, entity_type, action, details, level, created_by, created_at)
                 VALUES (@entity_id, @entity_type, @action, @details, @level, @created_by, @created_at)", conn)

                    cmd.Parameters.AddWithValue("@entity_id", DBNull.Value)
                    cmd.Parameters.AddWithValue("@entity_type", "Inventory")
                    cmd.Parameters.AddWithValue("@action", "Export")
                    cmd.Parameters.AddWithValue("@details", $"Exported Inventory as PDF: {fileName}")
                    cmd.Parameters.AddWithValue("@level", Session.UserType)
                    cmd.Parameters.AddWithValue("@created_by", Session.UserID)
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' fail silently so it doesn't block PDF export
        End Try
    End Sub

End Class
