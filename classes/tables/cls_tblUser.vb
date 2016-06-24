Public Class cls_tblUserDetails
    Public Shared tablename As String = "tblUserDetails"
    Structure Fields
        Dim UserId As Integer
        Dim BranchID As Integer
        Dim UserName As String
        Dim Password As String
        Dim UserType As String
        Dim Status As String
        Dim Enable As Boolean
        Dim LastLoginDate As Date
        Dim EnabledDate As Date
        Dim CreatedDate As Date
        Dim CreatedBy As Integer
        Dim UpdatedDate As Date
        Dim UpdatedBy As Integer
        Dim Session As String
        Dim FullName As String
        Dim Address As String
        Dim City As String
        Dim State As String
        Dim Zip As String
        Dim Phone As String
        Dim Email As String
    End Structure
    Enum FieldName
        UserId
        BranchID
        UserName
        Password
        UserType
        Status
        Enable
        LastLoginDate
        EnabledDate
        CreatedDate
        CreatedBy
        UpdatedDate
        UpdatedBy
        Session
        FullName
        Address
        City
        State
        Zip
        Phone
        Email
    End Enum
    Private ReadOnly Property tblUserDetails_insert
        Get
            Return <tblUserDetails_insert><![CDATA[
INSERT INTO [tblUserDetails]
           ([UserId]
           ,[BranchID]
           ,[UserName]
           ,[Password]
           ,[UserType]
           ,[Status]
           ,[Enable]
           ,[LastLoginDate]
           ,[EnabledDate]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedBy]
           ,[Session]
           ,[FullName]
           ,[Address]
           ,[City]
           ,[State]
           ,[Zip]
           ,[Phone]
           ,[Email])
     VALUES
           (@UserId 
           ,@BranchID 
           ,@UserName 
           ,@Password 
           ,@UserType 
           ,@Status 
           ,@Enable 
           ,@LastLoginDate 
           ,@EnabledDate 
           ,@CreatedDate 
           ,@CreatedBy 
           ,@UpdatedDate 
           ,@UpdatedBy 
           ,@Session 
           ,@FullName 
           ,@Address 
           ,@City 
           ,@State 
           ,@Zip 
           ,@Phone 
           ,@Email )
                    ]]></tblUserDetails_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblUserDetails_update
        Get
            Return <tblUserDetails_update><![CDATA[
   UPDATE
    [tblUserDetails]
   SET [BranchID] = @BranchID 
      ,[UserName] = @UserName 
      ,[Password] = @Password 
      ,[UserType] = @UserType 
      ,[Status] = @Status 
      ,[Enable] = @Enable 
      ,[LastLoginDate] = @LastLoginDate 
      ,[EnabledDate] = @EnabledDate 
      ,[CreatedDate] = @CreatedDate 
      ,[CreatedBy] = @CreatedBy 
      ,[UpdatedDate] = @UpdatedDate 
      ,[UpdatedBy] = @UpdatedBy 
      ,[Session] = @Session 
      ,[FullName] = @FullName 
      ,[Address] = @Address 
      ,[City] = @City 
      ,[State] = @State 
      ,[Zip] = @Zip 
      ,[Phone] = @Phone 
      ,[Email] = @Email 

WHERE
[UserId]=@UserId


                    ]]></tblUserDetails_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblUserDetails_Delete_By_UserId
        Get
            Return <tblUserDetails_Delete><![CDATA[

DELETE FROM
[tblUserDetails] 
WHERE
[UserId]=@UserId
                    ]]></tblUserDetails_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblUserDetails_MAXID
        Get
            Return <tblUserDetails_MAXID><![CDATA[

SELECT MAX([UserId]) FROM [tblUserDetails] WHERE 1=1
                    ]]></tblUserDetails_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblUserDetails_Select
        Get
            Return <tblUserDetails_Select><![CDATA[

SELECT [UserId]
      ,[BranchID]
      ,[UserName]
      ,[Password]
      ,[UserType]
      ,[Status]
      ,[Enable]
      ,[LastLoginDate]
      ,[EnabledDate]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[UpdatedDate]
      ,[UpdatedBy]
      ,[Session]
      ,[FullName]
      ,[Address]
      ,[City]
      ,[State]
      ,[Zip]
      ,[Phone]
      ,[Email]

 FROM [tblUserDetails] 

WHERE 1=1
                    ]]></tblUserDetails_Select>.Value
        End Get
    End Property
    Private ReadOnly Property SelectActiveUsers_Query
        Get
            Return <SelectActiveUsers><![CDATA[
            SELECT UserId, FullName as FullName
            FROM  tblUserDetails
            where Enable=1
            and UserId!=1
                    ]]></SelectActiveUsers>.Value
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

        Dim comMaxID As New SqlCommand(tblUserDetails_MAXID, _conn)
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
                   ByRef BranchID As Integer, _
                    ByRef UserName As String, _
                    ByRef Password As String, _
                    ByRef UserType As String, _
                    ByRef Status As String, _
                    ByRef Enable As Boolean, _
                    ByRef LastLoginDate As Date, _
                    ByRef EnabledDate As Date, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _
                    ByRef Session As String, _
                    ByRef FullName As String, _
                    ByRef Address As String, _
                    ByRef City As String, _
                    ByRef State As String, _
                    ByRef Zip As String, _
                    ByRef Phone As String, _
                    ByRef Email As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim UserId As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblUserDetails_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@UserId", UserId)
            .AddWithValue("@BranchID", BranchID)
            .AddWithValue("@UserName", UserName)
            .AddWithValue("@Password", Password)
            .AddWithValue("@UserType", UserType)
            .AddWithValue("@Status", Status)
            .AddWithValue("@Enable", Enable)
            .AddWithValue("@LastLoginDate", LastLoginDate)
            .AddWithValue("@EnabledDate", EnabledDate)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Session", Session)
            .AddWithValue("@FullName", FullName)
            .AddWithValue("@Address", Address)
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Email", Email)
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
        Return UserId
    End Function

    Function Update(ByVal UserId As Integer, _
                   ByRef BranchID As Integer, _
                    ByRef UserName As String, _
                    ByRef Password As String, _
                    ByRef UserType As String, _
                    ByRef Status As String, _
                    ByRef Enable As Boolean, _
                    ByRef LastLoginDate As Date, _
                    ByRef EnabledDate As Date, _
                    ByRef CreatedDate As Date, _
                    ByRef CreatedBy As Integer, _
                    ByRef UpdatedDate As Date, _
                    ByRef UpdatedBy As Integer, _
                    ByRef Session As String, _
                    ByRef FullName As String, _
                    ByRef Address As String, _
                    ByRef City As String, _
                    ByRef State As String, _
                    ByRef Zip As String, _
                    ByRef Phone As String, _
                    ByRef Email As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblUserDetails_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@BranchID", BranchID)
            .AddWithValue("@UserName", UserName)
            .AddWithValue("@Password", Password)
            .AddWithValue("@UserType", UserType)
            .AddWithValue("@Status", Status)
            .AddWithValue("@Enable", Enable)
            .AddWithValue("@LastLoginDate", LastLoginDate)
            .AddWithValue("@EnabledDate", EnabledDate)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Session", Session)
            .AddWithValue("@FullName", FullName)
            .AddWithValue("@Address", Address)
            .AddWithValue("@City", City)
            .AddWithValue("@State", State)
            .AddWithValue("@Zip", Zip)
            .AddWithValue("@Phone", Phone)
            .AddWithValue("@Email", Email)
            .AddWithValue("@UserId", UserId)
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

        Return UserId
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

        Dim comUpdate As New SqlCommand("Update [tblUserDetails] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

    Function Delete_By_UserId(ByRef UserId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserDetails_Delete_By_UserId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@UserId", UserId)
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
        Return UserId
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
                comSelection.CommandText = tblUserDetails_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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

    Function SelectAcitveUsers(Optional ByVal _selection_type As SelectionType = SelectionType.All, Optional ByVal _SelectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable
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
                comSelection.CommandText = SelectActiveUsers_Query

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

    Function Selection_One_Row(ByVal UserId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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


        comSelection.CommandText = tblUserDetails_Select & " AND [UserId]=@UserId"
        comSelection.Parameters.AddWithValue("@UserId", UserId)
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .UserId = dt.Rows(0).Item("UserId")
                .BranchID = dt.Rows(0).Item("BranchID")
                .UserName = dt.Rows(0).Item("UserName")
                .Password = dt.Rows(0).Item("Password")
                .UserType = dt.Rows(0).Item("UserType")
                .Status = dt.Rows(0).Item("Status")
                .Enable = dt.Rows(0).Item("Enable")
                .LastLoginDate = dt.Rows(0).Item("LastLoginDate")
                .EnabledDate = dt.Rows(0).Item("EnabledDate")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedDate = dt.Rows(0).Item("UpdatedDate")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .Session = dt.Rows(0).Item("Session")
                .FullName = dt.Rows(0).Item("FullName")
                .Address = dt.Rows(0).Item("Address")
                .City = dt.Rows(0).Item("City")
                .State = dt.Rows(0).Item("State")
                .Zip = dt.Rows(0).Item("Zip")
                .Phone = dt.Rows(0).Item("Phone")
                .Email = dt.Rows(0).Item("Email")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & " [tblUserDetails] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT [" & _fieldName.ToString & "] FROM [tblUserDetails] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
    Function CheckLogin(ByVal UserName As String, ByVal Password As String) As Fields
        Dim return_field As New Fields
        Try
            Dim pl As New List(Of SqlParameter)
            pl.Add(New SqlParameter("@UserName", UserName))
            pl.Add(New SqlParameter("@Password", Password))
            Dim dt As DataTable = Selection(cls_tblUserDetails.SelectionType.All, " AND " & cls_tblUserDetails.FieldName.UserName.ToString & " COLLATE Latin1_General_CS_AS =@UserName AND " & cls_tblUserDetails.FieldName.Password.ToString & " COLLATE Latin1_General_CS_AS =@Password  ", pl)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .UserId = dt.Rows(0).Item("UserId")
                .BranchID = dt.Rows(0).Item("BranchID")
                .UserName = dt.Rows(0).Item("UserName")
                .Password = dt.Rows(0).Item("Password")
                .UserType = dt.Rows(0).Item("UserType")
                .Status = dt.Rows(0).Item("Status")
                .Enable = dt.Rows(0).Item("Enable")
                .LastLoginDate = dt.Rows(0).Item("LastLoginDate")
                .EnabledDate = dt.Rows(0).Item("EnabledDate")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedDate = dt.Rows(0).Item("UpdatedDate")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .Session = dt.Rows(0).Item("Session")
                .FullName = dt.Rows(0).Item("FullName")
                .Address = dt.Rows(0).Item("Address")
                .City = dt.Rows(0).Item("City")
                .State = dt.Rows(0).Item("State")
                .Zip = dt.Rows(0).Item("Zip")
                .Phone = dt.Rows(0).Item("Phone")
                .Email = dt.Rows(0).Item("Email")
            End With
        Catch ex As Exception
            Throw ex
        End Try
        Return return_field
    End Function
End Class
