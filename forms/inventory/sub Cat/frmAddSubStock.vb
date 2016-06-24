Public Class frmAddSubStock
    Public StockId As Integer = 100
    ' Public QTY As Integer = 100
    Public ProductID As Integer = 1

    Dim objtblsubstock As New cls_t_tblSubStock
    Dim objtblps As New cls_t_tblProductSub
    Dim dtDistinctSubStockType As DataTable

    Public RecieveType As String = "Receive"


    Sub LoadSubStockDT()
        dtDistinctSubStockType = objtblps.Selection(cls_t_tblProductSub.SelectionType.All, "ProductID=" & ProductID)
        Panel1.Controls.Clear()
        For Each dr As DataRow In dtDistinctSubStockType.Rows
            Dim cc As New cntlSubCat2
            'Try
            '    cc.ComboBox1.DataSource = dtDistinctSubStockType
            '    'cc.ComboBox1.DisplayMember = "Category"
            '    cc.ComboBox1.DisplayMember = "SubCatName"
            'Catch ex As Exception
            'End Try
            cc.ComboBox1.Text = dr("SubCatName")
            cc.CategoryID = dr("SubCatId")
            'cc.ComboBox1.Enabled = False
            cc.NumericUpDown1.Value = 0
            Panel1.Controls.Add(cc)
            cc.Dock = DockStyle.Top
            cc.BringToFront()
        Next
        GC.Collect()
    End Sub

    Sub LoadSubStock()
        If StockId <= 0 Then
            Exit Sub
        End If

        For Each dr As DataRow In objtblsubstock.Selection(cls_t_tblSubStock.SelectionType.All, "StockID=" & StockId.ToString).Rows
            'Dim cc As New cntlSubCat
            For Each cc As cntlSubCat2 In Panel1.Controls
                If cc.ComboBox1.Text = dr("Category") Then
                    'Try
                    '    cc.ComboBox1.DataSource = dtDistinctSubStockType
                    '    'cc.ComboBox1.DisplayMember = "Category"
                    '    cc.ComboBox1.DisplayMember = "SubCatName"
                    'Catch ex As Exception
                    'End Try

                    cc.NumericUpDown1.Value = dr("qty")
                    'Panel1.Controls.Add(cc)
                    'cc.Dock = DockStyle.Top
                    'cc.BringToFront()
                End If

            Next

        Next
    End Sub
    Private Sub frmAddSubStock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSubStockDT()
        LoadSubStock()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Dim cc As New cntlSubCat
        'Try
        '    cc.ComboBox1.DataSource = dtDistinctSubStockType'8257042121
        '    cc.ComboBox1.DisplayMember = "Category"
        'Catch ex As Exception
        'End Try

        'Panel1.Controls.Add(cc)
        'cc.Dock = DockStyle.Top
        'cc.BringToFront()

        Dim frm As New frmSubCategory
        frm.ProductId = ProductID
        frm.ShowDialog()
        LoadSubStockDT()
        LoadSubStock()

    End Sub

    Private Sub Panel1_ControlAdded(sender As System.Object, e As System.Windows.Forms.ControlEventArgs) Handles Panel1.ControlAdded

    End Sub

    Private Sub Panel1_ControlRemoved(sender As System.Object, e As System.Windows.Forms.ControlEventArgs) Handles Panel1.ControlRemoved

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try
            Try
                If StockId > 0 Then
                    objtblsubstock.Delete_By_SELECT("StockID=" & StockId.ToString)
                End If
            Catch ex As Exception
            End Try
            For Each c As cntlSubCat2 In Panel1.Controls
                If c.NumericUpDown1.Value > 0 Then
                    objtblsubstock.Insert(StockId, c.ComboBox1.Text, ProductID, c.NumericUpDown1.Value, UserId, Now, Now, UserId, "", "", c.CategoryID, RecieveType, dtpTran.Value.Date)
                End If
            Next
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Close()
    End Sub

End Class