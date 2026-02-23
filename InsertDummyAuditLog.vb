Imports MySql.Data.MySqlClient

Module InsertDummyAuditLog

    Sub Main()
        Dim connStr As New MySqlConnection(modDB.strConnection)
        Dim rand As New Random()
        Dim actions As String() = {"Login", "Logout", "Delete", "Permanent Delete", "Restore"}
        Dim levels As String() = {"Admin", "Staff", "User"}
        Dim entityTypes As String() = {"Inventory", "Order", "User", "Payment", "Audit"}

        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Using cmd As New MySqlCommand()
                cmd.Connection = conn

                For i As Integer = 1 To 1000
                    Dim action As String = actions(rand.Next(actions.Length))
                    Dim level As String = levels(rand.Next(levels.Length))
                    Dim entityType As String = entityTypes(rand.Next(entityTypes.Length))
                    Dim userId As Integer = rand.Next(1, 20) ' Random user ID 1-19
                    Dim entityId As Integer = rand.Next(1, 50) ' Random entity ID 1-49
                    Dim deletedBy As Object = If(action.ToLower().Contains("delete"), rand.Next(1, 20), CType(Nothing, Object))
                    Dim deletedAt As Object = If(deletedBy IsNot Nothing, DateTime.Now.AddMinutes(-rand.Next(0, 10000)), CType(Nothing, Object))
                    Dim createdBy As Integer = rand.Next(1, 20)
                    Dim createdAt As DateTime = DateTime.Now.AddMinutes(-rand.Next(0, 10000))

                    cmd.CommandText = "INSERT INTO audit_log (log_date, log_time, user_id, action, details, level, entity_id, entity_type, deleted_by, deleted_at, created_by, created_at) " &
                                      "VALUES (@log_date, @log_time, @user_id, @action, @details, @level, @entity_id, @entity_type, @deleted_by, @deleted_at, @created_by, @created_at)"

                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@log_date", createdAt.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@log_time", createdAt.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@user_id", userId)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@details", action & " action performed on entity #" & entityId)
                    cmd.Parameters.AddWithValue("@level", level)
                    cmd.Parameters.AddWithValue("@entity_id", entityId)
                    cmd.Parameters.AddWithValue("@entity_type", entityType)
                    cmd.Parameters.AddWithValue("@deleted_by", If(deletedBy Is Nothing, DBNull.Value, deletedBy))
                    cmd.Parameters.AddWithValue("@deleted_at", If(deletedAt Is Nothing, DBNull.Value, deletedAt))
                    cmd.Parameters.AddWithValue("@created_by", createdBy)
                    cmd.Parameters.AddWithValue("@created_at", createdAt)

                    cmd.ExecuteNonQuery()
                Next

                Console.WriteLine("Inserted 1,000 dummy audit_log rows successfully!")
            End Using
        End Using

        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()
    End Sub

End Module
