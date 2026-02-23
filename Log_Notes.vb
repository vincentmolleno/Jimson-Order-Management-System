Imports MySql.Data.MySqlClient

Public Class Log_Notes

    Private Sub Log_Notes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check if Tag has log_id
        If Me.Tag Is Nothing Then Exit Sub
        Dim logId As String = Me.Tag.ToString()

        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT notes FROM audit_log WHERE log_id=@id", conn)
                    cmd.Parameters.AddWithValue("@id", logId)
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso result.ToString() <> "" Then
                        ' Note exists → readonly until clicked
                        notesTb.Text = result.ToString()
                        notesTb.ReadOnly = True
                        Button1.Text = "Edit Note"
                        Button1.Visible = False
                    Else
                        ' No note → editable immediately
                        notesTb.Text = ""
                        notesTb.ReadOnly = False
                        Button1.Text = "Add Note"
                        Button1.Visible = True
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading note: " & ex.Message)
        End Try
    End Sub

    Private Sub notesTb_Click(sender As Object, e As EventArgs) Handles notesTb.Click
        ' If currently readonly, allow editing
        If notesTb.ReadOnly Then
            notesTb.ReadOnly = False
            Button1.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Tag Is Nothing Then Exit Sub
        Dim logId As String = Me.Tag.ToString()

        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE audit_log SET notes=@notes WHERE log_id=@id", conn)
                    cmd.Parameters.AddWithValue("@notes", notesTb.Text)
                    cmd.Parameters.AddWithValue("@id", logId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("Note saved successfully!")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error saving note: " & ex.Message)
        End Try
    End Sub

End Class
