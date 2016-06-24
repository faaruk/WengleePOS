Public Class frmOrdersView

    Dim objOrderStatus As New cls_tblOrderStatus

    Dim objOrderItems As New cls_tblOrderItems

    Dim objOrders As New cls_tblOrder

    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Dim objCustomer As New cls_t_tblCustomer
    Dim objStock As New cls_tblStock
    Dim objUserRules As New cls_tblUserRules

    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString, "", "ALL")
    End Sub

    Sub LoadRouteCity()
        Dim dt As DataTable = objCustomer.Selection(cls_t_tblCustomer.SelectionType.DISTINCT_ROUTECITY)
        Dim dr As DataRow = dt.NewRow
        dr(0) = "--SELECT--"
        dt.Rows.InsertAt(dr, 0)
        cmbRouteCity.DataSource = dt
        cmbRouteCity.DisplayMember = "routecity"
        cmbRouteCity.ValueMember = "routecity"

    End Sub
    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked
    End Sub
    Private Sub dgInvoices_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellDoubleClick
        Try : Clipboard.SetText(CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value) : Catch ex As Exception : End Try
    End Sub
    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        cmbStatus.Enabled = chkStatus.Checked
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

            If chkRouteCity.Checked Then
                If cmbRouteCity.SelectedIndex >= 1 Then
                    'SelectString += " AND ISNULL(f.[" & cls_tblCustomer_BOL.FieldName.RouteCity.ToString & "],b.[" & cls_tblCustomer.FieldName.RouteCity.ToString & "]) =@RC"
                    SelectString += " AND b.[" & cls_tblCustomer.FieldName.RouteCity.ToString & "] =@RC"
                    pp.Add(New SqlParameter("@RC", cmbRouteCity.Text))
                    pp2.Add(New SqlParameter("@RC", cmbRouteCity.Text))
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



            Dim dt As DataTable = objOrders.Selection(cls_tblOrder.SelectionType.ReviewOrder, SelectString & " Order by OrderId", pp)
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

            dgOrder.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
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
    Private Sub btnEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrder.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.EditOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Try
            Dim frm As New frmOrderEdit
            frm.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                RefreshDG()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub


    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCustomers()
        LoadRouteCity()
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
            If dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Cancelled") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("No Order") Then
                dr.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Delivery") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Delivered") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Open") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Fulfilled") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Hold") Then
                dr.DefaultCellStyle.BackColor = Color.Red
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.PostOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                objOrderItems.Delete_By_OrderId(dgOrder.SelectedRows(0).Cells("OrderId").Value)
                objOrders.Delete_By_OrderId(dgOrder.SelectedRows(0).Cells("OrderId").Value)
                objOrderStatus.Delete_By_OrderID(dgOrder.SelectedRows(0).Cells("OrderId").Value)
                objStock.Delete_By_SELECT("TransactionId=" & dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString & " and TransactionType='ORDER'", Nothing)

                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If

    End Sub

    Private Sub btnPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLabel.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.PrintLabel, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Try
            Dim pp As New clsPrintLabel
            Dim l As New List(Of Integer)
            l.Add(dgOrder.SelectedRows(0).Cells("OrderId").Value)
            pp.PrintOrder(l)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub btnFulFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFulFill.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.FulFillOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                Dim frm As New frmOrderFullfillment
                frm.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderID").Value)
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    RefreshDG()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub btnCancelOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelOrder.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.CancelOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                objOrders.Update_field(cls_tblOrder.FieldName.Status, "Cancelled", "OrderID=" & dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString)
                objOrderStatus.Insert(dgOrder.SelectedRows(0).Cells("OrderID").Value, "Cancelled", "", "", Now, Now, UserId)
                objStock.Delete_By_SELECT("TransactionId=" & dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString & " and TransactionType='ORDER'", Nothing)

                MsgBox("Cancelled", MsgBoxStyle.Information, "Info")
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

    Private Sub btnUnlinkBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlinkBOL.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.LinkBol, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If

        If dgOrder.SelectedRows(0).Cells("BOL").Value.ToString = "NO" Then
            MsgBox("BOL address not linked", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

            Try
                Dim con As SqlConnection = (New clsConnection).connect
                Try
                    Dim com1 As New SqlCommand("Update tblOrder set BOLAddressID=0 where OrderID=" & dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString, con)
                    com1.ExecuteNonQuery()
                Catch ex As Exception
                End Try

                Dim com As New SqlCommand("Update tblCustomer set BOL='NO' where customerid=" & dgOrder.SelectedRows(0).Cells("cutomerid").Value.ToString, con)
                com.ExecuteNonQuery()
                MsgBox("Done", MsgBoxStyle.Information, "Info")
                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try

        End If

    End Sub

    Private Sub btnLinkBol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkBol.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.LinkBol, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If

        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                Dim frm As New frmBolAddress
                frm.OrderId = dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString
                frm.CustomerID = dgOrder.SelectedRows(0).Cells("CutomerId").Value.ToString
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    MsgBox("Done", MsgBoxStyle.Information, "Info")
                    RefreshDG()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub btnPrintBol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintBol.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.PrintBol, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If

        Try
            Dim pp As New clsPrintBOL_WINWORD
            pp.CreateBol(dgOrder.SelectedRows(0).Cells("OrderId").Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
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

    Private Sub btnViewRoute_Click(sender As System.Object, e As System.EventArgs) Handles btnViewRoute.Click

        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.ViewRoute, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Try
            ShowOrderDialog(dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "info")
        End Try

    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.PrintOrderList, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Dim frm As New frmPrintList
        frm.PrintPreview(dgOrder, "Order List", "", "", "", True, "", True, True) '

    End Sub

    Private Sub btnPrintSalesOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSalesOrder.Click

        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.SalesOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If

        Try
            Dim Mail As Boolean = False
            If MsgBox("Do you want to send sales order as email or fax?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                Mail = True
            End If
            Dim pp As New clsPrintSaleOrder_WINWORD
            pp.CreateSalesOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value, Mail)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        RefreshDG(True)
    End Sub


    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Export, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Dim objExport As New clsExportDatagridview
        Dim Header1 As String = "Orders"
        objExport.StartExport(dgOrder, Header1, "")
    End Sub

    Private Sub dgOrder_Sorted(sender As System.Object, e As System.EventArgs) Handles dgOrder.Sorted

        For Each dr As DataGridViewRow In dgOrder.Rows
            If dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Cancelled") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("No Order") Then
                dr.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Delivery") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Delivered") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Open") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Fulfilled") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Hold") Then
                dr.DefaultCellStyle.BackColor = Color.Red
            Else
                dr.DefaultCellStyle.BackColor = Nothing
            End If
        Next

    End Sub

    Private Sub chkRouteCity_CheckedChanged(sender As Object, e As EventArgs) Handles chkRouteCity.CheckedChanged
        cmbRouteCity.Enabled = chkRouteCity.Checked
    End Sub
End Class