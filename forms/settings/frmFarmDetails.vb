Public Class frmFarmDetails
    Dim objSet As New cls_tblSettings

    Private Sub frmFarmDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sett As cls_tblSettings.Fields = objSet.Selection_One_Row()
        txtAddress.Text = sett.Address
        txtEmail.Text = sett.email
        txtFax.Text = sett.Fax
        txtName.Text = sett.CompanyName
        txtPhone.Text = sett.Phone
        txtWebsite.Text = sett.Website

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        objSet.Update_field(cls_tblSettings.FieldName.CompanyName, txtName.Text)
        objSet.Update_field(cls_tblSettings.FieldName.Address, txtAddress.Text)
        objSet.Update_field(cls_tblSettings.FieldName.Phone, txtPhone.Text)
        objSet.Update_field(cls_tblSettings.FieldName.Fax, txtFax.Text)
        objSet.Update_field(cls_tblSettings.FieldName.email, txtEmail.Text)
        objSet.Update_field(cls_tblSettings.FieldName.Website, txtWebsite.Text)
        MsgBox("Done", MsgBoxStyle.Information, "Info")
        Close()
    End Sub
End Class