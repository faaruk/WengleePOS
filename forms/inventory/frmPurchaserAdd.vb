Public Class frmPurchaserAdd
    Dim objVendor As New cls_tblVendor
    Dim objPurchase As New cls_tblPurchase
    Dim objStock As New cls_tblStock
    Dim objProducts As New cls_tblProducts
    Dim objProductPrice As New cls_tblProductPrice


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        LoadCustomers()
        ClearAll()
    End Sub

    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblVendor.tablename, cls_tblVendor.FieldName.VendorName.ToString, cls_tblVendor.FieldName.VendorID.ToString)
    End Sub


    Sub TotalCaseQty()
        Dim total As Long = 0
        For Each drDG As DataGridViewRow In dgItemList.Rows
            drDG.Cells("QTY").Value = Val(drDG.Cells("Fresh").Value) + Val(drDG.Cells("Frozen").Value)
            total += Val(drDG.Cells("QTY").Value)
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
        dgItemList.Columns(8).DisplayIndex = 4
    End Sub

    Private Sub cmbCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.Leave

    End Sub

    Private Sub cmbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectedIndexChanged
        If Val(Label7.Text) = 0 And cmbCustomer.SelectedValue > 0 Then
            Try
                Dim paramlist As New List(Of SqlParameter)
                paramlist.Add(New SqlParameter("@StockTill", Now))
                ' Dim PurchaseId As String = objPurchase.Selection(cls_tblPurchase.SelectionType.All, "VendorID=" & cmbCustomer.SelectedValue & " Order By PurchaseId desc").Rows(0).Item("PurchaseID")
                Dim dt As DataTable = objProductPrice.Selection(cls_tblProductPrice.SelectionType.All_Product, " isnull(b.[VendorId],0)=" & cmbCustomer.SelectedValue.ToString & "  ", paramlist)
                'Dim dt As DataTable = objStock.Selection(cls_tblStock.SelectionType.Products_wise, " TransactionId=" & PurchaseId.ToString & " and TransactionType='PURCHASE' order by a.[StockId]")
                dgItemList.Rows.Clear()
                For Each drProduct As DataRow In dt.Rows
                    dgItemList.Rows.Add(drProduct(cls_tblProducts.FieldName.ProductId.ToString), _
                                        drProduct(cls_tblProducts.FieldName.ProductName.ToString), _
                                        0, "", "", "Delete", 0, 0, "")
                Next
            Catch ex As Exception
            End Try
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
        Dim frm As New frmVendorAdd
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
                    dgItemList.Rows.Add(pid, pname, 0)
                End If
            Next
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnPostOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostOrder.Click
        'If cmbStatus.SelectedIndex = 0 Then
        '    MsgBox("Select valid status of the Order", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If

        If cmbCustomer.SelectedIndex <= 0 Then
            MsgBox("Select valid Vendor of the Order", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If Not IsNumeric(txtInvoiceNo.Text.Trim) Then
            If MsgBox("Invoice No is not a valid number. Do you want to continue?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        'If txtOrderDate.Value = lastOrderdate.Date Then
        '    If MsgBox("There is already an order for this customer on this date. " & vbNewLine & "Are you sure?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'Else
        '    If Now.Hour > 12 And txtOrderDate.Value.Date = Today Then
        '        If MsgBox("Are you sure the order is for today?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
        '            Exit Sub
        '        End If
        '    End If
        'End If






        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try

            If Val(lblTotalCases.Text) = 0 Then ' And cmbStatus.Text <> "No Order" Then
                MsgBox("Please enter some quantity", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim OrderId As Integer = objPurchase.Insert(cmbCustomer.SelectedValue, txtOrderDate.Value, txtPO_No.Text, txtInvoiceNo.Text, 0, Now, UserId, Now, UserId, Session, conn, transac)
            Dim CountSl As Integer = 1

            For Each drItem As DataGridViewRow In dgItemList.Rows
                If Val(drItem.Cells(6).Value) + Val(drItem.Cells(7).Value) > 0 Then
                    Dim remmm As String = ""
                    Try
                        remmm = IIf(drItem.Cells(8).Value Is Nothing, "", drItem.Cells(8).Value)
                    Catch ex As Exception
                    End Try
                    objStock.Insert(ProductId:=drItem.Cells(0).Value, Qty:=drItem.Cells(2).Value, TransactionId:=OrderId, TransactionType:="PURCHASE", Stocktype:="IN", CreatedBy:=UserId, CreatedDate:=Now, Remarks:=remmm, Fresh:=drItem.Cells(6).Value, Frozen:=drItem.Cells(7).Value, TransactionDate:=txtOrderDate.Value, _conn:=conn, _transac:=transac) 'OrderId:=  OrderId, Sl:=  CountSl, ProductId:= ,,  Price:= 0, Discount:= 0, Extra:= 0, Weight:= "", SubTotal:= 0, Fresh:=  drItem.Cells(6).Value, Frozen:= drItem.Cells(7).Value, Notes:= "", conn, transac)
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
        dgItemList.Rows.Clear()
        txtOrderDate.Value = Today
        cmbCustomer.SelectedIndex = 0

        lblTotalCases.Text = 0
        txtComment.Text = ""

        txtInvoiceNo.Text = ""
        txtPO_No.Text = ""
    End Sub

    Private Sub btnCreateProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateProduct.Click
        Dim frm As New frmProductsAdd
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

        End If
    End Sub
 
    

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub frmOrderAdd_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

  
End Class