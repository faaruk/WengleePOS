Public Class cls_tblProducts

    Public Shared tablename As String = "tblProducts"

    Structure Fields
        Dim ProductId As Integer
        Dim ProductCode As String
        Dim ProductName As String
        Dim FullName As String
        Dim Brand As String
        Dim Category As String
        Dim SubCategory As String
        Dim Price As Decimal
        Dim UnitOfMeasure As String
        Dim DateCreated As Date
        Dim DateUpdated As Date
        Dim CreatedBy As Integer
        Dim UpdatedBy As Integer
        Dim Enabled As Boolean
    End Structure

    Enum FieldName
        ProductId
        ProductCode
        ProductName
        FullName
        Brand
        Category
        SubCategory
        Price
        UnitOfMeasure
        DateCreated
        DateUpdated
        CreatedBy
        UpdatedBy
        Enabled
    End Enum
    Private ReadOnly Property tblProducts_insert
        Get
            Return <tblProducts_insert><![CDATA[

INSERT INTO [tblProducts]

           ([ProductId]
           ,[ProductCode]
           ,[ProductName]
           ,[FullName]
           ,[Brand]
           ,[Category]
           ,[SubCategory]
           ,[Price]
           ,[UnitOfMeasure]
           ,[DateCreated]
           ,[DateUpdated]
           ,[CreatedBy]
           ,[UpdatedBy]
           ,[Enabled])

     VALUES

           (@ProductId 
           ,@ProductCode 
           ,@ProductName 
           ,@FullName 
           ,@Brand 
           ,@Category 
           ,@SubCategory 
           ,@Price 
           ,@UnitOfMeasure 
           ,@DateCreated 
           ,@DateUpdated 
           ,@CreatedBy 
           ,@UpdatedBy 
           ,@Enabled )

                    ]]></tblProducts_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblProducts_update
        Get
            Return <tblProducts_update><![CDATA[
UPDATE [tblProducts]
   SET [ProductId] = @ProductId 
      ,[ProductCode] = @ProductCode 
      ,[ProductName] = @ProductName 
      ,[FullName] = @FullName 
      ,[Brand] = @Brand 
      ,[Category] = @Category 
      ,[SubCategory] = @SubCategory 
      ,[Price] = @Price 
      ,[UnitOfMeasure] = @UnitOfMeasure 
      ,[DateCreated] = @DateCreated 
      ,[DateUpdated] = @DateUpdated 
      ,[CreatedBy] = @CreatedBy 
      ,[UpdatedBy] = @UpdatedBy 
      ,[Enabled] = @Enabled 
WHERE
[ProductId]=@ProductId


                    ]]></tblProducts_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblProducts_Delete_By_ProductId
        Get
            Return <tblProducts_Delete><![CDATA[

DELETE FROM
[tblProducts] 
WHERE
[ProductId]=@ProductId
                    ]]></tblProducts_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblProducts_MAXID
        Get
            Return <tblProducts_MAXID><![CDATA[

SELECT MAX([ProductId]) FROM [tblProducts] WHERE 1=1
                    ]]></tblProducts_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblProducts_Select
        Get
            Return <tblProducts_Select><![CDATA[

SELECT [ProductId]
      ,[ProductCode]
      ,[ProductName]
      ,[FullName]
      ,[Brand]
      ,[Category]
      ,[SubCategory]
      ,[Price]
      ,[UnitOfMeasure]
      ,[DateCreated]
      ,[DateUpdated]
      ,[CreatedBy]
      ,[UpdatedBy]
      ,[Enabled]
      ,[FZStatus]
  FROM [tblProducts]

WHERE 1=1
                    ]]></tblProducts_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblProducts_MAXID, _conn)
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
                    ByRef ProductCode As String, _
                    ByRef ProductName As String, _
                    ByRef FullName As String, _
                    ByRef Brand As String, _
                    ByRef Category As String, _
                    ByRef SubCategory As String, _
                    ByRef Price As Decimal, _
                    ByRef UnitOfMeasure As String, _
                    ByRef DateCreated As Date, _
                    ByRef DateUpdated As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedBy As Integer, _
                    ByRef Enabled As Boolean, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ProductId As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblProducts_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ProductId", ProductId)
            .AddWithValue("@ProductCode", ProductCode)
            .AddWithValue("@ProductName", ProductName)
            .AddWithValue("@FullName", FullName)
            .AddWithValue("@Brand", Brand)
            .AddWithValue("@Category", Category)
            .AddWithValue("@SubCategory", SubCategory)
            .AddWithValue("@Price", Price)
            .AddWithValue("@UnitOfMeasure", UnitOfMeasure)
            .AddWithValue("@DateCreated", DateCreated)
            .AddWithValue("@DateUpdated", DateUpdated)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Enabled", Enabled)
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
        Return ProductId
    End Function

    Function Update(ByVal ProductId As Integer, _
                    ByRef ProductCode As String, _
                    ByRef ProductName As String, _
                    ByRef FullName As String, _
                    ByRef Brand As String, _
                    ByRef Category As String, _
                    ByRef SubCategory As String, _
                    ByRef Price As Decimal, _
                    ByRef UnitOfMeasure As String, _
                    ByRef DateCreated As Date, _
                    ByRef DateUpdated As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedBy As Integer, _
                    ByRef Enabled As Boolean, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblProducts_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ProductName", ProductName)
            .AddWithValue("@FullName", FullName)
            .AddWithValue("@ProductCode", ProductCode)
            .AddWithValue("@Brand", Brand)
            .AddWithValue("@Category", Category)
            .AddWithValue("@SubCategory", SubCategory)
            .AddWithValue("@Price", Price)
            .AddWithValue("@UnitOfMeasure", UnitOfMeasure)
            .AddWithValue("@DateCreated", DateCreated)
            .AddWithValue("@DateUpdated", DateUpdated)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Enabled", Enabled)
            .AddWithValue("@ProductId", ProductId)
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

        Return ProductId
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

        Dim comUpdate As New SqlCommand("Update [tblProducts] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_ProductId(ByRef ProductId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblProducts_Delete_By_ProductId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ProductId", ProductId)
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
        Return ProductId
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
                comSelection.CommandText = tblProducts_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
    Function Selection_One_Row(ByVal ProductId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblProducts_Select & " AND [ProductId]=@ProductId"
        comSelection.Parameters.AddWithValue("@ProductId", ProductId)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .ProductId = dt.Rows(0).Item("ProductId")
                .ProductCode = dt.Rows(0).Item("ProductCode")
                .ProductName = dt.Rows(0).Item("ProductName")
                .FullName = IIf(dt.Rows(0).Item("FullName") Is DBNull.Value, "", dt.Rows(0).Item("FullName"))
                .Brand = dt.Rows(0).Item("Brand")
                .Category = dt.Rows(0).Item("Category")
                .SubCategory = dt.Rows(0).Item("SubCategory")
                .Price = dt.Rows(0).Item("Price")
                .UnitOfMeasure = dt.Rows(0).Item("UnitOfMeasure")
                .DateCreated = dt.Rows(0).Item("DateCreated")
                .DateUpdated = dt.Rows(0).Item("DateUpdated")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .Enabled = dt.Rows(0).Item("Enabled")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & " from [tblProducts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT [" & _fieldName.ToString & "] FROM [tblProducts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
