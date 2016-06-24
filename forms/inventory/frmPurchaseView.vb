Public Class frmPurchaseView
    Dim objStock As New cls_tblStock
    Dim objPurchase As New cls_tblPurchase
    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblVendor.tablename, cls_tblVendor.FieldName.VendorName.ToString, cls_tblVendor.FieldName.VendorID.ToString, "", "ALL")
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshDG()
    End Sub

    Sub RefreshDG()
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            If chkDateRange.Checked Then
                SelectString += " AND a.[" & cls_tblPurchase.FieldName.PurchaseDate.ToString & "] Between @d1 and @d2"
                pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            End If
            If chkCustomer.Checked Then
                If cmbCustomer.SelectedIndex = -1 Then
                    SelectString += " AND b.[" & cls_tblVendor.FieldName.VendorName.ToString & "] like '%' + @CN + '%' "
                    pp.Add(New SqlParameter("@CN", cmbCustomer.Text))
                ElseIf cmbCustomer.SelectedIndex >= 1 Then
                    SelectString += " AND a.[" & cls_tblPurchase.FieldName.VendorId.ToString & "] =@CID"
                    pp.Add(New SqlParameter("@CID", cmbCustomer.SelectedValue))
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
            Dim dt As DataTable = objPurchase.Selection(cls_tblPurchase.SelectionType.Review, SelectString, pp)
            dgOrder.DataSource = dt

            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns("route").Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedBy.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.CutomerId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.OrderAmount.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.OrderSl.ToString).Visible = False
            dgOrder.Columns(cls_tblPurchase.FieldName.PurchaseId.ToString).Visible = False
            dgOrder.Columns(cls_tblPurchase.FieldName.CreatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblPurchase.FieldName.Session.ToString).Visible = False
            dgOrder.Columns(cls_tblPurchase.FieldName.TotalAmount.ToString).Visible = False
            dgOrder.Columns(cls_tblPurchase.FieldName.UpdatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblPurchase.FieldName.VendorId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.StatusBy.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.StatusDate.ToString).Visible = False
            'dgOrder.Columns("CustomerName").HeaderText = "Customer Name"
            'dgOrder.Columns("RouteCity").HeaderText = "Route City"
            Try
                dgOrder.FirstDisplayedScrollingRowIndex = topRow
                dgOrder.SelectedRows(0).Selected = False
            Catch ex As Exception
            End Try
            Try
                dgOrder.Rows(selecteRow).Selected = True
            Catch ex As Exception
            End Try

            'dgOrder.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            'dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).DisplayIndex = 0
            'dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).Width = 85
            'dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).Frozen = True
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).DisplayIndex = 1
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Width = 85
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Frozen = True
            'dgOrder.Columns("CustomerName").DisplayIndex = 2
            'dgOrder.Columns("CustomerName").Frozen = True
            'dgOrder.Columns("RouteCity").DisplayIndex = 3
            'dgOrder.Columns("City").DisplayIndex = 4
            'dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).DisplayIndex = 5
            'dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).Width = 60
            'dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).HeaderText = "Total cases"
            'dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).DisplayIndex = 6
            'If dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width > 250 Then
            '    dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width = 250
            'End If
            'dgOrder.Columns(cls_tblOrder.FieldName.Status.ToString).DisplayIndex = 7
            'dgOrder.Columns(cls_tblOrder.FieldName.UpdatedBy.ToString).DisplayIndex = 8
            'dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).DisplayIndex = 9
            'dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).Width = 90
            'dgOrder.Columns(cls_tblOrder.FieldName.OrderNo.ToString).DisplayIndex = 10
            'dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).DisplayIndex = 11
            'dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).Width = 70
            'dgOrder.Columns(cls_tblOrder.FieldName.Remarks.ToString).DisplayIndex = 12
            dgOrder.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            Counter()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub btnEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrder.Click
        Try
            Dim frm As New frmPurchaserEdit
            frm.PurchaseId = dgOrder.SelectedRows(0).Cells("PurchaseID").Value
            frm.LoadPurchase()
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                RefreshDG()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub btnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOrder.Click
        Dim frm As New frmPurchaserAdd
        frm.ShowDialog()
        RefreshDG()
    End Sub

    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCustomers()


        chkDateRange.Checked = True
        dtpFrom.Value = Today
        dtpTo.Value = Today

        RefreshDG()
    End Sub
    Sub Counter()
        Dim c As Long = 0
        For Each dr As DataGridViewRow In dgOrder.Rows
            c += Val(dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value.ToString)
        Next
        lblTotalOrder.Text = "Total : " & dgOrder.Rows.Count.ToString & " Order(s)" & vbNewLine & "Total Qty : " & c.ToString '& " Case(s)"
    End Sub
    Private Sub dgOrder_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrder.SelectionChanged
        Try
            CntlOrderView1.OpenOrder(dgOrder.SelectedRows(0).Cells("PurchaseId").Value)
        Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Information, "Info {FMVO-01}")
            CntlOrderView1.Clear()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                objPurchase.Delete_By_PurchaseId(dgOrder.SelectedRows(0).Cells("PurchaseId").Value)
                objStock.Delete_By_SELECT("TransactionId=" & dgOrder.SelectedRows(0).Cells("PurchaseId").Value & " and TransactionType='PURCHASE'")
                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub frmOrdersView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub chkCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomer.CheckedChanged
        cmbCustomer.Enabled = chkCustomer.Checked
    End Sub

   
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmStockReport
        frm.ShowDialog()
    End Sub
End Class