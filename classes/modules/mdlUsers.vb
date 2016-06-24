Module mdlUsers
    Public UserName As String = ""
    Public UserId As Integer = 0
    Public UserPassword As String = ""
    Public UserLoggedIn As Boolean = False
    Public UserLoginTime As Date = Now
    Public UserFullName As String = ""
    Public UserBranchID As Integer = 0
    Public LoginDetailsID As Integer = 0


    Sub Logout()
        Try
            Dim objLoginDetails As New cls_tblUserLoginInfo
            LoginDetailsID = objLoginDetails.Update_field(cls_tblUserLoginInfo.FieldName.LogoutDate, Now, " " & cls_tblUserLoginInfo.FieldName.ItemSL.ToString & " = " & LoginDetailsID)
            UserName = ""
            UserId = 0
            UserBranchID = 0
            UserPassword = ""
            UserLoggedIn = False
            UserLoginTime = Now
            UserFullName = ""
            LoginDetailsID = 0
        Catch ex As Exception
        End Try
    End Sub
End Module
