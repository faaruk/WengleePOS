Public Class cntlOrderView

    Dim objCustomer As New cls_tblCustomer
    Dim objCustomerBol As New cls_tblCustomer_BOL
    Dim objOrder As New cls_tblOrder
    Dim objOrderStatus As New cls_tblOrderStatus
    Dim objOrderItems As New cls_tblOrderItems
    Dim objProducts As New cls_tblProducts
    Dim objUserRules As New cls_tblUserRules
    Dim objUserDetails As New cls_t_tblUserDetails

    Dim OpenOrderId As Integer = 0
    Dim OpenCustomnerId As Integer = 0
    Private Sub dgInvoices_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellDoubleClick
        Try : Clipboard.SetText(CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value) : Catch ex As Exception : End Try
    End Sub
    Sub OpenOrder(ByVal orderID As String)

        Clear()
         Try
            OpenOrderId = orderID
            Dim CutOf As String = ""
            Dim order As cls_tblOrder.Fields = objOrder.Selection_One_Row(orderID)
            OpenCustomnerId = order.CutomerId
            Try

                Label1.Text = "" & vbNewLine
                Label1.Text += " Order# ".PadRight(12) & ": " & order.OrderNo & vbNewLine
                Label1.Text += " Date ".PadRight(12) & ": " & order.OrderDate.ToShortDateString & vbNewLine

                Dim fl As cls_tblCustomer.Fields = objCustomer.Selection_One_Row(order.CutomerId)
                CutOf = fl.Receiving_CutOff
                Label1.Text += " Customer ".PadRight(12) & ": " & fl.CustomerName & vbNewLine
                Label1.Text += " Status ".PadRight(12) & ": " & order.Status.Trim & vbNewLine

                Label1.Text += " Created by ".PadRight(12) & ": " & objUserDetails.Selection_One_Row(order.CreatedBy).UserName_ & vbNewLine
                Label1.Text += " Updated by ".PadRight(12) & ": " & objUserDetails.Selection_One_Row(order.UpdatedBy).UserName_

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-1}")
            End Try
            btnEdit.Visible = True
            btnLinkBol.Visible = True
            Try
                btnPrintBOL.Visible = order.BOLAddressID <> 0
                If order.BOLAddressID <> 0 Then
                    CutOf = ""
                    Dim bi As cls_tblCustomer_BOL.Fields = objCustomerBol.Selection_One_Row(order.BOLAddressID)
                    CutOf = bi.Receiving_CutOff
                End If

            Catch ex As Exception
            End Try



            Try

                Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "OrderId=" & orderID.ToString & " Order by sl")
                Dim SL As Integer = 1
                For Each drProduct As DataRow In orderItems.Rows
                    dgItemList.Rows.Add(SL, _
                                        objProducts.SelectScalar(cls_tblProducts.FieldName.ProductName, "ProductID=" & drProduct(cls_tblOrderItems.FieldName.ProductId.ToString).ToString), _
                                        drProduct(cls_tblOrderItems.FieldName.Fresh.ToString), drProduct(cls_tblOrderItems.FieldName.Frozen.ToString), drProduct(cls_tblOrderItems.FieldName.Weight.ToString), drProduct(cls_tblOrderItems.FieldName.Notes.ToString)) ', "", _
                    SL += 1
                Next
            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-2}")
            End Try
            dgItemList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            Try
                TotalCaseQty()
            Catch ex As Exception
            End Try


            If order.Comments <> "" Then
                Label2.Text += vbNewLine & "Comments:" & vbNewLine & "---------------------------------------" & vbNewLine & order.Comments.Trim
            End If
            If Not CutOf = "" Then
                Label2.Text += vbNewLine & "Recieving Cut-Off : " & CutOf
            End If

            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-3}")
        End Try
    End Sub
    Sub OpenOrderNo(ByVal orderNO As String)
        Dim orderId As String = objOrder.Selection(cls_tblOrder.SelectionType.All, "OrderNo='" & orderNO.ToString & "'").Rows(0).Item("OrderId")
        OpenOrder(orderId)
    End Sub
    Sub TotalCaseQty()
        ' Dim total As Integer = 0
        For Each drDG As DataGridViewRow In dgItemList.Rows
            ' drDG.Cells("QTY").Value = Val(drDG.Cells("Fresh").Value) + Val(drDG.Cells("Frozen").Value)
            'total += Val(drDG.Cells("Fresh").Value) + Val(drDG.Cells("Frozen").Value)
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

        Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.UNIT_WISE_TOTAL, "a.OrderId=" & OpenOrderId.ToString & " group by b. UnitOfMeasure ")
        'Label2.Text = " Total " & total.ToString & " Case(s)."
        Label2.Text = "Total : " ' & c.ToString & " Case(s)"
        For Each dr As DataRow In orderItems.Rows
            Label2.Text += dr("Total").ToString & " " & dr("Unit").ToString & ", " 'Case(s)"
        Next
    End Sub
    'Sub TotalCaseQty()
    '    Dim total As Integer = 0
    '    For Each drDG As DataGridViewRow In dgItemList.Rows
    '        total += Val(drDG.Cells("QTY").Value)
    '        If Val(drDG.Cells("QTY").Value) >= 10 Then
    '            drDG.Cells("QTY").Style.BackColor = Color.LavenderBlush
    '        ElseIf Val(drDG.Cells("QTY").Value) >= 5 Then
    '            drDG.Cells("QTY").Style.BackColor = Color.LightYellow
    '        ElseIf Val(drDG.Cells("QTY").Value) > 0 Then
    '            drDG.Cells("QTY").Style.BackColor = Color.FromArgb(192, 255, 192)
    '        Else
    '            drDG.Cells("QTY").Style.BackColor = Color.White
    '        End If
    '    Next
    'End Sub
 
    Private Sub dgItemList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.SelectionChanged
        For Each dr As DataGridViewRow In dgItemList.SelectedRows
            dr.Selected = False
        Next
    End Sub

    Sub Clear()
        btnEdit.Visible = False
        btnLinkBol.Visible = False
        btnPrintBOL.Visible = False
        Label1.Text = ""
        Label2.Text = ""
        dgItemList.Rows.Clear()
    End Sub

    Private Sub Label2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.TextChanged
        Label2.Height = Label2.CreateGraphics.MeasureString(Label2.Text, Label2.Font, Label2.Width - 5).Height

        If Label2.Height + 200 > Me.Height Then
            Label2.Height = Me.Height - 200
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.EditOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Try
            Dim frm As New frmOrderEdit
            frm.OpenOrder(OpenOrderId)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                OpenOrder(OpenOrderId)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub btnPrintBOL_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintBOL.Click
        Try
            If Not objUserRules.CheckRule(cls_tblUserRules.Rules.PrintBol, UserId) Then
                MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
                Exit Sub
            End If

            Dim pp As New clsPrintBOL_WINWORD
            pp.CreateBol(OpenOrderId)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub btnLinkBol_Click(sender As System.Object, e As System.EventArgs) Handles btnLinkBol.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.LinkBol, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If

        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                Dim frm As New frmBolAddress
                frm.OrderId = OpenOrderId
                frm.CustomerID = OpenCustomnerId
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    OpenOrder(OpenOrderId)
                    MsgBox("Done", MsgBoxStyle.Information, "Info")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmPickReport.OrderId = OpenOrderId
        frmPickReport.ShowDialog()
    End Sub

    
    

End Class
