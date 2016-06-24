Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class frmImportEmployee
    Dim fl As OpenFileDialog

    Public oXL As Microsoft.Office.Interop.Excel.Application
    Dim oWB As Microsoft.Office.Interop.Excel.Workbook
    Dim oSheet1 As Microsoft.Office.Interop.Excel.Worksheet

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        fl = New OpenFileDialog
        fl.Filter = "Excel Files|*.xls"
        fl.Title = "Select : Employee Time Card Report.xls"
        If fl.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = fl.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Not IO.File.Exists(TextBox1.Text) Then
            MsgBox("select a valid file")
        End If
        Try
            oXL = CreateObject("Excel.Application")
            oXL.Visible = False
            oWB = oXL.Workbooks.Open(TextBox1.Text)
            oSheet1 = oWB.Worksheets(1)
            Dim n As String = oSheet1.Name

            Try
                'Marshal.ReleaseComObject(oSheet1)
                'oWB.Close(Type.Missing, Type.Missing, Type.Missing)
                'Marshal.ReleaseComObject(oWB)
                'oXL.Quit()
                'Marshal.ReleaseComObject(oXL)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                'Marshal.FinalReleaseComObject(xlRng)
                Marshal.FinalReleaseComObject(oSheet1)
                oWB.Close(Type.Missing, Type.Missing, Type.Missing)
                Marshal.FinalReleaseComObject(oWB)
                oXL.Quit()
                Marshal.FinalReleaseComObject(oXL)
            Catch ex As Exception
            End Try


            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection ("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & TextBox1.Text & "';Extended Properties=Excel 8.0;")
            Dim ds As DataSet = New System.Data.DataSet
            MyCommand = New System.Data.OleDb.OleDbDataAdapter _
            ("select * from [" & n & "$]", MyConnection)
            '   MyCommand.TableMappings.Add("Table", "TestTable")

            MyCommand.Fill(ds, "Table1")
            MyCommand.Dispose()
            Try
                MyConnection.Close()
            Catch ex As Exception
            End Try
            Dim dt As DataTable = ds.Tables(0)
            Dim employeename As String = dt.Rows(5)(3).ToString
            Dim employeecode As String = ""
            Dim str As String = ""

            'Dim employeename As String = ""
            'Dim employeename As String = ""

            oXL = CreateObject("Excel.Application")
            oXL.Visible = False

            oWB = oXL.Workbooks.Open(TextBox1.Text)
            oSheet1 = oWB.Worksheets(1)

            Dim StartCount As Integer = 0
            Dim i = 1
            While i <= dt.Rows.Count
                For i = StartCount + 1 To dt.Rows.Count
                    Try
                        If Not oSheet1.Cells(i, 1).Value Is Nothing Then
                            If oSheet1.Cells(i, 1).Value.ToString = "Employee Number" Then
                                StartCount = i
                                Exit For
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next

                Try
                    If Not oSheet1.Cells(StartCount + 2, 1).Value Is Nothing Then
                        str += "Emp Code : " & oSheet1.Cells(StartCount + 2, 1).Value.ToString & vbNewLine
                    End If
                Catch ex As Exception
                    str += "Emp Code : NO CODE" & vbNewLine
                End Try

                Try
                    If Not oSheet1.Cells(StartCount + 1, 3).Value Is Nothing Then
                        str += "Emp Name : " & oSheet1.Cells(StartCount + 1, 3).Value.ToString & vbNewLine
                    End If
                Catch ex As Exception
                    str += "Emp Name : NO NAME" & vbNewLine
                End Try




                Dim j = 1
                StartCount += 4


                str += "DATE       || START    || BREAK IN || BREAK OUT || LUNCH IN || LUNCH OUT || BREAK IN || BREAK OUT || END  " & vbNewLine


                Dim DayCount As Integer = 0
                Try
                    j = 1
                    Dim blankCount = 0
                    Dim isLunch As Boolean = False
                    Dim EndTime As String = ""
                    While DayCount < 15 And blankCount < 10
                        If IsDateUS(oSheet1.Cells(StartCount + j, 2).Value) Then
                            Try
                                str += vbNewLine
                                str += oSheet1.Cells(StartCount + j, 2).Value.ToString & "    " & oSheet1.Cells(StartCount + j, 7).Value.ToString
                                EndTime = oSheet1.Cells(StartCount + j, 9).Value.ToString
                                If IsDateUS(oSheet1.Cells(StartCount + j + 1, 2).Value) Or oSheet1.Cells(StartCount + j + 1, 9).Value Is Nothing Then
                                    str += " ".PadLeft(80) & EndTime
                                Else
                                    If Not IsDateUS(oSheet1.Cells(StartCount + j + 1, 2).Value) And Not oSheet1.Cells(StartCount + j + 1, 9).Value Is Nothing Then
                                        Select Case oSheet1.Cells(StartCount + j + 1, 4).Value.ToString
                                            Case "Break"
                                                str += "     " & oSheet1.Cells(StartCount + j + 1, 7).Value.ToString & "     " & oSheet1.Cells(StartCount + j + 1, 9).Value.ToString

                                                If Not oSheet1.Cells(StartCount + j + 3, 4).Value Is Nothing AndAlso oSheet1.Cells(StartCount + j + 3, 4).Value.ToString = "Break" Then
                                                    str += " ".PadLeft(28) & oSheet1.Cells(StartCount + j + 3, 7).Value.ToString & "    " & oSheet1.Cells(StartCount + j + 3, 9).Value.ToString & "    " & oSheet1.Cells(StartCount + j + 4, 9).Value.ToString
                                                ElseIf Not oSheet1.Cells(StartCount + j + 3, 4).Value Is Nothing AndAlso oSheet1.Cells(StartCount + j + 3, 4).Value.ToString = "Lunch" Then

                                                    str += "      " & oSheet1.Cells(StartCount + j + 3, 7).Value.ToString & "    " & oSheet1.Cells(StartCount + j + 3, 9).Value.ToString
                                                    If Not oSheet1.Cells(StartCount + j + 5, 4).Value Is Nothing AndAlso oSheet1.Cells(StartCount + j + 5, 4).Value.ToString = "Break" Then
                                                        str += "     " & oSheet1.Cells(StartCount + j + 5, 7).Value.ToString & "     " & oSheet1.Cells(StartCount + j + 5, 9).Value.ToString & "      " & oSheet1.Cells(StartCount + j + 6, 9).Value.ToString
                                                    Else
                                                        str += " ".PadLeft(30) & oSheet1.Cells(StartCount + j + 4, 9).Value.ToString
                                                    End If
                                                Else
                                                    str += " ".PadLeft(30) & oSheet1.Cells(StartCount + j + 2, 9).Value.ToString
                                                End If




                                            Case "Lunch"
                                                str += " ".PadLeft(30) & oSheet1.Cells(StartCount + j + 1, 7).Value.ToString & "    " & oSheet1.Cells(StartCount + j + 1, 9).Value.ToString
                                                If Not oSheet1.Cells(StartCount + j + 3, 4).Value Is Nothing AndAlso oSheet1.Cells(StartCount + j + 3, 4).Value.ToString = "Break" Then
                                                    str += "     " & oSheet1.Cells(StartCount + j + 3, 7).Value.ToString & "     " & oSheet1.Cells(StartCount + j + 3, 9).Value.ToString & "      " & oSheet1.Cells(StartCount + j + 4, 9).Value.ToString
                                                Else
                                                    str += " ".PadLeft(30) & oSheet1.Cells(StartCount + j + 2, 9).Value.ToString
                                                End If
                                        End Select

                                    End If
                                End If
                            Catch ex As Exception

                            End Try


                            DayCount += 1
                            blankCount = 0
                            isLunch = False
                        Else
                            blankCount += 1
                        End If
                        j += 1
                    End While

                    str += vbNewLine
                Catch ex As Exception

                End Try



                str += vbNewLine & vbNewLine & vbNewLine & " ***END*** " & vbNewLine & vbNewLine & vbNewLine



            End While



            TextBox2.Text = str



        Catch ex As Exception
        End Try
        Try
            'Marshal.ReleaseComObject(oSheet1)
            'oWB.Close(Type.Missing, Type.Missing, Type.Missing)
            'Marshal.ReleaseComObject(oWB)
            'oXL.Quit()
            'Marshal.ReleaseComObject(oXL)


            GC.Collect()
            GC.WaitForPendingFinalizers()

            'Marshal.FinalReleaseComObject(xlRng)
            Marshal.FinalReleaseComObject(oSheet1)

            oWB.Close(Type.Missing, Type.Missing, Type.Missing)
            Marshal.FinalReleaseComObject(oWB)

            oXL.Quit()
            Marshal.FinalReleaseComObject(oXL)

        Catch ex As Exception
        End Try
    End Sub


    Function IsDateUS(ByVal s As String) As Boolean
        Dim result As Date
        Return Date.TryParse(s, Globalization.CultureInfo.GetCultureInfo("en-US"), _
                 Globalization.DateTimeStyles.None, result)
    End Function
    'Gets a string in US Date format and return as date variable.
    Function CDateUS(ByVal s As String) As Date
        Dim result As Date
        If Not Date.TryParse(s, Globalization.CultureInfo.GetCultureInfo("en-US"), Globalization.DateTimeStyles.None, result) Then
            Throw New Exception("Error which converting Date from String in U.S. Date Format")
        End If
        Return result
    End Function

    Private Sub frmImportEmployee_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class