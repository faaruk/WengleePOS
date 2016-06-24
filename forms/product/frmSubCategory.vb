Public Class frmSubCategory

    Dim objSubCats As New cls_t_tblProductSub
    Public ProductId As Integer = 0
    Dim editID As Integer = 0

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text.Trim = "" Then
            MsgBox("Please enter sub category", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If Button2.Text = "Save" Then
            objSubCats.Insert(ProductId, TextBox1.Text, UserId, Now)
        Else
            objSubCats.Update(ProductId, TextBox1.Text, UserId, Now, editID)
        End If
        TextBox1.Clear()
        Button2.Text = "Save"
        LoadDG()
        'MsgBox("Saved", MsgBoxStyle.Information, "Info")
    End Sub
    Sub LoadDG()
        DataGridView1.DataSource = objSubCats.Selection(cls_t_tblProductSub.SelectionType.All, "ProductID=" & ProductId)
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
    End Sub

    Private Sub frmSubCategory_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        LoadDG()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If MsgBox("Are you sure ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    objSubCats.Delete_By_RowID(DataGridView1.Rows(e.RowIndex).Cells(2).Value)
                    LoadDG()
                End If
            End If
            If e.ColumnIndex = 1 Then
                editID = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
                Button2.Text = "Update"
            End If
        End If
    End Sub

End Class