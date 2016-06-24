Public Class frmOrdeEditr
    Dim objCustomer As New cls_tblCustomer
    Dim objOrder As New cls_tblOrder
    Dim objOrderStatus As New cls_tblOrderStatus
    Dim objOrderItems As New cls_tblOrderItems
    Dim objProducts As New cls_tblProducts
    'Dim OrderSl As Integer = 0
    Dim OpenedOrderID As Integer = 0
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
            txtOrderDate.Value = order.OrderDate
            cmbCustomer.SelectedValue = order.CutomerId
            cmbStatus.Text = order.Status
            OpenedOrderID = orderID
            For Each drProduct As DataRow In orderItems.Rows
                dgItemList.Rows.Add(drProduct(cls_tblOrderItems.FieldName.ProductId.ToString), _
                                    objProducts.SelectScalar(cls_tblProducts.FieldName.ProductName, "ProductID=" & drProduct(cls_tblOrderItems.FieldName.ProductId.ToString).ToString), _
                                    drProduct(cls_tblOrderItems.FieldName.Qty.ToString))
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
            total += Val(drDG.Cells("QTY").Value)
            If Val(drDG.Cells("QTY").Value) >= 10 Then
                drDG.Cells("QTY").Style.BackColor = Color.LavenderBlush
            ElseIf Val(drDG.Cells("QTY").Value) >= 5 Then
                drDG.Cells("QTY").Style.BackColor = Color.LightYellow
            ElseIf Val(drDG.Cells("QTY").Value) > 0 Then
                drDG.Cells("QTY").Style.BackColor = Color.FromArgb(192, 255, 192)
            Else
                drDG.Cells("QTY").Style.BackColor = Color.White
            End If
        Next
        lblTotalCases.Text = total.ToString
    End Sub

    Private Sub frmOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOrderDate.MinDate = Today.Date.AddDays(-1)

    End Sub

    Private Sub cmbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectedIndexChanged

        Try
            txtRouteCity.Text = objCustomer.Selection_One_Row(cmbCustomer.SelectedValue).RouteCity
        Catch ex As Exception
            txtRouteCity.Text = ""
        End Try

    End Sub


    Private Sub dgItemList_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellEndEdit
        Try
            If e.ColumnIndex = 2 Then
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

    Private Sub dgItemList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.GotFocus
        Try
            If dgItemList.SelectedCells(0).ColumnIndex <> 2 Then
                dgItemList.SelectedCells(0).Selected = False
                dgItemList.Rows(0).Cells(2).Selected = True
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgItemList_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.LostFocus
        Try
            dgItemList.SelectedCells(0).Selected = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgItemList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.SelectionChanged
        Try
            If dgItemList.SelectedCells(0).ColumnIndex < 2 Then
                For i = dgItemList.SelectedCells(0).ColumnIndex To 1
                    If dgItemList.Columns(i).Visible Then
                        SendKeys.Send("{TAB}")
                    End If
                Next
            ElseIf dgItemList.SelectedCells(0).ColumnIndex > 2 Then
                For i = 3 To dgItemList.SelectedCells(0).ColumnIndex
                    If dgItemList.Columns(i).Visible Then
                        SendKeys.Send("Shift+{TAB}")
                    End If
                Next
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
                If isAlready = 0 Then
                    dgItemList.Rows.Add(pid, pname, 0)
                End If
            Next
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnDeleteOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteOrder.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                objOrderItems.Delete_By_OrderId(OpenedOrderID)
                objOrder.Delete_By_OrderId(OpenedOrderID)
                objOrderStatus.Delete_By_OrderID(OpenedOrderID)
                DialogResult = Windows.Forms.DialogResult.OK
                Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub dgItemList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 5 Then
                dgItemList.Rows.Remove(dgItemList.Rows(e.RowIndex))
            End If
        End If

    End Sub

    Private Sub btnPostOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostOrder.Click
        If cmbStatus.SelectedIndex = 0 Then
            MsgBox("Select valid status of the Order", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cmbCustomer.SelectedIndex = 0 Then
            MsgBox("Select valid status of the Order", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            Dim order As cls_tblOrder.Fields = objOrder.Selection_One_Row(OpenedOrderID)

            Dim OrderId As Integer = objOrder.Update(OpenedOrderID, txtOrderNo.Text, order.OrderSl, txtOrderDate.Value, txtOrderDate.Value, cmbCustomer.SelectedValue, lblTotalCases.Text, 0, order.CreatedDate, order.CreatedBy, Now, UserId, cmbStatus.Text, Now, UserId, "", "", Session, UserBranchID, conn, transac)
            Dim CountSl As Integer = 1
            objOrderItems.Delete_By_OrderId(OrderId, conn, transac)
            For Each drItem As DataGridViewRow In dgItemList.Rows
                If drItem.Cells(2).Value > 0 Then
                    objOrderItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, drItem.Cells(2).Value, 0, 0, 0, "", 0, conn, transac)
                    CountSl += 1
                End If
            Next
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
End Class