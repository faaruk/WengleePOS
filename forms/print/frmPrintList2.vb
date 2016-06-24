Imports System.Drawing.Printing

Public Class frmPrintList2
    Public Sub Print(ByRef dg As DataGridView, ByVal header1 As String, ByVal header2 As String, ByVal footer1 As String, ByVal footer2 As String, ByVal isLandscape As Boolean, ByVal Reportprinter2 As String, ByVal printPageNo As Boolean)
        DGPrint = dg
        HeaderMain = header1
        HeaderSub = header2
        FooterMain = footer1
        FooterSub = footer2
        isPageNoPrint = printPageNo

        If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Info") = MsgBoxResult.Yes And DGPrint.RowCount <> 0 Then
            Try
                PrintDocument1.DefaultPageSettings.Landscape = isLandscape
                If Reportprinter2 <> "" Then
                    PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = Reportprinter2
                End If
                Dim printerformat As System.Drawing.Printing.PaperSize
                Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
                PrinterObj.PrinterName = PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName
                For Each printerformat In PrinterObj.PaperSizes()
                    Try
                        If "A4" = printerformat.PaperName Then
                            PrintDocument1.DefaultPageSettings.PaperSize = printerformat
                            Exit For
                        End If
                    Catch ex As Exception
                    End Try
                Next
                PrintDocument1.DefaultPageSettings.Margins.Top = 20 '+ m1
                PrintDocument1.DefaultPageSettings.Margins.Left = 20
                PrintDocument1.DefaultPageSettings.Margins.Bottom = 20 ' + m2
                PrintDocument1.DefaultPageSettings.Margins.Right = 20
                Me.PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
                Me.PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
                Me.PageSetupDialog1.PrinterSettings = PrintDocument1.PrinterSettings
                PrintDocument1.Print()
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub PrintPreview(ByRef dg As DataGridView, ByVal header1 As String, ByVal header2 As String, ByVal footer1 As String, ByVal footer2 As String, ByVal isLandscape As Boolean, ByVal Reportprinter2 As String, ByVal printPageNo As Boolean)
        DGPrint = dg
        HeaderMain = header1
        HeaderSub = header2
        FooterMain = footer1
        FooterSub = footer2
        isPageNoPrint = printPageNo
        Try
            PrintDocument1.DefaultPageSettings.Landscape = isLandscape
            If Reportprinter2 <> "" Then
                PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = Reportprinter2
            End If
            Dim printerformat As System.Drawing.Printing.PaperSize
            Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
            PrinterObj.PrinterName = PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName

            For Each printerformat In PrinterObj.PaperSizes()
                Try
                    If "A4" = printerformat.PaperName Then
                        PrintDocument1.DefaultPageSettings.PaperSize = printerformat
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next

            PrintDocument1.DefaultPageSettings.Margins.Top = 20 '+ m1
            PrintDocument1.DefaultPageSettings.Margins.Left = 20
            PrintDocument1.DefaultPageSettings.Margins.Bottom = 20 ' + m2
            PrintDocument1.DefaultPageSettings.Margins.Right = 20
            Me.PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
            Me.PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
            Me.PageSetupDialog1.PrinterSettings = PrintDocument1.PrinterSettings
            Me.PrintPreviewControl1.Document = Me.PrintDocument1
            Me.TextBoxX1.Text = nPageNo
            Me.WindowState = FormWindowState.Maximized
            Me.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PrintPreview(ByRef dg As DataGridView, ByVal header1 As String, ByVal header2 As String, ByVal footer1 As String, ByVal footer2 As String, ByVal isLandscape As Boolean, ByVal Reportprinter2 As String, ByVal printPageNo As Boolean, ByVal DatePrint As Boolean)
        isPrintDate = DatePrint
        PrintPreview(dg, header1, header2, footer1, footer2, isLandscape, Reportprinter2, printPageNo)

    End Sub


    Dim DGPrint As DataGridView
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''print''''''''''''''''''''''''''

    Private oStringFormat As StringFormat
    Private oStringFormatComboBox As StringFormat
    Private oButton As Button
    Private oCheckbox As CheckBox
    Private oComboBox As ComboBox

    Private nTotalWidth As Int16
    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private nMulti As Double
    Private HeaderMain As String
    Private HeaderSub As String
    Private FooterMain As String
    Private FooterSub As String
    Private isPageNoPrint As Boolean
    Private isPrintDate As Boolean = False
    Private sUserName As String = ""
    Dim c As Integer = 0

    Dim copies As Integer = 1
    Dim IsFirstCopy As Boolean = True
    Dim IsStaticLineHeight As Boolean = False
    Dim StaticHeightAdd As Integer = 11

    Sub clear()
        oStringFormat = Nothing
        oStringFormatComboBox = Nothing
        oButton = Nothing
        oCheckbox = Nothing
        oComboBox = Nothing
        nMulti = Nothing
        nTotalWidth = Nothing
        nRowPos = Nothing
        NewPage = Nothing
        nPageNo = Nothing
        sUserName = Nothing
    End Sub
    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

        oStringFormat = New StringFormat
        oStringFormat.Alignment = StringAlignment.Center
        oStringFormat.LineAlignment = StringAlignment.Center
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter

        oStringFormatComboBox = New StringFormat
        oStringFormatComboBox.LineAlignment = StringAlignment.Center
        oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
        oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter

        oButton = New Button
        oCheckbox = New CheckBox
        oComboBox = New ComboBox

        nTotalWidth = 0
        For Each oColumn As DataGridViewColumn In (From di As DataGridViewColumn In DGPrint.Columns
                                                   Select di
                                                   Order By di.DisplayIndex)

            If oColumn.Visible And oColumn.HeaderText.Trim <> "" Then
                nTotalWidth += oColumn.Width
            End If
        Next
        nPageNo = 1
        NewPage = True
        nRowPos = 0
        c = 0
        If IsFirstCopy Then
            copies = 1
        End If
    End Sub

    Private Sub PrintDocument1_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.EndPrint
        Me.TextBoxX2.Text = Me.PrintPreviewControl1.StartPage + 1
        Me.TextBoxX1.Text = nPageNo
        copies += 1
        IsFirstCopy = False
        'If PrintDocument1.PrinterSettings.Collate Then
        '    If PrintDocument1.PrinterSettings.Copies >= copies Then
        '        PrintDocument1.Print()
        '    End If
        'End If
        IsFirstCopy = True
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' e.PageSettings.
Read:
        c += 1
        Static oColumnLefts As New ArrayList
        Static oColumnWidths As New ArrayList
        Static oColumnTypes As New ArrayList
        Static nHeight As Int16

        Dim nWidth, i, nRowsPerPage As Int16
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim nLeft As Int16 = e.MarginBounds.Left

        If nPageNo = 1 Then
            'Draw column Header
            oColumnLefts.Clear()
            oColumnWidths.Clear()
            oColumnTypes.Clear()
            For Each oColumn As DataGridViewColumn In (From di As DataGridViewColumn In DGPrint.Columns
                                                   Select di
                                                   Order By di.DisplayIndex)
                If oColumn.Visible And oColumn.HeaderText.Trim <> "" Then
                    nWidth = CType(Math.Floor(oColumn.Width / nTotalWidth * nTotalWidth * (e.MarginBounds.Width / nTotalWidth)), Int16)

                    nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + StaticHeightAdd

                    oColumnLefts.Add(nLeft)
                    oColumnWidths.Add(nWidth)
                    oColumnTypes.Add(oColumn.GetType)
                    nLeft += nWidth
                End If


            Next

        End If

        Do While nRowPos <= DGPrint.Rows.Count - 1



            Dim oRow As DataGridViewRow = DGPrint.Rows(nRowPos)
            i = 0
            If Not IsStaticLineHeight Then
                nHeight = 0
                For Each oCell As DataGridViewCell In (From di As DataGridViewCell In oRow.Cells
                                                   Select di
                                                   Order By DGPrint.Columns(di.ColumnIndex).DisplayIndex)
                    If DGPrint.Columns(oCell.ColumnIndex).Visible And DGPrint.Columns(oCell.ColumnIndex).HeaderText.Trim <> "" Then
                        Dim d As Integer = 0
                        Try
                            d = e.Graphics.MeasureString(oCell.Value.ToString, oCell.InheritedStyle.Font, oColumnWidths(i)).Height + 2 '+ 11
                        Catch ex As Exception
                        End Try
                        If d > nHeight Then
                            nHeight = d
                        End If
                        i += 1
                    End If
                Next
            End If



            'If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top - (e.Graphics.MeasureString(HeaderMain, New Font(DGPrint.Font, FontStyle.Bold), e.MarginBounds.Width).Height + 13) Then
            If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                'Draw footer
                DrawFooterSub(e, nRowsPerPage)

                NewPage = True
                nPageNo += 1
                If Not (c >= e.PageSettings.PrinterSettings.FromPage And c < e.PageSettings.PrinterSettings.ToPage) And e.PageSettings.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    If c >= e.PageSettings.PrinterSettings.ToPage Then
                        'DrawFooterMain(e, nRowsPerPage, nTop)
                        'e.HasMorePages = False
                        e.HasMorePages = DrawFooterMain(e, nRowsPerPage, nTop)
                        Exit Sub
                    Else
                        e.Graphics.Clear(Color.White)
                        GoTo read
                    End If
                End If
                'If Not PrintDocument1.PrinterSettings.Collate Then

                'End If
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    oStringFormat.Alignment = StringAlignment.Far
                    oStringFormat.LineAlignment = StringAlignment.Near
                    If isPageNoPrint Then
                        e.Graphics.DrawString("Page : " & nPageNo.ToString, New Font(DGPrint.Font, FontStyle.Italic), Brushes.Black, e.MarginBounds.Left, 5)
                    End If
                    If isPrintDate Then
                        e.Graphics.DrawString("Print Date : " & Format(Now, "dd-MM-yyyy HH:mm"), New Font(DGPrint.Font, FontStyle.Italic), Brushes.Black, New RectangleF(5, 5, e.MarginBounds.Right - 5, 30), oStringFormat)
                    End If


                    oStringFormat.Alignment = StringAlignment.Center
                    oStringFormat.LineAlignment = StringAlignment.Center
                    'If HeaderMain <> "" Then
                    '    e.Graphics.DrawString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold), Brushes.Black, New RectangleF(e.MarginBounds.Left, 13, e.MarginBounds.Width, e.Graphics.MeasureString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold), e.MarginBounds.Width).Height), oStringFormat)
                    'End If
                    'If HeaderSub <> "" Then
                    '    e.Graphics.DrawString(HeaderSub, New Font(DGPrint.Font, FontStyle.Bold), Brushes.Black, New RectangleF(e.MarginBounds.Left, 13 + e.Graphics.MeasureString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold), e.MarginBounds.Width).Height, e.MarginBounds.Width, e.Graphics.MeasureString(HeaderSub, New Font(DGPrint.Font, FontStyle.Bold), e.MarginBounds.Width).Height), oStringFormat)
                    'End If
                    If HeaderMain <> "" Then
                        e.Graphics.DrawString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold), Brushes.Black, New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.Graphics.MeasureString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold), e.MarginBounds.Width).Height), oStringFormat)
                    End If
                    If HeaderSub <> "" Then
                        e.Graphics.DrawString(HeaderSub, New Font("Courier New", 10, FontStyle.Regular), Brushes.Black, New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top + e.Graphics.MeasureString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold), e.MarginBounds.Width).Height, e.MarginBounds.Width, e.Graphics.MeasureString(HeaderSub, New Font("Courier New", 10, FontStyle.Regular), e.MarginBounds.Width).Height), oStringFormat)
                    End If
                    ' Draw Columns Header
                    nTop = e.MarginBounds.Top + e.Graphics.MeasureString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold), e.MarginBounds.Width).Height + e.Graphics.MeasureString(HeaderSub, New Font("Courier New", 10, FontStyle.Regular), e.MarginBounds.Width).Height + 5
                    i = 0
                    If Not IsStaticLineHeight Then
                        For Each oColumn As DataGridViewColumn In (From di As DataGridViewColumn In DGPrint.Columns
                                                   Select di
                                                   Order By di.DisplayIndex)
                            If oColumn.Visible And oColumn.HeaderText.Trim <> "" Then
                                nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + StaticHeightAdd
                            End If
                        Next
                    End If
                    For Each oColumn As DataGridViewColumn In (From di As DataGridViewColumn In DGPrint.Columns
                                                   Select di
                                                   Order By di.DisplayIndex)
                        If oColumn.Visible And oColumn.HeaderText.Trim <> "" Then
                            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                            i += 1
                        End If
                    Next
                    nTop += nHeight
                    NewPage = False

                End If

                i = 0
                If Not IsStaticLineHeight Then
                    nHeight = 0
                    For Each oCell As DataGridViewCell In (From di As DataGridViewCell In oRow.Cells
                                                   Select di
                                                   Order By DGPrint.Columns(di.ColumnIndex).DisplayIndex)
                        If DGPrint.Columns(oCell.ColumnIndex).Visible And DGPrint.Columns(oCell.ColumnIndex).HeaderText.Trim <> "" Then
                            Dim d As Integer = 0
                            Try
                                d = e.Graphics.MeasureString(oCell.Value.ToString, oCell.InheritedStyle.Font, oColumnWidths(i)).Height + 2 '+ 11
                            Catch ex As Exception
                            End Try
                            If d > nHeight Then
                                nHeight = d
                            End If
                            i += 1
                        End If
                    Next
                End If
                i = 0
                'Draw items
                For Each oCell As DataGridViewCell In (From di As DataGridViewCell In oRow.Cells
                                                   Select di
                                                   Order By DGPrint.Columns(di.ColumnIndex).DisplayIndex)
                    If DGPrint.Columns(oCell.ColumnIndex).Visible And DGPrint.Columns(oCell.ColumnIndex).HeaderText.Trim <> "" Then
                        oStringFormat.Alignment = StringAlignment.Center
                        oStringFormat.LineAlignment = StringAlignment.Center
                        If oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then

                            Select Case oCell.OwningColumn.DefaultCellStyle.Alignment
                                Case DataGridViewContentAlignment.BottomCenter

                                    oStringFormat.Alignment = StringAlignment.Center
                                    oStringFormat.LineAlignment = StringAlignment.Far

                                Case DataGridViewContentAlignment.BottomRight
                                    oStringFormat.Alignment = StringAlignment.Far
                                    oStringFormat.LineAlignment = StringAlignment.Far

                                Case DataGridViewContentAlignment.BottomLeft
                                    oStringFormat.Alignment = StringAlignment.Near
                                    oStringFormat.LineAlignment = StringAlignment.Far

                                Case DataGridViewContentAlignment.MiddleCenter
                                    oStringFormat.Alignment = StringAlignment.Center
                                    oStringFormat.LineAlignment = StringAlignment.Center

                                Case DataGridViewContentAlignment.MiddleLeft
                                    oStringFormat.Alignment = StringAlignment.Near
                                    oStringFormat.LineAlignment = StringAlignment.Center

                                Case DataGridViewContentAlignment.MiddleRight
                                    oStringFormat.Alignment = StringAlignment.Far
                                    oStringFormat.LineAlignment = StringAlignment.Center

                                Case DataGridViewContentAlignment.NotSet
                                    oStringFormat.Alignment = StringAlignment.Near
                                    If Not IsNothing(oCell.Value) Then
                                        If IsNumeric(oCell.Value.ToString) Then
                                            oStringFormat.Alignment = StringAlignment.Far
                                        Else
                                            oStringFormat.Alignment = StringAlignment.Near
                                        End If
                                    End If
                                    oStringFormat.LineAlignment = StringAlignment.Center

                                Case DataGridViewContentAlignment.TopCenter

                                    oStringFormat.Alignment = StringAlignment.Center
                                    oStringFormat.LineAlignment = StringAlignment.Near

                                Case DataGridViewContentAlignment.TopLeft
                                    oStringFormat.Alignment = StringAlignment.Near
                                    oStringFormat.LineAlignment = StringAlignment.Near

                                Case DataGridViewContentAlignment.TopRight
                                    oStringFormat.Alignment = StringAlignment.Far
                                    oStringFormat.LineAlignment = StringAlignment.Near

                                Case Else
                                    oStringFormat.Alignment = StringAlignment.Near
                                    oStringFormat.LineAlignment = StringAlignment.Center

                            End Select

                            If Not IsNothing(oCell.Value) Then
                                e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                            End If


                        ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then

                            oCheckbox.Size = New Size(14, 14)
                            oCheckbox.Checked = CType(oCell.Value, Boolean)
                            Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
                            Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
                            oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                            oCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width - oCheckbox.Width) / 2, Int32), CType((oBitmap.Height - oCheckbox.Height) / 2, Int32), oCheckbox.Width, oCheckbox.Height))
                            e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))

                        ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then

                            'oComboBox.Size = New Size(oColumnWidths(i), nHeight)
                            'Dim oBitmap As New Bitmap(oComboBox.Width, oComboBox.Height)
                            'oComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                            'e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                            e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) - 16, nHeight), oStringFormatComboBox)

                        ElseIf oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then

                            Dim oCellSize As Rectangle = New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight)
                            Dim oImageSize As Size = CType(oCell.Value, Image).Size
                            e.Graphics.DrawImage(oCell.Value, New Rectangle(oColumnLefts(i) + CType(((oCellSize.Width - oImageSize.Width) / 2), Int32), nTop + CType(((oCellSize.Height - oImageSize.Height) / 2), Int32), CType(oCell.Value, Image).Width, CType(oCell.Value, Image).Height))

                        End If

                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))

                        i += 1
                    End If
                Next
                nTop += nHeight

            End If

            nRowPos += 1
            nRowsPerPage += 1

        Loop

        DrawFooterSub(e, nRowsPerPage)
        'DrawFooterMain(e, nRowsPerPage, nTop)

        'e.HasMorePages = False
        e.HasMorePages = DrawFooterMain(e, nRowsPerPage, nTop)

    End Sub

    Private Sub DrawFooterSub(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)
        If FooterSub <> "" Then
            e.Graphics.DrawString(FooterSub, _
                                  DGPrint.Font, _
                                  Brushes.LightGray, _
                                  e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(FooterSub, DGPrint.Font, e.MarginBounds.Width).Width) / 2, _
                                  e.PageBounds.Height - e.Graphics.MeasureString(FooterSub, DGPrint.Font, e.MarginBounds.Width).Height)
        End If
    End Sub
    Private Function DrawFooterMain(ByRef e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32, ByVal top As Integer) As Boolean
        If FooterMain <> "" Then
            If e.PageBounds.Height > top + e.Graphics.MeasureString(FooterMain, New Font(DGPrint.Font.FontFamily, 10, FontStyle.Bold), e.MarginBounds.Width).Height Then
                oStringFormat = New StringFormat
                oStringFormat.Alignment = StringAlignment.Far
                oStringFormat.LineAlignment = StringAlignment.Near
                oStringFormat.Trimming = StringTrimming.EllipsisCharacter
                e.Graphics.DrawString(FooterMain, _
                                          New Font("Courier New", 10, FontStyle.Bold), _
                                          Brushes.Black, New RectangleF( _
                                              New PointF(e.MarginBounds.Left, top), _
                                              New SizeF(e.MarginBounds.Width - 15, e.Graphics.MeasureString(FooterMain, New Font("Courier New", 10, FontStyle.Bold), e.MarginBounds.Width - 15).Height) _
                                              ), oStringFormat)
                Return False
            Else
                nPageNo += 1
                NewPage = True
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Private Sub Slider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Slider1.ValueChanged
        PrintPreviewControl1.Zoom = Me.Slider1.Value / 100
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        PrintDialog1.AllowSomePages = True
        PrintDialog1.UseEXDialog = True
        PrintDialog1.PrinterSettings = Me.PrintDocument1.DefaultPageSettings.PrinterSettings()
        PrintDialog1.PrinterSettings.ToPage = Val(TextBoxX1.Text)
        PrintDialog1.PrinterSettings.MaximumPage = Val(TextBoxX1.Text)
        PrintDialog1.PrinterSettings.FromPage = 1
        PrintDialog1.PrinterSettings.MinimumPage = 1

        'c = PrintDialog1.PrinterSettings.MaximumCopies
        If Me.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.PrintDocument1.DefaultPageSettings.PrinterSettings = PrintDialog1.PrinterSettings ' Printing.PrintRange.SomePages
            PrintDocument1.DocumentName = HeaderMain & " " & HeaderSub.Replace(vbNewLine, " ") & " Printed on - " & Format(Now, "dd/MM/yy HH:mm:ss tt")
            Me.PrintDocument1.Print()
        End If

    End Sub

    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Me.PrintPreviewControl1.StartPage = IIf(Me.PrintPreviewControl1.StartPage = 0, 0, Me.PrintPreviewControl1.StartPage - 1)
    End Sub

    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Me.PrintPreviewControl1.StartPage = IIf(Me.PrintPreviewControl1.StartPage = nPageNo - 1, Me.PrintPreviewControl1.StartPage, Me.PrintPreviewControl1.StartPage + 1)

    End Sub

    Private Sub ButtonX5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        Me.PrintPreviewControl1.StartPage = 0
    End Sub

    Private Sub ButtonX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        Me.PrintPreviewControl1.StartPage = nPageNo - 1
    End Sub

    Private Sub PrintPreviewControl1_StartPageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewControl1.StartPageChanged
        Me.TextBoxX2.Text = Me.PrintPreviewControl1.StartPage + 1
        Me.TextBoxX1.Text = nPageNo
    End Sub

    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal et As System.EventArgs) Handles ButtonX6.Click
        If Me.PageSetupDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = PageSetupDialog1.PageSettings.Landscape
            PrintDocument1.DefaultPageSettings.PaperSize = PageSetupDialog1.PageSettings.PaperSize

            Dim d As New Label
            Dim e As Graphics = d.CreateGraphics
            Dim m1 As Integer = 0
            If HeaderMain <> "" Then
                m1 += e.MeasureString(HeaderMain, New Font(DGPrint.Font.FontFamily, 16, FontStyle.Bold)).Height
            End If
            If HeaderSub <> "" Then
                m1 += e.MeasureString(HeaderSub, New Font(DGPrint.Font, FontStyle.Bold)).Height
            End If
            PrintDocument1.DefaultPageSettings.Margins.Top = PageSetupDialog1.PageSettings.Margins.Top '+ 13 + m1
            PrintDocument1.DefaultPageSettings.Margins.Left = PageSetupDialog1.PageSettings.Margins.Left
            Dim m2 As Integer = 0
            If FooterMain <> "" Then
                m2 += e.MeasureString(FooterMain, New Font(DGPrint.Font.FontFamily, 10, FontStyle.Bold)).Height
            End If
            If FooterSub <> "" Then
                m2 += e.MeasureString(FooterSub, New Font(DGPrint.Font, FontStyle.Bold)).Height
            End If
            PrintDocument1.DefaultPageSettings.Margins.Bottom = PageSetupDialog1.PageSettings.Margins.Bottom '+ 5 + m2
            PrintDocument1.DefaultPageSettings.Margins.Right = PageSetupDialog1.PageSettings.Margins.Right
            PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = PageSetupDialog1.PrinterSettings.PrinterName

            clear()
            Me.PrintPreviewControl1.InvalidatePreview()
            Me.TextBoxX1.Text = nPageNo
        End If
    End Sub


    Private Sub frmPrintList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub
End Class