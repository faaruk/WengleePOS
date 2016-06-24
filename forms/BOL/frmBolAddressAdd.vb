Public Class frmBolAddressAdd
    Public CustomerID As Integer = 0
    Public OrderId As Integer = 0
    Public BOLAddressID As Integer = 0
    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Validate Items
        If txtDropOffPoint.Text.Trim = "" Then
            MsgBox("Enter Drop Off Point ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtAddress.Text.Trim = "" Then
            MsgBox("Enter Address ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtState.Text.Trim = "" Then
            MsgBox("Enter State ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtCity.Text.Trim = "" Then
            MsgBox("Enter City ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtZip.Text.Trim = "" Then
            MsgBox("Enter Zip ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtRouteCity.Text.Trim = "" Then
            MsgBox("Enter Route City ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Try
            BOLAddressID = objCustomerBOL.Insert(CustomerID, txtDropOffPoint.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtContact.Text, OrderId, txtRouteCity.Text, txtPhone.Text, txtFax.Text, txtLong.Text, txtLati.Text, IIf(txtCutOf.Value = "01/01/1900 00:00:00", "NOT SPECIFIED", txtCutOf.Text))
            'MsgBox("Saved successfully", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    'Private Sub frmCustomerEdit_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    'LoadBols()
    'Try
    '    Dim itemsl As Integer = objCustomerBOL.SelectScalar(cls_tblCustomer_BOL.FieldName.ItemSl, "ItemSl in (Select Max(ItemSL) from tblCustomer_Bol where CustomerId=" & CustomerID.ToString & " )")
    '    Dim fl As cls_tblCustomer_BOL.Fields = objCustomerBOL.Selection_One_Row(itemsl)
    '    txtDropOffPoint.Text = fl.DropOffPoint
    '    txtAddress.Text = fl.Address
    '    txtRouteCity.Text = fl.RouteCity
    '    txtCity.Text = fl.City
    '    txtState.Text = fl.State
    '    txtZip.Text = fl.Zip
    '    txtContact.Text = fl.Contact
    'Catch ex As Exception
    'End Try
    'End Sub

    'Sub LoadBols()
    '    Try
    '        Dim dt As DataTable = objCustomerBOL.Selection(cls_tblCustomer_BOL.SelectionType.All, "itemsl in (select max(itemsl) from tblCustomer_BOL group by dropoffpoint)")
    '        txtDropOffPoint.DataSource = dt
    '        txtDropOffPoint.DisplayMember = cls_tblCustomer_BOL.FieldName.DropOffPoint.ToString
    '        txtDropOffPoint.ValueMember = cls_tblCustomer_BOL.FieldName.ItemSl.ToString
    '    Catch ex As Exception
    '    End Try
    '    txtDropOffPoint.Text = ""
    'End Sub


    'Private Sub txtDropOffPoint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDropOffPoint.SelectedIndexChanged
    '    Try
    '        Dim itemsl As Integer = txtDropOffPoint.SelectedValue
    '        Dim fl As cls_tblCustomer_BOL.Fields = objCustomerBOL.Selection_One_Row(itemsl)
    '        txtAddress.Text = fl.Address
    '        txtRouteCity.Text = fl.RouteCity
    '        txtCity.Text = fl.City
    '        txtState.Text = fl.State
    '        txtZip.Text = fl.Zip
    '        txtContact.Text = fl.Contact
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Private Sub frmBolAddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub

    Private Sub frmBolAddressAdd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ShowRouteMap()
    End Sub
    Sub ShowRouteMap()
        Dim dtr As String = ""
        dtr += "&q=" & txtDropOffPoint.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtAddress.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtCity.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtState.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtZip.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
        frmViewMap.Show()
        frmViewMap.LoadMap(dtr, "Place")
    End Sub
    Private Sub chkNotSpecified_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNotSpecified.CheckedChanged
        txtCutOf.Enabled = Not chkNotSpecified.Checked
        If Not txtCutOf.Enabled Then
            txtCutOf.Value = "01/01/1900 00:00:00"
        Else
            txtCutOf.Value = txtCutOf.Value.AddDays(1)
        End If
    End Sub

    Private Sub txtCutOf_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtCutOf.ValueChanged
        If txtCutOf.Value = "01/01/1900 00:00:00" Then
            chkNotSpecified.Checked = True
        End If
    End Sub
End Class