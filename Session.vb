Module Session
    ' Logged-in user info
    Public UserID As Integer
    Public UserFullName As String
    Public UserType As String

    ' Optional: a method to clear session on logout
    Public Sub Clear()
        UserID = 0
        UserFullName = ""
        UserType = ""
    End Sub
End Module
