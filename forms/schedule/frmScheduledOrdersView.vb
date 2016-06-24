Public Class frmScheduledOrdersView

    Dim objOrderItems As New cls_tblOrderScheduleItems

    Dim objOrders As New cls_tblOrderSchedule

    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString, "", "ALL")
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        cmbStatus.Enabled = chkStatus.Checked
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshDG()
    End Sub

    Sub RefreshDG()
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            Dim pp2 As New List(Of SqlParameter)

            If chkStatus.Checked Then
                SelectString += " AND a.[" & cls_tblOrderSchedule.FieldName.Status.ToString & "]=@status"
                pp.Add(New SqlParameter("@status", cmbStatus.Text))
                pp2.Add(New SqlParameter("@status", cmbStatus.Text))
            End If

            If chkDateRange.Checked Then
                SelectString += " AND a.[" & cls_tblOrderSchedule.FieldName.OrderDate.ToString & "] Between @d1 and @d2"
                pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
                pp2.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                pp2.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            End If

            If chkCustomer.Checked Then
                If cmbCustomer.SelectedIndex = -1 Then
                    SelectString += " AND b.[" & cls_tblCustomer.FieldName.CustomerName.ToString & "] like '%' + @CN + '%' "
                    pp.Add(New SqlParameter("@CN", cmbCustomer.Text))
                    pp2.Add(New SqlParameter("@CN", cmbCustomer.Text))
                ElseIf cmbCustomer.SelectedIndex >= 1 Then
                    SelectString += " AND a.[" & cls_tblOrderSchedule.FieldName.CutomerId.ToString & "] =@CID"
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



            Dim dt As DataTable = objOrders.Selection(cls_tblOrderSchedule.SelectionType.ReviewOrder, SelectString, pp)
            dgOrder.DataSource = dt
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.BranchId.ToString).Visible = False
            dgOrder.Columns("route").Visible = False
            'dgOrder.Columns(cls_tblOrderSchedule.FieldName.CreatedBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.CreatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.CutomerId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderAmount.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderSl.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderNo.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.DeliveryDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.Status.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.StatusBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.StatusDate.ToString).Visible = False

            dgOrder.Columns("CustomerName").HeaderText = "Customer Name"
            dgOrder.Columns("RouteCity").HeaderText = "Route City"

            Try
                dgOrder.FirstDisplayedScrollingRowIndex = topRow
                dgOrder.SelectedRows(0).Selected = False
            Catch ex As Exception
            End Try
            Try
                dgOrder.Rows(selecteRow).Selected = True
            Catch ex As Exception
            End Try


            ' AddPrintLabelButton()

            dgOrder.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderDate.ToString).DisplayIndex = 0
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderDate.ToString).Width = 85
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderDate.ToString).Frozen = True
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.DeliveryDate.ToString).DisplayIndex = 1
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.DeliveryDate.ToString).Width = 85
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.DeliveryDate.ToString).Frozen = True
            dgOrder.Columns("CustomerName").DisplayIndex = 2
            dgOrder.Columns("CustomerName").Frozen = True
            dgOrder.Columns("RouteCity").DisplayIndex = 3
            dgOrder.Columns("City").DisplayIndex = 4
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.TotalItems.ToString).DisplayIndex = 5
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.TotalItems.ToString).Width = 60
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.TotalItems.ToString).HeaderText = "Total Items"

            dgOrder.Columns("Total Cases").DisplayIndex = 6
            dgOrder.Columns("Total Cases").Width = 60

            dgOrder.Columns(cls_tblOrderSchedule.FieldName.Comments.ToString).DisplayIndex = 7
            If dgOrder.Columns(cls_tblOrderSchedule.FieldName.Comments.ToString).Width > 250 Then
                dgOrder.Columns(cls_tblOrderSchedule.FieldName.Comments.ToString).Width = 250
            End If
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.Status.ToString).DisplayIndex = 8

            dgOrder.Columns(cls_tblOrderSchedule.FieldName.CreatedBy.ToString).DisplayIndex = 9
            'dgOrder.Columns(cls_tblOrderSchedule.FieldName.CreatedDate.ToString).DisplayIndex = 10
            'dgOrder.Columns(cls_tblOrderSchedule.FieldName.CreatedDate.ToString).Width = 90

            dgOrder.Columns(cls_tblOrderSchedule.FieldName.UpdatedBy.ToString).DisplayIndex = 10
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.UpdatedDate.ToString).DisplayIndex = 11
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.UpdatedDate.ToString).Width = 90
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.UpdatedDate.ToString).HeaderText = "Updated On"

            dgOrder.Columns(cls_tblOrderSchedule.FieldName.OrderNo.ToString).DisplayIndex = 12
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.Session.ToString).DisplayIndex = 13
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.Session.ToString).Width = 70
            dgOrder.Columns(cls_tblOrderSchedule.FieldName.Remarks.ToString).DisplayIndex = 14
            ' dgOrder.Columns("Drop Off Point").DisplayIndex = 13
            Counter()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub btnEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrder.Click
        Try
            Dim frm As New frmScheduleOrderEdit
            frm.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                RefreshDG()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub btnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOrder.Click
        Dim frm As New frmScheduleOrderAdd
        frm.ShowDialog()
        RefreshDG()
    End Sub

    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCustomers()

        chkStatus.Checked = False
        chkCustomer.Checked = False
        cmbStatus.SelectedIndex = 1

        chkDateRange.Checked = False
        dtpFrom.Value = Today
        dtpTo.Value = Today

        RefreshDG()
    End Sub
    Sub Counter()
        Dim c As Integer = 0
        Dim od As String = "-1"
        For Each dr As DataGridViewRow In dgOrder.Rows
            c += dr.Cells(cls_tblOrderSchedule.FieldName.TotalItems.ToString).Value.ToString
            od += "," & dr.Cells(cls_tblOrderSchedule.FieldName.OrderId.ToString).Value.ToString
        Next
        Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.UNIT_WISE_TOTAL, "a.OrderId in (" & od.ToString & ") group by b. UnitOfMeasure ")
        'Label2.Text = " Total " & total.ToString & " Case(s)."
        ' Label2.Text = "Total : " ' & c.ToString & " Case(s)"
        lblTotalOrder.Text = "Total : " & dgOrder.Rows.Count.ToString & " Order(s)" & vbNewLine & "Total Qty : " '& c.ToString '& " Case(s)"
        For Each dr As DataRow In orderItems.Rows
            lblTotalOrder.Text += dr("Total").ToString & " " & dr("Unit").ToString & ", " 'Case(s)"
        Next
    End Sub
    Private Sub dgOrder_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrder.SelectionChanged
        Try
            CntlScheduledOrderView1.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value)
        Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Information, "Info {FMVO-01}")
            CntlScheduledOrderView1.Clear()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                objOrderItems.Delete_By_OrderId(dgOrder.SelectedRows(0).Cells("OrderId").Value)
                objOrders.Delete_By_OrderId(dgOrder.SelectedRows(0).Cells("OrderId").Value)
                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub frmOrdersView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub chkCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomer.CheckedChanged
        cmbCustomer.Enabled = chkCustomer.Checked
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnConfirm.Click
        Dim frm As New frmTodaysScheduledOrdersView
        frm.ShowDialog()
    End Sub


End Class