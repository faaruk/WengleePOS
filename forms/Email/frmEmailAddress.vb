Public Class frmEmailAddress

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If txtEmailAddress.Text.Trim <> "" Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Empty box not accepted", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmSetupEmail_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Activate()
    End Sub

    Private Sub frmEmailAddress_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnAttachFile.Click
        Dim f As New OpenFileDialog
        f.Filter = "All Files|*.*"
        f.Multiselect = False
        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            lblFileName.Text = f.FileName
        End If
    End Sub
End Class