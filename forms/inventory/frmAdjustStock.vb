Public Class frmAdjustStock

    Private Sub frmAdjustStock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadItems()
    End Sub
    Dim objStock As New cls_tblStock 
    Sub LoadItems()

        Dim ParameterList As New List(Of SqlParameter)
        ParameterList.Add(New SqlParameter("@StockTill", Now))
        Dim dt As DataTable = objStock.Selection(cls_tblStock.SelectionType.All_Product, "", ParameterList)
        dgInventory.DataSource = dt
        dgInventory.Columns("ProductID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgInventory.Columns("ProductCode").Visible = False
        dgInventory.Columns("Brand").Visible = False
        dgInventory.Columns("Price").Visible = False
        dgInventory.Columns("DateCreated").Visible = False
        dgInventory.Columns("DateUpdated").Visible = False
        dgInventory.Columns("CreatedBy").Visible = False
        dgInventory.Columns("UpdatedBy").Visible = False
        dgInventory.Columns("Enabled").Visible = False
        dgInventory.Columns("Frozen Qty Detail").Visible = False
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
            dr.Cells(0).Value = Val(dr.Cells("FrozenQty").Value)
            dr.Cells(1).Value = Val(dr.Cells("FreshQty").Value)
            dr.Cells(2).Value = Val(dr.Cells("Qty").Value)
        Next

        dgInventory.Columns(2).DisplayIndex = dgInventory.ColumnCount - 1
        dgInventory.Columns(1).DisplayIndex = dgInventory.ColumnCount - 2
        dgInventory.Columns(0).DisplayIndex = dgInventory.ColumnCount - 3
    End Sub
    Private Sub frmAdjustStock_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub dgInventory_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgInventory.CellEndEdit
        If e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case 0
                    If dgInventory.Rows(e.RowIndex).Cells(0).Value = Val(dgInventory.Rows(e.RowIndex).Cells("FrozenQty").Value) Then
                        dgInventory.Rows(e.RowIndex).Cells(0).Style.BackColor = Color.White
                        dgInventory.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.White
                    Else
                        dgInventory.Rows(e.RowIndex).Cells(0).Style.BackColor = Color.WhiteSmoke
                        dgInventory.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.WhiteSmoke
                    End If
                    dgInventory.Rows(e.RowIndex).Cells(2).Value = Val(dgInventory.Rows(e.RowIndex).Cells(0).Value) + Val(dgInventory.Rows(e.RowIndex).Cells(1).Value)
                Case 1
                    If dgInventory.Rows(e.RowIndex).Cells(1).Value = Val(dgInventory.Rows(e.RowIndex).Cells("FreshQty").Value) Then
                        dgInventory.Rows(e.RowIndex).Cells(1).Style.BackColor = Color.White
                        dgInventory.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.White
                    Else
                        dgInventory.Rows(e.RowIndex).Cells(1).Style.BackColor = Color.WhiteSmoke
                        dgInventory.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.WhiteSmoke
                    End If
                    dgInventory.Rows(e.RowIndex).Cells(2).Value = Val(dgInventory.Rows(e.RowIndex).Cells(0).Value) + Val(dgInventory.Rows(e.RowIndex).Cells(1).Value)
            End Select
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        For Each dr As DataGridViewRow In dgInventory.Rows
            If dr.Cells(0).Value <> Val(dr.Cells("FrozenQty").Value) Or dr.Cells(1).Value <> Val(dr.Cells("FreshQty").Value) Then
                Dim fr As Integer = Val(dr.Cells(1).Value) - Val(dr.Cells("FreshQty").Value)
                Dim fz As Integer = Val(dr.Cells(0).Value) - Val(dr.Cells("FrozenQty").Value)
                Dim tq As Integer = fr + fz
                objStock.Insert(ProductId:=dr.Cells("ProductID").Value, Qty:=tq, TransactionId:=0, TransactionType:="ADJUST", Stocktype:="IN", CreatedBy:=UserId, CreatedDate:=Now, Remarks:="", Fresh:=fr, Frozen:=fz, TransactionDate:=Now)
            End If
        Next
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub
End Class