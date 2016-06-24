Public Class cls_tblVendor
    Public Shared tablename As String = "tblVendor"
    Structure Fields
        Dim VendorID As Integer
        Dim VendorName As String
        Dim Address As String 
        Dim City As String
        Dim State As String
        Dim Zip As String
        Dim Notes As String
        Dim Status As String
        Dim CreatedDate As Date
        Dim CreatedBy As Integer
        Dim UpdatedDate As Date
        Dim UpdatedBy As Integer 
        Dim Phone As String
        Dim Email As String
        Dim Website As String
        Dim Fax As String 
    End Structure

    Enum FieldName
        VendorID
        VendorName
        Address 
        City
        State
        Zip
        Notes
        Status
        CreatedDate
        CreatedBy
        UpdatedDate
        UpdatedBy 
        Phone
        Email
        Website
        Fax 
    End Enum


    Private ReadOnly Property tblVendor_insert
        Get
            Return <tblVendor_insert><![CDATA[
INSERT INTO [tblVendor]
           ([VendorID]
           ,[VendorName]
           ,[Address] 
           ,[City]
           ,[State]
           ,[Zip]
           ,[Notes]
           ,[Status]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedBy] 
           ,[Phone]
           ,[Email]
           ,[Website]
           ,[Fax] )
     VALUES
           (@VendorID 
           ,@VendorName 
           ,@Address 
           ,@City 
           ,@State 
           ,@Zip 
           ,@Notes 
           ,@Status 
           ,@CreatedDate 
           ,@CreatedBy 
           ,@UpdatedDate 
           ,@UpdatedBy  
           ,@Phone 
           ,@Email 
           ,@Website  
           ,@Fax  )
                    ]]></tblVendor_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblVendor_update
        Get
            Return <tblVendor_update><![CDATA[
UPDATE [tblVendor]
   SET [VendorName] = @VendorName 
      ,[Address] = @Address 
      ,[City] = @City 
      ,[State] = @State 
      ,[Zip] = @Zip 
      ,[Notes] = @Notes 
      ,[Status] = @Status 
      ,[CreatedDate] = @CreatedDate 
      ,[CreatedBy] = @CreatedBy 
      ,[UpdatedDate] = @UpdatedDate 
      ,[UpdatedBy] = @UpdatedBy  
      ,[Phone] = @Phone
      ,[Email] = @Email
      ,[Website] = @Website
      ,[Fax] = @Fax
WHERE
[VendorID]=@VendorID


                    ]]></tblVendor_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblVendor_Delete_By_VendorID
        Get
            Return <tblVendor_Delete><![CDATA[

DELETE FROM
[tblVendor] 
WHERE
[VendorID]=@VendorID
                    ]]></tblVendor_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblVendor_MAXID
        Get
            Return <tblVendor_MAXID><![CDATA[

SELECT MAX([VendorID]) FROM [tblVendor] WHERE 1=1
                    ]]></tblVendor_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblVendor_Select
        Get
            Return <tblVendor_Select><![CDATA[

SELECT [VendorID]
      ,[VendorName]
      ,[Address] 
      ,[City]
      ,[State]
      ,[Zip]
      ,[Notes]
      ,[Status]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[UpdatedDate]
      ,[UpdatedBy] 
      ,[Phone]
      ,[Email]
      ,[Website]
      ,[Fax] 
  FROM [tblVendor]

WHERE 1=1
                    ]]></tblVendor_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblVendor_MAXID, _conn)
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


    Function Insert(ByRef VendorName As String, _
                    ByRef Address As String, _ 
                    ByRef City As String, _
                    ByRef State As String, _
                    ByRef Zip As String, _
                    ByRef Notes As String, _
                    ByRef Status As String, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _ 
                    ByRef Phone As String, _
                    ByRef Email As String, _
                    ByRef Website As String, _
                    ByRef Fax As String, _ 
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim VendorID As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblVendor_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@VendorID", VendorID)
            .AddWithValue("@VendorName", VendorName)
            .AddWithValue("@Address", Address) 
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Notes", Notes)
            .AddWithValue("@Status", Status)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy) 
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Email", Email)
            .AddWithValue("@Website", Website)
            .AddWithValue("@Fax", Fax) 
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
        Return VendorID
    End Function

    Function Update(ByVal VendorID As Integer, _
                    ByRef VendorName As String, _
                    ByRef Address As String, _ 
                    ByRef City As String, _
                    ByRef State As String, _
                    ByRef Zip As String, _
                    ByRef Notes As String, _
                    ByRef Status As String, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _ 
                    ByRef Phone As String, _
                    ByRef Email As String, _
                    ByRef Website As String, _
                    ByRef Fax As String, _ 
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblVendor_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@VendorName", VendorName)
            .AddWithValue("@Address", Address) 
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Notes", Notes)
            .AddWithValue("@Status", Status)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy) 
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Email", Email)
            .AddWithValue("@Website", Website)
            .AddWithValue("@Fax", Fax) 
            .AddWithValue("@VendorID", VendorID)
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

        Return VendorID
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

        Dim comUpdate As New SqlCommand("Update [tblVendor] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_VendorID(ByRef VendorID As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblVendor_Delete_By_VendorID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@VendorID", VendorID)
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
        Return VendorID
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
                comSelection.CommandText = tblVendor_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
    Function Selection_One_Row(ByVal VendorID As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblVendor_Select & " AND [VendorID]=@VendorID"
        comSelection.Parameters.AddWithValue("@VendorID", VendorID)
        Dim daSelection As New SqlDataAdapter(comSelection)

        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .VendorID = dt.Rows(0).Item("VendorID")
                .VendorName = dt.Rows(0).Item("VendorName")
                .Address = dt.Rows(0).Item("Address")
                .City = dt.Rows(0).Item("City")
                .State = dt.Rows(0).Item("State")
                .Zip = dt.Rows(0).Item("Zip")
                .Notes = dt.Rows(0).Item("Notes")
                .Status = dt.Rows(0).Item("Status")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedDate = dt.Rows(0).Item("UpdatedDate")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .Phone = dt.Rows(0).Item("Phone")
                .Email = dt.Rows(0).Item("Email")
                .Website = dt.Rows(0).Item("Website")
                .Fax = dt.Rows(0).Item("Fax")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & " [tblVendor] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & " FROM [tblVendor] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
