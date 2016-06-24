Public Class cntlScheduledOrderView

    Dim objCustomer As New cls_tblCustomer
    Dim objOrder As New cls_tblOrderSchedule
    'Dim objOrderStatus As New cls_tblOrderStatus
    Dim objOrderItems As New cls_tblOrderScheduleItems
    Dim objProducts As New cls_tblProducts
    Dim objUserDetails As New cls_t_tblUserDetails

    Dim OpenOrderId As Integer = 0

    Public ScheduleDate As Date = Nothing
    Public Event Confirmed()

    Sub OpenOrder(ByVal orderID As String)

        Clear()

        Try
            OpenOrderId = orderID
            Button1.Visible = Not ScheduleDate = Nothing
            Dim order As cls_tblOrderSchedule.Fields = objOrder.Selection_One_Row(orderID)
            Try
                Label1.Text = "" & vbNewLine
                Label1.Text += " Order# ".PadRight(12) & ": " & order.OrderNo & vbNewLine
                Label1.Text += " Date ".PadRight(12) & ": " & order.OrderDate.ToShortDateString & vbNewLine

                Label1.Text += " Name ".PadRight(12) & ": " & objCustomer.Selection_One_Row(order.CutomerId).CustomerName & vbNewLine
                Label1.Text += " Status ".PadRight(12) & ": " & order.Status.Trim & vbNewLine

                Label1.Text += " Created by ".PadRight(12) & ": " & objUserDetails.Selection_One_Row(order.CreatedBy).UserName_ & vbNewLine
                Label1.Text += " Updated by ".PadRight(12) & ": " & objUserDetails.Selection_One_Row(order.UpdatedBy).UserName_


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-1}")
            End Try


            Try
                Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderScheduleItems.SelectionType.All, "OrderId=" & orderID.ToString & " Order by sl")
                Dim SL As Integer = 1
                For Each drProduct As DataRow In orderItems.Rows
                    dgItemList.Rows.Add(SL, _
                                        objProducts.SelectScalar(cls_tblProducts.FieldName.ProductName, "ProductID=" & drProduct(cls_tblOrderItems.FieldName.ProductId.ToString).ToString), _
                                        drProduct(cls_tblOrderItems.FieldName.Fresh.ToString), drProduct(cls_tblOrderItems.FieldName.Frozen.ToString), drProduct(cls_tblOrderItems.FieldName.Weight.ToString), drProduct(cls_tblOrderItems.FieldName.Notes.ToString)) ', "", _
                    '                   drProduct(cls_tblOrderItems.FieldName.Fresh.ToString), drProduct(cls_tblOrderItems.FieldName.Frozen.ToString), drProduct(cls_tblOrderItems.FieldName.ItemId.ToString))
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

            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-3}")
        End Try
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Not ScheduleDate = Nothing Then
            Dim frm As New frmOrderConfirmAdd
            frm.OpenOrder(OpenOrderId, ScheduleDate)
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Clear()
                Button1.Visible = False
                RaiseEvent Confirmed()
            End If
        End If

    End Sub
End Class
