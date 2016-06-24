Public Class frmOrdersHistory

    'Dim objOrderStatus As New cls_tblOrderStatus

    Dim objOrderItems As New cls_tblOrderItems

    Dim objOrders As New cls_tblOrder

    'Dim objCustomerBOL As New cls_tblCustomer_BOL
    Public CustomerID As Integer = 0
    Private Sub dgInvoices_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgOrder.CellDoubleClick
        Try : Clipboard.SetText(CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex).Value) : Catch ex As Exception : End Try
    End Sub
    Sub RefreshDG()
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)
            Dim pp2 As New List(Of SqlParameter)

            If CustomerID = 0 Then
                SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] Between @d1 and @d2"
                pp.Add(New SqlParameter("@d1", Today.AddDays(-5)))
                pp.Add(New SqlParameter("@d2", Today.AddDays(1000).AddSeconds(-1)))
                pp2.Add(New SqlParameter("@d1", Today.AddDays(-5)))
                pp2.Add(New SqlParameter("@d2", Today.AddDays(1000).AddSeconds(-1)))
            Else

            End If


            If CustomerID > 0 Then
                SelectString += " AND a.[" & cls_tblOrder.FieldName.CutomerId.ToString & "] =@CID"
                pp.Add(New SqlParameter("@CID", CustomerID))
                pp2.Add(New SqlParameter("@CID", CustomerID))

            End If
            dgOrder.DataSource = Nothing

            Dim selecteRow As Integer = 0
            Dim topRow As Integer = 0
            Try
                topRow = dgOrder.FirstDisplayedScrollingRowIndex
                selecteRow = dgOrder.SelectedRows(0).Index
            Catch ex As Exception
            End Try



            Dim dt As DataTable = objOrders.Selection(cls_tblOrder.SelectionType.ReviewOrder, SelectString & " Order By a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] desc", pp)
            dgOrder.DataSource = dt
            dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            dgOrder.Columns("route").Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CreatedBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CutomerId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderAmount.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderSl.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusDate.ToString).Visible = False

            dgOrder.Columns("CustomerName").HeaderText = "Customer Name"
            dgOrder.Columns("RouteCity").HeaderText = "Route City"

            Try
                dgOrder.FirstDisplayedScrollingRowIndex = topRow
                dgOrder.SelectedRows(0).Selected = False
            Catch ex As Exception
            End Try
            Try
                dgOrder.Rows(selecteRow).Selected = True
            Catch ex As Exception
            End Try


            ' AddPrintLabelButton()

            dgOrder.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).DisplayIndex = 0
            dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).Width = 85
            dgOrder.Columns(cls_tblOrder.FieldName.OrderDate.ToString).Frozen = True
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).DisplayIndex = 1
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Width = 85
            'dgOrder.Columns(cls_tblOrder.FieldName.DeliveryDate.ToString).Frozen = True

            dgOrder.Columns("Posting Date").DisplayIndex = 1
            dgOrder.Columns("Posting Date").Width = 85
            dgOrder.Columns("Posting Date").Frozen = True


            dgOrder.Columns("CustomerName").DisplayIndex = 2
            dgOrder.Columns("CustomerName").Frozen = True
            dgOrder.Columns("RouteCity").DisplayIndex = 3
            dgOrder.Columns("City").DisplayIndex = 4
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).DisplayIndex = 5
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).Width = 60
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).HeaderText = "Total Items"
            dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).DisplayIndex = 6
            If dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width > 250 Then
                dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Width = 250
            End If
            dgOrder.Columns(cls_tblOrder.FieldName.Status.ToString).DisplayIndex = 7
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedBy.ToString).DisplayIndex = 8
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).DisplayIndex = 9
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).Width = 90
            dgOrder.Columns(cls_tblOrder.FieldName.OrderNo.ToString).DisplayIndex = 10
            dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).DisplayIndex = 11
            dgOrder.Columns(cls_tblOrder.FieldName.Session.ToString).Width = 70
            dgOrder.Columns(cls_tblOrder.FieldName.Remarks.ToString).DisplayIndex = 12
            ' dgOrder.Columns("Drop Off Point").DisplayIndex = 13
            Counter()
            If CustomerID > 0 Then
                dgOrder.Columns("CustomerName").Visible = False
                dgOrder.Columns("City").Visible = False
                dgOrder.Columns("RouteCity").Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
  
    Private Sub frmOrdersView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RefreshDG()
    End Sub
    Sub Counter()
        Dim c As Integer = 0
        Dim od As String = "-1"
        For Each dr As DataGridViewRow In dgOrder.Rows
            c += dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value.ToString
            od += "," & dr.Cells(cls_tblOrder.FieldName.OrderId.ToString).Value.ToString
        Next
        Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.UNIT_WISE_TOTAL, "a.OrderId in (" & od.ToString & ") group by b. UnitOfMeasure ")
        lblTotalOrder.Text = "Total : " & dgOrder.Rows.Count.ToString & " Order(s)" & " Total Qty : " '& c.ToString '& " Case(s)"
        For Each dr As DataRow In orderItems.Rows
            lblTotalOrder.Text += dr("Total").ToString & " " & dr("Unit").ToString & ", " 'Case(s)"
        Next
    End Sub
    Private Sub dgOrder_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrder.SelectionChanged
        Try
            CntlOrderView1.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value)
        Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Information, "Info {FMVO-01}")
            CntlOrderView1.Clear()
        End Try
    End Sub


    Private Sub frmOrdersView_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub


    Private Sub btnUnlinkBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgOrder.SelectedRows(0).Cells("BOL").Value.ToString = "NO" Then
            MsgBox("BOL address not linked", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                Dim con As SqlConnection = (New clsConnection).connect
                Try
                    Dim com1 As New SqlCommand("Update tblOrder set BOLAddressID=0 where OrderID=" & dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString, con)
                    com1.ExecuteNonQuery()
                Catch ex As Exception
                End Try
                Dim com As New SqlCommand("Update tblCustomer set BOL='NO' where customerid=" & dgOrder.SelectedRows(0).Cells("cutomerid").Value.ToString, con)
                com.ExecuteNonQuery()
                MsgBox("Done", MsgBoxStyle.Information, "Info")
                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

End Class