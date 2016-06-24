Imports System.IO

Public Class clsBOLPrint
    Public oXL As Microsoft.Office.Interop.Excel.Application
    Dim oWB As Microsoft.Office.Interop.Excel.Workbook
    Dim oSheet1 As Microsoft.Office.Interop.Excel.Worksheet
    ' Dim oSheet2 As Microsoft.Office.Interop.Excel.Worksheet
    'Dim objRoute As New cls_tblRoute
    'Dim objRouteOrder As New cls_tblRouteOrders
    Dim objOrder As New cls_tblOrder
    Dim objOrderItems As New cls_tblOrderItems
    Dim objCustomer As New cls_tblCustomer
    Dim ObjProductas As New cls_tblProducts
    Dim objCustomerBOL As New cls_tblCustomer_BOL

    Sub CreateBol(ByVal OrderID As Integer)
  

        Try
            Dim OrderDetails As cls_tblOrder.Fields = objOrder.Selection_One_Row(OrderID)

            Dim SlCounter As Integer = 0


            Dim CustomerDetails As cls_tblCustomer.Fields = Nothing
            Try
                CustomerDetails = objCustomer.Selection_One_Row(OrderDetails.CutomerId)
            Catch ex As Exception
            End Try

            Dim BOLDetails As cls_tblCustomer_BOL.Fields = Nothing
            Dim hasBOL As Boolean = False
            Dim file As String = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.Desktop, "BOL - " & OrderID.ToString & " " & CustomerDetails.CustomerName & ".xlsx")
            Try
                My.Computer.FileSystem.WriteAllBytes(file, My.Resources.BOL, False)
            Catch ex As Exception
            End Try

            oXL = CreateObject("Excel.Application")

            oXL.Visible = True
            oWB = oXL.Workbooks.Open(file)
            oSheet1 = oWB.Worksheets("BOL")

            oSheet1.Range("B14").Value = OrderDetails.OrderDate
            oSheet1.Range("E14").Value = OrderDetails.OrderNo

            Try
                Dim itemsl As Integer = objCustomerBOL.SelectScalar(cls_tblCustomer_BOL.FieldName.ItemSl, "OrderId = " & OrderID.ToString)
                BOLDetails = objCustomerBOL.Selection_One_Row(itemsl)
                hasBOL = True
            Catch ex As Exception
            End Try

            If hasBOL Then
                oSheet1.Range("O14").Value = BOLDetails.DropOffPoint ' CustomerDetails.CustomerName
                oSheet1.Range("O16").Value = BOLDetails.Address
                oSheet1.Range("O18").Value = BOLDetails.City & ", " & BOLDetails.State & ", " & BOLDetails.Zip
                oSheet1.Range("O19").Value = BOLDetails.Contact
                oSheet1.Range("O23").Value = "Deliver to Carrier"
            Else
                oSheet1.Range("O14").Value = CustomerDetails.CustomerName ' CustomerDetails.CustomerName
                oSheet1.Range("O16").Value = CustomerDetails.Address
                oSheet1.Range("O18").Value = CustomerDetails.City & ", " & CustomerDetails.State & ", " & CustomerDetails.Zip
                oSheet1.Range("O19").Value = CustomerDetails.Phone
                oSheet1.Range("O23").Value = "Pick up @ Chino"
            End If

            oSheet1.Range("J14").Value = CustomerDetails.CustomerName
            oSheet1.Range("J16").Value = CustomerDetails.Address
            oSheet1.Range("J18").Value = CustomerDetails.City & ", " & CustomerDetails.State & ", " & CustomerDetails.Zip
            oSheet1.Range("J19").Value = CustomerDetails.Phone

            Dim dtOrderItems As DataTable = Nothing
            Try
                dtOrderItems = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "OrderId=" & OrderDetails.OrderId)
            Catch ex As Exception
            End Try


            Try
                Dim counter As Integer = 0
                For Each drOrderItem As DataRow In dtOrderItems.Rows
                    Try
                        If (drOrderItem("Frozen") + drOrderItem("Fresh")) > 0 And counter <= 5 Then
                            Dim ProductDetails As cls_tblProducts.Fields = ObjProductas.Selection_One_Row(drOrderItem("ProductId"))
                            oSheet1.Range("B" & (32 + counter).ToString).Value = drOrderItem("Frozen") + drOrderItem("Fresh")
                            oSheet1.Range("F" & (32 + counter).ToString).Value = If(ProductDetails.FullName = "", ProductDetails.ProductName, ProductDetails.FullName)
                            oSheet1.Range("P" & (32 + counter).ToString).Value = drOrderItem("Weight")
                            counter += 1
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
End Class
