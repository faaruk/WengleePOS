Public Class cntlRouteView
    Dim objCustomer As New cls_tblCustomer
    Dim objOrders As New cls_tblOrder
    Dim objOrderStatus As New cls_tblOrderStatus
    Dim objOrderItems As New cls_tblOrderItems
    Dim objProducts As New cls_tblProducts

    Dim objRoute As New cls_tblRoute
    Dim objRouteItems As New cls_tblRouteOrders
    Dim objUserRules As New cls_tblUserRules

    Dim RouteId As Integer = 0
    Sub OpenRoute(ByVal _routeId As Integer)
        RouteId = _routeId
        Clear()
        Try
            Dim SL As Integer = 1
            Dim SlCounter As Integer = 1
            Try
                Dim RouteDetails As cls_tblRoute.Fields = objRoute.Selection_One_Row(_routeId)
                Label1.Text = "" & vbNewLine
                Label1.Text += "Route Name : " & RouteDetails.OtherInfos & vbNewLine
                Label1.Text += "Truck : " & RouteDetails.Truck & vbNewLine
                Label1.Text += "Driver : " & RouteDetails.Driver & vbNewLine
                Label1.Text += "Route City : " & RouteDetails.RouteCity & vbNewLine
                'Label1.Text += "Driver : " & RouteDetails. & vbNewLine
            Catch ex As Exception
            End Try


            Try

                Dim dtRouteOrder As DataTable = objRouteItems.Selection(cls_tblRouteOrders.SelectionType.All, "RouteID =" & _routeId.ToString)
                For Each drRouteOrder As DataRow In (From dr As DataRow In dtRouteOrder.Rows
                                                     Order By dr("sl")
                                                     Select dr).ToArray

                    Try

                        Dim OrderDetails As cls_tblOrder.Fields = objOrders.Selection_One_Row(drRouteOrder("OrderId"))
                        Dim CustomerDetails As cls_tblCustomer.Fields = objCustomer.Selection_One_Row(OrderDetails.CutomerId)

                        dgItemList.Rows.Add(SL, _
                                           OrderDetails.OrderNo, _
                                           CustomerDetails.CustomerName, _
                                           OrderDetails.Total, _
                                           OrderDetails.OrderId, _
                                           OrderDetails.InvoiceNumber, _
                                           OrderDetails.TotalCartons, _
                                           OrderDetails.OrderDiscrepancy, _
                                           "")
                        SL += 1

                    Catch ex As Exception
                    End Try
                Next

            Catch ex As Exception
            End Try

            Try
                TotalCaseQty()
            Catch ex As Exception

            End Try
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Sub TotalCaseQty()
        Dim total As Integer = 0
        Dim orderids As String = "-1"
        For Each drDG As DataGridViewRow In dgItemList.Rows
            total += Val(drDG.Cells("QTY").Value)
            orderids += "," & Val(drDG.Cells(4).Value).ToString
            Dim strVal = drDG.Cells(7).Value
            If strVal = "Mismatch" Then
                drDG.Cells(0).Style.BackColor = Color.Red
            End If
        Next
        Label2.Text = "Total " & dgItemList.Rows.Count.ToString & " Order(s)||Total " '& total.ToString & " Case(s)."
        Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.UNIT_WISE_TOTAL, "a.OrderId in (" & orderids.ToString & ") group by b. UnitOfMeasure ")
        For Each dr As DataRow In orderItems.Rows
            Label2.Text += dr("Total").ToString & " " & dr("Unit").ToString & ", " 'Case(s)"
        Next
    End Sub

    Private Sub dgItemList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                Try

                    Dim frm As New Form
                    frm.Size = New Size(500, 600)
                    frm.BackColor = Color.White
                    frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                    frm.StartPosition = FormStartPosition.CenterScreen
                    Dim cnt As New cntlOrderView
                    frm.Controls.Add(cnt)
                    cnt.Dock = DockStyle.Fill
                    frm.MinimizeBox = False
                    frm.MaximizeBox = False
                    frm.TopMost = True
                    frm.ShowInTaskbar = True
                    cnt.OpenOrder(dgItemList.Rows(e.RowIndex).Cells("ORDERID").Value)
                    frm.Show()

                Catch ex As Exception
                End Try

            End If
        End If
        'Try
        '    If My.Computer.Keyboard.AltKeyDown Then
        '        Dim frm As New Form
        '        frm.Size = New Size(500, 600)
        '        frm.BackColor = Color.White
        '        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        '        frm.StartPosition = FormStartPosition.CenterScreen
        '        Dim cnt As New cntlOrderView
        '        frm.Controls.Add(cnt)
        '        cnt.Dock = DockStyle.Fill
        '        frm.MinimizeBox = False
        '        frm.MaximizeBox = False
        '        frm.TopMost = False
        '        frm.ShowInTaskbar = False
        '        cnt.OpenOrder(dgItemList.Rows(e.RowIndex).Cells("ORDERID").Value)
        '        frm.ShowDialog()
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub dgItemList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItemList.SelectionChanged

        'For Each dr As DataGridViewRow In dgItemList.SelectedRows
        '    dr.Selected = False
        'Next
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

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.CreateRoute, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        Try
            Dim frm As New frmCreateRoute
            frm.OpenEdtiRoute(RouteId)
            frm.ShowDialog()
            OpenRoute(RouteId)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If dgItemList.SelectedRows.Count <= 0 Then
            MsgBox("Select one or more orders", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Try
            Dim l As New List(Of Integer)
            For Each dr As DataGridViewRow In dgItemList.SelectedRows
                l.Add(dr.Cells("ORDERID").Value())
            Next
            Dim pp As New clsPrintLabel
            pp.PrintOrder(l)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub


    Private Sub btnLoadNcr_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadNcr.Click
        RefreshTransfererDB()
        LinkOrder()
        OpenRoute(RouteId)
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

End Class
