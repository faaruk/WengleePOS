Public Class cls_tblCustomer

    Public Shared tablename As String = "tblCustomer"

    Structure Fields
        Dim CustomerID As Integer
        Dim CustomerName As String
        Dim Address As String
        Dim RouteCity As String
        Dim Route As String
        Dim City As String
        Dim State As String
        Dim Zip As String
        Dim Notes As String
        Dim Status As String
        Dim CreatedDate As Date
        Dim CreatedBy As Integer
        Dim UpdatedDate As Date
        Dim UpdatedBy As Integer
        Dim ClientSince As Date
        Dim Phone As String
        Dim Email As String
        Dim Website As String
        Dim Fax As String
        Dim BOL As String
        Dim CustomerId_Link As String
        Dim Longt As String
        Dim Latt As String
        Dim NCR_ID As String
        Dim Receiving_CutOff As String
        Dim Cod As Boolean
    End Structure

    Enum FieldName
        CustomerID
        CustomerName
        Address
        RouteCity
        Route
        City
        State
        Zip
        Notes
        Status
        CreatedDate
        CreatedBy
        UpdatedDate
        UpdatedBy
        ClientSince
        Phone
        Email
        Website
        Fax
        BOL
        CustomerId_Link
        Longt
        Latt
        NCR_ID
        Receiving_CutOff
        Cod
    End Enum
    Private ReadOnly Property tblCustomer_insert
        Get
            Return <tblCustomer_insert><![CDATA[
INSERT INTO [tblCustomer]
           ([CustomerID]
           ,[CustomerName]
           ,[Address]
           ,[RouteCity]
           ,[Route]
           ,[City]
           ,[State]
           ,[Zip]
           ,[Notes]
           ,[Status]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedBy]
           ,[ClientSince]
           ,[Phone]
           ,[Email]
           ,[Website]
           ,[Fax]
           ,[BOL]
         ,[CustomerId_Link]
         ,[Longt]
         ,[Latt]
         ,[NCR_ID]
         ,[Receiving_CutOff]
        , Cod)
     VALUES
           (@CustomerID 
           ,@CustomerName 
           ,@Address 
           ,@RouteCity 
           ,@Route 
           ,@City 
           ,@State 
           ,@Zip 
           ,@Notes 
           ,@Status 
           ,@CreatedDate 
           ,@CreatedBy 
           ,@UpdatedDate 
           ,@UpdatedBy 
           ,@ClientSince
           ,@Phone 
           ,@Email 
           ,@Website  
           ,@Fax 
           ,@BOL
        ,@CustomerId_Link
        ,@Longt
        ,@Latt
        ,@NCR_ID
        ,@Receiving_CutOff
        , @Cod )
                    ]]></tblCustomer_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_update
        Get
            Return <tblCustomer_update><![CDATA[
UPDATE [tblCustomer]
   SET [CustomerName] = @CustomerName 
      ,[Address] = @Address 
      ,[RouteCity] = @RouteCity 
      ,[Route] = @Route 
      ,[City] = @City 
      ,[State] = @State 
      ,[Zip] = @Zip 
      ,[Notes] = @Notes 
      ,[Status] = @Status 
      ,[CreatedDate] = @CreatedDate 
      ,[CreatedBy] = @CreatedBy 
      ,[UpdatedDate] = @UpdatedDate 
      ,[UpdatedBy] = @UpdatedBy 
      ,[ClientSince] = @ClientSince 
      ,[Phone] = @Phone
      ,[Email] = @Email
      ,[Website] = @Website
      ,[Fax] = @Fax
      ,[BOL] = @BOL
         ,[CustomerId_Link]=@CustomerId_Link
         ,[Longt]=@Longt
         ,[Latt]=@Latt
         ,[NCR_ID]=@NCR_ID
         ,[Receiving_CutOff]=@Receiving_CutOff
        ,[Cod]=@Cod
WHERE
[CustomerID]=@CustomerID


                    ]]></tblCustomer_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblCustomer_Delete_By_CustomerID
        Get
            Return <tblCustomer_Delete><![CDATA[

DELETE FROM
[tblCustomer] 
WHERE
[CustomerID]=@CustomerID
                    ]]></tblCustomer_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_MAXID
        Get
            Return <tblCustomer_MAXID><![CDATA[

SELECT MAX([CustomerID]) FROM [tblCustomer] WHERE 1=1
                    ]]></tblCustomer_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_Select
        Get
            Return <tblCustomer_Select><![CDATA[
SELECT 
         [CustomerID]
        ,[NCR_ID]
        ,[Cod]
        ,[CustomerName]
        ,[Address]
      ,[RouteCity]
      ,[Route]
      ,[City]
      ,[State]
      ,[Zip]
      ,[Notes]
      ,[Status]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[UpdatedDate]
      ,[UpdatedBy]
      ,[ClientSince]
      ,[Phone]
      ,[Email]
      ,[Website]
      ,[Fax]
      ,[BOL]
         ,[CustomerId_Link]
         ,[Longt]
         ,[Latt]
         ,[Receiving_CutOff]  
  FROM [tblCustomer]

WHERE 1=1
                    ]]></tblCustomer_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblCustomer_Select_GetBolID
        Get
            Return <tblCustomer_Select><![CDATA[

select BOLAddressID  from 
tblOrder a 
left outer join tblCustomer b on a.CutomerId = b.CustomerID 
where a.CutomerId = @CustomerID and b.BOL ='YES' and Orderid in (select MAX(OrderId) from tblOrder group by CutomerId)
                    ]]></tblCustomer_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblCustomer_MAXID, _conn)
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
    Function GetBolID(CustomerID As Integer) As Integer
        Dim BolID As Integer = 0
        Dim objConn As clsConnection = Nothing
        objConn = New clsConnection
        Dim _conn As SqlConnection = objConn.connect
        Dim com As New SqlCommand(tblCustomer_Select_GetBolID, _conn)
        com.Parameters.AddWithValue("@CustomerId", CustomerID)
        Try
            BolID = com.ExecuteScalar
        Catch ex As Exception
        End Try
        Return BolID
    End Function

    Function Insert(ByRef CustomerName As String, _
                    ByRef Address As String, _
                    ByRef RouteCity As String, _
                    ByRef Route As String, _
                    ByRef City As String, _
                    ByRef State As String, _
                    ByRef Zip As String, _
                    ByRef Notes As String, _
                    ByRef Status As String, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _
                    ByRef ClientSince As Date, _
                    ByRef Phone As String, _
                    ByRef Email As String, _
                    ByRef Website As String, _
                    ByRef Fax As String, _
                    ByRef BOL As String, _
          ByRef CustomerId_Link As String, _
         ByRef Longt As String, _
          ByRef Latt As String, _
          ByRef NCR_ID As String, _
          ByRef Receiving_CutOff As String, ByRef Cod As Boolean, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim CustomerID As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblCustomer_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@CustomerID", CustomerID)
            .AddWithValue("@CustomerName", CustomerName)
            .AddWithValue("@Address", Address)
            .AddWithValue("@RouteCity", RouteCity)
            .AddWithValue("@Route", Route)
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Notes", Notes)
            .AddWithValue("@Status", Status)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@ClientSince", ClientSince)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Email", Email)
            .AddWithValue("@Website", Website)
            .AddWithValue("@Fax", Fax)
            .AddWithValue("@BOL", BOL)
            .AddWithValue("@CustomerId_Link", CustomerId_Link)
            .AddWithValue("@Longt", Longt)
            .AddWithValue("@Latt", Latt)
            .AddWithValue("@NCR_ID", NCR_ID)
            .AddWithValue("@Receiving_CutOff", Receiving_CutOff)
            .AddWithValue("@Cod", Cod)
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
        Return CustomerID
    End Function

    Function Update(ByVal CustomerID As Integer, _
                    ByRef CustomerName As String, _
                    ByRef Address As String, _
                    ByRef RouteCity As String, _
                    ByRef Route As String, _
                    ByRef City As String, _
                    ByRef State As String, _
                    ByRef Zip As String, _
                    ByRef Notes As String, _
                    ByRef Status As String, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _
                    ByRef ClientSince As Date, _
                    ByRef Phone As String, _
                    ByRef Email As String, _
                    ByRef Website As String, _
                    ByRef Fax As String, _
                    ByRef BOL As String, _
          ByRef CustomerId_Link As String, _
         ByRef Longt As String, _
          ByRef Latt As String, _
          ByRef NCR_ID As String, _
          ByRef Receiving_CutOff As String, ByRef Cod As Boolean, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblCustomer_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@CustomerName", CustomerName)
            .AddWithValue("@Address", Address)
            .AddWithValue("@RouteCity", RouteCity)
            .AddWithValue("@Route", Route)
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Notes", Notes)
            .AddWithValue("@Status", Status)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@ClientSince", ClientSince)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Email", Email)
            .AddWithValue("@Website", Website)
            .AddWithValue("@Fax", Fax)
            .AddWithValue("@BOL", BOL)
            .AddWithValue("@CustomerId_Link", CustomerId_Link)
            .AddWithValue("@Longt", Longt)
            .AddWithValue("@Latt", Latt)
            .AddWithValue("@NCR_ID", NCR_ID)
            .AddWithValue("@Receiving_CutOff", Receiving_CutOff)
            .AddWithValue("@Cod", Cod)
            .AddWithValue("@CustomerID", CustomerID)
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

        Return CustomerID
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

        Dim comUpdate As New SqlCommand("Update [tblCustomer] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_CustomerID(ByRef CustomerID As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCustomer_Delete_By_CustomerID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@CustomerID", CustomerID)
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
        Return CustomerID
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
                comSelection.CommandText = tblCustomer_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
    Function Selection_One_Row(ByVal CustomerID As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblCustomer_Select & " AND [CustomerID]=@CustomerID"
        comSelection.Parameters.AddWithValue("@CustomerID", CustomerID)
        Dim daSelection As New SqlDataAdapter(comSelection)

        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .CustomerID = dt.Rows(0).Item("CustomerID")
                .CustomerName = dt.Rows(0).Item("CustomerName")
                .Address = dt.Rows(0).Item("Address")
                .RouteCity = dt.Rows(0).Item("RouteCity")
                .Route = dt.Rows(0).Item("Route")
                .City = dt.Rows(0).Item("City")
                .State = dt.Rows(0).Item("State")
                .Zip = dt.Rows(0).Item("Zip")
                .Notes = dt.Rows(0).Item("Notes")
                .Status = dt.Rows(0).Item("Status")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedDate = dt.Rows(0).Item("UpdatedDate")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .ClientSince = dt.Rows(0).Item("ClientSince")
                .Phone = dt.Rows(0).Item("Phone")
                .Email = dt.Rows(0).Item("Email")
                .Website = dt.Rows(0).Item("Website")
                .Fax = dt.Rows(0).Item("Fax")
                .BOL = dt.Rows(0).Item("BOL")
                .CustomerId_Link = dt.Rows(0).Item("CustomerId_Link")
                .Longt = dt.Rows(0).Item("Longt")
                .Latt = dt.Rows(0).Item("Latt")
                .NCR_ID = dt.Rows(0).Item("NCR_ID")
                .Receiving_CutOff = dt.Rows(0).Item("Receiving_CutOff")
                .Cod = dt.Rows(0).Item("Cod")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & " [tblCustomer] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & " FROM [tblCustomer] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
