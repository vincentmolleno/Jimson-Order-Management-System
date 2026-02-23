Imports MySql.Data.MySqlClient

Public Class Rep_Recent_Wastage_Summary_Report

    Dim conn As New MySqlConnection(modDB.strConnection)
    Private Const PageSize As Integer = 50 ' Limit rows loaded

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadRecentWastageSummary()
    End Sub

    Private Sub Rep_Recent_Wastage_Summary_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRecentWastageSummary()
        recentWastageSummaryDgv.ContextMenuStrip = cmsWastage
    End Sub

    Sub LoadRecentWastageSummary()
        ApplyFilter("Alltime")
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            recentWastageSummaryDgv.Rows.Clear()

            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Base query
            Dim query As String =
            "SELECT w.id, w.created_at, w.item, w.quantity, w.reason, " &
            "CONCAT(u.first_name, ' ', u.last_name) AS reported_by_name, " &
            "w.total_cost " &
            "FROM wastage w " &
            "LEFT JOIN users u ON u.id = w.reported_by " &
            "WHERE w.is_deleted = 0 "

            ' Apply filter
            Select Case filter
                Case "Today"
                    query &= " AND DATE(w.created_at) = CURDATE() "
                Case "Last 7 days"
                    query &= " AND w.created_at >= NOW() - INTERVAL 7 DAY "
                Case "Last 30 days"
                    query &= " AND w.created_at >= NOW() - INTERVAL 30 DAY "
                Case "Alltime"
                    ' no extra WHERE clause
            End Select

            ' Add row limit
            query &= " ORDER BY w.created_at DESC LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        recentWastageSummaryDgv.Rows.Add(
                             dr("id"), ' hidden ID
                             Convert.ToDateTime(dr("created_at")).ToString("yyyy-MM-dd"),
                             dr("item").ToString(),
                             dr("quantity"),
                             dr("reason").ToString(),
                             dr("reported_by_name").ToString(),
                             Convert.ToDecimal(dr("total_cost")).ToString("F2")
                         )
                    End While
                End Using
            End Using

            recentWastageSummaryDgv.Columns(0).Visible = False
            recentWastageSummaryDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            recentWastageSummaryDgv.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Filters for combo box
    Public ReadOnly Property Filters As String()
        Get
            Return New String() {"Alltime", "Today", "Last 7 days", "Last 30 days"}
        End Get
    End Property

End Class
