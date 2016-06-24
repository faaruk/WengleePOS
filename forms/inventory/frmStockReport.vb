Public Class frmStockReport
    Dim objStock As New cls_tblStock
    Dim objProduct As New cls_tblProducts
    Dim arranged As Boolean = False
    Sub LoadItems()

        Dim selects As String = ""
        Dim ParameterList As New List(Of SqlParameter)
        ParameterList.Add(New SqlParameter("@StockTill", Now))
        Try
            If cmbProductCategory.SelectedIndex > 0 Then
                selects = " a.Category= @Category "
                ParameterList.Add(New SqlParameter("@Category", cmbProductCategory.Text))
            End If
        Catch ex As Exception
        End Try
        Dim dt As DataTable = objStock.Selection(cls_tblStock.SelectionType.All_Product, selects, ParameterList)
        dgInventory.DataSource = dt
        If Not arranged Then
            dgInventory.Columns("ProductID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgInventory.Columns("ProductCode").Visible = False
            dgInventory.Columns("Brand").Visible = False
            dgInventory.Columns("Price").Visible = False
            dgInventory.Columns("DateCreated").Visible = False
            dgInventory.Columns("DateUpdated").Visible = False
            dgInventory.Columns("CreatedBy").Visible = False
            dgInventory.Columns("UpdatedBy").Visible = False
            dgInventory.Columns("Enabled").Visible = False
            dgInventory.Columns("ProductName").HeaderText = "Product Name"
            dgInventory.Columns("ProductName").ReadOnly = True
            dgInventory.Columns("FullName").HeaderText = "Full Name"
            dgInventory.Columns("FullName").ReadOnly = True
            dgInventory.Columns("Category").HeaderText = "Category"
            dgInventory.Columns("Category").ReadOnly = True
            dgInventory.Columns("Category").Visible = False
            dgInventory.Columns("SubCategory").HeaderText = "Sub-Category"
            dgInventory.Columns("SubCategory").ReadOnly = True
            dgInventory.Columns("SubCategory").Visible = False
            dgInventory.Columns("ProductId").HeaderText = "Product Id"
            dgInventory.Columns("UnitOfMeasure").HeaderText = "Unit Of Measure"
            dgInventory.Columns("UnitOfMeasure").ReadOnly = True
            dgInventory.Columns("Qty").ReadOnly = True
            dgInventory.Columns("Qty").HeaderText = "TotalQty"
            dgInventory.Columns("Qty").DefaultCellStyle.Format = "#,###"
            dgInventory.Columns("Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInventory.Columns("FreshQty").ReadOnly = True
            dgInventory.Columns("FreshQty").DefaultCellStyle.Format = "#,###"
            dgInventory.Columns("FreshQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgInventory.Columns("FrozenQty").ReadOnly = True
            dgInventory.Columns("FrozenQty").DefaultCellStyle.Format = "#,###"
            dgInventory.Columns("FrozenQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'DataGridView1.Columns("Cost Price").ReadOnly = False
            'DataGridView1.Columns("Cost Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DataGridView1.Columns("Selling Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'DataGridView1.Columns("ItemSl").Visible = False
            'DataGridView1.Columns("ls").Visible = False
            'DataGridView1.Columns("lc").Visible = False
            arranged = True
        End If
      

        For Each dr As DataGridViewRow In dgInventory.Rows
            If dr.Cells("Qty").Value <= 0 Then
                dr.Cells("Qty").Style.BackColor = Color.Red
            End If
            If dr.Cells("FreshQty").Value <= 0 Then
                dr.Cells("FreshQty").Style.BackColor = Color.Red
            End If
            If dr.Cells("FrozenQty").Value <= 0 Then
                dr.Cells("FrozenQty").Style.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub frmPriceList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadItems()
        LoadCategory()
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
                cmbProductCategory.Text = "ALL CATEGORIES"
            Else
                cmbProductCategory.Text = tmp
            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInventory.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                Dim frm As New frmStockHistory
                frm.chkDateRange.Checked = True
                frm.DateTimePicker1.Value = Today.AddDays(-11)
                frm.DateTimePicker2.MaxDate = Now.Date.AddDays(1).AddMilliseconds(-1)
                frm.DateTimePicker2.Value = Now.Date.AddDays(1).AddMilliseconds(-1)
                frm.ProductId = dgInventory.Rows(e.RowIndex).Cells("ProductId").Value
                ' frm.Location = MousePosition
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub DataGridView1_Sorted(sender As System.Object, e As System.EventArgs) Handles dgInventory.Sorted
        For Each dr As DataGridViewRow In dgInventory.Rows
            If dr.Cells("Qty").Value <= 0 Then
                dr.Cells("Qty").Style.BackColor = Color.Red
            End If
            If dr.Cells("FreshQty").Value <= 0 Then
                dr.Cells("FreshQty").Style.BackColor = Color.Red
            End If
            If dr.Cells("FrozenQty").Value <= 0 Then
                dr.Cells("FrozenQty").Style.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        dgInventory.Columns(0).Visible = False
        Dim frm As New frmPrintList2
        frm.PrintPreview(dgInventory, "Inventory", "As on " & Today.ToString, "", "", False, "", True, True)
        'DataGridView1.Columns(0).Visible = False
        'DataGridView1.Columns(1).Visible = False
        'Dim dd As Size = DataGridView1.Size
        'DataGridView1.Size = DataGridView1.PreferredSize
        'Dim oBitmap As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        'DataGridView1.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
        'oBitmap.Save("test2.bmp")
        'Process.Start("test2.bmp")
        'DataGridView1.Size = dd
        dgInventory.Columns(0).Visible = True
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim objExport As New clsExportDatagridview
        Dim Header1 As String = "Inventory"
        objExport.StartExport(dgInventory, Header1, "")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmAdjustStock
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadItems()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadItems()

    End Sub
End Class