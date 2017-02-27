Public Class frmCalender2

    Dim objOrders As New cls_tblOrder
    Dim objSchOrders As New cls_tblOrderSchedule
    Dim objNotes As New cls_tblNotes

    Private Sub frmCalender2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cmbBOL.SelectedIndex = 0
        GetValues()
    End Sub

    Sub GetValues()
        DataGridView1.Rows.Clear()
        DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.Programmatic
        DataGridView1.Rows.Add("Total", "", "", "", "", "", "", "")
        DataGridView1.Rows(0).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        DataGridView1.Rows(0).DefaultCellStyle.BackColor = SystemColors.ButtonFace
        DataGridView1.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(0).Frozen = True
        DataGridView1.Rows(0).Height = 28
        DataGridView1.Rows.Add("NOTES", "NA", "NA", "NA", "NA", "NA", "NA", "NA")
        DataGridView1.Rows(1).Height = 28
        DataGridView1.Rows(1).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Underline)
        DataGridView1.Rows(1).DefaultCellStyle.BackColor = SystemColors.Control
        DataGridView1.Rows(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim FstRow As Integer = 2
        Dim dtNotes As DataTable = Nothing
        Try
            Dim pp As New List(Of SqlParameter)
            pp.Add(New SqlParameter("@d1", txtDate.Value.Date))
            pp.Add(New SqlParameter("@d2", txtDate.Value.Date.AddDays(6)))
            dtNotes = objNotes.Selection(cls_tblNotes.SelectionType.All, "NoteDate between @d1 and @d2", pp)
         
        Catch ex As Exception
        End Try

        'DataGridView1.Columns.Clear()
        'DataGridView1.Columns.RemoveAt(0)
        'DataGridView1.Columns.RemoveAt(1)
        'DataGridView1.Columns.RemoveAt(2)
        'DataGridView1.Columns.RemoveAt(3)
        'DataGridView1.Columns.RemoveAt(4)
        'DataGridView1.Columns.RemoveAt(5)
        'DataGridView1.Columns.RemoveAt(6)
        For i = 0 To 6
            'If (i > 6) Then
            'DataGridView1.Columns.Add("newColumnName", "Column Name in Text")
            'End If
            Dim dte As Date = txtDate.Value.Date.AddDays(i)
            Dim dte2 As Date = dte.AddDays(1).AddSeconds(-1)

            Dim SelectString As String = ""
            Dim SelectString1 As String = ""
            Dim SelectString2 As String = ""
            Dim SelectString3 As String = ""
            Select Case cmbBOL.SelectedIndex
                Case 0 'ALL : Do Nothing
                Case 1 'YES
                    SelectString = " AND f.ItemSl IS NOT NULL"
                Case 2 'NO
                    SelectString = " AND f.ItemSl IS NULL"
            End Select
            If chkZeroQty.Checked = False Then
                If chkFrozen.Checked Then
                    SelectString1 = " AND a.Frozen > 0"
                    SelectString2 = " AND a.OrderId in (select orderid from (SELECT  sum (Frozen) as  'Frozen' , orderid  FROM [tblOrderItems] group by orderid) a where  a.Frozen>0)"
                    SelectString3 = " AND a.OrderId in (select orderid from (SELECT  sum (Frozen) as  'Frozen' , orderid  FROM [tblOrderScheduleItems] group by orderid) a where  a.Frozen>0)"
                End If
            Else
                If chkFrozen.Checked Then
                    'SelectString1 = " AND a.Frozen > 0"
                    'SelectString2 = " AND a.OrderId in (select orderid from (SELECT  sum (Frozen) as  'Frozen' , orderid  FROM [tblOrderItems] group by orderid) a where  a.Frozen>0)"
                    'SelectString3 = " AND a.OrderId in (select orderid from (SELECT  sum (Frozen) as  'Frozen' , orderid  FROM [tblOrderScheduleItems] group by orderid) a where  a.Frozen>0)"
                End If
            End If
            Dim SelectStringLargeOrders = ""
            Dim SelectStringLargeOrders2 = ""
            Dim SelectStringLargeOrders3 = ""
            If chkLargeOrders.Checked = True Then
                'SelectStringLargeOrders = " having sum (a.Fresh) + sum (a.Frozen)>=20 "
                'SelectStringLargeOrders2 = " AND a.OrderId in (select orderid from (SELECT  sum (Frozen)+sum(Fresh) as  'Frozen' , orderid  FROM [tblOrderItems] group by orderid) B where  B.Frozen>=20) "
                SelectStringLargeOrders2 = " and ISNULL( h.Cs,0 )>=20 "
                'SelectStringLargeOrders3 = " and a.OrderId in (select orderid from (SELECT  sum (Frozen)+sum(Fresh) as  'Frozen' , orderid  FROM [tblOrderScheduleItems] group by orderid) B where  B.Frozen>=20) "
                SelectStringLargeOrders3 = " and ISNULL( h.Cs,0 )>=20 "

            End If

            Try
                Dim pp2 As New List(Of SqlParameter)
                pp2.Add(New SqlParameter("@d1", dte))
                pp2.Add(New SqlParameter("@d2", dte2))
                Dim dt2 As DataTable = ExecuteAdapter(cls_tblOrderItems.tblOrderItems_Select_PickedQuantities_total_for_Calender & SelectString & SelectString1 & " group by b. UnitOfMeasure " & SelectStringLargeOrders, pp2)
                Dim Str As String = ""
                For Each dr As DataRow In dt2.Rows
                    If dr("Unit").ToString.ToUpper.Contains("CASE") Then
                        Str += dr("Total").ToString & " " & dr("Unit").ToString ' & ", "
                        Exit For
                    End If
                Next
                DataGridView1.Rows(0).Cells(i + 1).Value = Str
            Catch ex As Exception
            End Try



            DataGridView1.Columns(i + 1).HeaderText = dte.ToString("MM-dd-yyyy") & vbNewLine & dte.DayOfWeek.ToString
            DataGridView1.Columns(i + 1).Tag = dte


            Try
                For Each dr As DataRow In dtNotes.Rows
                    If dr("NoteDate") = dte.Date Then
                        DataGridView1.Rows(1).Cells(i + 1).Value = "NOTE"
                    End If
                Next
            Catch ex As Exception
            End Try


            'DataGridView1.Columns(i + 1).SortMode = DataGridViewColumnSortMode.Programmatic
            Dim lrc As Integer = 0
            Try
                Dim pp As New List(Of SqlParameter)
                SelectString += SelectString2 & SelectStringLargeOrders2 & " AND a.[" & cls_tblOrder.FieldName.OrderDate.ToString & "] Between @d1 and @d2 Order By CreatedDate,CustomerName"
                pp.Add(New SqlParameter("@d1", dte))
                pp.Add(New SqlParameter("@d2", dte2))
                Dim dt As DataTable = Nothing
                dt = objOrders.Selection(cls_tblOrder.SelectionType.ReviewOrder, SelectString, pp)
                lrc = dt.Rows.Count
                For j = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(j)
                    If DataGridView1.RowCount = j + FstRow Then
                        DataGridView1.Rows.Add(j + FstRow, "", "", "", "", "", "", "")
                    End If
                    'DataGridView1.Rows(j).Cells(i + 1).Value = "Order#: " & dr("OrderNo") & vbNewLine & _
                    '   "Customer: " & dr("CustomerName") & vbNewLine & _
                    '   "Status: " & dr("Status") & vbNewLine & _
                    '   IIf(dr("Drop Off Point") <> "", "Drop Off Point: " & dr("Drop Off Point") & vbNewLine, "") & _
                    '    "Total Items: " & dr("TotalItems") & vbNewLine '& _
                    Try
                        'DataGridView1.Rows(j + 1).Cells(i + 1).Value = dr("CustomerName").ToString.Substring(0, 14) & ", " & _
                        '                   dr("Total Cases") & " Cases" '& vbNewLine & _
                        DataGridView1.Rows(j + FstRow).Cells(i + 1).Value = dr("CustomerName").ToString.Substring(0, 13) & vbNewLine & _
                                          dr("Total Cases") & " Cases" '& vbNewLine & _
                    Catch ex As Exception
                        'DataGridView1.Rows(j + 1).Cells(i + 1).Value = dr("CustomerName").ToString & ", " & _
                        '                    dr("Total Cases") & " Cases" '& vbNewLine & _
                        DataGridView1.Rows(j + FstRow).Cells(i + 1).Value = dr("CustomerName").ToString & vbNewLine & _
                                          dr("Total Cases") & " Cases" '& vbNewLine & _
                    End Try

                    If dr("Status").ToString = "On Hold" Then
                        DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.Gray
                        'If dr("Total Cases") >= 15 Then
                        '    DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.LavenderBlush + Color.Gray
                        'ElseIf dr("Total Cases") >= 5 Then
                        '    DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.LightYellow + Color.Gray
                        'Else
                        '    DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.FromArgb(192, 255, 192) + Color.Gray
                        'End If

                    ElseIf dr("Status").ToString = "Cancelled" Then
                        DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.OrangeRed
                    Else
                        If dr("Total Cases") >= 15 Then
                            DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.LavenderBlush
                        ElseIf dr("Total Cases") >= 5 Then
                            DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.LightYellow
                        Else
                            DataGridView1.Rows(j + FstRow).Cells(i + 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        End If
                    End If



                    'DataGridView1.Rows(j + 1).Cells(i + 1).Value = dr("CustomerName").ToString.Substring(0, 10) & ", " & _
                    'dr("Total Cases") & " Cases" '& vbNewLine & _
                    '"Total " & dr("TotalItems") & " items" & vbNewLine '& _
                    'dr("") & vbNewLine & _
                    'dr("") & vbNewLine & _
                    'dr("") & vbNewLine


                    DataGridView1.Rows(j + FstRow).Cells(i + 1).Tag = dr("OrderId")
                Next
            Catch ex As Exception
            End Try
            If chkFutureOrders.Checked Then
                Try
                    Dim SelectTable As String = ""

                    SelectString = ""
                    Dim pp As New List(Of SqlParameter)

                    'pp.Add(New SqlParameter("@d1", dtpFrom.Value.Date)) 


                    Dim cl As Integer = 1
                    Dim d1 As Date = dte
                    While d1 <= dte2
                        If SelectTable <> "" Then
                            SelectTable += " UNION ALL "
                        End If
                        SelectTable += " select @d" & cl.ToString & " dddddd "
                        pp.Add(New SqlParameter("@d" & cl.ToString, d1))
                        cl += 1
                        d1 = d1.AddDays(1)
                    End While


                    SelectTable = "RIGHT OUTER JOIN (" & SelectTable & ")  fff on (a.startdate = a.enddate or CONVERT(date,fff.dddddd) between a.startdate and a.enddate) and ((a.[ScheduleType]='DAILY' and (a.[Repeat] =1 or DATEDIFF(DAY,a.[StartDate] ,CONVERT(date,fff.dddddd)) % a.[Repeat] = 0)) or (a.[ScheduleType]='WEEKLY' and a.[ScheduleInfo] like '%' + (DATENAME(dw, fff.dddddd)) + '%') OR (a.[ScheduleType]='MONTHLY' and (a.[Repeat] =1 or DATEDIFF(Month,a.[StartDate] ,CONVERT(date,fff.dddddd)) % a.[Repeat] = 0) and DATEPART (day,a.[StartDate]) = DATEPART (day,fff.dddddd))) and a.OrderId not in (Select ScheduledOrderId from tblOrder where Convert(Date,OrderDate)=fff.dddddd)  "
                    Dim dt As DataTable = objSchOrders.Selection(cls_tblOrderSchedule.SelectionType.ScheduledOrder, SelectTable & " Where a.OrderId is not null " & SelectString & SelectString3 & SelectStringLargeOrders3, pp)
                    For j = 0 To dt.Rows.Count - 1
                        Dim dr As DataRow = dt.Rows(j)
                        If DataGridView1.RowCount = lrc + j + FstRow Then
                            DataGridView1.Rows.Add(lrc + j + FstRow, "", "", "", "", "", "", "")
                        End If

                        Try
                            'DataGridView1.Rows(j + 1).Cells(i + 1).Value = dr("CustomerName").ToString.Substring(0, 14) & ", " & _
                            '                   dr("Total Cases") & " Cases" '& vbNewLine & _
                            DataGridView1.Rows(lrc + j + FstRow).Cells(i + 1).Value = dr("CustomerName").ToString.Substring(0, 13) & vbNewLine & _
                                              dr("Total Cases") & " Cases" '& vbNewLine & _
                        Catch ex As Exception
                            'DataGridView1.Rows(j + 1).Cells(i + 1).Value = dr("CustomerName").ToString & ", " & _
                            '                    dr("Total Cases") & " Cases" '& vbNewLine & _
                            DataGridView1.Rows(lrc + j + FstRow).Cells(i + 1).Value = dr("CustomerName").ToString & vbNewLine & _
                                              dr("Total Cases") & " Cases" '& vbNewLine & _
                        End Try

                        DataGridView1.Rows(lrc + j + FstRow).Cells(i + 1).Style.BackColor = Color.Orange
                        'If dr("Total Cases") >= 15 Then
                        '    DataGridView1.Rows(j + 1).Cells(i + 1).Style.BackColor = Color.LavenderBlush
                        'ElseIf dr("Total Cases") >= 5 Then
                        '    DataGridView1.Rows(j + 1).Cells(i + 1).Style.BackColor = Color.LightYellow
                        'Else
                        '    DataGridView1.Rows(j + 1).Cells(i + 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        'End If
                        'DataGridView1.Rows(j + 1).Cells(i + 1).Value = dr("CustomerName").ToString.Substring(0, 10) & ", " & _
                        'dr("Total Cases") & " Cases" '& vbNewLine & _
                        '"Total " & dr("TotalItems") & " items" & vbNewLine '& _
                        'dr("") & vbNewLine & _
                        'dr("") & vbNewLine & _
                        'dr("") & vbNewLine


                        DataGridView1.Rows(lrc + j + FstRow).Cells(i + 1).Tag = dr("OrderId")
                    Next
                Catch ex As Exception

                End Try


            End If
            openSelected()
        Next
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged
   
        openSelected()

    End Sub
    Sub openSelected()
        Try
            If DataGridView1.SelectedCells(0).Style.BackColor = Color.Orange Then
                Try
                    CntlScheduledOrderView1.ScheduleDate = Nothing
                    Try
                        CntlScheduledOrderView1.ScheduleDate = DataGridView1.Columns(DataGridView1.SelectedCells(0).ColumnIndex).Tag
                    Catch ex As Exception
                        CntlScheduledOrderView1.ScheduleDate = Nothing
                    End Try
                    CntlScheduledOrderView1.OpenOrder(DataGridView1.SelectedCells(0).Tag)
                    CntlScheduledOrderView1.BringToFront()
                Catch ex As Exception
                    CntlScheduledOrderView1.Clear()
                End Try
            Else

                Try
                    CntlOrderView1.OpenOrder(DataGridView1.SelectedCells(0).Tag)
                    CntlOrderView1.BringToFront()
                Catch ex As Exception
                    CntlOrderView1.Clear()
                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub frmCalender2_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
        lblRGB.BackColor = Color.FromArgb(192, 255, 192)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtDate.ValueChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        GetValues()
    End Sub

    Private Sub DataGridView1_SortCompare(sender As Object, e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles DataGridView1.SortCompare
        e.Handled = e.RowIndex1 = 0 Or e.RowIndex2 = 0
  
    End Sub
 
    Private Sub CntlScheduledOrderView1_Confirmed() Handles CntlScheduledOrderView1.Confirmed
        GetValues()
    End Sub

    

    Private Sub DataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim fr As New frmCalNotes
            If DataGridView1.Rows(1).Cells(DataGridView1.SelectedCells(0).ColumnIndex).Value = "NA" Then
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim dt As Date = DataGridView1.Columns(DataGridView1.SelectedCells(0).ColumnIndex).Tag
                    objNotes.Insert(dt.Date, fr.RichTextBox1.Text)
                    DataGridView1.Rows(1).Cells(DataGridView1.SelectedCells(0).ColumnIndex).Value = "NOTE"
                End If
            Else
                Dim dt As Date = DataGridView1.Columns(DataGridView1.SelectedCells(0).ColumnIndex).Tag
                Dim ni As cls_tblNotes.Fields = objNotes.Selection_One_Row_Select("NoteDate=@Da", New List(Of SqlParameter) From {New SqlParameter("@Da", dt.Date)})
                fr.RichTextBox1.Text = ni.Notes_
                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                    objNotes.Update(dt.Date, fr.RichTextBox1.Text, ni.NoteId_)
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class