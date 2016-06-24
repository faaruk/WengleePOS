Public Class frmCustomerAdd
    Dim objCustomer As New cls_tblCustomer
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
            objCustomer.Insert(txtName.Text, txtAddress.Text, txtRouteCity.Text, txtRoute.Text, txtCity.Text, txtState.Text, txtZip.Text, txtNotes.Text, "ACTIVE", Now, UserId, Now, UserId, txtClientSince.Value.Date, txtPhone.Text, txtEmail.Text, txtWebsite.Text, txtFax.Text, "YES", "", txtLong.Text, txtLati.Text, txtNCR.Text, IIf(txtCutOf.Value = "01/01/1900 00:00:00", "NOT SPECIFIED", txtCutOf.Text), IIf(chkCod.Checked, True, False))
            MsgBox("Saved successfully", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
 
    Private Sub lblGPS_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblGPS.LinkClicked
        Process.Start("http://www.gps-coordinates.net/")
        Process.Start("http://www.gpsvisualizer.com/geocode")
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

    Private Sub txtName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtZip.TextChanged, txtState.TextChanged, txtName.TextChanged, txtCity.TextChanged, txtAddress.TextChanged
        Label14.Text = txtName.Text.Trim & "," & txtAddress.Text.Trim & "," & txtCity.Text.Trim & "," & txtState.Text.Trim & "," & txtZip.Text
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

    Private Sub frmCustomerAdd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class