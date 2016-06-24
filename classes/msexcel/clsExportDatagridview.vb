Imports System.IO
Imports System.ComponentModel
Imports Microsoft.Office.Interop.Excel
Public Class clsExportDatagridview
    WithEvents Bg1 As BackgroundWorker

    Dim frmProgress As Form
    Dim pb1 As ProgressBar
    Public oXL As Microsoft.Office.Interop.Excel.Application
    Dim oWB As Microsoft.Office.Interop.Excel.Workbook
    Dim oSheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Sub New()
        Bg1 = New BackgroundWorker
        Bg1.WorkerReportsProgress = True
        Bg1.WorkerSupportsCancellation = True
        frmProgress = New Form
        frmProgress.MinimizeBox = False
        frmProgress.MaximizeBox = False
        frmProgress.Size = New Size(600, 100)
        frmProgress.StartPosition = FormStartPosition.CenterScreen
        frmProgress.FormBorderStyle = FormBorderStyle.FixedDialog
        pb1 = New ProgressBar
        frmProgress.Controls.Add(pb1)
        pb1.Location = New Size(20, 40)
        pb1.Size = New Size(560, 20)
        AddHandler frmProgress.Shown, AddressOf frmP_shown
        AddHandler frmProgress.FormClosed, AddressOf frmP_Closed
    End Sub

    Dim dg As DataGridView
    Dim Header1 As String
    Dim Header2 As String

    Sub StartExport(ByRef dg_ As DataGridView, Optional Header1_ As String = "", Optional Header2_ As String = "")
        pb1.Maximum = dg_.Rows.Count + 2
        dg = dg_
        Header1 = Header1_
        Header2 = Header2_
        frmProgress.ShowDialog()
    End Sub

    Private Sub Bg1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bg1.DoWork

        oXL = CreateObject("Excel.Application")

        oWB = oXL.Workbooks.Add
        oSheet1 = oWB.Worksheets(1)
        oSheet1.Name = "Case Totals"

        Dim MaximumOrders As Integer = 20

        'First Sheet
        Try

            Dim i As Integer = 0
            Dim RowStart As Integer = 1
            Dim SlCounter As Integer = 0

            Dim ColStart As Integer = Asc("B")

            oSheet1.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperLetter
            Dim VisiBleCount As Integer = (From DC As DataGridViewColumn In dg.Columns Where DC.Visible = True Select DC).Count
            If Header1 <> "" Then

                RowStart += 1

                'Page Heading 
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + VisiBleCount - 1) & RowStart.ToString).Merge()
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Value = Header1
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Interior.ColorIndex = 4
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Bold = True
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Size = 16
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).BorderAround(8)
                oSheet1.Range(ChrW(ColStart) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            End If

            If Header2 <> "" Then
                RowStart += 1
                'Page Heading 
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + VisiBleCount - 1) & RowStart.ToString).Merge()
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Value = Header2
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Interior.ColorIndex = 4
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Bold = True
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Size = 14
                oSheet1.Range(ChrW(ColStart) & RowStart.ToString).BorderAround(8)
                oSheet1.Range(ChrW(ColStart) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            End If

            RowStart += 1


            'Column Heading 
            Dim cnt As Integer = 0
            For Each dc As DataGridViewColumn In (From dc_t As DataGridViewColumn In dg.Columns Order By dc_t.DisplayIndex Select dc_t)
                If dc.Visible Then
                    oSheet1.Range(ChrW(ColStart + cnt) & RowStart.ToString).Value = dc.HeaderText.ToUpper
                    oSheet1.Range(ChrW(ColStart + cnt) & RowStart.ToString).Font.Size = 12
                    oSheet1.Range(ChrW(ColStart + cnt) & RowStart.ToString).Font.Bold = True
                    oSheet1.Range(ChrW(ColStart + cnt) & RowStart.ToString).BorderAround(8)
                    oSheet1.Range(ChrW(ColStart + cnt) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    cnt += 1
                End If
            Next
            Bg1.ReportProgress(1)


            Dim StartRow As Integer = RowStart + 1
            For Each dr As DataGridViewRow In dg.Rows
                RowStart += 1
                cnt = 0
                 
                If Bg1.CancellationPending Then
                    Exit For
                End If
                For Each dc As DataGridViewColumn In (From dc_t As DataGridViewColumn In dg.Columns Order By dc_t.DisplayIndex Select dc_t)
                    If dc.Visible Then
                        oSheet1.Range(ChrW(ColStart + cnt) & RowStart.ToString).Value = dr.Cells(dc.Index).Value
                        If Not dr.Cells(dc.Index).Style.BackColor = Nothing Then
                            oSheet1.Range(ChrW(ColStart + cnt) & RowStart.ToString).Interior.Color = dr.Cells(dc.Index).Style.BackColor
                        End If
                        cnt += 1
                    End If
                Next
                Bg1.ReportProgress(1)
            Next

            oSheet1.Range(ChrW(ColStart) & StartRow.ToString & ":" & ChrW(ColStart + VisiBleCount - 1) & RowStart.ToString).Font.Size = 12
            oSheet1.Range(ChrW(ColStart) & StartRow.ToString & ":" & ChrW(ColStart + VisiBleCount - 1) & RowStart.ToString).BorderAround(8)

            With oSheet1.Range(ChrW(ColStart) & StartRow.ToString & ":" & ChrW(ColStart + VisiBleCount - 1) & RowStart.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            End With

            With oSheet1.Range(ChrW(ColStart) & StartRow.ToString & ":" & ChrW(ColStart + VisiBleCount - 1) & RowStart.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            End With


            oSheet1.Range(ChrW(ColStart) & StartRow.ToString & ":" & ChrW(ColStart + VisiBleCount - 1) & RowStart.ToString).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            For i = 0 To dg.Columns.Count - 1
                oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).EntireColumn.AutoFit()
            Next


        Catch ex As Exception
        End Try
        Try
            oXL.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmP_shown(sender As Object, e As EventArgs)
        Bg1.RunWorkerAsync()
    End Sub


    Private Sub Bg1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Bg1.ProgressChanged
        Try

            pb1.Value = pb1.Value + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bg1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bg1.RunWorkerCompleted
        frmProgress.Close()
    End Sub

    Private Sub frmP_Closed(sender As Object, e As FormClosedEventArgs)
        If Bg1.IsBusy Then
            Bg1.CancelAsync()
        End If
    End Sub

End Class
