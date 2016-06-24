Public Class frmScheduleOrderEdit
    Dim objCustomer As New cls_tblCustomer
    Dim objCustomer_BOL As New cls_tblCustomer_BOL

    Dim objOrderSchedule As New cls_tblOrderSchedule
    Dim objOrderScheduleItems As New cls_tblOrderScheduleItems


    Dim objProducts As New cls_tblProducts
    Dim objTemplate As New cls_tblTemplate
    Dim objTemplateItems As New cls_tblTemplateItems

    Dim BOLAddressID As Integer = 0

    Public EditScheduleOrderId As Integer = 0

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        LoadCustomers()
        ClearAll()
    End Sub
 
    Sub OpenOrder(ByVal orderID As String)
        EditScheduleOrderId = orderID
        Try
            Dim order As cls_tblOrderSchedule.Fields = objOrderSchedule.Selection_One_Row(orderID)
            txtOrderNo.Text = order.OrderNo
            txtOrderDate.Value = order.OrderDate
            cmbCustomer.SelectedValue = order.CutomerId
            cmbStatus.Text = order.Status
            txtComment.Text = order.Comments

            rdbDaily.Checked = False
            rdbWeekly.Checked = False
            rdbMonthly.Checked = False

            Select Case order.ScheduleType
                Case "DAILY"
                    rdbDaily.Checked = True
                Case "WEEKLY"
                    rdbWeekly.Checked = True
                Case "MONTHLY"
                    rdbMonthly.Checked = True
            End Select
            txtEndDate.Value = order.EndDate
            txtStartDate.Value = order.StartDate
            CheckBox2.Checked = order.EndDate <> "1/1/2100"
            txtRepeat.Value = order.Repeat

            For Each chk As CheckBox In (From c As Control In Panel2.Controls
                                        Select c
                                        Order By c.Tag)
                chk.Checked = order.ScheduleInfo.Contains(chk.Text)
            Next

            Dim orderItems As DataTable = objOrderScheduleItems.Selection(cls_tblOrderScheduleItems.SelectionType.All, "OrderId=" & orderID.ToString & " Order by sl")
            For Each drProduct As DataRow In orderItems.Rows
                dgItemList.Rows.Add(drProduct(cls_tblOrderScheduleItems.FieldName.ProductId.ToString), _
                                    objProducts.SelectScalar(cls_tblProducts.FieldName.ProductName, "ProductID=" & drProduct(cls_tblOrderScheduleItems.FieldName.ProductId.ToString).ToString), _
                                    drProduct(cls_tblOrderScheduleItems.FieldName.Qty.ToString), "", "", "", _
                                    drProduct(cls_tblOrderScheduleItems.FieldName.Fresh.ToString), drProduct(cls_tblOrderScheduleItems.FieldName.Frozen.ToString), drProduct(cls_tblOrderScheduleItems.FieldName.ItemId.ToString))
            Next
            TotalCaseQty()
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString)
    End Sub

    Dim OrderSl As Integer = 0

    Sub LoadOrderSl()
        OrderSl = objOrderSchedule.MaxID_PlusOne(1)
        txtOrderNo.Text = Now.ToString("yyyyMM") & "/" & OrderSl.ToString("000")
    End Sub

    Dim LastOption As Integer = -1
    

    Sub TotalCaseQty()
        Dim total As Integer = 0
        For Each drDG As DataGridViewRow In dgItemList.Rows
            drDG.Cells("QTY").Value = Val(drDG.Cells("Fresh").Value) + Val(drDG.Cells("Frozen").Value)
            total += Val(drDG.Cells("Fresh").Value) + Val(drDG.Cells("Frozen").Value)
            If Val(drDG.Cells("Fresh").Value) >= 10 Then
                drDG.Cells("Fresh").Style.BackColor = Color.LavenderBlush
            ElseIf Val(drDG.Cells("Fresh").Value) >= 5 Then
                drDG.Cells("Fresh").Style.BackColor = Color.LightYellow
            ElseIf Val(drDG.Cells("Fresh").Value) > 0 Then
                drDG.Cells("Fresh").Style.BackColor = Color.FromArgb(192, 255, 192)
            Else
                drDG.Cells("Fresh").Style.BackColor = Color.White
            End If
            If Val(drDG.Cells("Frozen").Value) >= 10 Then
                drDG.Cells("Frozen").Style.BackColor = Color.LavenderBlush
            ElseIf Val(drDG.Cells("Frozen").Value) >= 5 Then
                drDG.Cells("Frozen").Style.BackColor = Color.LightYellow
            ElseIf Val(drDG.Cells("Frozen").Value) > 0 Then
                drDG.Cells("Frozen").Style.BackColor = Color.FromArgb(192, 255, 192)
            Else
                drDG.Cells("Frozen").Style.BackColor = Color.White
            End If
        Next
        lblTotalCases.Text = total.ToString
    End Sub

    Private Sub frmOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'txtOrderDate.MinDate = Today.Date.AddDays(-1)
        SetDisplayIndex()
    End Sub

    Sub SetDisplayIndex()
        dgItemList.Columns(6).DisplayIndex = 2
        dgItemList.Columns(7).DisplayIndex = 3
    End Sub

    Private Sub cmbCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.Leave
        clientChanged()
    End Sub
    Private Sub cmbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectedIndexChanged
        clientChanged()
    End Sub

    Dim lastOrderId As Integer = 0
    Dim lastOrderdate As Date = Now
    Sub clientChanged()
        Try
            'Load Customer Address Route

            txtRouteCity.Text = objCustomer.Selection_One_Row(cmbCustomer.SelectedValue).RouteCity

            'If No Customer Found, then throw error

            If cmbCustomer.Text.Trim = "" Then
                Throw New Exception("Client Not found")
            End If

            'Load Last Order Number and Details 
            lblLastOrder.Text = ""
            lastOrderId = 0

            Try

                Dim cd As cls_tblCustomer.Fields = objCustomer.Selection_One_Row(cmbCustomer.SelectedValue)
                BOLAddressID = 0
                If cd.BOL = "YES" Then
                    'BOLAddressID = objCustomer_BOL.Selection(cls_tblCustomer_BOL.SelectionType.All, " CustomerID=" & cmbCustomer.SelectedValue.ToString & " Order by Itemsl desc").Rows(0).Item("ItemSl")
                    BOLAddressID = objCustomer.GetBolID(cmbCustomer.SelectedValue)
                End If
                If BOLAddressID = 0 Then
                    btnShowBOLAddress.Visible = False
                    btnLinkAddress.BackColor = Nothing
                    btnLinkAddress.Text = "Link BOL Drop-Off"
                    btnLinkAddress.UseVisualStyleBackColor = True
                Else
                    btnShowBOLAddress.Visible = True
                    btnLinkAddress.BackColor = Color.Green
                    btnLinkAddress.Text = "Unlink BOL Drop-Off"
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
            txtRouteCity.Text = ""
        End Try
    

    End Sub

    Private Sub dgItemList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 5 Then
                dgItemList.Rows.Remove(dgItemList.Rows(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub dgItemList_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellEndEdit
        Try
            If e.ColumnIndex = 2 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Then
                If Val(dgItemList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) > 0 Then
                    dgItemList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Val(dgItemList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                Else
                    dgItemList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                End If
                TotalCaseQty()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnCreateCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateCustomer.Click
        Dim frm As New frmCustomerAdd
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim custID As Integer = cmbCustomer.SelectedValue
            LoadCustomers()
            cmbCustomer.SelectedValue = custID
        End If
    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click
        Dim frm As New frmOrderItemAdd
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each dgrProduct As DataGridViewRow In frm.dgProduct.SelectedRows
                Dim pid As Integer = dgrProduct.Cells(0).Value
                Dim pname As String = dgrProduct.Cells(1).Value
                Dim isAlready As Integer = 0
                For Each dgrItem As DataGridViewRow In dgItemList.Rows
                    If dgrItem.Cells(0).Value = pid Then
                        isAlready += 1
                    End If
                Next

                isAlready = 0

                If isAlready = 0 Then
                    dgItemList.Rows.Add(pid, pname, 0, "", "", "", 0, 0)
                End If
            Next
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnAddOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkAddress.Click
        If BOLAddressID = 0 Then
            Dim frm As New frmBolAddress
            frm.CustomerID = -1
            frm.OrderId = -1
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                BOLAddressID = frm.txtDropOffPoint.SelectedValue
                btnLinkAddress.BackColor = Color.Green
                btnLinkAddress.Text = "Unlink BOL Drop-Off"
                btnShowBOLAddress.Visible = True
            End If
        Else
            btnShowBOLAddress.Visible = False
            BOLAddressID = 0
            btnLinkAddress.BackColor = Nothing
            btnLinkAddress.Text = "Link BOL Drop-Off"
            btnLinkAddress.UseVisualStyleBackColor = True
        End If
    End Sub


    Private Sub btnPostOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostOrder.Click
      
        If cmbCustomer.SelectedIndex <= 0 Then
            MsgBox("Select valid Customer of the Order", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If


        LoadOrderSl()


        Dim endadte As Date = Now
        If txtEndDate.Enabled Then
            endadte = txtEndDate.Value.Date
        Else
            endadte = "01/01/2100"
        End If

        Dim WeekDays As String = ""
        Dim stype As String = ""
        Select Case True
            Case rdbDaily.Checked
                stype = "DAILY"
            Case rdbWeekly.Checked
                stype = "WEEKLY"
            Case rdbMonthly.Checked
                stype = "MONTHLY"
        End Select
        If Panel2.Enabled Then
            For Each chk As CheckBox In (From c As Control In Panel2.Controls
                                         Select c
                                         Order By c.Tag)
                If chk.Checked Then
                    If WeekDays <> "" Then
                        WeekDays &= ","
                    End If
                    WeekDays &= chk.Text
                End If
            Next
            If WeekDays = "" Then
                MsgBox("Please select a day", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
        Dim rep As Integer = 1
        If txtRepeat.Enabled Then
            rep = txtRepeat.Value
        End If

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            'If Val(lblTotalCases.Text) = 0 And cmbStatus.Text <> "No Order" Then
            '    MsgBox("Please enter some quantity", MsgBoxStyle.Information, "Info")
            '    Exit Sub
            'End If

            Dim order As cls_tblOrderSchedule.Fields = objOrderSchedule.Selection_One_Row(EditScheduleOrderId)
            Dim OrderId As Integer = objOrderSchedule.Update(EditScheduleOrderId, txtOrderNo.Text, OrderSl, txtOrderDate.Value, txtOrderDate.Value, cmbCustomer.SelectedValue, lblTotalCases.Text, 0, order.CreatedDate, order.CreatedBy, Now, UserId, cmbStatus.Text, Now, UserId, order.Remarks, txtComment.Text, Session, UserBranchID, BOLAddressID, stype, txtStartDate.Value.Date, WeekDays, rep, endadte, conn, transac)
            Dim CountSl As Integer = 1

            Dim keepsl As String = "-1"
            For Each drItem As DataGridViewRow In dgItemList.Rows
                Dim ItemId As Integer = 0
                Try
                    ItemId = drItem.Cells("ColumnItemId").Value
                Catch ex As Exception
                End Try
                If ItemId > 0 Then
                    If CheckBox1.Checked Then
                        ' If drItem.Cells(2).Value > 0 Then
                        objOrderScheduleItems.Update(ItemId, OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                        CountSl += 1
                        ' End If
                    Else
                        If drItem.Cells(2).Value > 0 Then
                            objOrderScheduleItems.Update(ItemId, OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                            CountSl += 1
                        End If
                    End If
                Else
                    If CheckBox1.Checked Then
                        ' If drItem.Cells(2).Value > 0 Then
                        ItemId = objOrderScheduleItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                        CountSl += 1
                        ' End If
                    Else
                        If drItem.Cells(2).Value > 0 Then
                            ItemId = objOrderScheduleItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                            CountSl += 1
                        End If
                    End If
                End If
                If keepsl <> "" Then
                    keepsl += ","
                End If
                keepsl += ItemId.ToString


            Next
            objOrderScheduleItems.Delete_By_SELECT(" ItemId Not In (" & keepsl & ") and OrderId=" & OrderId.ToString, Nothing, conn, transac)
            transac.Commit()

            'Try
            '    Dim com As New SqlCommand("Update tblCustomer set BOL='YES' where customerid=" & cmbCustomer.SelectedValue.ToString, conn)
            '    com.ExecuteNonQuery()
            'Catch ex As Exception
            'End Try

            ShowOrderDialog(OrderId, "Saved. Order Id : " & OrderId.ToString)
            ' MsgBox("Saved", MsgBoxStyle.Information, "Info")
            ClearAll()
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            Try
                transac.Rollback()
            Catch ex2 As Exception
                MsgBox(ex2.Message, MsgBoxStyle.Information, "Info")
            End Try
        Finally
            conn.Close()
            objConn.Dispose()
            conn.Dispose()
            transac.Dispose()
        End Try
    End Sub

    Sub ClearAll()

        dgItemList.Rows.Clear()
        txtOrderDate.Value = Today
        txtOrderNo.Text = ""
        cmbCustomer.SelectedIndex = 0
        cmbStatus.SelectedIndex = 1
        LastOption = 0
        lblTotalCases.Text = 0
        LoadOrderSl()
        lblLastOrder.Text = ""
        lastOrderId = 0
        txtComment.Text = ""
        BOLAddressID = 0
        btnLinkAddress.BackColor = Nothing
        btnLinkAddress.Text = "Link BOL Drop-Off"
        btnLinkAddress.UseVisualStyleBackColor = True
        btnShowBOLAddress.Visible = False
    End Sub

    Private Sub btnCreateProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateProduct.Click
        Dim frm As New frmProductsAdd
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub lblLastOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLastOrder.Click
        If lastOrderId <> 0 Then
            ShowOrderDialog(lastOrderId, "")
        End If
    End Sub

    Sub ShowOrderDialog(ByVal _OrderId As Integer, ByVal title As String)
        Dim frm As New Form
        frm.Size = New Size(500, 600)
        frm.Text = title
        frm.BackColor = Color.White
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        frm.StartPosition = FormStartPosition.CenterScreen
        Dim cnt As New cntlScheduledOrderView
        frm.Controls.Add(cnt)
        cnt.Dock = DockStyle.Fill
        frm.MinimizeBox = False
        frm.MaximizeBox = False
        frm.TopMost = False
        frm.ShowInTaskbar = False
        cnt.OpenOrder(_OrderId)
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoOrder.Click
        If cmbStatus.SelectedIndex = 0 Then
            MsgBox("Select valid status of the Order", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cmbCustomer.SelectedIndex <= 0 Then
            MsgBox("Select valid Customer of the Order", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtOrderDate.Value = lastOrderdate.Date Then
            If MsgBox("There is already an order for this customer on this date. " & vbNewLine & "Are you sure?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        LoadOrderSl()
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            ' Dim OrderId As Integer = objOrderSchedule.Insert(txtOrderNo.Text, OrderSl, txtOrderDate.Value, txtOrderDate.Value, cmbCustomer.SelectedValue, lblTotalCases.Text, 0, Now, UserId, Now, UserId, "No Order", Now, UserId, "", txtComment.Text, Session, UserBranchID, BOLAddressID, conn, transac)
            transac.Commit()
            MsgBox("Saved", MsgBoxStyle.Information, "Info")
            ClearAll()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            Try
                transac.Rollback()
            Catch ex2 As Exception
                MsgBox(ex2.Message, MsgBoxStyle.Information, "Info")
            End Try
        Finally
            conn.Close()
            objConn.Dispose()
            conn.Dispose()
            transac.Dispose()
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub frmOrderAdd_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOrderHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnOrderHistory.Click
        Dim frm As New frmOrdersHistory
        frm.CustomerID = cmbCustomer.SelectedValue
        frm.ShowDialog()
    End Sub

    Private Sub btnShowBOLAddress_Click(sender As System.Object, e As System.EventArgs) Handles btnShowBOLAddress.Click
        Dim frm As New frmBolAddress
        frm.CustomerID = -1
        frm.OrderId = -1
        frm.txtDropOffPoint.SelectedValue = BOLAddressID
        frm.txtDropOffPoint.Enabled = False
        frm.btnSave.Visible = False
        frm.Button1.Visible = False
        frm.Button2.Visible = False
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdbDaily.CheckedChanged, rdbWeekly.CheckedChanged, rdbMonthly.CheckedChanged
        Panel2.Enabled = rdbWeekly.Checked
        txtRepeat.Enabled = rdbDaily.Checked Or rdbMonthly.Checked
        Label13.Text = IIf(rdbDaily.Checked, "Days", IIf(rdbMonthly.Checked, "Months", Label13.Text))
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        txtEndDate.Enabled = CheckBox2.Checked
    End Sub
End Class