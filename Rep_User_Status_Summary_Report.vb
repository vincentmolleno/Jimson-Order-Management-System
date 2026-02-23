Imports MySql.Data.MySqlClient

Public Class Rep_User_Status_Summary_Report
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader
    Private Const MaxRows As Integer = 100  ' Limit rows for performance

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadUserStatusSummary()
    End Sub

    Private Sub Rep_User_Status_Summary_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserStatusSummary()
    End Sub

    Public Sub LoadUserStatusSummary()
        Try
            usrStatSumRepDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String =
                "SELECT first_name, last_name, phone_number, email, type, last_active " &
                "FROM users " &
                "ORDER BY last_active DESC " &
                $"LIMIT {MaxRows}"

            Using cmd As New MySqlCommand(query, conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim fullName As String = dr("first_name").ToString() & " " & dr("last_name").ToString()
                        usrStatSumRepDgv.Rows.Add(
                            fullName,
                            dr("phone_number").ToString(),
                            dr("email").ToString(),
                            dr("type").ToString(),
                            If(IsDBNull(dr("last_active")), "", dr("last_active").ToString())
                        )
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading User Status Summary: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            usrStatSumRepDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "SELECT first_name, last_name, phone_number, email, type, last_active FROM users "

            Select Case filter
                Case "Last active 24 hours"
                    query &= "WHERE last_active >= NOW() - INTERVAL 1 DAY "
                Case "Last active 7 days"
                    query &= "WHERE last_active >= NOW() - INTERVAL 7 DAY "
                Case "Last active 30 days"
                    query &= "WHERE last_active >= NOW() - INTERVAL 30 DAY "
                Case Else
                    ' All users, no extra WHERE
            End Select

            query &= "ORDER BY last_active DESC " &
                     $"LIMIT {MaxRows}"

            Using cmd As New MySqlCommand(query, conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim fullName As String = dr("first_name").ToString() & " " & dr("last_name").ToString()
                        usrStatSumRepDgv.Rows.Add(
                            fullName,
                            dr("phone_number").ToString(),
                            dr("email").ToString(),
                            dr("type").ToString(),
                            If(IsDBNull(dr("last_active")), "", dr("last_active").ToString())
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

    Public ReadOnly Property Filters As String()
        Get
            Return New String() {
                "All",
                "Last active 24 hours",
                "Last active 7 days",
                "Last active 30 days"
            }
        End Get
    End Property
End Class
