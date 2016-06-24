Public Class frmTodaysScheduledOrdersView

    Dim objOrderItems As New cls_tblOrderScheduleItems

    Dim objOrders As New cls_tblOrderSchedule

    ' Dim ScheduleDate As Date = Now
    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString, "", "ALL")
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        cmbStatus.Enabled = chkStatus.Checked
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshDG()
    End Sub

    Sub RefreshDG()
        Try
            ExecuteAdapter("Update tblOrderSchedule set Repeat = 1 where [Repeat]=0")
        Catch ex As Exception
        End Try
        Try
            'Dim SSS As String = "(a.startdate = a.enddate or CONVERT(date,@d1) between a.startdate and a.enddate) and ((a.[ScheduleType]='DAILY' and (a.[Repeat] =1 or DATEDIFF(DAY,a.[StartDate] ,CONVERT(date,@d1)) % a.[Repeat] = 0)) or (a.[ScheduleType]='WEEKLY' and a.[ScheduleInfo] like '%' + (DATENAME(dw, CAST(DATEPART(m, GETDATE()) AS VARCHAR) + '/'  + CAST(DATEPART(d, @d1) AS VARCHAR) + '/' + CAST(DATEPART(yy, getdate()) AS VARCHAR))) + '%') OR (a.[ScheduleType]='MONTHLY' and (a.[Repeat] =1 or DATEDIFF(Month,a.[StartDate] ,CONVERT(date,@d1)) % a.[Repeat] = 0) and DATEPART (day,a.[StartDate]) = DATEPART (day,@d1))) and a.OrderId not in (Select ScheduledOrderId from tblOrder where Convert(Date,OrderDate)=@d1)"
            Dim SelectTable As String = ""

            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter) 

            'pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date)) 

            Dim cl As Integer = 1
            Dim d1 As Date = dtpFrom.Value.Date
            While d1 <= dtpTo.Value.Date
                If SelectTable <> "" Then
                    SelectTable += " UNION ALL "
                End If
                SelectTable += " select @d" & cl.ToString & " dddddd "
                pp.Add(New SqlParameter("@d" & cl.ToString, d1))
                cl += 1
                d1 = d1.AddDays(1)
            End While

            If chkCustomer.Checked Then
                If cmbCustomer.SelectedIndex = -1 Then
                    SelectString += " AND b.[" & cls_tblCustomer.FieldName.CustomerName.ToString & "] like '%' + @CN + '%' "
                    pp.Add(New SqlParameter("@CN", cmbCustomer.Text)) 
                ElseIf cmbCustomer.SelectedIndex >= 1 Then
                    SelectString += " AND a.[" & cls_tblOrderSchedule.FieldName.CutomerId.ToString & "] =@CID"
                    pp.Add(New SqlParameter("@CID", cmbCustomer.SelectedValue)) 
                End If
            End If
            SelectTable = "RIGHT OUTER JOIN (" & SelectTable & ")  fff on (a.startdate = a.enddate or CONVERT(date,fff.dddddd) between a.startdate and a.enddate) and ((a.[ScheduleType]='DAILY' and (a.[Repeat] =1 or DATEDIFF(DAY,a.[StartDate] ,CONVERT(date,fff.dddddd)) % a.[Repeat] = 0)) or (a.[ScheduleType]='WEEKLY' and a.[ScheduleInfo] like '%' + (DATENAME(dw, fff.dddddd)) + '%') OR (a.[ScheduleType]='MONTHLY' and (a.[Repeat] =1 or DATEDIFF(Month,a.[StartDate] ,CONVERT(date,fff.dddddd)) % a.[Repeat] = 0) and DATEPART (day,a.[StartDate]) = DATEPART (day,fff.dddddd))) and a.OrderId not in (Select ScheduledOrderId from tblOrder where Convert(Date,OrderDate)=fff.dddddd)  "
            dgOrder.DataSource = Nothing

            Dim selecteRow As Integer = 0
            Dim topRow As Integer = 0
            Try
                topRow = dgOrder.FirstDisplayedScrollingRowIndex
                selecteRow = dgOrder.SelectedRows(0).Index
            Catch ex As Exception
            End Try


            dgOrder.DataSource = Nothing
            For Each c As DataGridViewColumn In dgOrder.Columns
                c.Frozen = False
            Next
            Dim dt As DataTable = objOrders.Selection(cls_tblOrderSchedule.SelectionType.ScheduledOrder, SelectTable & " Where a.OrderId is not null " & SelectString, pp)
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
            dgOrder.Columns("ColumnConfirm").DisplayIndex = 0

            ' dgOrder.Columns("Drop Off Point").DisplayIndex = 13
            dgOrder.Columns("CustomerName").Frozen = True
            Counter()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub
    

    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCustomers()

        chkStatus.Checked = False
        chkCustomer.Checked = False
        cmbStatus.SelectedIndex = 1


        dtpFrom.Value = Today
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

    Private Sub dgOrder_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                'If MsgBox("Are you sure (y/n)?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.Yes Then
                Dim frm As New frmOrderConfirmAdd
                frm.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value, dgOrder.SelectedRows(0).Cells("Schedule Date").Value)
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    RefreshDG()
                End If
                'End If
            End If
        End If
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

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub


End Class