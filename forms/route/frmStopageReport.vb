Imports Microsoft.Reporting.WinForms

Public Class frmStopageReport
    Public RouteId As String
    Private Sub frmStopageReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dbWengLeeDataSet.tblBranch' table. You can move, or remove it, as needed.


        Dim dt As New DataTable

        Dim objOrder As New cls_tblOrder
        dt = objOrder.SelectRouteStopage(RouteId)

        ReportViewer1.Reset()

        ReportViewer1.LocalReport.ReportEmbeddedResource = "WengLee_Application.StopageReport.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("OrderDetails", dt))

        Dim parReportParam1 As New ReportParameter("rcunt", dt.Rows.Count)
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter() {parReportParam1})

        ReportViewer1.ZoomPercent = 100
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        ReportViewer1.Width = Width - 30
        ReportViewer1.Height = Height - 40
        ReportViewer1.RefreshReport()
    End Sub
End Class