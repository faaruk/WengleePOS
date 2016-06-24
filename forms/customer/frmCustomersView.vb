Public Class frmCustomersView
    Dim objCustomers As New cls_tblCustomer

    Sub ShowCustomers()
        Try
            Dim selecteRow As Integer = 0
            Dim topRow As Integer = 0

            Try
                topRow = dgCustomers.FirstDisplayedScrollingRowIndex
                selecteRow = dgCustomers.SelectedRows(0).Index
            Catch ex As Exception
            End Try

            dgCustomers.DataSource = objCustomers.Selection(cls_tblCustomer.SelectionType.All, " 1=1 and [Status]='ACTIVE' Order By CustomerName")
            dgCustomers.Columns(cls_tblCustomer.FieldName.CreatedBy.ToString).Visible = False
            dgCustomers.Columns(cls_tblCustomer.FieldName.CreatedDate.ToString).Visible = False
            dgCustomers.Columns(cls_tblCustomer.FieldName.CustomerID.ToString).Visible = False
            dgCustomers.Columns(cls_tblCustomer.FieldName.Notes.ToString).Visible = False
            dgCustomers.Columns(cls_tblCustomer.FieldName.UpdatedBy.ToString).Visible = False
            dgCustomers.Columns(cls_tblCustomer.FieldName.UpdatedDate.ToString).Visible = False
            dgCustomers.Columns(cls_tblCustomer.FieldName.Status.ToString).Visible = False

            'dgCustomers.Columns(cls_tblCustomer.FieldName.CustomerName .ToString).Visible = False
            'dgCustomers.Columns(cls_tblCustomer.FieldName.UpdatedDate.ToString).Visible = False

            For Each dr As DataGridViewRow In dgCustomers.Rows
                If dr.Cells(cls_tblCustomer.FieldName.Notes.ToString).Value = "" Then
                    'dr.Cells(0).Value = "No Notes"
                    dr.Cells(0).Value = ""
                Else
                    dr.Cells(0).Value = "Notes"
                End If
                Try
                    If dr.Cells(cls_tblCustomer.FieldName.Receiving_CutOff.ToString).Value = "" Then
                        dr.Cells(cls_tblCustomer.FieldName.Receiving_CutOff.ToString).Value = "Not Specified"
                    End If
                Catch ex As Exception
                    dr.Cells(cls_tblCustomer.FieldName.Receiving_CutOff.ToString).Value = "Not Specified"
                End Try
            Next

            Try
                dgCustomers.FirstDisplayedScrollingRowIndex = topRow
                dgCustomers.SelectedRows(0).Selected = False
            Catch ex As Exception
            End Try

            Try
                dgCustomers.Rows(selecteRow).Selected = True
            Catch ex As Exception
            End Try

            lblTotalOrder.Text = "Total : " & dgCustomers.Rows.Count.ToString & " Customer(s)"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
  

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frm As New frmCustomerAdd
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ShowCustomers()
        End If
    End Sub

    Private Sub frmCustomerAll_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowCustomers()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Dim frm As New frmCustomerEdit
            frm.OpenCustomerId = dgCustomers.SelectedRows(0).Cells(2).Value
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
            'objCustomers.Delete_By_CustomerID(dgCustomers.SelectedRows(0).Cells(0).Value)

            objCustomers.Update_field(cls_tblCustomer.FieldName.Status, "DEACTIVATED", "CustomerId=" & dgCustomers.SelectedRows(0).Cells(2).Value)

            ShowCustomers()
            MsgBox("Deleted", MsgBoxStyle.Information, "Info")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub frmCustomersView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub dgCustomers_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCustomers.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                Dim frmn As New frmShowNotes
                frmn.TextBox1.Text = dgCustomers.Rows(e.RowIndex).Cells(cls_tblCustomer.FieldName.Notes.ToString).Value
                frmn.ShowDialog()
            ElseIf e.ColumnIndex = 1 Then
                ShowRouteMap(dgCustomers.Rows(e.RowIndex).Cells(cls_tblCustomer.FieldName.CustomerID.ToString).Value)
            End If
        End If
    End Sub

    Sub ShowRouteMap(CutomerId As Integer)
        Dim CustomerDetails As cls_tblCustomer.Fields = Nothing
        Dim dtr As String = ""
        Try
            CustomerDetails = objCustomers.Selection_One_Row(CutomerId)
        Catch ex As Exception
        End Try


        dtr += "&q=" & CustomerDetails.CustomerName.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")

        frmViewMap.Show()
        frmViewMap.LoadMap(dtr, "Place")
    End Sub
End Class