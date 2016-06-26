Public Class frmTaskList
    Dim objTasks As New cls_t_tblTask
    Dim Updatefl As cls_t_tblTask.Fields
    Private Sub frmTaskList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFilter.SelectedIndex = 0



    End Sub

    Private Sub frmTaskList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Width = 410
        Top = 100
        With Screen.FromPoint(MousePosition).WorkingArea
            Left = .Left + .Width - Width
            Height = .Height + .Top - Top
        End With

        'dgItems.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, dgItems.DefaultCellStyle.SelectionBackColor)
        Dim objUser As New cls_tblUserDetails
        Dim dt As DataTable
        dt = objUser.SelectAcitveUsers
        cmbAssignTo.DisplayMember = "FullName"
        cmbAssignTo.ValueMember = "UserId"
        cmbAssignTo.DataSource = dt
        LoadTask()
    End Sub
    Sub LoadTask()
        Dim str As String = ""
        If cmbFilter.SelectedIndex <> 2 Then
            str = "TaskStatus = '" & cmbFilter.Text & "'"
        End If


        Dim dt As DataTable = objTasks.Selection(cls_t_tblTask.SelectionType.All, str)

        For i = dgItems.Controls.Count - 1 To 0 Step -1
            Dim c As Control = dgItems.Controls(i)
            dgItems.Controls.Remove(c)
            c.Visible = False
            c.Dispose()
        Next

        dgItems.Rows.Clear()

        For i = 0 To dt.Rows.Count - 1

            Dim dr As DataRow = dt.Rows(i)
            dgItems.Rows.Add(0, "", dr("TaskId"))
            Dim d As Rectangle = dgItems.GetCellDisplayRectangle(1, i, False)

            Dim lbl As New usrTaskView With {.BackColor = Color.Transparent, .Width = d.Size.Width, .Location = d.Location, .Tag = i}
            lbl.lblHeader.Text = CDate(dr("TaskDate")).ToShortDateString & "-" & dr("TaskSubject")
            lbl.lblTask.Visible = dr("Task").ToString.Trim <> ""
            If lbl.lblTask.Visible Then
                lbl.lblTask.Text = dr("Task")
            End If


            lbl.lblDetails.Visible = dr("Details").ToString.Trim <> ""
            If lbl.lblDetails.Visible Then
                lbl.lblDetails.Text = dr("Details")
            End If
            lbl.lblAssignTo.Visible = dr("AssignToDesc").ToString.Trim <> ""
            If lbl.lblAssignTo.Visible Then
                lbl.lblAssignTo.Text = "Assigned to " + dr("AssignToDesc")
            End If

            If dr("TaskStatus") = "Pending" Then
                dgItems.Rows(i).DefaultCellStyle.BackColor = Color.Orange
            ElseIf dr("TaskStatus") = "Completed" Then
                dgItems.Rows(i).DefaultCellStyle.BackColor = Color.LimeGreen
            End If
            dgItems.Controls.Add(lbl)
            lbl.AutoSize = True
            dgItems.Rows(i).Height = lbl.Height
            AddHandler lbl.Click, AddressOf lbl_click

        Next
    End Sub

    Private Sub lbl_click(sender As Object, e As EventArgs)
        Try
            For Each dr As DataGridViewRow In dgItems.SelectedRows
                dr.Selected = False
            Next
            dgItems.Rows(sender.tag).Selected = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddnew.Click
        ShowNewDialog()
        CLear()
    End Sub
    Sub CLear()
        txtSubject.Clear()
        txtTask.Clear()
        txtDetails.Clear()
        dtpTaskDate.Value = Now
        cmbStatus.SelectedIndex = 0
    End Sub

    Sub ShowNewDialog()
        If Panel2.BackgroundImage IsNot Nothing Then
            Panel2.BackgroundImage.Dispose()
            Panel2.BackgroundImage = Nothing
        End If
        Dim bmp As Bitmap = New Bitmap(Width, Height)
        Panel1.DrawToBitmap(bmp, New Rectangle(New Point(0, 0), New Size(Width, Height)))
        Dim gr As Graphics = Graphics.FromImage(bmp)
        gr.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.Black)), New Rectangle(New Point(0, 0), New Size(Width, Height)))
        gr.Dispose()
        Panel2.BackgroundImage = bmp
        Panel2.BringToFront()
        Panel2.Show()
        btnOk.Text = "Ok"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim updateid As Integer = 0
        For Each dr As DataGridViewRow In dgItems.Rows
            If dr.Cells(0).Value = 1 Then
                Try
                    updateid = dr.Cells(2).Value

                Catch ex As Exception
                End Try
            End If
        Next


        If updateid <> 0 Then
            ShowNewDialog()
            Updatefl = objTasks.Selection_One_Row(updateid)
            txtSubject.Text = Updatefl.TaskSubject_
            txtTask.Text = Updatefl.Task_
            txtDetails.Text = Updatefl.Details_
            dtpTaskDate.Value = Updatefl.TaskDate_
            cmbStatus.Text = Updatefl.TaskStatus_
            Dim strDropDown As String
            strDropDown = Updatefl.AssignTo_
            'cmbAssignTo.SelectedIndex = cmbAssignTo.FindString(strDropDown)
            cmbAssignTo.SelectedValue = strDropDown
            btnOk.Text = "Update"
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim c As Integer = 0
        For Each dr As DataGridViewRow In dgItems.Rows
            If dr.Cells(0).Value = 1 Then
                Try
                    objTasks.Delete_By_RowID(dr.Cells(2).Value)
                    c += 1
                Catch ex As Exception
                End Try
            End If
        Next
        MsgBox("Done" & vbNewLine & c.ToString & " Deleted", MsgBoxStyle.Information, "Deleted")
        LoadTask()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        LoadTask()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Panel2.Hide()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If txtSubject.Text.Trim = "" Then
            MsgBox("Enter a valid subject")
            Exit Sub
        End If
        Dim strAssignTo As String
        If (cmbAssignTo.SelectedValue <> Nothing) Then
            strAssignTo = cmbAssignTo.SelectedValue.ToString()
        End If

        If btnOk.Text = "Update" Then
            objTasks.Update(Updatefl.CreatedDate_, dtpTaskDate.Value, txtTask.Text, txtSubject.Text, txtDetails.Text, Updatefl.Createdby_, UserId, Now, cmbStatus.Text, Updatefl.TaskId_, strAssignTo)
        Else
            objTasks.Insert(Now, dtpTaskDate.Value, txtTask.Text, txtSubject.Text, txtDetails.Text, UserId, UserId, Now, cmbStatus.Text, strAssignTo)
        End If
        LoadTask()
        Panel2.Hide()
    End Sub



    Private Sub AlwaysOnTopToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.CheckedChanged
        TopMost = AlwaysOnTopToolStripMenuItem.Checked
    End Sub
End Class