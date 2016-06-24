Public Class frmPickedQuantities
    Dim objProduct As New cls_tblProducts
    Sub LoadPickedQuatities()
        Try
            Dim pp As New List(Of SqlParameter)
            pp.Add(New SqlParameter("@d1", DateTimePicker1.Value.Date))
            pp.Add(New SqlParameter("@d2", DateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1)))
            Dim selects As String = ""
            If cmbProductCategory.SelectedIndex > 0 Then
                selects = " AND  b.Category= @Category "
                pp.Add(New SqlParameter("@Category", cmbProductCategory.Text))
            End If

            Dim dt As DataTable = ExecuteAdapter(cls_tblOrderItems.tblOrderItems_Select_PickedQuantities.ToString.Replace("#####", selects), pp)
            DataGridView1.DataSource = dt
            DataGridView1.Columns("ProductId").Visible = False
            DataGridView1.Columns("ProductName").HeaderText = "Product Name"
            DataGridView1.Columns("Category").HeaderText = "Category"
            DataGridView1.Columns("Fresh").HeaderText = "Fresh" ' (Cases)"
            DataGridView1.Columns("Frozen").HeaderText = "Frozen" ' (Cases)"
            DataGridView1.Columns("Fresh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("Frozen").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns("ColumnsFutureOrders").DefaultCellStyle.Format = "#,##0"
            DataGridView1.Columns(DataGridView1.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Counter()
        Catch ex As Exception
        End Try
    End Sub

    Sub Counter()
        Dim pp As New List(Of SqlParameter)
        pp.Add(New SqlParameter("@d1", DateTimePicker1.Value.Date))
        pp.Add(New SqlParameter("@d2", DateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1)))
        Dim selects As String = ""
        If cmbProductCategory.SelectedIndex > 0 Then
            selects = " AND b.Category= @Category "
            pp.Add(New SqlParameter("@Category", cmbProductCategory.Text))
        End If
        Dim dt As DataTable = ExecuteAdapter(cls_tblOrderItems.tblOrderItems_Select_PickedQuantities_total.ToString.Replace("#####", selects), pp)

        lblTotalOrder.Text = "Total : "
        For Each dr As DataRow In dt.Rows
            lblTotalOrder.Text += dr("Total").ToString & " " & dr("Unit").ToString & ", "
        Next
    End Sub
    Sub LoadCategory()
        Dim tmp As String = ""
        Try
            tmp = cmbProductCategory.Text
        Catch ex As Exception
        End Try
        cmbProductCategory.Items.Clear()
        cmbProductCategory.Items.Add("ALL CATEGORIES")
        For Each dr As DataRow In objProduct.SelectDistinct(cls_tblProducts.FieldName.Category).Rows
            Try
                If dr(0).ToString.Trim <> "" Then
                    cmbProductCategory.Items.Add(dr(0).ToString)
                End If
            Catch ex As Exception

            End Try

        Next

        Try
            If tmp.Trim = "" Then
                cmbProductCategory.Text = "Poultry"
            Else
                cmbProductCategory.Text = tmp
            End If

        Catch ex As Exception
        End Try

    End Sub


    Private Sub frmPickedQuantities_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCategory()
        LoadPickedQuatities()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintList
        frm.PrintPreview(DataGridView1, "Case Totals of " & DateTimePicker1.Value.ToShortDateString, "", "", "", False, "", False, True)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim objp As New clsPrintCaseTotal_MSEXCEL
        objp.CreateRouteSheet(DataGridView1, DateTimePicker1.Value, DateTimePicker2.Value, cmbProductCategory.Text)
    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                Dim frm As New frmStockHistory
                frm.chkDateRange.Checked = True
                frm.DateTimePicker1.Value = DateTimePicker1.Value '.Date '.AddDays(-11)
                'frm.DateTimePicker2.MaxDate = Now.Date.AddDays(1).AddSeconds(-1)
                'frm.DateTimePicker2.MaxDate = DateAdd(DateInterval.Day, 365, Now)
                frm.DateTimePicker2.Value = DateTimePicker2.Value '.Date.AddDays(1).AddSeconds(-1)
                frm.ProductId = DataGridView1.Rows(e.RowIndex).Cells("ProductId").Value
                ' frm.DateTimePicker1.Refresh()
                frm.ShowDialog()
            ElseIf e.ColumnIndex = 9 Then
                Dim frm As New frmStockFutureOrders
                frm.Text = "Future Orders"
                frm.ProductId = DataGridView1.Rows(e.RowIndex).Cells("ProductId").Value
                frm.ShowDialog()
            End If
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadPickedQuatities()
    End Sub
End Class