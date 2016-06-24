Public Class cls_tblOrderSchedule
    Public Shared tablename As String = "tblOrderSchedule"
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
        Dim ScheduleType As String
        Dim StartDate As Date
        Dim ScheduleInfo As String
        Dim Repeat As Integer
        Dim EndDate As Date
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
        ScheduleType
        StartDate
        ScheduleInfo
        Repeat
        EndDate
    End Enum
    Private ReadOnly Property tblOrderSchedule_insert
        Get
            Return <tblOrderSchedule_insert><![CDATA[
INSERT INTO [tblOrderSchedule]
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
           ,[ScheduleType]
           ,[StartDate]
           ,[ScheduleInfo]
           ,[Repeat]
           ,[EndDate])
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
           ,@ScheduleType
           ,@StartDate
           ,@ScheduleInfo
           ,@Repeat
           ,@EndDate)
                    ]]></tblOrderSchedule_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderSchedule_update
        Get
            Return <tblOrderSchedule_update><![CDATA[
UPDATE [tblOrderSchedule]
   SET [OrderNo] = @OrderNo 
      ,[OrderSl] = @OrderSl 
      ,[OrderDate] = @OrderDate 
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
      ,[ScheduleType] = @ScheduleType 
      ,[StartDate] = @StartDate
      ,[ScheduleInfo] = @ScheduleInfo 
      ,[Repeat] = @Repeat 
      ,[EndDate] = @EndDate 
WHERE
       [OrderId]=@OrderId


                    ]]></tblOrderSchedule_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblOrderSchedule_Delete_By_OrderId
        Get
            Return <tblOrderSchedule_Delete><![CDATA[

DELETE FROM
[tblOrderSchedule] 
WHERE
[OrderId]=@OrderId
                    ]]></tblOrderSchedule_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderSchedule_MAXID
        Get
            Return <tblOrderSchedule_MAXID><![CDATA[

SELECT MAX([OrderId]) FROM [tblOrderSchedule] WHERE 1=1
                    ]]></tblOrderSchedule_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderSchedule_MAXSL
        Get
            Return <tblOrderSchedule_MAXSL><![CDATA[

select isnull(MAX(ordersl),0) from tblOrderSchedule
where DATEPART(Month, orderdate ) =DATEPART(Month, GETDATE() ) and DATEPART(Year, orderdate ) =DATEPART(Year, GETDATE() ) 
                    ]]></tblOrderSchedule_MAXSL>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderSchedule_Select
        Get
            Return <tblOrderSchedule_Select><![CDATA[

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
      ,[ScheduleType]
      ,[StartDate] 
      ,[ScheduleInfo] 
      ,[Repeat] 
      ,[EndDate]  
  FROM [tblOrderSchedule]

WHERE 1=1
                    ]]></tblOrderSchedule_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblOrderSchedule_Select_Review
        Get
            Return <tblOrderSchedule_Select_Review><![CDATA[

SELECT a.[OrderId]
      ,a.[OrderNo]
      ,a.[OrderSl]
      ,a.[OrderDate]
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
      ,''  as Status
      ,a.[StatusDate]
      ,a.[StatusBy]
      ,a.[Remarks]
      ,a.[Comments]
      ,a.[Session]
      ,a.[BranchId]
      ,CASE WHEN f.ItemSl IS NULL THEN '' ELSE f.[DropOffPoint] END as [Drop Off Point]
      ,a.[ScheduleType]
      ,a.[StartDate] 
      ,a.[ScheduleInfo] 
      ,a.[Repeat] 
      ,a.[EndDate]  
  FROM [tblOrderSchedule] a
LEFT OUTER JOIN tblCustomer b ON a.[CutomerId]=b.[CustomerId]
LEFT OUTER JOIN tblUserDetails e on a.UpdatedBy  = e.UserId
LEFT OUTER JOIN (select * from tblCustomer_BOL) f on a.[BOLAddressID] = f.ItemSl
LEFT OUTER JOIN tblUserDetails g on a.CreatedBy  = g.UserId
LEFT OUTER JOIN ( Select a.OrderId , Sum(a.Fresh + a.Frozen) as [Cs] from tblOrderScheduleItems a LEFT OUTER JOIN tblProducts b ON a.ProductId = b.ProductId Where b.UnitOfMeasure='Case(s)' Group By a.OrderId ) h on a.OrderId = h.OrderId 


WHERE 1=1

                    ]]></tblOrderSchedule_Select_Review>.Value
        End Get
    End Property

    Private ReadOnly Property tblOrderSchedule_Select_ScheduledOrder
        Get
            Return <tblOrderSchedule_Select_Review><![CDATA[

SELECT fff.dddddd as [Schedule Date]
      ,a.[OrderId]
      ,a.[OrderNo]
      ,a.[OrderSl]
      ,a.[OrderDate]
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
      ,''  as Status
      ,a.[StatusDate]
      ,a.[StatusBy]
      ,a.[Remarks]
      ,a.[Comments]
      ,a.[Session]
      ,a.[BranchId]
      ,CASE WHEN f.ItemSl IS NULL THEN '' ELSE f.[DropOffPoint] END as [Drop Off Point]
      ,a.[ScheduleType]
      ,a.[StartDate] 
      ,a.[ScheduleInfo] 
      ,a.[Repeat] 
      ,a.[EndDate]  
  FROM [tblOrderSchedule] a
LEFT OUTER JOIN tblCustomer b ON a.[CutomerId]=b.[CustomerId]
LEFT OUTER JOIN tblUserDetails e on a.UpdatedBy  = e.UserId
LEFT OUTER JOIN (select * from tblCustomer_BOL) f on a.[BOLAddressID] = f.ItemSl
LEFT OUTER JOIN tblUserDetails g on a.CreatedBy  = g.UserId
LEFT OUTER JOIN ( Select a.OrderId , Sum(a.Fresh + a.Frozen) as [Cs] from tblOrderScheduleItems a LEFT OUTER JOIN tblProducts b ON a.ProductId = b.ProductId Where b.UnitOfMeasure='Case(s)' Group By a.OrderId ) h on a.OrderId = h.OrderId 
                   ]]></tblOrderSchedule_Select_Review>.Value
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

        Dim comMaxID As New SqlCommand(tblOrderSchedule_MAXID, _conn)
        Select Case type
            Case 0
                comMaxID.CommandText = tblOrderSchedule_MAXID
            Case 1
                comMaxID.CommandText = tblOrderSchedule_MAXSL
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
                    ByRef ScheduleType As String, _
                    ByRef StartDate As Date, _
                    ByRef ScheduleInfo As String, _
                    ByRef Repeat As Integer, _
                    ByRef EndDate As Date, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim OrderId As Integer = MaxID_PlusOne(0, _conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblOrderSchedule_insert, _conn)
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
            .AddWithValue("@ScheduleType", ScheduleType)
            .AddWithValue("@StartDate", StartDate)
            .AddWithValue("@ScheduleInfo", ScheduleInfo)
            .AddWithValue("@Repeat", Repeat)
            .AddWithValue("@EndDate", EndDate) 
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
                    ByRef ScheduleType As String, _
                    ByRef StartDate As Date, _
                    ByRef ScheduleInfo As String, _
                    ByRef Repeat As Integer, _
                    ByRef EndDate As Date, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim comUpdated As New SqlCommand(tblOrderSchedule_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If
        With comUpdated.Parameters
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
            .AddWithValue("@ScheduleType", ScheduleType)
            .AddWithValue("@StartDate", StartDate)
            .AddWithValue("@ScheduleInfo", ScheduleInfo)
            .AddWithValue("@Repeat", Repeat)
            .AddWithValue("@EndDate", EndDate)
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

        Dim comUpdate As New SqlCommand("Update [tblOrderSchedule] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblOrderSchedule_Delete_By_OrderId, _conn)
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
        ScheduledOrder = 2
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
                comSelection.CommandText = tblOrderSchedule_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.ReviewOrder
                comSelection.CommandText = tblOrderSchedule_Select_Review & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.ScheduledOrder
                comSelection.CommandText = tblOrderSchedule_Select_ScheduledOrder & _SelectString 'IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
        comSelection.CommandText = tblOrderSchedule_Select & " AND [OrderId]=@OrderId"
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
                .ScheduleType = dt.Rows(0).Item("ScheduleType")
                .StartDate = dt.Rows(0).Item("StartDate")
                .ScheduleInfo = dt.Rows(0).Item("ScheduleInfo")
                .Repeat = dt.Rows(0).Item("Repeat")
                .EndDate = dt.Rows(0).Item("EndDate")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & " [tblOrderSchedule] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT [" & _fieldName.ToString & "] FROM [tblOrderSchedule] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
