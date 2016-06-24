Public Class frmSetupEmail

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        Try
            Dim objEmail As New clsGmail
            Dim Response As String = ""
            objEmail.SendEmail(txtUserName.Text, "TEST MAIL", "TEST MAIL", "", txtUserName.Text, txtPassword.Text, Response)
            If Response = "Mail Sent" Then
                MsgBox(Response, MsgBoxStyle.Information, "info")
            Else
                MsgBox("Error While sending mail", MsgBoxStyle.Information, "info")
            End If
        Catch ex As Exception
            MsgBox("Error While sending mail" & vbNewLine & ex.Message, MsgBoxStyle.Information, "info")
        End Try
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveSettings.Click
        Dim Sett As mdlLocalSettings.LocalSetting = MyLocalSettings
        Sett.EmailPass = SHA1Encryption.Encrypt(txtPassword.Text)
        Sett.EmailUserName = txtUserName.Text
        MyLocalSettings = Sett
        SaveLocalSettings()
        Close()
    End Sub

    Private Sub frmSetupEmail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtUserName.Text = MyLocalSettings.EmailUserName
        Try
            txtPassword.Text = SHA1Encryption.Decrypt(MyLocalSettings.EmailPass)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmSetupEmail_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Activate()
    End Sub
End Class