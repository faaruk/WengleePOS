Public Class cntltemplateView

    Dim objCustomer As New cls_tblCustomer
    Dim objOrder As New cls_tblTemplate
    Dim objOrderItems As New cls_tblTemplateItems
    Dim objProducts As New cls_tblProducts

    Dim OpenOrderId As Integer = 0

    Sub OpenOrder(ByVal orderID As String)

        Clear()

        Try
            OpenOrderId = orderID
            Dim order As cls_tblTemplate.Fields = objOrder.Selection_One_Row(orderID)
            Try
                Label1.Text = "" & vbNewLine
                If order.CutomerId = 0 Then
                    Label1.Text += " Customer Name ".PadRight(20) & " : Common for all customer" & vbNewLine

                Else
                    Label1.Text += " Customer Name ".PadRight(20) & " : " & objCustomer.Selection_One_Row(order.CutomerId).CustomerName & vbNewLine
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-1}")
            End Try


            Try
                Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "TemplateId=" & orderID.ToString & " Order by sl")
                Dim SL As Integer = 1
                For Each drProduct As DataRow In orderItems.Rows
                    dgItemList.Rows.Add(SL, _
                                        objProducts.SelectScalar(cls_tblProducts.FieldName.ProductName, "ProductID=" & drProduct(cls_tblTemplateItems.FieldName.ProductId.ToString).ToString))
                    SL += 1
                Next
            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-2}")
            End Try

            dgItemList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info {CNTLOV-3}")
        End Try
    End Sub


    Private Sub dgItemList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.SelectionChanged
        For Each dr As DataGridViewRow In dgItemList.SelectedRows
            dr.Selected = False
        Next
    End Sub

    Sub Clear()
        Label1.Text = ""
        dgItemList.Rows.Clear()
    End Sub

End Class
