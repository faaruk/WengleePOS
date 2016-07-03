Public Class frmOrdersafterRoute
    Public RouteId As String
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dbWengLeeDataSet.tblBranch' table. You can move, or remove it, as needed.
        ReportViewer1.Width = Width - 30
        ReportViewer1.Height = Height - 40
        FillCombo(cmbRoute, "OtherInfos")
        FillCombo(cmbDriver, "Driver")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim dt As New DataTable
        Dim dtsummary As New DataTable
        Dim objOrder As New cls_tblOrder

        Dim strSQL As String
        Dim strDriver As String = cmbDriver.SelectedValue.ToString()
        Dim strRoute As String = ""

        strRoute = cmbRoute.SelectedValue.ToString()

        strSQL = "and (RouteDate>=convert(datetime, '" + DateTimePicker1.Value.Date.ToString() + "', 101) "
        strSQL += "and RouteDate<=convert(datetime, '" + DateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1) + "', 101)) "
        If (strDriver <> "<<All>>" And strDriver <> "" And strDriver <> "0") Then
            strSQL += "and Driver='" + strDriver + "' "
        End If
        If (strRoute <> "<<All>>" And strRoute <> "" And strRoute <> "0") Then
            strSQL += "and OtherInfos='" + strRoute + "' "
        End If

        dt = objOrder.SelectOrdersAfterRoute(RouteId, strSQL)
        ReportViewer1.Reset()

        ReportViewer1.LocalReport.ReportEmbeddedResource = "WengLee_Application.OrdersCreatedAfterRoute.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        ReportViewer1.RefreshReport()
    End Sub
    Private Sub FillCombo(ByVal cmb As ComboBox, ByVal _type As String, Optional ByVal _additionalCondition As String = "")
        Dim FirstItemText As String = "<<All>>"
        Dim objConn As New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim strSQL As String
        strSQL = "SELECT distinct " + _type + " as Display, " + _type + " as Value "
        strSQL += "FROM tblRoute "
        strSQL += "where RouteDate>=convert(datetime, '" + DateTimePicker1.Value.Date.ToString() + "', 101) "
        strSQL += "and RouteDate<=convert(datetime, '" + DateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1) + "', 101) "
        strSQL += _additionalCondition
        strSQL += "order by " + _type + " "
        Dim da As New SqlDataAdapter(strSQL, conn)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim dr As DataRow = dt.NewRow
        dr(0) = FirstItemText
        dr(1) = "0"
        dt.Rows.InsertAt(dr, 0)
        cmb.DisplayMember = "Display"
        cmb.ValueMember = "Value"
        cmb.DataSource = dt
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        FillCombo(cmbDriver, "Driver")
        Dim strSQL As String = ""
        Dim strDriver As String = cmbDriver.SelectedValue.ToString()
        If (strDriver <> "<<All>>" And strDriver <> "" And strDriver <> "0") Then
            strSQL = "and Driver='" + strDriver + "' "
            strSQL += "and (RouteDate>=convert(datetime, '" + DateTimePicker1.Value.Date.ToString() + "', 101) "
            strSQL += "and RouteDate<=convert(datetime, '" + DateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1) + "', 101)) "
        End If
        FillCombo(cmbRoute, "OtherInfos", strSQL)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        FillCombo(cmbDriver, "Driver")
        Dim strSQL As String = ""
        Dim strDriver As String = cmbDriver.SelectedValue.ToString()
        If (strDriver <> "<<All>>" And strDriver <> "" And strDriver <> "0") Then
            strSQL = "and Driver='" + strDriver + "' "
            strSQL += "and (RouteDate>=convert(datetime, '" + DateTimePicker1.Value.Date.ToString() + "', 101) "
            strSQL += "and RouteDate<=convert(datetime, '" + DateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1) + "', 101)) "
        End If
        FillCombo(cmbRoute, "OtherInfos", strSQL)
    End Sub

    Private Sub cmbDriver_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDriver.SelectedIndexChanged
        Dim strSQL As String = ""
        Dim strDriver As String = cmbDriver.SelectedValue.ToString()
        If (strDriver <> "<<All>>" And strDriver <> "" And strDriver <> "0") Then
            strSQL = "and Driver='" + strDriver + "' "
            strSQL += "and (RouteDate>=convert(datetime, '" + DateTimePicker1.Value.Date.ToString() + "', 101) "
            strSQL += "and RouteDate<=convert(datetime, '" + DateTimePicker2.Value.Date.AddDays(1).AddMilliseconds(-1) + "', 101)) "
        End If
        FillCombo(cmbRoute, "OtherInfos", strSQL)
        
    End Sub
End Class