Public Class frmInventoryList
    Dim objProduct As New cls_tblProducts

    Dim arranged As Boolean = False
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        FillComBoBox(Column2, cls_tblVendor.tablename, cls_tblVendor.FieldName.VendorName.ToString, cls_tblVendor.FieldName.VendorID.ToString)
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub

    Dim objProductPrices As New cls_tblProductPrice
    Dim objtarget As New cls_tblTarget

    Sub LoadItems()
        Dim ParameterList As New List(Of SqlParameter)
        ParameterList.Add(New SqlParameter("@StockTill", Now))
        Dim selects As String = ""
        If cmbProductCategory.SelectedIndex > 0 Then
            'selects = " Category= '" & cmbProductCategory.Text & "' AND "
            selects = " a.Category= @Category AND  "
            ParameterList.Add(New SqlParameter("@Category", cmbProductCategory.Text))
        End If


        If ComboBox1.SelectedIndex = 1 Then
            selects += " a.Enabled = 'true' and "
        ElseIf ComboBox1.SelectedIndex = 2 Then
            selects += " a.Enabled = 'false' and "
        End If

        If ComboBox2.SelectedIndex = 1 Then
            selects += " a.TrackInventory = 'true' and "
        ElseIf ComboBox2.SelectedIndex = 2 Then
            selects += " a.TrackInventory = 'false' and "
        End If


        Try
            Dim dt As DataTable = objProductPrices.Selection(cls_tblProductPrice.SelectionType.All_Product, selects & " 1=1 Order By a.[ProductId]", ParameterList)
            If Not arranged Then
                'DataGridView1.DataSource = Nothing
                For Each ca As DataGridViewColumn In From ccc As DataGridViewColumn In DataGridView1.Columns Order By ccc.DisplayIndex Select ccc
                    ca.Frozen = False
                Next
                For Each ca As DataGridViewColumn In DataGridView1.Columns
                    ca.DisplayIndex = ca.Index
                Next
                For Each ca As DataGridViewColumn In DataGridView1.Columns
                    ca.DisplayIndex = ca.Index
                Next
                For Each ca As DataGridViewColumn In DataGridView1.Columns
                    ca.DisplayIndex = ca.Index
                Next
                For Each ca As DataGridViewColumn In DataGridView1.Columns
                    ca.Frozen = False
                Next
            End If


            DataGridView1.DataSource = dt
            If Not arranged Then

                'DataGridView1.Columns("ProductCode").Visible = False
                DataGridView1.Columns("Code").DefaultCellStyle.BackColor = Color.LightGray
                DataGridView1.Columns("Code").ReadOnly = True

                DataGridView1.Columns("Brand").Visible = False
                DataGridView1.Columns("Price").Visible = False
                DataGridView1.Columns("DateCreated").Visible = False
                DataGridView1.Columns("DateUpdated").Visible = False

                DataGridView1.Columns("CreatedBy").Visible = False
                DataGridView1.Columns("UpdatedBy").Visible = False
                DataGridView1.Columns("Enabled").Visible = False

                DataGridView1.Columns("ProductName").HeaderText = "Product Name"
                DataGridView1.Columns("ProductName").ReadOnly = True
                DataGridView1.Columns("ProductName").DefaultCellStyle.BackColor = Color.LightGray

                DataGridView1.Columns("FullName").HeaderText = "Full Name"
                DataGridView1.Columns("FullName").ReadOnly = True
                DataGridView1.Columns("FullName").DefaultCellStyle.BackColor = Color.LightGray
                DataGridView1.Columns("FullName").Visible = False

                DataGridView1.Columns("Category").HeaderText = "Category"
                DataGridView1.Columns("Category").ReadOnly = True
                DataGridView1.Columns("Category").Visible = False

                DataGridView1.Columns("SubCategory").HeaderText = "Sub-Category"
                DataGridView1.Columns("SubCategory").ReadOnly = True
                DataGridView1.Columns("SubCategory").Visible = False

                'DataGridView1.Columns("ProductId").HeaderText = "Product Id"
                DataGridView1.Columns("ProductId").HeaderText = "Id"
                DataGridView1.Columns("ProductId").DefaultCellStyle.BackColor = Color.LightGray

                DataGridView1.Columns("UnitOfMeasure").HeaderText = "Unit Of Measure"
                DataGridView1.Columns("UnitOfMeasure").ReadOnly = True
                DataGridView1.Columns("UnitOfMeasure").DefaultCellStyle.BackColor = Color.LightGray

                DataGridView1.Columns("StockQty").ReadOnly = True
                ' DataGridView1.Columns("StockQty").HeaderText = "Qty in Stock"
                DataGridView1.Columns("StockQty").HeaderText = "TotalQty"

                'DataGridView1.Columns("StockQty").DefaultCellStyle.BackColor = Color.LightGray
                DataGridView1.Columns("StockQty").DefaultCellStyle.Format = "#,##0"
                DataGridView1.Columns("StockQty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns("FreshStock").ReadOnly = True
                DataGridView1.Columns("FreshStock").HeaderText = "FreshQty"

                DataGridView1.Columns("FreshStock").DefaultCellStyle.Format = "#,##0"
                DataGridView1.Columns("FreshStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns("FrozenStock").ReadOnly = True
                DataGridView1.Columns("FrozenStock").HeaderText = "FrozenQty"
                DataGridView1.Columns("FrozenStock").DefaultCellStyle.Format = "#,##0"
                DataGridView1.Columns("FrozenStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'DataGridView1.Columns("Future Orders").ReadOnly = True
                'ColumnsFutureOrders.HeaderText = "Future Frozen/Fresh"
                'DataGridView1.Columns("Future Orders").DefaultCellStyle.Format = "#,##0"
                'DataGridView1.Columns("Future Orders").DefaultCellStyle.BackColor = Color.LightGray
                'DataGridView1.Columns("Future Orders").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'DataGridView1.Columns("Target Stock Levels").ReadOnly = True
                DataGridView1.Columns("Target Stock Levels").HeaderText = "Target Stock Levels"
                DataGridView1.Columns("Target Stock Levels").DefaultCellStyle.Format = "#,##0"
                'DataGridView1.Columns("Target Stock Levels").DefaultCellStyle.BackColor = Color.LightGray
                DataGridView1.Columns("Target Stock Levels").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'DataGridView1.Columns("Cost Price").ReadOnly = False
                'DataGridView1.Columns("Cost Price").DefaultCellStyle.BackColor = Color.LightGray

                DataGridView1.Columns("UnitOfMesuare2").HeaderText = "Selling Unit Of Measure"
                DataGridView1.Columns("UnitOfMesuare2").Visible = False
                'DataGridView1.Columns("UnitOfMeasure2").ReadOnly = True
                DataGridView1.Columns("VendorItemCode").HeaderText = "Vendor Item Code"
                'DataGridView1.Columns("VendorItemCode").ReadOnly = True

                DataGridView1.Columns("Cost Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DataGridView1.Columns("Cost Price").Visible = False
                DataGridView1.Columns("Selling Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DataGridView1.Columns("Selling Price").Visible = False

                DataGridView1.Columns("ItemSl").Visible = False
                DataGridView1.Columns("ls").Visible = False
                DataGridView1.Columns("lc").Visible = False
                DataGridView1.Columns("vi").Visible = False
                DataGridView1.Columns("um2").Visible = False
                DataGridView1.Columns("vc").Visible = False
                DataGridView1.Columns("ColumnMargin").DefaultCellStyle.Format = "#,##0.00%"
                DataGridView1.Columns("ColumnMargin").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'DataGridView1.Columns("ColumnMargin").DefaultCellStyle.BackColor = Color.LightGray
                'DataGridView1.Columns("ColumnVendor").DisplayIndex = 23
                DataGridView1.Columns("ColumnVendor").Visible = False
                DataGridView1.Columns("ColumnsFutureOrders").DefaultCellStyle.Format = "#,##0"
                ''arranged = True
            End If


            DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)


            UpdateColor()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmPriceList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1
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
                'cmbProductCategory.Text = "ALL CATEGORIES"
                cmbProductCategory.Text = "Poultry Parts/Meat"
            Else
                cmbProductCategory.Text = tmp
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim errCnt As Integer = 0
            For Each dr As DataGridViewRow In DataGridView1.Rows
                If dr.Cells("Cost Price").Value <> dr.Cells("lc").Value Or dr.Cells("Selling Price").Value <> dr.Cells("ls").Value Or dr.Cells("Column2").Value <> dr.Cells("vi").Value Or dr.Cells("UnitOfMesuare2").Value <> dr.Cells("um2").Value Or dr.Cells("VendorItemCode").Value <> dr.Cells("vc").Value Then
                    Try
                        Dim pps As cls_tblProductPrice.Fields = objProductPrices.Selection_One_Row(ExecuteAdapter("Select Max(itemSl) from tblProductPrice where PID=" & dr.Cells("ProductId").Value).Rows(0).Item(0))
                        objProductPrices.Insert(PID:=dr.Cells("ProductId").Value, CostPrice:=pps.CostPrice, _
                                                                          SellPrice:=pps.SellPrice, EntryDate:=Now, UserId:=UserId, VendorId:=dr.Cells("Column2").Value, UnitOfMesuare:=pps.UnitOfMesuare, VendorItemCode:=dr.Cells("VendorItemCode").Value)
                    Catch ex As Exception
                        Try
                            objProductPrices.Insert(PID:=dr.Cells("ProductId").Value, CostPrice:=dr.Cells("Cost Price").Value, _
                                                                          SellPrice:=dr.Cells("Selling Price").Value, EntryDate:=Now, UserId:=UserId, VendorId:=dr.Cells("Column2").Value, UnitOfMesuare:=dr.Cells("UnitOfMesuare2").Value, VendorItemCode:=dr.Cells("VendorItemCode").Value)
                        Catch ex2 As Exception
                            errCnt += 1
                        End Try
                    End Try

                End If
                objtarget.Insert(dr.Cells("ProductId").Value, dr.Cells("Target Stock Levels").Value, dr.Cells("Target Stock Levels").Value, 0, Now, UserId, "", "")
            Next
            If errCnt > 0 Then
                Throw New Exception("Some entries not Updated")
            End If
            MsgBox("Updated", MsgBoxStyle.Information, "Info")
            LoadItems()
            setDI()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                Dim frm As New frmPriceHistory
                frm.ProductId = DataGridView1.Rows(e.RowIndex).Cells("ProductId").Value
                'frm.Location = MousePosition
                frm.ShowDialog()
            ElseIf e.ColumnIndex = 1 Then
                Dim frm As New frmStockHistory
                frm.chkDateRange.Checked = True
                frm.DateTimePicker1.Value = Today.AddDays(-11)
                frm.DateTimePicker2.MaxDate = Now.Date.AddDays(1).AddMilliseconds(-1)
                frm.DateTimePicker2.Value = Now.Date.AddDays(1).AddMilliseconds(-1)
                frm.ProductId = DataGridView1.Rows(e.RowIndex).Cells("ProductId").Value
                frm.ShowDialog()
            ElseIf e.ColumnIndex = 2 Then
                Dim frm As New frmProductTarget
                frm.ProductId = DataGridView1.Rows(e.RowIndex).Cells("ProductId").Value
                frm.ShowDialog()
            ElseIf e.ColumnIndex = 34 Then
                Dim frm As New frmStockFutureOrders
                frm.Text = "Future Orders"
                frm.ProductId = DataGridView1.Rows(e.RowIndex).Cells("ProductId").Value
                frm.ShowDialog()
            ElseIf e.ColumnIndex = 4 Then
                Dim frm As New frmFZWeights
                ' frm.Text = "Future Orders"
                frm.ProductId = DataGridView1.Rows(e.RowIndex).Cells("ProductId").Value
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub frmPriceList_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        UpdateColor()
        WindowState = FormWindowState.Maximized
        setDI()
    End Sub
    Sub setDI()
        DataGridView1.Columns("ColumnMargin").DisplayIndex = 21
        DataGridView1.Columns("ColumnsFutureOrders").DisplayIndex = 33
        DataGridView1.Columns(0).DisplayIndex = DataGridView1.Columns.Count - 1
        DataGridView1.Columns(1).DisplayIndex = DataGridView1.Columns.Count - 1
        DataGridView1.Columns("VendorItemCode").DisplayIndex = DataGridView1.Columns.Count - 1
        DataGridView1.Columns("ColumnVendor").DisplayIndex = DataGridView1.Columns.Count - 1
        DataGridView1.Columns("Column2").DisplayIndex = DataGridView1.Columns.Count - 1
        DataGridView1.Columns("UnitOfMeasure").Frozen = True
    End Sub
    Sub UpdateColor()
        Try
            For Each dr As DataGridViewRow In DataGridView1.Rows

                If dr.Cells("StockQty").Value <= 0 Then
                    dr.Cells("StockQty").Style.BackColor = Color.Red
                Else
                    dr.Cells("StockQty").Style.BackColor = Color.LightGray
                End If
                If dr.Cells("FreshStock").Value <= 0 Then
                    dr.Cells("FreshStock").Style.BackColor = Color.Red
                Else
                    dr.Cells("FreshStock").Style.BackColor = Color.LightGray
                End If

                If dr.Cells("FrozenStock").Value <= 0 Then
                    dr.Cells("FrozenStock").Style.BackColor = Color.Red
                Else
                    dr.Cells("FrozenStock").Style.BackColor = Color.LightGray
                End If

                Try
                    dr.Cells("ColumnMargin").Value = Math.Round((Val(dr.Cells("Selling Price").Value) - Val(dr.Cells("Cost Price").Value)) / Val(dr.Cells("Selling Price").Value), 2)
                    If Val(dr.Cells("Cost Price").Value) = 0 Or Val(dr.Cells("Selling Price").Value) = 0 Then
                        dr.Cells("ColumnMargin").Value = 0
                    End If
                Catch ex As Exception
                    dr.Cells("ColumnMargin").Value = 0
                End Try

                If dr.Cells("ColumnMargin").Value <= 0 Then
                    dr.Cells("ColumnMargin").Style.BackColor = Color.Red
                Else
                    dr.Cells("ColumnMargin").Style.BackColor = Color.LightGray
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView1_Sorted(sender As System.Object, e As System.EventArgs) Handles DataGridView1.Sorted
        UpdateColor()

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        Try

            For Each dr As DataGridViewRow In DataGridView1.Rows
                Try
                    dr.Cells("ColumnMargin").Value = Math.Round((Val(dr.Cells("Selling Price").Value) - Val(dr.Cells("Cost Price").Value)) / Val(dr.Cells("Selling Price").Value), 2)
                    If Val(dr.Cells("Cost Price").Value) = 0 Or Val(dr.Cells("Selling Price").Value) = 0 Then
                        dr.Cells("ColumnMargin").Value = 0
                    End If
                Catch ex As Exception
                    dr.Cells("ColumnMargin").Value = 0
                End Try
            Next

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        'DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns("Column2").Visible = False
        DataGridView1.Columns("ColumnVendor").Visible = True
        Dim frm As New frmPrintList2
        frm.PrintPreview(DataGridView1, "Inventory", "As on " & Today.ToString, "", "", True, "", True, True)
        'DataGridView1.Columns(0).Visible = False
        'DataGridView1.Columns(1).Visible = False
        'Dim dd As Size = DataGridView1.Size
        'DataGridView1.Size = DataGridView1.PreferredSize
        'Dim oBitmap As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        'DataGridView1.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
        'oBitmap.Save("test2.bmp")
        'Process.Start("test2.bmp")
        'DataGridView1.Size = dd
        'DataGridView1.Columns(0).Visible = True
        DataGridView1.Columns(1).Visible = True
        DataGridView1.Columns("Column2").Visible = True
        DataGridView1.Columns("ColumnVendor").Visible = False
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim objExport As New clsExportDatagridview
        Dim Header1 As String = "Inventory List"
        objExport.StartExport(DataGridView1, Header1, "")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim frm As New frmAdjustStock
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadItems()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadItems()
        UpdateColor()
        setDI()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class