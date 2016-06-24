Public Class cls_tblTemplate
    Public Shared tablename As String = "tblTemplate"
    Structure Fields
        Dim TemplateId As Integer
        Dim TemplateName As String
        Dim CutomerId As Integer
        Dim TotalItems As Integer
        Dim CreatedDate As Date
        Dim CreatedBy As Integer
        Dim UpdatedDate As Date
        Dim UpdatedBy As Integer
        Dim Remarks As String
        Dim Comments As String
    End Structure
    Enum FieldName
        TemplateId
        TemplateName
        CutomerId
        TotalItems
        CreatedDate
        CreatedBy
        UpdatedDate
        UpdatedBy
        Remarks
        Comments
    End Enum

    Private ReadOnly Property tblTemplate_insert
        Get
            Return <tblTemplate_insert><![CDATA[
INSERT INTO [tblTemplate]
           ([TemplateId]
           ,[TemplateName]
           ,[CutomerId]
           ,[TotalItems]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedBy]
           ,[Remarks]
           ,[Comments])
     VALUES
           (@TemplateId 
           ,@TemplateName 
           ,@CutomerId 
           ,@TotalItems 
           ,@CreatedDate 
           ,@CreatedBy 
           ,@UpdatedDate 
           ,@UpdatedBy 
           ,@Remarks 
           ,@Comments )
                    ]]></tblTemplate_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblTemplate_update
        Get
            Return <tblTemplate_update><![CDATA[
UPDATE [tblTemplate]
   SET [TemplateName] = @TemplateName 
      ,[CutomerId] = @CutomerId 
      ,[TotalItems] = @TotalItems 
      ,[CreatedDate] = @CreatedDate 
      ,[CreatedBy] = @CreatedBy 
      ,[UpdatedDate] = @UpdatedDate 
      ,[UpdatedBy] = @UpdatedBy 
      ,[Remarks] = @Remarks 
      ,[Comments] = @Comments 
WHERE
[TemplateId]=@TemplateId


                    ]]></tblTemplate_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblTemplate_Delete_By_TemplateId
        Get
            Return <tblTemplate_Delete><![CDATA[

DELETE FROM
[tblTemplate] 
WHERE
[TemplateId]=@TemplateId
                    ]]></tblTemplate_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblTemplate_Delete_By_SELECT
        Get
            Return <tblTemplate_Delete><![CDATA[

DELETE FROM
[tblTemplate] 
WHERE
1=1
                    ]]></tblTemplate_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblTemplate_MAXID
        Get
            Return <tblTemplate_MAXID><![CDATA[

SELECT MAX([TemplateId]) FROM [tblTemplate] WHERE 1=1
                    ]]></tblTemplate_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblTemplate_Select
        Get
            Return <tblTemplate_Select><![CDATA[
SELECT [TemplateId]
      ,[TemplateName]
      ,[CutomerId]
      ,[TotalItems]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[UpdatedDate]
      ,[UpdatedBy]
      ,[Remarks]
      ,[Comments]

 FROM [tblTemplate] 

WHERE 1=1
                    ]]></tblTemplate_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblTemplate_Select_Review
        Get
            Return <tblTemplate_Select><![CDATA[
SELECT a.[TemplateId]
      ,a.[TemplateName]
      ,a.[CutomerId], Isnull(b.CustomerName ,'Common for all customer') as [CustomerName]
      ,a.[TotalItems]
      ,a.[CreatedDate]
      ,c.UserName as  [CreatedBy]
      ,a.[UpdatedDate]
      ,d.UserName as [UpdatedBy]
      ,a.[Remarks] as [Default]
      ,a.[Comments]

 FROM [tblTemplate] a 
 left outer join tblCustomer b on a.[CutomerId]= b.CustomerID 
 left outer join tblUserDetails c on a.[CreatedBy]= c.UserId 
 left outer join tblUserDetails d on a.[UpdatedBy]= d.UserId 

WHERE 1=1
                    ]]></tblTemplate_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblTemplate_Select_ComboBox1
        Get
            Return <tblTemplate_Select><![CDATA[
SELECT [TemplateId]
      ,[TemplateName] 

 FROM [tblTemplate] 

WHERE 1=1
                    ]]></tblTemplate_Select>.Value
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

        Dim comMaxID As New SqlCommand(tblTemplate_MAXID, _conn)
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
          TemplateName As String, _
          CutomerId As Integer, _
          TotalItems As Integer, _
          CreatedDate As Date, _
          CreatedBy As Integer, _
          UpdatedDate As Date, _
          UpdatedBy As Integer, _
          Remarks As String, _
          Comments As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim TemplateId As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblTemplate_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@TemplateId", TemplateId)
            .AddWithValue("@TemplateName", TemplateName)
            .AddWithValue("@CutomerId", CutomerId)
            .AddWithValue("@TotalItems", TotalItems)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Remarks", Remarks)
            .AddWithValue("@Comments", Comments)

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
        Return TemplateId
    End Function

    Function Update(ByVal TemplateId As Integer, _
          TemplateName As String, _
          CutomerId As Integer, _
          TotalItems As Integer, _
          CreatedDate As Date, _
          CreatedBy As Integer, _
          UpdatedDate As Date, _
          UpdatedBy As Integer, _
          Remarks As String, _
          Comments As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblTemplate_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@TemplateName", TemplateName)
            .AddWithValue("@CutomerId", CutomerId)
            .AddWithValue("@TotalItems", TotalItems)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Remarks", Remarks)
            .AddWithValue("@Comments", Comments)
            .AddWithValue("@TemplateId", TemplateId)
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

        Return TemplateId
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

        Dim comUpdate As New SqlCommand("Update [tblTemplate] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblTemplate_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
    Function Delete_By_TemplateId(ByRef TemplateId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblTemplate_Delete_By_TemplateId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@TemplateId", TemplateId)
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
        Return TemplateId
    End Function
    Enum SelectionType
        All = 0
        ComboBox1 = 1
        All_Review = 2
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
                comSelection.CommandText = tblTemplate_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.ComboBox1
                comSelection.CommandText = tblTemplate_Select_ComboBox1 & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.All_Review
                comSelection.CommandText = tblTemplate_Select_review & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

        End Select

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 And _selection_type <> SelectionType.ComboBox1 Then
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
    Function Selection_One_Row(ByVal TemplateId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblTemplate_Select & " AND [TemplateId]=@TemplateId"
        comSelection.Parameters.AddWithValue("@TemplateId", TemplateId)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .TemplateId = dt.Rows(0).Item("TemplateId")
                .TemplateName = dt.Rows(0).Item("TemplateName")
                .CutomerId = dt.Rows(0).Item("CutomerId")
                .TotalItems = dt.Rows(0).Item("TotalItems")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedDate = dt.Rows(0).Item("UpdatedDate")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .Remarks = dt.Rows(0).Item("Remarks")
                .Comments = dt.Rows(0).Item("Comments")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & "  from [tblTemplate] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & "  from [tblTemplate] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
