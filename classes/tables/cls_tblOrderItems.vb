Public Class cls_tblOrderItems

    Public Shared tablename As String = "tblOrderItems"

    Structure Fields
        Dim ItemId As Integer
        Dim OrderId As Integer
        Dim Sl As Integer
        Dim ProductId As Integer
        Dim Qty As Integer
        Dim Price As Decimal
        Dim Discount As Decimal
        Dim Extra As Decimal
        Dim Weight As String
        Dim SubTotal As Decimal
        Dim Fresh As Integer
        Dim Frozen As Integer
        Dim Notes As String
    End Structure

    Enum FieldName
        ItemId
        OrderId
        Sl
        ProductId
        Qty
        Price
        Discount
        Extra
        Weight
        SubTotal
        Fresh
        Frozen
        Notes
    End Enum

    Private ReadOnly Property tblOrderItems_insert
        Get
            Return <tblOrderItems_insert><![CDATA[
INSERT INTO [tblOrderItems]
           ([ItemId]
           ,[OrderId]
           ,[Sl]
           ,[ProductId]
           ,[Qty]
           ,[Price]
           ,[Discount]
           ,[Extra]
           ,[Weight]
           ,[SubTotal]
           ,[Fresh]
           ,[Frozen]
           ,[Notes])
     VALUES
           (@ItemId 
           ,@OrderId 
           ,@Sl 
           ,@ProductId 
           ,@Qty 
           ,@Price 
           ,@Discount 
           ,@Extra 
           ,@Weight 
           ,@SubTotal 
           ,@Fresh
           ,@Frozen 
           ,@Notes)
                    ]]></tblOrderItems_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderItems_update
        Get
            Return <tblOrderItems_update><![CDATA[
UPDATE [tblOrderItems]
   SET [OrderId] = @OrderId 
      ,[Sl] = @Sl 
      ,[ProductId] = @ProductId 
      ,[Qty] = @Qty 
      ,[Price] = @Price 
      ,[Discount] = @Discount 
      ,[Extra] = @Extra 
      ,[Weight] = @Weight 
      ,[SubTotal] = @SubTotal 
      ,[Fresh] = @Fresh 
      ,[Frozen] = @Frozen 
      ,[Notes] = @Notes 
WHERE
[ItemId]=@ItemId


                    ]]></tblOrderItems_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblOrderItems_Delete_By_ItemId
        Get
            Return <tblOrderItems_Delete><![CDATA[

DELETE FROM
[tblOrderItems] 
WHERE
[ItemId]=@ItemId
                    ]]></tblOrderItems_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblOrderItems_Delete_By_SELECT
        Get
            Return <tblOrderItems_Delete_By_SELECT><![CDATA[

DELETE FROM
[tblOrderItems] 
WHERE
1=1
                    ]]></tblOrderItems_Delete_By_SELECT>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderItems_Delete_By_OrderId
        Get
            Return <tblOrderItems_Delete><![CDATA[

DELETE FROM
[tblOrderItems] 
WHERE
[OrderId]=@OrderId
                    ]]></tblOrderItems_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderItems_MAXID
        Get
            Return <tblOrderItems_MAXID><![CDATA[

SELECT MAX([ItemId]) FROM [tblOrderItems] WHERE 1=1
                    ]]></tblOrderItems_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderItems_Select
        Get
            Return <tblOrderItems_Select><![CDATA[

SELECT [ItemId]
      ,[OrderId]
      ,[Sl]
      ,[ProductId]
      ,[Qty]
      ,[Price]
      ,[Discount]
      ,[Extra]
      ,[Weight]
      ,[SubTotal]
      ,[Fresh]
      ,[Frozen]
      ,[Notes]
  FROM [tblOrderItems]

WHERE 1=1
                    ]]></tblOrderItems_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderItems_Select_UNIT_WISE_TOTAL
        Get
            Return <tblOrderItems_Select><![CDATA[

SELECT  sum (a.Fresh) as 'Fresh' ,sum (a.Frozen) as  'Frozen',sum (a.Fresh) + sum (a.Frozen) as [Total],b. UnitOfMeasure as [Unit]
  FROM [tblOrderItems] a
  left outer join [tblProducts] b
    on a.ProductId = b.ProductId 

WHERE 1=1
                    ]]></tblOrderItems_Select>.Value
        End Get
    End Property

    Shared ReadOnly Property tblOrderItems_Select_PickedQuantities
        Get
            Return <tblOrderItems_Select><![CDATA[
--SELECT b.ProductId,b.ProductName,b.Category ,sum (a.Fresh) as 'Fresh' ,sum (a.Frozen) as  'Frozen',sum (a.Fresh) + sum (a.Frozen) as [Total],b. UnitOfMeasure as [Unit],'' as [ ] 
--  FROM [tblOrderItems] a
--  left outer join [tblProducts] b
--    on a.ProductId = b.ProductId 
--    where a.OrderId in (select OrderId from tblOrder where OrderDate between @d1 and @d2 )
--    group by b.ProductId,b.ProductName,b.Category ,b. UnitOfMeasure 
    
    
    
    SELECT b.ProductId,b.ProductName,b.Category ,sum (a.Fresh) as 'Fresh' ,sum (a.Frozen) as  'Frozen',sum (a.Fresh) + sum (a.Frozen) as [Total],b. UnitOfMeasure as [Unit],'' as [ ] 
    ,convert(varchar,ISNULL(-d.Fresh,0)) + ',' + convert(varchar,ISNULL(-d.Frozen,0)) as [Future Orders]
  FROM tblStock a
  left outer join [tblProducts] b
    on a.ProductId = b.ProductId 
    left outer join
		    (select sum( case when stocktype='IN' then  qty*0 else -1 * qty end) as qty,
		    sum( case when stocktype='IN' then  Fresh*0 else -1 * Fresh end) as Fresh,
		    sum( case when stocktype='IN' then Frozen*0 else -1 * Frozen end) as Frozen, 
		    productid from tblStock Where TransactionDate>getdate() group by ProductId ) d 
	    on d.ProductId=a.ProductId
        --where a.OrderId in (select OrderId from tblOrder where OrderDate between @d1 and @d2) #####
          where a.TransactionDate between @d1 and @d2 #####
    group by b.ProductId,b.ProductName,b.Category ,b. UnitOfMeasure, d.Fresh, d.Frozen  
                    ]]></tblOrderItems_Select>.Value
        End Get

    End Property
    Shared ReadOnly Property tblOrderItems_Select_PickedQuantities_total
        Get
            Return <tblOrderItems_Select><![CDATA[

--SELECT sum (a.Fresh) as 'Fresh' ,sum (a.Frozen) as  'Frozen',sum (a.Fresh) + sum (a.Frozen) as [Total],b. UnitOfMeasure as [Unit],'' as [ ] 
 -- FROM [tblOrderItems] a
  --left outer join [tblProducts] b
    --on a.ProductId = b.ProductId 
    --where a.OrderId in (select OrderId from tblOrder where OrderDate between @d1 and @d2) #####
    --where a.TransactionDate between @d1 and @d2 #####
    --group by b. UnitOfMeasure 





                           SELECT sum (a.Fresh) as 'Fresh' ,sum (a.Frozen) as  'Frozen',sum (a.Fresh) + sum (a.Frozen) as [Total],b. UnitOfMeasure as [Unit],'' as [ ] 
  FROM tblStock a
  left outer join [tblProducts] b
    on a.ProductId = b.ProductId 
        --where a.OrderId in (select OrderId from tblOrder where OrderDate between @d1 and @d2) #####
          where a.TransactionDate between @d1 and @d2 #####
    group by  b. UnitOfMeasure 
                    ]]></tblOrderItems_Select>.Value
        End Get

    End Property
    Shared ReadOnly Property tblOrderItems_Select_PickedQuantities_total_for_Calender
        Get
            Return <tblOrderItems_Select><![CDATA[

SELECT sum (a.Fresh) as 'Fresh' ,sum (a.Frozen) as  'Frozen',sum (a.Fresh) + sum (a.Frozen) as [Total],b. UnitOfMeasure as [Unit],'' as [ ] 
  FROM [tblOrderItems] a
  left outer join [tblProducts] b on a.ProductId = b.ProductId 
LEFT OUTER JOIN tblOrder c on a.[OrderId] = c.OrderId
LEFT OUTER JOIN (select * from tblCustomer_BOL) f on c.[BOLAddressID] = f.ItemSl
    where a.OrderId in (select OrderId from tblOrder where OrderDate between @d1 and @d2)
    
                    ]]></tblOrderItems_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblOrderItems_MAXID, _conn)
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
                    ByRef OrderId As Integer, _
                    ByRef Sl As Integer, _
                    ByRef ProductId As Integer, _
                    ByRef Qty As Integer, _
                    ByRef Price As Decimal, _
                    ByRef Discount As Decimal, _
                    ByRef Extra As Decimal, _
                    ByRef Weight As String, _
                    ByRef SubTotal As Decimal, _
                    ByRef Fresh As Integer, _
                    ByRef Frozen As Integer, _
                    ByRef Notes As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblOrderItems_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemId", ItemId)
            .AddWithValue("@OrderId", OrderId)
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@ProductId", ProductId)
            .AddWithValue("@Qty", Qty)
            .AddWithValue("@Price", Price)
            .AddWithValue("@Discount", Discount)
            .AddWithValue("@Extra", Extra)
            .AddWithValue("@Weight", Weight)
            .AddWithValue("@SubTotal", SubTotal)
            .AddWithValue("@Fresh", Fresh)
            .AddWithValue("@Frozen", Frozen)
            .AddWithValue("@Notes", Notes)
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
        Return ItemId
    End Function

    Function Update(ByVal ItemId As Integer, _
                   ByRef OrderId As Integer, _
                    ByRef Sl As Integer, _
                    ByRef ProductId As Integer, _
                    ByRef Qty As Integer, _
                    ByRef Price As Decimal, _
                    ByRef Discount As Decimal, _
                    ByRef Extra As Decimal, _
                    ByRef Weight As String, _
                    ByRef SubTotal As Decimal, _
                    ByRef Fresh As Integer, _
                    ByRef Frozen As Integer, _
                    ByRef Notes As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblOrderItems_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@OrderId", OrderId)
            .AddWithValue("@Sl", Sl)
            .AddWithValue("@ProductId", ProductId)
            .AddWithValue("@Qty", Qty)
            .AddWithValue("@Price", Price)
            .AddWithValue("@Discount", Discount)
            .AddWithValue("@Extra", Extra)
            .AddWithValue("@Weight", Weight)
            .AddWithValue("@SubTotal", SubTotal)
            .AddWithValue("@Fresh", Fresh)
            .AddWithValue("@Frozen", Frozen)
            .AddWithValue("@Notes", Notes)
            .AddWithValue("@ItemId", ItemId)
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

        Return ItemId
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

        Dim comUpdate As New SqlCommand("Update [tblOrderItems] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_ItemId(ByRef ItemId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrderItems_Delete_By_ItemId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId", ItemId)
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
        Return ItemId
    End Function
    Function Delete_By_SELECT(ByRef _selectstring As String, Optional ByVal _params As List(Of SqlParameter) = Nothing, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrderItems_Delete_By_SELECT & IIf(_selectstring <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectstring, " AND " & _selectstring), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = 0
        Try
            obj = comDelete.ExecuteNonQuery
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
    Function Delete_By_OrderId(ByRef OrderId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrderItems_Delete_By_OrderId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@OrderId", OrderId)
        End With
        Dim obj As Object = 0
        Try
            obj = comDelete.ExecuteNonQuery
            'If obj = 0 Then
            '    Throw New Exception("No Records Deleted")
            'End If
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
        UNIT_WISE_TOTAL = 1
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
                comSelection.CommandText = tblOrderItems_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.UNIT_WISE_TOTAL
                comSelection.CommandText = tblOrderItems_Select_UNIT_WISE_TOTAL & IIf(_SelectString <> "", IIf(_SelectString.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

        End Select

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            'If dt.Rows.Count = 0 Then
            '    Throw New Exception("No Records Found")
            'End If
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
    Function Selection_One_Row(ByVal ItemId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblOrderItems_Select & " AND [ItemId]=@ItemId"
        comSelection.Parameters.AddWithValue("@ItemId", ItemId)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .ItemId = dt.Rows(0).Item("ItemId")
                .OrderId = dt.Rows(0).Item("OrderId")
                .Sl = dt.Rows(0).Item("Sl")
                .ProductId = dt.Rows(0).Item("ProductId")
                .Qty = dt.Rows(0).Item("Qty")
                .Price = dt.Rows(0).Item("Price")
                .Discount = dt.Rows(0).Item("Discount")
                .Extra = dt.Rows(0).Item("Extra")
                .Weight = dt.Rows(0).Item("Weight")
                .SubTotal = dt.Rows(0).Item("SubTotal")
                .Fresh = dt.Rows(0).Item("Fresh")
                .Frozen = dt.Rows(0).Item("Frozen")
                .Notes = dt.Rows(0).Item("Notes")

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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & " [tblOrderItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT [" & _fieldName.ToString & "] FROM [tblOrderItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
    Function SelectCaseAndLBs(ByVal _orderId As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim strSQL As String
        strSQL = "select STUFF((SELECT ', ' + convert(varchar(10), sum (a.Fresh) + sum (a.Frozen)) + ' ' + b.UnitOfMeasure"
        strSQL += " FROM [tblOrderItems] a"
        strSQL += " left outer join [tblProducts] b"
        strSQL += " on a.ProductId = b.ProductId "
        strSQL += " WHERE(1 = 1)"
        strSQL += " AND OrderId=" + _orderId + ""
        strSQL += " group by b. UnitOfMeasure"
        strSQL += " FOR XML PATH(''), TYPE"
        strSQL += " ).value('.', 'NVARCHAR(MAX)') "
        strSQL += " ,1,1,'') as [Values]"

        Dim comSelectDistinct As New SqlCommand(strSQL, _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If

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
