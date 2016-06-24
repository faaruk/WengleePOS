Public Class frmEditTemplate

    Dim objOrder As New cls_tblTemplate
    Dim objOrderItems As New cls_tblTemplateItems
    Dim objProducts As New cls_tblProducts

    Public TemplateId As Integer = 0



    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        LoadCustomers()
        ClearAll()
    End Sub

    Sub LoadTemplate()
        Try

            Dim ff As cls_tblTemplate.Fields = objOrder.Selection_One_Row(TemplateId)
            txtTemplateName.Text = ff.TemplateName
            cmbCustomer.SelectedValue = ff.CutomerId
            CheckBox1.Checked = ff.CutomerId = 0
            Dim dt As DataTable = objOrderItems.Selection(cls_tblTemplateItems.SelectionType.Products_wise, " TemplateId=" & TemplateId.ToString & " order by a.[Sl]")
            For Each drProduct As DataRow In dt.Rows
                dgItemList.Rows.Add(drProduct(cls_tblProducts.FieldName.ProductId), _
                                    drProduct(cls_tblProducts.FieldName.ProductName), _
                                    0, "", "", "Delete", 0, 0)
            Next
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub


    Sub LoadCustomers()
        FillComBoBox(cmbCustomer, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString)
    End Sub

    Private Sub frmOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetDisplayIndex()
    End Sub

    Sub SetDisplayIndex()
        dgItemList.Columns(6).DisplayIndex = 2
        dgItemList.Columns(7).DisplayIndex = 3
    End Sub


    Private Sub dgItemList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItemList.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 5 Then
                dgItemList.Rows.Remove(dgItemList.Rows(e.RowIndex))
            End If
        End If
    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click
        Dim frm As New frmOrderItemAdd
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each dgrProduct As DataGridViewRow In frm.dgProduct.SelectedRows
                Dim pid As Integer = dgrProduct.Cells(0).Value
                Dim pname As String = dgrProduct.Cells(1).Value
                Dim isAlready As Integer = 0
                For Each dgrItem As DataGridViewRow In dgItemList.Rows
                    If dgrItem.Cells(0).Value = pid Then
                        isAlready += 1
                    End If
                Next
                isAlready = 0
                If isAlready = 0 Then
                    dgItemList.Rows.Add(pid, pname, 0)
                End If
            Next
            Try
                dgItemList.SelectedCells(0).Selected = False
            Catch ex As Exception
            End Try
        End If
    End Sub




    Private Sub btnPostOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostOrder.Click

        If cmbCustomer.SelectedIndex <= 0 And Not CheckBox1.Checked Then
            MsgBox("Select valid Customer of the Template", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtTemplateName.Text.Trim = "" Then
            MsgBox("Enter a valid Template name", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim transac As SqlTransaction = conn.BeginTransaction
        Try
            If dgItemList.Rows.Count = 0 Then
                MsgBox("Please add some product", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim ff As cls_tblTemplate.Fields = objOrder.Selection_One_Row(TemplateId)

            Dim OrderId As Integer = objOrder.Update(TemplateId:=TemplateId, TemplateName:=txtTemplateName.Text, CutomerId:=IIf(CheckBox1.Checked, 0, cmbCustomer.SelectedValue), _
                                                      TotalItems:=dgItemList.Rows.Count, CreatedDate:=ff.CreatedDate, CreatedBy:=ff.CreatedBy, UpdatedDate:=Now, UpdatedBy:=UserId, Remarks:=ff.Remarks, Comments:=ff.Comments, _conn:=conn, _transac:=transac)
            Dim CountSl As Integer = 1
            objOrderItems.Delete_By_SELECT("TemplateId =" & TemplateId.ToString)
            For Each drItem As DataGridViewRow In dgItemList.Rows
                objOrderItems.Insert(OrderId, CountSl, drItem.Cells(0).Value, "", Now, conn, transac)
                CountSl += 1
            Next

            transac.Commit()
            MsgBox("Saved", MsgBoxStyle.Information, "Info")
            ClearAll()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
            Try
                transac.Rollback()
            Catch ex2 As Exception
                MsgBox(ex2.Message, MsgBoxStyle.Information, "Info")
            End Try
        Finally
            conn.Close()
            objConn.Dispose()
            conn.Dispose()
            transac.Dispose()
        End Try

    End Sub

    Sub ClearAll()

        dgItemList.Rows.Clear()
        txtTemplateName.Text = ""
        cmbCustomer.SelectedIndex = 0
        txtTemplateName.Text = ""
    End Sub




    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub frmOrderAdd_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If dgItemList.RowCount > 1 And dgItemList.SelectedRows.Count > 0 Then
            If dgItemList.SelectedRows(0).Index <> 0 Then
                For Each dr As DataGridViewRow In dgItemList.SelectedRows
                    Dim drIndex As Integer = dr.Index
                    dgItemList.Rows.Remove(dr)
                    dgItemList.Rows.Insert(drIndex - 1, dr)
                    Try
                        dgItemList.SelectedRows(0).Selected = False
                    Catch ex As Exception
                    End Try
                    Try
                        dgItemList.Rows(drIndex - 1).Selected = True
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        If dgItemList.RowCount > 1 And dgItemList.SelectedRows.Count > 0 Then
            If dgItemList.SelectedRows(0).Index <> dgItemList.RowCount - 1 Then
                For Each dr As DataGridViewRow In dgItemList.SelectedRows
                    Dim drIndex As Integer = dr.Index
                    dgItemList.Rows.Remove(dr)
                    dgItemList.Rows.Insert(drIndex + 1, dr)
                    Try
                        dgItemList.SelectedRows(0).Selected = False
                    Catch ex As Exception
                    End Try
                    Try
                        dgItemList.Rows(drIndex + 1).Selected = True
                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        cmbCustomer.Enabled = Not CheckBox1.Checked
    End Sub

End Class