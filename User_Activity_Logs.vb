Imports MySql.Data.MySqlClient

Public Class User_Activity_Logs
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader

    Private Const PageSize As Integer = 50       ' Rows per page
    Private lastLogId As Integer? = Nothing     ' Keyset pagination: track last loaded log ID
    Private isLoading As Boolean = False        ' Prevent multiple loads at once
    Private allDataLoaded As Boolean = False    ' Stop loading if no more rows
    Private currentUserId As Integer


    Public Sub LoadUserLogs(userId As Integer)
        currentUserId = userId ' store for pagination
        lastLogId = Nothing
        allDataLoaded = False

        ' Load first page
        dgv_load(userId, reset:=True)
    End Sub


    Private Sub dgv_load(userId As Integer, Optional reset As Boolean = False)
        If isLoading Or allDataLoaded Then Return

        If reset Then
            DataGridView1.Rows.Clear()
            lastLogId = Nothing
            allDataLoaded = False
        End If

        isLoading = True
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
            SELECT id, CONCAT(log_date, ' ', log_time) AS timestamp, action, details
            FROM audit_log
            WHERE user_id = @userId /**WHERE_CLAUSE**/
            ORDER BY id ASC
            LIMIT @PageSize"

            ' Keyset pagination: load logs with id > lastLogId
            Dim whereClause As String = ""
            If lastLogId.HasValue Then
                whereClause = "AND id > @LastLogId"
            End If
            query = query.Replace("/**WHERE_CLAUSE**/", whereClause)

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", userId)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)
                If lastLogId.HasValue Then cmd.Parameters.AddWithValue("@LastLogId", lastLogId.Value)

                Using dr = cmd.ExecuteReader()
                    Dim rowsLoaded As Integer = 0
                    While dr.Read()
                        Dim timestamp As String = If(IsDBNull(dr("timestamp")), "", dr("timestamp").ToString())
                        Dim action As String = If(IsDBNull(dr("action")), "", dr("action").ToString())
                        Dim details As String = If(IsDBNull(dr("details")), "", dr("details").ToString())

                        DataGridView1.Rows.Add(timestamp, action, details)

                        lastLogId = Convert.ToInt32(dr("id"))
                        rowsLoaded += 1
                    End While

                    If rowsLoaded < PageSize Then allDataLoaded = True
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading logs: " & ex.Message)
        Finally
            isLoading = False
            conn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_Scroll(sender As Object, e As ScrollEventArgs) Handles DataGridView1.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            If DataGridView1.Rows.Count > 0 AndAlso
           DataGridView1.FirstDisplayedScrollingRowIndex + DataGridView1.DisplayedRowCount(False) >= DataGridView1.Rows.Count Then
                ' Load next page
                dgv_load(currentUserId)
            End If
        End If
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class