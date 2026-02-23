Imports MySql.Data.MySqlClient

Module modDatabaseInit

    ' ================= CONFIG =================
    Public dbName As String = "jimsondb"

    Private ReadOnly RequiredTables As String() = {
        "users",
        "inventory",
        "`order`",
        "audit_log",
        "wastage"
    }

    ' ================= PUBLIC ENTRY =================
    Public Sub EnsureDatabaseReady()
        ' Try connecting to MySQL server
        If Not CanConnectToServer() Then
            MsgBox("Cannot connect to MySQL server. Please check server credentials.", MsgBoxStyle.Critical, "Database Error")
            Application.Exit()
            Exit Sub
        End If

        ' 1️⃣ Ensure database exists
        Dim dbAlreadyExists As Boolean = EnsureDatabaseExists(dbName)

        ' Exit early if database already exists, no spam
        If dbAlreadyExists Then
            ' Database exists, no need for initialization message
            Exit Sub
        End If

        ' Only reaches here if database was just created
        MsgBox("Database '" & dbName & "' did not exist and has been created.", MsgBoxStyle.Information, "Database Initialization")

        ' 2️⃣ Connect to the actual database and initialize tables/admin
        Using conn As New MySqlConnection(modDB.strConnection)
            conn.Open()
            Dim adminCreated As Boolean = False
            Dim tablesCreated As Boolean = False
            Dim defaultUsername As String = "admin"
            Dim defaultPassword As String = "admin"

            ' Create tables if missing
            If Not TablesExist(conn) Then
                CreateAllTables(conn)
                tablesCreated = True
            End If

            ' Create default admin if missing
            Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE type='Admin' AND is_deleted=0"
            Using checkCmd As New MySqlCommand(checkQuery, conn)
                If Convert.ToInt32(checkCmd.ExecuteScalar()) = 0 Then
                    Dim insertQuery As String =
            "INSERT INTO users (first_name,last_name,type,username,password,created_by) " &
            "VALUES ('System','Administrator','Admin',@username,@password,0)"

                    Using cmd As New MySqlCommand(insertQuery, conn)
                        cmd.Parameters.AddWithValue("@username", defaultUsername)
                        cmd.Parameters.AddWithValue("@password", modDB.Encrypt(defaultPassword))
                        cmd.ExecuteNonQuery()
                    End Using

                    AddSystemAudit("No admin found. Default admin account created.")
                    adminCreated = True
                End If
            End Using

            ' Show initialization report only if something was created
            If tablesCreated Or adminCreated Then
                Dim msg As String = "Database Initialization Report:" & vbCrLf &
                            "-----------------------------------" & vbCrLf

                If tablesCreated Then msg &= "Tables were missing and have been created." & vbCrLf
                If adminCreated Then
                    msg &= vbCrLf & "No admin account was found, so a default admin account was created." & vbCrLf &
                   "First login credentials:" & vbCrLf &
                   "Username: " & defaultUsername & vbCrLf &
                   "Password: " & defaultPassword
                End If

                MsgBox(msg, MsgBoxStyle.Information, "Database Initialization")
            End If
        End Using
    End Sub




    ' ================= SERVER CONNECTION CHECK =================
    Public Function CanConnectToServer() As Boolean
        Try
            ' Connect to server only
            Dim serverOnlyConnStr As String = $"server={modDB.db_server};uid={modDB.db_uid};password={modDB.db_pwd};"
            Using conn As New MySqlConnection(serverOnlyConnStr)
                conn.Open()
                Return True
            End Using
        Catch
            Return False
        End Try
    End Function


    ' ================= CREATE DATABASE IF MISSING =================
    ' Returns True if database already exists, False if it was just created
    Private Function EnsureDatabaseExists(databaseName As String) As Boolean
        Dim exists As Boolean = False
        ' Use server-only connection (remove database from strConnection)
        Dim serverOnlyConnStr As String = $"server={modDB.db_server};uid={modDB.db_uid};password={modDB.db_pwd};"
        Using conn As New MySqlConnection(serverOnlyConnStr)
            conn.Open()

            ' Check if database already exists
            Using checkCmd As New MySqlCommand($"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME='{databaseName}'", conn)
                exists = checkCmd.ExecuteScalar() IsNot Nothing
            End Using

            ' Create database if it doesn't exist
            If Not exists Then
                Using cmd As New MySqlCommand($"CREATE DATABASE `{databaseName}`", conn)
                    cmd.ExecuteNonQuery()
                End Using
            End If
        End Using
        Return exists
    End Function




    ' ================= TABLE CHECK =================
    Public Function TablesExist(conn As MySqlConnection) As Boolean
        For Each tbl As String In RequiredTables
            Dim q As String = "SELECT COUNT(*) FROM information_schema.tables " &
                              "WHERE table_schema = DATABASE() AND table_name = @table"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@table", tbl)
                If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then Return False
            End Using
        Next
        Return True
    End Function

    ' ================= TABLE CREATION =================
    Private Sub CreateAllTables(conn As MySqlConnection)
        Dim queries As String() = {
            GetUsersTable(),
            GetInventoryTable(),
            GetOrderTable(),
            GetAuditLogTable(),
            GetWastageTable()
        }

        For Each q As String In queries
            Using cmd As New MySqlCommand(q, conn)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    ' ================= SYSTEM AUDIT =================
    Private Sub AddSystemAudit(details As String)
        Try
            Using conn As New MySqlConnection(modDB.strConnection)
                conn.Open()
                Dim q As String =
                    "INSERT INTO audit_log " &
                    "(log_date, log_time, user_id, action, details, level, entity_type, created_by) " &
                    "VALUES (CURDATE(), CURTIME(), 0, 'System Init', @details, 'Admin', 'System', 'System')"
                Using cmd As New MySqlCommand(q, conn)
                    cmd.Parameters.AddWithValue("@details", details)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
        End Try
    End Sub

    ' ================= TABLE DEFINITIONS =================
    Private Function GetAuditLogTable() As String
        Return "CREATE TABLE IF NOT EXISTS audit_log (" &
               "log_id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY," &
               "log_date DATE NOT NULL DEFAULT (CURDATE())," &
               "log_time TIME NOT NULL DEFAULT (CURTIME())," &
               "user_id INT(255) NOT NULL," &
               "action VARCHAR(50) NOT NULL," &
               "details TEXT," &
               "level ENUM('Admin','Staff','Cashier') NOT NULL DEFAULT 'Admin'," &
               "entity_id INT UNSIGNED," &
               "entity_type VARCHAR(100)," &
               "deleted_by VARCHAR(255)," &
               "deleted_at DATETIME," &
               "restored_by VARCHAR(255)," &
               "restored_at DATETIME," &
               "created_by VARCHAR(255)," &
               "created_at DATETIME DEFAULT CURRENT_TIMESTAMP," &
               "notes TEXT" &
               ");"
    End Function

    Private Function GetInventoryTable() As String
        Return "CREATE TABLE IF NOT EXISTS inventory (" &
               "id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY," &
               "item_name VARCHAR(255) NOT NULL," &
               "category VARCHAR(100) NOT NULL," &
               "quantity INT UNSIGNED NOT NULL DEFAULT 0," &
               "unit VARCHAR(50) NOT NULL," &
               "minimum_stock INT UNSIGNED NOT NULL DEFAULT 0," &
               "price DECIMAL(10,2) NOT NULL DEFAULT 0.00," &
               "status VARCHAR(50) NOT NULL DEFAULT 'Available'," &
               "supplier VARCHAR(255)," &
               "note TEXT," &
               "is_deleted TINYINT(1) NOT NULL DEFAULT 0," &
               "deleted_by VARCHAR(255)," &
               "deleted_at DATETIME," &
               "restored_at DATETIME," &
               "restored_by VARCHAR(255)," &
               "created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," &
               "updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," &
               "created_by VARCHAR(255)," &
               "updated_by VARCHAR(255)" &
               ");"
    End Function

    Private Function GetOrderTable() As String
        Return "CREATE TABLE IF NOT EXISTS `order` (" &
               "order_no INT UNSIGNED AUTO_INCREMENT PRIMARY KEY," &
               "order_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," &
               "customer VARCHAR(255) NOT NULL," &
               "contact_details VARCHAR(255) NOT NULL," &
               "items TEXT NOT NULL," &
               "total_cost DECIMAL(10,2) NOT NULL DEFAULT 0.00," &
               "payment VARCHAR(50) NOT NULL DEFAULT 'Paid'," &
               "shipping_fee DECIMAL(10,2) NOT NULL DEFAULT 0.00," &
               "status VARCHAR(50) NOT NULL DEFAULT 'Pending'," &
               "shipping_address TEXT," &
               "notes TEXT," &
               "is_deleted TINYINT(1) NOT NULL DEFAULT 0," &
               "deleted_by INT(11)," &
               "deleted_at DATETIME," &
               "restored_at DATETIME," &
               "restored_by INT(11)," &
               "created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," &
               "updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," &
               "created_by VARCHAR(10)," &
               "updated_by INT(11)" &
               ");"
    End Function

    Private Function GetUsersTable() As String
        Return "CREATE TABLE IF NOT EXISTS users (" &
               "id INT UNSIGNED ZEROFILL AUTO_INCREMENT PRIMARY KEY," &
               "first_name VARCHAR(100) NOT NULL," &
               "last_name VARCHAR(100) NOT NULL," &
               "email VARCHAR(100)," &
               "phone_number VARCHAR(20)," &
               "type ENUM('Admin','Staff','Cashier') NOT NULL," &
               "username VARCHAR(100) NOT NULL UNIQUE," &
               "password VARCHAR(100) NOT NULL," &
               "is_deleted TINYINT(1) NOT NULL DEFAULT 0," &
               "deleted_by INT UNSIGNED," &
               "deleted_at DATETIME," &
               "restored_by INT UNSIGNED," &
               "restored_at DATETIME," &
               "created_by INT UNSIGNED NOT NULL," &
               "created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," &
               "updated_by INT UNSIGNED," &
               "updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," &
               "last_active DATETIME" &
               ");"
    End Function

    Private Function GetWastageTable() As String
        Return "CREATE TABLE IF NOT EXISTS wastage (" &
               "id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY," &
               "item VARCHAR(255) NOT NULL," &
               "category VARCHAR(100) NOT NULL," &
               "quantity INT UNSIGNED NOT NULL," &
               "reason TEXT," &
               "reported_by INT UNSIGNED NOT NULL," &
               "total_cost DECIMAL(10,2) NOT NULL DEFAULT 0.00," &
               "is_deleted TINYINT(1) NOT NULL DEFAULT 0," &
               "deleted_by INT UNSIGNED," &
               "deleted_at DATETIME," &
               "restored_by INT UNSIGNED," &
               "restored_at DATETIME," &
               "created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," &
               "updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," &
               "created_by INT UNSIGNED NOT NULL," &
               "updated_by INT UNSIGNED NOT NULL" &
               ");"
    End Function


End Module
