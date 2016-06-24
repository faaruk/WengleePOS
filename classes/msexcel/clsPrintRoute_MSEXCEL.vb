Imports System.IO

Public Class clsRoutePrint
    Public oXL As Microsoft.Office.Interop.Excel.Application
    Dim oWB As Microsoft.Office.Interop.Excel.Workbook
    Dim oSheet1 As Microsoft.Office.Interop.Excel.Worksheet
    Dim oSheet2 As Microsoft.Office.Interop.Excel.Worksheet
    Dim objRoute As New cls_tblRoute
    Dim objRouteOrder As New cls_tblRouteOrders
    Dim objOrder As New cls_tblOrder
    Dim objOrderItems As New cls_tblOrderItems
    Dim objCustomer As New cls_tblCustomer
    Dim ObjProductas As New cls_tblProducts
    Dim objCustomerBOL As New cls_tblCustomer_BOL
    Sub CreateRouteSheetPreview(ByVal RouteId As Integer)

        Dim frm As New frmPreviewRoutePrint


        frm.TabPage1.Text = "Shipment Route #" & RouteId.ToString
        frm.TabPage2.Text = "Shipment Route #" & RouteId.ToString & " Addresses"


        Dim MaximumOrders As Integer = 20

        For i = 1 To 20
            frm.dgSheet1.Columns.Add("column" & i.ToString, "")
        Next
        frm.dgSheet2.Columns.Add("column1", "")
        frm.dgSheet2.Columns.Add("column2", "")
        frm.dgSheet2.Columns.Add("column3", "")
        frm.dgSheet2.Columns.Add("column4", "")
        frm.dgSheet2.Columns.Add("column5", "")
        frm.dgSheet2.Columns.Add("column6", "")

        For i = 1 To 50
            frm.dgSheet1.Rows.Add()
            frm.dgSheet2.Rows.Add()
        Next

        'First Sheet

        Try
            Dim i As Integer = 0
            Dim ColStart As Integer = Asc("B")
            Dim RowStart As Integer = 1

            Dim TotalColumns As Integer = 15

            Dim RouteDetails As cls_tblRoute.Fields = objRoute.Selection_One_Row(RouteId)

            Dim SlCounter As Integer = 0

            Dim dtProducts As DataTable = ObjProductas.Selection(cls_tblProducts.SelectionType.All, " 1=1 Order by ProductId")
            Dim dtRouteOrder As DataTable = objRouteOrder.Selection(cls_tblRouteOrders.SelectionType.All, "RouteID =" & RouteId.ToString)


            Dim drOrders As DataRow() = (From dr As DataRow In dtRouteOrder.Rows
                                         Order By dr("sl")
                                         Select dr).ToArray

            frm.Show()

            frm.dgSheet2.Item(1, 1).Value = "ROUTE NAME : "
            frm.dgSheet2.Item(2, 1).Value = RouteDetails.OtherInfos
            frm.dgSheet2.Item(1, 2).Value = "TRUCK : "
            frm.dgSheet2.Item(2, 2).Value = RouteDetails.Truck
            frm.dgSheet2.Item(1, 3).Value = "DRIVER : "
            frm.dgSheet2.Item(2, 3).Value = RouteDetails.Driver
            frm.dgSheet2.Item(1, 4).Value = "DATE : "
            frm.dgSheet2.Item(2, 4).Value = RouteDetails.RouteDate.ToShortDateString
            frm.dgSheet2.Item(1, 5).Value = "TOTAL STOPS : "
            frm.dgSheet2.Item(2, 5).Value = RouteDetails.TotalOrder.ToString



NewPage:




            'Page Heading  
            frm.Label1.Text = "ROUTE OF " & Now.ToShortDateString


            'Page Heading 

            frm.Label2.Text = "ROUTE NAME : " & RouteDetails.OtherInfos & "  TRUCK : " & RouteDetails.Truck & "   DRIVER : " & RouteDetails.Driver


            RowStart += 1

            'columns heading

            frm.dgSheet1.Item(ColStart + 1 - 65, RowStart).Value = "SL."
            frm.dgSheet1.Item(ColStart + 2 - 65, RowStart).Value = "CUSTOMER"

            frm.dgSheet1.Rows(RowStart).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            For i = 0 To 11
                frm.dgSheet1.Item(ColStart + i + 3 - 65, RowStart).Value = dtProducts.Rows(i).Item("ProductName").ToString

            Next


            frm.dgSheet1.Item(ColStart + 15 - 65, RowStart).Value = "OTHERS"
            frm.dgSheet1.Item(ColStart + 16 - 65, RowStart).Value = "COMMENTS"


            For j = SlCounter To IIf(SlCounter + MaximumOrders - 1 > drOrders.Count - 1, drOrders.Count - 1, SlCounter + MaximumOrders - 1)
                Dim drRouteOrder As DataRow = drOrders(j)
                Dim OrderDetails As cls_tblOrder.Fields = Nothing
                Dim CustomerDetails As cls_tblCustomer.Fields = Nothing
                Dim BOLDetails As cls_tblCustomer_BOL.Fields = Nothing
                Dim hasBOL As Boolean = False
                Try
                    OrderDetails = objOrder.Selection_One_Row(drRouteOrder("OrderId"))
                Catch ex As Exception
                End Try
                Try
                    CustomerDetails = objCustomer.Selection_One_Row(OrderDetails.CutomerId)
                Catch ex As Exception
                End Try
                Try
                    Dim itemsl As Integer = OrderDetails.BOLAddressID
                    BOLDetails = objCustomerBOL.Selection_One_Row(itemsl)
                    hasBOL = True
                Catch ex As Exception
                End Try

                RowStart += 1
                Try
                    frm.dgSheet1.Item(ColStart + 1 - 65, RowStart).Value = (SlCounter + 1).ToString
                    frm.dgSheet1.Item(ColStart + 2 - 65, RowStart).Value = CustomerDetails.CustomerName

                Catch ex As Exception
                End Try
                Dim dtOrderItems As DataTable = Nothing
                Try
                    dtOrderItems = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "OrderId=" & OrderDetails.OrderId)
                Catch ex As Exception
                End Try


                Dim ProductID_Main As New List(Of Integer)
                For i = 0 To 11
                    Try

                        Dim Pid As Integer = dtProducts.Rows(i).Item("ProductId").ToString
                        Dim StrQTY As String = ""

                        For Each drOrderItem As DataRow In dtOrderItems.Rows
                            If drOrderItem("ProductId") = Pid Then
                                If (drOrderItem("Frozen") + drOrderItem("Fresh")) > 0 Then
                                    StrQTY = IIf(drOrderItem("Fresh") > 0, drOrderItem("Fresh").ToString & "-" & "fsh" & " " & IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", ""), IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", "")) + " "
                                End If
                            End If
                        Next
                        frm.dgSheet1.Item(ColStart + i + 3 - 65, RowStart).Value = StrQTY

                        ProductID_Main.Add(Pid)

                    Catch ex As Exception
                    End Try
                Next
                Dim StrQTY2 As String = ""
                Try
                    For Each drOrderItem As DataRow In dtOrderItems.Rows
                        Try
                            If Not ProductID_Main.Contains(drOrderItem("ProductId")) Then
                                If (drOrderItem("Frozen") + drOrderItem("Fresh")) > 0 Then
                                    Dim ProductDetails As cls_tblProducts.Fields = ObjProductas.Selection_One_Row(drOrderItem("ProductId"))
                                    StrQTY2 += ProductDetails.ProductName & ": " & IIf(drOrderItem("Fresh") > 0, drOrderItem("Fresh").ToString & "-" & "fsh" & " " & IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", ""), IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", "")) + " "
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try

                Try
                    frm.dgSheet1.Item(ColStart + 15 - 65, RowStart).Value = StrQTY2


                    frm.dgSheet1.Item(ColStart + 16 - 65, RowStart).Value = OrderDetails.Comments


                    frm.dgSheet2.Item(1, 8 + SlCounter).Value = "STOP #" & (SlCounter + 1).ToString
                    If hasBOL Then
                        frm.dgSheet2.Item(2, 8 + SlCounter).Value = CustomerDetails.CustomerName & vbNewLine & BOLDetails.DropOffPoint & vbNewLine &
                                             BOLDetails.Address & ", " & BOLDetails.City & ", " & BOLDetails.State & " " & BOLDetails.Zip & vbNewLine & BOLDetails.Contact
                    Else
                        frm.dgSheet2.Item(2, 8 + SlCounter).Value = CustomerDetails.CustomerName & vbNewLine &
                                             CustomerDetails.Address & ", " & CustomerDetails.City & ", " & CustomerDetails.State & " " & CustomerDetails.Zip
                    End If


                Catch ex As Exception

                End Try

                SlCounter += 1
            Next
            If SlCounter < drOrders.Count Then
                'RowStart += 1
                RowStart += 1

                RowStart += 1

                GoTo NewPage
            End If

            frm.dgSheet2.Item(1, 10 + SlCounter).Value = "TOTAL CASES : "
            frm.dgSheet2.Item(2, 10 + SlCounter).Value = RouteDetails.TotalItems

        Catch ex As Exception
        End Try

    End Sub
    Sub CreateRouteSheet(ByVal RouteId As Integer)


        oXL = CreateObject("Excel.Application")

        oXL.Visible = True
        oWB = oXL.Workbooks.Add
        If oWB.Worksheets.Count < 2 Then
            oWB.Worksheets.Add()
        End If
        oSheet1 = oWB.Worksheets(1)
        oSheet2 = oWB.Worksheets(2)

        oSheet1.Name = "Shipment Route #" & RouteId.ToString
        oSheet2.Name = "Shipment Route #" & RouteId.ToString & " Addresses"


        Dim MaximumOrders As Integer = 20



        'First Sheet

        Try
            Dim i As Integer = 0
            Dim ColStart As Integer = Asc("B")
            Dim RowStart As Integer = 1

            Dim TotalColumns As Integer = 15

            Dim RouteDetails As cls_tblRoute.Fields = objRoute.Selection_One_Row(RouteId)

            Dim SlCounter As Integer = 0

            Dim dtProducts As DataTable = ObjProductas.Selection(cls_tblProducts.SelectionType.All, " 1=1 Order by ProductId")
            Dim dtRouteOrder As DataTable = objRouteOrder.Selection(cls_tblRouteOrders.SelectionType.All, "RouteID =" & RouteId.ToString)


            Dim drOrders As DataRow() = (From dr As DataRow In dtRouteOrder.Rows
                                         Order By dr("sl")
                                         Select dr).ToArray


            oSheet1.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperLetter
            oSheet1.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape

            oSheet1.PageSetup.TopMargin = 10
            oSheet1.PageSetup.LeftMargin = 10
            oSheet1.PageSetup.RightMargin = 10
            oSheet1.PageSetup.BottomMargin = 10
            oSheet1.PageSetup.HeaderMargin = 0
            oSheet1.PageSetup.FooterMargin = 0

            oSheet2.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperLetter
            oSheet2.PageSetup.TopMargin = 19
            oSheet2.PageSetup.LeftMargin = 3
            oSheet2.PageSetup.RightMargin = 3
            oSheet2.PageSetup.BottomMargin = 19
            oSheet2.PageSetup.HeaderMargin = 8
            oSheet2.PageSetup.FooterMargin = 8


            'Sheet 2 Page Heading

            oSheet2.Cells(1, 1).value = "ROUTE NAME : "
            oSheet2.Cells(1, 2).value = RouteDetails.OtherInfos
            oSheet2.Cells(2, 1).value = "TRUCK : "
            oSheet2.Cells(2, 2).value = RouteDetails.Truck
            oSheet2.Cells(3, 1).value = "DRIVER : "
            oSheet2.Cells(3, 2).value = RouteDetails.Driver
            oSheet2.Cells(4, 1).value = "DATE : "
            oSheet2.Cells(4, 2).value = RouteDetails.RouteDate.ToShortDateString
            oSheet2.Cells(5, 1).value = "TOTAL STOPS : "
            oSheet2.Cells(5, 2).value = RouteDetails.TotalOrder.ToString



NewPage:

            Try
                oSheet1.Range("A" & RowStart.ToString).EntireRow.RowHeight = 0.5
            Catch ex As Exception
            End Try

            RowStart += 1

            'Page Heading 
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + TotalColumns) & RowStart.ToString).Merge()
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Value = "ROUTE OF " & Now.ToShortDateString
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Interior.ColorIndex = 4
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Bold = True
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Size = 16
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).BorderAround(8)
            oSheet1.Range(ChrW(ColStart) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            RowStart += 1
            'Page Heading 
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + TotalColumns) & RowStart.ToString).Merge()
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Value = "ROUTE NAME : " & RouteDetails.OtherInfos & "  TRUCK : " & RouteDetails.Truck & "   DRIVER : " & RouteDetails.Driver
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Interior.Color = Color.LightGreen
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Bold = True
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).Font.Size = 14
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString).BorderAround(8)
            oSheet1.Range(ChrW(ColStart) & RowStart).Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            RowStart += 1

            'columns heading
            oSheet1.Range("A1").EntireColumn.ColumnWidth = 0.42
            oSheet1.Range("B1").EntireColumn.ColumnWidth = 3.29
            oSheet1.Range("C1").EntireColumn.ColumnWidth = 19
            oSheet1.Cells(RowStart, ColStart + 1 - 65).Value = "SL."
            oSheet1.Cells(RowStart, ColStart + 2 - 65).Value = "CUSTOMER"
            oSheet1.Cells(RowStart, ColStart + 1 - 65).BorderAround(8)
            oSheet1.Cells(RowStart, ColStart + 2 - 65).BorderAround(8)

            For i = 0 To 11
                oSheet1.Cells(RowStart, ColStart + i + 3 - 65).Value = dtProducts.Rows(i).Item("ProductName").ToString
                oSheet1.Cells(RowStart, ColStart + i + 3 - 65).BorderAround(8)
                oSheet1.Range(ChrW(ColStart + i + 2) & "1").EntireColumn.ColumnWidth = 5.55
            Next

            oSheet1.Range("A" & RowStart.ToString).EntireRow.RowHeight = 56.25
            oSheet1.Cells(RowStart, ColStart + 15 - 65).Value = "OTHERS"
            oSheet1.Cells(RowStart, ColStart + 15 - 65).BorderAround(8)
            oSheet1.Range(ChrW(ColStart + 14) & "1").EntireColumn.ColumnWidth = 18
            'oSheet1.Range(ChrW(ColStart + 15) & RowStart.ToString).Font.Size = 14
            'oSheet1.Range(ChrW(ColStart + 15) & RowStart.ToString).WrapText = True
            oSheet1.Cells(RowStart, ColStart + 16 - 65).Value = "COMMENTS"
            oSheet1.Cells(RowStart, ColStart + 16 - 65).BorderAround(8)
            oSheet1.Range(ChrW(ColStart + 15) & "1").EntireColumn.ColumnWidth = 18
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + TotalColumns) & RowStart.ToString).Interior.Color = Color.WhiteSmoke
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + TotalColumns) & RowStart.ToString).Font.Bold = True
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + TotalColumns) & RowStart.ToString).Font.Size = 14
            oSheet1.Range(ChrW(ColStart) & RowStart.ToString & ":" & ChrW(ColStart + TotalColumns) & RowStart.ToString).WrapText = True

            For j = SlCounter To IIf(SlCounter + MaximumOrders - 1 > drOrders.Count - 1, drOrders.Count - 1, SlCounter + MaximumOrders - 1)
                Dim drRouteOrder As DataRow = drOrders(j)
                Dim OrderDetails As cls_tblOrder.Fields = Nothing
                Dim CustomerDetails As cls_tblCustomer.Fields = Nothing
                Dim BOLDetails As cls_tblCustomer_BOL.Fields = Nothing
                Dim hasBOL As Boolean = False
                Try
                    OrderDetails = objOrder.Selection_One_Row(drRouteOrder("OrderId"))
                Catch ex As Exception
                End Try
                Try
                    CustomerDetails = objCustomer.Selection_One_Row(OrderDetails.CutomerId)
                Catch ex As Exception
                End Try
                Try
                    Dim itemsl As Integer = OrderDetails.BOLAddressID
                    BOLDetails = objCustomerBOL.Selection_One_Row(itemsl)
                    hasBOL = True
                Catch ex As Exception
                End Try

                RowStart += 1
                Try
                    oSheet1.Cells(RowStart, ColStart + 1 - 65).Value = (SlCounter + 1).ToString
                    oSheet1.Cells(RowStart, ColStart + 2 - 65).Value = CustomerDetails.CustomerName
                    oSheet1.Range(ChrW(ColStart + 1) & RowStart.ToString).WrapText = True
                    oSheet1.Cells(RowStart, ColStart + 1 - 65).BorderAround(8)
                    oSheet1.Cells(RowStart, ColStart + 2 - 65).BorderAround(8)
                Catch ex As Exception
                End Try
                Dim dtOrderItems As DataTable = Nothing
                Try
                    dtOrderItems = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "OrderId=" & OrderDetails.OrderId)
                Catch ex As Exception
                End Try


                Dim ProductID_Main As New List(Of Integer)
                For i = 0 To 11
                    Try

                        Dim Pid As Integer = dtProducts.Rows(i).Item("ProductId").ToString
                        Dim StrQTY As String = ""

                        For Each drOrderItem As DataRow In dtOrderItems.Rows
                            If drOrderItem("ProductId") = Pid Then
                                If (drOrderItem("Frozen") + drOrderItem("Fresh")) > 0 Then
                                    StrQTY = IIf(drOrderItem("Fresh") > 0, drOrderItem("Fresh").ToString & "-" & "fsh" & " " & IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", ""), IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", "")) + " "
                                End If
                            End If
                        Next
                        oSheet1.Cells(RowStart, ColStart + i + 3 - 65).Value = StrQTY
                        oSheet1.Cells(RowStart, ColStart + i + 3 - 65).BorderAround(8)
                        ProductID_Main.Add(Pid)

                    Catch ex As Exception
                    End Try
                Next
                Dim StrQTY2 As String = ""
                Try
                    For Each drOrderItem As DataRow In dtOrderItems.Rows
                        Try
                            If Not ProductID_Main.Contains(drOrderItem("ProductId")) Then
                                If (drOrderItem("Frozen") + drOrderItem("Fresh")) > 0 Then
                                    Dim ProductDetails As cls_tblProducts.Fields = ObjProductas.Selection_One_Row(drOrderItem("ProductId"))
                                    StrQTY2 += ProductDetails.ProductName & ": " & IIf(drOrderItem("Fresh") > 0, drOrderItem("Fresh").ToString & "-" & "fsh" & " " & IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", ""), IIf(drOrderItem("Frozen") > 0, drOrderItem("Frozen").ToString & "-" & "fzn", "")) + " "
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try

                Try
                    oSheet1.Cells(RowStart, ColStart + 15 - 65).Value = StrQTY2
                    oSheet1.Cells(RowStart, ColStart + 15 - 65).BorderAround(8)

                    oSheet1.Cells(RowStart, ColStart + 16 - 65).Value = OrderDetails.Comments
                    oSheet1.Cells(RowStart, ColStart + 16 - 65).BorderAround(8)

                    oSheet2.Cells(8 + SlCounter, 1).value = "STOP #" & (SlCounter + 1).ToString
                    If hasBOL Then
                        oSheet2.Cells(8 + SlCounter, 2).value = CustomerDetails.CustomerName & vbNewLine & BOLDetails.DropOffPoint & vbNewLine &
                                             BOLDetails.Address & ", " & BOLDetails.City & ", " & BOLDetails.State & " " & BOLDetails.Zip & vbNewLine & BOLDetails.Contact
                    Else
                        oSheet2.Cells(8 + SlCounter, 2).value = CustomerDetails.CustomerName & vbNewLine &
                                             CustomerDetails.Address & ", " & CustomerDetails.City & ", " & CustomerDetails.State & " " & CustomerDetails.Zip
                    End If

                    oSheet1.Range("A" & RowStart.ToString).EntireRow.RowHeight = 24.75
                    oSheet1.Range(ChrW(ColStart + 1) & RowStart.ToString, ChrW(ColStart + 15) & RowStart.ToString).Font.Size = 10
                    oSheet1.Range(ChrW(ColStart + 1) & RowStart.ToString, ChrW(ColStart + 15) & RowStart.ToString).WrapText = True

                Catch ex As Exception

                End Try

                SlCounter += 1
            Next
            If SlCounter < drOrders.Count Then
                'RowStart += 1
                RowStart += 1
                oSheet1.Range("A" & RowStart.ToString).EntireRow.RowHeight = 22.75
                RowStart += 1
                oSheet1.Range("A" & RowStart.ToString).EntireRow.RowHeight = 0.5
                GoTo NewPage
            End If

            oSheet2.Cells(10 + SlCounter, 1).value = "TOTAL CASES : "
            oSheet2.Cells(10 + SlCounter, 2).value = RouteDetails.TotalItems
            oSheet2.Range("A1").EntireColumn.ColumnWidth = 15
            oSheet2.Range("B1").EntireColumn.ColumnWidth = 42
            'oSheet2.Range("C1").EntireColumn.AutoFit()
            For i = 1 To SlCounter + 11
                oSheet2.Range("A" & i.ToString).EntireRow.AutoFit()
            Next
        Catch ex As Exception
        End Try

    End Sub

End Class
