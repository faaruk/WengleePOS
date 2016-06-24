Public Class frmRouteReport
    Public RouteId As String
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dbWengLeeDataSet.tblBranch' table. You can move, or remove it, as needed.


        Dim dt As New DataTable
        Dim dtsummary As New DataTable
        Dim objOrder As New cls_tblOrder
        dt = objOrder.SelectRouteDetails(RouteId)
        dtsummary = objOrder.SelectRouteSummary(RouteId)

        ReportViewer1.Reset()

        ReportViewer1.LocalReport.ReportEmbeddedResource = "WengLee_Application.RouteReport.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("OrderDetails", dt))
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsSummary", dtsummary))
        ReportViewer1.ZoomPercent = 100
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
        ReportViewer1.Width = Width - 30
        ReportViewer1.Height = Height - 40
        ReportViewer1.RefreshReport()
    End Sub
End Class