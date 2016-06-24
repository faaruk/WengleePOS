Public Class cls_tblCustomer_BOL
    Public Shared tablename As String = "tblCustomer_BOL"
    Structure Fields
        Dim ItemSl As Integer
        Dim CustomerId As Integer
        Dim DropOffPoint As String
        Dim Address As String
        Dim City As String
        Dim State As String
        Dim Zip As String
        Dim Contact As String
        Dim OrderID As Integer
        Dim RouteCity As String
        Dim Phone As String
        Dim Fax As String
        Dim Longt As String
        Dim Latt As String 
        Dim Receiving_CutOff As String
    End Structure
    Enum FieldName
        ItemSl
        CustomerId
        DropOffPoint
        Address
        City
        State
        Zip
        Contact
        OrderID
        RouteCity
        Phone
        Fax
        Longt
        Latt 
        Receiving_CutOff
    End Enum
    Private ReadOnly Property tblCustomer_BOL_insert
        Get
            Return <tblCustomer_BOL_insert><![CDATA[
INSERT INTO [tblCustomer_BOL]
           ([ItemSl]
           ,[CustomerId]
           ,[DropOffPoint]
           ,[Address]
           ,[City]
           ,[State]
           ,[Zip]
           ,[Contact]
           ,[OrderID]
           ,[RouteCity]
           ,[Phone]
           ,[Fax]
         ,[Longt]
         ,[Latt] 
         ,[Receiving_CutOff])
     VALUES
           (@ItemSl 
           ,@CustomerId 
           ,@DropOffPoint 
           ,@Address 
           ,@City 
           ,@State 
           ,@Zip 
           ,@Contact 
           ,@OrderID 
           ,@RouteCity 
           ,@Phone 
           ,@Fax
        ,@Longt
        ,@Latt 
        ,@Receiving_CutOff)
                    ]]></tblCustomer_BOL_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_BOL_update
        Get
            Return <tblCustomer_BOL_update><![CDATA[
UPDATE [tblCustomer_BOL]
   SET [CustomerId] = @CustomerId 
      ,[DropOffPoint] = @DropOffPoint 
      ,[Address] = @Address 
      ,[City] = @City 
      ,[State] = @State 
      ,[Zip] = @Zip 
      ,[Contact] = @Contact 
      ,[OrderID] = @OrderID 
      ,[RouteCity] = @RouteCity 
      ,[Phone] = @Phone 
      ,[Fax] = @Fax 
         ,[Longt]=@Longt
         ,[Latt]=@Latt 
         ,[Receiving_CutOff]=@Receiving_CutOff
WHERE
[ItemSl]=@ItemSl
                    ]]></tblCustomer_BOL_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblCustomer_BOL_Delete_By_ItemSl
        Get
            Return <tblCustomer_BOL_Delete><![CDATA[

DELETE FROM
[tblCustomer_BOL] 
WHERE
[ItemSl]=@ItemSl
                    ]]></tblCustomer_BOL_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblCustomer_BOL_Delete_By_SELECT
        Get
            Return <tblCustomer_BOL_Delete><![CDATA[

DELETE FROM
[tblCustomer_BOL] 
WHERE
1=1
                    ]]></tblCustomer_BOL_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_BOL_MAXID
        Get
            Return <tblCustomer_BOL_MAXID><![CDATA[

SELECT MAX([ItemSl]) FROM [tblCustomer_BOL] WHERE 1=1
                    ]]></tblCustomer_BOL_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_BOL_Select
        Get
            Return <tblCustomer_BOL_Select><![CDATA[


SELECT [ItemSl]
      ,[CustomerId]
      ,[DropOffPoint]
      ,[Address]
      ,[City]
      ,[State]
      ,[Zip]
      ,[Contact]
      ,[OrderID]
      ,[RouteCity]
      ,[Phone]
      ,[Fax]
         ,[Longt]
         ,[Latt] 
         ,[Receiving_CutOff]
 FROM [tblCustomer_BOL] 

WHERE 1=1
                    ]]></tblCustomer_BOL_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_BOL_Select_ddl
        Get
            Return <tblCustomer_BOL_Select><![CDATA[


SELECT [ItemSl] 
      ,[DropOffPoint] 
 FROM [tblCustomer_BOL] 

WHERE 1=1
                    ]]></tblCustomer_BOL_Select>.Value
        End Get
    End Property
    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblCustomer_BOL_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function


    Function Insert( _
        ByVal CustomerId As Integer, _
        ByVal DropOffPoint As String, _
        ByVal Address As String, _
        ByVal City As String, _
        ByVal State As String, _
        ByVal Zip As String, _
        ByVal Contact As String, _
        ByVal OrderID As Integer, _
        ByVal RouteCity As String, _
        ByVal Phone As String, _
        ByVal Fax As String, _
         ByRef Longt As String, _
          ByRef Latt As String, _ 
          ByRef Receiving_CutOff As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblCustomer_BOL_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl", ItemSl)
            .AddWithValue("@CustomerId", CustomerId)
            .AddWithValue("@DropOffPoint", DropOffPoint)
            .AddWithValue("@Address", Address)
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Contact", Contact)
            .AddWithValue("@OrderID", OrderID)
            .AddWithValue("@RouteCity", RouteCity)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Fax", Fax)
            .AddWithValue("@Longt", Longt)
            .AddWithValue("@Latt", Latt) 
            .AddWithValue("@Receiving_CutOff", Receiving_CutOff)
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
        Return ItemSl
    End Function

    Function Update(ByVal ItemSl As Integer, _
        ByVal CustomerId As Integer, _
        ByVal DropOffPoint As String, _
        ByVal Address As String, _
        ByVal City As String, _
        ByVal State As String, _
        ByVal Zip As String, _
        ByVal Contact As String, _
        ByVal OrderID As Integer, _
        ByVal RouteCity As String, _
        ByVal Phone As String, _
        ByVal Fax As String, _
         ByRef Longt As String, _
          ByRef Latt As String, _ 
          ByRef Receiving_CutOff As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblCustomer_BOL_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@CustomerId", CustomerId)
            .AddWithValue("@DropOffPoint", DropOffPoint)
            .AddWithValue("@Address", Address)
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Contact", Contact)
            .AddWithValue("@OrderID", OrderID)
            .AddWithValue("@RouteCity", RouteCity)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Fax", Fax)
            .AddWithValue("@Longt", Longt)
            .AddWithValue("@Latt", Latt)
            .AddWithValue("@Receiving_CutOff", Receiving_CutOff)
            .AddWithValue("@ItemSl", ItemSl)
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

        Return ItemSl
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

        Dim comUpdate As New SqlCommand("Update [tblCustomer_BOL] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_ItemSl(ByRef ItemSl As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCustomer_BOL_Delete_By_ItemSl, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl", ItemSl)
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
        Return ItemSl
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

        Dim comDelete As New SqlCommand(tblCustomer_BOL_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Deleted")
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
    Enum SelectionType
        All = 0
        DDL = 1
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
                comSelection.CommandText = tblCustomer_BOL_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.DDL
                comSelection.CommandText = tblCustomer_BOL_Select_ddl & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
                Throw New Exception("No Records Found")
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
    Function Selection_One_Row(ByVal ItemSl As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblCustomer_BOL_Select & " AND [ItemSl]=@ItemSl"
        comSelection.Parameters.AddWithValue("@ItemSl", ItemSl)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .ItemSl = dt.Rows(0).Item("ItemSl")
                .CustomerId = dt.Rows(0).Item("CustomerId")
                .DropOffPoint = dt.Rows(0).Item("DropOffPoint")
                .Address = dt.Rows(0).Item("Address")
                .City = dt.Rows(0).Item("City")
                .State = dt.Rows(0).Item("State")
                .Zip = dt.Rows(0).Item("Zip")
                .Contact = dt.Rows(0).Item("Contact")
                .OrderID = dt.Rows(0).Item("OrderID")
                .RouteCity = dt.Rows(0).Item("RouteCity")
                .Phone = dt.Rows(0).Item("Phone")
                .Fax = dt.Rows(0).Item("Fax")
                .Longt = dt.Rows(0).Item("Longt")
                .Latt = dt.Rows(0).Item("Latt") 
                .Receiving_CutOff = dt.Rows(0).Item("Receiving_CutOff")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & "  from [tblCustomer_BOL] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & "  from [tblCustomer_BOL] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                Throw New Exception("No Records Found")
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
End Class
