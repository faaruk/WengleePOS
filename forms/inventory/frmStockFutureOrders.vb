Public Class frmStockFutureOrders
    Dim objProductPrice As New cls_tblStock
    Dim objProduct As New cls_tblProducts

    Private _ProductID As Integer = 0
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
            paramList.Add(New SqlParameter("@FromDate", Now))
            paramList.Add(New SqlParameter("@ProductID", _ProductID))
            Dim strNew As String = ""
            If chkFresh.Checked And chkFrozen.Checked Then

            ElseIf chkFresh.Checked Then
                strNew += " and a.Fresh >0"
            ElseIf chkFrozen.Checked Then
                strNew += " and a.Frozen >0"
            End If

            Dim dt As DataTable = objProductPrice.Selection(cls_tblStock.SelectionType.FutureOrders, "a.[ProductId]=@ProductID and a.TransactionDate>@FromDate and a.TransactionType='ORDER' " & strNew & " Order By a.TransactionDate,f.stockid ", paramList)
            dgHistory.DataSource = dt
            dgHistory.Columns(cls_tblStock.FieldName.CreatedBy.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.ProductId.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.Remarks.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.TransactionId.ToString).Visible = False
            dgHistory.Columns("Status").Visible = False

            dgHistory.Columns("AnticipatedInventory").Visible = False

            'dgHistory.Columns("Total Qty").Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub frmPriceHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmPriceHistory_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Try
            dgHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgHistory.Columns(" ").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
        End Try
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

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click

        Dim objExport As New clsExportDatagridview
        Dim pi As cls_tblProducts.Fields = objProduct.Selection_One_Row(_ProductID)
        Dim Header1 As String = "Product Future Orders - " & pi.ProductName
        objExport.StartExport(dgHistory, Header1, "From " & Now.Date.ToShortDateString)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        LoadList()
    End Sub

End Class