Public Class frmCarrier
    Dim objTruck As New cls_tblMasterItems

    Private Sub frmTruck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshListTruck()
    End Sub
    Sub RefreshListTruck()
        Try
            DataGridView1.DataSource = objTruck.SelectDistinct(cls_tblMasterItems.FieldName.ItemValue, "[ItemName]='CARRIER'") 'ItemValue
            DataGridView1.Columns(0).HeaderText = "CARRIER"
        Catch ex As Exception
            DataGridView1.DataSource = Nothing
        End Try

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then
            Try
                objTruck.Insert("CARRIER", "CARRIER", TextBox1.Text, "")
                TextBox1.Clear()
                RefreshListTruck()
                MsgBox("Saved", MsgBoxStyle.Information, "Info")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            End Try
        Else
            MsgBox("Enter Carrier Name", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            objTruck.Delete_By_SELECT("[ItemName]='CARRIER' and [ItemValue]='" & DataGridView1.SelectedRows(0).Cells(0).Value.ToString & "'")
            RefreshListTruck()
            MsgBox("Delete", MsgBoxStyle.Information, "Info")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
End Class