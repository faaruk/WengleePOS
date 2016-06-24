Public Class frmBolAddressEdit
    Public CustomerID As Integer = 0
    Public OrderId As Integer = 0
    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Public BOLAddressID As Integer = 0
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
            BOLAddressID = objCustomerBOL.Update(BOLAddressID, CustomerID, txtDropOffPoint.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtContact.Text, OrderId, txtRouteCity.Text, txtPhone.Text, txtFax.Text, txtLong.Text, txtLati.Text, IIf(txtCutOf.Value = "01/01/1900 00:00:00", "NOT SPECIFIED", txtCutOf.Text))
            MsgBox("Saved successfully", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub frmCustomerEdit_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Try

            Dim fl As cls_tblCustomer_BOL.Fields = objCustomerBOL.Selection_One_Row(BOLAddressID)

            txtDropOffPoint.Text = fl.DropOffPoint
            txtAddress.Text = fl.Address
            txtRouteCity.Text = fl.RouteCity
            txtCity.Text = fl.City
            txtState.Text = fl.State
            txtZip.Text = fl.Zip
            txtContact.Text = fl.Contact
            txtPhone.Text = fl.Phone
            txtFax.Text = fl.Fax
            txtLong.Text = fl.Longt
            txtLati.Text = fl.Latt

            If fl.Receiving_CutOff = "NOT SPECIFIED" Or fl.Receiving_CutOff = "" Then
                chkNotSpecified.Checked = True
                txtCutOf.Text = "01/01/1900 00:00:00"
            Else
                txtCutOf.Text = fl.Receiving_CutOff
            End If

        Catch ex As Exception
        End Try

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