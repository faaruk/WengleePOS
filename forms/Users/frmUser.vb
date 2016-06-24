Public Class frmUser
    Dim objUser As New cls_tblUserDetails
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmCreateUser
        frm.ShowDialog()
        LoadUsers()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim frm As New frmCreateUser
            frm.editid = DataGridView1.SelectedRows(0).Cells(0).Value
            frm.ShowDialog()
            LoadUsers()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Try
            objUser.Delete_By_UserId(DataGridView1.SelectedRows(0).Cells(0).Value)
            MsgBox("Deleted", MsgBoxStyle.Information, "Info")
            LoadUsers()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub frmViewRoute_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Sub LoadUsers()
        Try

            DataGridView1.DataSource = objUser.Selection()
            DataGridView1.Columns("UserId").Visible = False
            DataGridView1.Columns("BranchID").Visible = False
            DataGridView1.Columns("UserType").Visible = False
            DataGridView1.Columns("Status").Visible = False
            DataGridView1.Columns("Enable").Visible = False
            DataGridView1.Columns("LastLoginDate").Visible = False
            DataGridView1.Columns("EnabledDate").Visible = False
            DataGridView1.Columns("CreatedBy").Visible = False
            DataGridView1.Columns("UpdatedDate").Visible = False
            DataGridView1.Columns("UpdatedBy").Visible = False
            DataGridView1.Columns("Session").Visible = False
            DataGridView1.Columns("Password").Visible = False
            'DataGridView1.Columns("").Visible = False
            'DataGridView1.Columns("").Visible = False
            'DataGridView1.Columns("").Visible = False
            'DataGridView1.Columns("").Visible = False
            'DataGridView1.Columns("").Visible = False
            'DataGridView1.Columns("").Visible = False


            DataGridView1.Columns("FullName").HeaderText = "Full Name"
            DataGridView1.Columns("CreatedDate").HeaderText = "Created Date"
            'DataGridView1.Columns("").HeaderText = "Order Date"
            'DataGridView1.Columns("").DefaultCellStyle.Format = "MM/dd/yyyy"
            'DataGridView1.Columns("").DefaultCellStyle.Format = "MM/dd/yyyy"
            'DataGridView1.Columns("").HeaderText = "Route Date"
            'DataGridView1.Columns("").HeaderText = "Route Name"
            'DataGridView1.Columns("").DisplayIndex = 0
        Catch ex As Exception
        End Try
    End Sub
 
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            DataGridView1.Columns("Password").Visible = True
            For Each dr As DataGridViewRow In DataGridView1.Rows
                dr.Cells("Password").Value = Decrypt(dr.Cells("Password").Value)
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class