Imports System.IO

Public Class clsPrintCaseTotal_MSEXCEL
    Public oXL As Microsoft.Office.Interop.Excel.Application
    Dim oWB As Microsoft.Office.Interop.Excel.Workbook
    Dim oSheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Sub CreateRouteSheet(ByRef dg As DataGridView, d1 As Date, d2 As Date, category As String)



        oXL = CreateObject("Excel.Application")

        oXL.Visible = True
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

            RowStart += 1
            'Page Heading 
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + dg.Columns.Count - 2) & RowStart.ToString).Merge()
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Value = "CASE TOTALS FROM " & d1.ToShortDateString & " TO " & d2.ToShortDateString & "  (" & category & ")"
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Interior.ColorIndex = 4
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Bold = True
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Size = 16
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).BorderAround(8)
            oSheet1.Range(ChrW(ColStart) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            RowStart += 1


            'Page Heading 
            For i = 0 To dg.Columns.Count - 2
                oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).Value = dg.Columns(i).HeaderText.ToUpper
                oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).Font.Size = 12
                oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).Font.Bold = True
                oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).BorderAround(8)
                oSheet1.Range(ChrW(ColStart + i) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            Next

            For Each dr As DataGridViewRow In dg.Rows
                RowStart += 1
                For i = 0 To dg.Columns.Count - 2
                    oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).Value = dr.Cells(i).Value
                    oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).Font.Size = 12
                    oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).BorderAround(8)
                    oSheet1.Range(ChrW(ColStart + i) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            For i = 0 To dg.Columns.Count - 2
                oSheet1.Range(ChrW(ColStart + i) & RowStart.ToString).EntireColumn.AutoFit()
            Next

        Catch ex As Exception
        End Try
    End Sub
End Class
