Public Class frmProductsAdd
    Dim objProduct As New cls_t_tblProducts

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtName.Text = "" Then
            MsgBox("Please enter a valid Product Name", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        objProduct.Insert(txtCode.Text, txtName.Text, txtFullName.Text, "WengLee", txtCategory.Text, txtSubCategory.Text, 0, txtUnit.Text, Now, Now, UserId, UserId, chkActive.Checked, chkTrack.Checked, chkFz.Checked)
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub frmProductsAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each dr As DataRow In objProduct.SelectDistinct(cls_tblProducts.FieldName.Category).Rows
            txtCategory.AutoCompleteCustomSource.Add(dr(0).ToString)
        Next
        For Each dr As DataRow In objProduct.SelectDistinct(cls_tblProducts.FieldName.SubCategory).Rows
            txtSubCategory.AutoCompleteCustomSource.Add(dr(0).ToString)
        Next
    End Sub
End Class