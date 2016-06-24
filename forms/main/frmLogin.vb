Public Class frmLogin
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If DeveloperPc() Then
            txtUsername.Text = "Admin"
            txtPassword.Text = "Admin"
            'DoLogin()
        End If

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        DoLogin()
    End Sub

    Sub DoLogin()

        If txtUsername.Text.Trim = "" Then
            txtUsername.Focus()
            Exit Sub
        End If

        If txtPassword.Text.Trim = "" Then
            txtPassword.Focus()
            Exit Sub
        End If

        'For Each dr As DataRow In objUser.Selection().Rows
        '    If dr("Username") = txtUsername.Text Then
        '        MsgBox(Decrypt(dr("Password")))
        '    End If
        'Next

        Try
            Dim objUser As New cls_tblUserDetails
            Dim userinfo As cls_tblUserDetails.Fields = objUser.CheckLogin(txtUsername.Text, Encrypt(txtPassword.Text))
            'Dim userinfo As cls_tblUserDetails.Fields = objUser.CheckLogin(txtUsername.Text, txtPassword.Text)
            UserName = userinfo.UserName
            UserId = userinfo.UserId
            UserBranchID = userinfo.BranchID
            UserPassword = Decrypt(userinfo.Password)
            UserLoggedIn = True
            UserLoginTime = Now
            UserFullName = userinfo.FullName
            Dim objLoginDetails As New cls_tblUserLoginInfo
            LoginDetailsID = objLoginDetails.Insert(UserId, UserLoginTime, UserLoginTime)
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox("Authentication Failed." & vbNewLine & "Please check your Username and Password", MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

        Try
            Dim conn As SqlConnection = (New clsConnection).connect
            Dim bulkcopy As New SqlBulkCopy(conn)
            Dim da As New SqlDataAdapter("Select [StockId]   ,[ProductId]  ,[Qty]   ,[TransactionId] ,[TransactionType]     ,[Stocktype]  ,[CreatedBy] ,[CreatedDate]  ,[Remarks]  ,[Fresh] as [sex] from tblStock", conn)
            Dim dt As New DataTable
            da.Fill(dt)
            ' Dim sa As String = @"bifyuyt"

            Dim com As New SqlCommand("delete from tblStock", conn)
            com.ExecuteNonQuery()
            bulkcopy.DestinationTableName = "tblStock"

            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("StockId", "StockId"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("ProductId", "ProductId"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("Qty", "Qty"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("TransactionId", "TransactionId"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("TransactionType", "TransactionType"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("Stocktype", "Stocktype"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("CreatedBy", "CreatedBy"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("CreatedDate", "CreatedDate"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("Remarks", "Remarks"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("Fresh", "Fresh"))
            'bulkcopy.ColumnMappings.Add(New SqlBulkCopyColumnMapping("TransactionDate", "TransactionDate"))
            bulkcopy.WriteToServer(dt)
            MsgBox("Done")
        Catch ex As Exception
            MsgBox("Not Done")
        End Try
    End Sub
    'Sub TestA(b As String)
    '    MsgBox("test" & b)
    'End Sub
    Private Sub frmLogin_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'Action(AddressOf TestA)("this is a test")
        '  acti
        If Not DeveloperPc() Then
            If My.Application.Info.Version <= New Version("1.0.7.9") Then
                Try
                    Dim myLocation As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "WengLee Application.exe")
                    If Environment.GetCommandLineArgs(0) <> myLocation Then
                        MsgBox("The software need some arrangements. So it will download the recent version again and will arrange the APP FOLDER. Please reset the Desktop shortcut of the app. The most rescent version of this app is 'WengLee Application.exe'", MsgBoxStyle.Information, "info")
                        StartUpdater()
                        'If Not IO.File.Exists(myLocation) Then
                        'End If
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
        Dim objVC As New VersionControl
        objVC.VersionCheck()

    End Sub
End Class