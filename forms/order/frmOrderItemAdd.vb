Public Class frmOrderItemAdd
    Dim objProduct As New cls_tblProducts

    Private Sub frmAddOrderItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgProduct.AutoGenerateColumns = False
        Dim dtCategory As DataTable = objProduct.SelectDistinct(cls_tblProducts.FieldName.Category)
        For Each dr As DataRow In dtCategory.Rows
            If dr(0).ToString.Trim = "" Then
                dr(0) = "<NO CATEGORY>"
            End If
        Next
        dgCategory.DataSource = dtCategory
    End Sub

    Private Sub dgCategory_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCategory.SelectionChanged
        Dim selectString As String = ""
        For Each drdg As DataGridViewRow In dgCategory.SelectedRows
            If selectString <> "" Then
                selectString += ","
            End If
            If drdg.Cells(0).Value = "<NO CATEGORY>" Then
                selectString += "''"
            Else
                selectString += "'" & drdg.Cells(0).Value & "'"
            End If
        Next
        If selectString <> "" Then
            Dim dtSubCategory As DataTable = objProduct.SelectDistinct(cls_tblProducts.FieldName.SubCategory, "[" & cls_tblProducts.FieldName.Category.ToString & "] in (" & selectString & ")")
            For Each dr As DataRow In dtSubCategory.Rows
                If dr(0).ToString.Trim = "" Then
                    dr(0) = "<NO SUB-CATEGORY>"
                End If
            Next
            dgSubCategory.DataSource = dtSubCategory
        End If

    End Sub

    Private Sub dgSubCategory_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSubCategory.SelectionChanged
        Dim selectString1 As String = ""
        For Each drdg As DataGridViewRow In dgCategory.SelectedRows
            If selectString1 <> "" Then
                selectString1 += ","
            End If
            If drdg.Cells(0).Value = "<NO CATEGORY>" Then
                selectString1 += "''"
            Else
                selectString1 += "'" & drdg.Cells(0).Value & "'"
            End If
        Next

        Dim selectString2 As String = ""
        For Each drdg As DataGridViewRow In dgSubCategory.SelectedRows
            If selectString2 <> "" Then
                selectString2 += ","
            End If
            If drdg.Cells(0).Value = "<NO SUB-CATEGORY>" Then
                selectString2 += "''"
            Else
                selectString2 += "'" & drdg.Cells(0).Value & "'"
            End If
        Next

        If selectString1 <> "" And selectString2 <> "" Then
            Dim dtProducts As DataTable = objProduct.Selection(cls_tblProducts.SelectionType.All, "[" & cls_tblProducts.FieldName.Category.ToString & "] in (" & selectString1 & ") AND [" & cls_tblProducts.FieldName.SubCategory.ToString & "] in (" & selectString2 & ")")
            dgProduct.DataSource = dtProducts
        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If dgProduct.SelectedRows.Count = 0 Then
            MsgBox("Select some products." & vbNewLine & "PS : Use Ctrl + Click to select multiple items", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub
End Class