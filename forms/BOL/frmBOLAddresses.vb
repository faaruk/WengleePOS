Public Class frmBOLAddresses

    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            For Each dr As DataGridViewRow In DataGridView1.Rows

                Dim ItemSl As Integer = 0
                Try
                    ItemSl = dr.Cells(cls_tblCustomer_BOL.FieldName.ItemSl.ToString).Value
                Catch ex As Exception
                End Try

                Dim CustomerId As Integer = 0
                Try
                    CustomerId = dr.Cells(cls_tblCustomer_BOL.FieldName.CustomerId.ToString).Value
                Catch ex As Exception
                End Try

                Dim DropOffPoint As String = ""
                Try
                    DropOffPoint = dr.Cells(cls_tblCustomer_BOL.FieldName.DropOffPoint.ToString).Value
                Catch ex As Exception
                End Try

                Dim Address As String = ""
                Try
                    Address = dr.Cells(cls_tblCustomer_BOL.FieldName.Address.ToString).Value
                Catch ex As Exception
                End Try

                Dim City As String = ""
                Try
                    City = dr.Cells(cls_tblCustomer_BOL.FieldName.City.ToString).Value
                Catch ex As Exception
                End Try

                Dim State As String = ""
                Try
                    State = dr.Cells(cls_tblCustomer_BOL.FieldName.State.ToString).Value
                Catch ex As Exception
                End Try

                Dim Zip As String = ""
                Try
                    Zip = dr.Cells(cls_tblCustomer_BOL.FieldName.Zip.ToString).Value
                Catch ex As Exception
                End Try

                Dim Contact As String = ""
                Try
                    Contact = dr.Cells(cls_tblCustomer_BOL.FieldName.Contact.ToString).Value
                Catch ex As Exception
                End Try

                Dim OrderID As Integer = 0
                Try
                    OrderID = dr.Cells(cls_tblCustomer_BOL.FieldName.OrderID.ToString).Value
                Catch ex As Exception
                End Try

                Dim RouteCity As String = ""
                Try
                    RouteCity = dr.Cells(cls_tblCustomer_BOL.FieldName.RouteCity.ToString).Value
                Catch ex As Exception
                End Try

                Dim Phone As String = ""
                Try
                    Phone = dr.Cells(cls_tblCustomer_BOL.FieldName.Phone.ToString).Value
                Catch ex As Exception
                End Try

                Dim Fax As String = ""
                Try
                    Fax = dr.Cells(cls_tblCustomer_BOL.FieldName.Fax.ToString).Value
                Catch ex As Exception
                End Try
                Dim Lat As String = ""
                Try
                    Lat = dr.Cells(cls_tblCustomer_BOL.FieldName.Latt.ToString).Value
                Catch ex As Exception
                End Try
                Dim Longt As String = ""
                Try
                    Longt = dr.Cells(cls_tblCustomer_BOL.FieldName.Longt.ToString).Value
                Catch ex As Exception
                End Try
                Dim Cut As String = "NOT SPECIFIED"
                Try
                    Cut = dr.Cells(cls_tblCustomer_BOL.FieldName.Receiving_CutOff.ToString).Value
                Catch ex As Exception
                End Try

                objCustomerBOL.Update(ItemSl:=ItemSl, _
                                 CustomerId:=CustomerId, _
                                 DropOffPoint:=DropOffPoint, _
                                 Address:=Address, _
                                 City:=City, _
                                 State:=State, _
                                 Zip:=Zip, _
                                 Contact:=Contact, _
                                 OrderID:=OrderID, _
                                 RouteCity:=RouteCity, _
                                 Phone:=Phone, _
                                 Fax:=Fax, Longt:=Longt, Latt:=Lat, Receiving_CutOff:=Cut)
            Next
            MsgBox("Updated", MsgBoxStyle.Information, "info")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try

    End Sub

    Sub LoadBols()
        Try
            Dim dt As DataTable = objCustomerBOL.Selection(cls_tblCustomer_BOL.SelectionType.All, "itemsl in (select max(itemsl) from tblCustomer_BOL group by dropoffpoint) Order by dropoffpoint")
            DataGridView1.DataSource = dt
            DataGridView1.Columns("ItemSl").Visible = False
            DataGridView1.Columns("CustomerId").Visible = False
            DataGridView1.Columns("OrderID").Visible = False
            DataGridView1.Columns(0).DisplayIndex = DataGridView1.Columns.Count - 1
            'DataGridView1.Columns("").Visible = False
            'DataGridView1.Columns("").Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmBOLAddresses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBols()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If MsgBox("Are you sure?" & "Please note that deleting a BOL Drop-Off will also unlink it from orders (if Any)", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                    Exit Sub
                End If
                objCustomerBOL.Delete_By_ItemSl(DataGridView1.Rows(e.RowIndex).Cells(cls_tblCustomer_BOL.FieldName.ItemSl.ToString).Value)
                MsgBox("Deleted", MsgBoxStyle.Information, "info")
                LoadBols()
            End If
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNew.Click
        If MsgBox("Are you sure?" & vbNewLine & vbNewLine & vbNewLine & "Please note that adding a new BOL Drop-Off will also will also discard the current changes made in the list (if Any). You can avoid it by saving the changes before adding a New Drop Off point.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Congfirm") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim frm As New frmBolAddressAdd
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadBols()
        End If
    End Sub
End Class