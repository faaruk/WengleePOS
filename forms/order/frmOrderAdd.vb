Public Class frmOrderAdd
    Dim objCustomer As New cls_tblCustomer
    Dim objCustomer_BOL As New cls_tblCustomer_BOL
    Dim objOrder As New cls_tblOrder
    Dim objOrderItems As New cls_tblOrderItems
    Dim objProducts As New cls_tblProducts
    Dim objTemplate As New cls_tblTemplate
    Dim objTemplateItems As New cls_tblTemplateItems
    Dim objStock As New cls_tblStock
    Dim TemplateId As String = "0"

    Dim BOLAddressID As Integer = 0


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        LoadCustomers()
        ClearAll()
        LoadTemplates()
        Try
            cmbTemplate.SelectedValue = objTemplate.SelectScalar(cls_tblTemplate.FieldName.TemplateId, "Remarks='DEFAULT'")
        Catch ex As Exception
            cmbTemplate.SelectedIndex = 1
        End Try
    End Sub

    Dim isloadingTemplayes As Boolean = False
    Sub LoadTemplates()
        Dim lastIndex As Integer = 0
        Try
            lastIndex = cmbTemplate.SelectedIndex
        Catch ex As Exception

        End Try
        Try
            isloadingTemplayes = True
            Dim cid As Integer = 0
            Try
                Dim selectedRowView As DataRowView = DirectCast(Me.cmbCustomer.SelectedItem, DataRowView)
                Dim customerName As String = Me.cmbCustomer.SelectedText
                cid = Me.cmbCustomer.SelectedValue

                'cid = cmbCustomer.SelectedValue
            Catch ex As Exception
            End Try
            TemplateId = "0"
            Dim dt As DataTable = objTemplate.Selection(cls_tblTemplate.SelectionType.ComboBox1, "CutomerId in (0," & cid.ToString & ")")
            If (cid.ToString <> "0") Then
                If (dt.Rows.Count > 1) Then
                    For Each drTemp As DataRow In dt.Rows
                        Dim _TemplateId As String = drTemp("TemplateId")
                        If (_TemplateId <> "1") Then
                            LoadAllItemsOnSelectCustomer(_TemplateId)
                            cmbTemplate.SelectedValue = _TemplateId
                            lastIndex = _TemplateId
                            TemplateId = _TemplateId
                        End If
                    Next
                Else
                    Dim _TemplateId As String = 1
                    LoadAllItemsOnSelectCustomer(_TemplateId)
                    cmbTemplate.SelectedValue = _TemplateId
                    lastIndex = _TemplateId

                End If
            End If

            Dim dr1 As DataRow = dt.NewRow
            dr1(0) = -1
            dr1(1) = "Default"
            dt.Rows.InsertAt(dr1, 0)
            Dim dr As DataRow = dt.NewRow
            dr(0) = -2
            dr(1) = "None"
            dt.Rows.InsertAt(dr, 0)


            cmbTemplate.DataSource = dt
            cmbTemplate.ValueMember = "TemplateId"
            cmbTemplate.DisplayMember = "TemplateName"

        Catch ex As Exception
        End Try
        Try
            'cmbTemplate.SelectedIndex = lastIndex
            cmbTemplate.SelectedValue = lastIndex
        Catch ex As Exception
            cmbTemplate.SelectedIndex = 1
        End Try
        isloadingTemplayes = False
        'LoadAllItems()
    End Sub
    Sub LoadAllItemsOnSelectCustomer(ByVal _index As String)

        dgItemList.Rows.Clear()

        Try
            Dim dt As DataTable = objTemplateItems.Selection(cls_tblTemplateItems.SelectionType.Products_wise, " TemplateId=" & _index & " order by a.[Sl]")
            For Each drProduct As DataRow In dt.Rows
                dgItemList.Rows.Add(drProduct(cls_tblProducts.FieldName.ProductId), _
                                    drProduct(cls_tblProducts.FieldName.ProductName), _
                                    0, "", "", "Delete", 0, 0)
            Next
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try

        LastOption = _index
        TotalCaseQty()

    End Sub

    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString, " AND [Status]='ACTIVE'")
    End Sub

    Dim OrderSl As Integer = 0

    Sub LoadOrderSl()
        OrderSl = objOrder.MaxID_PlusOne(1)
        txtOrderNo.Text = Now.ToString("yyyyMM") & "/" & OrderSl.ToString("000")
    End Sub

    Dim LastOption As Integer = -1
    Sub LoadAllItems()
        If LastOption <> cmbTemplate.SelectedValue Then

            If Val(lblTotalCases.Text) > 0 Then
                If MsgBox("Changing Template will erase all items from the list. Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Try
                        cmbTemplate.SelectedValue = LastOption
                    Catch ex As Exception
                    End Try
                    Exit Sub
                End If
            End If

            dgItemList.Rows.Clear()
            Select Case cmbTemplate.SelectedIndex
                Case 0
                    'Clear All
                Case 1
                    Dim dt As DataTable = objProducts.Selection(cls_tblProducts.SelectionType.All)
                    For Each drProduct As DataRow In dt.Rows
                        dgItemList.Rows.Add(drProduct(cls_tblProducts.FieldName.ProductId), _
                                            drProduct(cls_tblProducts.FieldName.ProductName), _
                                            0, "", "", "Delete", 0, 0)
                    Next
                    Try
                        dgItemList.SelectedCells(0).Selected = False
                    Catch ex As Exception
                    End Try
                Case Else
                    Try
                        Dim dt As DataTable = objTemplateItems.Selection(cls_tblTemplateItems.SelectionType.Products_wise, " TemplateId=" & cmbTemplate.SelectedValue.ToString & " order by a.[Sl]")
                        For Each drProduct As DataRow In dt.Rows
                            dgItemList.Rows.Add(drProduct(cls_tblProducts.FieldName.ProductId), _
                                                drProduct(cls_tblProducts.FieldName.ProductName), _
                                                0, "", "", "Delete", 0, 0)
                        Next
                        Try
                            dgItemList.SelectedCells(0).Selected = False
                        Catch ex As Exception
                        End Try
                    Catch ex As Exception
                    End Try
            End Select

            LastOption = cmbTemplate.SelectedValue
            TotalCaseQty()
        End If
    End Sub

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
        txtOrderDate.MinDate = Today.Date.AddDays(-1)
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
            lblNotes.Text = ""
            'txtRouteCity.Text = objCustomer.Selection_One_Row(cmbCustomer.SelectedValue).RouteCity
            'Load Customer Address Route
            Dim Customerfl As cls_tblCustomer.Fields = objCustomer.Selection_One_Row(cmbCustomer.SelectedValue)
            txtRouteCity.Text = Customerfl.RouteCity
            If Customerfl.Notes <> "" Then
                lblNotes.Text = "Notes: " & Customerfl.Notes
            End If

            'If No Customer Found, then throw error

            If cmbCustomer.Text.Trim = "" Then
                Throw New Exception("Client Not found")
            End If

            'Load Last Order Number and Details 
            lblLastOrder.Text = ""
            lastOrderId = 0
            Try
                Dim dt As DataTable = objOrder.Selection(cls_tblOrder.SelectionType.All, "OrderID in (Select Max(orderId) from [tblOrder] where CutomerId=@CutomerId)", New List(Of SqlParameter) From {New SqlParameter("@CutomerId", cmbCustomer.SelectedValue)})
                If dt.Rows.Count > 0 Then
                    lastOrderId = dt.Rows(0).Item(cls_tblOrder.FieldName.OrderId.ToString).ToString
                    lblLastOrder.Text = "Last Order No :" & dt.Rows(0).Item(cls_tblOrder.FieldName.OrderNo.ToString).ToString & _
        "   Date :" & CDate(dt.Rows(0).Item(cls_tblOrder.FieldName.OrderDate.ToString)).ToShortDateString
                    lastOrderdate = CDate(dt.Rows(0).Item(cls_tblOrder.FieldName.OrderDate.ToString))
                Else
                    lblLastOrder.Text = ""
                End If
            Catch ex As Exception
            End Try

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
                    txtDOP.Text = ""
                    lblDOP.Visible = False
                    txtDOP.Visible = False
                Else
                    btnShowBOLAddress.Visible = True
                    btnLinkAddress.BackColor = Color.Green
                    btnLinkAddress.Text = "Unlink BOL Drop-Off"
                    Dim objCustomerBOL As New cls_tblCustomer_BOL
                    Dim fl As cls_tblCustomer_BOL.Fields = objCustomerBOL.Selection_One_Row(BOLAddressID)
                    lblDOP.Visible = True
                    txtDOP.Visible = True
                    txtDOP.Text = fl.DropOffPoint
                End If
            Catch ex As Exception
            End Try

        Catch ex As Exception
            txtRouteCity.Text = ""
        End Try
        LoadTemplates()
    End Sub
    Private Sub cmbTemplate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTemplate.SelectedIndexChanged
        If Not isloadingTemplayes Then
            LoadAllItems()
        End If
    End Sub

    Private Sub dgItemList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 5 Then
                dgItemList.Rows.Remove(dgItemList.Rows(e.RowIndex))
                TotalCaseQty()
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

                Dim objCustomerBOL As New cls_tblCustomer_BOL
                Dim fl As cls_tblCustomer_BOL.Fields = objCustomerBOL.Selection_One_Row(BOLAddressID)
                lblDOP.Visible = True
                txtDOP.Visible = True
                txtDOP.Text = fl.DropOffPoint
            End If
        Else
            btnShowBOLAddress.Visible = False
            BOLAddressID = 0
            lblDOP.Visible = False
            txtDOP.Visible = False
            txtDOP.Text = ""
            btnLinkAddress.BackColor = Nothing
            btnLinkAddress.Text = "Link BOL Drop-Off"
            btnLinkAddress.UseVisualStyleBackColor = True
        End If
    End Sub


    Private Sub btnPostOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostOrder.Click
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
        Else
            If Now.Hour > 12 And txtOrderDate.Value.Date = Today Then
                If MsgBox("Are you sure the order is for today?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        LoadOrderSl()

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            If Val(lblTotalCases.Text) = 0 And cmbStatus.Text <> "No Order" Then
                MsgBox("Please enter some quantity", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim OrderId As Integer = objOrder.Insert(txtOrderNo.Text, OrderSl, txtOrderDate.Value, dtpDeliveryDate.Value, cmbCustomer.SelectedValue, lblTotalCases.Text, 0, Now, UserId, Now, UserId, cmbStatus.Text, Now, UserId, "", txtComment.Text, Session, UserBranchID, BOLAddressID, 0, conn, transac)
            Dim CountSl As Integer = 1
            For Each drItem As DataGridViewRow In dgItemList.Rows

                If CheckBox1.Checked Then
                    ' If drItem.Cells(2).Value > 0 Then
                    objOrderItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                    CountSl += 1
                    ' End If
                Else
                    If drItem.Cells(2).Value > 0 Then
                        objOrderItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                        CountSl += 1
                    End If
                End If

                If (Val(drItem.Cells(6).Value) + Val(drItem.Cells(7).Value)) > 0 Then
                    If cmbStatus.Text <> "Cancelled" Then
                        objStock.Insert(ProductId:=drItem.Cells(0).Value, Qty:=(Val(drItem.Cells(6).Value) + Val(drItem.Cells(7).Value)), TransactionId:=OrderId, TransactionType:="ORDER", Stocktype:="OUT", CreatedBy:=UserId, CreatedDate:=Now, Remarks:="", Fresh:=drItem.Cells(6).Value, Frozen:=drItem.Cells(7).Value, TransactionDate:=txtOrderDate.Value, _conn:=conn, _transac:=transac) 'OrderId:=  OrderId, Sl:=  CountSl, ProductId:= ,,  Price:= 0, Discount:= 0, Extra:= 0, Weight:= "", SubTotal:= 0, Fresh:=  drItem.Cells(6).Value, Frozen:= drItem.Cells(7).Value, Notes:= "", conn, transac)
                    End If
                End If

            Next

            transac.Commit()
            Try
                Dim com As New SqlCommand("Update tblCustomer set BOL='YES' where customerid=" & cmbCustomer.SelectedValue.ToString, conn)
                com.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            'If MsgBox("Do you want to Link BOL Drop-Off?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            '    Try
            '        Dim frm As New frmBolAddress
            '        frm.OrderId = OrderId
            '        frm.CustomerID = cmbCustomer.SelectedValue
            '        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            '            MsgBox("Done", MsgBoxStyle.Information, "Info")
            '        End If
            '    Catch ex As Exception
            '        MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            '    End Try
            'End If
            ShowOrderDialog(OrderId, "Saved. Order Id : " & OrderId.ToString)
            ' MsgBox("Saved", MsgBoxStyle.Information, "Info")
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

    Sub ClearAll()

        dgItemList.Rows.Clear()
        txtOrderDate.Value = Today
        txtOrderNo.Text = ""
        cmbCustomer.SelectedIndex = 0
        cmbStatus.SelectedIndex = 1
        LastOption = 0
        lblTotalCases.Text = 0
        LoadOrderSl()
        LoadAllItems()
        lblLastOrder.Text = ""
        lastOrderId = 0
        txtComment.Text = ""

        BOLAddressID = 0
        txtDOP.Text = ""
        lblDOP.Visible = False
        txtDOP.Visible = False
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
        Dim cnt As New cntlOrderView
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


            Dim OrderId As Integer = objOrder.Insert(txtOrderNo.Text, OrderSl, txtOrderDate.Value, txtOrderDate.Value, cmbCustomer.SelectedValue, lblTotalCases.Text, 0, Now, UserId, Now, UserId, "No Order", Now, UserId, "", txtComment.Text, Session, UserBranchID, BOLAddressID, 0, conn, transac)


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

    Private Sub SelectPostOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPostOrderToolStripMenuItem.Click

        btnPostOrder.Focus()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
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
        Else
            If Now.Hour > 12 And txtOrderDate.Value.Date = Today Then
                If MsgBox("Are you sure the order is for today?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        LoadOrderSl()

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            'If Val(lblTotalCases.Text) = 0 And cmbStatus.Text <> "No Order" Then
            '    MsgBox("Please enter some quantity", MsgBoxStyle.Information, "Info")
            '    Exit Sub
            'End If

            Dim OrderId As Integer = objOrder.Insert(txtOrderNo.Text, OrderSl, txtOrderDate.Value, dtpDeliveryDate.Value, cmbCustomer.SelectedValue, lblTotalCases.Text, 0, Now, UserId, Now, UserId, cmbStatus.Text, Now, UserId, "", txtComment.Text, Session, UserBranchID, BOLAddressID, 0, conn, transac)
            Dim CountSl As Integer = 1
            For Each drItem As DataGridViewRow In dgItemList.Rows

                'If CheckBox1.Checked Then
                '  ' If drItem.Cells(2).Value > 0 Then
                objOrderItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                CountSl += 1
                '   ' End If
                'Else
                '    If drItem.Cells(2).Value > 0 Then
                '        objOrderItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, drItem.Cells(6).Value, drItem.Cells(7).Value, "", conn, transac)
                '        CountSl += 1
                '    End If
                'End If

                If (Val(drItem.Cells(6).Value) + Val(drItem.Cells(7).Value)) > 0 Then
                    If cmbStatus.Text <> "Cancelled" Then
                        objStock.Insert(ProductId:=drItem.Cells(0).Value, Qty:=(Val(drItem.Cells(6).Value) + Val(drItem.Cells(7).Value)), TransactionId:=OrderId, TransactionType:="ORDER", Stocktype:="OUT", CreatedBy:=UserId, CreatedDate:=Now, Remarks:="", Fresh:=drItem.Cells(6).Value, Frozen:=drItem.Cells(7).Value, TransactionDate:=txtOrderDate.Value, _conn:=conn, _transac:=transac) 'OrderId:=  OrderId, Sl:=  CountSl, ProductId:= ,,  Price:= 0, Discount:= 0, Extra:= 0, Weight:= "", SubTotal:= 0, Fresh:=  drItem.Cells(6).Value, Frozen:= drItem.Cells(7).Value, Notes:= "", conn, transac)
                    End If
                End If

            Next

            transac.Commit()
            Try
                Dim com As New SqlCommand("Update tblCustomer set BOL='YES' where customerid=" & cmbCustomer.SelectedValue.ToString, conn)
                com.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            'If MsgBox("Do you want to Link BOL Drop-Off?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            '    Try
            '        Dim frm As New frmBolAddress
            '        frm.OrderId = OrderId
            '        frm.CustomerID = cmbCustomer.SelectedValue
            '        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            '            MsgBox("Done", MsgBoxStyle.Information, "Info")
            '        End If
            '    Catch ex As Exception
            '        MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            '    End Try
            'End If
            ShowOrderDialog(OrderId, "Saved. Order Id : " & OrderId.ToString)
            ' MsgBox("Saved", MsgBoxStyle.Information, "Info")
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If cmbCustomer.SelectedIndex <= 0 Then
            MsgBox("Select valid Customer of the Template", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            If dgItemList.Rows.Count = 0 Then
                MsgBox("Please add some product", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim objTemplate As New cls_tblTemplate
            Dim objTemplateItems As New cls_tblTemplateItems

            Dim customerName As String = ""
            Dim customerId As String = ""

            Dim item As DataRowView = TryCast(Me.cmbCustomer.SelectedItem, DataRowView)
            If (Not item Is Nothing) Then
                With item.Row
                    customerName = .Item(0).ToString()
                    customerId = .Item(1).ToString()
                End With
            End If


            Dim OrderId As Integer = 0
            If (TemplateId <> "0") Then

                Dim ff As cls_tblTemplate.Fields = objTemplate.Selection_One_Row(TemplateId)
                OrderId = objTemplate.Update(TemplateId:=TemplateId, TemplateName:=customerName, CutomerId:=customerId, _
                                                          TotalItems:=dgItemList.Rows.Count, CreatedDate:=ff.CreatedDate, CreatedBy:=ff.CreatedBy, UpdatedDate:=Now, UpdatedBy:=UserId, Remarks:=ff.Remarks, Comments:=ff.Comments, _conn:=conn, _transac:=transac)
                objTemplateItems.Delete_By_SELECT("TemplateId =" & TemplateId.ToString)
            Else
                OrderId = objTemplate.Insert(TemplateName:=customerName, CutomerId:=customerId, _
                                                      TotalItems:=dgItemList.Rows.Count, CreatedDate:=Now, CreatedBy:=UserId, UpdatedDate:=Now, UpdatedBy:=UserId, Remarks:="", Comments:="", _conn:=conn, _transac:=transac)
                TemplateId = OrderId.ToString()
            End If

            Dim CountSl As Integer = 1
            For Each drItem As DataGridViewRow In dgItemList.Rows
                objTemplateItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, "", Now, conn, transac)
                CountSl += 1
            Next

            transac.Commit()
            MsgBox("Saved", MsgBoxStyle.Information, "Info")
            'ClearAll()
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
End Class