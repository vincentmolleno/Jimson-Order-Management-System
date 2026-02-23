Imports MySql.Data.MySqlClient

Public Class Dashboard

    Private Const PageSize As Integer = 50         ' Number of rows per page
    Private lastLogDate As DateTime? = Nothing    ' Tracks the last loaded log date
    Private lastLogTime As TimeSpan? = Nothing    ' Tracks the last loaded log time
    Private isLoading As Boolean = False          ' Prevent multiple loads at once
    Private allDataLoaded As Boolean = False      ' Stop when no more rows


    Private Sub Dashboard_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            dgv_load()
            LoadTotalRevenue()
            LoadPendingOrders()
        End If
    End Sub

    Private Sub LoadTotalRevenue()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                Dim query As String = "SELECT SUM(total_cost) FROM `order` WHERE `is_deleted` = 0"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    revenueLbl.Text = If(IsDBNull(result), "₱0.00", "₱" & Format(Convert.ToDecimal(result), "N2"))
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading total revenue: " & ex.Message)
        End Try
    End Sub

    Private Sub dgv_load(Optional reset As Boolean = False)
        If isLoading Or allDataLoaded Then Return

        If reset Then
            dashboardLogDgv.Rows.Clear()
            lastLogDate = Nothing
            lastLogTime = Nothing
            allDataLoaded = False
        End If

        isLoading = True
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                Dim query As String = "
                SELECT log_date, log_time, user_id, action, details
                FROM audit_log
                /**WHERE_CLAUSE**/
                ORDER BY log_date DESC, log_time DESC
                LIMIT @PageSize"

                ' Keyset pagination: load rows after the last fetched
                Dim whereClause As String = ""
                If lastLogDate.HasValue AndAlso lastLogTime.HasValue Then
                    whereClause = "WHERE (log_date < @LastLogDate) OR (log_date = @LastLogDate AND log_time < @LastLogTime)"
                End If
                query = query.Replace("/**WHERE_CLAUSE**/", whereClause)

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@PageSize", PageSize)
                    If lastLogDate.HasValue AndAlso lastLogTime.HasValue Then
                        cmd.Parameters.AddWithValue("@LastLogDate", lastLogDate.Value)
                        cmd.Parameters.AddWithValue("@LastLogTime", lastLogTime.Value)
                    End If

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        Dim rowsLoaded As Integer = 0
                        While dr.Read()
                            Dim logDate As DateTime = If(IsDBNull(dr("log_date")), DateTime.MinValue, dr("log_date"))
                            Dim logTime As TimeSpan = If(IsDBNull(dr("log_time")), TimeSpan.Zero, dr("log_time"))
                            Dim userId As String = If(IsDBNull(dr("user_id")), "000000", CInt(dr("user_id")).ToString("D6"))
                            Dim action As String = If(IsDBNull(dr("action")), "", dr("action").ToString())
                            Dim details As String = If(IsDBNull(dr("details")), "", dr("details").ToString())

                            dashboardLogDgv.Rows.Add(logDate.ToString("yyyy-MM-dd"), userId, action, details)

                            lastLogDate = logDate
                            lastLogTime = logTime
                            rowsLoaded += 1
                        End While

                        ' No more rows left
                        If rowsLoaded < PageSize Then allDataLoaded = True
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading audit logs: " & ex.Message)
        Finally
            isLoading = False
        End Try
    End Sub


    Private Sub LoadPendingOrders()
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()

                Dim query As String = "SELECT COUNT(*) FROM `order` WHERE `status` = 'Pending' AND `is_deleted` = 0"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    pendingOrdersLbl.Text = Convert.ToInt32(result).ToString()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading pending orders: " & ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_load()
        LoadTotalRevenue()
        LoadPendingOrders()
        EnableDoubleBuffering(dashboardLogDgv)
    End Sub

    Private Sub visitLogs_Click(sender As Object, e As EventArgs) Handles visitLogs.Click
        Admin.loggingBtn.PerformClick()
    End Sub

    Public Sub EnableDoubleBuffering(dgv As DataGridView)
        Dim dgvType As Type = dgv.GetType()
        Dim pi As System.Reflection.PropertyInfo = dgvType.GetProperty("DoubleBuffered",
        System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        pi.SetValue(dgv, True, Nothing)
    End Sub


End Class
