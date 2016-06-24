Public Class frmOrderFullfillment
    Dim objCustomer As New cls_tblCustomer
    Dim objOrder As New cls_tblOrder
    Dim objOrderStatus As New cls_tblOrderStatus
    Dim objOrderItems As New cls_tblOrderItems
    Dim objProducts As New cls_tblProducts
    'Dim OrderSl As Integer = 0
    Dim OpenedOrderID As Integer = 0
    Dim objStock As New cls_tblStock
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        LoadCustomers()
        ClearAll()
    End Sub

    Sub OpenOrder(ByVal orderID As String)
        Try
            Dim order As cls_tblOrder.Fields = objOrder.Selection_One_Row(orderID)
            Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "OrderId=" & orderID.ToString & " Order by sl")
            txtOrderNo.Text = order.OrderNo
            'txtOrderDate.MinDate = order.OrderDate
            txtOrderDate.Value = order.OrderDate
            cmbCustomer.SelectedValue = order.CutomerId
            cmbStatus.Text = order.Status
            txtComment.Text = order.Comments
            OpenedOrderID = orderID
            For Each drProduct As DataRow In orderItems.Rows
                dgItemList.Rows.Add(drProduct(cls_tblOrderItems.FieldName.ProductId.ToString), _
                                  objProducts.SelectScalar(cls_tblProducts.FieldName.ProductName, "ProductID=" & drProduct(cls_tblOrderItems.FieldName.ProductId.ToString).ToString), _
                                  drProduct(cls_tblOrderItems.FieldName.Qty.ToString), "", "", "", _
                                  drProduct(cls_tblOrderItems.FieldName.Fresh.ToString), drProduct(cls_tblOrderItems.FieldName.Frozen.ToString), drProduct(cls_tblOrderItems.FieldName.Weight.ToString), drProduct(cls_tblOrderItems.FieldName.notes.ToString), drProduct(cls_tblOrderItems.FieldName.ItemId.ToString))
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
        SetDisplayIndex()
    End Sub

    Sub SetDisplayIndex()
        dgItemList.Columns(6).DisplayIndex = 2
        dgItemList.Columns(7).DisplayIndex = 3
        dgItemList.Columns(8).DisplayIndex = 5
        dgItemList.Columns(9).DisplayIndex = 6
    End Sub

    Private Sub cmbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectedIndexChanged

        Try
            txtRouteCity.Text = objCustomer.Selection_One_Row(cmbCustomer.SelectedValue).RouteCity
        Catch ex As Exception
            txtRouteCity.Text = ""
        End Try

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

    'Private Sub dgItemList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.GotFocus
    '    Try
    '        If dgItemList.SelectedCells(0).ColumnIndex <> 2 Then
    '            dgItemList.SelectedCells(0).Selected = False
    '            dgItemList.Rows(0).Cells(2).Selected = True
    '        End If
    '    Catch ex As Exception
    '    End Try

    'End Sub


    Private Sub dgItemList_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.LostFocus
        Try
            dgItemList.SelectedCells(0).Selected = False
        Catch ex As Exception
        End Try
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
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            Dim order As cls_tblOrder.Fields = objOrder.Selection_One_Row(OpenedOrderID)
            Dim OrderId As Integer = objOrder.Update(OpenedOrderID, txtOrderNo.Text, order.OrderSl, txtOrderDate.Value, txtOrderDate.Value, cmbCustomer.SelectedValue, lblTotalCases.Text, 0, order.CreatedDate, order.CreatedBy, Now, UserId, "Fulfilled", Now, UserId, "", txtComment.Text, Session, UserBranchID, order.BOLAddressID, 0, conn, transac)
            Dim CountSl As Integer = 1
            Dim keepsl As String = "-1"
            objStock.Delete_By_SELECT("TransactionId=" & OrderId.ToString & " and TransactionType='ORDER'", Nothing, conn, transac)
            For Each drItem As DataGridViewRow In dgItemList.Rows
                ' If drItem.Cells(2).Value > 0 Then
                Dim itemid As Integer = Val(drItem.Cells(10).Value)
                If itemid > 0 Then
                    Dim itemdetail As cls_tblOrderItems.Fields = objOrderItems.Selection_One_Row(itemid, conn, transac)
                    objOrderItems.Update(itemid, OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, itemdetail.Price, itemdetail.Discount, itemdetail.Extra, drItem.Cells(8).Value.ToString, 0, drItem.Cells(6).Value, drItem.Cells(7).Value, drItem.Cells(9).Value.ToString, conn, transac)
                Else
                    itemid = objOrderItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, drItem.Cells(8).Value, 0, drItem.Cells(6).Value, drItem.Cells(7).Value, drItem.Cells(9).Value, conn, transac)
                End If
                If Val(drItem.Cells(6).Value) + Val(drItem.Cells(7).Value) > 0 Then
                    'If cmbStatus.Text <> "Cancelled" Then
                    'End If
                    objStock.Insert(ProductId:=drItem.Cells(0).Value, Qty:=(Val(drItem.Cells(6).Value) + Val(drItem.Cells(7).Value)), TransactionId:=OrderId, TransactionType:="ORDER", Stocktype:="OUT", CreatedBy:=UserId, CreatedDate:=Now, Remarks:="", Fresh:=drItem.Cells(6).Value, Frozen:=drItem.Cells(7).Value, TransactionDate:=txtOrderDate.Value, _conn:=conn, _transac:=transac) 'OrderId:=  OrderId, Sl:=  CountSl, ProductId:= ,,  Price:= 0, Discount:= 0, Extra:= 0, Weight:= "", SubTotal:= 0, Fresh:=  drItem.Cells(6).Value, Frozen:= drItem.Cells(7).Value, Notes:= "", conn, transac)
                End If
                If keepsl <> "" Then
                    keepsl += ","
                End If
                keepsl += itemid.ToString
                CountSl += 1
                'End If
            Next
            objOrderItems.Delete_By_SELECT(" ItemId Not In (" & keepsl & ") and OrderId=" & OrderId.ToString, Nothing, conn, transac)
            transac.Commit()
            MsgBox("Saved", MsgBoxStyle.Information, "Info")
            ClearAll()
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
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
        txtOrderDate.Value = Today
        txtOrderNo.Text = ""
        cmbCustomer.SelectedIndex = 0
        cmbStatus.SelectedIndex = 0
        dgItemList.Rows.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub frmEditOrder_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            dgItemList.SelectedCells(0).Selected = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SelectPostOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPostOrderToolStripMenuItem.Click
        btnPostOrder.Focus()
    End Sub
End Class