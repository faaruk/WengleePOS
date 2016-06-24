Public Class frmVendorEdit
    Dim objVendor As New cls_tblVendor
    Public OpenCustomerId As Integer = 0

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
            Dim fl As cls_tblVendor.Fields = objVendor.Selection_One_Row(OpenCustomerId)
            objVendor.Update(OpenCustomerId, txtName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtNotes.Text, fl.Status, fl.CreatedDate, fl.CreatedBy, fl.UpdatedDate, fl.UpdatedBy, txtPhone.Text, txtEmail.Text, txtWebsite.Text, txtFax.Text)
            MsgBox("Updated successfully", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub frmCustomerEdit_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try

            Dim fl As cls_tblVendor.Fields = objVendor.Selection_One_Row(OpenCustomerId)
            txtName.Text = fl.VendorName
            txtAddress.Text = fl.Address
            txtCity.Text = fl.City
            txtState.Text = fl.State
            txtZip.Text = fl.Zip
            txtNotes.Text = fl.Notes
            txtPhone.Text = fl.Phone
            txtEmail.Text = fl.Email
            txtWebsite.Text = fl.Website
            txtFax.Text = fl.Fax

        Catch ex As Exception
        End Try
    End Sub
End Class