'Class Version : 1.0.0.2
'Created Dated : 18/11/2014
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO



Public Class cls_tblInvoiceStatus
Public Shared tablename As String = "tblInvoiceStatus"


Structure Fields


    Dim InvoiceNumber_ as string
    Dim CustomerID_ as string
    Dim Status_ as string

End Structure

Enum FieldName

    [InvoiceNumber]
    [CustomerID]
    [Status]

End Enum


Private ReadOnly Property tblInvoiceStatus_insert
Get
Return <tblInvoiceStatus_insert><![CDATA[
  INSERT INTO [tblInvoiceStatus]
  (
      [InvoiceNumber],
      [CustomerID],
      [Status]
  )
  VALUES
  (
      @InvoiceNumber_,
      @CustomerID_,
      @Status_
  )
]]></tblInvoiceStatus_insert>.Value
End Get
End Property


Private ReadOnly Property tblInvoiceStatus_update
Get
Return <tblInvoiceStatus_update><![CDATA[
UPDATE [tblInvoiceStatus]
Set 
    [Status]=@Status_
 WHERE [InvoiceNumber]=@InvoiceNumber_ AND [CustomerID]=@CustomerID_
]]></tblInvoiceStatus_update>.Value
End Get
End Property


Public ReadOnly Property tblInvoiceStatus_select
Get
Return <tblInvoiceStatus_select><![CDATA[
SELECT 
      [InvoiceNumber],
      [CustomerID],
      [Status]
FROM [tblInvoiceStatus]
    WHERE 1=1
]]></tblInvoiceStatus_select>.Value
End Get
End Property


Private ReadOnly Property tblInvoiceStatus_Delete_By_RowID
Get
Return <tblInvoiceStatus_Delete_By_RowID><![CDATA[
DELETE FROM [tblInvoiceStatus] WHERE [InvoiceNumber]=@InvoiceNumber_ AND [CustomerID]=@CustomerID_
]]></tblInvoiceStatus_Delete_By_RowID>.Value
End Get
End Property


Private ReadOnly Property tblInvoiceStatus_Delete_By_SELECT
Get
Return <tblInvoiceStatus_Delete_By_SELECT><![CDATA[
DELETE FROM [tblInvoiceStatus] WHERE 1=1
]]></tblInvoiceStatus_Delete_By_SELECT>.Value
End Get
End Property


    Function Insert( _
    ByVal InvoiceNumber_ as string , _
    ByVal CustomerID_ as string , _
    ByVal Status_ as string , _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing


        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblInvoiceStatus_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)
            .AddWithValue("@CustomerID_", CustomerID_)
            .AddWithValue("@Status_", Status_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return 0
    End Function



    Function Update(
    ByVal Status_ as string , _
    ByVal InvoiceNumber_ as string , _
    ByVal CustomerID_ as string , _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblInvoiceStatus_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)
            .AddWithValue("@CustomerID_", CustomerID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return 0
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object, _
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName
            
            Case FieldName.InvoiceNumber
                fn="InvoiceNumber"
            Case FieldName.CustomerID
                fn="CustomerID"
            Case FieldName.Status
                fn="Status"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblInvoiceStatus] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblInvoiceStatus_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID( _
     ByVal InvoiceNumber_ As String, _
     ByVal CustomerID_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblInvoiceStatus_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)
            .AddWithValue("@CustomerID_", CustomerID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return 0
    End Function



    Function Selection_One_Row( _
     ByVal InvoiceNumber_ As String, _
     ByVal CustomerID_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblInvoiceStatus_Select & "  AND [InvoiceNumber]=@InvoiceNumber_ AND [CustomerID]=@CustomerID_"

        With comSelection.Parameters
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)
            .AddWithValue("@CustomerID_", CustomerID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                .InvoiceNumber_ = dt.Rows(0).Item("InvoiceNumber")
                .CustomerID_ = dt.Rows(0).Item("CustomerID")
                .Status_ = dt.Rows(0).Item("Status")
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName, _
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InvoiceNumber
                fn = "InvoiceNumber"
            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblInvoiceStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName, _
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InvoiceNumber
                fn = "InvoiceNumber"
            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblInvoiceStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function




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
                comSelection.CommandText = tblInvoiceStatus_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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



End Class