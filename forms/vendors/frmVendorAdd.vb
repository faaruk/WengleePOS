Public Class frmVendorAdd
    Dim objVendor As New cls_tblVendor
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub txtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSave.Click

        'Validate Items
        If txtName.Text.Trim = "" Then
            MsgBox("Enter Name ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtAddress.Text.Trim = "" Then
            MsgBox("Enter Address ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtState.Text.Trim = "" Then
            MsgBox("Enter State ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtCity.Text.Trim = "" Then
            MsgBox("Enter City ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtZip.Text.Trim = "" Then
            MsgBox("Enter Zip ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtName.Text.Trim = "" Then
            MsgBox("Enter Name ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Try
            'txtClientSince.Text = "01/01/2014"
            objVendor.Insert(txtName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtNotes.Text, "ACTIVE", Now, UserId, Now, UserId, txtPhone.Text, txtEmail.Text, txtWebsite.Text, txtFax.Text)
            MsgBox("Saved successfully", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try


    End Sub

End Class