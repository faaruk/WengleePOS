Public Class frmOrdersCancelList
    Dim objOrder As New cls_tblOrder
    Dim objOrderStatus As New cls_tblOrderStatus
    Dim objStock As New cls_tblStock
    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        dtpFrom.Enabled = chkDateRange.Checked
        dtpTo.Enabled = chkDateRange.Checked
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        cmbStatus.Enabled = chkStatus.Checked
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshDG()
    End Sub

    Sub RefreshDG()
        Try
            Dim SelectString As String = ""
            Dim pp As New List(Of SqlParameter)

            If chkStatus.Checked Then
                SelectString += " AND a.[" & cls_tblOrder.FieldName.Status.ToString & "]=@status"
                pp.Add(New SqlParameter("@status", cmbStatus.Text))
            End If
            If chkDateRange.Checked Then
                SelectString += " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] Between @d1 and @d2"
                pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date))
                pp.Add(New SqlParameter("@d2", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)))
            End If
            dgOrder.DataSource = Nothing
            Dim dt As DataTable = objOrder.Selection(cls_tblOrder.SelectionType.ReviewOrder, SelectString, pp)
            dgOrder.DataSource = dt
            dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.Comments.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CreatedBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CreatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.CutomerId.ToString).Visible = False
            dgOrder.Columns("route").Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderAmount.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderSl.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.OrderId.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.StatusDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedBy.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.UpdatedDate.ToString).Visible = False
            dgOrder.Columns(cls_tblOrder.FieldName.TotalItems.ToString).HeaderText = "Total cases"

            dgOrder.Columns("CustomerName").HeaderText = "Customer Name"
            dgOrder.Columns("RouteCity").HeaderText = "Route City"
            'dgOrder.Columns("").HeaderText = ""
            dgOrder.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            'dgOrder.Columns(cls_tblOrder.FieldName.BranchId.ToString).Visible = False
            Counter()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub btnEditOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditOrder.Click
        If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Try
                objOrder.Update_field(cls_tblOrder.FieldName.Status, "Cancelled", "OrderID=" & dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString)
                objOrderStatus.Insert(dgOrder.SelectedRows(0).Cells("OrderID").Value, "Cancelled", "", "", Now, Now, UserId)
                objStock.Delete_By_SELECT("TransactionId=" & dgOrder.SelectedRows(0).Cells("OrderID").Value.ToString & " and TransactionType='ORDER'", Nothing)
                MsgBox("Cancelled", MsgBoxStyle.Information, "Info")
                RefreshDG()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub


    Private Sub frmOrdersCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkStatus.Checked = True
        cmbStatus.SelectedIndex = 1

        chkDateRange.Checked = True
        dtpFrom.Value = Today
        dtpTo.Value = Today

        RefreshDG()
    End Sub

    Sub Counter()
        Dim c As Integer = 0
        Dim od As String = "-1"
        For Each dr As DataGridViewRow In dgOrder.Rows
            c += Val(dr.Cells(cls_tblOrder.FieldName.TotalItems.ToString).Value.ToString)
            od += "," & dr.Cells(cls_tblOrder.FieldName.OrderId.ToString).Value.ToString
            If dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Cancelled") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("No Order") Then
                dr.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Delivery") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Delivered") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Open") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Fulfilled") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Hold") Then
                dr.DefaultCellStyle.BackColor = Color.Red
            Else
                dr.DefaultCellStyle.BackColor = Nothing
            End If
        Next
        lblTotalOrder.Text = "Total : " & dgOrder.Rows.Count.ToString & " Order(s)        Total Qty: " & c.ToString '& " Case(s)"
    End Sub
    Private Sub dgOrder_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrder.SelectionChanged
        Try
            CntlOrderView1.OpenOrder(dgOrder.SelectedRows(0).Cells("OrderId").Value)
        Catch ex As Exception
            CntlOrderView1.Clear()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub dgOrder_Sorted(sender As Object, e As EventArgs) Handles dgOrder.Sorted

        For Each dr As DataGridViewRow In dgOrder.Rows
            If dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Cancelled") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("No Order") Then
                dr.DefaultCellStyle.BackColor = Color.LightGray
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Delivery") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Delivered") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Open") Or dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.StartsWith("Fulfilled") Then
                dr.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192)
            ElseIf dr.Cells(cls_tblOrder.FieldName.Status.ToString).Value.ToString.Contains("On Hold") Then
                dr.DefaultCellStyle.BackColor = Color.Red
            Else
                dr.DefaultCellStyle.BackColor = Nothing
            End If
        Next
    End Sub
End Class