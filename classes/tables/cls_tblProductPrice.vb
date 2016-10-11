Public Class cls_tblProductPrice

    Public Shared tablename As String = "tblProductPrice"

    Structure Fields
        Dim ItemSl As Integer
        Dim PID As Integer
        Dim CostPrice As Decimal
        Dim SellPrice As Decimal
        Dim EntryDate As Date
        Dim UserId As Integer
        Dim VendorId As Integer
        Dim UnitOfMesuare As String
        Dim VendorItemCode As String

    End Structure

    Enum FieldName
        ItemSl
        PID
        CostPrice
        SellPrice
        EntryDate
        UserId
        VendorId
        UnitOfMesuare
        VendorItemCode
    End Enum

    Private ReadOnly Property tblProductPrice_insert
        Get
            Return <tblProductPrice_insert><![CDATA[

INSERT INTO [tblProductPrice]
           ([ItemSl]
           ,[PID]
           ,[CostPrice]
           ,[SellPrice]
           ,[EntryDate]
           ,[UserId]
           ,[VendorId]
           ,[UnitOfMesuare]
           ,[VendorItemCode])
     VALUES
           (@ItemSl 
           ,@PID 
           ,@CostPrice 
           ,@SellPrice 
           ,@EntryDate 
           ,@UserId 
           ,@VendorId 
           ,@UnitOfMesuare 
           ,@VendorItemCode )

                    ]]></tblProductPrice_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblProductPrice_update
        Get
            Return <tblProductPrice_update><![CDATA[
                UPDATE [tblProductPrice]
                   SET [PID] = @PID 
                      ,[CostPrice] = @CostPrice 
                      ,[SellPrice] = @SellPrice 
                      ,[EntryDate] = @EntryDate 
                      ,[UserId] = @UserId 
                      ,[VendorId] = @VendorId 
                      ,[UnitOfMesuare] = @UnitOfMesuare 
                      ,[VendorItemCode] = @VendorItemCode 

                WHERE
                [ItemSl]=@ItemSl
            ]]></tblProductPrice_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblProductPrice_Delete_By_ItemSl
        Get
            Return <tblProductPrice_Delete><![CDATA[

DELETE FROM
[tblProductPrice] 
WHERE
[ItemSl]=@ItemSl
                    ]]></tblProductPrice_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblProductPrice_Delete_By_SELECT
        Get
            Return <tblProductPrice_Delete><![CDATA[

DELETE FROM
[tblProductPrice] 
WHERE
1=1
                    ]]></tblProductPrice_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblProductPrice_MAXID
        Get
            Return <tblProductPrice_MAXID><![CDATA[

SELECT MAX([ItemSl]) FROM [tblProductPrice] WHERE 1=1
                    ]]></tblProductPrice_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblProductPrice_Select
        Get
            Return <tblProductPrice_Select><![CDATA[

SELECT 

            [ItemSl]
           ,[PID]
           ,[CostPrice]
           ,[SellPrice]
           ,[EntryDate]
           ,[UserId]
           ,[VendorId]
           ,[UnitOfMesuare]
           ,[VendorItemCode]

 FROM [tblProductPrice] 

WHERE 1=1
                    ]]></tblProductPrice_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblProductPrice_Select_User
        Get
            Return <tblProductPrice_Select><![CDATA[
SELECT 
            [ItemSl]
           ,[PID]
           ,[CostPrice]
           ,[SellPrice]
           ,[EntryDate]
           ,a.[UserId]
           ,b.[UserName]
           ,'' as [ ]

FROM [tblProductPrice] a
left outer join 
tblUserDetails b
on a.UserId = b.UserId 

WHERE 1=1
                    ]]></tblProductPrice_Select>.Value
        End Get
    End Property

    'NOTE: Future Order will show the Sum of OUT Stock Type after the Current Date/Time that is passed via the Parrameter 'StockTill'
    Private ReadOnly Property tblProductPrice_Select_Product
        Get
            Return <tblProductPrice_Select><![CDATA[
SELECT a.[ProductId]
      ,a.[ProductCode] as [Code]
      ,a.[ProductName]
      ,a.[FullName]
      ,a.[Brand]
      ,a.[Category]
      ,a.[SubCategory]
      ,a.[Price]
      ,a.[UnitOfMeasure]
      ,a.[DateCreated]
      ,a.[DateUpdated]
      ,a.[CreatedBy]
      ,a.[UpdatedBy]
      ,a.[Enabled]
      ,isnull(b.CostPrice ,0) as [Cost Price]
      ,isnull(b.SellPrice ,0) as [Selling Price]
      ,isnull(b.CostPrice ,0) as [lc]
      ,isnull(b.SellPrice ,0) as [ls]
      ,isnull(b.ItemSl,0) as ItemSl
      ,isnull(b.[VendorId],0) as [VendorId]
      ,isnull(b.[UnitOfMesuare],a.[UnitOfMeasure]) as [UnitOfMesuare2]
      ,isnull(b.[VendorItemCode],'') as [VendorItemCode]
      ,isnull(b.[VendorId],0) as [vi]
      ,isnull(f.[VendorName],'') as [vi2]
      ,isnull(b.[UnitOfMesuare],a.[UnitOfMeasure]) as [um2]
      ,isnull(b.[VendorItemCode],'') as [vc]
      ,ISNULL(c.qty,0) as [StockQty]
      ,ISNULL(c.Fresh,0) as [FreshStock]
      ,ISNULL(c.Frozen,0) as [FrozenStock]
      ,convert(varchar,ISNULL(-d.Fresh,0)) + ',' + convert(varchar,ISNULL(-d.Frozen,0)) as [Future Orders]
      ,convert(varchar,ISNULL(-d.Frozen,0)) as [Future FZ]
      ,ISNULL(e.TargetQty ,0) as [Target Stock Levels]
      --,(select Category + ' : ' + CONVERT(varchar,qty) + ', ' from tblSubStock where ProductId=a.ProductId for XML path('')) as [Frozen Qty Detail]
  FROM [tblProducts] a 
   left outer join 

  (select * from [tblProductPrice] where ItemSl in (Select MAX(itemsl) from tblProductPrice group by PID )) b
    on a.ProductId = b.PID 
    left outer join
    (select sum( case when stocktype='IN' then  qty else -1 * qty end) as qty,sum( case when stocktype='IN' then  Fresh else -1 * Fresh end) as Fresh,sum( case when stocktype='IN' then  Frozen else -1 * Frozen end) as Frozen, productid from tblStock Where TransactionDate<=@StockTill group by ProductId ) c 
    on a.ProductId = c.ProductId 
    left outer join
    (select sum( case when stocktype='IN' then  qty*0 else -1 * qty end) as qty,sum( case when stocktype='IN' then  Fresh*0 else -1 * Fresh end) as Fresh,sum( case when stocktype='IN' then Frozen*0 else -1 * Frozen end) as Frozen, productid from tblStock Where TransactionDate>@StockTill group by ProductId ) d 
    on a.ProductId = d.ProductId 
    left outer join 
    (select * from tblTarget where ItemSl in (select MAX(itemsl) from tblTarget group by productid)) e on a.ProductId = e.ProductId 
    left outer join 
    tblVendor f on b.[VendorId] = f.VendorID 
    

Where 1=1
    
                    ]]></tblProductPrice_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblProductPrice_MAXID, _conn)
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
              PID As Integer, _
              CostPrice As Decimal, _
              SellPrice As Decimal, _
              EntryDate As Date, _
              UserId As Integer, _
              VendorId As Integer, _
              UnitOfMesuare As String, _
              VendorItemCode As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer



        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblProductPrice_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl", ItemSl)
            .AddWithValue("@PID", PID)
            .AddWithValue("@CostPrice", CostPrice)
            .AddWithValue("@SellPrice", SellPrice)
            .AddWithValue("@EntryDate", EntryDate)
            .AddWithValue("@UserId", UserId)
            .AddWithValue("@VendorId", VendorId)
            .AddWithValue("@UnitOfMesuare", UnitOfMesuare)
            .AddWithValue("@VendorItemCode", VendorItemCode)
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
              PID As Integer, _
              CostPrice As Decimal, _
              SellPrice As Decimal, _
              EntryDate As Date, _
              UserId As Integer, _
              VendorId As Integer, _
              UnitOfMesuare As String, _
              VendorItemCode As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblProductPrice_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@PID", PID)
            .AddWithValue("@CostPrice", CostPrice)
            .AddWithValue("@SellPrice", SellPrice)
            .AddWithValue("@EntryDate", EntryDate)
            .AddWithValue("@UserId", UserId)
            .AddWithValue("@VendorId", VendorId)
            .AddWithValue("@UnitOfMesuare", UnitOfMesuare)
            .AddWithValue("@VendorItemCode", VendorItemCode)
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

        Dim comUpdate As New SqlCommand("Update [tblProductPrice] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblProductPrice_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
    Function Delete_By_ItemSl(ByRef ItemSl As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblProductPrice_Delete_By_ItemSl, _conn)
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
    Enum SelectionType
        All = 0
        All_Product = 1
        All_With_user = 2
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
                comSelection.CommandText = tblProductPrice_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.All_Product
                comSelection.CommandText = tblProductPrice_Select_Product & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.All_With_user
                comSelection.CommandText = tblProductPrice_Select_User & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
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
        comSelection.CommandText = tblProductPrice_Select & " AND [ItemSl]=@ItemSl"
        comSelection.Parameters.AddWithValue("@ItemSl", ItemSl)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .ItemSl = dt.Rows(0).Item("ItemSl")
                .PID = dt.Rows(0).Item("PID")
                .CostPrice = dt.Rows(0).Item("CostPrice")
                .SellPrice = dt.Rows(0).Item("SellPrice")
                .EntryDate = dt.Rows(0).Item("EntryDate")
                .UserId = dt.Rows(0).Item("UserId")
                .VendorId = dt.Rows(0).Item("VendorId")
                .UnitOfMesuare = dt.Rows(0).Item("UnitOfMesuare")
                .VendorItemCode = dt.Rows(0).Item("VendorItemCode")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & "  from [tblProductPrice] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & "  from [tblProductPrice] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
