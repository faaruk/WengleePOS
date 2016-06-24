Public Class frmViewRoute

    Dim objRoutes As New cls_tblRoute
    Dim objRouteOrders As New cls_tblRouteOrders
    Dim objUserRules As New cls_tblUserRules
    Dim objOrder As New cls_tblOrder
    Dim objCustomer As New cls_tblCustomer
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.CreateRoute, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Dim frm As New frmCreateRoute
        frm.ShowDialog()
        LoadRoutes()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.CreateRoute, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Try
            Dim frm As New frmCreateRoute
            frm.OpenEdtiRoute(DataGridView1.SelectedRows(0).Cells("RouteId").Value)
            frm.ShowDialog()
            LoadRoutes()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.CreateRoute, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            objRouteOrders.Delete_By_Select("[RouteID]=" & DataGridView1.SelectedRows(0).Cells("RouteId").Value.ToString)
            objRoutes.Delete_By_RouteId(DataGridView1.SelectedRows(0).Cells("RouteId").Value)
            MsgBox("Deleted", MsgBoxStyle.Information, "Info")
            LoadRoutes()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub frmViewRoute_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadRouteCity()
        LoadRoutes()

    End Sub

    Sub LoadRoutes()
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            If chkDateRange.Checked Then
                SelectString += " AND [" & cls_tblRoute.FieldName.RouteDate.ToString & "] Between @d1 and @d2"
                pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            End If
            SelectString += " AND a.[TotalOrder]>0"

            If chkRouteCity.Checked Then
                If cmbRouteCity.SelectedIndex >= 1 Then
                    SelectString += " AND a.[RouteCity] =@RC"
                    pp.Add(New SqlParameter("@RC", cmbRouteCity.Text))
                End If
            End If

            DataGridView1.DataSource = objRoutes.Selection(cls_tblRoute.SelectionType.Review, SelectString, pp)
            DataGridView1.Columns("RouteId").Visible = False
            DataGridView1.Columns("OrderDate").Visible = False
            'DataGridView1.Columns("CreatedBy").Visible = False
            DataGridView1.Columns("CreatedOn").Visible = False
            'DataGridView1.Columns("UpdatedBy").Visible = False
            'DataGridView1.Columns("UpdatedOn").Visible = False
            DataGridView1.Columns("Comments").Visible = False
            DataGridView1.Columns("RouteCity").HeaderText = "Route"
            DataGridView1.Columns("TotalOrder").HeaderText = "Total Orders"
            DataGridView1.Columns("TotalItems").HeaderText = "Total Items"
            DataGridView1.Columns("OrderDate").HeaderText = "Order Date"
            DataGridView1.Columns("OrderDate").DefaultCellStyle.Format = "MM/dd/yyyy"
            DataGridView1.Columns("RouteDate").DefaultCellStyle.Format = "MM/dd/yyyy"
            DataGridView1.Columns("RouteDate").HeaderText = "Route Date"
            DataGridView1.Columns("OtherInfos").HeaderText = "Route Name"
            '   DataGridView1.Columns("OtherInfos").DisplayIndex = 1
            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            'For Each c As DataGridViewColumn In DataGridView1.Columns

            'Next


            Counter()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Sub Counter()
        'Dim c As Integer = 0
        'For Each dr As DataGridViewRow In DataGridView1.Rows
        '    c += dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value.ToString
        'Next
        lblTotalOrder.Text = "Total : " & DataGridView1.Rows.Count.ToString & " Shipment Route(s)" '        Total : " & c.ToString & " Case(s)"
    End Sub
    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadRoutes()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Try
            Try
                CntlRouteView1.OpenRoute(DataGridView1.SelectedRows(0).Cells("RouteId").Value)
            Catch ex As Exception
                CntlRouteView1.Clear()
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then

            If e.ColumnIndex = 0 Then
                frmRouteReport.RouteId = DataGridView1.SelectedRows(0).Cells("RouteId").Value
                frmRouteReport.ShowDialog()
                'try
                '    dim obj as new clsrouteprint
                '    obj.createroutesheetpreview(datagridview1.selectedrows(0).cells("routeid").value)
                'catch ex as exception
                '    msgbox(ex.message, msgboxstyle.information, "info")
                'end try

            ElseIf e.ColumnIndex = 1 Then
                frmStopageReport.RouteId = DataGridView1.SelectedRows(0).Cells("RouteId").Value
                frmStopageReport.ShowDialog()
                'Try
                '    Dim obj As New clsRoutePrint
                '    obj.CreateRouteSheet(DataGridView1.SelectedRows(0).Cells("RouteId").Value)
                'Catch ex As Exception
                '    MsgBox(ex.Message, MsgBoxStyle.Information, "info")
                'End Try
            ElseIf e.ColumnIndex = 2 Then
                Try
                    ShowRouteMap(DataGridView1.SelectedRows(0).Cells("RouteId").Value)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
                End Try
            End If
        End If
    End Sub

    Sub ShowRouteMap(RouteId As Integer)
        Dim dtRouteOrder As DataTable = objRouteOrders.Selection(cls_tblRouteOrders.SelectionType.All, "RouteID =" & RouteId.ToString)


        Dim drOrders As DataRow() = (From dr As DataRow In dtRouteOrder.Rows
                                             Order By dr("sl")
                                             Select dr).ToArray

        Dim OrderDetails As cls_tblOrder.Fields = Nothing
        Dim CustomerDetails As cls_tblCustomer.Fields = Nothing
        Dim BOLDetails As cls_tblCustomer_BOL.Fields = Nothing
        Dim c As Integer = 1
        Dim c2 As Integer = drOrders.Count
        Dim dtr As String = ""
        Dim sett As cls_tblSettings.Fields = objSet.Selection_One_Row()
        If sett.Address Is Nothing OrElse sett.Address.Trim = "" Then
            c = 0
            c2 = drOrders.Count - 1
        Else
            dtr += "&origin=" & sett.CompanyName.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & sett.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
        End If

        For Each drRouteOrder As DataRow In drOrders
            Dim hasBOL As Boolean = False
            Try
                OrderDetails = objOrder.Selection_One_Row(drRouteOrder("OrderId"))
            Catch ex As Exception
            End Try
            Try
                CustomerDetails = objCustomer.Selection_One_Row(OrderDetails.CutomerId)
            Catch ex As Exception
            End Try
            Try
                Dim itemsl As Integer = OrderDetails.BOLAddressID ' objCustomerBOL.SelectScalar(cls_tblCustomer_BOL.FieldName.ItemSl, "OrderId = " & drRouteOrder("OrderId").ToString)
                BOLDetails = objCustomerBOL.Selection_One_Row(itemsl)
                hasBOL = True
            Catch ex As Exception
            End Try

            Select Case c
                Case 0
                    If hasBOL Then
                        dtr += "&origin=" & BOLDetails.DropOffPoint.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    Else
                        dtr += "&origin=" & CustomerDetails.CustomerName.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    End If
                Case c2
                    If hasBOL Then
                        dtr += "&destination=" & BOLDetails.DropOffPoint.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    Else
                        dtr += "&destination=" & CustomerDetails.CustomerName.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    End If
                Case 1
                    If hasBOL Then
                        dtr += "&waypoints=" & BOLDetails.DropOffPoint.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    Else
                        dtr += "&waypoints=" & CustomerDetails.CustomerName.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    End If
                Case Else
                    If hasBOL Then
                        dtr += "|" & BOLDetails.DropOffPoint.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & BOLDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    Else
                        dtr += "|" & CustomerDetails.CustomerName.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Address.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.City.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.State.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & CustomerDetails.Zip.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
                    End If
            End Select
            c += 1
        Next
        frmViewMap.Show()
        frmViewMap.LoadMap(dtr & "&mode=driving", "Direction")
    End Sub


    Private Sub frmOrdersView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub chkRouteCity_CheckedChanged(sender As Object, e As EventArgs) Handles chkRouteCity.CheckedChanged
        cmbRouteCity.Enabled = chkRouteCity.Checked
    End Sub


    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If (DataGridView1.RowCount > 0) Then
            Dim frm As New Form
            frm.Size = New Size(1100, 600)
            frm.BackColor = Color.White
            frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            frm.StartPosition = FormStartPosition.CenterScreen
            Dim cnt As New cntlRouteView
            frm.Controls.Add(cnt)
            cnt.Dock = DockStyle.Fill
            frm.MinimizeBox = False
            frm.MaximizeBox = False
            frm.TopMost = False
            frm.ShowInTaskbar = True
            cnt.OpenRoute(DataGridView1.SelectedRows(0).Cells("RouteId").Value)
            frm.Show()
        End If
    End Sub

    Private Sub CntlRouteView1_Load(sender As System.Object, e As System.EventArgs) Handles CntlRouteView1.Load

        
    End Sub
    Sub LinkOrder()
        Try
            Dim objConn As New clsConnection
            Dim con As SqlConnection = objConn.connectTransfer
            Dim com As New SqlCommand("update a set a.OrderNumber = d.OrderNo  from dbWengleeTransferer .dbo.tblInvoices a left outer join dbWengleeTransferer .dbo.tblCustomers b on a.CustomerID = b.CustomerId  left outer join dbWenglee .dbo.tblCustomer c on a.CustomerID = c.CustomerID_Link collate SQL_Latin1_General_CP1_CI_AS or b.CustomerName = c.CustomerName  collate SQL_Latin1_General_CP1_CI_AS left outer join ( select OrderNo,CutomerId , OrderDate  from dbWenglee .dbo.tblOrder where OrderId in (  select MAX(OrderId) from dbWenglee .dbo.tblOrder group by CutomerId , OrderDate) ) d on c.CustomerID = d.CutomerId and CONVERT(date, a.InvoiceDate,101) =  CONVERT(date, d.OrderDate,101)  where a.OrderNumber is null and d.OrderNo is not null", con)
            com.CommandTimeout = 0
            com.ExecuteNonQuery()

            Dim objConn2 As New clsConnection
            Dim con2 As SqlConnection = objConn2.connect
            Dim com2 As New SqlCommand("update x set x.InvoiceNumber=y.InvoiceNumber, x.TotalCartons=y.TotalCartons from dbWengLee.dbo.tblOrder x inner join dbWengleeTransferer.dbo.tblInvoices y on X.OrderNo=Y.OrderNumber and CONVERT(date, y.InvoiceDate,101) =  CONVERT(date, x.OrderDate,101) where x.InvoiceNumber is null and y.OrderNumber is not null", con2)
            com2.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnLoadNcr_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadNcr.Click
        ProgressBar1.Visible = True
        RefreshTransfererDB()
        ProgressBar1.Step = 1
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 1000
        ProgressBar1.Value = 0
        For tmpRun As Integer = 0 To 1000 - 1
            System.Threading.Thread.Sleep(1)
            ProgressBar1.Value += 1
        Next
        LinkOrder()
        If (DataGridView1.RowCount > 0) Then
            ShowRouteMap(DataGridView1.SelectedRows(0).Cells("RouteId").Value)
        End If
        ProgressBar1.Visible = False
    End Sub
End Class