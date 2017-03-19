Public Class cls_tblRoute
    Public Shared tablename As String = "tblRoute"
    Structure Fields
        Dim RouteId As Integer
        Dim RouteDate As Date
        Dim CreatedBy As Integer
        Dim CreatedOn As Date
        Dim UpdatedBy As Integer
        Dim UpdatedOn As Date
        Dim RouteCity As String
        Dim TotalOrder As Integer
        Dim OrderDate As Date
        Dim TotalItems As Integer
        Dim Truck As String
        Dim Driver As String
        Dim OtherInfos As String
        Dim Comments As String
    End Structure
    Enum FieldName
        RouteId
        RouteDate
        CreatedBy
        CreatedOn
        UpdatedBy
        UpdatedOn
        RouteCity
        TotalOrder
        OrderDate
        TotalItems
        Truck
        Driver
        OtherInfos
        Comments
    End Enum
    Private ReadOnly Property tblRoute_insert
        Get
            Return <tblRoute_insert><![CDATA[
INSERT INTO [tblRoute]
           ([RouteId]
           ,[RouteDate]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[UpdatedBy]
           ,[UpdatedOn]
           ,[RouteCity]
           ,[TotalOrder]
           ,[OrderDate]
           ,[TotalItems]
           ,[Truck]
           ,[Driver]
           ,[OtherInfos]
           ,[Comments])
     VALUES
           (@RouteId 
           ,@RouteDate 
           ,@CreatedBy 
           ,@CreatedOn 
           ,@UpdatedBy 
           ,@UpdatedOn 
           ,@RouteCity 
           ,@TotalOrder 
           ,@OrderDate 
           ,@TotalItems 
           ,@Truck 
           ,@Driver 
           ,@OtherInfos 
           ,@Comments )
                    ]]></tblRoute_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblRoute_update
        Get
            Return <tblRoute_update><![CDATA[
UPDATE [tblRoute]
   SET [RouteDate] = @RouteDate 
      ,[CreatedBy] = @CreatedBy 
      ,[CreatedOn] = @CreatedOn 
      ,[UpdatedBy] = @UpdatedBy 
      ,[UpdatedOn] = @UpdatedOn 
      ,[RouteCity] = @RouteCity 
      ,[TotalOrder] = @TotalOrder 
      ,[OrderDate] = @OrderDate 
      ,[TotalItems] = @TotalItems 
      ,[Truck] = @Truck 
      ,[Driver] = @Driver 
      ,[OtherInfos] = @OtherInfos 
      ,[Comments] = @Comments 
WHERE
[RouteId]=@RouteId


                    ]]></tblRoute_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblRoute_Delete_By_RouteId
        Get
            Return <tblRoute_Delete><![CDATA[

DELETE FROM
[tblRoute] 
WHERE
[RouteId]=@RouteId
                    ]]></tblRoute_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblRoute_MAXID
        Get
            Return <tblRoute_MAXID><![CDATA[

SELECT MAX([RouteId]) FROM [tblRoute] WHERE 1=1
                    ]]></tblRoute_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblRoute_Select
        Get
            Return <tblRoute_Select><![CDATA[

SELECT [RouteId]
      ,[RouteDate]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[RouteCity]
      ,[TotalOrder]
      ,[OrderDate]
      ,[TotalItems]
      ,[Truck]
      ,[Driver]
      ,[OtherInfos]
      ,[Comments]
  FROM [tblRoute] 

WHERE 1=1
                    ]]></tblRoute_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblRoute_Select_Review
        Get
            Return <tblRoute_Select><![CDATA[

SELECT a.[RouteId]
      ,a.[OtherInfos]
      ,a.[RouteDate]
       ,a.[OrderDate]
      ,a.[RouteCity]
      ,a.[TotalOrder]
      ,isnull(h.Cs2,0) as [TotalItems] 
      ,isnull(h.Cs,0) as [Total Cases]
        ,isnull(h.Cs,0) as [TotalCases]
      ,a.[Truck]
      ,a.[Driver]
      ,a.[Comments]
   ,g.[UserName] as [CreatedBy]
      ,a.[CreatedOn]
      ,e.[UserName] as [UpdatedBy] 
     ,a.[UpdatedOn]
     FROM [tblRoute]  a 
LEFT OUTER JOIN tblUserDetails e on a.UpdatedBy  = e.UserId 
LEFT OUTER JOIN tblUserDetails g on a.CreatedBy  = g.UserId
LEFT OUTER JOIN ( Select a1.RouteID  , sum(case when b.UnitOfMeasure='Case(s)' then  a.Fresh + a.Frozen else 0 end ) as [Cs],sum(a.Fresh + a.Frozen) as [Cs2] from tblRouteOrders a1 left outer join tblOrderItems a on a1.OrderId = a.OrderId  LEFT OUTER JOIN tblProducts b ON a.ProductId = b.ProductId Group By a1.RouteID ) h on a.RouteID = h.RouteID 


WHERE 1=1
                    ]]></tblRoute_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblRoute_MAXID, _conn)
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


    Function Insert(
        ByVal RouteDate As Date, _
        ByVal CreatedBy As Integer, _
        ByVal CreatedOn As Date, _
        ByVal UpdatedBy As Integer, _
        ByVal UpdatedOn As Date, _
        ByVal RouteCity As String, _
        ByVal TotalOrder As Integer, _
        ByVal OrderDate As Date, _
        ByVal TotalItems As Integer, _
        ByVal Truck As String, _
        ByVal Driver As String, _
        ByVal OtherInfos As String, _
        ByVal Comments As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim RouteId As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblRoute_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@RouteId", RouteId)
            .AddWithValue("@RouteDate", RouteDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@CreatedOn", CreatedOn)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@UpdatedOn", UpdatedOn)
            .AddWithValue("@RouteCity", RouteCity)
            .AddWithValue("@TotalOrder", TotalOrder)
            .AddWithValue("@OrderDate", OrderDate)
            .AddWithValue("@TotalItems", TotalItems)
            .AddWithValue("@Truck", Truck)
            .AddWithValue("@Driver", Driver)
            .AddWithValue("@OtherInfos", OtherInfos)
            .AddWithValue("@Comments", Comments)
            '.AddWithValue("@", )
            '.AddWithValue("@", )
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
        Return RouteId
    End Function

    Function Update(ByVal RouteId As Integer, _
                    ByVal RouteDate As Date, _
                    ByVal CreatedBy As Integer, _
                    ByVal CreatedOn As Date, _
                    ByVal UpdatedBy As Integer, _
                    ByVal UpdatedOn As Date, _
                    ByVal RouteCity As String, _
                    ByVal TotalOrder As Integer, _
                    ByVal OrderDate As Date, _
                    ByVal TotalItems As Integer, _
                    ByVal Truck As String, _
                    ByVal Driver As String, _
                    ByVal OtherInfos As String, _
                    ByVal Comments As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblRoute_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@RouteDate", RouteDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@CreatedOn", CreatedOn)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@UpdatedOn", UpdatedOn)
            .AddWithValue("@RouteCity", RouteCity)
            .AddWithValue("@TotalOrder", TotalOrder)
            .AddWithValue("@OrderDate", OrderDate)
            .AddWithValue("@TotalItems", TotalItems)
            .AddWithValue("@Truck", Truck)
            .AddWithValue("@Driver", Driver)
            .AddWithValue("@OtherInfos", OtherInfos)
            .AddWithValue("@Comments", Comments)
            .AddWithValue("@RouteId", RouteId)
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

        Return RouteId
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

        Dim comUpdate As New SqlCommand("Update [tblRoute] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_RouteId(ByRef RouteId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblRoute_Delete_By_RouteId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@RouteId", RouteId)
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
        Return RouteId
    End Function

    Enum SelectionType
        All = 0
        Review = 1
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
                comSelection.CommandText = tblRoute_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.Review
                comSelection.CommandText = tblRoute_Select_Review & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
    Function Selection_One_Row(ByVal RouteId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblRoute_Select & " AND [RouteId]=@RouteId"
        comSelection.Parameters.AddWithValue("@RouteId", RouteId)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .RouteId = dt.Rows(0).Item("RouteId")
                .RouteDate = dt.Rows(0).Item("RouteDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .CreatedOn = dt.Rows(0).Item("CreatedOn")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .UpdatedOn = dt.Rows(0).Item("UpdatedOn")
                .RouteCity = dt.Rows(0).Item("RouteCity")
                .TotalOrder = dt.Rows(0).Item("TotalOrder")
                .OrderDate = dt.Rows(0).Item("OrderDate")
                .TotalItems = dt.Rows(0).Item("TotalItems")
                .Truck = dt.Rows(0).Item("Truck")
                .Driver = dt.Rows(0).Item("Driver")
                .OtherInfos = dt.Rows(0).Item("OtherInfos")
                .Comments = dt.Rows(0).Item("Comments")
                '. = dt.Rows(0).Item("") 
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & "  from [tblRoute] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & "  from [tblRoute] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
