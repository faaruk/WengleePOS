Public Class frmOrdersSelectDialog
    Dim objOrderItems As New cls_tblOrderItems

    Dim objOrders As New cls_tblOrder

    Public ExtraSelect As String = ""

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
    Private Sub dgInvoices_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellDoubleClick
        Try : Clipboard.SetText(CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value) : Catch ex As Exception : End Try
    End Sub
    Sub RefreshDG(Optional isFuture As Boolean = False)
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            Dim pp2 As New List(Of SqlParameter)

            If chkStatus.Checked Then
                SelectString += " AND a.[" & cls_tblOrder.FieldName.Status.ToString & "]=@status"
                pp.Add(New SqlParameter("@status", cmbStatus.Text))
                pp2.Add(New SqlParameter("@status", cmbStatus.Text))
            End If


            If Not isFuture Then
                If chkDateRange.Checked Then
                    SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] Between @d1 and @d2"
                    pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                    pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
                    pp2.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                    pp2.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
                End If
            Else
                SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] >= @d1 "
                pp.Add(New SqlParameter("@d1", Today.AddDays(1).Date))
                'pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
                pp2.Add(New SqlParameter("@d1", Today.AddDays(1).Date))
                'pp2.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            End If


            If chkCustomer.Checked Then
                If cmbCustomer.SelectedIndex = -1 Then
                    SelectString += " AND b.[" & cls_tblCustomer.FieldName.CustomerName.ToString & "] like '%' + @CN + '%' "
                    pp.Add(New SqlParameter("@CN", cmbCustomer.Text))
                    pp2.Add(New SqlParameter("@CN", cmbCustomer.Text))
                ElseIf cmbCustomer.SelectedIndex >= 1 Then
                    SelectString += " AND a.[" & cls_tblOrder.FieldName.CutomerId.ToString & "] =@CID"
                    pp.Add(New SqlParameter("@CID", cmbCustomer.SelectedValue))
                    pp2.Add(New SqlParameter("@CID", cmbCustomer.SelectedValue))
                End If
            End If

            dgOrder.DataSource = Nothing

            Dim selecteRow As Integer = 0
            Dim topRow As Integer = 0
            ' Dim sortedro As Integer = 0
            Try
                topRow = dgOrder.FirstDisplayedScrollingRowIndex
                selecteRow = dgOrder.SelectedRows(0).Index
            Catch ex As Exception
            End Try
            'Try
            '    sortedro = dgOrder.SortedColumn
            'Catch ex As Exception
            'End Try

            Dim dt As DataTable = objOrders.Selection(cls_tblOrder.SelectionType.ReviewOrder, SelectString & ExtraSelect, pp)
            dgOrder.DataSource = dt
            dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            dgOrder.Columns("route").Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CutomerId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderAmount.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderSl.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusDate.ToString).Visible = False

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
            dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).DisplayIndex = 0
            dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).Width = 85
            dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).Frozen = True
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).DisplayIndex = 1
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Width = 85
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Frozen = True
            dgOrder.Columns("Posting Date").DisplayIndex = 1
            dgOrder.Columns("Posting Date").Width = 85
            dgOrder.Columns("Posting Date").Frozen = True
            dgOrder.Columns("CustomerName").DisplayIndex = 2
            dgOrder.Columns("CustomerName").Frozen = True
            dgOrder.Columns("RouteCity").DisplayIndex = 3
            dgOrder.Columns("City").DisplayIndex = 4
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).DisplayIndex = 5
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).Width = 60
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).HeaderText = "Total Items"

            dgOrder.Columns("Total Cases").DisplayIndex = 6
            dgOrder.Columns("Total Cases").Width = 60

            dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).DisplayIndex = 7
            If dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width > 250 Then
                dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width = 250
            End If
            dgOrder.Columns(cls_tblOrder.FieldName.Status.ToString).DisplayIndex = 8

            dgOrder.Columns(cls_tblOrder.FieldName.CreatedBy.ToString).DisplayIndex = 9
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).DisplayIndex = 10
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).Width = 90

            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedBy.ToString).DisplayIndex = 10
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).DisplayIndex = 11
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).Width = 90
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).HeaderText = "Updated On"

            dgOrder.Columns(cls_tblOrder.FieldName.OrderNo.ToString).DisplayIndex = 12
            dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).DisplayIndex = 13
            dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).Width = 70
            dgOrder.Columns(cls_tblOrder.FieldName.Remarks.ToString).DisplayIndex = 14
            ' dgOrder.Columns("Drop Off Point").DisplayIndex = 13
            Counter()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub



    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCustomers()
        chkStatus.Checked = False
        chkCustomer.Checked = True
        cmbStatus.SelectedIndex = 1
        chkDateRange.Checked = True
        dtpFrom.Value = Today
        dtpTo.Value = Today
        RefreshDG()
    End Sub

    Sub Counter()
        Dim c As Integer = 0
        Dim od As String = "-1"
        For Each dr As DataGridViewRow In dgOrder.Rows
            c += Val(dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value.ToString)
            od += "," & dr.Cells(cls_tblOrder.FieldName.OrderId.ToString).Value.ToString
        Next
        Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.UNIT_WISE_TOTAL, "a.OrderId in (" & od.ToString & ") group by b. UnitOfMeasure ")

        'Label2.Text = " Total " & total.ToString & " Case(s)."
        'Label2.Text = "Total : " ' & c.ToString & " Case(s)"
        lblTotalOrder.Text = "Total : " & dgOrder.Rows.Count.ToString & " Order(s)" & vbNewLine & "Total Qty : " '& c.ToString '& " Case(s)"
        For Each dr As DataRow In orderItems.Rows
            lblTotalOrder.Text += dr("Total").ToString & " " & dr("Unit").ToString & ", " 'Case(s)"
        Next
    End Sub

    Private Sub dgOrder_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrder.SelectionChanged
        Try
            CntlOrderView1.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value)
        Catch ex As Exception
            CntlOrderView1.Clear()
        End Try
    End Sub
 


    Private Sub frmOrdersView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub chkCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomer.CheckedChanged
        cmbCustomer.Enabled = chkCustomer.Checked
    End Sub

   
    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnFutureOrders.Click
        RefreshDG(True)
    End Sub

   
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If dgOrder.SelectedRows.Count = 0 Then
            MsgBox("Select an order", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class