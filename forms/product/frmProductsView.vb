Public Class frmProductsView
    Dim objProduct As New cls_tblProducts
    Sub LoadItems()
        Try
            Dim selects As String = ""
            Dim ParameterList As New List(Of SqlParameter)
            If cmbProductCategory.SelectedIndex > 0 Then
                'selects = " Category= '" & cmbProductCategory.Text & "' "
                selects = " Category= @Category"
                ParameterList.Add(New SqlParameter("@Category", cmbProductCategory.Text))
            End If

            If ComboBox1.SelectedIndex = 1 Then
                selects += " and Enabled = 'true'"
            ElseIf ComboBox1.SelectedIndex = 2 Then
                selects += " and Enabled = 'false'"
            End If

            If ComboBox2.SelectedIndex = 1 Then
                selects += " and TrackInventory = 'true'"
            ElseIf ComboBox2.SelectedIndex = 2 Then
                selects += " and TrackInventory = 'false'"
            End If

            Dim dt As DataTable = objProduct.Selection(cls_tblProducts.SelectionType.All, selects, ParameterList)
            DataGridView1.DataSource = dt

            DataGridView1.Columns("ProductCode").HeaderText = "Code" ' = False
            'DataGridView1.Columns("ProductCode").Visible = False
            DataGridView1.Columns("Brand").Visible = False
            DataGridView1.Columns("Price").Visible = False
            DataGridView1.Columns("DateCreated").Visible = False
            DataGridView1.Columns("DateUpdated").Visible = False
            DataGridView1.Columns("CreatedBy").Visible = False
            DataGridView1.Columns("UpdatedBy").Visible = False
            DataGridView1.Columns("Enabled").Visible = False
            'DataGridView1.Columns("").Visible = False

            DataGridView1.Columns("ProductName").HeaderText = "Product Name"
            DataGridView1.Columns("FullName").HeaderText = "Full Name"
            DataGridView1.Columns("Category").HeaderText = "Category"
            DataGridView1.Columns("SubCategory").HeaderText = "Sub-Category"
            DataGridView1.Columns("ProductId").HeaderText = "Product Id"
            DataGridView1.Columns("UnitOfMeasure").HeaderText = "Unit Of Measure"
            DataGridView1.Columns("FZStatus").HeaderText = "FZ"

            'DataGridView1.Columns("").HeaderText = ""
            'DataGridView1.Columns("").HeaderText = ""
            'DataGridView1.Columns("").HeaderText = ""
            'DataGridView1.Columns("").HeaderText = ""
            LoadCategory()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Private Sub frmProductsView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1
        ComboBox2.SelectedIndex = 0
        LoadItems()
    End Sub

    Sub LoadCategory()
        Dim tmp As String = ""
        Try
            tmp = cmbProductCategory.Text
        Catch ex As Exception
        End Try
        cmbProductCategory.Items.Clear()
        cmbProductCategory.Items.Add("ALL CATEGORIES")
        For Each dr As DataRow In objProduct.SelectDistinct(cls_tblProducts.FieldName.Category).Rows
            Try
                If dr(0).ToString.Trim <> "" Then
                    cmbProductCategory.Items.Add(dr(0).ToString)
                End If
            Catch ex As Exception
            End Try
        Next

        Try
            If tmp.Trim = "" Then
                cmbProductCategory.Text = "ALL CATEGORIES"
            Else
                cmbProductCategory.Text = tmp
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Dim frm As New frmProductsAdd
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadItems()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                objProduct.Delete_By_ProductId(DataGridView1.SelectedRows(0).Cells("ProductId").Value)
                LoadCategory()
                LoadItems()

            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            If MsgBox("Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                Dim frm As New frmProductsEdit
                frm.ProductID = DataGridView1.SelectedRows(0).Cells("ProductId").Value
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    LoadCategory()
                    LoadItems()
                End If
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadItems()
    End Sub
 

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Dim frm As New frmSubCategory
            frm.ProductId = DataGridView1.SelectedRows(0).Cells("ProductId").Value
            frm.ShowDialog()
        Catch ex As Exception
        End Try

    End Sub

    
End Class