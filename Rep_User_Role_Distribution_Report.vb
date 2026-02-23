Imports MySql.Data.MySqlClient

Public Class Rep_User_Role_Distribution_Report
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadUserRoleReport()
    End Sub

    Private Sub Rep_User_Role_Distribution_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserRoleReport()
    End Sub

    Public Sub LoadUserRoleReport()
        Try
            userRoleReportDgv.Rows.Clear()

            If conn.State = ConnectionState.Closed Then conn.Open()

            ' Base query with LIMIT
            Dim query As String =
                "SELECT type AS 'Type', " &
                "COUNT(*) AS 'UserCount', " &
                "ROUND(100 * COUNT(*) / (SELECT COUNT(*) FROM `users`), 2) AS 'Percentage' " &
                "FROM `users` " &
                "GROUP BY type " &
                "ORDER BY COUNT(*) DESC " &
                "LIMIT 50"

            Using cmd As New MySqlCommand(query, conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        userRoleReportDgv.Rows.Add(
                            dr("Type").ToString(),
                            dr("UserCount"),
                            dr("Percentage").ToString() & " %"
                        )
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading user role report: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            userRoleReportDgv.Rows.Clear()

            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT type AS 'Type', " &
                "COUNT(*) AS 'UserCount', " &
                "ROUND(100 * COUNT(*) / (SELECT COUNT(*) FROM `users`), 2) AS 'Percentage' " &
                "FROM `users` "

            ' Apply filter
            Select Case filter
                Case "Exclude admins"
                    query &= "WHERE type <> 'Admin' "
                Case "Staff only"
                    query &= "WHERE type = 'Staff' "
                Case "Cashier only"
                    query &= "WHERE type = 'Cashier' "
                Case Else
                    ' All users: no WHERE clause
            End Select

            query &= "GROUP BY type ORDER BY COUNT(*) DESC LIMIT 50"

            Using cmd As New MySqlCommand(query, conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        userRoleReportDgv.Rows.Add(
                            dr("Type").ToString(),
                            dr("UserCount"),
                            dr("Percentage").ToString() & " %"
                        )
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Filter options
    Public ReadOnly Property Filters As String()
        Get
            Return New String() {"All users", "Exclude admins", "Staff only", "Cashier only"}
        End Get
    End Property
End Class
