Public Class cls_tblOrder

    Public Shared tablename As String = "tblOrder"

    Structure Fields
        Dim OrderId As Integer
        Dim OrderNo As String
        Dim OrderSl As Integer
        Dim OrderDate As Date
        Dim DeliveryDate As Date
        Dim CutomerId As Integer
        Dim TotalItems As Integer
        Dim OrderAmount As Decimal
        Dim CreatedDate As Date
        Dim CreatedBy As Integer
        Dim UpdatedDate As Date
        Dim UpdatedBy As Integer
        Dim Status As String
        Dim StatusDate As Date
        Dim StatusBy As Integer
        Dim Remarks As String
        Dim Comments As String
        Dim Session As String
        Dim BranchId As Integer
        Dim BOLAddressID As Integer
        Dim ScheduledOrderId As Integer
        Dim InvoiceNumber As String
        Dim TotalCartons As Integer
        Dim OrderDiscrepancy As String
        Dim Total As String
    End Structure

    Enum FieldName
        OrderId
        OrderNo
        OrderSl
        OrderDate
        DeliveryDate
        CutomerId
        TotalItems
        OrderAmount
        CreatedDate
        CreatedBy
        UpdatedDate
        UpdatedBy
        Status
        StatusDate
        StatusBy
        Remarks
        Comments
        Session
        BranchId
        BOLAddressID
        ScheduledOrderId
        InvoiceNumber
        TotalCartons
        OrderDiscrepancy
        Total
    End Enum

    Private ReadOnly Property tblOrder_insert
        Get
            Return <tblOrder_insert><![CDATA[
INSERT INTO [tblOrder]
           ([OrderId]
           ,[OrderNo]
           ,[OrderSl]
           ,[OrderDate]
           ,[DeliveryDate]
           ,[CutomerId]
           ,[TotalItems]
           ,[OrderAmount]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedBy]
           ,[Status]
           ,[StatusDate]
           ,[StatusBy]
           ,[Remarks]
           ,[Comments]
           ,[Session]
           ,[BranchId]
           ,[BOLAddressID]
           ,[ScheduledOrderId])
     VALUES
           (@OrderId 
           ,@OrderNo 
           ,@OrderSl 
           ,@OrderDate 
           ,@DeliveryDate 
           ,@CutomerId 
           ,@TotalItems 
           ,@OrderAmount 
           ,@CreatedDate 
           ,@CreatedBy 
           ,@UpdatedDate 
           ,@UpdatedBy 
           ,@Status 
           ,@StatusDate 
           ,@StatusBy 
           ,@Remarks 
           ,@Comments 
           ,@Session 
           ,@BranchId 
           ,@BOLAddressID 
           ,@ScheduledOrderId )
                    ]]></tblOrder_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrder_update
        ' [OrderNo] = @OrderNo 
        ',[OrderSl] = @OrderSl 

        Get
            Return <tblOrder_update><![CDATA[

UPDATE [tblOrder]
   SET [OrderDate] = @OrderDate 
      ,[DeliveryDate] = @DeliveryDate 
      ,[CutomerId] = @CutomerId 
      ,[TotalItems] = @TotalItems 
      ,[OrderAmount] = @OrderAmount 
      ,[CreatedDate] = @CreatedDate 
      ,[CreatedBy] = @CreatedBy 
      ,[UpdatedDate] = @UpdatedDate 
      ,[UpdatedBy] = @UpdatedBy 
      ,[Status] = @Status 
      ,[StatusDate] = @StatusDate 
      ,[StatusBy] = @StatusBy  
      ,[Remarks] = @Remarks 
      ,[Comments] = @Comments 
      ,[Session] = @Session 
      ,[BranchId] = @BranchId 
      ,[BOLAddressID] = @BOLAddressID 
      ,[ScheduledOrderId] = @ScheduledOrderId 
WHERE
[OrderId]=@OrderId

       ]]></tblOrder_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblOrder_Delete_By_OrderId
        Get
            Return <tblOrder_Delete><![CDATA[
DELETE FROM
    [tblOrder] 
WHERE
    [OrderId]=@OrderId
                    ]]></tblOrder_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrder_MAXID
        Get
            Return <tblOrder_MAXID><![CDATA[

SELECT MAX([OrderId]) FROM [tblOrder] WHERE 1=1
                    ]]></tblOrder_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property QryOrderDetails
        Get
            Return <QryOrderDetails><![CDATA[

SELECT        D.OrderId, P.ProductName, D.Qty, D.Frozen, D.Fresh
FROM            tblOrderItems AS D INNER JOIN
                         tblProducts AS P ON D.ProductId = P.ProductId
WHERE        1 = 1
                    ]]></QryOrderDetails>.Value
        End Get
    End Property
    
    Private ReadOnly Property tblOrder_MAXSL
        Get
            Return <tblOrder_MAXSL><![CDATA[

select isnull(MAX(ordersl),0) from tblOrder
where DATEPART(Month, orderdate ) =DATEPART(Month, GETDATE() ) and DATEPART(Year, orderdate ) =DATEPART(Year, GETDATE() ) 
                    ]]></tblOrder_MAXSL>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrder_Select
        Get
            Return <tblOrder_Select><![CDATA[

SELECT [OrderId]
      ,[OrderNo]
      ,[OrderSl]
      ,[OrderDate]
      ,[DeliveryDate]
      ,[CutomerId]
      ,[TotalItems]
      ,[OrderAmount]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[UpdatedDate]
      ,[UpdatedBy]
      ,[Status]
      ,[StatusDate]
      ,[StatusBy]
      ,[Remarks]
      ,[Comments]
      ,[Session]
      ,[BranchId]
      ,Isnull([BOLAddressID],0) as [BOLAddressID]
      ,Isnull([ScheduledOrderId],0) as [ScheduledOrderId],
      ISNULL([InvoiceNumber],'') AS [InvoiceNumber],
      round(ISNULL([TotalCartons],0),0) AS [TotalCartons],
	  case when ISNULL([TotalCartons],0)<>[TotalItems] then 'Mismatch'
	  else 'Ok' end OrderDiscrepancy,
    (select (stuff(
		(
			SELECT 
			', '+ convert(varchar(50), sum (IOI.Fresh) + sum (IOI.Frozen))  + ' ' + IOP.UnitOfMeasure
			 from tblOrderItems IOI 
			inner join tblProducts IOP on IOP.ProductId=IOI.ProductId
			where IOI.OrderId=tblOrder.OrderId group by IOP.UnitOfMeasure  FOR XML PATH('')
		),1,1,'') )) as Total
  FROM [tblOrder]

WHERE 1=1
                    ]]></tblOrder_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrder_Select_Review
        Get
            Return <tblOrder_Select_Review><![CDATA[

SELECT a.[OrderId],
       a.[OrderNo],
       a.[OrderSl],
       a.[OrderDate],
       a.[DeliveryDate] as [Posting Date],
       a.[CutomerId],
       b.[CustomerName],
       b.[Route],
       CASE
       WHEN f.ItemSl IS NULL THEN b.[RouteCity]
           ELSE f.[RouteCity]
       END AS [RouteCity],
       CASE
       WHEN f.ItemSl IS NULL THEN b.[City]
           ELSE f.[City]
       END AS [City],
       a.[TotalItems],
       ISNULL( h.Cs,0 ) AS [Total Cases],
       a.[OrderAmount],
       a.[CreatedDate],
       g.[UserName] AS [CreatedBy],
       a.[UpdatedDate],
       e.[UserName] AS [UpdatedBy],
       a.[Status] + CASE
                    WHEN c.ItemId IS NULL
                     AND a.[Status] <> 'Delivered' THEN ''
                        ELSE '. On Delivery(' + b.RouteCity + '-' + d.RouteCity + ')'
                    END + CASE
                          WHEN a_temp.OrderId IS NULL THEN ''
                              ELSE '. Last order date ' + CONVERT( VARCHAR,a_temp.OrderDate,101 ) + ' #' + a_temp.OrderNo
                          END AS Status,
       d.Driver,
       d.Truck,
       d.OtherInfos AS [Route Name],
       a.[StatusDate],
       a.[StatusBy],
       a.[Remarks],
       a.[Comments],
       a.[Session],
       a.[BranchId],
       CASE
       WHEN f.ItemSl IS NULL THEN 'NO'
           ELSE 'YES'
       END AS [BOL],
       CASE
       WHEN f.ItemSl IS NULL THEN ''
           ELSE f.[DropOffPoint]
       END AS [Drop Off Point],
       CASE
       WHEN ISNULL( f.[Receiving_CutOff],CASE
                                         WHEN ISNULL( b.[Receiving_CutOff],'' ) = '' THEN 'NOT SPECIFIED'
                                             ELSE b.[Receiving_CutOff]
                                         END ) = '' THEN 'NOT SPECIFIED'
           ELSE b.[Receiving_CutOff]
       END AS [Recieving Cut Off]
  FROM [tblOrder] a
       LEFT OUTER JOIN tblorder a_temp ON a.Status = 'No Order'
                                      AND a.OrderId > a_temp.OrderId
                                      AND a.CutomerId = a_temp.CutomerId
                                      AND a_temp.OrderId IN( 
                                                             SELECT MAX( OrderId )
                                                               FROM tblOrder
                                                               WHERE OrderDate < a.OrderDate
                                                                 AND CutomerId = a.CutomerId
                                                                 AND Status NOT IN( 'Cancelled','No Order' )
                                                               GROUP BY CutomerId )
       LEFT OUTER JOIN tblCustomer b ON a.[CutomerId] = b.[CustomerId]
       LEFT OUTER JOIN( 
                        SELECT *
                          FROM tblRouteOrders
                          WHERE ItemId IN(
                        SELECT MAX( itemId )
                          FROM tblRouteOrders
                          GROUP BY OrderId )) c ON a.OrderId = c.OrderId
       LEFT OUTER JOIN tblRoute d ON c.RouteID = d.RouteId
       LEFT OUTER JOIN tblUserDetails e ON a.UpdatedBy = e.UserId
       LEFT OUTER JOIN( 
                        SELECT *
                          FROM tblCustomer_BOL ) f ON a.[BOLAddressID] = f.ItemSl
       LEFT OUTER JOIN tblUserDetails g ON a.CreatedBy = g.UserId
       LEFT OUTER JOIN( 
                        SELECT a.OrderId,
                               SUM( a.Fresh + a.Frozen ) AS [Cs]
                          FROM tblOrderItems a
                               LEFT OUTER JOIN tblProducts b ON a.ProductId = b.ProductId
                          WHERE b.UnitOfMeasure = 'Case(s)'
                          GROUP BY a.OrderId ) h ON a.OrderId = h.OrderId
  WHERE 1 = 1

                    ]]></tblOrder_Select_Review>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrder_Select_CustomerWise
        Get
            Return <tblOrder_Select_Review><![CDATA[

SELECT a.[OrderId]
      ,a.[OrderNo]
      ,a.[OrderSl]
      ,a.[OrderDate], convert(int,DATEDIFF (day,a.[OrderDate],GETDATE()))  as [DaysAgo]
      ,a.[DeliveryDate]
      ,a.[CutomerId]
      ,b.[CustomerName]
      ,b.[Route]
      ,CASE WHEN f.ItemSl IS NULL THEN b.[RouteCity] ELSE f.[RouteCity] END as [RouteCity]
      ,CASE WHEN f.ItemSl IS NULL THEN b.[City] ELSE f.[City] END as [City]
      ,a.[TotalItems]
      ,isnull(h.Cs,0) as [Total Cases]
      ,a.[OrderAmount]
      ,a.[CreatedDate]
      ,g.[UserName] as [CreatedBy]
      ,a.[UpdatedDate]
      ,e.[UserName] as [UpdatedBy] 
      ,a.[Status] + case when c.ItemId is null and a.[Status]<>'Delivered' then '' else '. On Delivery(' +  b.RouteCity + '-' + d.RouteCity + ')' end  as Status
      ,d.Driver , d.Truck , d.OtherInfos as [Route Name]
      ,a.[StatusDate]
      ,a.[StatusBy]
      ,a.[Remarks]    
      ,a.[Comments]
      ,a.[Session]
      ,a.[BranchId]
      ,CASE WHEN f.ItemSl IS NULL THEN 'NO' ELSE 'YES' END as [BOL]
      ,CASE WHEN f.ItemSl IS NULL THEN '' ELSE f.[DropOffPoint] END as [Drop Off Point]
  FROM tblCustomer b
LEFT OUTER JOIN [tblOrder] a ON a.[CutomerId]=b.[CustomerId]
LEFT OUTER JOIN (select * from tblRouteOrders where ItemId in (Select MAX(itemId) from tblRouteOrders Group By OrderId)) c on a.OrderId = c.OrderId 
LEFT OUTER JOIN tblRoute d on c.RouteID  = d.RouteId
LEFT OUTER JOIN tblUserDetails e on a.UpdatedBy  = e.UserId
LEFT OUTER JOIN (select * from tblCustomer_BOL) f on a.[BOLAddressID] = f.ItemSl
LEFT OUTER JOIN tblUserDetails g on a.CreatedBy  = g.UserId
LEFT OUTER JOIN ( Select a.OrderId , Sum(a.Fresh + a.Frozen) as [Cs] from tblOrderItems a LEFT OUTER JOIN tblProducts b ON a.ProductId = b.ProductId Where b.UnitOfMeasure='Case(s)' Group By a.OrderId ) h on a.OrderId = h.OrderId 

WHERE a.OrderId in ( select MAX(OrderId) from tblOrder where CreatedDate in (select MAX(CreatedDate) from tblOrder where orderdate in (select MAX(OrderDate) from tblOrder group by CutomerId )  group by CutomerId )  group by CutomerId )

                    ]]></tblOrder_Select_Review>.Value
        End Get
    End Property
    Function MaxID_PlusOne(ByVal type As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblOrder_MAXID, _conn)
        Select Case type
            Case 0
                comMaxID.CommandText = tblOrder_MAXID
            Case 1
                comMaxID.CommandText = tblOrder_MAXSL
        End Select
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
                    ByRef OrderNo As String, _
                    ByRef OrderSl As Integer, _
                    ByRef OrderDate As Date, _
                    ByRef DeliveryDate As Date, _
                    ByRef CutomerId As Integer, _
                    ByRef TotalItems As Integer, _
                    ByRef OrderAmount As Decimal, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _
                    ByRef Status As String, _
                    ByRef StatusDate As Date, _
                    ByRef StatusBy As Integer, _
                    ByRef Remarks As String, _
                    ByRef Comments As String, _
                    ByRef Session As String, _
                    ByRef BranchId As Integer, _
                    ByRef BOLAddressID As Integer, _
                    ByRef ScheduledOrderId As Integer, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim OrderId As Integer = MaxID_PlusOne(0, _conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblOrder_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@OrderId", OrderId)
            .AddWithValue("@OrderNo", OrderNo)
            .AddWithValue("@OrderSl", OrderSl)
            .AddWithValue("@OrderDate", OrderDate)
            .AddWithValue("@DeliveryDate", DeliveryDate)
            .AddWithValue("@CutomerId", CutomerId)
            .AddWithValue("@TotalItems", TotalItems)
            .AddWithValue("@OrderAmount", OrderAmount)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Status", Status)
            .AddWithValue("@StatusDate", StatusDate)
            .AddWithValue("@StatusBy", StatusBy)
            .AddWithValue("@Remarks", Remarks)
            .AddWithValue("@Comments", Comments)
            .AddWithValue("@Session", Session)
            .AddWithValue("@BranchId", BranchId)
            .AddWithValue("@BOLAddressID", BOLAddressID)
            .AddWithValue("@ScheduledOrderId", ScheduledOrderId)
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
        Return OrderId
    End Function

    Function Update(ByVal OrderId As Integer, _
                    ByRef OrderNo As String, _
                    ByRef OrderSl As Integer, _
                    ByRef OrderDate As Date, _
                    ByRef DeliveryDate As Date, _
                    ByRef CutomerId As Integer, _
                    ByRef TotalItems As Integer, _
                    ByRef OrderAmount As Decimal, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _
                    ByRef Status As String, _
                    ByRef StatusDate As Date, _
                    ByRef StatusBy As Integer, _
                    ByRef Remarks As String, _
                    ByRef Comments As String, _
                    ByRef Session As String, _
                    ByRef BranchId As Integer, _
                    ByRef BOLAddressID As Integer, _
                    ByRef ScheduledOrderId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim comUpdated As New SqlCommand(tblOrder_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If
        With comUpdated.Parameters
            '.AddWithValue("@OrderNo", OrderNo)
            '.AddWithValue("@OrderSl", OrderSl)
            .AddWithValue("@OrderDate", OrderDate)
            .AddWithValue("@DeliveryDate", DeliveryDate)
            .AddWithValue("@CutomerId", CutomerId)
            .AddWithValue("@TotalItems", TotalItems)
            .AddWithValue("@OrderAmount", OrderAmount)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Status", Status)
            .AddWithValue("@StatusDate", StatusDate)
            .AddWithValue("@StatusBy", StatusBy)
            .AddWithValue("@Remarks", Remarks)
            .AddWithValue("@Comments", Comments)
            .AddWithValue("@Session", Session)
            .AddWithValue("@BranchId", BranchId)
            .AddWithValue("@BOLAddressID", BOLAddressID)
            .AddWithValue("@ScheduledOrderId", ScheduledOrderId)
            .AddWithValue("@OrderId", OrderId)
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
        Return OrderId
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

        Dim comUpdate As New SqlCommand("Update [tblOrder] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_OrderId(ByRef OrderId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrder_Delete_By_OrderId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@OrderId", OrderId)
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
        Return OrderId
    End Function

    Enum SelectionType
        All = 0
        ReviewOrder = 1
        CustomerWise = 2
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
                comSelection.CommandText = tblOrder_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.ReviewOrder
                comSelection.CommandText = tblOrder_Select_Review & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.CustomerWise
                comSelection.CommandText = tblOrder_Select_CustomerWise & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
    Function Selection_One_Row(ByVal OrderId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblOrder_Select & " AND [OrderId]=@OrderId"
        comSelection.Parameters.AddWithValue("@OrderId", OrderId)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .OrderId = dt.Rows(0).Item("OrderId")
                .OrderNo = dt.Rows(0).Item("OrderNo")
                .OrderSl = dt.Rows(0).Item("OrderSl")
                .OrderDate = dt.Rows(0).Item("OrderDate")
                .DeliveryDate = dt.Rows(0).Item("DeliveryDate")
                .CutomerId = dt.Rows(0).Item("CutomerId")
                .TotalItems = dt.Rows(0).Item("TotalItems")
                .OrderAmount = dt.Rows(0).Item("OrderAmount")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedDate = dt.Rows(0).Item("UpdatedDate")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .Status = dt.Rows(0).Item("Status")
                .StatusDate = dt.Rows(0).Item("StatusDate")
                .StatusBy = dt.Rows(0).Item("StatusBy")
                .Remarks = dt.Rows(0).Item("Remarks")
                .Comments = dt.Rows(0).Item("Comments")
                .Session = dt.Rows(0).Item("Session")
                .BranchId = dt.Rows(0).Item("BranchId")
                .BOLAddressID = dt.Rows(0).Item("BOLAddressID")
                .ScheduledOrderId = dt.Rows(0).Item("ScheduledOrderId")
                .InvoiceNumber = dt.Rows(0).Item("InvoiceNumber")
                .TotalCartons = dt.Rows(0).Item("TotalCartons")
                .OrderDiscrepancy = dt.Rows(0).Item("OrderDiscrepancy")
                .Total = dt.Rows(0).Item("Total")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & " [tblOrder] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT [" & _fieldName.ToString & "] FROM [tblOrder] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
    Function SelectRouteDetails(ByVal RouteId As String, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim strSQL As String
        strSQL = "select convert(varchar(10),R.RouteDate,101) RouteDate, "
        strSQL += "R.OtherInfos,R.Truck, R.Driver, "
        strSQL += "R.RouteId, RO.ItemId, RO.OrderId, O.OrderDate,"
        strSQL += "(select (stuff( "
        strSQL += "( "
        strSQL += "SELECT  "
        strSQL += "', '+ convert(varchar(50), sum (IOI.Fresh) + sum (IOI.Frozen))  + ' ' + replace(replace(IOP.UnitOfMeasure,'Case(s)','Cs'),'LB(s)','LB') "
        strSQL += "from tblOrderItems IOI  "
        strSQL += "inner join tblProducts IOP on IOP.ProductId=IOI.ProductId "
        strSQL += "where IOI.OrderId=O.OrderId group by IOP.UnitOfMeasure  FOR XML PATH('') "
        strSQL += "),1,1,'') )) as  TotalItems, "
        strSQL += "O.TotalItems as TotalItems2, "
        strSQL += "C.CustomerName, O.Comments, Case when C.Cod=1 then 'Yes' else 'No' end Cod, "
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 1) as 'prod1',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 2) as 'prod2',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 3) as 'prod3',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 4) as 'prod4',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 5) as 'prod15',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 6) as 'prod16',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 7) as 'prod17',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 8) as 'prod18',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 9) as 'prod19',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 10) as 'prod110',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 11) as 'prod111',"
        strSQL += "dbo.fn_GetQtyByOrderByProduct(O.OrderId, 12) as 'prod112', "
        strSQL += "dbo.fn_GetQtyByOrderByOtherProduct(O.OrderId) as 'OtherProduct' "
        strSQL += "from tblRoute R "
        strSQL += "inner join tblRouteOrders RO on RO.RouteID=R.RouteId "
        strSQL += "inner join tblOrder O on O.OrderId=RO.OrderId "
        strSQL += "inner join tblCustomer C on C.CustomerID=O.CutomerId "
        strSQL += "and R.[RouteId]=" + RouteId + " "
        strSQL += "order by RO.SL asc "
        Dim comSelect As New SqlCommand(strSQL, _conn)
        If Not _transac Is Nothing Then
            comSelect.Transaction = _transac
        End If

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelect)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelect.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function
    Function SelectOrdersAfterRoute(ByVal _RouteId As String, ByVal _additionalCondition As String,
                                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim strSQL As String

        strSQL = "SELECT        OrderNo, C.CustomerName, O.OrderDate, O.CreatedDate, O.Status, R.RouteDate, "
        strSQL += "R.RouteId, R.CreatedOn, R.OtherInfos, R.Driver "
        strSQL += "FROM            tblOrder O "
        strSQL += "inner join tblRouteOrders RO on O.OrderId=RO.OrderId "
        strSQL += "inner join tblRoute R on RO.RouteID=R.RouteId "
        strSQL += "inner join tblCustomer C on C.CustomerID=O.CutomerId  "
        strSQL += "where (O.CreatedDate > R.CreatedOn) "
        strSQL += _additionalCondition
        Dim comSelect As New SqlCommand(strSQL, _conn)
        If Not _transac Is Nothing Then
            comSelect.Transaction = _transac
        End If

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelect)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelect.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            'Throw ex
        End Try

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function
    Function SelectRouteSummary(ByVal RouteId As String, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim strSQL As String
        strSQL = "Select "
        strSQL += " R.RouteId, "
        strSQL += " (select (stuff((SELECT ', '+ convert(varchar(50), sum (IOI.Fresh) + sum (IOI.Frozen))  + ' ' + replace(replace(IOP.UnitOfMeasure,'Case(s)','Cs'),'LB(s)','LB') "
        strSQL += " from tblRouteOrders RO inner join tblOrderItems IOI on IOI.OrderId=RO.OrderId"
        strSQL += " inner join tblProducts IOP on IOP.ProductId=IOI.ProductId"
        strSQL += " where RO.RouteID=R.RouteId group by IOP.UnitOfMeasure  FOR XML PATH('')),1,1,'') )) as SumTotalItems,"
        strSQL += " (select sum(O.TotalItems) from "
        strSQL += " tblRouteOrders RO inner join tblOrder O "
        strSQL += " on O.OrderId=RO.OrderId"
        strSQL += " where RO.[RouteId] = R.RouteId) SumTotalItems2,"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 1) as 'prod1',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 2) as 'prod2',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 3) as 'prod3',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 4) as 'prod4',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 5) as 'prod15',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 6) as 'prod16',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 7) as 'prod17',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 8) as 'prod18',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 9) as 'prod19',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 10) as 'prod110',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 11) as 'prod111',"
        strSQL += " dbo.[fn_GetQtyByRouteByProduct](R.RouteId, 12) as 'prod112',"
        strSQL += " dbo.fn_GetQtyByRouteByOtherProduct(R.RouteId) as 'OtherProduct'"
        strSQL += " from tblRoute R "
        strSQL += " where (R.[RouteId] = " + RouteId + ") "

        Dim comSelect As New SqlCommand(strSQL, _conn)
        If Not _transac Is Nothing Then
            comSelect.Transaction = _transac
        End If

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelect)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelect.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function
    Function SelectRouteStopage(ByVal RouteId As String, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim strSQL As String
        strSQL = "select * from ( "
        strSQL += "select convert(varchar(10),R.RouteDate,101) RouteDate, RO.SL, R.OtherInfos, R.Truck, R.Driver, R.RouteId, RO.ItemId, RO.OrderId, O.OrderDate, C.CustomerName, "
        strSQL += " O.Comments, O.BOLAddressID,"
        strSQL += " '' as DropOffPoint,C.Address, C.City, C.State, C.Zip, '' Contact"
        strSQL += " from tblRoute R "
        strSQL += " inner join tblRouteOrders RO on RO.RouteID=R.RouteId "
        strSQL += " inner join tblOrder O on O.OrderId=RO.OrderId "
        strSQL += " inner join tblCustomer C on C.CustomerID=O.CutomerId "
        strSQL += " and R.[RouteId]=" + RouteId + " "
        strSQL += " and O.BOLAddressID=0"
        strSQL += " UNION ALL"
        strSQL += " select convert(varchar(10),R.RouteDate,101) RouteDate, RO.SL, R.OtherInfos,R.Truck, R.Driver, R.RouteId, RO.ItemId, RO.OrderId, O.OrderDate, C.CustomerName, "
        strSQL += " O.Comments, O.BOLAddressID,"
        strSQL += " B.DropOffPoint as DropOffPoint, B.Address, B.City, B.State, B.Zip, B.Contact"
        strSQL += " from tblRoute R "
        strSQL += " inner join tblRouteOrders RO on RO.RouteID=R.RouteId "
        strSQL += " inner join tblOrder O on O.OrderId=RO.OrderId "
        strSQL += " inner join tblCustomer C on C.CustomerID=O.CutomerId "
        strSQL += " inner join tblCustomer_BOL B on B.ItemSl=O.BOLAddressID"
        strSQL += " and R.[RouteId]=" + RouteId + " "
        strSQL += " and O.BOLAddressID<>0) A"
        strSQL += " order by SL asc "
        Dim comSelect As New SqlCommand(strSQL, _conn)
        If Not _transac Is Nothing Then
            comSelect.Transaction = _transac
        End If

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelect)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelect.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function
    Function SelectOrderSummary(ByVal OrderId As String, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim strSQL As String

        strSQL = tblOrder_Select_Review + " and (h.OrderId = " + OrderId + " ) "

        Dim comSelect As New SqlCommand(strSQL, _conn)
        If Not _transac Is Nothing Then
            comSelect.Transaction = _transac
        End If

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelect)
        'Try
        daSelection.Fill(dt)
        'If dt.Rows.Count = 0 Then
        '    Throw New Exception("No Records Found")
        'End If
        'Catch ex As Exception

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        'Throw ex
        'End Try

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function
    Function SelectOrderDetails(ByVal OrderId As String, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim strSQL As String

        strSQL = QryOrderDetails + " and (D.OrderId = " + OrderId + " ) "

        Dim comSelect As New SqlCommand(strSQL, _conn)
        If Not _transac Is Nothing Then
            comSelect.Transaction = _transac
        End If

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelect)
        'Try
        daSelection.Fill(dt)
        '    If dt.Rows.Count = 0 Then
        '        Throw New Exception("No Records Found")
        '    End If
        'Catch ex As Exception

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        'Throw ex
        '        End Try

        comSelect.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function
End Class
