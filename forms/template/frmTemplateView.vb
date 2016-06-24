Public Class frmTemplateView

   
    Dim objTemplateItems As New cls_tblTemplateItems
    Dim objTemplate As New cls_tblTemplate
    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString, "", "ALL")
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshDG()
    End Sub


    Sub RefreshDG()
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            Dim pp2 As New List(Of SqlParameter)
            If chkCustomer.Checked Then
                If cmbCustomer.SelectedIndex = -1 Then
                    SelectString += " AND b.[" & cls_tblCustomer.FieldName.CustomerName.ToString & "] like '%' + @CN + '%' "
                    pp.Add(New SqlParameter("@CN", cmbCustomer.Text))
                    pp2.Add(New SqlParameter("@CN", cmbCustomer.Text))
               ElseIf cmbCustomer.SelectedIndex >= 0 Then
                    SelectString += " AND a.[" & cls_tblTemplate.FieldName.CutomerId.ToString & "] =@CID"
                    pp.Add(New SqlParameter("@CID", cmbCustomer.SelectedValue))
                    pp2.Add(New SqlParameter("@CID", cmbCustomer.SelectedValue))
                End If
            End If

            dgOrder.DataSource = Nothing

            Dim selecteRow As Integer = 0
            Dim topRow As Integer = 0
            Try
                topRow = dgOrder.FirstDisplayedScrollingRowIndex
                selecteRow = dgOrder.SelectedRows(0).Index
            Catch ex As Exception
            End Try
            Dim dt As DataTable = objTemplate.Selection(cls_tblTemplate.SelectionType.All_Review, SelectString, pp)
            dgOrder.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub btnEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrder.Click
        Try
            Dim frm As New frmEditTemplate
            frm.TemplateId = dgOrder.SelectedRows(0).Cells("TemplateId").Value
            frm.LoadTemplate()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                RefreshDG()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub btnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOrder.Click
        Dim frm As New frmCreateTemplate
        frm.ShowDialog()
        RefreshDG()
    End Sub

    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCustomers()
        chkCustomer.Checked = True
        RefreshDG()
    End Sub

    Private Sub dgOrder_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrder.SelectionChanged
        Try
            CntlOrderView1.OpenOrder(dgOrder.SelectedRows(0).Cells("TemplateId").Value)
        Catch ex As Exception
            CntlOrderView1.Clear()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                objTemplateItems.Delete_By_SELECT("TemplateId=" & dgOrder.SelectedRows(0).Cells("TemplateId").Value)
                objTemplate.Delete_By_TemplateId(dgOrder.SelectedRows(0).Cells("TemplateId").Value)
                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub frmOrdersView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub chkCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomer.CheckedChanged
        cmbCustomer.Enabled = chkCustomer.Checked
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                If dgOrder.SelectedRows(0).Cells("CutomerID").Value.ToString <> 0 Then
                    MsgBox("This template cannot be set as default because it is not for all customers", MsgBoxStyle.Information, "info")
                    Exit Sub
                End If
                objTemplate.Update_field(cls_tblTemplate.FieldName.Remarks, "")
                objTemplate.Update_field(cls_tblTemplate.FieldName.Remarks, "DEFAULT", "TemplateId=" & dgOrder.SelectedRows(0).Cells("TemplateId").Value.ToString)
                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub
End Class