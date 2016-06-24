Imports System.IO
Imports Word = Microsoft.Office.Interop.Word
Public Class clsPrintBOL_WINWORD


    Dim objOrder As New cls_tblOrder
    Dim objOrderItems As New cls_tblOrderItems
    Dim objCustomer As New cls_tblCustomer

    Dim ObjProductas As New cls_tblProducts
    Dim objCustomerBOL As New cls_tblCustomer_BOL

    Sub CreateBol(ByVal OrderID As Integer)


        Try
            Dim OrderDetails As cls_tblOrder.Fields = objOrder.Selection_One_Row(OrderID)
            Dim CustomerDetails As cls_tblCustomer.Fields = Nothing
            Try
                CustomerDetails = objCustomer.Selection_One_Row(OrderDetails.CutomerId)
            Catch ex As Exception
            End Try
            Dim dtCaseAndLBs As DataTable = Nothing
            Try
                dtCaseAndLBs = objOrderItems.SelectCaseAndLBs(OrderDetails.OrderId)
            Catch ex As Exception
            End Try

            Dim dtOrderItems As DataTable = Nothing
            Try
                dtOrderItems = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "OrderId=" & OrderDetails.OrderId)
            Catch ex As Exception
            End Try

            Dim BOLDetails As cls_tblCustomer_BOL.Fields = Nothing
            Dim hasBOL As Boolean = False


            Try
                Dim itemsl As Integer = OrderDetails.BOLAddressID 'objCustomerBOL.SelectScalar(cls_tblCustomer_BOL.FieldName.ItemSl, "OrderId = " & OrderID.ToString)
                BOLDetails = objCustomerBOL.Selection_One_Row(itemsl)
                hasBOL = True
            Catch ex As Exception
            End Try

            Dim PageNo As Integer = 1
            Dim TotalPage As Integer = Math.Floor((dtOrderItems.Rows.Count / 8) + 1.0)
            Dim file As String = ""
            Dim wordApp As Word.Application = New Word.Application

            wordApp.Visible = True
            Dim aDoc As Word.Document = Nothing
            While PageNo <= TotalPage
                If PageNo = 1 Then
                    file = CustomerDetails.CustomerName & " - BOL - " & OrderDetails.OrderNo.ToString.Replace("/", "_") & ".docx"
                    If MyLocalSettings.FileLocation = "" Then
                        Dim sfd As New SaveFileDialog
                        'sfd.Title ="
                        MsgBox("Select a location(folder) to save the file. Please note that the software will not ask for the location(folder) again. All files will be saved in that location(folder) automatically", MsgBoxStyle.Information, "Info")
                        sfd.Filter = "Word File(*.docx)|*.docx"
                        sfd.FileName = file
                        If sfd.ShowDialog = DialogResult.OK Then
                            'file = sfd.FileName
                            MyLocalSettings.FileLocation = (New IO.FileInfo(sfd.FileName)).DirectoryName
                            SaveLocalSettings()
                        Else
                            Exit Sub
                        End If
                    End If
                    file = My.Computer.FileSystem.CombinePath(MyLocalSettings.FileLocation, file)
                Else
                    file = CustomerDetails.CustomerName & " - BOL - " & OrderDetails.OrderNo.ToString.Replace("/", "_") & " Page-" & PageNo.ToString & ".docx"
                    file = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.Temp, file)
                End If
                Try
                    If IO.File.Exists(file) Then
                        SetAttr(file, FileAttribute.Normal)
                        IO.File.Delete(file)
                    End If
                    My.Computer.FileSystem.WriteAllBytes(file, My.Resources.BOL_DOC, False)
                    ' SetAttr(file, FileAttribute.ReadOnly) '+ FileAttribute.Hidden + FileAttribute.System)
                Catch ex As Exception
                End Try


                'If PageNo = 1 Then
                '    aDoc = wordApp.Documents.Add()
                'End If

                If PageNo = 1 Then
                    ' aDoc = wordApp.Documents.Open(FileName:=file, [ReadOnly]:=False)
                    aDoc = wordApp.Documents.Open(FileName:=file, [ReadOnly]:=False)
                    'wordApp.Selection.EndKey(Unit:=6)
                    'wordApp.Selection.InsertBreak(Type:=Word.WdBreakType.wdPageBreak)
                    'wordApp.Selection.InsertFile(FileName:=file, Range:="", ConfirmConversions:=False, Link:=False, Attachment:=False) ' next time onwards use InsertFile method
                    'Try
                    '    SetAttr(file, FileAttribute.ReadOnly + FileAttribute.Hidden + FileAttribute.System)
                    'Catch ex As Exception
                    'End Try
                Else
                    wordApp.Selection.EndKey(Unit:=6)
                    wordApp.Selection.InsertBreak(Type:=Word.WdBreakType.wdPageBreak)
                    wordApp.Selection.InsertFile(FileName:=file, Range:="", ConfirmConversions:=False, Link:=False, Attachment:=False) ' next time onwards use InsertFile method
                End If

                aDoc.Activate()
              
                FindAndReplace(wordApp, "<PageCount>", PageNo.ToString & " of " & TotalPage.ToString)
                FindAndReplace(wordApp, "<OrderDate>", OrderDetails.OrderDate.ToShortDateString)
                FindAndReplace(wordApp, "<BOL_No>", OrderDetails.OrderNo)
                FindAndReplace(wordApp, "<CustomerName>", CustomerDetails.CustomerName)

                FindAndReplace(wordApp, "<CustomerAddress1>", CustomerDetails.Address & ", " & CustomerDetails.City & ", " & CustomerDetails.State & ", " & CustomerDetails.Zip)
                FindAndReplace(wordApp, "<CustomerAddress2>", IIf(CustomerDetails.Phone.Trim <> "", "Tel : " & CustomerDetails.Phone & " ", "") & _
                                   IIf(CustomerDetails.Fax.Trim <> "", "Fax : " & CustomerDetails.Fax & " ", ""))

                If hasBOL Then
                    FindAndReplace(wordApp, "<CarrierInfo1>", BOLDetails.DropOffPoint)
                    FindAndReplace(wordApp, "<CarrierInfo2>", BOLDetails.Address & ", " & BOLDetails.City & ", " & BOLDetails.State & ", " & BOLDetails.Zip)
                    FindAndReplace(wordApp, "<CarrierInfo3>", IIf(BOLDetails.Phone.Trim <> "", "Tel : " & BOLDetails.Phone & " ", "") & _
                                   IIf(BOLDetails.Fax.Trim <> "", "Fax : " & BOLDetails.Fax & " ", "") & IIf(BOLDetails.Contact.Trim <> "", "Contact : " & BOLDetails.Contact, ""))
                Else
                    FindAndReplace(wordApp, "<CarrierInfo1>", CustomerDetails.CustomerName)
                    FindAndReplace(wordApp, "<CarrierInfo2>", CustomerDetails.Address & ", " & CustomerDetails.City & ", " & CustomerDetails.State & ", " & CustomerDetails.Zip)
                    FindAndReplace(wordApp, "<CarrierInfo3>", IIf(CustomerDetails.Phone.Trim <> "", "Tel : " & CustomerDetails.Phone & " ", "") & _
                                   IIf(CustomerDetails.Fax.Trim <> "", "Fax : " & CustomerDetails.Fax & " ", ""))
                    'FindAndReplace(wordApp, "<CarrierInfo1>", "")
                    'FindAndReplace(wordApp, "<CarrierInfo2>", "")
                    'FindAndReplace(wordApp, "<CarrierInfo3>", "")
                End If

                Dim weight As Integer = 0
                Dim qty As Integer = 0
                For i = ((PageNo - 1) * 8) + 1 To PageNo * 8
                    If i > dtOrderItems.Rows.Count Then

                        FindAndReplace(wordApp, "<qty" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                        FindAndReplace(wordApp, "<unit" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                        FindAndReplace(wordApp, "<descript" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                        FindAndReplace(wordApp, "<nweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                        FindAndReplace(wordApp, "<tweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                        FindAndReplace(wordApp, "<gweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                    Else
                        Try
                            Dim drOrderItem As DataRow = dtOrderItems.Rows(i - 1)
                            If (drOrderItem("Frozen") + drOrderItem("Fresh")) > 0 Then
                                Dim ProductDetails As cls_tblProducts.Fields = ObjProductas.Selection_One_Row(drOrderItem("ProductId"))
                                FindAndReplace(wordApp, "<qty" & (((i - 1) Mod 8) + 1).ToString & ">", drOrderItem("Frozen") + drOrderItem("Fresh"))
                                FindAndReplace(wordApp, "<unit" & (((i - 1) Mod 8) + 1).ToString & ">", ProductDetails.UnitOfMeasure)
                                Dim desc As String = If(ProductDetails.FullName = "", ProductDetails.ProductName, ProductDetails.FullName)
                                Dim StrQTY = IIf(drOrderItem("Fresh") > 0, "FRESH" & IIf(drOrderItem("Frozen") > 0, "-" & "FROZEN", ""), IIf(drOrderItem("Frozen") > 0, "FROZEN", ""))
                                If StrQTY <> "" Then
                                    desc = desc & " (" & StrQTY & ")"
                                End If
                                FindAndReplace(wordApp, "<descript" & (((i - 1) Mod 8) + 1).ToString & ">", desc)
                                FindAndReplace(wordApp, "<nweight" & (((i - 1) Mod 8) + 1).ToString & ">", drOrderItem("Weight"))
                                FindAndReplace(wordApp, "<tweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                                FindAndReplace(wordApp, "<gweight" & (((i - 1) Mod 8) + 1).ToString & ">", drOrderItem("Weight"))
                                qty += drOrderItem("Frozen") + drOrderItem("Fresh")
                                weight += Val(drOrderItem("Weight"))
                            Else
                                FindAndReplace(wordApp, "<qty" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                                FindAndReplace(wordApp, "<unit" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                                FindAndReplace(wordApp, "<descript" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                                FindAndReplace(wordApp, "<nweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                                FindAndReplace(wordApp, "<tweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                                FindAndReplace(wordApp, "<gweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                            End If
                        Catch ex As Exception
                            FindAndReplace(wordApp, "<qty" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                            FindAndReplace(wordApp, "<unit" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                            FindAndReplace(wordApp, "<descript" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                            FindAndReplace(wordApp, "<nweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                            FindAndReplace(wordApp, "<tweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                            FindAndReplace(wordApp, "<gweight" & (((i - 1) Mod 8) + 1).ToString & ">", "")
                        End Try
                    End If
                Next

                FindAndReplace(wordApp, "<qTot>", qty.ToString)
                FindAndReplace(wordApp, "<descrTot>", dtCaseAndLBs.Rows(0).Item(0).ToString())
                PageNo += 1
            End While
            aDoc.Save()
        Catch ex As Exception
        End Try

    End Sub

    Sub FindAndReplace(wordApp As Word.Application, findText As Object, replaceText As Object)
        Dim matchCase As Object = True
        Dim matchWholeWord As Object = True
        Dim matchWildCards As Object = False
        Dim matchSoundsLike As Object = False
        Dim matchAllWordForms As Object = False
        Dim forward As Object = True
        Dim format As Object = False
        Dim matchKashida As Object = False
        Dim matchDiacritics As Object = False
        Dim matchAlefHamza As Object = False
        Dim matchControl As Object = False
        Dim read_only As Object = False
        Dim visible As Object = True
        Dim replace As Object = 2
        Dim wrap As Object = 1
        wordApp.Selection.Find.Execute(findText, _
             matchCase, _
             matchWholeWord, _
             matchWildCards, _
             matchSoundsLike, _
             matchAllWordForms, _
             forward, _
             wrap, _
             format, _
             replaceText, _
             replace, _
             matchKashida, _
             matchDiacritics, _
             matchAlefHamza, _
             matchControl)
    End Sub

End Class
