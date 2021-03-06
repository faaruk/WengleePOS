﻿Public Class frmStockFutureOrdersFz
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
    Sub UpdateColor()
        Try
            For Each dr As DataGridViewRow In dgHistory.Rows

                If dr.Cells("AnticipatedInventory").Value <= 0 Then
                    dr.Cells("AnticipatedInventory").Style.BackColor = Color.Red
                Else
                    dr.Cells("AnticipatedInventory").Style.BackColor = Color.White
                End If
                If dr.Cells("Status").Value = "On Hold" Then
                    dr.Cells("Status").Style.BackColor = Color.Yellow
                Else
                    dr.Cells("Status").Style.BackColor = Color.White
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub
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
            If chkStatus.Checked Then
                strNew += " and B.Status <> 'On Hold'"
            End If
            Dim dt As DataTable
            If chkStatus.Checked Then
                dt = objProductPrice.Selection(cls_tblStock.SelectionType.FutureOrdersWithOutOnHold, "a.[ProductId]=@ProductID and a.TransactionDate>@FromDate and a.TransactionType='ORDER' " & strNew & " Order By a.TransactionDate,f.stockid ", paramList)
            Else
                dt = objProductPrice.Selection(cls_tblStock.SelectionType.FutureOrders, "a.[ProductId]=@ProductID and a.TransactionDate>@FromDate and a.TransactionType='ORDER' " & strNew & " Order By a.TransactionDate,f.stockid ", paramList)
            End If

            Dim Str As Integer = 0
            For Each dr As DataRow In dt.Rows
                If dr("Unit").ToString.ToUpper.Contains("CASE") Then
                    Str += dr("Frozen").ToString
                End If
            Next
            lblTotalFrozen.Text = "Total Frozen: " + Str.ToString() + " Case(s)"


            dgHistory.DataSource = dt
            dgHistory.Columns(cls_tblStock.FieldName.ProductId.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.Remarks.ToString).Visible = False
            dgHistory.Columns(cls_tblStock.FieldName.TransactionId.ToString).Visible = False

            dgHistory.Columns("Fresh").Visible = False
            dgHistory.Columns("Total Fresh").Visible = False
            dgHistory.Columns("Qty").Visible = False
            dgHistory.Columns("Total Qty").Visible = False
            dgHistory.Columns("Stocktype1").Visible = False
            dgHistory.Columns("TransactionDate").Visible = False
            dgHistory.Columns("Frozen Qty Detail").Visible = False
            'dgHistory.Columns("Order/Invoice Date").Visible = False

            'dgHistory.Columns("Total Qty").Visible = False

        Catch ex As Exception
        End Try

    End Sub

    Private Sub frmPriceHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmPriceHistory_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Try
            UpdateColor()
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
        UpdateColor()
    End Sub

    Private Sub dgHistory_Sorted(sender As System.Object, e As System.EventArgs) Handles dgHistory.Sorted
        UpdateColor()
    End Sub
End Class