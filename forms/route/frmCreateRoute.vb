Public Class frmCreateRoute
    Dim objOders As New cls_tblOrder
    Dim objOrderItems As New cls_tblOrderItems
    Dim objRoute As New cls_tblRoute
    Dim objRouteItems As New cls_tblRouteOrders
    Dim objCustomer As New cls_tblCustomer
    Dim objTruck As New cls_tblMasterItems

    Dim SelectedRoute As String = ""
    Dim ShowingRoute As String = ""

    Dim SelectedDate As Date = Now
    Dim ShowingDate As Date = Now
    Dim SelectedRoute_orignal As String = ""

    Dim EditRouteID As Integer = 0
    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Dim objSet As New cls_tblSettings
    Dim objtCustomer As New cls_t_tblCustomer
    Sub LoadRouteCity()
        Dim dt As DataTable = objtCustomer.Selection(cls_t_tblCustomer.SelectionType.DISTINCT_ROUTECITY)
        Dim dr As DataRow = dt.NewRow
        dr(0) = "--SELECT--"
        dt.Rows.InsertAt(dr, 0)
        cmbRouteCity.DataSource = dt
        cmbRouteCity.DisplayMember = "routecity"
        cmbRouteCity.ValueMember = "routecity"

    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Clear()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub OpenEdtiRoute(ByVal _routeId As Integer)
        Try
            Dim RouteDetails As cls_tblRoute.Fields = objRoute.Selection_One_Row(_routeId)
            Dim dtRouteOrder As DataTable = objRouteItems.Selection(cls_tblRouteOrders.SelectionType.All, "RouteID =" & _routeId.ToString)

            Dim SlCounter As Integer = 1

            txtRouteName.Text = RouteDetails.OtherInfos
            cmbDriver.Text = RouteDetails.Driver
            cmbTruck.Text = RouteDetails.Truck

             
            SelectedRoute_orignal = ""
            SelectedRoute = RouteDetails.RouteCity
            SelectedDate = RouteDetails.OrderDate


            If dtpFrom.Value > RouteDetails.RouteDate Then
                dtpFrom.Value = RouteDetails.RouteDate.Date
            End If
            If dtpTo.Value < RouteDetails.RouteDate Then
                dtpTo.Value = RouteDetails.RouteDate.Date
            End If



            For Each drRouteOrder As DataRow In (From dr As DataRow In dtRouteOrder.Rows
                                                 Order By dr("sl")
                                                 Select dr).ToArray
                Try
                    Dim OrderDetails As cls_tblOrder.Fields = objOders.Selection_One_Row(drRouteOrder("OrderId"))
                    Dim CustomerDetails As cls_tblCustomer.Fields = objCustomer.Selection_One_Row(OrderDetails.CutomerId)

                    dgRouteCities.Rows.Add(OrderDetails.OrderId, _
                                                           OrderDetails.OrderNo, _
                                                           CustomerDetails.RouteCity, _
                                                           CustomerDetails.Route, _
                                                           CustomerDetails.CustomerName, _
                                                           OrderDetails.TotalItems)
                Catch ex As Exception
                End Try
            Next
            EditRouteID = _routeId
            CountCases()
            lblOrderTotal.Text = dgRouteCities.Rows.Count.ToString & " Orders"
            RefreshDG()
        Catch ex As Exception
            '//MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub




    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        cmbStatus.Enabled = chkStatus.Checked
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        'SelectedRoute = ""
        'ShowingRoute = ""

        'SelectedDate = Now
        'ShowingDate = Now
        RefreshDG()
    End Sub


    Sub RefreshDG()
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            SelectString = " AND a.[" & cls_tblOrder.FieldName.OrderId.ToString & "] not in (Select OrderId from tblRouteOrders where RouteID<>" & EditRouteID.ToString & ")"

            If chkStatus.Checked Then
                SelectString += " AND a.[" & cls_tblOrder.FieldName.Status.ToString & "]=@status"
                pp.Add(New SqlParameter("@status", cmbStatus.Text))
            Else
                SelectString += " AND a.[" & cls_tblOrder.FieldName.Status.ToString & "] in ('Open','Fulfilled','Picked')"
            End If

            If chkDateRange.Checked Then 'And SelectedRoute.Trim = ""
                SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] Between @d1 and @d2"
                pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            End If
            'SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] < Getdate()"

            'If SelectedRoute.Trim <> "" Then
            '    SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] Between @d1 and @d2"
            '    pp.Add(New SqlParameter("@d1", SelectedDate.Date))
            '    pp.Add(New SqlParameter("@d2", SelectedDate.Date.AddDays(1).AddSeconds(-1)))

            '    Dim cnt = 0
            '    Try
            '        cnt = SelectedRoute_orignal.Split("/").Count
            '    Catch ex As Exception
            '    End Try
            '    If cnt > 1 Then
            '        Dim tmp_route As String = SelectedRoute_orignal.Replace("*", "").Split("/")(1).Trim
            '        SelectString += " AND (b.[" & cls_tblCustomer.FieldName.RouteCity.ToString & "] like '%" & tmp_route.Replace("*", "") & "%' OR b.[" & cls_tblCustomer.FieldName.RouteCity.ToString & "] like '%" & SelectedRoute & "%')"
            '    Else
            '        SelectString += " AND b.[" & cls_tblCustomer.FieldName.RouteCity.ToString & "] like '%" & SelectedRoute & "%'"
            '    End If
            'End If

            Dim selectedOrders As String = "-1"
            For Each dr As DataGridViewRow In dgRouteCities.Rows
                selectedOrders += "," & dr.Cells(0).Value.ToString
            Next
            If dgRouteCities.Rows.Count > 0 Then
                If SelectedRoute.Trim <> "" Then
                    SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderId.ToString & "] not in (" & selectedOrders & ")"
                End If
            End If

            If chkRouteCity.Checked Then
                If cmbRouteCity.SelectedIndex >= 1 Then
                    SelectString += " AND ISNULL(f.[" & cls_tblCustomer_BOL.FieldName.RouteCity.ToString & "],b.[" & cls_tblCustomer.FieldName.RouteCity.ToString & "]) =@RC"
                    pp.Add(New SqlParameter("@RC", cmbRouteCity.Text))
                End If
            End If

            ShowingRoute = SelectedRoute
            ShowingDate = SelectedDate
            dgOrder.DataSource = Nothing
            Dim dt As DataTable = objOders.Selection(cls_tblOrder.SelectionType.ReviewOrder, SelectString, pp)
            Dim selecteRow As Integer = 0
            Dim topRow As Integer = 0
            Try
                topRow = dgOrder.FirstDisplayedScrollingRowIndex
                selecteRow = dgOrder.SelectedRows(0).Index
            Catch ex As Exception
            End Try

            Try

                dgOrder.DataSource = dt
            Catch ex As Exception
                If dgRouteCities.Rows.Count > 0 Then
                    MsgBox("No more orders for this route", MsgBoxStyle.Information, "Info")
                Else
                    'MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
                End If

            End Try
            dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.CreatedBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CutomerId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderAmount.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderSl.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusDate.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.UpdatedBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).HeaderText = "Total Items"

            dgOrder.Columns("CustomerName").HeaderText = "Customer Name"
            dgOrder.Columns("RouteCity").HeaderText = "Route City"
            'dgOrder.Columns("").HeaderText = ""

            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            Try
                dgOrder.FirstDisplayedScrollingRowIndex = topRow
                dgOrder.SelectedRows(0).Selected = False
            Catch ex As Exception
            End Try
            Try
                dgOrder.Rows(selecteRow).Selected = True
            Catch ex As Exception
            End Try
            Counter()
        Catch ex As Exception

        End Try
    End Sub

    Sub Counter()
        Dim c As Integer = 0
        For Each dr As DataGridViewRow In dgOrder.Rows
            c += dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value.ToString
        Next
        lblTotalOrder.Text = "Total : " & dgOrder.Rows.Count.ToString & " Order(s)        Total Qty: " & c.ToString '& " Case(s)"
    End Sub

    Private Sub frmCreateRoute_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadRouteCity()
        'chkStatus.Checked = True
        cmbStatus.SelectedIndex = 1
        chkDateRange.Checked = True
        'dtpFrom.Value = Today
        'dtpTo.Value = Today
        RefreshDG()
    End Sub


    Private Sub btnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOrder.Click
        Try

            Dim dr As DataGridViewRow = dgOrder.SelectedRows(0)

            If SelectedRoute <> "" And Not (dr.Cells("RouteCity").Value.ToString.Contains(SelectedRoute) OrElse SelectedRoute.Contains(dr.Cells("RouteCity").Value.ToString)) Then
                If MsgBox("Route not valid" & vbNewLine & "Do you want to continue (Y/N)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            If SelectedRoute <> "" And SelectedDate <> dr.Cells(cls_tblOrder.FieldName.OrderDate.ToString).Value Then
                If MsgBox("Date Not Valid" & vbNewLine & "Do you want to continue (Y/N)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            If dr.Cells(cls_tblOrder.FieldName.OrderDate.ToString).Value > Now Then
                If MsgBox("Order date/time greater than current date/time" & vbNewLine & "Do you want to continue (Y/N)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            dgRouteCities.Rows.Add(dr.Cells("OrderID").Value, _
                                                            dr.Cells("OrderNo").Value, _
                                                           dr.Cells("RouteCity").Value, _
                                                             dr.Cells("Route").Value, _
                                                             dr.Cells(cls_tblCustomer.FieldName.CustomerName.ToString).Value, _
                                                             dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value)

            Dim tmp_route As String = Microsoft.VisualBasic.Left(dr.Cells("RouteCity").Value.ToString.Replace("*", "").Split("/")(0).Trim, 2)
            Dim cnt = 0

            Try
                cnt = SelectedRoute_orignal.Split("/").Count
            Catch ex As Exception
            End Try

            If SelectedRoute = "" Then
                SelectedRoute_orignal = dr.Cells("RouteCity").Value
                SelectedRoute = tmp_route
            End If

            If cnt > 1 Then
                SelectedRoute_orignal = ""
                SelectedRoute = tmp_route
            End If

            SelectedDate = dr.Cells(cls_tblOrder.FieldName.OrderDate.ToString).Value
            If txtRouteName.Text = "" Then
                Dim strRN As String = SelectedRoute & " - " & Now.ToString("MMddyy")
                Dim strRN_ As String = ""
                Dim ic As Integer = 1

                Try 'LA - 010916
                    ic = objRoute.Selection(cls_tblRoute.SelectionType.All, "OtherInfos like '" & strRN & "%'").Rows.Count + 1
                Catch ex As Exception
                End Try
                strRN_ = strRN & " #" & ic.ToString

                txtRouteName.Text = strRN_
            End If


            dgOrder.Rows.Remove(dr)
            'If ShowingRoute <> SelectedRoute Then
            '    RefreshDG()
            'Else
            '    For Each dr As DataGridViewRow In dgOrder.SelectedRows
            '        If dr.Cells("RouteCity").Value.ToString.Contains(SelectedRoute) Then
            '            dgOrder.Rows.Remove(dr)
            '        End If
            '    Next
            'End If
            CountCases()
            lblOrderTotal.Text = dgRouteCities.Rows.Count.ToString & " Orders"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnLessOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLessOrder.Click
        Try
            dgRouteCities.Rows.Remove(dgRouteCities.SelectedRows(0))
            If dgRouteCities.Rows.Count = 0 Then
                SelectedRoute = ""
                SelectedRoute_orignal = ""
            End If
            RefreshDG()
            CountCases()
            lblOrderTotal.Text = dgRouteCities.Rows.Count.ToString & " Orders"
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgOrder_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellDoubleClick
        If Val(dgOrder.SelectedRows(0).Cells("OrderNo").Value.ToString) <> 0 Then
            Dim frm As New Form
            frm.Size = New Size(400, 600)
            frm.BackColor = Color.White
            frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            frm.StartPosition = FormStartPosition.CenterScreen
            Dim cnt As New cntlOrderView
            frm.Controls.Add(cnt)
            cnt.Dock = DockStyle.Fill
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.TopMost = False
            frm.ShowInTaskbar = False
            cnt.OpenOrder(Val(dgOrder.SelectedRows(0).Cells("orderID").Value.ToString))
            frm.ShowDialog()
        End If
    End Sub

    Sub CountCases()
        Dim orderids As String = "-1"
        For Each dr As DataGridViewRow In dgRouteCities.Rows
            orderids += "," & Val(dr.Cells(0).Value).ToString
        Next
        Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.UNIT_WISE_TOTAL, "a.OrderId in (" & orderids.ToString & ") group by b. UnitOfMeasure ")
        lblCaseTotal.Text = "Total : "
        For Each dr As DataRow In orderItems.Rows
            lblCaseTotal.Text += dr("Total").ToString & " " & dr("Unit").ToString & ", "
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRoute.Click
        If MsgBox("Are you Sure?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        SaveRoute(False)
    End Sub

    Sub SaveRoute(ByVal isPrint As Boolean)

        If txtRouteName.Text = "" Then
            MsgBox("Please enter a route name ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Try
            If cmbDriver.SelectedIndex = 0 Or cmbDriver.Text.Trim = "" Then
                MsgBox("Please Select a Driver ", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
        End Try

        Try
            If cmbTruck.SelectedIndex = 0 Or cmbTruck.Text.Trim = "" Then
                MsgBox("Please Select a Truck ", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
        End Try


        If dgRouteCities.Rows.Count = 0 Then
            MsgBox("please add some orders in this Route", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim conn As SqlConnection = Nothing
        Dim transact As SqlTransaction = Nothing
        Try
            Try
                If txtRouteName.Text.Split(":").Length > 1 Then
                    txtRouteName.Text = txtRouteName.Text.Split(":")(0) & ":" & cmbDriver.Text
                Else
                    txtRouteName.Text = txtRouteName.Text & ":" & cmbDriver.Text
                End If
            Catch ex As Exception
            End Try
            conn = (New clsConnection).connect
            Dim RouteDetails As cls_tblRoute.Fields
            Try
                If EditRouteID <> 0 Then
                    RouteDetails = objRoute.Selection_One_Row(EditRouteID)
                    objRouteItems.Delete_By_Select("[RouteID]=" & EditRouteID, Nothing)
                    objRoute.Delete_By_RouteId(EditRouteID)
                End If
            Catch ex As Exception
            End Try
            For Each dr As DataGridViewRow In dgRouteCities.Rows
                Try
                    If objRouteItems.Selection(cls_tblRouteOrders.SelectionType.All, "OrderID=" & dr.Cells("OrderID").Value).Rows.Count > 0 Then
                        If MessageBox.Show("Route already asigned for Order# : " & dr.Cells(1).Value & vbNewLine & "Do you want to continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next


            transact = conn.BeginTransaction

            'Dim RouteId As Integer = objRoute.Insert(Now, UserId, Now, UserId, Now, SelectedRoute, dgRouteCities.Rows.Count, SelectedDate, Val(lblCaseTotal.Text), cmbTruck.Text, cmbDriver.Text, txtRouteName.Text, "", conn, transact)
            Dim RouteId As Integer
            If EditRouteID <> 0 Then
                RouteId = objRoute.Insert(dtpFrom.Value, UserId, RouteDetails.CreatedOn, UserId, RouteDetails.CreatedOn, SelectedRoute, dgRouteCities.Rows.Count, SelectedDate, Val(lblCaseTotal.Text), cmbTruck.Text, cmbDriver.Text, txtRouteName.Text, "", conn, transact)
            Else
                RouteId = objRoute.Insert(dtpFrom.Value, UserId, Now, UserId, Now, SelectedRoute, dgRouteCities.Rows.Count, SelectedDate, Val(lblCaseTotal.Text), cmbTruck.Text, cmbDriver.Text, txtRouteName.Text, "", conn, transact)
            End If

            For Each dr As DataGridViewRow In dgRouteCities.Rows
                objRouteItems.Insert(dr.Index + 1, dr.Cells("OrderID").Value, RouteId, conn, transact)
            Next

            transact.Commit()
            MsgBox("Saved", MsgBoxStyle.Information, "Info")

            If isPrint Then
                frmRouteReport.RouteId = RouteId
                frmRouteReport.ShowDialog()
                'Try
                '    Dim obj As New clsRoutePrint
                '    obj.CreateRouteSheet(RouteId)
                'Catch ex As Exception
                '    MsgBox(ex.Message, MsgBoxStyle.Information, "info")
                'End Try
            End If

            Clear()
            RefreshDG()

        Catch ex As Exception
            Try
                transact.Rollback()
            Catch ex2 As Exception
            End Try
            MsgBox("Error :" & vbNewLine & ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Sub Clear()

        dgRouteCities.Rows.Clear()
        cmbTruck.Text = ""
        cmbDriver.Text = ""
        txtRouteName.Text = ""
        SelectedDate = Now
        SelectedRoute = ""
        SelectedRoute_orignal = ""
        EditRouteID = 0
        Try
            Dim dt As DataTable = objTruck.SelectDistinct(cls_tblMasterItems.FieldName.ItemValue, "[ItemName]='DRIVER'")
            Dim dr As DataRow = dt.NewRow
            dr(0) = "Select Driver"
            dt.Rows.InsertAt(dr, 0)
            cmbDriver.DataSource = dt
            cmbDriver.DisplayMember = "ItemValue"
            'cmbDriver.Text = ""
        Catch ex As Exception
        End Try
        Try
            Dim dt As DataTable = objTruck.SelectDistinct(cls_tblMasterItems.FieldName.ItemValue, "[ItemName]='TRUCK'")
            Dim dr As DataRow = dt.NewRow
            dr(0) = "Select Truck"
            dt.Rows.InsertAt(dr, 0)
            cmbTruck.DataSource = dt
            cmbTruck.DisplayMember = "ItemValue"
            'cmbTruck.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If dgRouteCities.RowCount > 1 And dgRouteCities.SelectedRows.Count > 0 Then
            If dgRouteCities.SelectedRows(0).Index <> 0 Then
                For Each dr As DataGridViewRow In dgRouteCities.SelectedRows
                    Dim drIndex As Integer = dr.Index
                    dgRouteCities.Rows.Remove(dr)
                    dgRouteCities.Rows.Insert(drIndex - 1, dr)
                    Try
                        dgRouteCities.SelectedRows(0).Selected = False
                    Catch ex As Exception
                    End Try
                    Try
                        dgRouteCities.Rows(drIndex - 1).Selected = True
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        If dgRouteCities.RowCount > 1 And dgRouteCities.SelectedRows.Count > 0 Then
            If dgRouteCities.SelectedRows(0).Index <> dgRouteCities.RowCount - 1 Then
                For Each dr As DataGridViewRow In dgRouteCities.SelectedRows
                    Dim drIndex As Integer = dr.Index
                    dgRouteCities.Rows.Remove(dr)
                    dgRouteCities.Rows.Insert(drIndex + 1, dr)
                    Try
                        dgRouteCities.SelectedRows(0).Selected = False
                    Catch ex As Exception
                    End Try
                    Try
                        dgRouteCities.Rows(drIndex + 1).Selected = True
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub btnSaveAndPrintRoute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndPrintRoute.Click
        If MsgBox("Are you Sure?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        SaveRoute(True)
    End Sub

    Private Sub dgOrder_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                ShowRouteMap(dgOrder.Rows(e.RowIndex).Cells("OrderID").Value)
            End If
        End If
    End Sub

    Sub ShowRouteMap(OrderId As Integer)
        Dim OrderDetails As cls_tblOrder.Fields = Nothing
        Dim CustomerDetails As cls_tblCustomer.Fields = Nothing
        Dim BOLDetails As cls_tblCustomer_BOL.Fields = Nothing
        Dim dtr As String = ""
        Dim hasBOL As Boolean = False

        Try
            OrderDetails = objOders.Selection_One_Row(OrderId)
        Catch ex As Exception
        End Try
        Try
            CustomerDetails = objCustomer.Selection_One_Row(OrderDetails.CutomerId)
        Catch ex As Exception
        End Try
        Try
            Dim itemsl As Integer = OrderDetails.BOLAddressID ' objCustomerBOL.SelectScalar(cls_tblCustomer_BOL.FieldName.ItemSl, "OrderId = " & OrderId)
            BOLDetails = objCustomerBOL.Selection_One_Row(itemsl)
            hasBOL = True
        Catch ex As Exception
        End Try

        If hasBOL Then
            dtr += "&q=" & BOLDetails.DropOffPoint.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
        Else
            dtr += "&q=" & CustomerDetails.CustomerName.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
        End If

        frmViewMap.Show()
        frmViewMap.LoadMap(dtr, "Place")
    End Sub

    Private Sub chkRouteCity_CheckedChanged(sender As Object, e As EventArgs) Handles chkRouteCity.CheckedChanged
        cmbRouteCity.Enabled = chkRouteCity.Checked
    End Sub
End Class