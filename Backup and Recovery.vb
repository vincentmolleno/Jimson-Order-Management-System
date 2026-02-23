Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class Backup_and_Recovery
    Private backupFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Backups")

    ' --- Manual Backup ---
    Private Sub createBackupButton_Click(sender As Object, e As EventArgs) Handles createBackupButton.Click
        Try
            ' Ensure backup folder exists
            If Not Directory.Exists(backupFolder) Then Directory.CreateDirectory(backupFolder)

            ' Save backup file
            Dim saveFileDialog As New SaveFileDialog() With {
                .Filter = "SQL Files|*.sql",
                .Title = "Save Backup File",
                .FileName = "SystemBackup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".sql",
                .InitialDirectory = backupFolder
            }

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim backupFile As String = saveFileDialog.FileName

                ' Run mysqldump
                Dim psi As New ProcessStartInfo() With {
                    .FileName = "cmd.exe",
                    .RedirectStandardInput = True,
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }

                Dim process As Process = Process.Start(psi)
                Using sw As StreamWriter = process.StandardInput
                    sw.WriteLine($"mysqldump -u root -p your_database_name > ""{backupFile}""")
                    sw.WriteLine("exit")
                End Using
                process.WaitForExit()

                MessageBox.Show("Backup created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' --- Audit log ---
                LogAudit("CREATE BACKUP", $"Created backup: {Path.GetFileName(backupFile)}", "INFO")
            End If

        Catch ex As Exception
            MessageBox.Show("Error creating backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogAudit("CREATE BACKUP FAILED", ex.Message, "ERROR")
        End Try
    End Sub

    ' --- Restore Backup ---
    Private Sub restoreBackupButton_Click(sender As Object, e As EventArgs) Handles restoreBackupButton.Click
        Try
            ' Ensure folder exists
            If Not Directory.Exists(backupFolder) Then Directory.CreateDirectory(backupFolder)

            Dim openFileDialog As New OpenFileDialog() With {
                .Filter = "SQL Files|*.sql",
                .Title = "Select Backup File",
                .InitialDirectory = backupFolder
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim restoreFile As String = openFileDialog.FileName

                ' Run mysql restore
                Dim psi As New ProcessStartInfo() With {
                    .FileName = "cmd.exe",
                    .RedirectStandardInput = True,
                    .UseShellExecute = False,
                    .CreateNoWindow = True
                }

                Dim process As Process = Process.Start(psi)
                Using sw As StreamWriter = process.StandardInput
                    sw.WriteLine($"mysql -u root -p your_database_name < ""{restoreFile}""")
                    sw.WriteLine("exit")
                End Using
                process.WaitForExit()

                MessageBox.Show("Backup restored successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' --- Audit log ---
                LogAudit("RESTORE BACKUP", $"Restored backup: {Path.GetFileName(restoreFile)}", "INFO")
            End If

        Catch ex As Exception
            MessageBox.Show("Error restoring backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogAudit("RESTORE BACKUP FAILED", ex.Message, "ERROR")
        End Try
    End Sub

    ' --- Helper: Log Audit ---
    Private Sub LogAudit(action As String, details As String, level As String)
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "INSERT INTO audit_log (user_id, action, details, level) 
                     VALUES (@user_id, @action, @details, @level)", conn)
                    cmd.Parameters.AddWithValue("@user_id", Session.UserID)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@details", details)
                    cmd.Parameters.AddWithValue("@level", level)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' Silent fail to prevent logging errors from breaking backup/restore
        End Try
    End Sub

End Class
