Imports MySql.Data.MySqlClient

Public Class Rep_Top_Wasted_Items_Analysis_Report
    Dim conn As New MySqlConnection(modDB.strConnection)

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadTopWastedItems()
    End Sub

    Private Sub Rep_Top_Wasted_Items_Analysis_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTopWastedItems()
    End Sub

    Public Sub LoadTopWastedItems()
        Try
            topWastedItemsDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT id, item, category, COUNT(*) AS incidents, SUM(total_cost) AS total_cost " &
                "FROM wastage " &
                "WHERE is_deleted = 0 " &
                "GROUP BY item, category " &
                "ORDER BY total_cost DESC " &
                "LIMIT 50"

            Using cmd As New MySqlCommand(query, conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        topWastedItemsDgv.Rows.Add(
                            Convert.ToInt32(dr("id")),          ' ID
                            dr("item").ToString(),
                            dr("category").ToString(),
                            Convert.ToInt32(dr("incidents")),
                            Convert.ToDecimal(dr("total_cost")).ToString("F2")
                        )
                    End While
                End Using
            End Using

            topWastedItemsDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Catch ex As Exception
            MsgBox("Error loading top wasted items: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            topWastedItemsDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT id, item, category, COUNT(*) AS incidents, SUM(total_cost) AS total_cost " &
                "FROM wastage " &
                "WHERE is_deleted = 0 "

            Select Case filter
                Case "Today"
                    query &= " AND DATE(created_at) = CURDATE() "
                Case "Last 7 days"
                    query &= " AND created_at >= NOW() - INTERVAL 7 DAY "
                Case "Last 30 days"
                    query &= " AND created_at >= NOW() - INTERVAL 30 DAY "
                Case Else
                    ' Alltime: no extra clause
            End Select

            query &= " GROUP BY item, category ORDER BY total_cost DESC LIMIT 50"

            Using cmd As New MySqlCommand(query, conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        topWastedItemsDgv.Rows.Add(
                            Convert.ToInt32(dr("id")),
                            dr("item").ToString(),
                            dr("category").ToString(),
                            Convert.ToInt32(dr("incidents")),
                            Convert.ToDecimal(dr("total_cost")).ToString("F2")
                        )
                    End While
                End Using
            End Using

            topWastedItemsDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Context menu edit/delete logic remains unchanged
    ' ------------------------
    ' ... (editToolStripMenuItem_Click, deleteToolStripMenuItem_Click, MouseDown, LogAudit)
    ' ------------------------

    ' Filter options
    Public ReadOnly Property Filters As String()
        Get
            Return New String() {"Alltime", "Today", "Last 7 days", "Last 30 days"}
        End Get
    End Property
End Class
