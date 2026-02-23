Imports MySql.Data.MySqlClient

Public Class Rep_Order_Trends_Report
    Dim conn As New MySqlConnection(modDB.strConnection)
    Dim dr As MySqlDataReader
    Private Const PageSize As Integer = 50  ' Maximum number of rows to load

    Private Sub Me_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then LoadOrderTrendsReport()
    End Sub

    Sub LoadOrderTrendsReport()
        ApplyFilter("Monthly") ' default
    End Sub

    Private Sub Rep_Order_Trends_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrderTrendsReport()
    End Sub

    Public Sub ApplyFilter(filter As String)
        Try
            orderTrendsDgv.Rows.Clear()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim groupByClause As String
            Dim periodFormat As String

            Select Case filter
                Case "Daily"
                    groupByClause = "DATE(order_date)"
                    periodFormat = "%Y-%m-%d"
                Case "Monthly"
                    groupByClause = "DATE_FORMAT(order_date, '%Y-%m')"
                    periodFormat = "%Y-%m"
                Case "Yearly"
                    groupByClause = "DATE_FORMAT(order_date, '%Y')"
                    periodFormat = "%Y"
                Case Else
                    groupByClause = "DATE_FORMAT(order_date, '%Y-%m')"
                    periodFormat = "%Y-%m"
            End Select

            Dim query As String =
            $"SELECT DATE_FORMAT(order_date, '{periodFormat}') AS period, " &
            "COUNT(*) AS order_count, SUM(total_cost) AS total_revenue " &
            "FROM `order` " &
            "WHERE is_deleted = 0 " &
            $"GROUP BY {groupByClause} " &
            "ORDER BY period DESC " &
            "LIMIT @PageSize"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PageSize", PageSize)

                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        Dim period As String = dr("period").ToString()
                        Dim count As Integer = Convert.ToInt32(dr("order_count"))
                        Dim revenue As Decimal = Convert.ToDecimal(dr("total_revenue"))

                        orderTrendsDgv.Rows.Add(period, count, revenue.ToString("F2"))
                    End While
                End Using
            End Using

            orderTrendsDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception
            MsgBox("Error applying filter: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Filters for ComboBox
    Public ReadOnly Property Filters As String()
        Get
            Return New String() {"Daily", "Monthly", "Yearly"}
        End Get
    End Property

End Class
