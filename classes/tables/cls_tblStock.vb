Public Class cls_tblStock
    Public Shared tablename As String = "tblStock"
    Structure Fields
        Dim StockId As Integer
        Dim ProductId As Integer
        Dim Qty As Long
        Dim TransactionId As Integer
        Dim TransactionType As String
        Dim Stocktype As String
        Dim CreatedBy As Integer
        Dim CreatedDate As Date
        Dim Remarks As String
        Dim Fresh As Integer
        Dim Frozen As Integer
        Dim TransactionDate As Date

    End Structure

    Enum FieldName
        StockId 
        ProductId
        Qty
        TransactionId
        TransactionType
        Stocktype
        CreatedBy
        CreatedDate
        Remarks
        Fresh
        Frozen
        TransactionDate
    End Enum

    Private ReadOnly Property tblStock_insert
        Get
            Return <tblStock_insert><![CDATA[
INSERT INTO [tblStock]
           ([StockId]
           ,[ProductId]
           ,[Qty]
           ,[TransactionId]
           ,[TransactionType]
           ,[Stocktype]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[Remarks]
           ,[Fresh]
           ,[Frozen]
           ,[TransactionDate])
     VALUES
           (@StockId 
           ,@ProductId 
           ,@Qty 
           ,@TransactionId 
           ,@TransactionType 
           ,@Stocktype 
           ,@CreatedBy 
           ,@CreatedDate 
           ,@Remarks
           ,@Fresh
           ,@Frozen
           ,@TransactionDate )
                    ]]></tblStock_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblStock_update
        Get
            Return <tblStock_update><![CDATA[
UPDATE [tblStock]
   SET [ProductId] = @ProductId 
      ,[Qty] = @Qty 
      ,[TransactionId] = @TransactionId 
      ,[TransactionType] = @TransactionType 
      ,[Stocktype] = @Stocktype 
      ,[CreatedBy] = @CreatedBy 
      ,[CreatedDate] = @CreatedDate 
      ,[Remarks] = @Remarks 
      ,[Fresh] = @Fresh 
      ,[Frozen] = @Frozen 
      ,[TransactionDate] = @TransactionDate
WHERE
[StockId]=@StockId


                    ]]></tblStock_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblStock_Delete_By_StockId
        Get
            Return <tblStock_Delete><![CDATA[

DELETE FROM
[tblStock] 
WHERE
[StockId]=@StockId
                    ]]></tblStock_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblStock_Delete_By_SELECT
        Get
            Return <tblStock_Delete><![CDATA[

DELETE FROM
[tblStock] 
WHERE
1=1
                    ]]></tblStock_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblStock_MAXID
        Get
            Return <tblStock_MAXID><![CDATA[

SELECT MAX([StockId]) FROM [tblStock] WHERE 1=1
                    ]]></tblStock_MAXID>.Value
        End Get
    End Property

    Private ReadOnly Property tblStock_Select
        Get
            Return <tblStock_Select><![CDATA[
SELECT [StockId]
      ,[ProductId]
      ,[Qty]
      ,[TransactionId]
      ,[TransactionType]
      ,[Stocktype]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[Remarks]
      ,[Fresh]
      ,[Frozen]
      ,[TransactionDate]

 FROM [tblStock] 

WHERE 1=1
                    ]]></tblStock_Select>.Value
        End Get
    End Property
    'TODO: Need TransactionDate to be added
    Private ReadOnly Property tblStock_Select_With_OtherInfo
        Get
            Return <tblStock_Select><![CDATA[

SELECT 
        a.[StockId]
        ,a.[ProductId]
        ,a.[Stocktype]
        ,a.[Fresh]
        ,f.rtFs as [Total Fresh]
        ,a.[Frozen]
        ,f.rtFz as [Total Frozen]
        ,a.[Qty]
        ,f.[rt] as [Total Qty]
        ,a.[TransactionId]
        ,a.[TransactionType]
        ,ISNULL ( b.OrderNo , d.InvoiceNo ) as [Order/Invoice No]
        ,ISNULL (b.OrderDate ,d.PurchaseDate ) as [Order/Invoice Date]
        ,ISNULL ( c.CustomerName , e.VendorName ) as [Customer/Vendor Name]
        ,a.[Stocktype]
        ,a.[CreatedBy]
        ,a.[CreatedDate]
        ,a.[Remarks]
        ,a.[TransactionDate]
		,isnull(g.Weight,'') as [Weight] 
		,Isnull(g.Notes,'') as [Notes]
		,isnull(a.Remarks,'') as [PO Notes]
        ,(select Category + ' : ' + CONVERT(varchar,qty) + ', ' from tblSubStock where StockId=a.StockId for XML path('')) as [Frozen Qty Detail]

 FROM [tblStock] a

        left outer join 
            tblOrder b on a.TransactionId = b.OrderId and a.TransactionType ='ORDER'
        left outer join
            tblCustomer c on b.CutomerId = c.CustomerID 
        left outer join
            tblPurchase d on a.TransactionId = d.PurchaseId and a.TransactionType ='PURCHASE'
        left outer join 
            tblVendor e on d.VendorId = e.VendorID 
        left outer join 
            (
                select a.StockId , SUM (case when b.Stocktype = 'IN' then  isnull(b.Qty,0) else -1 * isnull(b.Qty,0) end ) as rt,
                SUM (case when b.Stocktype = 'IN' then  isnull(b.Fresh,0) else -1 * isnull(b.Fresh,0) end ) as rtFs,
                SUM (case when b.Stocktype = 'IN' then  isnull(b.Frozen,0) else -1 * isnull(b.Frozen,0) end ) as rtFz from 
                (select ROW_NUMBER  () OVER (Order By  TransactionDate, stockid ) as tt,* from tblStock ) a
                left outer join 
                (select ROW_NUMBER  () OVER (Order By  TransactionDate, stockid ) as tt,* from tblStock ) b on b.tt<=a.tt and a.ProductId= b.ProductId
                where a.ProductId = @ProductId
                group by a.tt , a.StockId
            ) f on a.StockId = f.StockId 
		Left Outer Join tblOrderItems g on b.OrderId = g.OrderId and a.ProductId = g.ProductId 
WHERE 1=1

       ]]></tblStock_Select>.Value
        End Get
    End Property

    'TODO: Need TransactionDate to be added
    Private ReadOnly Property tblStock_Select_With_OtherInfo_withoutTotal
        Get
            Return <tblStock_Select><![CDATA[

SELECT 
        a.[StockId]
        ,a.[ProductId]
        ,a.[Stocktype]
        ,a.[Fresh]
        ,0 as [Total Fresh]
        ,a.[Frozen]
        ,0 as [Total Frozen]
        ,a.[Qty]
        ,0 as [Total Qty]
        ,a.[TransactionId]
        ,a.[TransactionType]
        ,ISNULL ( b.OrderNo , d.InvoiceNo ) as [Order/Invoice No]
        ,ISNULL (b.OrderDate ,d.PurchaseDate ) as [Order/Invoice Date]
        ,ISNULL ( c.CustomerName , e.VendorName ) as [Customer/Vendor Name]
        ,a.[Stocktype]
        ,a.[CreatedBy]
        ,a.[CreatedDate]
        ,a.[Remarks]
        ,a.[TransactionDate]
		,isnull(g.Weight,'') as [Weight] 
		,Isnull(g.Notes,'') as [Notes]
		,isnull(a.Remarks,'') as [PO Notes]
        ,(select Category + ' : ' + CONVERT(varchar,qty) + ', ' from tblSubStock where StockId=a.StockId for XML path('')) as [FZ Weights]
        ,isnull(b.[Status],'') as [Order Status]

 FROM [tblStock] a

        left outer join 
            tblOrder b on a.TransactionId = b.OrderId and a.TransactionType ='ORDER'
        left outer join
            tblCustomer c on b.CutomerId = c.CustomerID 
        left outer join
            tblPurchase d on a.TransactionId = d.PurchaseId and a.TransactionType ='PURCHASE'
        left outer join 
            tblVendor e on d.VendorId = e.VendorID 
		Left Outer Join tblOrderItems g on b.OrderId = g.OrderId and a.ProductId = g.ProductId 
WHERE 1=1

       ]]></tblStock_Select>.Value
        End Get
    End Property

    'TODO: Need TransactionDate to be added
    Private ReadOnly Property tblStock_Select_With_FutureOrders
        Get
            Return <tblStock_Select><![CDATA[

SELECT a.[StockId]
      ,a.[ProductId]
      ,a.[Stocktype]
      ,a.[Fresh]
      ,f.rtFs as [Total Fresh]
      
      ,a.[Frozen]
      ,f.rtFz as [Total Frozen]
        --,ISNULL(g.Frozen,0) as [FrozenStock]
		,ISNULL(g.Frozen,0)+(-1*f.rtFz) as AnticipatedInventory
      ,a.[Qty]
      ,f.[rt] as [Total Qty]
      ,a.[TransactionId]
      ,a.[TransactionType]
      , ISNULL ( b.OrderNo , d.InvoiceNo ) as [Order/Invoice No]
      , ISNULL (b.OrderDate ,d.PurchaseDate ) as [Order/Invoice Date]
      , B.Status
      , ISNULL ( c.CustomerName , e.VendorName ) as [Customer/Vendor Name]
      ,a.[Stocktype]
      ,u.FullName CreatedBy
      --,a.[CreatedBy]
      ,a.[CreatedDate]
      ,a.[Remarks]
      ,a.[TransactionDate]
      ,(select Category + ' : ' + CONVERT(varchar,qty) + ', ' from tblSubStock where StockId=a.StockId for XML path('')) as [Frozen Qty Detail]
      ,p.UnitOfMeasure as [Unit] 
 FROM [tblStock] a
    left join tblUserDetails u on U.UserId=a.CreatedBy
    left outer join 
        tblOrder b on a.TransactionId = b.OrderId and a.TransactionType ='ORDER'
    left outer join
        tblCustomer c on b.CutomerId = c.CustomerID 
    left outer join
        tblPurchase d on a.TransactionId = d.PurchaseId and a.TransactionType ='PURCHASE'
    left outer join 
        tblVendor e on d.VendorId = e.VendorID 
    left outer join [tblProducts] p on a.ProductId = p.ProductId 
    left outer join 
    (
        select a.StockId , SUM (case when b.Stocktype = 'IN' then -1 * isnull(b.Qty,0) else isnull(b.Qty,0) end ) as rt,
        SUM (case when b.Stocktype = 'IN' then  -1 * isnull(b.Fresh,0) else isnull(b.Fresh,0) end ) as rtFs,
        SUM (case when b.Stocktype = 'IN' then  -1 * isnull(b.Frozen,0) else isnull(b.Frozen,0) end ) as rtFz from 
            (select ROW_NUMBER  () OVER (Order By  TransactionDate, stockid ) as tt,* from tblStock Where TransactionDate>=@FromDate) a
        left outer join 
            (select ROW_NUMBER  () OVER (Order By  TransactionDate, stockid ) as tt,* from tblStock Where TransactionDate>=@FromDate) b on b.tt<=a.tt and a.ProductId= b.ProductId
        where a.ProductId = @ProductId
        group by a.tt , a.StockId
    ) f on a.StockId = f.StockId 
    left join
	(select sum( case when stocktype='IN' then  qty else -1 * qty end) as qty,sum( case when stocktype='IN' then  Fresh else -1 * Fresh end) as Fresh,sum( case when stocktype='IN' then  Frozen else -1 * Frozen end) as Frozen, productid from tblStock Where TransactionDate<@FromDate group by ProductId ) g 
    on a.ProductId = g.ProductId                       
WHERE a.Stocktype <> 'IN'

       ]]></tblStock_Select>.Value
        End Get
    End Property

    Private ReadOnly Property tblStock_Select_With_FutureOrdersWithOnHold
        Get
            Return <tblStock_Select><![CDATA[

SELECT a.[StockId]
      ,a.[ProductId]
      ,a.[Stocktype]
      ,a.[Fresh]
      ,f.rtFs as [Total Fresh]
      
      ,a.[Frozen]
      ,f.rtFz as [Total Frozen]
        --,ISNULL(g.Frozen,0) as [FrozenStock]
		,ISNULL(g.Frozen,0)+(-1*f.rtFz) as AnticipatedInventory
      ,a.[Qty]
      ,f.[rt] as [Total Qty]
      ,a.[TransactionId]
      ,a.[TransactionType]
      , ISNULL ( b.OrderNo , d.InvoiceNo ) as [Order/Invoice No]
      , ISNULL (b.OrderDate ,d.PurchaseDate ) as [Order/Invoice Date]
      , B.Status
      , ISNULL ( c.CustomerName , e.VendorName ) as [Customer/Vendor Name]
      ,a.[Stocktype]
      ,u.FullName CreatedBy
      --,a.[CreatedBy]
      ,a.[CreatedDate]
      ,a.[Remarks]
      ,a.[TransactionDate]
      ,(select Category + ' : ' + CONVERT(varchar,qty) + ', ' from tblSubStock where StockId=a.StockId for XML path('')) as [Frozen Qty Detail]
      ,p.UnitOfMeasure as [Unit] 
 FROM [tblStock] a
    left join tblUserDetails u on U.UserId=a.CreatedBy
    left outer join 
        tblOrder b on a.TransactionId = b.OrderId and a.TransactionType ='ORDER'
    left outer join
        tblCustomer c on b.CutomerId = c.CustomerID 
    left outer join
        tblPurchase d on a.TransactionId = d.PurchaseId and a.TransactionType ='PURCHASE'
    left outer join 
        tblVendor e on d.VendorId = e.VendorID 
    left outer join [tblProducts] p on a.ProductId = p.ProductId 
    left outer join 
    (
        select a.StockId , SUM (case when b.Stocktype = 'IN' then -1 * isnull(b.Qty,0) else isnull(b.Qty,0) end ) as rt,
        SUM (case when b.Stocktype = 'IN' then  -1 * isnull(b.Fresh,0) else isnull(b.Fresh,0) end ) as rtFs,
        SUM (case when b.Stocktype = 'IN' then  -1 * isnull(b.Frozen,0) else isnull(b.Frozen,0) end ) as rtFz from 
            (select ROW_NUMBER  () OVER (Order By  TransactionDate, stockid ) as tt,tblStock.* from tblStock
			inner join tblOrder on tblStock.TransactionId = tblOrder.OrderId and tblStock.TransactionType ='ORDER' and tblOrder.Status <> 'On Hold' 
			 Where TransactionDate>=@FromDate) a
        left outer join 
            (select ROW_NUMBER  () OVER (Order By  TransactionDate, stockid ) as tt,tblStock.* from tblStock 
            inner join tblOrder on tblStock.TransactionId = tblOrder.OrderId and tblStock.TransactionType ='ORDER' and tblOrder.Status <> 'On Hold' 
            Where TransactionDate>=@FromDate) b on b.tt<=a.tt and a.ProductId= b.ProductId
        where a.ProductId = @ProductId
        group by a.tt , a.StockId
    ) f on a.StockId = f.StockId 
    left join
	(select sum( case when stocktype='IN' then  qty else -1 * qty end) as qty,sum( case when stocktype='IN' then  Fresh else -1 * Fresh end) as Fresh,sum( case when stocktype='IN' then  Frozen else -1 * Frozen end) as Frozen, productid from tblStock Where TransactionDate<@FromDate group by ProductId ) g 
    on a.ProductId = g.ProductId                       
WHERE a.Stocktype <> 'IN'

       ]]></tblStock_Select>.Value
        End Get
    End Property

    Private ReadOnly Property tblStock_Select_With_ProductName
        Get
            Return <tblStock_Select><![CDATA[
SELECT a.[StockId]
      ,a.[ProductId]
      ,b.ProductName
      ,a.[Qty]
      ,a.[TransactionId]
      ,a.[TransactionType]
      ,a.[Stocktype]
      ,a.[CreatedBy]
      ,a.[CreatedDate]
      ,a.[Remarks]
      ,a.[Fresh]
      ,a.[Frozen]
      ,a.[TransactionDate]
      ,(select Category + ' : ' + CONVERT(varchar,qty) + ', ' from tblSubStock where StockId=a.StockId for XML path('')) as [Frozen Qty Detail]

 FROM [tblStock] a
 Left Outer Join 
 tblProducts b
 on a.ProductId = b.ProductId 

WHERE 1=1
                    ]]></tblStock_Select>.Value
        End Get
    End Property

    Private ReadOnly Property tblStock_Select_All_Product
        Get
            Return <tblStock_Select><![CDATA[
SELECT a.[ProductId]
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
      ,isnull(b.Qty,0) as Qty
      ,isnull(b.Fresh,0) as FreshQty
      ,isnull(b.Frozen,0) as FrozenQty
      ,(select Category + ' : ' + CONVERT(varchar,qty) + ', ' from tblSubStock where ProductID=a.ProductID for XML path('')) as [Frozen Qty Detail]
  FROM [tblProducts] a
  left outer join 
  (select sum( case when stocktype='IN' then  qty else -1 * qty end) as qty,sum( case when stocktype='IN' then  Fresh else -1 * Fresh end) as Fresh,sum( case when stocktype='IN' then  Frozen else -1 * Frozen end) as Frozen, productid from tblStock where TransactionDate <=@StockTill group by ProductId ) b
  on a.ProductId = b.ProductId 
   

WHERE 1=1
                    ]]></tblStock_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblStock_MAXID, _conn)
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
                      ProductId As Integer, _
                      Qty As Long, _
                      TransactionId As Integer, _
                      TransactionType As String, _
                      Stocktype As String, _
                      CreatedBy As Integer, _
                      CreatedDate As Date, _
                      Remarks As String, _
                      Fresh As Integer, _
                      Frozen As Integer, _
                      TransactionDate As Date, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim StockId As Integer = MaxID_PlusOne(_conn, _transac)
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim comInsert As New SqlCommand(tblStock_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@StockId", StockId)
            .AddWithValue("@ProductId", ProductId)
            .AddWithValue("@Qty", Qty)
            .AddWithValue("@TransactionId", TransactionId)
            .AddWithValue("@TransactionType", TransactionType)
            .AddWithValue("@Stocktype", Stocktype)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@Remarks", Remarks)
            .AddWithValue("@Fresh", Fresh)
            .AddWithValue("@Frozen", Frozen)
            .AddWithValue("@TransactionDate", TransactionDate)
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
        Return StockId
    End Function

    Function Update(ByVal StockId As Integer, _
                          ProductId As Integer, _
                          Qty As Long, _
                          TransactionId As Integer, _
                          TransactionType As String, _
                          Stocktype As String, _
                          CreatedBy As Integer, _
                          CreatedDate As Date, _
                          Remarks As String, _
                          Fresh As Integer, _
                          Frozen As Integer, _
                          TransactionDate As Date, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblStock_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ProductId", ProductId)
            .AddWithValue("@Qty", Qty)
            .AddWithValue("@TransactionId", TransactionId)
            .AddWithValue("@TransactionType", TransactionType)
            .AddWithValue("@Stocktype", Stocktype)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@Remarks", Remarks)
            .AddWithValue("@Fresh", Fresh)
            .AddWithValue("@Frozen", Frozen)
            .AddWithValue("@StockId", StockId)
            .AddWithValue("@TransactionDate", TransactionDate)
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

        Return StockId
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

        Dim comUpdate As New SqlCommand("Update [tblStock] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblStock_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
    Function Delete_By_StockId(ByRef StockId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblStock_Delete_By_StockId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@StockId", StockId)
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
        Return StockId
    End Function
    Enum SelectionType
        All = 0
        Products_wise = 1
        All_Product = 2
        OtherInfo = 3
        FutureOrders = 4
        OtherInfo_withoutTotal = 5
        FutureOrdersWithOutOnHold = 6
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
                comSelection.CommandText = tblStock_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.Products_wise
                comSelection.CommandText = tblStock_Select_With_ProductName & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.All_Product
                comSelection.CommandText = tblStock_Select_All_Product & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.OtherInfo
                comSelection.CommandText = tblStock_Select_With_OtherInfo & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.FutureOrders
                comSelection.CommandText = tblStock_Select_With_FutureOrders & IIf(_SelectString <> "", IIf(_SelectString.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.FutureOrdersWithOutOnHold
                comSelection.CommandText = tblStock_Select_With_FutureOrdersWithOnHold & IIf(_SelectString <> "", IIf(_SelectString.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.OtherInfo_withoutTotal
                comSelection.CommandText = tblStock_Select_With_OtherInfo_withoutTotal & IIf(_SelectString <> "", IIf(_SelectString.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
    Function Selection_One_Row(ByVal StockId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblStock_Select & " AND [StockId]=@StockId"
        comSelection.Parameters.AddWithValue("@StockId", StockId)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)

            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If

            With return_field
                .StockId = dt.Rows(0).Item("StockId")
                .ProductId = dt.Rows(0).Item("ProductId")
                .Qty = dt.Rows(0).Item("Qty")
                .TransactionId = dt.Rows(0).Item("TransactionId")
                .TransactionType = dt.Rows(0).Item("TransactionType")
                .Stocktype = dt.Rows(0).Item("Stocktype")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .Remarks = dt.Rows(0).Item("Remarks")
                .Fresh = dt.Rows(0).Item("Fresh")
                .Frozen = dt.Rows(0).Item("Frozen")
                .TransactionDate = dt.Rows(0).Item("TransactionDate")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & "  from [tblStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & "  from [tblStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
