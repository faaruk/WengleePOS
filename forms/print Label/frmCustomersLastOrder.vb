Public Class frmCustomersLastOrder

    Dim objOrderStatus As New cls_tblOrderStatus

    Dim objOrderItems As New cls_tblOrderItems

    Dim objOrders As New cls_tblOrder

    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Dim objStock As New cls_tblStock

    Sub LoadCustomers()
        ' FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString, "", "ALL")
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        '  dtpTo.Enabled = chkDateRange.Checked
    End Sub
    Private Sub dgInvoices_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellDoubleClick
        Try : Clipboard.SetText(CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value) : Catch ex As Exception : End Try
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshDG()
    End Sub

    Sub AddPrintLabelButton()
        Dim btnPP As New DataGridViewButtonColumn
        btnPP.Text = "Print Label"
        btnPP.HeaderText = "Print Label"
        btnPP.UseColumnTextForButtonValue = True
        dgOrder.Columns.Add(btnPP)
    End Sub

    Sub RefreshDG(Optional isFuture As Boolean = False)
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            Dim pp2 As New List(Of SqlParameter)

            'If Not isFuture Then
            '    If chkDateRange.Checked Then
            '        SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] Between @d1 and @d2"
            '        pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
            '        pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            '        pp2.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
            '        pp2.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            '    End If
            'Else
            '    SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] >= @d1 "
            '    pp.Add(New SqlParameter("@d1", Today.AddDays(1).Date))
            '    'pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            '    pp2.Add(New SqlParameter("@d1", Today.AddDays(1).Date))
            '    'pp2.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            'End If



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



            Dim dt As DataTable = objOrders.Selection(cls_tblOrder.SelectionType.CustomerWise, SelectString, pp)

            Dim strWhere As String
            Dim conDays As String = ddlDays.SelectedItem
            If txtDays.Text <> "" Then


                strWhere = "DaysAgo" & conDays & txtDays.Text

                If (conDays = "" Or conDays = "-Select-") Then
                    dt = dt
                Else
                    dt = dt.Select(strWhere).CopyToDataTable()
                End If
            End If
            dgOrder.DataSource = dt
            dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns("route").Visible = False
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
            dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).DisplayIndex = 1
            dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Width = 85
            dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Frozen = True
            dgOrder.Columns("CustomerName").DisplayIndex = 2
            dgOrder.Columns("CustomerName").Frozen = True
            dgOrder.Columns("DaysAgo").DisplayIndex = 3
            dgOrder.Columns("DaysAgo").HeaderText = "#DaysAgo"
            dgOrder.Columns("RouteCity").DisplayIndex = 4
            dgOrder.Columns("City").DisplayIndex = 5
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).DisplayIndex = 6
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).Width = 60
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).HeaderText = "Total Items"

            dgOrder.Columns("Total Cases").DisplayIndex = 7
            dgOrder.Columns("Total Cases").Width = 60

            dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).DisplayIndex = 8
            If dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width > 250 Then
                dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width = 250
            End If
            dgOrder.Columns(cls_tblOrder.FieldName.Status.ToString).DisplayIndex = 9

            dgOrder.Columns(cls_tblOrder.FieldName.CreatedBy.ToString).DisplayIndex = 10
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).DisplayIndex = 10
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).Width = 90

            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedBy.ToString).DisplayIndex = 11
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).DisplayIndex = 12
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).Width = 90
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).HeaderText = "Updated On"

            dgOrder.Columns(cls_tblOrder.FieldName.OrderNo.ToString).DisplayIndex = 13
            dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).DisplayIndex = 14
            dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).Width = 70
            dgOrder.Columns(cls_tblOrder.FieldName.Remarks.ToString).DisplayIndex = 15
            ' dgOrder.Columns("Drop Off Point").DisplayIndex = 13
            Counter()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub


    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        LoadCustomers()
        chkDateRange.Checked = True
        dtpFrom.Value = Today
        RefreshDG()

    End Sub

    Sub Counter()
        Dim c As Integer = 0
        Dim od As String = "-1"
        For Each dr As DataGridViewRow In dgOrder.Rows
            c += Val(dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value.ToString)
            od += "," & dr.Cells(cls_tblOrder.FieldName.OrderId.ToString).Value.ToString
            If dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Cancelled") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("No Order") Then
                dr.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Delivered") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Fulfilled") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Delivery") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192)
            Else
                dr.DefaultCellStyle.BackColor = Nothing
            End If
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub frmOrdersView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub


    Dim objRouteOrder As New cls_tblRouteOrders


    Sub ShowOrderDialog(ByVal _OrderId As Integer)
        Dim frm As New Form
        frm.Size = New Size(500, 600)
        frm.Text = "Route"
        frm.BackColor = Color.White
        'frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        frm.StartPosition = FormStartPosition.CenterScreen
        Dim cnt As New cntlRouteView
        frm.Controls.Add(cnt)
        cnt.Dock = DockStyle.Fill
        Dim RouteId As Integer = objRouteOrder.SelectScalar(cls_tblRouteOrders.FieldName.RouteID, "OrderId=" & _OrderId.ToString)
        If RouteId = 0 Then
            Throw New Exception("No Route found")
        End If
        frm.MinimizeBox = False
        frm.MaximizeBox = False
        frm.TopMost = False
        frm.ShowInTaskbar = False
        cnt.OpenRoute(RouteId)
        frm.ShowDialog()
    End Sub


    Private Sub dgOrder_Sorted(sender As System.Object, e As System.EventArgs) Handles dgOrder.Sorted
        For Each dr As DataGridViewRow In dgOrder.Rows
            If dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Cancelled") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("No Order") Then
                dr.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Delivered") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Fulfilled") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Delivery") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192)
            Else
                dr.DefaultCellStyle.BackColor = Nothing
            End If
        Next
    End Sub

    Private Sub btnExport_Click_1(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim objExport As New clsExportDatagridview
        Dim Header1 As String = "Last Order by customer"
        objExport.StartExport(dgOrder, Header1, "")
    End Sub

    Private Sub frmCustomersLastOrder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtDays_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDays.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub


    
End Class