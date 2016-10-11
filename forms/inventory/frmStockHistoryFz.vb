Public Class frmStockHistoryFz

    Dim objProductPrice As New cls_tblStock
    Dim objStock As New cls_t_tblStock
    Dim objProduct As New cls_tblProducts
    Private _ProductID As Integer = 0

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'DateTimePicker1.MaxDate = Now
        'DateTimePicker2.MaxDate = Now
        'Me.DateTimePicker2.MaxDate = DateAdd(DateInterval.Day, 365, Now)
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property ProductId As Integer
        Get
            Return _ProductID
        End Get
        Set(value As Integer)
            _ProductID = value
            LoadList()
        End Set
    End Property

    Sub LoadList()
        Try
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@StockTill", Now))
            Dim strNew As String = ""
            Dim ret As New cls_t_tblStock.Stocks
            If chkDateRange.Checked Then
                strNew = "and a.TransactionDate Between @d1 and @d2"
                paramList.Add(New SqlParameter("@d1", DateTimePicker1.Value.Date))
                'paramList.Add(New SqlParameter("@d2", DateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1)))
                paramList.Add(New SqlParameter("@d2", DateTimePicker2.Value.Date.AddMilliseconds(-1)))
                Try
                    ret = objStock.StockTill(_ProductID, DateTimePicker1.Value.Date.AddSeconds(-1))
                Catch ex As Exception
                End Try
            End If
            If chkFresh.Checked And chkFrozen.Checked Then

            ElseIf chkFresh.Checked Then
                strNew += " and a.Fresh >0"
            ElseIf chkFrozen.Checked Then
                strNew += " and a.Frozen >0"
            End If
            paramList.Add(New SqlParameter("@ProductID", _ProductID))

            Dim dt As DataTable = objProductPrice.Selection(cls_tblStock.SelectionType.OtherInfo_withoutTotal, "a.[ProductId]=@ProductID and a.TransactionDate<=@StockTill and a.[Frozen]<>0 " & strNew & " Order By a.transactiondate Desc, a.createddate desc, a.stockid desc", paramList)

            Try
                Dim qtfs As Integer = ret.freshQty
                Dim qtfz As Integer = ret.froZenQty
                Dim qt As Integer = ret.totalQty

                For i = dt.Rows.Count - 1 To 0 Step -1
                    Dim dr As DataRow = dt.Rows(i)
                    If dr("Stocktype") = "IN" Then
                        Try
                            qtfs += Val(dr("Fresh"))
                        Catch ex As Exception
                        End Try
                        Try
                            qtfz += Val(dr("Frozen"))
                        Catch ex As Exception
                        End Try
                        Try
                            qt += Val(dr("Qty"))
                        Catch ex As Exception
                        End Try
                    Else
                        Try
                            qtfs -= Val(dr("Fresh"))
                        Catch ex As Exception
                        End Try
                        Try
                            qtfz -= Val(dr("Frozen"))
                        Catch ex As Exception
                        End Try
                        Try
                            qt -= Val(dr("Qty"))
                        Catch ex As Exception
                        End Try
                    End If

                    Try
                        dr("Total Fresh") = qtfs
                    Catch ex As Exception
                    End Try
                    Try
                        dr("Total Frozen") = qtfz
                    Catch ex As Exception
                    End Try
                    Try
                        dr("Total Qty") = qt
                    Catch ex As Exception
                    End Try

                    Application.DoEvents()
                Next
            Catch ex As Exception
            End Try
            Dim TotalFresh As Integer = Convert.ToInt32(dt.Compute("SUM(Fresh)", String.Empty))
            Dim TotalFrozen As Integer = Convert.ToInt32(dt.Compute("SUM(Frozen)", String.Empty))
            Dim TotalQty As Integer = Convert.ToInt32(dt.Compute("SUM(Qty)", String.Empty))

            lblTotalFresh.Text = "Total Fresh: " + TotalFresh.ToString()
            lblTotalFrozen.Text = "Total Frozen: " + TotalFrozen.ToString()
            lblTotal.Text = "Total Qty.: " + TotalQty.ToString()
            dgHistory.DataSource = dt
            dgHistory.Columns(cls_tblStock.FieldName.CreatedBy.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.ProductId.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.Remarks.ToString).Visible = False
            'dgHistory.Columns(cls_tblStock.FieldName.StockId.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.TransactionId.ToString).Visible = False

            dgHistory.Columns("Fresh").Visible = False
            dgHistory.Columns("Total Fresh").Visible = False
            dgHistory.Columns("Stocktype1").Visible = False
            dgHistory.Columns("TransactionDate").Visible = False

            dgHistory.Columns("Qty").Visible = False
            dgHistory.Columns("Total Qty").Visible = False
            'dgHistory.Columns("Frozen Qty Detail").Visible = False

            'dgHistory.Columns(cls_tblStock.FieldName.CreatedBy.ToString).Visible = False
            'dgHistory.Columns(cls_tblStock.FieldName.CreatedBy.ToString).Visible = False
            'dgHistory.Columns("UserId").Visible = False
            'dgHistory.Columns("ItemSl").Visible = False
            'dgHistory.Columns("CostPrice").HeaderText = "C.P."
            'dgHistory.Columns("SellPrice").HeaderText = "S.P."
            'dgHistory.Columns("UserName").HeaderText = "By"
            'dgHistory.Columns("CostPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgHistory.Columns("SellPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgHistory.Columns(" ").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            For Each dr As DataGridViewRow In dgHistory.Rows
                If dr.Cells("Stocktype").Value = "IN" Then
                    dr.DefaultCellStyle.BackColor = Color.WhiteSmoke
                End If
                If dr.Cells("Order Status").Value = "On Hold" Then
                    dr.DefaultCellStyle.BackColor = Color.Red
                End If
            Next
            Try
                dgHistory.Columns("Frozen Qty Detail").DisplayIndex = dgHistory.Columns("Total Qty").Index + 1
            Catch ex As Exception
            End Try
            Try
                dgHistory.Columns(0).DisplayIndex = dgHistory.ColumnCount - 1
            Catch ex As Exception
            End Try
        Catch ex As Exception
            dgHistory.DataSource = Nothing
        End Try
    End Sub


    Private Sub frmPriceHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmPriceHistory_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        Try
            dgHistory.Columns(0).DisplayIndex = dgHistory.ColumnCount - 1
        Catch ex As Exception
        End Try
        Try
            dgHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgHistory.Columns(" ").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
        End Try
        Try
            For Each dr As DataGridViewRow In dgHistory.Rows
                If dr.Cells("Stocktype").Value = "IN" Then
                    dr.DefaultCellStyle.BackColor = Color.WhiteSmoke
                End If
                If dr.Cells("Order Status").Value = "On Hold" Then
                    dr.DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        Catch ex As Exception
        End Try

        Dim d1 As Date = DateTimePicker1.Value
        Dim d2 As Date = DateTimePicker2.Value
        DateTimePicker1.Value = Now.AddDays(-1)
        DateTimePicker2.Value = Now.AddDays(-1)
        DateTimePicker1.Value = d1
        DateTimePicker2.Value = d2

    End Sub

    Private Sub dgHistory_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHistory.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        If dgHistory.Columns(e.ColumnIndex).HeaderText = "Order/Invoice No" Then
            Try
                Select Case dgHistory.Rows(e.RowIndex).Cells("TransactionType").Value
                    Case "ORDER"
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
                        frm.TopMost = False
                        frm.ShowInTaskbar = False
                        cnt.OpenOrder(dgHistory.Rows(e.RowIndex).Cells("TransactionId").Value)
                        frm.ShowDialog()
                    Case "PURCHASE"

                        Dim frm As New Form
                        frm.Size = New Size(500, 600)
                        frm.BackColor = Color.White
                        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        frm.StartPosition = FormStartPosition.CenterScreen
                        Dim cnt As New cntlPurchaseView
                        frm.Controls.Add(cnt)
                        cnt.Dock = DockStyle.Fill
                        frm.MinimizeBox = False
                        frm.MaximizeBox = False
                        frm.TopMost = False
                        frm.ShowInTaskbar = False
                        cnt.OpenOrder(dgHistory.Rows(e.RowIndex).Cells("TransactionId").Value)
                        frm.ShowDialog()
                End Select

            Catch ex As Exception
            End Try
        End If
        If e.ColumnIndex = 0 Then
            Dim frm As New frmAddSubStock
            frm.StockId = dgHistory.Rows(e.RowIndex).Cells("StockId").Value
            frm.ProductID = dgHistory.Rows(e.RowIndex).Cells("ProductID").Value
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LoadList()
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDateRange.CheckedChanged
        DateTimePicker1.Enabled = chkDateRange.Checked
        DateTimePicker2.Enabled = chkDateRange.Checked
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        LoadList()
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim objExport As New clsExportDatagridview

        Dim pi As cls_tblProducts.Fields = objProduct.Selection_One_Row(_ProductID)
        Dim Header1 As String = "Product History - " & pi.ProductName
        If chkFresh.Checked And chkFrozen.Checked Then

        ElseIf chkFresh.Checked Then
            Header1 += "(Fresh)"
        ElseIf chkFrozen.Checked Then
            Header1 += "(Frozen)"
        End If
        Dim Header2 As String = ""
        If chkDateRange.Checked Then
            Header2 = "From " & DateTimePicker1.Value & " To " & DateTimePicker2.Value
        End If
        objExport.StartExport(dgHistory, Header1, Header2)
    End Sub
End Class