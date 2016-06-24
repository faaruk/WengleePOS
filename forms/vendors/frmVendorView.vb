Public Class frmVendorView
    Dim objVendors As New cls_tblVendor

    Sub ShowCustomers()
        Try
            Dim selecteRow As Integer = 0
            Dim topRow As Integer = 0
            Try
                topRow = dgCustomers.FirstDisplayedScrollingRowIndex
                selecteRow = dgCustomers.SelectedRows(0).Index
            Catch ex As Exception
            End Try
            dgCustomers.DataSource = objVendors.Selection(cls_tblVendor.SelectionType.All, " 1=1 Order By VendorName")
            dgCustomers.Columns(cls_tblVendor.FieldName.CreatedBy.ToString).Visible = False
            dgCustomers.Columns(cls_tblVendor.FieldName.CreatedDate.ToString).Visible = False
            dgCustomers.Columns(cls_tblVendor.FieldName.VendorID.ToString).Visible = False
            dgCustomers.Columns(cls_tblVendor.FieldName.Notes.ToString).Visible = False
            dgCustomers.Columns(cls_tblVendor.FieldName.UpdatedBy.ToString).Visible = False
            dgCustomers.Columns(cls_tblVendor.FieldName.UpdatedDate.ToString).Visible = False
            dgCustomers.Columns(cls_tblVendor.FieldName.Status.ToString).Visible = False
            Try
                dgCustomers.FirstDisplayedScrollingRowIndex = topRow
                dgCustomers.SelectedRows(0).Selected = False
            Catch ex As Exception
            End Try
            Try
                dgCustomers.Rows(selecteRow).Selected = True
            Catch ex As Exception
            End Try

            lblTotalOrder.Text = "Total : " & dgCustomers.Rows.Count.ToString & " Vendor(s)"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frm As New frmVendorAdd
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ShowCustomers()
        End If
    End Sub

    Private Sub frmCustomerAll_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowCustomers()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Dim frm As New frmVendorEdit
            frm.OpenCustomerId = dgCustomers.SelectedRows(0).Cells(0).Value
            frm.ShowDialog()
            ShowCustomers()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Are you sure?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If
            objVendors.Delete_By_VendorID(dgCustomers.SelectedRows(0).Cells(0).Value)
            ShowCustomers()
            MsgBox("Deleted", MsgBoxStyle.Information, "Info")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub frmCustomersView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class