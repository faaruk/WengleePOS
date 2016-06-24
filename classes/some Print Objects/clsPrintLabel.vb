Imports System.Drawing.Printing

Public Class clsPrintLabel
    Inherits PrintDocument

    Public NoOfLabel As Integer = 1
    Public PrintItems As List(Of PrintItem)


    Dim w As Integer = 200
    Dim h As Integer = 100 - 4

    Dim SlCounter As Integer = 1
    Dim topadd As Integer = 2


    Dim objOrderItems As New cls_tblOrderItems
    Dim objCustomer As New cls_tblCustomer
    Dim objOrder As New cls_tblOrder
    Dim objProducts As New cls_tblProducts

    Structure PrintItem

        Dim labelText As String
        Dim subItem As String
        Dim subItem2 As String

        Sub New(_labelText As String, _subItem As String, _subItem2 As String)
            labelText = _labelText
            subItem = _subItem
            subItem2 = _subItem2
        End Sub

    End Structure

    Sub PrintOrder(OrderIds As List(Of Integer))

        Dim ps As New PrintDialog
        ps.PrintToFile = False
        ps.AllowSelection = False
        ps.AllowSomePages = False
        ps.ShowNetwork = False
        ps.UseEXDialog = True

        If ps.ShowDialog = Windows.Forms.DialogResult.OK Then

            PrinterSettings = ps.PrinterSettings
            ' Dim ll As New List(Of String)
            Dim ll As New List(Of PrintItem)
            ' Dim ll2 As New List(Of String)
            NoOfLabel = 0
            For Each OrderId As Integer In OrderIds
                SetData(ll, OrderId)
            Next
            PrintItems = ll
            Print()

        End If
    End Sub
    Sub SetData(ll As List(Of PrintItem), ByVal OrderId As Integer)
        Dim LabelText As String = ""
        Try
            Dim order As cls_tblOrder.Fields = objOrder.Selection_One_Row(OrderId)
            LabelText = objCustomer.Selection_One_Row(order.CutomerId).CustomerName
        Catch ex As Exception
        End Try


        Try

            Dim orderItems As DataTable = objOrderItems.Selection(cls_tblOrderItems.SelectionType.All, "OrderId=" & OrderId.ToString & " Order by sl")
            For Each drProduct As DataRow In orderItems.Rows
                Dim unit As String = objProducts.SelectScalar(cls_tblProducts.FieldName.UnitOfMeasure, "ProductID=" & drProduct(cls_tblOrderItems.FieldName.ProductId.ToString).ToString)
                Dim pn As String = objProducts.SelectScalar(cls_tblProducts.FieldName.ProductName, "ProductID=" & drProduct(cls_tblOrderItems.FieldName.ProductId.ToString).ToString)
                If unit.Trim.ToUpper = "Case(s)".ToUpper Then
                    For i = 1 To drProduct(cls_tblOrderItems.FieldName.Qty.ToString)
                        ll.Add(New PrintItem(LabelText, pn, "1 " & unit))
                        NoOfLabel += 1
                    Next
                Else
                    ll.Add(New PrintItem(LabelText, pn, drProduct(cls_tblOrderItems.FieldName.Qty.ToString).ToString & " " & unit))

                    NoOfLabel += 1
                End If

            Next

        Catch ex As Exception
        End Try
    End Sub
    Private Sub clsPrintLabel_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Me.PrintPage

        While SlCounter <= NoOfLabel
            Dim PI As PrintItem = PrintItems(SlCounter - 1)
            Dim heightX As Integer = 0
            Try
                heightX = e.Graphics.MeasureString(PI.labelText, New Font("Arial", 18, FontStyle.Bold), w - 2).Height
                If heightX < h / 3 Then
                    heightX = h / 3
                Else
                    'heightX = heightX * 0.9
                End If
                If heightX > h - 30 Then
                    heightX = h - 30
                    e.Graphics.DrawString(PI.labelText, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Rectangle(New Point(0, topadd), New Size(w, heightX)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Else
                    e.Graphics.DrawString(PI.labelText, New Font("Arial", 18, FontStyle.Bold), Brushes.Black, New Rectangle(New Point(0, topadd), New Size(w, heightX)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End If

            Catch ex As Exception
            End Try
            Try
                If PrintItems.Count >= SlCounter Then
                    e.Graphics.DrawString(PI.subItem & vbNewLine & PI.subItem2, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New Rectangle(New Point(0, topadd + heightX), New Size(w, h - heightX)), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End If
            Catch ex As Exception
            End Try
            e.Graphics.DrawRectangle(Pens.LightGray, New Rectangle(New Point(0, topadd), New Size(w, h)))
            topadd += h + 4
            SlCounter += 1
            If topadd + h > e.PageBounds.Height And SlCounter <= NoOfLabel Then
                topadd = 2
                e.HasMorePages = True
                Exit Sub
            End If
            e.HasMorePages = False

        End While

    End Sub
End Class
