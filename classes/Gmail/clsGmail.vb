Imports System.Net
Imports System.Net.Mail
Public Class clsGmail
    Dim server As String = "smtp.gmail.com"
    Dim port As Integer = 587
    Dim SSL As Boolean = True

    Sub SendEmail(ToEmail As String, Subject As String, Message As String, AttachmentFileName As String, UserName As String, Password As String, ByRef Response As String, Optional ListOdFiles As List(Of String) = Nothing)
        Dim smtpServer As New SmtpClient()
        smtpServer.Credentials = New Net.NetworkCredential(UserName, Password)
        smtpServer.Host = server
        smtpServer.Port = port
        smtpServer.EnableSsl = SSL
        Dim mail As New MailMessage(UserName, ToEmail, Subject, Message)
        If AttachmentFileName <> "" Then
            If IO.File.Exists(AttachmentFileName) Then
                mail.Attachments.Add(New Attachment(AttachmentFileName))
            End If
        End If
        If Not ListOdFiles Is Nothing Then
            For Each ast As String In ListOdFiles
                If ast <> "" Then
                    If IO.File.Exists(ast) Then
                        mail.Attachments.Add(New Attachment(ast))
                    End If
                End If
            Next
        End If

        smtpServer.Send(mail)
        ' MsgBox("Mail sent", MsgBoxStyle.Information, "Info")
        Response = "Mail Sent"
    End Sub



End Class
