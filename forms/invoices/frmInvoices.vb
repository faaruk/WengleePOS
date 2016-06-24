Public Class frmInvoices
    Dim objInvStat As New cls_tblInvoiceStatus
    Private Sub frmInvoices_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        chkDateRange.Checked = True
        dtp1.Value = Today
        dtp2.Value = Today
        RefreshInvoices()

    End Sub

    Sub RefreshInvoices()

        Dim dtListofInvoices As New DataTable
        Dim objConn As New clsConnection
        Dim con As SqlConnection = objConn.connectTransfer
        ' LinkOrder()

        Dim str As String = ""
        Dim str2 As String = ""
        Dim da As New SqlDataAdapter("", con)
        If chkDateRange.Checked Then
            str = " And a.InvoiceDate Between @d1 and @d2"
            'str2 = " WHERE OrderDate Between @d1 and @d2"
            da.SelectCommand.Parameters.AddWithValue("@d1", dtp1.Value.Date)
            da.SelectCommand.Parameters.AddWithValue("@d2", dtp2.Value.Date.AddDays(1).AddSeconds(-1))
        End If

        'da.SelectCommand.CommandText = @"
        Dim strSQL As String = ""
        strSQL = " SELECT a.OrderNumber,"
        strSQL = strSQL & " a.InvoiceNumber,"
        strSQL = strSQL & " InvoiceDate,"
        strSQL = strSQL & " a.CustomerId,"
        strSQL = strSQL & " c.CustomerName,"
        strSQL = strSQL & " c.Email,"
        strSQL = strSQL & " d.Phone,"
        strSQL = strSQL & " TotalAmount,"
        strSQL = strSQL & " ISNULL(LastPrintedBy, 'NOT PRINTED') AS [LastPrintedBy],"
        strSQL = strSQL & " g.[Status] + CASE"
        strSQL = strSQL & " WHEN e.ItemId IS NULL"
        strSQL = strSQL & " AND g.[Status] <> 'Delivered'"
        strSQL = strSQL & " THEN ''"
        strSQL = strSQL & " ELSE '. On Delivery(' + d.RouteCity + '-' + f.RouteCity + ')'"
        strSQL = strSQL & " END AS [Order Status],"
        strSQL = strSQL & " f.Driver,"
        strSQL = strSQL & " f.Truck,"
        strSQL = strSQL & " f.OtherInfos AS [Route Name],"
        strSQL = strSQL & " ISNULL(h.Status,"
        strSQL = strSQL & " CASE"
        strSQL = strSQL & " WHEN LastPrintedBy IS NULL"
        strSQL = strSQL & " THEN 'Not Printed'"
        strSQL = strSQL & " ELSE 'Printed'"
        strSQL = strSQL & " END) AS Status,a.HandheldEditDate as [Scan Date]"
        strSQL = strSQL & " FROM dbWengleeTransferer.dbo.tblInvoices a"
        strSQL = strSQL & " LEFT OUTER JOIN dbWengleeTransferer.dbo.tblNotification b ON a.InvoiceNumber = b.InvoiceNo"
        strSQL = strSQL & " AND a.CustomerId = b.CustomerId"
        strSQL = strSQL & " LEFT OUTER JOIN dbWengleeTransferer.dbo.tblCustomers c ON a.CustomerId = c.CustomerId"
        strSQL = strSQL & " LEFT OUTER JOIN dbWenglee.dbo.tblCustomer d ON c.CustomerId = d.CustomerID_link COLLATE SQL_Latin1_General_CP1_CI_AS"
        strSQL = strSQL & " OR c.CustomerName = d.CustomerName COLLATE SQL_Latin1_General_CP1_CI_AS"
        strSQL = strSQL & " LEFT OUTER JOIN( "
        strSQL = strSQL & " SELECT *"
        strSQL = strSQL & " FROM(dbWenglee.dbo.[tblOrder])"
        strSQL = strSQL & " WHERE OrderID IN("
        strSQL = strSQL & " Select MAX(OrderID)"
        strSQL = strSQL & " FROM dbWenglee.dbo.[tblOrder] " & str2 & " "
        strSQL = strSQL & " GROUP BY CutomerId )) g ON a.OrderNumber = g.OrderNo"
        strSQL = strSQL & " AND CONVERT( VARCHAR, g.OrderDate, 101) = CONVERT(VARCHAR, a.InvoiceDate, 101)"
        strSQL = strSQL & " AND d.CustomerID = g.CutomerId"
        strSQL = strSQL & " LEFT OUTER JOIN( "
        strSQL = strSQL & " SELECT *"
        strSQL = strSQL & " FROM(dbWenglee.dbo.tblRouteOrders)"
        strSQL = strSQL & " WHERE ItemId IN("
        strSQL = strSQL & " Select MAX(itemId)"
        strSQL = strSQL & " FROM(dbWenglee.dbo.tblRouteOrders)"
        strSQL = strSQL & " GROUP BY OrderId )) e ON g.OrderId = e.OrderId"
        strSQL = strSQL & " LEFT OUTER JOIN dbWenglee.dbo.tblRoute f ON e.RouteID = f.RouteId"
        strSQL = strSQL & " LEFT OUTER JOIN dbWenglee.dbo.tblInvoiceStatus h ON h.InvoiceNumber = a.InvoiceNumber COLLATE SQL_Latin1_General_CP1_CI_AS"
        strSQL = strSQL & " AND h.CustomerID = a.CustomerID COLLATE SQL_Latin1_General_CP1_CI_AS"
        strSQL = strSQL & " WHERE b.Pk_id IS NULL " & str & ""
        strSQL = strSQL & " ORDER BY a.InvoiceDate DESC;"

        'da.SelectCommand.CommandText = strSQL

        Dim query As String = <QUERY><![CDATA[  

SELECT a.OrderNumber,
       a.InvoiceNumber,
       a.HandheldEditDate as [Scan Date],
       InvoiceDate,
       a.CustomerId,
       c.CustomerName,
       d.CustomerId_Link AS [Linked ID],
       d.CustomerName AS [Linked Customer Name],
       c.Email,
       d.Phone,
       TotalAmount,
       ISNULL(LastPrintedBy,'NOT PRINTED') AS [LastPrintedBy],
       g.[Status] + CASE
                    WHEN e.ItemId IS NULL
                     AND g.[Status] <> 'Delivered' THEN ''
                        ELSE '. On Delivery(' + d.RouteCity + '-' + f.RouteCity + ')'
                    END AS [Order Status],
       f.Driver,
       f.Truck,
       f.OtherInfos AS [Route Name],
       ISNULL(h.Status,CASE
                       WHEN LastPrintedBy IS NULL THEN 'Not Printed'
                           ELSE 'Printed'
                       END) AS Status
  FROM dbWengleeTransferer.dbo.tblInvoices a
       LEFT OUTER JOIN dbWengleeTransferer.dbo.tblNotification b ON a.InvoiceNumber = b.InvoiceNo
                                                                AND a.CustomerId = b.CustomerId
       LEFT OUTER JOIN dbWengleeTransferer.dbo.tblCustomers c ON a.CustomerId = c.CustomerId
       LEFT OUTER JOIN dbWenglee.dbo.tblCustomer d ON c.CustomerId = d.CustomerID_link COLLATE SQL_Latin1_General_CP1_CI_AS
                                                   OR
                                                      ( c.CustomerId <> d.CustomerID_link COLLATE SQL_Latin1_General_CP1_CI_AS
                                                    AND c.CustomerName = d.CustomerName COLLATE SQL_Latin1_General_CP1_CI_AS
                                                      )
       LEFT OUTER JOIN( 
                        SELECT *
                          FROM dbWenglee.dbo.[tblOrder]
                          WHERE OrderID IN(
                        SELECT MAX(OrderID)
                          FROM dbWenglee.dbo.[tblOrder]
                          WHERE 1234 = 1234
                          GROUP BY CutomerId )) g ON a.OrderNumber = g.OrderNo
                                                 AND CONVERT( VARCHAR,g.OrderDate,101) = CONVERT(VARCHAR,a.InvoiceDate,101)
                                                 AND d.CustomerID = g.CutomerId
       LEFT OUTER JOIN( 
                        SELECT *
                          FROM dbWenglee.dbo.tblRouteOrders
                          WHERE ItemId IN(
                        SELECT MAX(itemId)
                          FROM dbWenglee.dbo.tblRouteOrders
                          GROUP BY OrderId )) e ON g.OrderId = e.OrderId
       LEFT OUTER JOIN dbWenglee.dbo.tblRoute f ON e.RouteID = f.RouteId
       LEFT OUTER JOIN dbWenglee.dbo.tblInvoiceStatus h ON h.InvoiceNumber = a.InvoiceNumber COLLATE SQL_Latin1_General_CP1_CI_AS
                                                       AND h.CustomerID = a.CustomerID COLLATE SQL_Latin1_General_CP1_CI_AS
  WHERE b.Pk_id IS NULL
    AND 4321 = 4321
  ORDER BY a.InvoiceDate DESC

                                ]]></QUERY>.Value

        da.SelectCommand.CommandText = query.Replace("WHERE 1234 = 1234", str2).Replace("AND 4321 = 4321", str)

        Try

            da.Fill(dtListofInvoices)
            dgInvoices.DataSource = dtListofInvoices
            dgInvoices.Columns("CustomerId").Visible = False
            For Each dr As DataGridViewRow In dgInvoices.Rows
                If dr.Cells(1).Value Is DBNull.Value OrElse dr.Cells(1).Value = "-" OrElse dr.Cells(1).Value = "" Then
                    dr.Cells(0).Value = "Link with order"
                Else
                    dr.Cells(0).Value = "UnLink order"
                End If


            Next
        Catch ex As Exception
        End Try

    End Sub

    Sub UpdateOrderNumber(InvoiceNumber As String, CustomerID As String, OrderNumber As String)
        Dim dtListofInvoices As New DataTable
        Dim objConn As New clsConnection
        Dim con As SqlConnection = objConn.connectTransfer
        Dim com As New SqlCommand("Update tblInvoices Set OrderNumber='" & OrderNumber & "' Where InvoiceNumber='" & InvoiceNumber & "' AND CustomerId='" & CustomerID & "'", con)
        com.ExecuteNonQuery()

        Dim objConn2 As New clsConnection
        Dim con2 As SqlConnection = objConn2.connect
        Dim com2 As New SqlCommand("Update tblOrder Set InvoiceNumber='" & InvoiceNumber & "' , TotalCartons = isnull((select sum(isnull(TotalCartons,0)) from dbWengleeTransferer.dbo.tblInvoices where InvoiceNumber='" & InvoiceNumber & "'),0) Where OrderNo='" & OrderNumber & "'", con2)
        com2.ExecuteNonQuery()
    End Sub

    Private Sub dgInvoices_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInvoices.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If dgInvoices.Rows(e.RowIndex).Cells(0).Value = "Link with order" Then
                    Dim frm As New frmOrdersSelectDialog
                    Dim od As String = "'-1'"
                    For Each dr As DataGridViewRow In dgInvoices.Rows
                        If Not dr.Cells("OrderNumber").Value Is DBNull.Value Then
                            od += ",'" & dr.Cells("OrderNumber").Value.ToString & "'"
                        End If
                    Next
                    od = " AND a.OrderNo not in (" & od & ")"
                    frm.ExtraSelect = od

                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Try
                            UpdateOrderNumber(dgInvoices.Rows(e.RowIndex).Cells("InvoiceNumber").Value, dgInvoices.Rows(e.RowIndex).Cells("CustomerId").Value, frm.dgOrder.SelectedRows(0).Cells("OrderNo").Value)
                            dgInvoices.Rows(e.RowIndex).Cells("OrderNumber").Value = frm.dgOrder.SelectedRows(0).Cells("OrderNo").Value
                            dgInvoices.Rows(e.RowIndex).Cells(0).Value = "UnLink order"
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
                        End Try
                    End If
                Else
                    If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Conmfirm") = MsgBoxResult.Yes Then
                        UpdateOrderNumber(dgInvoices.Rows(e.RowIndex).Cells("InvoiceNumber").Value, dgInvoices.Rows(e.RowIndex).Cells("CustomerId").Value, "-")
                        dgInvoices.Rows(e.RowIndex).Cells("OrderNumber").Value = "-"
                        dgInvoices.Rows(e.RowIndex).Cells(0).Value = "Link with order"
                    End If

                End If


            ElseIf e.ColumnIndex = 1 Then
                Try
                    ShowOrderDialog(dgInvoices.Rows(e.RowIndex).Cells("OrderNumber").Value, "Order #: " & dgInvoices.Rows(e.RowIndex).Cells("OrderNumber").Value.ToString)
                Catch ex As Exception
                End Try
            ElseIf e.ColumnIndex = 17 Then
                Try
                    Dim frm As New frmInvoiceStatusDialog
                    frm.ComboBox1.Text = dgInvoices.Rows(e.RowIndex).Cells("Status").Value

                    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Try
                            Dim fd As cls_tblInvoiceStatus.Fields = objInvStat.Selection_One_Row(dgInvoices.Rows(e.RowIndex).Cells("InvoiceNumber").Value, dgInvoices.Rows(e.RowIndex).Cells("CustomerID").Value)
                            objInvStat.Update(frm.ComboBox1.Text, dgInvoices.Rows(e.RowIndex).Cells("InvoiceNumber").Value, dgInvoices.Rows(e.RowIndex).Cells("CustomerID").Value)
                        Catch ex As Exception
                            objInvStat.Insert(dgInvoices.Rows(e.RowIndex).Cells("InvoiceNumber").Value, dgInvoices.Rows(e.RowIndex).Cells("CustomerID").Value, frm.ComboBox1.Text)
                        End Try
                        RefreshInvoices()
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Sub ShowOrderDialog(ByVal _OrderId As String, ByVal title As String)
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
        cnt.OpenOrderNo(_OrderId)
        frm.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        RefreshTransfererDB()
        LinkOrder()
        RefreshInvoices()
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

    Private Sub dgInvoices_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInvoices.CellDoubleClick
        Try : Clipboard.SetText(CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value) : Catch ex As Exception : End Try
    End Sub

    Private Sub chkDateRange_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtp1.Enabled = chkDateRange.Checked
        dtp2.Enabled = chkDateRange.Checked
    End Sub

    Private Sub frmInvoices_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        dgInvoices.Columns(2).DisplayIndex = dgInvoices.ColumnCount - 2
        WindowState = FormWindowState.Maximized
    End Sub


    Private Sub btnReload_Click(sender As System.Object, e As System.EventArgs) Handles btnReload.Click
        RefreshInvoices()
    End Sub
End Class