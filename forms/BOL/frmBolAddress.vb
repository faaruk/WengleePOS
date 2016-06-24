Public Class frmBolAddress
    Public CustomerID As Integer = 0
    Public OrderId As Integer = 0
    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        LoadBols()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Validate Items
        If txtDropOffPoint.Text.Trim = "-Select-" Then
            MsgBox("Select Drop Off Point ", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        'If txtAddress.Text.Trim = "" Then
        '    MsgBox("Enter Address ", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        'If txtState.Text.Trim = "" Then
        '    MsgBox("Enter State ", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        'If txtCity.Text.Trim = "" Then
        '    MsgBox("Enter City ", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If
        'If txtZip.Text.Trim = "" Then
        '    MsgBox("Enter Zip ", MsgBoxStyle.Information, "Info")
        '    Exit Sub
        'End If

        If txtRouteCity.Text.Trim = "" Then
            MsgBox("No Route City found. Please edit and update the Route city of the BOL Drop-Off", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Try

            If OrderId > 0 Or CustomerID > 0 Then
                Dim BOLAddressID As Integer = txtDropOffPoint.SelectedValue
                Dim con As SqlConnection = (New clsConnection).connect
                Try
                    Dim com1 As New SqlCommand("Update tblOrder set BOLAddressID=" & BOLAddressID.ToString & " where OrderId=" & OrderId.ToString, con)
                    com1.ExecuteNonQuery()
                Catch ex As Exception
                End Try
                Dim com As New SqlCommand("Update tblCustomer set BOL='YES' where customerid=" & CustomerID.ToString, con)
                com.ExecuteNonQuery()
                MsgBox("Saved successfully", MsgBoxStyle.Information, "Info")
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub
    Private Sub frmCustomerEdit_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If CustomerID > 0 Then
                Dim itemsl As Integer = objCustomerBOL.SelectScalar(cls_tblCustomer_BOL.FieldName.ItemSl, "ItemSl in (Select Max(ItemSL) from tblCustomer_Bol where CustomerId=" & CustomerID.ToString & " )")
                Dim fl As cls_tblCustomer_BOL.Fields = objCustomerBOL.Selection_One_Row(itemsl)
                txtDropOffPoint.Text = fl.DropOffPoint
                txtAddress.Text = fl.Address
                txtRouteCity.Text = fl.RouteCity
                txtCity.Text = fl.City
                txtState.Text = fl.State
                txtZip.Text = fl.Zip
                txtContact.Text = fl.Contact
                txtPhone.Text = fl.Phone
                txtFax.Text = fl.Fax
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadBols()
        Try
            Dim dt As DataTable = objCustomerBOL.Selection(cls_tblCustomer_BOL.SelectionType.DDL, "itemsl in (select max(itemsl) from tblCustomer_BOL group by dropoffpoint) Order by dropoffpoint")
            txtDropOffPoint.DataSource = dt
            Dim dr As DataRow = dt.NewRow
            dr(0) = -1
            dr(1) = "-Select-"
            dt.Rows.InsertAt(dr, 0)
            txtDropOffPoint.DisplayMember = cls_tblCustomer_BOL.FieldName.DropOffPoint.ToString
            txtDropOffPoint.ValueMember = cls_tblCustomer_BOL.FieldName.ItemSl.ToString
            txtDropOffPoint.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub


    Private Sub txtDropOffPoint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDropOffPoint.SelectedIndexChanged
        LoadTheAddress()
    End Sub

    Sub LoadTheAddress()
        Try
            Dim itemsl As Integer = txtDropOffPoint.SelectedValue
            Dim fl As cls_tblCustomer_BOL.Fields = objCustomerBOL.Selection_One_Row(itemsl)
            txtAddress.Text = fl.Address
            txtRouteCity.Text = fl.RouteCity
            txtCity.Text = fl.City
            txtState.Text = fl.State
            txtZip.Text = fl.Zip
            txtContact.Text = fl.Contact
            txtPhone.Text = fl.Phone
            txtFax.Text = fl.Fax
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmBolAddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmBolAddressAdd
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            LoadBols()
            txtDropOffPoint.SelectedValue = frm.BOLAddressID
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm As New frmBolAddressEdit
        frm.BOLAddressID = txtDropOffPoint.SelectedValue
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtDropOffPoint.SelectedValue = frm.BOLAddressID
            LoadTheAddress()
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnMap.Click
        ShowRouteMap()
    End Sub
    Sub ShowRouteMap()
        Dim dtr As String = ""
        dtr += "&q=" & txtDropOffPoint.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtAddress.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtCity.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtState.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+") & "," & txtZip.Text.Trim.Replace("&", "+and+").Replace("#", "").Replace(" ", "+")
        frmViewMap.Show()
        frmViewMap.LoadMap(dtr, "Place")
    End Sub
End Class