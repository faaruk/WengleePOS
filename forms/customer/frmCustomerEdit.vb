Public Class frmCustomerEdit
    Dim objCustomer As New cls_tblCustomer
    Public OpenCustomerId As Integer = 0

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub txtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSave.Click
        'Validate Items
        If txtName.Text.Trim = "" Then
            MsgBox("Enter Name ", MsgBoxStyle.Information, "Info")
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
        'If txtRoute.Text.Trim = "" Then
        '    MsgBox("Enter Route ", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        If txtRouteCity.Text.Trim = "" Then
            MsgBox("Enter Route City ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtName.Text.Trim = "" Then
            MsgBox("Enter Name ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Try
            'txtClientSince.Text = "01/01/2014"
            Dim fl As cls_tblCustomer.Fields = objCustomer.Selection_One_Row(OpenCustomerId)
            objCustomer.Update(OpenCustomerId, txtName.Text, txtAddress.Text, txtRouteCity.Text, txtRoute.Text, txtCity.Text, txtState.Text, txtZip.Text, txtNotes.Text, fl.Status, fl.CreatedDate, fl.CreatedBy, fl.UpdatedDate, fl.UpdatedBy, txtClientSince.Value.Date, txtPhone.Text, txtEmail.Text, txtWebsite.Text, txtFax.Text, "YES", fl.CustomerId_Link, txtLong.Text, txtLati.Text, txtNCR.Text, IIf(txtCutOf.Value = "01/01/1900 00:00:00", "NOT SPECIFIED", txtCutOf.Text), IIf(chkCod.Checked, True, False))
            MsgBox("Updated successfully", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub frmCustomerEdit_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            Dim fl As cls_tblCustomer.Fields = objCustomer.Selection_One_Row(OpenCustomerId)

            txtName.Text = fl.CustomerName
            txtAddress.Text = fl.Address
            txtRouteCity.Text = fl.RouteCity
            txtRoute.Text = fl.Route
            txtCity.Text = fl.City
            txtState.Text = fl.State
            txtZip.Text = fl.Zip
            txtNotes.Text = fl.Notes
            txtClientSince.Value = fl.ClientSince
            txtPhone.Text = fl.Phone
            txtEmail.Text = fl.Email
            txtWebsite.Text = fl.Website
            txtFax.Text = fl.Fax

            txtLong.Text = fl.Longt
            txtLati.Text = fl.Latt
            txtNCR.Text = fl.NCR_ID
            If fl.Receiving_CutOff = "NOT SPECIFIED" Or fl.Receiving_CutOff = "" Then
                chkNotSpecified.Checked = True
                txtCutOf.Text = "01/01/1900 00:00:00"
            Else
                txtCutOf.Text = fl.Receiving_CutOff
            End If
            chkCod.Checked = fl.Cod
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ShowRouteMap()
    End Sub
    Sub ShowRouteMap()
        Dim dtr As String = ""
        dtr += "&q=" & txtName.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtAddress.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtCity.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtState.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtZip.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
        frmViewMap.Show()
        frmViewMap.LoadMap(dtr, "Place")
    End Sub


    Private Sub lblGPS_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblGPS.LinkClicked
        Process.Start("http://www.gps-coordinates.net/")
        Process.Start("http://www.gpsvisualizer.com/geocode")
    End Sub
    Private Sub txtName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtZip.TextChanged, txtState.TextChanged, txtName.TextChanged, txtCity.TextChanged, txtAddress.TextChanged
        Label14.Text = txtName.Text.Trim & "," & txtAddress.Text.Trim & "," & txtCity.Text.Trim & "," & txtState.Text.Trim & "," & txtZip.Text
    End Sub

    Private Sub frmCustomerEdit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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