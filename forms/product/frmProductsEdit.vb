Public Class frmProductsEdit
    Dim objProduct As New cls_t_tblProducts
    Public ProductID As Integer = 0
    Dim pr As cls_t_tblProducts.Fields

    Private Sub frmProductsEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pr = objProduct.Selection_One_Row(ProductID)
        txtCategory.Text = pr.Category_
        txtName.Text = pr.ProductName_
        txtSubCategory.Text = pr.SubCategory_
        txtUnit.Text = pr.UnitOfMeasure_
        txtFullName.Text = pr.FullName_
        txtCode.Text = pr.ProductCode_
        chkActive.Checked = pr.Enabled_
        chkTrack.Checked = pr.TrackInventory_
        chkFz.Checked = pr.FZStatus_
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If txtName.Text = "" Then
                MsgBox("Please enter a valid Product Name", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            objProduct.Update(txtCode.Text, txtName.Text, txtFullName.Text, pr.Brand_, txtCategory.Text, txtSubCategory.Text, pr.Price_, txtUnit.Text, pr.DateCreated_, Now, pr.CreatedBy_, UserId, chkActive.Checked, chkTrack.Checked, chkFz.Checked, ProductID)
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

End Class