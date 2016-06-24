'Class Version : 1.0.0.2
'Created Dated : 13/03/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_t_tblStock
    Inherits Database_Table_code_class_tblStock

    Enum SelectionType
        All = 0
    End Enum

    Function Selection(Optional ByVal _selection_type As SelectionType = SelectionType.All, Optional ByVal _SelectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable
        Dim dt As New DataTable
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comSelection As New SqlCommand("", _conn)
        If Not _transac Is Nothing Then
            comSelection.Transaction = _transac
        End If

        Select Case _selection_type
            Case SelectionType.All
                comSelection.CommandText = tblStock_select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

        End Select

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelection.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comSelection.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return dt
    End Function

    Structure Stocks
        Dim ProductID As Integer
        Dim dateTill As DateTime
        Dim froZenQty As Integer
        Dim freshQty As Integer
        Dim totalQty As Integer
    End Structure
    Function StockTill(ProductID As Integer, dateTill As DateTime) As Stocks
        Dim ret As New Stocks
        Try
            Dim QuerySTR As String = <tblStock_Select><![CDATA[
select  SUM (case when Stocktype = 'IN' then isnull(Qty,0) else -1 * isnull(Qty,0) end ) as rt,
        SUM (case when Stocktype = 'IN' then isnull(Fresh,0) else -1 * isnull(Fresh,0) end ) as rtFs,
        SUM (case when Stocktype = 'IN' then isnull(Frozen,0) else -1 * isnull(Frozen,0) end ) as rtFz from 
            tblStock
        where ProductId = @ProductId and TransactionDate<=@StockTill

       ]]></tblStock_Select>.Value
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@StockTill", dateTill))
            paramList.Add(New SqlParameter("@ProductID", ProductID))
            Dim dt As DataTable = ExecuteAdapter(QuerySTR, paramList)
            ret.ProductID = ProductID
            ret.dateTill = dateTill
            ret.totalQty = dt.Rows(0).Item("rt")
            ret.freshQty = dt.Rows(0).Item("rtFs")
            ret.froZenQty = dt.Rows(0).Item("rtFz")
        Catch ex As Exception
        End Try
        Return ret

    End Function



End Class