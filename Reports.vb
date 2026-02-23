Imports System.IO
Imports System.Net.Mime.MediaTypeNames
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient

Public Class Reports


    Public Sub LimitToStaffReports()
        reportTypeCombo.Items.Clear()
        reportTypeCombo.Items.AddRange(New Object() {
            "Low Stock Alert Report",
            "Recent Wastage Summary Report",
            "Top Wasted Items Analysis Report"
        })
        reportTypeCombo.SelectedIndex = 0
    End Sub

    Public Sub LimitToCashierReports()
        reportTypeCombo.Items.Clear()
        reportTypeCombo.Items.AddRange(New Object() {
            "Order Status Report",
            "Order Trends Report",
            "Recent Order Summary Report",
            "Top Revenue Orders Report"
        })
        reportTypeCombo.SelectedIndex = 0
    End Sub



    'combobox default selected index helper
    Private Sub SetDefaultIndex(index As Integer, ParamArray combos() As ComboBox)
        For Each cb As ComboBox In combos
            cb.SelectedIndex = index
        Next
    End Sub

    'comboBoxes to be set default and set tags for combo
    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        reportTypeCombo.SelectedIndex = 0
        filterCombo.SelectedIndex = 0

        ' Map report names to forms
        reportTypeCombo.Tag = New Dictionary(Of String, Form) From {
        {"User Status Summary Report", New Rep_User_Status_Summary_Report()},
        {"User Role Distribution Report", New Rep_User_Role_Distribution_Report()},
        {"Low Stock Alert Report", New Rep_Low_Stock_Alert_Report()},
        {"Top Revenue Orders Report", New Rep_Top_Revenue_Orders_Report()},
        {"Order Status Report", New Rep_Order_Status_Report()},
        {"Order Trends Report", New Rep_Order_Trends_Report()},
        {"Recent Order Summary Report", New Rep_Recent_Order_Summary_Report()},
        {"Recent Wastage Summary Report", New Rep_Recent_Wastage_Summary_Report()},
        {"Top Wasted Items Analysis Report", New Rep_Top_Wasted_Items_Analysis_Report()}
    }

        ' Load default report
        Dim map = DirectCast(reportTypeCombo.Tag, Dictionary(Of String, Form))
        grandchildform(map(reportTypeCombo.SelectedItem.ToString()))

    End Sub

    Private Sub filterCombo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles filterCombo.SelectionChangeCommitted
        ' Get the currently displayed report form
        If rep_displayPnl.Controls.Count > 0 Then
            Dim currentForm As Form = rep_displayPnl.Controls(0)
            ' Check if it has ApplyFilter method
            Dim method = currentForm.GetType().GetMethod("ApplyFilter")
            If method IsNot Nothing Then
                method.Invoke(currentForm, New Object() {filterCombo.SelectedItem.ToString()})
            End If
        End If
    End Sub

    Private Sub reportTypeCombo_SelectionChangeCommitted(sender As Object, e As EventArgs) _
    Handles reportTypeCombo.SelectionChangeCommitted

        Dim map = DirectCast(reportTypeCombo.Tag, Dictionary(Of String, Form))
        grandchildform(map(reportTypeCombo.SelectedItem.ToString()))
    End Sub

    ' childform of report
    Sub grandchildform(ByVal panel As Form)
        rep_displayPnl.Controls.Clear()

        panel.TopLevel = False
        panel.FormBorderStyle = FormBorderStyle.None
        panel.Dock = DockStyle.Fill

        rep_displayPnl.Controls.Add(panel)
        panel.Show()

        ' --- New code to update filterCombo ---
        ' Check if the panel has a "Filters" property
        Dim filtersProp = panel.GetType().GetProperty("Filters")
        If filtersProp IsNot Nothing Then
            Dim options As String() = DirectCast(filtersProp.GetValue(panel), String())
            filterCombo.Items.Clear()
            filterCombo.Items.AddRange(options)
            filterCombo.SelectedIndex = 0 ' optional: select first by default
        Else
            ' fallback if no filters defined
            filterCombo.Items.Clear()
            filterCombo.Items.Add("No filters available")
            filterCombo.SelectedIndex = 0
        End If
    End Sub

    Private Sub generateReportBtn_Click(sender As Object, e As EventArgs) Handles generateReportBtn.Click
        ' Make sure there is a report loaded
        If rep_displayPnl.Controls.Count = 0 Then
            MsgBox("No report loaded to generate PDF.")
            Return
        End If

        Dim currentForm As Form = rep_displayPnl.Controls(0)

        ' Try to find a DataGridView in the current form
        Dim dgv As DataGridView = Nothing
        For Each ctrl As Control In currentForm.Controls
            If TypeOf ctrl Is DataGridView Then
                dgv = DirectCast(ctrl, DataGridView)
                Exit For
            End If
        Next

        If dgv Is Nothing Then
            MsgBox("No DataGridView found in the current report.")
            Return
        End If

        ' Ask user where to save PDF
        Dim saveDlg As New SaveFileDialog()
        saveDlg.Filter = "PDF Files|*.pdf"
        saveDlg.FileName = reportTypeCombo.SelectedItem.ToString() & ".pdf"

        If saveDlg.ShowDialog() <> DialogResult.OK Then Return

        Try
            ' Create PDF document
            Dim doc As New Document(PageSize.A4, 10, 10, 10, 10)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(saveDlg.FileName, FileMode.Create))
            doc.Open()

            ' Add title
            Dim title As New Paragraph(reportTypeCombo.SelectedItem.ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
            title.Alignment = Element.ALIGN_CENTER
            title.SpacingAfter = 10
            doc.Add(title)

            ' Create PDF table
            Dim pdfTable As New PdfPTable(dgv.Columns.Count)
            pdfTable.WidthPercentage = 100

            ' Add headers
            For Each col As DataGridViewColumn In dgv.Columns
                Dim cell As New PdfPCell(New Phrase(col.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                cell.BackgroundColor = BaseColor.LIGHT_GRAY
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                pdfTable.AddCell(cell)
            Next

            ' Add data rows
            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    For Each cell As DataGridViewCell In row.Cells
                        pdfTable.AddCell(New Phrase(If(cell.Value Is Nothing, "", cell.Value.ToString()), FontFactory.GetFont(FontFactory.HELVETICA, 11)))
                    Next
                End If
            Next

            doc.Add(pdfTable)
            doc.Close()

            ' --- Log report generation ---
            LogReportAudit(reportTypeCombo.SelectedItem.ToString(), filterCombo.SelectedItem.ToString())

            MsgBox("PDF generated successfully!")
        Catch ex As Exception
            MsgBox("Error generating PDF: " & ex.Message)
        End Try
    End Sub

    Private Sub LogReportAudit(reportName As String, filterUsed As String)
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                Using cmd As New MySqlCommand(
                "INSERT INTO audit_log 
                 (entity_id, entity_type, action, details, level, created_by, created_at)
                 VALUES (@entity_id, @entity_type, @action, @details, @level, @created_by, @created_at)", conn)

                    cmd.Parameters.AddWithValue("@entity_id", DBNull.Value) ' reports don't have an entity_id
                    cmd.Parameters.AddWithValue("@entity_type", "Report")
                    cmd.Parameters.AddWithValue("@action", "Generate")
                    cmd.Parameters.AddWithValue("@details", $"Generated {reportName} (Filter: {filterUsed}) as PDF")
                    cmd.Parameters.AddWithValue("@level", Session.UserType)
                    cmd.Parameters.AddWithValue("@created_by", Session.UserID)
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' fail silently so it doesn't block PDF generation
        End Try
    End Sub

End Class