Public Class frmFZWeights
    Public ProductId As Integer = 0

    Dim objSubStock As New cls_t_tblSubStock
    Dim objProduct As New cls_t_tblProducts
    Dim objProductSub As New cls_t_tblProductSub

    Private Sub frmFZWeights_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSubCats()
        LoadList()
    End Sub

    Sub LoadSubCats()
        Dim dt As DataTable = objProductSub.Selection(cls_t_tblProductSub.SelectionType.All, "ProductID=" & ProductId.ToString)
        Try
            Dim dr As DataRow = dt.NewRow
            dr(0) = 0
            dr(2) = "Select Sub-Category"
            dt.Rows.InsertAt(dr, 0)
        Catch ex As Exception
        End Try
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "SubCatName"
        ComboBox1.ValueMember = "SubCatId"
    End Sub

    Sub LoadList()
        If ComboBox1.SelectedIndex > 0 Then
            DataGridView1.DataSource = objSubStock.Selection(cls_t_tblSubStock.SelectionType.StockReport, "a.ProductID=" & ProductId.ToString & " and a.SubCategoryID=" & ComboBox1.SelectedValue.ToString & " order by [SubStockID] desc")
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim frm As New frmAddSubStock
        frm.StockId = 0
        frm.RecieveType = "Receive"
        frm.ProductID = ProductId
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadList()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmAddSubStock
        frm.RecieveType = "Adjust"
        frm.StockId = 0
        frm.ProductID = ProductId
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadList()
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmAddSubStock
        frm.RecieveType = "Post Order"
        frm.StockId = 0
        frm.ProductID = ProductId
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadList()
        End If
    End Sub

    Private Sub chkDateRange_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDateRange.CheckedChanged
        DateTimePicker1.Enabled = chkDateRange.Checked
        DateTimePicker2.Enabled = chkDateRange.Checked

    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        LoadList()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class