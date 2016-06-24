Public Class frmPrintLabel

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        Dim pp As New clsPrintLabel
        'pp.LabelText = ComboBox1.Text
        pp.NoOfLabel = NumericUpDown1.Value
        Dim ps As New PrintDialog
        ps.PrintToFile = False
        ps.AllowSelection = False
        ps.AllowSomePages = False
        ps.ShowNetwork = False
        ps.UseEXDialog = True

        If ps.ShowDialog = Windows.Forms.DialogResult.OK Then
            pp.PrinterSettings = ps.PrinterSettings
            'Dim pg As New PageSetupDialog
            'pg.PageSettings = pp.DefaultPageSettings
            'If pg.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    pp.DefaultPageSettings = pg.PageSettings
            '    pp.Print()
            'End If
            pp.Print()
        End If


    End Sub
    Sub LoadCustomers()
        FillComBoBox(ComboBox1, cls_tblCustomer.tablename, cls_tblCustomer.FieldName.CustomerName.ToString, cls_tblCustomer.FieldName.CustomerID.ToString)
    End Sub
    Private Sub frmPrintLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadCustomers()
        Catch ex As Exception
        End Try
    End Sub
End Class