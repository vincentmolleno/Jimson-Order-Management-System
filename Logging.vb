Imports MySql.Data.MySqlClient

Public Class Logging
    Dim conn As New MySqlConnection(modDB.strConnection)
    Private Const MaxRows As Integer = 50 ' default row limit

    Private Sub Logging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_load()
        SetDefaultIndex(0, levelsCb)
    End Sub

    Private Sub Logging_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then dgv_load()
    End Sub

    ' --- Load logs with optional limit and search/filter ---
    Private Sub dgv_load(Optional searchText As String = "", Optional levelFilter As String = "", Optional limit As Integer = MaxRows)
        Try
            logDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
                SELECT log_id, log_date, log_time, user_id, action, details, level, entity_id, entity_type
                FROM audit_log
                WHERE 1=1"

            ' Apply level filter if provided
            If Not String.IsNullOrWhiteSpace(levelFilter) Then
                query &= " AND level = @level"
            End If

            ' Apply search if provided
            If Not String.IsNullOrWhiteSpace(searchText) Then
                query &= " AND (log_id LIKE @search OR user_id LIKE @search OR action LIKE @search OR details LIKE @search OR level LIKE @search OR entity_id LIKE @search OR entity_type LIKE @search)"
            End If

            query &= " ORDER BY log_date DESC, log_time DESC"

            ' Apply limit
            If limit > 0 Then
                query &= $" LIMIT {limit}"
            End If

            Using cmd As New MySqlCommand(query, conn)
                If Not String.IsNullOrWhiteSpace(levelFilter) Then
                    cmd.Parameters.AddWithValue("@level", levelFilter)
                End If
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                End If

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim formattedLogId As String = If(IsDBNull(dr("log_id")), "000000", CInt(dr("log_id")).ToString("D6"))
                        Dim formattedUserId As String = If(IsDBNull(dr("user_id")), "000000", CInt(dr("user_id")).ToString("D6"))

                        logDgv.Rows.Add(
                            formattedLogId,
                            dr("log_date"),
                            dr("log_time"),
                            formattedUserId,
                            If(IsDBNull(dr("action")), "", dr("action")),
                            If(IsDBNull(dr("details")), "", dr("details")),
                            If(IsDBNull(dr("level")), "", dr("level")),
                            If(IsDBNull(dr("entity_id")), "", dr("entity_id")),
                            If(IsDBNull(dr("entity_type")), "", dr("entity_type"))
                        )
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' --- Search logs ---
    Private Sub SearchLogs(queryText As String)
        dgv_load(searchText:=queryText)
    End Sub

    ' --- Filter logs by level ---
    Private Sub FilterLogsByLevel(levelValue As String)
        If levelValue = "All Levels" Then
            dgv_load()
        Else
            dgv_load(levelFilter:=levelValue)
        End If
    End Sub

    ' --- ComboBox helper ---
    Private Sub SetDefaultIndex(index As Integer, ParamArray combos() As ComboBox)
        For Each cb As ComboBox In combos
            cb.SelectedIndex = index
        Next
    End Sub

    Private Sub searchTb_TextChanged(sender As Object, e As EventArgs) Handles searchTb.TextChanged
        SearchLogs(searchTb.Text)
    End Sub

    Private Sub levelsCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles levelsCb.SelectedIndexChanged
        FilterLogsByLevel(levelsCb.Text)
    End Sub

    ' --- Open Notes form ---
    Private Sub NotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotesToolStripMenuItem.Click
        If logDgv.SelectedRows.Count = 0 Then
            MsgBox("Please select a log first.")
            Exit Sub
        End If

        Dim selectedLogId As String = logDgv.SelectedRows(0).Cells("LogID").Value.ToString()
        Dim noteForm As New Log_Notes()
        noteForm.Tag = selectedLogId
        noteForm.ShowDialog()
    End Sub
End Class
