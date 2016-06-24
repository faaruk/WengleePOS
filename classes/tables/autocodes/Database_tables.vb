'Class Version : 1.0.0.2
'Created Dated : 21/09/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Imports System.Data



Public Class Database_Table_code_class_tblUserRules
    Public Shared tablename As String = "tblUserRules"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim RuleName_ As String
        Dim Enabled_ As Boolean
        Dim CreatedDate_ As DateTime
        Dim UserID_ As Int32

    End Structure


    Enum FieldName


        [ItemSl]
        [RuleName]
        [Enabled]
        [CreatedDate]
        [UserID]

    End Enum


    Public ReadOnly Property tblUserRules_insert
        Get
            Return <tblUserRules_insert><![CDATA[
  INSERT INTO [tblUserRules]
  (
      [ItemSl],
      [RuleName],
      [Enabled],
      [CreatedDate],
      [UserID]
  )
  VALUES
  (
      @ItemSl_,
      @RuleName_,
      @Enabled_,
      @CreatedDate_,
      @UserID_
  )
]]></tblUserRules_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_update
        Get
            Return <tblUserRules_update><![CDATA[
UPDATE [tblUserRules]
Set 
    [RuleName]=@RuleName_,
    [Enabled]=@Enabled_,
    [CreatedDate]=@CreatedDate_,
    [UserID]=@UserID_
 WHERE [ItemSl]=@ItemSl_
]]></tblUserRules_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblUserRules_select
        Get
            Return <tblUserRules_select><![CDATA[
SELECT 
      [ItemSl],
      [RuleName],
      [Enabled],
      [CreatedDate],
      [UserID]
FROM [tblUserRules]
    WHERE 1=1
]]></tblUserRules_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_Delete_By_RowID
        Get
            Return <tblUserRules_Delete_By_RowID><![CDATA[
DELETE FROM [tblUserRules] WHERE [ItemSl]=@ItemSl_
]]></tblUserRules_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_Delete_By_SELECT
        Get
            Return <tblUserRules_Delete_By_SELECT><![CDATA[
DELETE FROM [tblUserRules] WHERE 1=1
]]></tblUserRules_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_MAXID
        Get
            Return <tblUserRules_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblUserRules] WHERE 1=1
]]></tblUserRules_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblUserRules_MAXID, _conn)
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
    ByVal RuleName_ As String, _
    ByVal Enabled_ As Boolean, _
    ByVal CreatedDate_ As DateTime, _
    ByVal UserID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblUserRules_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@RuleName_", RuleName_)
            .AddWithValue("@Enabled_", Enabled_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UserID_", UserID_)

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
        Return ItemSl_
    End Function



    Function Update(
    ByVal RuleName_ As String, _
    ByVal Enabled_ As Boolean, _
    ByVal CreatedDate_ As DateTime, _
    ByVal UserID_ As Int32, _
    ByVal ItemSl_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblUserRules_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@RuleName_", RuleName_)
            .AddWithValue("@Enabled_", Enabled_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@ItemSl_", ItemSl_)

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

        Return ItemSl_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.RuleName
                fn = "RuleName"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblUserRules] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblUserRules_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserRules_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

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
        Return ItemSl_
    End Function



    Function Selection_One_Row( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblUserRules_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("RuleName") Is DBNull.Value Then : .RuleName_ = dt.Rows(0).Item("RuleName") : End If
                If Not dt.Rows(0).Item("Enabled") Is DBNull.Value Then : .Enabled_ = dt.Rows(0).Item("Enabled") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblUserRules_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("RuleName") Is DBNull.Value Then : .RuleName_ = dt.Rows(0).Item("RuleName") : End If
                If Not dt.Rows(0).Item("Enabled") Is DBNull.Value Then : .Enabled_ = dt.Rows(0).Item("Enabled") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.RuleName
                fn = "RuleName"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblUserRules] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.RuleName
                fn = "RuleName"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblUserRules] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblUserLoginInfo
    Public Shared tablename As String = "tblUserLoginInfo"


    Structure Fields


        Dim ItemSL_ As Int32
        Dim UserID_ As Int32
        Dim LoginDate_ As DateTime
        Dim LogoutDate_ As DateTime

    End Structure


    Enum FieldName


        [ItemSL]
        [UserID]
        [LoginDate]
        [LogoutDate]

    End Enum


    Public ReadOnly Property tblUserLoginInfo_insert
        Get
            Return <tblUserLoginInfo_insert><![CDATA[
  INSERT INTO [tblUserLoginInfo]
  (
      [ItemSL],
      [UserID],
      [LoginDate],
      [LogoutDate]
  )
  VALUES
  (
      @ItemSL_,
      @UserID_,
      @LoginDate_,
      @LogoutDate_
  )
]]></tblUserLoginInfo_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_update
        Get
            Return <tblUserLoginInfo_update><![CDATA[
UPDATE [tblUserLoginInfo]
Set 
    [UserID]=@UserID_,
    [LoginDate]=@LoginDate_,
    [LogoutDate]=@LogoutDate_
 WHERE [ItemSL]=@ItemSL_
]]></tblUserLoginInfo_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblUserLoginInfo_select
        Get
            Return <tblUserLoginInfo_select><![CDATA[
SELECT 
      [ItemSL],
      [UserID],
      [LoginDate],
      [LogoutDate]
FROM [tblUserLoginInfo]
    WHERE 1=1
]]></tblUserLoginInfo_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_Delete_By_RowID
        Get
            Return <tblUserLoginInfo_Delete_By_RowID><![CDATA[
DELETE FROM [tblUserLoginInfo] WHERE [ItemSL]=@ItemSL_
]]></tblUserLoginInfo_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_Delete_By_SELECT
        Get
            Return <tblUserLoginInfo_Delete_By_SELECT><![CDATA[
DELETE FROM [tblUserLoginInfo] WHERE 1=1
]]></tblUserLoginInfo_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_MAXID
        Get
            Return <tblUserLoginInfo_MAXID><![CDATA[
SELECT MAX([ItemSL]) FROM [tblUserLoginInfo] WHERE 1=1
]]></tblUserLoginInfo_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblUserLoginInfo_MAXID, _conn)
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
    ByVal UserID_ As Int32, _
    ByVal LoginDate_ As DateTime, _
    ByVal LogoutDate_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSL_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblUserLoginInfo_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSL_", ItemSL_)
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@LoginDate_", LoginDate_)
            .AddWithValue("@LogoutDate_", LogoutDate_)

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
        Return ItemSL_
    End Function



    Function Update(
    ByVal UserID_ As Int32, _
    ByVal LoginDate_ As DateTime, _
    ByVal LogoutDate_ As DateTime, _
    ByVal ItemSL_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblUserLoginInfo_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@LoginDate_", LoginDate_)
            .AddWithValue("@LogoutDate_", LogoutDate_)
            .AddWithValue("@ItemSL_", ItemSL_)

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

        Return ItemSL_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSL
                fn = "ItemSL"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.LoginDate
                fn = "LoginDate"
            Case FieldName.LogoutDate
                fn = "LogoutDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblUserLoginInfo] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblUserLoginInfo_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemSL_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserLoginInfo_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSL_", ItemSL_)

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
        Return ItemSL_
    End Function



    Function Selection_One_Row( _
     ByVal ItemSL_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblUserLoginInfo_select & "  AND [ItemSL]=@ItemSL_"

        With comSelection.Parameters
            .AddWithValue("@ItemSL_", ItemSL_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSL") Is DBNull.Value Then : .ItemSL_ = dt.Rows(0).Item("ItemSL") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
                If Not dt.Rows(0).Item("LoginDate") Is DBNull.Value Then : .LoginDate_ = dt.Rows(0).Item("LoginDate") : End If
                If Not dt.Rows(0).Item("LogoutDate") Is DBNull.Value Then : .LogoutDate_ = dt.Rows(0).Item("LogoutDate") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblUserLoginInfo_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSL") Is DBNull.Value Then : .ItemSL_ = dt.Rows(0).Item("ItemSL") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
                If Not dt.Rows(0).Item("LoginDate") Is DBNull.Value Then : .LoginDate_ = dt.Rows(0).Item("LoginDate") : End If
                If Not dt.Rows(0).Item("LogoutDate") Is DBNull.Value Then : .LogoutDate_ = dt.Rows(0).Item("LogoutDate") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSL
                fn = "ItemSL"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.LoginDate
                fn = "LoginDate"
            Case FieldName.LogoutDate
                fn = "LogoutDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblUserLoginInfo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSL
                fn = "ItemSL"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.LoginDate
                fn = "LoginDate"
            Case FieldName.LogoutDate
                fn = "LogoutDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblUserLoginInfo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblSession
    Public Shared tablename As String = "tblSession"


    Structure Fields


        Dim SessionName_ As String
        Dim IsDefault_ As Boolean
        Dim CreatedBy_ As Int32
        Dim CreadtedOn_ As DateTime

    End Structure


    Enum FieldName


        [SessionName]
        [IsDefault]
        [CreatedBy]
        [CreadtedOn]

    End Enum


    Public ReadOnly Property tblSession_insert
        Get
            Return <tblSession_insert><![CDATA[
  INSERT INTO [tblSession]
  (
      [SessionName],
      [IsDefault],
      [CreatedBy],
      [CreadtedOn]
  )
  VALUES
  (
      @SessionName_,
      @IsDefault_,
      @CreatedBy_,
      @CreadtedOn_
  )
]]></tblSession_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblSession_update
        Get
            Return <tblSession_update><![CDATA[
UPDATE [tblSession]
Set 
    [IsDefault]=@IsDefault_,
    [CreatedBy]=@CreatedBy_,
    [CreadtedOn]=@CreadtedOn_
 WHERE [SessionName]=@SessionName_
]]></tblSession_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblSession_select
        Get
            Return <tblSession_select><![CDATA[
SELECT 
      [SessionName],
      [IsDefault],
      [CreatedBy],
      [CreadtedOn]
FROM [tblSession]
    WHERE 1=1
]]></tblSession_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblSession_Delete_By_RowID
        Get
            Return <tblSession_Delete_By_RowID><![CDATA[
DELETE FROM [tblSession] WHERE [SessionName]=@SessionName_
]]></tblSession_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblSession_Delete_By_SELECT
        Get
            Return <tblSession_Delete_By_SELECT><![CDATA[
DELETE FROM [tblSession] WHERE 1=1
]]></tblSession_Delete_By_SELECT>.Value
        End Get
    End Property


    Function Insert( _
    ByVal SessionName_ As String, _
    ByVal IsDefault_ As Boolean, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreadtedOn_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing


        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblSession_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@SessionName_", SessionName_)
            .AddWithValue("@IsDefault_", IsDefault_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreadtedOn_", CreadtedOn_)

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
        Return 0
    End Function



    Function Update(
    ByVal IsDefault_ As Boolean, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreadtedOn_ As DateTime, _
    ByVal SessionName_ As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblSession_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@IsDefault_", IsDefault_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreadtedOn_", CreadtedOn_)
            .AddWithValue("@SessionName_", SessionName_)

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

        Return 0
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SessionName
                fn = "SessionName"
            Case FieldName.IsDefault
                fn = "IsDefault"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreadtedOn
                fn = "CreadtedOn"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblSession] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblSession_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal SessionName_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblSession_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@SessionName_", SessionName_)

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
        Return 0
    End Function



    Function Selection_One_Row( _
     ByVal SessionName_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblSession_select & "  AND [SessionName]=@SessionName_"

        With comSelection.Parameters
            .AddWithValue("@SessionName_", SessionName_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("SessionName") Is DBNull.Value Then : .SessionName_ = dt.Rows(0).Item("SessionName") : End If
                If Not dt.Rows(0).Item("IsDefault") Is DBNull.Value Then : .IsDefault_ = dt.Rows(0).Item("IsDefault") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreadtedOn") Is DBNull.Value Then : .CreadtedOn_ = dt.Rows(0).Item("CreadtedOn") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblSession_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("SessionName") Is DBNull.Value Then : .SessionName_ = dt.Rows(0).Item("SessionName") : End If
                If Not dt.Rows(0).Item("IsDefault") Is DBNull.Value Then : .IsDefault_ = dt.Rows(0).Item("IsDefault") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreadtedOn") Is DBNull.Value Then : .CreadtedOn_ = dt.Rows(0).Item("CreadtedOn") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SessionName
                fn = "SessionName"
            Case FieldName.IsDefault
                fn = "IsDefault"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreadtedOn
                fn = "CreadtedOn"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblSession] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SessionName
                fn = "SessionName"
            Case FieldName.IsDefault
                fn = "IsDefault"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreadtedOn
                fn = "CreadtedOn"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblSession] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblSettings
    Public Shared tablename As String = "tblSettings"


    Structure Fields


        Dim ItemId_ As Int32
        Dim CompanyName_ As String
        Dim Address_ As String
        Dim Phone_ As String
        Dim Fax_ As String
        Dim Website_ As String
        Dim email_ As String
        Dim OrderPrinterName_ As String
        Dim PrintOrder_ As Boolean
        Dim ReportPrinterName_ As String

    End Structure


    Enum FieldName


        [ItemId]
        [CompanyName]
        [Address]
        [Phone]
        [Fax]
        [Website]
        [email]
        [OrderPrinterName]
        [PrintOrder]
        [ReportPrinterName]

    End Enum


    Public ReadOnly Property tblSettings_insert
        Get
            Return <tblSettings_insert><![CDATA[
  INSERT INTO [tblSettings]
  (
      [ItemId],
      [CompanyName],
      [Address],
      [Phone],
      [Fax],
      [Website],
      [email],
      [OrderPrinterName],
      [PrintOrder],
      [ReportPrinterName]
  )
  VALUES
  (
      @ItemId_,
      @CompanyName_,
      @Address_,
      @Phone_,
      @Fax_,
      @Website_,
      @email_,
      @OrderPrinterName_,
      @PrintOrder_,
      @ReportPrinterName_
  )
]]></tblSettings_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_update
        Get
            Return <tblSettings_update><![CDATA[
UPDATE [tblSettings]
Set 
    [CompanyName]=@CompanyName_,
    [Address]=@Address_,
    [Phone]=@Phone_,
    [Fax]=@Fax_,
    [Website]=@Website_,
    [email]=@email_,
    [OrderPrinterName]=@OrderPrinterName_,
    [PrintOrder]=@PrintOrder_,
    [ReportPrinterName]=@ReportPrinterName_
 WHERE [ItemId]=@ItemId_
]]></tblSettings_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblSettings_select
        Get
            Return <tblSettings_select><![CDATA[
SELECT 
      [ItemId],
      [CompanyName],
      [Address],
      [Phone],
      [Fax],
      [Website],
      [email],
      [OrderPrinterName],
      [PrintOrder],
      [ReportPrinterName]
FROM [tblSettings]
    WHERE 1=1
]]></tblSettings_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_Delete_By_RowID
        Get
            Return <tblSettings_Delete_By_RowID><![CDATA[
DELETE FROM [tblSettings] WHERE [ItemId]=@ItemId_
]]></tblSettings_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_Delete_By_SELECT
        Get
            Return <tblSettings_Delete_By_SELECT><![CDATA[
DELETE FROM [tblSettings] WHERE 1=1
]]></tblSettings_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_MAXID
        Get
            Return <tblSettings_MAXID><![CDATA[
SELECT MAX([ItemId]) FROM [tblSettings] WHERE 1=1
]]></tblSettings_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblSettings_MAXID, _conn)
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
    ByVal CompanyName_ As String, _
    ByVal Address_ As String, _
    ByVal Phone_ As String, _
    ByVal Fax_ As String, _
    ByVal Website_ As String, _
    ByVal email_ As String, _
    ByVal OrderPrinterName_ As String, _
    ByVal PrintOrder_ As Boolean, _
    ByVal ReportPrinterName_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblSettings_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemId_", ItemId_)
            .AddWithValue("@CompanyName_", CompanyName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Fax_", Fax_)
            .AddWithValue("@Website_", Website_)
            .AddWithValue("@email_", email_)
            .AddWithValue("@OrderPrinterName_", OrderPrinterName_)
            .AddWithValue("@PrintOrder_", PrintOrder_)
            .AddWithValue("@ReportPrinterName_", ReportPrinterName_)

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
        Return ItemId_
    End Function



    Function Update(
    ByVal CompanyName_ As String, _
    ByVal Address_ As String, _
    ByVal Phone_ As String, _
    ByVal Fax_ As String, _
    ByVal Website_ As String, _
    ByVal email_ As String, _
    ByVal OrderPrinterName_ As String, _
    ByVal PrintOrder_ As Boolean, _
    ByVal ReportPrinterName_ As String, _
    ByVal ItemId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblSettings_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@CompanyName_", CompanyName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Fax_", Fax_)
            .AddWithValue("@Website_", Website_)
            .AddWithValue("@email_", email_)
            .AddWithValue("@OrderPrinterName_", OrderPrinterName_)
            .AddWithValue("@PrintOrder_", PrintOrder_)
            .AddWithValue("@ReportPrinterName_", ReportPrinterName_)
            .AddWithValue("@ItemId_", ItemId_)

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

        Return ItemId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.CompanyName
                fn = "CompanyName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.email
                fn = "email"
            Case FieldName.OrderPrinterName
                fn = "OrderPrinterName"
            Case FieldName.PrintOrder
                fn = "PrintOrder"
            Case FieldName.ReportPrinterName
                fn = "ReportPrinterName"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblSettings] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblSettings_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblSettings_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId_", ItemId_)

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
        Return ItemId_
    End Function



    Function Selection_One_Row( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblSettings_select & "  AND [ItemId]=@ItemId_"

        With comSelection.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("CompanyName") Is DBNull.Value Then : .CompanyName_ = dt.Rows(0).Item("CompanyName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
                If Not dt.Rows(0).Item("Website") Is DBNull.Value Then : .Website_ = dt.Rows(0).Item("Website") : End If
                If Not dt.Rows(0).Item("email") Is DBNull.Value Then : .email_ = dt.Rows(0).Item("email") : End If
                If Not dt.Rows(0).Item("OrderPrinterName") Is DBNull.Value Then : .OrderPrinterName_ = dt.Rows(0).Item("OrderPrinterName") : End If
                If Not dt.Rows(0).Item("PrintOrder") Is DBNull.Value Then : .PrintOrder_ = dt.Rows(0).Item("PrintOrder") : End If
                If Not dt.Rows(0).Item("ReportPrinterName") Is DBNull.Value Then : .ReportPrinterName_ = dt.Rows(0).Item("ReportPrinterName") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblSettings_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("CompanyName") Is DBNull.Value Then : .CompanyName_ = dt.Rows(0).Item("CompanyName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
                If Not dt.Rows(0).Item("Website") Is DBNull.Value Then : .Website_ = dt.Rows(0).Item("Website") : End If
                If Not dt.Rows(0).Item("email") Is DBNull.Value Then : .email_ = dt.Rows(0).Item("email") : End If
                If Not dt.Rows(0).Item("OrderPrinterName") Is DBNull.Value Then : .OrderPrinterName_ = dt.Rows(0).Item("OrderPrinterName") : End If
                If Not dt.Rows(0).Item("PrintOrder") Is DBNull.Value Then : .PrintOrder_ = dt.Rows(0).Item("PrintOrder") : End If
                If Not dt.Rows(0).Item("ReportPrinterName") Is DBNull.Value Then : .ReportPrinterName_ = dt.Rows(0).Item("ReportPrinterName") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.CompanyName
                fn = "CompanyName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.email
                fn = "email"
            Case FieldName.OrderPrinterName
                fn = "OrderPrinterName"
            Case FieldName.PrintOrder
                fn = "PrintOrder"
            Case FieldName.ReportPrinterName
                fn = "ReportPrinterName"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblSettings] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.CompanyName
                fn = "CompanyName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.email
                fn = "email"
            Case FieldName.OrderPrinterName
                fn = "OrderPrinterName"
            Case FieldName.PrintOrder
                fn = "PrintOrder"
            Case FieldName.ReportPrinterName
                fn = "ReportPrinterName"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblSettings] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblBranch
    Public Shared tablename As String = "tblBranch"


    Structure Fields


        Dim BranchID_ As Int32
        Dim BranchName_ As String
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32

    End Structure


    Enum FieldName


        [BranchID]
        [BranchName]
        [CreatedDate]
        [CreatedBy]

    End Enum


    Public ReadOnly Property tblBranch_insert
        Get
            Return <tblBranch_insert><![CDATA[
  INSERT INTO [tblBranch]
  (
      [BranchID],
      [BranchName],
      [CreatedDate],
      [CreatedBy]
  )
  VALUES
  (
      @BranchID_,
      @BranchName_,
      @CreatedDate_,
      @CreatedBy_
  )
]]></tblBranch_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblBranch_update
        Get
            Return <tblBranch_update><![CDATA[
UPDATE [tblBranch]
Set 
    [BranchName]=@BranchName_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_
 WHERE [BranchID]=@BranchID_
]]></tblBranch_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblBranch_select
        Get
            Return <tblBranch_select><![CDATA[
SELECT 
      [BranchID],
      [BranchName],
      [CreatedDate],
      [CreatedBy]
FROM [tblBranch]
    WHERE 1=1
]]></tblBranch_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblBranch_Delete_By_RowID
        Get
            Return <tblBranch_Delete_By_RowID><![CDATA[
DELETE FROM [tblBranch] WHERE [BranchID]=@BranchID_
]]></tblBranch_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBranch_Delete_By_SELECT
        Get
            Return <tblBranch_Delete_By_SELECT><![CDATA[
DELETE FROM [tblBranch] WHERE 1=1
]]></tblBranch_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBranch_MAXID
        Get
            Return <tblBranch_MAXID><![CDATA[
SELECT MAX([BranchID]) FROM [tblBranch] WHERE 1=1
]]></tblBranch_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblBranch_MAXID, _conn)
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
    ByVal BranchName_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim BranchID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblBranch_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@BranchID_", BranchID_)
            .AddWithValue("@BranchName_", BranchName_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)

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
        Return BranchID_
    End Function



    Function Update(
    ByVal BranchName_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal BranchID_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblBranch_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@BranchName_", BranchName_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@BranchID_", BranchID_)

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

        Return BranchID_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.BranchName
                fn = "BranchName"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblBranch] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblBranch_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal BranchID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBranch_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@BranchID_", BranchID_)

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
        Return BranchID_
    End Function



    Function Selection_One_Row( _
     ByVal BranchID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblBranch_select & "  AND [BranchID]=@BranchID_"

        With comSelection.Parameters
            .AddWithValue("@BranchID_", BranchID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("BranchID") Is DBNull.Value Then : .BranchID_ = dt.Rows(0).Item("BranchID") : End If
                If Not dt.Rows(0).Item("BranchName") Is DBNull.Value Then : .BranchName_ = dt.Rows(0).Item("BranchName") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblBranch_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("BranchID") Is DBNull.Value Then : .BranchID_ = dt.Rows(0).Item("BranchID") : End If
                If Not dt.Rows(0).Item("BranchName") Is DBNull.Value Then : .BranchName_ = dt.Rows(0).Item("BranchName") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.BranchName
                fn = "BranchName"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblBranch] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.BranchName
                fn = "BranchName"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblBranch] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblUserDetails
    Public Shared tablename As String = "tblUserDetails"


    Structure Fields


        Dim UserId_ As Int32
        Dim BranchID_ As Int32
        Dim UserName_ As String
        Dim Password_ As String
        Dim UserType_ As String
        Dim Status_ As String
        Dim Enable_ As Boolean
        Dim LastLoginDate_ As DateTime
        Dim EnabledDate_ As DateTime
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim Session_ As String
        Dim FullName_ As String
        Dim Address_ As String
        Dim City_ As String
        Dim State_ As String
        Dim Zip_ As String
        Dim Phone_ As String
        Dim Email_ As String

    End Structure


    Enum FieldName


        [UserId]
        [BranchID]
        [UserName]
        [Password]
        [UserType]
        [Status]
        [Enable]
        [LastLoginDate]
        [EnabledDate]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [Session]
        [FullName]
        [Address]
        [City]
        [State]
        [Zip]
        [Phone]
        [Email]

    End Enum


    Public ReadOnly Property tblUserDetails_insert
        Get
            Return <tblUserDetails_insert><![CDATA[
  INSERT INTO [tblUserDetails]
  (
      [UserId],
      [BranchID],
      [UserName],
      [Password],
      [UserType],
      [Status],
      [Enable],
      [LastLoginDate],
      [EnabledDate],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Session],
      [FullName],
      [Address],
      [City],
      [State],
      [Zip],
      [Phone],
      [Email]
  )
  VALUES
  (
      @UserId_,
      @BranchID_,
      @UserName_,
      @Password_,
      @UserType_,
      @Status_,
      @Enable_,
      @LastLoginDate_,
      @EnabledDate_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @Session_,
      @FullName_,
      @Address_,
      @City_,
      @State_,
      @Zip_,
      @Phone_,
      @Email_
  )
]]></tblUserDetails_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_update
        Get
            Return <tblUserDetails_update><![CDATA[
UPDATE [tblUserDetails]
Set 
    [BranchID]=@BranchID_,
    [UserName]=@UserName_,
    [Password]=@Password_,
    [UserType]=@UserType_,
    [Status]=@Status_,
    [Enable]=@Enable_,
    [LastLoginDate]=@LastLoginDate_,
    [EnabledDate]=@EnabledDate_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [Session]=@Session_,
    [FullName]=@FullName_,
    [Address]=@Address_,
    [City]=@City_,
    [State]=@State_,
    [Zip]=@Zip_,
    [Phone]=@Phone_,
    [Email]=@Email_
 WHERE [UserId]=@UserId_
]]></tblUserDetails_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblUserDetails_select
        Get
            Return <tblUserDetails_select><![CDATA[
SELECT 
      [UserId],
      [BranchID],
      [UserName],
      [Password],
      [UserType],
      [Status],
      [Enable],
      [LastLoginDate],
      [EnabledDate],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Session],
      [FullName],
      [Address],
      [City],
      [State],
      [Zip],
      [Phone],
      [Email]
FROM [tblUserDetails]
    WHERE 1=1
]]></tblUserDetails_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_Delete_By_RowID
        Get
            Return <tblUserDetails_Delete_By_RowID><![CDATA[
DELETE FROM [tblUserDetails] WHERE [UserId]=@UserId_
]]></tblUserDetails_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_Delete_By_SELECT
        Get
            Return <tblUserDetails_Delete_By_SELECT><![CDATA[
DELETE FROM [tblUserDetails] WHERE 1=1
]]></tblUserDetails_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_MAXID
        Get
            Return <tblUserDetails_MAXID><![CDATA[
SELECT MAX([UserId]) FROM [tblUserDetails] WHERE 1=1
]]></tblUserDetails_MAXID>.Value
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
    ByVal BranchID_ As Int32, _
    ByVal UserName_ As String, _
    ByVal Password_ As String, _
    ByVal UserType_ As String, _
    ByVal Status_ As String, _
    ByVal Enable_ As Boolean, _
    ByVal LastLoginDate_ As DateTime, _
    ByVal EnabledDate_ As DateTime, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Session_ As String, _
    ByVal FullName_ As String, _
    ByVal Address_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Phone_ As String, _
    ByVal Email_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim UserId_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@BranchID_", BranchID_)
            .AddWithValue("@UserName_", UserName_)
            .AddWithValue("@Password_", Password_)
            .AddWithValue("@UserType_", UserType_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Enable_", Enable_)
            .AddWithValue("@LastLoginDate_", LastLoginDate_)
            .AddWithValue("@EnabledDate_", EnabledDate_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)

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
        Return UserId_
    End Function



    Function Update(
    ByVal BranchID_ As Int32, _
    ByVal UserName_ As String, _
    ByVal Password_ As String, _
    ByVal UserType_ As String, _
    ByVal Status_ As String, _
    ByVal Enable_ As Boolean, _
    ByVal LastLoginDate_ As DateTime, _
    ByVal EnabledDate_ As DateTime, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Session_ As String, _
    ByVal FullName_ As String, _
    ByVal Address_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Phone_ As String, _
    ByVal Email_ As String, _
    ByVal UserId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@BranchID_", BranchID_)
            .AddWithValue("@UserName_", UserName_)
            .AddWithValue("@Password_", Password_)
            .AddWithValue("@UserType_", UserType_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Enable_", Enable_)
            .AddWithValue("@LastLoginDate_", LastLoginDate_)
            .AddWithValue("@EnabledDate_", EnabledDate_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@UserId_", UserId_)

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

        Return UserId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.UserName
                fn = "UserName"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.UserType
                fn = "UserType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Enable
                fn = "Enable"
            Case FieldName.LastLoginDate
                fn = "LastLoginDate"
            Case FieldName.EnabledDate
                fn = "EnabledDate"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblUserDetails] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblUserDetails_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal UserId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserDetails_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@UserId_", UserId_)

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
        Return UserId_
    End Function



    Function Selection_One_Row( _
     ByVal UserId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblUserDetails_select & "  AND [UserId]=@UserId_"

        With comSelection.Parameters
            .AddWithValue("@UserId_", UserId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("BranchID") Is DBNull.Value Then : .BranchID_ = dt.Rows(0).Item("BranchID") : End If
                If Not dt.Rows(0).Item("UserName") Is DBNull.Value Then : .UserName_ = dt.Rows(0).Item("UserName") : End If
                If Not dt.Rows(0).Item("Password") Is DBNull.Value Then : .Password_ = dt.Rows(0).Item("Password") : End If
                If Not dt.Rows(0).Item("UserType") Is DBNull.Value Then : .UserType_ = dt.Rows(0).Item("UserType") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Enable") Is DBNull.Value Then : .Enable_ = dt.Rows(0).Item("Enable") : End If
                If Not dt.Rows(0).Item("LastLoginDate") Is DBNull.Value Then : .LastLoginDate_ = dt.Rows(0).Item("LastLoginDate") : End If
                If Not dt.Rows(0).Item("EnabledDate") Is DBNull.Value Then : .EnabledDate_ = dt.Rows(0).Item("EnabledDate") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblUserDetails_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("BranchID") Is DBNull.Value Then : .BranchID_ = dt.Rows(0).Item("BranchID") : End If
                If Not dt.Rows(0).Item("UserName") Is DBNull.Value Then : .UserName_ = dt.Rows(0).Item("UserName") : End If
                If Not dt.Rows(0).Item("Password") Is DBNull.Value Then : .Password_ = dt.Rows(0).Item("Password") : End If
                If Not dt.Rows(0).Item("UserType") Is DBNull.Value Then : .UserType_ = dt.Rows(0).Item("UserType") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Enable") Is DBNull.Value Then : .Enable_ = dt.Rows(0).Item("Enable") : End If
                If Not dt.Rows(0).Item("LastLoginDate") Is DBNull.Value Then : .LastLoginDate_ = dt.Rows(0).Item("LastLoginDate") : End If
                If Not dt.Rows(0).Item("EnabledDate") Is DBNull.Value Then : .EnabledDate_ = dt.Rows(0).Item("EnabledDate") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.UserName
                fn = "UserName"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.UserType
                fn = "UserType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Enable
                fn = "Enable"
            Case FieldName.LastLoginDate
                fn = "LastLoginDate"
            Case FieldName.EnabledDate
                fn = "EnabledDate"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblUserDetails] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.UserName
                fn = "UserName"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.UserType
                fn = "UserType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Enable
                fn = "Enable"
            Case FieldName.LastLoginDate
                fn = "LastLoginDate"
            Case FieldName.EnabledDate
                fn = "EnabledDate"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblUserDetails] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblOrderStatus
    Public Shared tablename As String = "tblOrderStatus"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim OrderId_ As Int32
        Dim Status_ As String
        Dim Reason_ As String
        Dim Comments_ As String
        Dim CreatedDate_ As DateTime
        Dim StatusDate_ As DateTime
        Dim CreatedBy_ As Int32

    End Structure


    Enum FieldName


        [ItemSl]
        [OrderId]
        [Status]
        [Reason]
        [Comments]
        [CreatedDate]
        [StatusDate]
        [CreatedBy]

    End Enum


    Public ReadOnly Property tblOrderStatus_insert
        Get
            Return <tblOrderStatus_insert><![CDATA[
  INSERT INTO [tblOrderStatus]
  (
      [ItemSl],
      [OrderId],
      [Status],
      [Reason],
      [Comments],
      [CreatedDate],
      [StatusDate],
      [CreatedBy]
  )
  VALUES
  (
      @ItemSl_,
      @OrderId_,
      @Status_,
      @Reason_,
      @Comments_,
      @CreatedDate_,
      @StatusDate_,
      @CreatedBy_
  )
]]></tblOrderStatus_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderStatus_update
        Get
            Return <tblOrderStatus_update><![CDATA[
UPDATE [tblOrderStatus]
Set 
    [OrderId]=@OrderId_,
    [Status]=@Status_,
    [Reason]=@Reason_,
    [Comments]=@Comments_,
    [CreatedDate]=@CreatedDate_,
    [StatusDate]=@StatusDate_,
    [CreatedBy]=@CreatedBy_
 WHERE [ItemSl]=@ItemSl_
]]></tblOrderStatus_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblOrderStatus_select
        Get
            Return <tblOrderStatus_select><![CDATA[
SELECT 
      [ItemSl],
      [OrderId],
      [Status],
      [Reason],
      [Comments],
      [CreatedDate],
      [StatusDate],
      [CreatedBy]
FROM [tblOrderStatus]
    WHERE 1=1
]]></tblOrderStatus_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderStatus_Delete_By_RowID
        Get
            Return <tblOrderStatus_Delete_By_RowID><![CDATA[
DELETE FROM [tblOrderStatus] WHERE [ItemSl]=@ItemSl_
]]></tblOrderStatus_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderStatus_Delete_By_SELECT
        Get
            Return <tblOrderStatus_Delete_By_SELECT><![CDATA[
DELETE FROM [tblOrderStatus] WHERE 1=1
]]></tblOrderStatus_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderStatus_MAXID
        Get
            Return <tblOrderStatus_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblOrderStatus] WHERE 1=1
]]></tblOrderStatus_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblOrderStatus_MAXID, _conn)
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
    ByVal OrderId_ As Int32, _
    ByVal Status_ As String, _
    ByVal Reason_ As String, _
    ByVal Comments_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal StatusDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblOrderStatus_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Reason_", Reason_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@StatusDate_", StatusDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)

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
        Return ItemSl_
    End Function



    Function Update(
    ByVal OrderId_ As Int32, _
    ByVal Status_ As String, _
    ByVal Reason_ As String, _
    ByVal Comments_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal StatusDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal ItemSl_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblOrderStatus_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Reason_", Reason_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@StatusDate_", StatusDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@ItemSl_", ItemSl_)

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

        Return ItemSl_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Reason
                fn = "Reason"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblOrderStatus] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblOrderStatus_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrderStatus_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

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
        Return ItemSl_
    End Function



    Function Selection_One_Row( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderStatus_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Reason") Is DBNull.Value Then : .Reason_ = dt.Rows(0).Item("Reason") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("StatusDate") Is DBNull.Value Then : .StatusDate_ = dt.Rows(0).Item("StatusDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderStatus_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Reason") Is DBNull.Value Then : .Reason_ = dt.Rows(0).Item("Reason") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("StatusDate") Is DBNull.Value Then : .StatusDate_ = dt.Rows(0).Item("StatusDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Reason
                fn = "Reason"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblOrderStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Reason
                fn = "Reason"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblOrderStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblState
    Public Shared tablename As String = "tblState"


    Structure Fields


        Dim Code_ As String
        Dim StateName_ As String

    End Structure


    Enum FieldName


        [Code]
        [StateName]

    End Enum


    Public ReadOnly Property tblState_insert
        Get
            Return <tblState_insert><![CDATA[
  INSERT INTO [tblState]
  (
      [Code],
      [StateName]
  )
  VALUES
  (
      @Code_,
      @StateName_
  )
]]></tblState_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblState_update
        Get
            Return <tblState_update><![CDATA[
UPDATE [tblState]
Set 
    [StateName]=@StateName_
 WHERE [Code]=@Code_
]]></tblState_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblState_select
        Get
            Return <tblState_select><![CDATA[
SELECT 
      [Code],
      [StateName]
FROM [tblState]
    WHERE 1=1
]]></tblState_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblState_Delete_By_RowID
        Get
            Return <tblState_Delete_By_RowID><![CDATA[
DELETE FROM [tblState] WHERE [Code]=@Code_
]]></tblState_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblState_Delete_By_SELECT
        Get
            Return <tblState_Delete_By_SELECT><![CDATA[
DELETE FROM [tblState] WHERE 1=1
]]></tblState_Delete_By_SELECT>.Value
        End Get
    End Property


    Function Insert( _
    ByVal Code_ As String, _
    ByVal StateName_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing


        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblState_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Code_", Code_)
            .AddWithValue("@StateName_", StateName_)

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
        Return 0
    End Function



    Function Update(
    ByVal StateName_ As String, _
    ByVal Code_ As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblState_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@StateName_", StateName_)
            .AddWithValue("@Code_", Code_)

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

        Return 0
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Code
                fn = "Code"
            Case FieldName.StateName
                fn = "StateName"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblState] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblState_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal Code_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblState_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Code_", Code_)

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
        Return 0
    End Function



    Function Selection_One_Row( _
     ByVal Code_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblState_select & "  AND [Code]=@Code_"

        With comSelection.Parameters
            .AddWithValue("@Code_", Code_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Code") Is DBNull.Value Then : .Code_ = dt.Rows(0).Item("Code") : End If
                If Not dt.Rows(0).Item("StateName") Is DBNull.Value Then : .StateName_ = dt.Rows(0).Item("StateName") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblState_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Code") Is DBNull.Value Then : .Code_ = dt.Rows(0).Item("Code") : End If
                If Not dt.Rows(0).Item("StateName") Is DBNull.Value Then : .StateName_ = dt.Rows(0).Item("StateName") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Code
                fn = "Code"
            Case FieldName.StateName
                fn = "StateName"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblState] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Code
                fn = "Code"
            Case FieldName.StateName
                fn = "StateName"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblState] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblChatMSG
    Public Shared tablename As String = "tblChatMSG"


    Structure Fields


        Dim id_ As Int32
        Dim msg_ As String
        Dim datetime_ As DateTime
        Dim Mem_id_ As String
        Dim Chat_ID_ As Int32

    End Structure


    Enum FieldName


        [id]
        [msg]
        [datetime]
        [Mem_id]
        [Chat_ID]

    End Enum


    Public ReadOnly Property tblChatMSG_insert
        Get
            Return <tblChatMSG_insert><![CDATA[
  INSERT INTO [tblChatMSG]
  (
      [id],
      [msg],
      [datetime],
      [Mem_id],
      [Chat_ID]
  )
  VALUES
  (
      @id_,
      @msg_,
      @datetime_,
      @Mem_id_,
      @Chat_ID_
  )
]]></tblChatMSG_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblChatMSG_update
        Get
            Return <tblChatMSG_update><![CDATA[
UPDATE [tblChatMSG]
Set 
    [msg]=@msg_,
    [datetime]=@datetime_,
    [Mem_id]=@Mem_id_,
    [Chat_ID]=@Chat_ID_
 WHERE [id]=@id_
]]></tblChatMSG_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblChatMSG_select
        Get
            Return <tblChatMSG_select><![CDATA[
SELECT 
      [id],
      [msg],
      [datetime],
      [Mem_id],
      [Chat_ID]
FROM [tblChatMSG]
    WHERE 1=1
]]></tblChatMSG_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblChatMSG_Delete_By_RowID
        Get
            Return <tblChatMSG_Delete_By_RowID><![CDATA[
DELETE FROM [tblChatMSG] WHERE [id]=@id_
]]></tblChatMSG_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblChatMSG_Delete_By_SELECT
        Get
            Return <tblChatMSG_Delete_By_SELECT><![CDATA[
DELETE FROM [tblChatMSG] WHERE 1=1
]]></tblChatMSG_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblChatMSG_MAXID
        Get
            Return <tblChatMSG_MAXID><![CDATA[
SELECT MAX([id]) FROM [tblChatMSG] WHERE 1=1
]]></tblChatMSG_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblChatMSG_MAXID, _conn)
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
    ByVal msg_ As String, _
    ByVal datetime_ As DateTime, _
    ByVal Mem_id_ As String, _
    ByVal Chat_ID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim id_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblChatMSG_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@id_", id_)
            .AddWithValue("@msg_", msg_)
            .AddWithValue("@datetime_", datetime_)
            .AddWithValue("@Mem_id_", Mem_id_)
            .AddWithValue("@Chat_ID_", Chat_ID_)

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
        Return id_
    End Function



    Function Update(
    ByVal msg_ As String, _
    ByVal datetime_ As DateTime, _
    ByVal Mem_id_ As String, _
    ByVal Chat_ID_ As Int32, _
    ByVal id_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblChatMSG_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@msg_", msg_)
            .AddWithValue("@datetime_", datetime_)
            .AddWithValue("@Mem_id_", Mem_id_)
            .AddWithValue("@Chat_ID_", Chat_ID_)
            .AddWithValue("@id_", id_)

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

        Return id_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.id
                fn = "id"
            Case FieldName.msg
                fn = "msg"
            Case FieldName.datetime
                fn = "datetime"
            Case FieldName.Mem_id
                fn = "Mem_id"
            Case FieldName.Chat_ID
                fn = "Chat_ID"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblChatMSG] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblChatMSG_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal id_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblChatMSG_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@id_", id_)

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
        Return id_
    End Function



    Function Selection_One_Row( _
     ByVal id_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblChatMSG_select & "  AND [id]=@id_"

        With comSelection.Parameters
            .AddWithValue("@id_", id_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("id") Is DBNull.Value Then : .id_ = dt.Rows(0).Item("id") : End If
                If Not dt.Rows(0).Item("msg") Is DBNull.Value Then : .msg_ = dt.Rows(0).Item("msg") : End If
                If Not dt.Rows(0).Item("datetime") Is DBNull.Value Then : .datetime_ = dt.Rows(0).Item("datetime") : End If
                If Not dt.Rows(0).Item("Mem_id") Is DBNull.Value Then : .Mem_id_ = dt.Rows(0).Item("Mem_id") : End If
                If Not dt.Rows(0).Item("Chat_ID") Is DBNull.Value Then : .Chat_ID_ = dt.Rows(0).Item("Chat_ID") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblChatMSG_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("id") Is DBNull.Value Then : .id_ = dt.Rows(0).Item("id") : End If
                If Not dt.Rows(0).Item("msg") Is DBNull.Value Then : .msg_ = dt.Rows(0).Item("msg") : End If
                If Not dt.Rows(0).Item("datetime") Is DBNull.Value Then : .datetime_ = dt.Rows(0).Item("datetime") : End If
                If Not dt.Rows(0).Item("Mem_id") Is DBNull.Value Then : .Mem_id_ = dt.Rows(0).Item("Mem_id") : End If
                If Not dt.Rows(0).Item("Chat_ID") Is DBNull.Value Then : .Chat_ID_ = dt.Rows(0).Item("Chat_ID") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.id
                fn = "id"
            Case FieldName.msg
                fn = "msg"
            Case FieldName.datetime
                fn = "datetime"
            Case FieldName.Mem_id
                fn = "Mem_id"
            Case FieldName.Chat_ID
                fn = "Chat_ID"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblChatMSG] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.id
                fn = "id"
            Case FieldName.msg
                fn = "msg"
            Case FieldName.datetime
                fn = "datetime"
            Case FieldName.Mem_id
                fn = "Mem_id"
            Case FieldName.Chat_ID
                fn = "Chat_ID"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblChatMSG] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblCustomer
    Public Shared tablename As String = "tblCustomer"


    Structure Fields


        Dim CustomerID_ As Int32
        Dim CustomerName_ As String
        Dim Address_ As String
        Dim RouteCity_ As String
        Dim Route_ As String
        Dim City_ As String
        Dim State_ As String
        Dim Zip_ As String
        Dim Notes_ As String
        Dim Status_ As String
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim ClientSince_ As DateTime
        Dim Phone_ As String
        Dim Email_ As String
        Dim Website_ As String
        Dim Fax_ As String
        Dim BOL_ As String
        Dim CustomerId_Link_ As String
        Dim Longt_ As String
        Dim Latt_ As String
        Dim NCR_ID_ As String
        Dim Receiving_CutOff_ As String

    End Structure


    Enum FieldName


        [CustomerID]
        [CustomerName]
        [Address]
        [RouteCity]
        [Route]
        [City]
        [State]
        [Zip]
        [Notes]
        [Status]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [ClientSince]
        [Phone]
        [Email]
        [Website]
        [Fax]
        [BOL]
        [CustomerId_Link]
        [Longt]
        [Latt]
        [NCR_ID]
        [Receiving_CutOff]

    End Enum


    Public ReadOnly Property tblCustomer_insert
        Get
            Return <tblCustomer_insert><![CDATA[
  INSERT INTO [tblCustomer]
  (
      [CustomerID],
      [CustomerName],
      [Address],
      [RouteCity],
      [Route],
      [City],
      [State],
      [Zip],
      [Notes],
      [Status],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [ClientSince],
      [Phone],
      [Email],
      [Website],
      [Fax],
      [BOL],
      [CustomerId_Link],
      [Longt],
      [Latt],
      [NCR_ID],
      [Receiving_CutOff]
  )
  VALUES
  (
      @CustomerID_,
      @CustomerName_,
      @Address_,
      @RouteCity_,
      @Route_,
      @City_,
      @State_,
      @Zip_,
      @Notes_,
      @Status_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @ClientSince_,
      @Phone_,
      @Email_,
      @Website_,
      @Fax_,
      @BOL_,
      @CustomerId_Link_,
      @Longt_,
      @Latt_,
      @NCR_ID_,
      @Receiving_CutOff_
  )
]]></tblCustomer_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_update
        Get
            Return <tblCustomer_update><![CDATA[
UPDATE [tblCustomer]
Set 
    [CustomerName]=@CustomerName_,
    [Address]=@Address_,
    [RouteCity]=@RouteCity_,
    [Route]=@Route_,
    [City]=@City_,
    [State]=@State_,
    [Zip]=@Zip_,
    [Notes]=@Notes_,
    [Status]=@Status_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [ClientSince]=@ClientSince_,
    [Phone]=@Phone_,
    [Email]=@Email_,
    [Website]=@Website_,
    [Fax]=@Fax_,
    [BOL]=@BOL_,
    [CustomerId_Link]=@CustomerId_Link_,
    [Longt]=@Longt_,
    [Latt]=@Latt_,
    [NCR_ID]=@NCR_ID_,
    [Receiving_CutOff]=@Receiving_CutOff_
 WHERE [CustomerID]=@CustomerID_
]]></tblCustomer_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblCustomer_select
        Get
            Return <tblCustomer_select><![CDATA[
SELECT 
      [CustomerID],
      [CustomerName],
      [Address],
      [RouteCity],
      [Route],
      [City],
      [State],
      [Zip],
      [Notes],
      [Status],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [ClientSince],
      [Phone],
      [Email],
      [Website],
      [Fax],
      [BOL],
      [CustomerId_Link],
      [Longt],
      [Latt],
      [NCR_ID],
      [Receiving_CutOff]
FROM [tblCustomer]
    WHERE 1=1
]]></tblCustomer_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_Delete_By_RowID
        Get
            Return <tblCustomer_Delete_By_RowID><![CDATA[
DELETE FROM [tblCustomer] WHERE [CustomerID]=@CustomerID_
]]></tblCustomer_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_Delete_By_SELECT
        Get
            Return <tblCustomer_Delete_By_SELECT><![CDATA[
DELETE FROM [tblCustomer] WHERE 1=1
]]></tblCustomer_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_MAXID
        Get
            Return <tblCustomer_MAXID><![CDATA[
SELECT MAX([CustomerID]) FROM [tblCustomer] WHERE 1=1
]]></tblCustomer_MAXID>.Value
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



    Function Insert( _
    ByVal CustomerName_ As String, _
    ByVal Address_ As String, _
    ByVal RouteCity_ As String, _
    ByVal Route_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Notes_ As String, _
    ByVal Status_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal ClientSince_ As DateTime, _
    ByVal Phone_ As String, _
    ByVal Email_ As String, _
    ByVal Website_ As String, _
    ByVal Fax_ As String, _
    ByVal BOL_ As String, _
    ByVal CustomerId_Link_ As String, _
    ByVal Longt_ As String, _
    ByVal Latt_ As String, _
    ByVal NCR_ID_ As String, _
    ByVal Receiving_CutOff_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim CustomerID_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@CustomerID_", CustomerID_)
            .AddWithValue("@CustomerName_", CustomerName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@RouteCity_", RouteCity_)
            .AddWithValue("@Route_", Route_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@ClientSince_", ClientSince_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@Website_", Website_)
            .AddWithValue("@Fax_", Fax_)
            .AddWithValue("@BOL_", BOL_)
            .AddWithValue("@CustomerId_Link_", CustomerId_Link_)
            .AddWithValue("@Longt_", Longt_)
            .AddWithValue("@Latt_", Latt_)
            .AddWithValue("@NCR_ID_", NCR_ID_)
            .AddWithValue("@Receiving_CutOff_", Receiving_CutOff_)

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
        Return CustomerID_
    End Function



    Function Update(
    ByVal CustomerName_ As String, _
    ByVal Address_ As String, _
    ByVal RouteCity_ As String, _
    ByVal Route_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Notes_ As String, _
    ByVal Status_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal ClientSince_ As DateTime, _
    ByVal Phone_ As String, _
    ByVal Email_ As String, _
    ByVal Website_ As String, _
    ByVal Fax_ As String, _
    ByVal BOL_ As String, _
    ByVal CustomerId_Link_ As String, _
    ByVal Longt_ As String, _
    ByVal Latt_ As String, _
    ByVal NCR_ID_ As String, _
    ByVal Receiving_CutOff_ As String, _
    ByVal CustomerID_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@CustomerName_", CustomerName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@RouteCity_", RouteCity_)
            .AddWithValue("@Route_", Route_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@ClientSince_", ClientSince_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@Website_", Website_)
            .AddWithValue("@Fax_", Fax_)
            .AddWithValue("@BOL_", BOL_)
            .AddWithValue("@CustomerId_Link_", CustomerId_Link_)
            .AddWithValue("@Longt_", Longt_)
            .AddWithValue("@Latt_", Latt_)
            .AddWithValue("@NCR_ID_", NCR_ID_)
            .AddWithValue("@Receiving_CutOff_", Receiving_CutOff_)
            .AddWithValue("@CustomerID_", CustomerID_)

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

        Return CustomerID_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.CustomerName
                fn = "CustomerName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.Route
                fn = "Route"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.ClientSince
                fn = "ClientSince"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.BOL
                fn = "BOL"
            Case FieldName.CustomerId_Link
                fn = "CustomerId_Link"
            Case FieldName.Longt
                fn = "Longt"
            Case FieldName.Latt
                fn = "Latt"
            Case FieldName.NCR_ID
                fn = "NCR_ID"
            Case FieldName.Receiving_CutOff
                fn = "Receiving_CutOff"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblCustomer] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblCustomer_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal CustomerID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCustomer_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@CustomerID_", CustomerID_)

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
        Return CustomerID_
    End Function



    Function Selection_One_Row( _
     ByVal CustomerID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblCustomer_select & "  AND [CustomerID]=@CustomerID_"

        With comSelection.Parameters
            .AddWithValue("@CustomerID_", CustomerID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("CustomerID") Is DBNull.Value Then : .CustomerID_ = dt.Rows(0).Item("CustomerID") : End If
                If Not dt.Rows(0).Item("CustomerName") Is DBNull.Value Then : .CustomerName_ = dt.Rows(0).Item("CustomerName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("RouteCity") Is DBNull.Value Then : .RouteCity_ = dt.Rows(0).Item("RouteCity") : End If
                If Not dt.Rows(0).Item("Route") Is DBNull.Value Then : .Route_ = dt.Rows(0).Item("Route") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("ClientSince") Is DBNull.Value Then : .ClientSince_ = dt.Rows(0).Item("ClientSince") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("Website") Is DBNull.Value Then : .Website_ = dt.Rows(0).Item("Website") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
                If Not dt.Rows(0).Item("BOL") Is DBNull.Value Then : .BOL_ = dt.Rows(0).Item("BOL") : End If
                If Not dt.Rows(0).Item("CustomerId_Link") Is DBNull.Value Then : .CustomerId_Link_ = dt.Rows(0).Item("CustomerId_Link") : End If
                If Not dt.Rows(0).Item("Longt") Is DBNull.Value Then : .Longt_ = dt.Rows(0).Item("Longt") : End If
                If Not dt.Rows(0).Item("Latt") Is DBNull.Value Then : .Latt_ = dt.Rows(0).Item("Latt") : End If
                If Not dt.Rows(0).Item("NCR_ID") Is DBNull.Value Then : .NCR_ID_ = dt.Rows(0).Item("NCR_ID") : End If
                If Not dt.Rows(0).Item("Receiving_CutOff") Is DBNull.Value Then : .Receiving_CutOff_ = dt.Rows(0).Item("Receiving_CutOff") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblCustomer_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("CustomerID") Is DBNull.Value Then : .CustomerID_ = dt.Rows(0).Item("CustomerID") : End If
                If Not dt.Rows(0).Item("CustomerName") Is DBNull.Value Then : .CustomerName_ = dt.Rows(0).Item("CustomerName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("RouteCity") Is DBNull.Value Then : .RouteCity_ = dt.Rows(0).Item("RouteCity") : End If
                If Not dt.Rows(0).Item("Route") Is DBNull.Value Then : .Route_ = dt.Rows(0).Item("Route") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("ClientSince") Is DBNull.Value Then : .ClientSince_ = dt.Rows(0).Item("ClientSince") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("Website") Is DBNull.Value Then : .Website_ = dt.Rows(0).Item("Website") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
                If Not dt.Rows(0).Item("BOL") Is DBNull.Value Then : .BOL_ = dt.Rows(0).Item("BOL") : End If
                If Not dt.Rows(0).Item("CustomerId_Link") Is DBNull.Value Then : .CustomerId_Link_ = dt.Rows(0).Item("CustomerId_Link") : End If
                If Not dt.Rows(0).Item("Longt") Is DBNull.Value Then : .Longt_ = dt.Rows(0).Item("Longt") : End If
                If Not dt.Rows(0).Item("Latt") Is DBNull.Value Then : .Latt_ = dt.Rows(0).Item("Latt") : End If
                If Not dt.Rows(0).Item("NCR_ID") Is DBNull.Value Then : .NCR_ID_ = dt.Rows(0).Item("NCR_ID") : End If
                If Not dt.Rows(0).Item("Receiving_CutOff") Is DBNull.Value Then : .Receiving_CutOff_ = dt.Rows(0).Item("Receiving_CutOff") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.CustomerName
                fn = "CustomerName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.Route
                fn = "Route"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.ClientSince
                fn = "ClientSince"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.BOL
                fn = "BOL"
            Case FieldName.CustomerId_Link
                fn = "CustomerId_Link"
            Case FieldName.Longt
                fn = "Longt"
            Case FieldName.Latt
                fn = "Latt"
            Case FieldName.NCR_ID
                fn = "NCR_ID"
            Case FieldName.Receiving_CutOff
                fn = "Receiving_CutOff"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblCustomer] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.CustomerName
                fn = "CustomerName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.Route
                fn = "Route"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.ClientSince
                fn = "ClientSince"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.BOL
                fn = "BOL"
            Case FieldName.CustomerId_Link
                fn = "CustomerId_Link"
            Case FieldName.Longt
                fn = "Longt"
            Case FieldName.Latt
                fn = "Latt"
            Case FieldName.NCR_ID
                fn = "NCR_ID"
            Case FieldName.Receiving_CutOff
                fn = "Receiving_CutOff"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblCustomer] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblOrder
    Public Shared tablename As String = "tblOrder"


    Structure Fields


        Dim OrderId_ As Int32
        Dim OrderNo_ As String
        Dim OrderSl_ As Int32
        Dim OrderDate_ As DateTime
        Dim DeliveryDate_ As DateTime
        Dim CutomerId_ As Int32
        Dim TotalItems_ As Int32
        Dim OrderAmount_ As Decimal
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim Status_ As String
        Dim StatusDate_ As DateTime
        Dim StatusBy_ As Int32
        Dim Remarks_ As String
        Dim Comments_ As String
        Dim Session_ As String
        Dim BranchId_ As Int32
        Dim BOLAddressID_ As Int32
        Dim ScheduledOrderId_ As Int32

    End Structure


    Enum FieldName


        [OrderId]
        [OrderNo]
        [OrderSl]
        [OrderDate]
        [DeliveryDate]
        [CutomerId]
        [TotalItems]
        [OrderAmount]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [Status]
        [StatusDate]
        [StatusBy]
        [Remarks]
        [Comments]
        [Session]
        [BranchId]
        [BOLAddressID]
        [ScheduledOrderId]

    End Enum


    Public ReadOnly Property tblOrder_insert
        Get
            Return <tblOrder_insert><![CDATA[
  INSERT INTO [tblOrder]
  (
      [OrderId],
      [OrderNo],
      [OrderSl],
      [OrderDate],
      [DeliveryDate],
      [CutomerId],
      [TotalItems],
      [OrderAmount],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Status],
      [StatusDate],
      [StatusBy],
      [Remarks],
      [Comments],
      [Session],
      [BranchId],
      [BOLAddressID],
      [ScheduledOrderId]
  )
  VALUES
  (
      @OrderId_,
      @OrderNo_,
      @OrderSl_,
      @OrderDate_,
      @DeliveryDate_,
      @CutomerId_,
      @TotalItems_,
      @OrderAmount_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @Status_,
      @StatusDate_,
      @StatusBy_,
      @Remarks_,
      @Comments_,
      @Session_,
      @BranchId_,
      @BOLAddressID_,
      @ScheduledOrderId_
  )
]]></tblOrder_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrder_update
        Get
            Return <tblOrder_update><![CDATA[
UPDATE [tblOrder]
Set 
    [OrderNo]=@OrderNo_,
    [OrderSl]=@OrderSl_,
    [OrderDate]=@OrderDate_,
    [DeliveryDate]=@DeliveryDate_,
    [CutomerId]=@CutomerId_,
    [TotalItems]=@TotalItems_,
    [OrderAmount]=@OrderAmount_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [Status]=@Status_,
    [StatusDate]=@StatusDate_,
    [StatusBy]=@StatusBy_,
    [Remarks]=@Remarks_,
    [Comments]=@Comments_,
    [Session]=@Session_,
    [BranchId]=@BranchId_,
    [BOLAddressID]=@BOLAddressID_,
    [ScheduledOrderId]=@ScheduledOrderId_
 WHERE [OrderId]=@OrderId_
]]></tblOrder_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblOrder_select
        Get
            Return <tblOrder_select><![CDATA[
SELECT 
      [OrderId],
      [OrderNo],
      [OrderSl],
      [OrderDate],
      [DeliveryDate],
      [CutomerId],
      [TotalItems],
      [OrderAmount],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Status],
      [StatusDate],
      [StatusBy],
      [Remarks],
      [Comments],
      [Session],
      [BranchId],
      [BOLAddressID],
      [ScheduledOrderId]
FROM [tblOrder]
    WHERE 1=1
]]></tblOrder_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrder_Delete_By_RowID
        Get
            Return <tblOrder_Delete_By_RowID><![CDATA[
DELETE FROM [tblOrder] WHERE [OrderId]=@OrderId_
]]></tblOrder_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrder_Delete_By_SELECT
        Get
            Return <tblOrder_Delete_By_SELECT><![CDATA[
DELETE FROM [tblOrder] WHERE 1=1
]]></tblOrder_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrder_MAXID
        Get
            Return <tblOrder_MAXID><![CDATA[
SELECT MAX([OrderId]) FROM [tblOrder] WHERE 1=1
]]></tblOrder_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblOrder_MAXID, _conn)
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
    ByVal OrderNo_ As String, _
    ByVal OrderSl_ As Int32, _
    ByVal OrderDate_ As DateTime, _
    ByVal DeliveryDate_ As DateTime, _
    ByVal CutomerId_ As Int32, _
    ByVal TotalItems_ As Int32, _
    ByVal OrderAmount_ As Decimal, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Status_ As String, _
    ByVal StatusDate_ As DateTime, _
    ByVal StatusBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Comments_ As String, _
    ByVal Session_ As String, _
    ByVal BranchId_ As Int32, _
    ByVal BOLAddressID_ As Int32, _
    ByVal ScheduledOrderId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim OrderId_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@OrderNo_", OrderNo_)
            .AddWithValue("@OrderSl_", OrderSl_)
            .AddWithValue("@OrderDate_", OrderDate_)
            .AddWithValue("@DeliveryDate_", DeliveryDate_)
            .AddWithValue("@CutomerId_", CutomerId_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@OrderAmount_", OrderAmount_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@StatusDate_", StatusDate_)
            .AddWithValue("@StatusBy_", StatusBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@BranchId_", BranchId_)
            .AddWithValue("@BOLAddressID_", BOLAddressID_)
            .AddWithValue("@ScheduledOrderId_", ScheduledOrderId_)

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
        Return OrderId_
    End Function



    Function Update(
    ByVal OrderNo_ As String, _
    ByVal OrderSl_ As Int32, _
    ByVal OrderDate_ As DateTime, _
    ByVal DeliveryDate_ As DateTime, _
    ByVal CutomerId_ As Int32, _
    ByVal TotalItems_ As Int32, _
    ByVal OrderAmount_ As Decimal, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Status_ As String, _
    ByVal StatusDate_ As DateTime, _
    ByVal StatusBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Comments_ As String, _
    ByVal Session_ As String, _
    ByVal BranchId_ As Int32, _
    ByVal BOLAddressID_ As Int32, _
    ByVal ScheduledOrderId_ As Int32, _
    ByVal OrderId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@OrderNo_", OrderNo_)
            .AddWithValue("@OrderSl_", OrderSl_)
            .AddWithValue("@OrderDate_", OrderDate_)
            .AddWithValue("@DeliveryDate_", DeliveryDate_)
            .AddWithValue("@CutomerId_", CutomerId_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@OrderAmount_", OrderAmount_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@StatusDate_", StatusDate_)
            .AddWithValue("@StatusBy_", StatusBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@BranchId_", BranchId_)
            .AddWithValue("@BOLAddressID_", BOLAddressID_)
            .AddWithValue("@ScheduledOrderId_", ScheduledOrderId_)
            .AddWithValue("@OrderId_", OrderId_)

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

        Return OrderId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.OrderNo
                fn = "OrderNo"
            Case FieldName.OrderSl
                fn = "OrderSl"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.DeliveryDate
                fn = "DeliveryDate"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.OrderAmount
                fn = "OrderAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.StatusBy
                fn = "StatusBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.BranchId
                fn = "BranchId"
            Case FieldName.BOLAddressID
                fn = "BOLAddressID"
            Case FieldName.ScheduledOrderId
                fn = "ScheduledOrderId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblOrder] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblOrder_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal OrderId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrder_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@OrderId_", OrderId_)

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
        Return OrderId_
    End Function



    Function Selection_One_Row( _
     ByVal OrderId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrder_select & "  AND [OrderId]=@OrderId_"

        With comSelection.Parameters
            .AddWithValue("@OrderId_", OrderId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("OrderNo") Is DBNull.Value Then : .OrderNo_ = dt.Rows(0).Item("OrderNo") : End If
                If Not dt.Rows(0).Item("OrderSl") Is DBNull.Value Then : .OrderSl_ = dt.Rows(0).Item("OrderSl") : End If
                If Not dt.Rows(0).Item("OrderDate") Is DBNull.Value Then : .OrderDate_ = dt.Rows(0).Item("OrderDate") : End If
                If Not dt.Rows(0).Item("DeliveryDate") Is DBNull.Value Then : .DeliveryDate_ = dt.Rows(0).Item("DeliveryDate") : End If
                If Not dt.Rows(0).Item("CutomerId") Is DBNull.Value Then : .CutomerId_ = dt.Rows(0).Item("CutomerId") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("OrderAmount") Is DBNull.Value Then : .OrderAmount_ = dt.Rows(0).Item("OrderAmount") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("StatusDate") Is DBNull.Value Then : .StatusDate_ = dt.Rows(0).Item("StatusDate") : End If
                If Not dt.Rows(0).Item("StatusBy") Is DBNull.Value Then : .StatusBy_ = dt.Rows(0).Item("StatusBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("BranchId") Is DBNull.Value Then : .BranchId_ = dt.Rows(0).Item("BranchId") : End If
                If Not dt.Rows(0).Item("BOLAddressID") Is DBNull.Value Then : .BOLAddressID_ = dt.Rows(0).Item("BOLAddressID") : End If
                If Not dt.Rows(0).Item("ScheduledOrderId") Is DBNull.Value Then : .ScheduledOrderId_ = dt.Rows(0).Item("ScheduledOrderId") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrder_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("OrderNo") Is DBNull.Value Then : .OrderNo_ = dt.Rows(0).Item("OrderNo") : End If
                If Not dt.Rows(0).Item("OrderSl") Is DBNull.Value Then : .OrderSl_ = dt.Rows(0).Item("OrderSl") : End If
                If Not dt.Rows(0).Item("OrderDate") Is DBNull.Value Then : .OrderDate_ = dt.Rows(0).Item("OrderDate") : End If
                If Not dt.Rows(0).Item("DeliveryDate") Is DBNull.Value Then : .DeliveryDate_ = dt.Rows(0).Item("DeliveryDate") : End If
                If Not dt.Rows(0).Item("CutomerId") Is DBNull.Value Then : .CutomerId_ = dt.Rows(0).Item("CutomerId") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("OrderAmount") Is DBNull.Value Then : .OrderAmount_ = dt.Rows(0).Item("OrderAmount") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("StatusDate") Is DBNull.Value Then : .StatusDate_ = dt.Rows(0).Item("StatusDate") : End If
                If Not dt.Rows(0).Item("StatusBy") Is DBNull.Value Then : .StatusBy_ = dt.Rows(0).Item("StatusBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("BranchId") Is DBNull.Value Then : .BranchId_ = dt.Rows(0).Item("BranchId") : End If
                If Not dt.Rows(0).Item("BOLAddressID") Is DBNull.Value Then : .BOLAddressID_ = dt.Rows(0).Item("BOLAddressID") : End If
                If Not dt.Rows(0).Item("ScheduledOrderId") Is DBNull.Value Then : .ScheduledOrderId_ = dt.Rows(0).Item("ScheduledOrderId") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.OrderNo
                fn = "OrderNo"
            Case FieldName.OrderSl
                fn = "OrderSl"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.DeliveryDate
                fn = "DeliveryDate"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.OrderAmount
                fn = "OrderAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.StatusBy
                fn = "StatusBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.BranchId
                fn = "BranchId"
            Case FieldName.BOLAddressID
                fn = "BOLAddressID"
            Case FieldName.ScheduledOrderId
                fn = "ScheduledOrderId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblOrder] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.OrderNo
                fn = "OrderNo"
            Case FieldName.OrderSl
                fn = "OrderSl"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.DeliveryDate
                fn = "DeliveryDate"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.OrderAmount
                fn = "OrderAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.StatusBy
                fn = "StatusBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.BranchId
                fn = "BranchId"
            Case FieldName.BOLAddressID
                fn = "BOLAddressID"
            Case FieldName.ScheduledOrderId
                fn = "ScheduledOrderId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblOrder] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblRoute
    Public Shared tablename As String = "tblRoute"


    Structure Fields


        Dim RouteId_ As Int32
        Dim RouteDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim CreatedOn_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim UpdatedOn_ As DateTime
        Dim RouteCity_ As String
        Dim TotalOrder_ As Int32
        Dim OrderDate_ As DateTime
        Dim TotalItems_ As Int32
        Dim Truck_ As String
        Dim Driver_ As String
        Dim OtherInfos_ As String
        Dim Comments_ As String

    End Structure


    Enum FieldName


        [RouteId]
        [RouteDate]
        [CreatedBy]
        [CreatedOn]
        [UpdatedBy]
        [UpdatedOn]
        [RouteCity]
        [TotalOrder]
        [OrderDate]
        [TotalItems]
        [Truck]
        [Driver]
        [OtherInfos]
        [Comments]

    End Enum


    Public ReadOnly Property tblRoute_insert
        Get
            Return <tblRoute_insert><![CDATA[
  INSERT INTO [tblRoute]
  (
      [RouteId],
      [RouteDate],
      [CreatedBy],
      [CreatedOn],
      [UpdatedBy],
      [UpdatedOn],
      [RouteCity],
      [TotalOrder],
      [OrderDate],
      [TotalItems],
      [Truck],
      [Driver],
      [OtherInfos],
      [Comments]
  )
  VALUES
  (
      @RouteId_,
      @RouteDate_,
      @CreatedBy_,
      @CreatedOn_,
      @UpdatedBy_,
      @UpdatedOn_,
      @RouteCity_,
      @TotalOrder_,
      @OrderDate_,
      @TotalItems_,
      @Truck_,
      @Driver_,
      @OtherInfos_,
      @Comments_
  )
]]></tblRoute_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoute_update
        Get
            Return <tblRoute_update><![CDATA[
UPDATE [tblRoute]
Set 
    [RouteDate]=@RouteDate_,
    [CreatedBy]=@CreatedBy_,
    [CreatedOn]=@CreatedOn_,
    [UpdatedBy]=@UpdatedBy_,
    [UpdatedOn]=@UpdatedOn_,
    [RouteCity]=@RouteCity_,
    [TotalOrder]=@TotalOrder_,
    [OrderDate]=@OrderDate_,
    [TotalItems]=@TotalItems_,
    [Truck]=@Truck_,
    [Driver]=@Driver_,
    [OtherInfos]=@OtherInfos_,
    [Comments]=@Comments_
 WHERE [RouteId]=@RouteId_
]]></tblRoute_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblRoute_select
        Get
            Return <tblRoute_select><![CDATA[
SELECT 
      [RouteId],
      [RouteDate],
      [CreatedBy],
      [CreatedOn],
      [UpdatedBy],
      [UpdatedOn],
      [RouteCity],
      [TotalOrder],
      [OrderDate],
      [TotalItems],
      [Truck],
      [Driver],
      [OtherInfos],
      [Comments]
FROM [tblRoute]
    WHERE 1=1
]]></tblRoute_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoute_Delete_By_RowID
        Get
            Return <tblRoute_Delete_By_RowID><![CDATA[
DELETE FROM [tblRoute] WHERE [RouteId]=@RouteId_
]]></tblRoute_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoute_Delete_By_SELECT
        Get
            Return <tblRoute_Delete_By_SELECT><![CDATA[
DELETE FROM [tblRoute] WHERE 1=1
]]></tblRoute_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoute_MAXID
        Get
            Return <tblRoute_MAXID><![CDATA[
SELECT MAX([RouteId]) FROM [tblRoute] WHERE 1=1
]]></tblRoute_MAXID>.Value
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



    Function Insert( _
    ByVal RouteDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreatedOn_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal UpdatedOn_ As DateTime, _
    ByVal RouteCity_ As String, _
    ByVal TotalOrder_ As Int32, _
    ByVal OrderDate_ As DateTime, _
    ByVal TotalItems_ As Int32, _
    ByVal Truck_ As String, _
    ByVal Driver_ As String, _
    ByVal OtherInfos_ As String, _
    ByVal Comments_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim RouteId_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@RouteId_", RouteId_)
            .AddWithValue("@RouteDate_", RouteDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreatedOn_", CreatedOn_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@UpdatedOn_", UpdatedOn_)
            .AddWithValue("@RouteCity_", RouteCity_)
            .AddWithValue("@TotalOrder_", TotalOrder_)
            .AddWithValue("@OrderDate_", OrderDate_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@Truck_", Truck_)
            .AddWithValue("@Driver_", Driver_)
            .AddWithValue("@OtherInfos_", OtherInfos_)
            .AddWithValue("@Comments_", Comments_)

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
        Return RouteId_
    End Function



    Function Update(
    ByVal RouteDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreatedOn_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal UpdatedOn_ As DateTime, _
    ByVal RouteCity_ As String, _
    ByVal TotalOrder_ As Int32, _
    ByVal OrderDate_ As DateTime, _
    ByVal TotalItems_ As Int32, _
    ByVal Truck_ As String, _
    ByVal Driver_ As String, _
    ByVal OtherInfos_ As String, _
    ByVal Comments_ As String, _
    ByVal RouteId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@RouteDate_", RouteDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreatedOn_", CreatedOn_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@UpdatedOn_", UpdatedOn_)
            .AddWithValue("@RouteCity_", RouteCity_)
            .AddWithValue("@TotalOrder_", TotalOrder_)
            .AddWithValue("@OrderDate_", OrderDate_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@Truck_", Truck_)
            .AddWithValue("@Driver_", Driver_)
            .AddWithValue("@OtherInfos_", OtherInfos_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@RouteId_", RouteId_)

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

        Return RouteId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.RouteId
                fn = "RouteId"
            Case FieldName.RouteDate
                fn = "RouteDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedOn
                fn = "CreatedOn"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.UpdatedOn
                fn = "UpdatedOn"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.TotalOrder
                fn = "TotalOrder"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.Truck
                fn = "Truck"
            Case FieldName.Driver
                fn = "Driver"
            Case FieldName.OtherInfos
                fn = "OtherInfos"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblRoute] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblRoute_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal RouteId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblRoute_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@RouteId_", RouteId_)

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
        Return RouteId_
    End Function



    Function Selection_One_Row( _
     ByVal RouteId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblRoute_select & "  AND [RouteId]=@RouteId_"

        With comSelection.Parameters
            .AddWithValue("@RouteId_", RouteId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("RouteId") Is DBNull.Value Then : .RouteId_ = dt.Rows(0).Item("RouteId") : End If
                If Not dt.Rows(0).Item("RouteDate") Is DBNull.Value Then : .RouteDate_ = dt.Rows(0).Item("RouteDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreatedOn") Is DBNull.Value Then : .CreatedOn_ = dt.Rows(0).Item("CreatedOn") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedOn") Is DBNull.Value Then : .UpdatedOn_ = dt.Rows(0).Item("UpdatedOn") : End If
                If Not dt.Rows(0).Item("RouteCity") Is DBNull.Value Then : .RouteCity_ = dt.Rows(0).Item("RouteCity") : End If
                If Not dt.Rows(0).Item("TotalOrder") Is DBNull.Value Then : .TotalOrder_ = dt.Rows(0).Item("TotalOrder") : End If
                If Not dt.Rows(0).Item("OrderDate") Is DBNull.Value Then : .OrderDate_ = dt.Rows(0).Item("OrderDate") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("Truck") Is DBNull.Value Then : .Truck_ = dt.Rows(0).Item("Truck") : End If
                If Not dt.Rows(0).Item("Driver") Is DBNull.Value Then : .Driver_ = dt.Rows(0).Item("Driver") : End If
                If Not dt.Rows(0).Item("OtherInfos") Is DBNull.Value Then : .OtherInfos_ = dt.Rows(0).Item("OtherInfos") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblRoute_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("RouteId") Is DBNull.Value Then : .RouteId_ = dt.Rows(0).Item("RouteId") : End If
                If Not dt.Rows(0).Item("RouteDate") Is DBNull.Value Then : .RouteDate_ = dt.Rows(0).Item("RouteDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreatedOn") Is DBNull.Value Then : .CreatedOn_ = dt.Rows(0).Item("CreatedOn") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedOn") Is DBNull.Value Then : .UpdatedOn_ = dt.Rows(0).Item("UpdatedOn") : End If
                If Not dt.Rows(0).Item("RouteCity") Is DBNull.Value Then : .RouteCity_ = dt.Rows(0).Item("RouteCity") : End If
                If Not dt.Rows(0).Item("TotalOrder") Is DBNull.Value Then : .TotalOrder_ = dt.Rows(0).Item("TotalOrder") : End If
                If Not dt.Rows(0).Item("OrderDate") Is DBNull.Value Then : .OrderDate_ = dt.Rows(0).Item("OrderDate") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("Truck") Is DBNull.Value Then : .Truck_ = dt.Rows(0).Item("Truck") : End If
                If Not dt.Rows(0).Item("Driver") Is DBNull.Value Then : .Driver_ = dt.Rows(0).Item("Driver") : End If
                If Not dt.Rows(0).Item("OtherInfos") Is DBNull.Value Then : .OtherInfos_ = dt.Rows(0).Item("OtherInfos") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.RouteId
                fn = "RouteId"
            Case FieldName.RouteDate
                fn = "RouteDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedOn
                fn = "CreatedOn"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.UpdatedOn
                fn = "UpdatedOn"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.TotalOrder
                fn = "TotalOrder"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.Truck
                fn = "Truck"
            Case FieldName.Driver
                fn = "Driver"
            Case FieldName.OtherInfos
                fn = "OtherInfos"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblRoute] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.RouteId
                fn = "RouteId"
            Case FieldName.RouteDate
                fn = "RouteDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedOn
                fn = "CreatedOn"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.UpdatedOn
                fn = "UpdatedOn"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.TotalOrder
                fn = "TotalOrder"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.Truck
                fn = "Truck"
            Case FieldName.Driver
                fn = "Driver"
            Case FieldName.OtherInfos
                fn = "OtherInfos"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblRoute] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblRouteOrders
    Public Shared tablename As String = "tblRouteOrders"


    Structure Fields


        Dim ItemId_ As Int32
        Dim Sl_ As Int32
        Dim OrderId_ As Int32
        Dim RouteID_ As Int32

    End Structure


    Enum FieldName


        [ItemId]
        [Sl]
        [OrderId]
        [RouteID]

    End Enum


    Public ReadOnly Property tblRouteOrders_insert
        Get
            Return <tblRouteOrders_insert><![CDATA[
  INSERT INTO [tblRouteOrders]
  (
      [ItemId],
      [Sl],
      [OrderId],
      [RouteID]
  )
  VALUES
  (
      @ItemId_,
      @Sl_,
      @OrderId_,
      @RouteID_
  )
]]></tblRouteOrders_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblRouteOrders_update
        Get
            Return <tblRouteOrders_update><![CDATA[
UPDATE [tblRouteOrders]
Set 
    [Sl]=@Sl_,
    [OrderId]=@OrderId_,
    [RouteID]=@RouteID_
 WHERE [ItemId]=@ItemId_
]]></tblRouteOrders_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblRouteOrders_select
        Get
            Return <tblRouteOrders_select><![CDATA[
SELECT 
      [ItemId],
      [Sl],
      [OrderId],
      [RouteID]
FROM [tblRouteOrders]
    WHERE 1=1
]]></tblRouteOrders_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblRouteOrders_Delete_By_RowID
        Get
            Return <tblRouteOrders_Delete_By_RowID><![CDATA[
DELETE FROM [tblRouteOrders] WHERE [ItemId]=@ItemId_
]]></tblRouteOrders_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblRouteOrders_Delete_By_SELECT
        Get
            Return <tblRouteOrders_Delete_By_SELECT><![CDATA[
DELETE FROM [tblRouteOrders] WHERE 1=1
]]></tblRouteOrders_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblRouteOrders_MAXID
        Get
            Return <tblRouteOrders_MAXID><![CDATA[
SELECT MAX([ItemId]) FROM [tblRouteOrders] WHERE 1=1
]]></tblRouteOrders_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblRouteOrders_MAXID, _conn)
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
    ByVal Sl_ As Int32, _
    ByVal OrderId_ As Int32, _
    ByVal RouteID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblRouteOrders_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemId_", ItemId_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@RouteID_", RouteID_)

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
        Return ItemId_
    End Function



    Function Update(
    ByVal Sl_ As Int32, _
    ByVal OrderId_ As Int32, _
    ByVal RouteID_ As Int32, _
    ByVal ItemId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblRouteOrders_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@RouteID_", RouteID_)
            .AddWithValue("@ItemId_", ItemId_)

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

        Return ItemId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.RouteID
                fn = "RouteID"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblRouteOrders] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblRouteOrders_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblRouteOrders_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId_", ItemId_)

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
        Return ItemId_
    End Function



    Function Selection_One_Row( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblRouteOrders_select & "  AND [ItemId]=@ItemId_"

        With comSelection.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("RouteID") Is DBNull.Value Then : .RouteID_ = dt.Rows(0).Item("RouteID") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblRouteOrders_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("RouteID") Is DBNull.Value Then : .RouteID_ = dt.Rows(0).Item("RouteID") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.RouteID
                fn = "RouteID"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblRouteOrders] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.RouteID
                fn = "RouteID"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblRouteOrders] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblMasterItems
    Public Shared tablename As String = "tblMasterItems"


    Structure Fields


        Dim ItemId_ As Int32
        Dim ItemType_ As String
        Dim ItemName_ As String
        Dim ItemValue_ As String
        Dim Comments_ As String

    End Structure


    Enum FieldName


        [ItemId]
        [ItemType]
        [ItemName]
        [ItemValue]
        [Comments]

    End Enum


    Public ReadOnly Property tblMasterItems_insert
        Get
            Return <tblMasterItems_insert><![CDATA[
  INSERT INTO [tblMasterItems]
  (
      [ItemId],
      [ItemType],
      [ItemName],
      [ItemValue],
      [Comments]
  )
  VALUES
  (
      @ItemId_,
      @ItemType_,
      @ItemName_,
      @ItemValue_,
      @Comments_
  )
]]></tblMasterItems_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblMasterItems_update
        Get
            Return <tblMasterItems_update><![CDATA[
UPDATE [tblMasterItems]
Set 
    [ItemType]=@ItemType_,
    [ItemName]=@ItemName_,
    [ItemValue]=@ItemValue_,
    [Comments]=@Comments_
 WHERE [ItemId]=@ItemId_
]]></tblMasterItems_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblMasterItems_select
        Get
            Return <tblMasterItems_select><![CDATA[
SELECT 
      [ItemId],
      [ItemType],
      [ItemName],
      [ItemValue],
      [Comments]
FROM [tblMasterItems]
    WHERE 1=1
]]></tblMasterItems_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblMasterItems_Delete_By_RowID
        Get
            Return <tblMasterItems_Delete_By_RowID><![CDATA[
DELETE FROM [tblMasterItems] WHERE [ItemId]=@ItemId_
]]></tblMasterItems_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblMasterItems_Delete_By_SELECT
        Get
            Return <tblMasterItems_Delete_By_SELECT><![CDATA[
DELETE FROM [tblMasterItems] WHERE 1=1
]]></tblMasterItems_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblMasterItems_MAXID
        Get
            Return <tblMasterItems_MAXID><![CDATA[
SELECT MAX([ItemId]) FROM [tblMasterItems] WHERE 1=1
]]></tblMasterItems_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblMasterItems_MAXID, _conn)
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
    ByVal ItemType_ As String, _
    ByVal ItemName_ As String, _
    ByVal ItemValue_ As String, _
    ByVal Comments_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblMasterItems_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemId_", ItemId_)
            .AddWithValue("@ItemType_", ItemType_)
            .AddWithValue("@ItemName_", ItemName_)
            .AddWithValue("@ItemValue_", ItemValue_)
            .AddWithValue("@Comments_", Comments_)

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
        Return ItemId_
    End Function



    Function Update(
    ByVal ItemType_ As String, _
    ByVal ItemName_ As String, _
    ByVal ItemValue_ As String, _
    ByVal Comments_ As String, _
    ByVal ItemId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblMasterItems_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ItemType_", ItemType_)
            .AddWithValue("@ItemName_", ItemName_)
            .AddWithValue("@ItemValue_", ItemValue_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@ItemId_", ItemId_)

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

        Return ItemId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.ItemType
                fn = "ItemType"
            Case FieldName.ItemName
                fn = "ItemName"
            Case FieldName.ItemValue
                fn = "ItemValue"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblMasterItems] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblMasterItems_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblMasterItems_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId_", ItemId_)

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
        Return ItemId_
    End Function



    Function Selection_One_Row( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblMasterItems_select & "  AND [ItemId]=@ItemId_"

        With comSelection.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("ItemType") Is DBNull.Value Then : .ItemType_ = dt.Rows(0).Item("ItemType") : End If
                If Not dt.Rows(0).Item("ItemName") Is DBNull.Value Then : .ItemName_ = dt.Rows(0).Item("ItemName") : End If
                If Not dt.Rows(0).Item("ItemValue") Is DBNull.Value Then : .ItemValue_ = dt.Rows(0).Item("ItemValue") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblMasterItems_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("ItemType") Is DBNull.Value Then : .ItemType_ = dt.Rows(0).Item("ItemType") : End If
                If Not dt.Rows(0).Item("ItemName") Is DBNull.Value Then : .ItemName_ = dt.Rows(0).Item("ItemName") : End If
                If Not dt.Rows(0).Item("ItemValue") Is DBNull.Value Then : .ItemValue_ = dt.Rows(0).Item("ItemValue") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.ItemType
                fn = "ItemType"
            Case FieldName.ItemName
                fn = "ItemName"
            Case FieldName.ItemValue
                fn = "ItemValue"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblMasterItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.ItemType
                fn = "ItemType"
            Case FieldName.ItemName
                fn = "ItemName"
            Case FieldName.ItemValue
                fn = "ItemValue"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblMasterItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblVersion
    Public Shared tablename As String = "tblVersion"


    Structure Fields


        Dim Version_ As String
        Dim Date_ As DateTime

    End Structure


    Enum FieldName


        [Version]
        [Date]

    End Enum


    Public ReadOnly Property tblVersion_insert
        Get
            Return <tblVersion_insert><![CDATA[
  INSERT INTO [tblVersion]
  (
      [Version],
      [Date]
  )
  VALUES
  (
      @Version_,
      @Date_
  )
]]></tblVersion_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblVersion_update
        Get
            Return <tblVersion_update><![CDATA[
UPDATE [tblVersion]
Set 
    [Date]=@Date_
 WHERE [Version]=@Version_
]]></tblVersion_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblVersion_select
        Get
            Return <tblVersion_select><![CDATA[
SELECT 
      [Version],
      [Date]
FROM [tblVersion]
    WHERE 1=1
]]></tblVersion_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblVersion_Delete_By_RowID
        Get
            Return <tblVersion_Delete_By_RowID><![CDATA[
DELETE FROM [tblVersion] WHERE [Version]=@Version_
]]></tblVersion_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblVersion_Delete_By_SELECT
        Get
            Return <tblVersion_Delete_By_SELECT><![CDATA[
DELETE FROM [tblVersion] WHERE 1=1
]]></tblVersion_Delete_By_SELECT>.Value
        End Get
    End Property


    Function Insert( _
    ByVal Version_ As String, _
    ByVal Date_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing


        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblVersion_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Version_", Version_)
            .AddWithValue("@Date_", Date_)

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
        Return 0
    End Function



    Function Update(
    ByVal Date_ As DateTime, _
    ByVal Version_ As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblVersion_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Date_", Date_)
            .AddWithValue("@Version_", Version_)

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

        Return 0
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Version
                fn = "Version"
            Case FieldName.Date
                fn = "Date"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblVersion] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblVersion_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal Version_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblVersion_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Version_", Version_)

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
        Return 0
    End Function



    Function Selection_One_Row( _
     ByVal Version_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblVersion_select & "  AND [Version]=@Version_"

        With comSelection.Parameters
            .AddWithValue("@Version_", Version_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Version") Is DBNull.Value Then : .Version_ = dt.Rows(0).Item("Version") : End If
                If Not dt.Rows(0).Item("Date") Is DBNull.Value Then : .Date_ = dt.Rows(0).Item("Date") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblVersion_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Version") Is DBNull.Value Then : .Version_ = dt.Rows(0).Item("Version") : End If
                If Not dt.Rows(0).Item("Date") Is DBNull.Value Then : .Date_ = dt.Rows(0).Item("Date") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Version
                fn = "Version"
            Case FieldName.Date
                fn = "Date"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblVersion] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Version
                fn = "Version"
            Case FieldName.Date
                fn = "Date"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblVersion] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblCustomer_BOL
    Public Shared tablename As String = "tblCustomer_BOL"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim CustomerId_ As Int32
        Dim DropOffPoint_ As String
        Dim Address_ As String
        Dim City_ As String
        Dim State_ As String
        Dim Zip_ As String
        Dim Contact_ As String
        Dim OrderID_ As Int32
        Dim RouteCity_ As String
        Dim Phone_ As String
        Dim Fax_ As String
        Dim Longt_ As String
        Dim Latt_ As String
        Dim Receiving_CutOff_ As String

    End Structure


    Enum FieldName


        [ItemSl]
        [CustomerId]
        [DropOffPoint]
        [Address]
        [City]
        [State]
        [Zip]
        [Contact]
        [OrderID]
        [RouteCity]
        [Phone]
        [Fax]
        [Longt]
        [Latt]
        [Receiving_CutOff]

    End Enum


    Public ReadOnly Property tblCustomer_BOL_insert
        Get
            Return <tblCustomer_BOL_insert><![CDATA[
  INSERT INTO [tblCustomer_BOL]
  (
      [ItemSl],
      [CustomerId],
      [DropOffPoint],
      [Address],
      [City],
      [State],
      [Zip],
      [Contact],
      [OrderID],
      [RouteCity],
      [Phone],
      [Fax],
      [Longt],
      [Latt],
      [Receiving_CutOff]
  )
  VALUES
  (
      @ItemSl_,
      @CustomerId_,
      @DropOffPoint_,
      @Address_,
      @City_,
      @State_,
      @Zip_,
      @Contact_,
      @OrderID_,
      @RouteCity_,
      @Phone_,
      @Fax_,
      @Longt_,
      @Latt_,
      @Receiving_CutOff_
  )
]]></tblCustomer_BOL_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_BOL_update
        Get
            Return <tblCustomer_BOL_update><![CDATA[
UPDATE [tblCustomer_BOL]
Set 
    [CustomerId]=@CustomerId_,
    [DropOffPoint]=@DropOffPoint_,
    [Address]=@Address_,
    [City]=@City_,
    [State]=@State_,
    [Zip]=@Zip_,
    [Contact]=@Contact_,
    [OrderID]=@OrderID_,
    [RouteCity]=@RouteCity_,
    [Phone]=@Phone_,
    [Fax]=@Fax_,
    [Longt]=@Longt_,
    [Latt]=@Latt_,
    [Receiving_CutOff]=@Receiving_CutOff_
 WHERE [ItemSl]=@ItemSl_
]]></tblCustomer_BOL_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblCustomer_BOL_select
        Get
            Return <tblCustomer_BOL_select><![CDATA[
SELECT 
      [ItemSl],
      [CustomerId],
      [DropOffPoint],
      [Address],
      [City],
      [State],
      [Zip],
      [Contact],
      [OrderID],
      [RouteCity],
      [Phone],
      [Fax],
      [Longt],
      [Latt],
      [Receiving_CutOff]
FROM [tblCustomer_BOL]
    WHERE 1=1
]]></tblCustomer_BOL_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_BOL_Delete_By_RowID
        Get
            Return <tblCustomer_BOL_Delete_By_RowID><![CDATA[
DELETE FROM [tblCustomer_BOL] WHERE [ItemSl]=@ItemSl_
]]></tblCustomer_BOL_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_BOL_Delete_By_SELECT
        Get
            Return <tblCustomer_BOL_Delete_By_SELECT><![CDATA[
DELETE FROM [tblCustomer_BOL] WHERE 1=1
]]></tblCustomer_BOL_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblCustomer_BOL_MAXID
        Get
            Return <tblCustomer_BOL_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblCustomer_BOL] WHERE 1=1
]]></tblCustomer_BOL_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblCustomer_BOL_MAXID, _conn)
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
    ByVal CustomerId_ As Int32, _
    ByVal DropOffPoint_ As String, _
    ByVal Address_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Contact_ As String, _
    ByVal OrderID_ As Int32, _
    ByVal RouteCity_ As String, _
    ByVal Phone_ As String, _
    ByVal Fax_ As String, _
    ByVal Longt_ As String, _
    ByVal Latt_ As String, _
    ByVal Receiving_CutOff_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblCustomer_BOL_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@CustomerId_", CustomerId_)
            .AddWithValue("@DropOffPoint_", DropOffPoint_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Contact_", Contact_)
            .AddWithValue("@OrderID_", OrderID_)
            .AddWithValue("@RouteCity_", RouteCity_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Fax_", Fax_)
            .AddWithValue("@Longt_", Longt_)
            .AddWithValue("@Latt_", Latt_)
            .AddWithValue("@Receiving_CutOff_", Receiving_CutOff_)

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
        Return ItemSl_
    End Function



    Function Update(
    ByVal CustomerId_ As Int32, _
    ByVal DropOffPoint_ As String, _
    ByVal Address_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Contact_ As String, _
    ByVal OrderID_ As Int32, _
    ByVal RouteCity_ As String, _
    ByVal Phone_ As String, _
    ByVal Fax_ As String, _
    ByVal Longt_ As String, _
    ByVal Latt_ As String, _
    ByVal Receiving_CutOff_ As String, _
    ByVal ItemSl_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblCustomer_BOL_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@CustomerId_", CustomerId_)
            .AddWithValue("@DropOffPoint_", DropOffPoint_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Contact_", Contact_)
            .AddWithValue("@OrderID_", OrderID_)
            .AddWithValue("@RouteCity_", RouteCity_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Fax_", Fax_)
            .AddWithValue("@Longt_", Longt_)
            .AddWithValue("@Latt_", Latt_)
            .AddWithValue("@Receiving_CutOff_", Receiving_CutOff_)
            .AddWithValue("@ItemSl_", ItemSl_)

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

        Return ItemSl_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.CustomerId
                fn = "CustomerId"
            Case FieldName.DropOffPoint
                fn = "DropOffPoint"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Contact
                fn = "Contact"
            Case FieldName.OrderID
                fn = "OrderID"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.Longt
                fn = "Longt"
            Case FieldName.Latt
                fn = "Latt"
            Case FieldName.Receiving_CutOff
                fn = "Receiving_CutOff"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblCustomer_BOL] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblCustomer_BOL_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCustomer_BOL_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

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
        Return ItemSl_
    End Function



    Function Selection_One_Row( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblCustomer_BOL_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("CustomerId") Is DBNull.Value Then : .CustomerId_ = dt.Rows(0).Item("CustomerId") : End If
                If Not dt.Rows(0).Item("DropOffPoint") Is DBNull.Value Then : .DropOffPoint_ = dt.Rows(0).Item("DropOffPoint") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Contact") Is DBNull.Value Then : .Contact_ = dt.Rows(0).Item("Contact") : End If
                If Not dt.Rows(0).Item("OrderID") Is DBNull.Value Then : .OrderID_ = dt.Rows(0).Item("OrderID") : End If
                If Not dt.Rows(0).Item("RouteCity") Is DBNull.Value Then : .RouteCity_ = dt.Rows(0).Item("RouteCity") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
                If Not dt.Rows(0).Item("Longt") Is DBNull.Value Then : .Longt_ = dt.Rows(0).Item("Longt") : End If
                If Not dt.Rows(0).Item("Latt") Is DBNull.Value Then : .Latt_ = dt.Rows(0).Item("Latt") : End If
                If Not dt.Rows(0).Item("Receiving_CutOff") Is DBNull.Value Then : .Receiving_CutOff_ = dt.Rows(0).Item("Receiving_CutOff") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblCustomer_BOL_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("CustomerId") Is DBNull.Value Then : .CustomerId_ = dt.Rows(0).Item("CustomerId") : End If
                If Not dt.Rows(0).Item("DropOffPoint") Is DBNull.Value Then : .DropOffPoint_ = dt.Rows(0).Item("DropOffPoint") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Contact") Is DBNull.Value Then : .Contact_ = dt.Rows(0).Item("Contact") : End If
                If Not dt.Rows(0).Item("OrderID") Is DBNull.Value Then : .OrderID_ = dt.Rows(0).Item("OrderID") : End If
                If Not dt.Rows(0).Item("RouteCity") Is DBNull.Value Then : .RouteCity_ = dt.Rows(0).Item("RouteCity") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
                If Not dt.Rows(0).Item("Longt") Is DBNull.Value Then : .Longt_ = dt.Rows(0).Item("Longt") : End If
                If Not dt.Rows(0).Item("Latt") Is DBNull.Value Then : .Latt_ = dt.Rows(0).Item("Latt") : End If
                If Not dt.Rows(0).Item("Receiving_CutOff") Is DBNull.Value Then : .Receiving_CutOff_ = dt.Rows(0).Item("Receiving_CutOff") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.CustomerId
                fn = "CustomerId"
            Case FieldName.DropOffPoint
                fn = "DropOffPoint"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Contact
                fn = "Contact"
            Case FieldName.OrderID
                fn = "OrderID"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.Longt
                fn = "Longt"
            Case FieldName.Latt
                fn = "Latt"
            Case FieldName.Receiving_CutOff
                fn = "Receiving_CutOff"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblCustomer_BOL] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.CustomerId
                fn = "CustomerId"
            Case FieldName.DropOffPoint
                fn = "DropOffPoint"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Contact
                fn = "Contact"
            Case FieldName.OrderID
                fn = "OrderID"
            Case FieldName.RouteCity
                fn = "RouteCity"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Fax
                fn = "Fax"
            Case FieldName.Longt
                fn = "Longt"
            Case FieldName.Latt
                fn = "Latt"
            Case FieldName.Receiving_CutOff
                fn = "Receiving_CutOff"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblCustomer_BOL] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblOrderItems
    Public Shared tablename As String = "tblOrderItems"


    Structure Fields


        Dim ItemId_ As Int32
        Dim OrderId_ As Int32
        Dim Sl_ As Int32
        Dim ProductId_ As Int32
        Dim Qty_ As Int32
        Dim Price_ As Decimal
        Dim Discount_ As Decimal
        Dim Extra_ As Decimal
        Dim Weight_ As String
        Dim SubTotal_ As Decimal
        Dim Notes_ As String
        Dim Fresh_ As Int32
        Dim Frozen_ As Int32

    End Structure


    Enum FieldName


        [ItemId]
        [OrderId]
        [Sl]
        [ProductId]
        [Qty]
        [Price]
        [Discount]
        [Extra]
        [Weight]
        [SubTotal]
        [Notes]
        [Fresh]
        [Frozen]

    End Enum


    Public ReadOnly Property tblOrderItems_insert
        Get
            Return <tblOrderItems_insert><![CDATA[
  INSERT INTO [tblOrderItems]
  (
      [ItemId],
      [OrderId],
      [Sl],
      [ProductId],
      [Qty],
      [Price],
      [Discount],
      [Extra],
      [Weight],
      [SubTotal],
      [Notes],
      [Fresh],
      [Frozen]
  )
  VALUES
  (
      @ItemId_,
      @OrderId_,
      @Sl_,
      @ProductId_,
      @Qty_,
      @Price_,
      @Discount_,
      @Extra_,
      @Weight_,
      @SubTotal_,
      @Notes_,
      @Fresh_,
      @Frozen_
  )
]]></tblOrderItems_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderItems_update
        Get
            Return <tblOrderItems_update><![CDATA[
UPDATE [tblOrderItems]
Set 
    [OrderId]=@OrderId_,
    [Sl]=@Sl_,
    [ProductId]=@ProductId_,
    [Qty]=@Qty_,
    [Price]=@Price_,
    [Discount]=@Discount_,
    [Extra]=@Extra_,
    [Weight]=@Weight_,
    [SubTotal]=@SubTotal_,
    [Notes]=@Notes_,
    [Fresh]=@Fresh_,
    [Frozen]=@Frozen_
 WHERE [ItemId]=@ItemId_
]]></tblOrderItems_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblOrderItems_select
        Get
            Return <tblOrderItems_select><![CDATA[
SELECT 
      [ItemId],
      [OrderId],
      [Sl],
      [ProductId],
      [Qty],
      [Price],
      [Discount],
      [Extra],
      [Weight],
      [SubTotal],
      [Notes],
      [Fresh],
      [Frozen]
FROM [tblOrderItems]
    WHERE 1=1
]]></tblOrderItems_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderItems_Delete_By_RowID
        Get
            Return <tblOrderItems_Delete_By_RowID><![CDATA[
DELETE FROM [tblOrderItems] WHERE [ItemId]=@ItemId_
]]></tblOrderItems_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderItems_Delete_By_SELECT
        Get
            Return <tblOrderItems_Delete_By_SELECT><![CDATA[
DELETE FROM [tblOrderItems] WHERE 1=1
]]></tblOrderItems_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderItems_MAXID
        Get
            Return <tblOrderItems_MAXID><![CDATA[
SELECT MAX([ItemId]) FROM [tblOrderItems] WHERE 1=1
]]></tblOrderItems_MAXID>.Value
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
    ByVal OrderId_ As Int32, _
    ByVal Sl_ As Int32, _
    ByVal ProductId_ As Int32, _
    ByVal Qty_ As Int32, _
    ByVal Price_ As Decimal, _
    ByVal Discount_ As Decimal, _
    ByVal Extra_ As Decimal, _
    ByVal Weight_ As String, _
    ByVal SubTotal_ As Decimal, _
    ByVal Notes_ As String, _
    ByVal Fresh_ As Int32, _
    ByVal Frozen_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@ItemId_", ItemId_)
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Discount_", Discount_)
            .AddWithValue("@Extra_", Extra_)
            .AddWithValue("@Weight_", Weight_)
            .AddWithValue("@SubTotal_", SubTotal_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Fresh_", Fresh_)
            .AddWithValue("@Frozen_", Frozen_)

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
        Return ItemId_
    End Function



    Function Update(
    ByVal OrderId_ As Int32, _
    ByVal Sl_ As Int32, _
    ByVal ProductId_ As Int32, _
    ByVal Qty_ As Int32, _
    ByVal Price_ As Decimal, _
    ByVal Discount_ As Decimal, _
    ByVal Extra_ As Decimal, _
    ByVal Weight_ As String, _
    ByVal SubTotal_ As Decimal, _
    ByVal Notes_ As String, _
    ByVal Fresh_ As Int32, _
    ByVal Frozen_ As Int32, _
    ByVal ItemId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Discount_", Discount_)
            .AddWithValue("@Extra_", Extra_)
            .AddWithValue("@Weight_", Weight_)
            .AddWithValue("@SubTotal_", SubTotal_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Fresh_", Fresh_)
            .AddWithValue("@Frozen_", Frozen_)
            .AddWithValue("@ItemId_", ItemId_)

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

        Return ItemId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Extra
                fn = "Extra"
            Case FieldName.Weight
                fn = "Weight"
            Case FieldName.SubTotal
                fn = "SubTotal"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblOrderItems] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblOrderItems_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrderItems_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId_", ItemId_)

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
        Return ItemId_
    End Function



    Function Selection_One_Row( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderItems_select & "  AND [ItemId]=@ItemId_"

        With comSelection.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Discount") Is DBNull.Value Then : .Discount_ = dt.Rows(0).Item("Discount") : End If
                If Not dt.Rows(0).Item("Extra") Is DBNull.Value Then : .Extra_ = dt.Rows(0).Item("Extra") : End If
                If Not dt.Rows(0).Item("Weight") Is DBNull.Value Then : .Weight_ = dt.Rows(0).Item("Weight") : End If
                If Not dt.Rows(0).Item("SubTotal") Is DBNull.Value Then : .SubTotal_ = dt.Rows(0).Item("SubTotal") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Fresh") Is DBNull.Value Then : .Fresh_ = dt.Rows(0).Item("Fresh") : End If
                If Not dt.Rows(0).Item("Frozen") Is DBNull.Value Then : .Frozen_ = dt.Rows(0).Item("Frozen") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderItems_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Discount") Is DBNull.Value Then : .Discount_ = dt.Rows(0).Item("Discount") : End If
                If Not dt.Rows(0).Item("Extra") Is DBNull.Value Then : .Extra_ = dt.Rows(0).Item("Extra") : End If
                If Not dt.Rows(0).Item("Weight") Is DBNull.Value Then : .Weight_ = dt.Rows(0).Item("Weight") : End If
                If Not dt.Rows(0).Item("SubTotal") Is DBNull.Value Then : .SubTotal_ = dt.Rows(0).Item("SubTotal") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Fresh") Is DBNull.Value Then : .Fresh_ = dt.Rows(0).Item("Fresh") : End If
                If Not dt.Rows(0).Item("Frozen") Is DBNull.Value Then : .Frozen_ = dt.Rows(0).Item("Frozen") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Extra
                fn = "Extra"
            Case FieldName.Weight
                fn = "Weight"
            Case FieldName.SubTotal
                fn = "SubTotal"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblOrderItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Extra
                fn = "Extra"
            Case FieldName.Weight
                fn = "Weight"
            Case FieldName.SubTotal
                fn = "SubTotal"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblOrderItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblProducts
    Public Shared tablename As String = "tblProducts"


    Structure Fields


        Dim ProductId_ As Int32
        Dim ProductCode_ As String
        Dim ProductName_ As String
        Dim FullName_ As String
        Dim Brand_ As String
        Dim Category_ As String
        Dim SubCategory_ As String
        Dim Price_ As Decimal
        Dim UnitOfMeasure_ As String
        Dim DateCreated_ As DateTime
        Dim DateUpdated_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedBy_ As Int32
        Dim Enabled_ As Boolean
        Dim TrackInventory_ As Boolean

    End Structure


    Enum FieldName


        [ProductId]
        [ProductCode]
        [ProductName]
        [FullName]
        [Brand]
        [Category]
        [SubCategory]
        [Price]
        [UnitOfMeasure]
        [DateCreated]
        [DateUpdated]
        [CreatedBy]
        [UpdatedBy]
        [Enabled]
        [TrackInventory]

    End Enum


    Public ReadOnly Property tblProducts_insert
        Get
            Return <tblProducts_insert><![CDATA[
  INSERT INTO [tblProducts]
  (
      [ProductId],
      [ProductCode],
      [ProductName],
      [FullName],
      [Brand],
      [Category],
      [SubCategory],
      [Price],
      [UnitOfMeasure],
      [DateCreated],
      [DateUpdated],
      [CreatedBy],
      [UpdatedBy],
      [Enabled],
      [TrackInventory]
  )
  VALUES
  (
      @ProductId_,
      @ProductCode_,
      @ProductName_,
      @FullName_,
      @Brand_,
      @Category_,
      @SubCategory_,
      @Price_,
      @UnitOfMeasure_,
      @DateCreated_,
      @DateUpdated_,
      @CreatedBy_,
      @UpdatedBy_,
      @Enabled_,
      @TrackInventory_
  )
]]></tblProducts_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_update
        Get
            Return <tblProducts_update><![CDATA[
UPDATE [tblProducts]
Set 
    [ProductCode]=@ProductCode_,
    [ProductName]=@ProductName_,
    [FullName]=@FullName_,
    [Brand]=@Brand_,
    [Category]=@Category_,
    [SubCategory]=@SubCategory_,
    [Price]=@Price_,
    [UnitOfMeasure]=@UnitOfMeasure_,
    [DateCreated]=@DateCreated_,
    [DateUpdated]=@DateUpdated_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedBy]=@UpdatedBy_,
    [Enabled]=@Enabled_,
    [TrackInventory]=@TrackInventory_
 WHERE [ProductId]=@ProductId_
]]></tblProducts_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblProducts_select
        Get
            Return <tblProducts_select><![CDATA[
SELECT 
      [ProductId],
      [ProductCode],
      [ProductName],
      [FullName],
      [Brand],
      [Category],
      [SubCategory],
      [Price],
      [UnitOfMeasure],
      [DateCreated],
      [DateUpdated],
      [CreatedBy],
      [UpdatedBy],
      [Enabled],
      [TrackInventory]
FROM [tblProducts]
    WHERE 1=1
]]></tblProducts_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_Delete_By_RowID
        Get
            Return <tblProducts_Delete_By_RowID><![CDATA[
DELETE FROM [tblProducts] WHERE [ProductId]=@ProductId_
]]></tblProducts_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_Delete_By_SELECT
        Get
            Return <tblProducts_Delete_By_SELECT><![CDATA[
DELETE FROM [tblProducts] WHERE 1=1
]]></tblProducts_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_MAXID
        Get
            Return <tblProducts_MAXID><![CDATA[
SELECT MAX([ProductId]) FROM [tblProducts] WHERE 1=1
]]></tblProducts_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblProducts_MAXID, _conn)
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
    ByVal ProductCode_ As String, _
    ByVal ProductName_ As String, _
    ByVal FullName_ As String, _
    ByVal Brand_ As String, _
    ByVal Category_ As String, _
    ByVal SubCategory_ As String, _
    ByVal Price_ As Decimal, _
    ByVal UnitOfMeasure_ As String, _
    ByVal DateCreated_ As DateTime, _
    ByVal DateUpdated_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Enabled_ As Boolean, _
    ByVal TrackInventory_ As Boolean, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ProductId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblProducts_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@ProductCode_", ProductCode_)
            .AddWithValue("@ProductName_", ProductName_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@Brand_", Brand_)
            .AddWithValue("@Category_", Category_)
            .AddWithValue("@SubCategory_", SubCategory_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@UnitOfMeasure_", UnitOfMeasure_)
            .AddWithValue("@DateCreated_", DateCreated_)
            .AddWithValue("@DateUpdated_", DateUpdated_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Enabled_", Enabled_)
            .AddWithValue("@TrackInventory_", TrackInventory_)

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
        Return ProductId_
    End Function



    Function Update(
    ByVal ProductCode_ As String, _
    ByVal ProductName_ As String, _
    ByVal FullName_ As String, _
    ByVal Brand_ As String, _
    ByVal Category_ As String, _
    ByVal SubCategory_ As String, _
    ByVal Price_ As Decimal, _
    ByVal UnitOfMeasure_ As String, _
    ByVal DateCreated_ As DateTime, _
    ByVal DateUpdated_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Enabled_ As Boolean, _
    ByVal TrackInventory_ As Boolean, _
    ByVal ProductId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblProducts_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ProductCode_", ProductCode_)
            .AddWithValue("@ProductName_", ProductName_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@Brand_", Brand_)
            .AddWithValue("@Category_", Category_)
            .AddWithValue("@SubCategory_", SubCategory_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@UnitOfMeasure_", UnitOfMeasure_)
            .AddWithValue("@DateCreated_", DateCreated_)
            .AddWithValue("@DateUpdated_", DateUpdated_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Enabled_", Enabled_)
            .AddWithValue("@TrackInventory_", TrackInventory_)
            .AddWithValue("@ProductId_", ProductId_)

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

        Return ProductId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.ProductCode
                fn = "ProductCode"
            Case FieldName.ProductName
                fn = "ProductName"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Brand
                fn = "Brand"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.SubCategory
                fn = "SubCategory"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.UnitOfMeasure
                fn = "UnitOfMeasure"
            Case FieldName.DateCreated
                fn = "DateCreated"
            Case FieldName.DateUpdated
                fn = "DateUpdated"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.TrackInventory
                fn = "TrackInventory"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblProducts] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblProducts_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ProductId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblProducts_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ProductId_", ProductId_)

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
        Return ProductId_
    End Function



    Function Selection_One_Row( _
     ByVal ProductId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblProducts_select & "  AND [ProductId]=@ProductId_"

        With comSelection.Parameters
            .AddWithValue("@ProductId_", ProductId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("ProductCode") Is DBNull.Value Then : .ProductCode_ = dt.Rows(0).Item("ProductCode") : End If
                If Not dt.Rows(0).Item("ProductName") Is DBNull.Value Then : .ProductName_ = dt.Rows(0).Item("ProductName") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("Brand") Is DBNull.Value Then : .Brand_ = dt.Rows(0).Item("Brand") : End If
                If Not dt.Rows(0).Item("Category") Is DBNull.Value Then : .Category_ = dt.Rows(0).Item("Category") : End If
                If Not dt.Rows(0).Item("SubCategory") Is DBNull.Value Then : .SubCategory_ = dt.Rows(0).Item("SubCategory") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("UnitOfMeasure") Is DBNull.Value Then : .UnitOfMeasure_ = dt.Rows(0).Item("UnitOfMeasure") : End If
                If Not dt.Rows(0).Item("DateCreated") Is DBNull.Value Then : .DateCreated_ = dt.Rows(0).Item("DateCreated") : End If
                If Not dt.Rows(0).Item("DateUpdated") Is DBNull.Value Then : .DateUpdated_ = dt.Rows(0).Item("DateUpdated") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Enabled") Is DBNull.Value Then : .Enabled_ = dt.Rows(0).Item("Enabled") : End If
                If Not dt.Rows(0).Item("TrackInventory") Is DBNull.Value Then : .TrackInventory_ = dt.Rows(0).Item("TrackInventory") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblProducts_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("ProductCode") Is DBNull.Value Then : .ProductCode_ = dt.Rows(0).Item("ProductCode") : End If
                If Not dt.Rows(0).Item("ProductName") Is DBNull.Value Then : .ProductName_ = dt.Rows(0).Item("ProductName") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("Brand") Is DBNull.Value Then : .Brand_ = dt.Rows(0).Item("Brand") : End If
                If Not dt.Rows(0).Item("Category") Is DBNull.Value Then : .Category_ = dt.Rows(0).Item("Category") : End If
                If Not dt.Rows(0).Item("SubCategory") Is DBNull.Value Then : .SubCategory_ = dt.Rows(0).Item("SubCategory") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("UnitOfMeasure") Is DBNull.Value Then : .UnitOfMeasure_ = dt.Rows(0).Item("UnitOfMeasure") : End If
                If Not dt.Rows(0).Item("DateCreated") Is DBNull.Value Then : .DateCreated_ = dt.Rows(0).Item("DateCreated") : End If
                If Not dt.Rows(0).Item("DateUpdated") Is DBNull.Value Then : .DateUpdated_ = dt.Rows(0).Item("DateUpdated") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Enabled") Is DBNull.Value Then : .Enabled_ = dt.Rows(0).Item("Enabled") : End If
                If Not dt.Rows(0).Item("TrackInventory") Is DBNull.Value Then : .TrackInventory_ = dt.Rows(0).Item("TrackInventory") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.ProductCode
                fn = "ProductCode"
            Case FieldName.ProductName
                fn = "ProductName"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Brand
                fn = "Brand"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.SubCategory
                fn = "SubCategory"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.UnitOfMeasure
                fn = "UnitOfMeasure"
            Case FieldName.DateCreated
                fn = "DateCreated"
            Case FieldName.DateUpdated
                fn = "DateUpdated"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.TrackInventory
                fn = "TrackInventory"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblProducts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.ProductCode
                fn = "ProductCode"
            Case FieldName.ProductName
                fn = "ProductName"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Brand
                fn = "Brand"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.SubCategory
                fn = "SubCategory"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.UnitOfMeasure
                fn = "UnitOfMeasure"
            Case FieldName.DateCreated
                fn = "DateCreated"
            Case FieldName.DateUpdated
                fn = "DateUpdated"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.TrackInventory
                fn = "TrackInventory"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblProducts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblVendor
    Public Shared tablename As String = "tblVendor"


    Structure Fields


        Dim VendorID_ As Int32
        Dim VendorName_ As String
        Dim Address_ As String
        Dim City_ As String
        Dim State_ As String
        Dim Zip_ As String
        Dim Notes_ As String
        Dim Status_ As String
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim Phone_ As String
        Dim Email_ As String
        Dim Website_ As String
        Dim Fax_ As String

    End Structure


    Enum FieldName


        [VendorID]
        [VendorName]
        [Address]
        [City]
        [State]
        [Zip]
        [Notes]
        [Status]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [Phone]
        [Email]
        [Website]
        [Fax]

    End Enum


    Public ReadOnly Property tblVendor_insert
        Get
            Return <tblVendor_insert><![CDATA[
  INSERT INTO [tblVendor]
  (
      [VendorID],
      [VendorName],
      [Address],
      [City],
      [State],
      [Zip],
      [Notes],
      [Status],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Phone],
      [Email],
      [Website],
      [Fax]
  )
  VALUES
  (
      @VendorID_,
      @VendorName_,
      @Address_,
      @City_,
      @State_,
      @Zip_,
      @Notes_,
      @Status_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @Phone_,
      @Email_,
      @Website_,
      @Fax_
  )
]]></tblVendor_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblVendor_update
        Get
            Return <tblVendor_update><![CDATA[
UPDATE [tblVendor]
Set 
    [VendorName]=@VendorName_,
    [Address]=@Address_,
    [City]=@City_,
    [State]=@State_,
    [Zip]=@Zip_,
    [Notes]=@Notes_,
    [Status]=@Status_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [Phone]=@Phone_,
    [Email]=@Email_,
    [Website]=@Website_,
    [Fax]=@Fax_
 WHERE [VendorID]=@VendorID_
]]></tblVendor_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblVendor_select
        Get
            Return <tblVendor_select><![CDATA[
SELECT 
      [VendorID],
      [VendorName],
      [Address],
      [City],
      [State],
      [Zip],
      [Notes],
      [Status],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Phone],
      [Email],
      [Website],
      [Fax]
FROM [tblVendor]
    WHERE 1=1
]]></tblVendor_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblVendor_Delete_By_RowID
        Get
            Return <tblVendor_Delete_By_RowID><![CDATA[
DELETE FROM [tblVendor] WHERE [VendorID]=@VendorID_
]]></tblVendor_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblVendor_Delete_By_SELECT
        Get
            Return <tblVendor_Delete_By_SELECT><![CDATA[
DELETE FROM [tblVendor] WHERE 1=1
]]></tblVendor_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblVendor_MAXID
        Get
            Return <tblVendor_MAXID><![CDATA[
SELECT MAX([VendorID]) FROM [tblVendor] WHERE 1=1
]]></tblVendor_MAXID>.Value
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



    Function Insert( _
    ByVal VendorName_ As String, _
    ByVal Address_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Notes_ As String, _
    ByVal Status_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Phone_ As String, _
    ByVal Email_ As String, _
    ByVal Website_ As String, _
    ByVal Fax_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim VendorID_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@VendorID_", VendorID_)
            .AddWithValue("@VendorName_", VendorName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@Website_", Website_)
            .AddWithValue("@Fax_", Fax_)

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
        Return VendorID_
    End Function



    Function Update(
    ByVal VendorName_ As String, _
    ByVal Address_ As String, _
    ByVal City_ As String, _
    ByVal State_ As String, _
    ByVal Zip_ As String, _
    ByVal Notes_ As String, _
    ByVal Status_ As String, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Phone_ As String, _
    ByVal Email_ As String, _
    ByVal Website_ As String, _
    ByVal Fax_ As String, _
    ByVal VendorID_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@VendorName_", VendorName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@Website_", Website_)
            .AddWithValue("@Fax_", Fax_)
            .AddWithValue("@VendorID_", VendorID_)

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

        Return VendorID_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.VendorID
                fn = "VendorID"
            Case FieldName.VendorName
                fn = "VendorName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.Fax
                fn = "Fax"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblVendor] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblVendor_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal VendorID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblVendor_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@VendorID_", VendorID_)

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
        Return VendorID_
    End Function



    Function Selection_One_Row( _
     ByVal VendorID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblVendor_select & "  AND [VendorID]=@VendorID_"

        With comSelection.Parameters
            .AddWithValue("@VendorID_", VendorID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("VendorID") Is DBNull.Value Then : .VendorID_ = dt.Rows(0).Item("VendorID") : End If
                If Not dt.Rows(0).Item("VendorName") Is DBNull.Value Then : .VendorName_ = dt.Rows(0).Item("VendorName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("Website") Is DBNull.Value Then : .Website_ = dt.Rows(0).Item("Website") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblVendor_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("VendorID") Is DBNull.Value Then : .VendorID_ = dt.Rows(0).Item("VendorID") : End If
                If Not dt.Rows(0).Item("VendorName") Is DBNull.Value Then : .VendorName_ = dt.Rows(0).Item("VendorName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("Website") Is DBNull.Value Then : .Website_ = dt.Rows(0).Item("Website") : End If
                If Not dt.Rows(0).Item("Fax") Is DBNull.Value Then : .Fax_ = dt.Rows(0).Item("Fax") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.VendorID
                fn = "VendorID"
            Case FieldName.VendorName
                fn = "VendorName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.Fax
                fn = "Fax"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblVendor] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.VendorID
                fn = "VendorID"
            Case FieldName.VendorName
                fn = "VendorName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Website
                fn = "Website"
            Case FieldName.Fax
                fn = "Fax"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblVendor] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblPurchase
    Public Shared tablename As String = "tblPurchase"


    Structure Fields


        Dim PurchaseId_ As Int32
        Dim VendorId_ As Int32
        Dim PurchaseDate_ As DateTime
        Dim PO_No_ As String
        Dim InvoiceNo_ As String
        Dim TotalAmount_ As Decimal
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim Session_ As String

    End Structure


    Enum FieldName


        [PurchaseId]
        [VendorId]
        [PurchaseDate]
        [PO_No]
        [InvoiceNo]
        [TotalAmount]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [Session]

    End Enum


    Public ReadOnly Property tblPurchase_insert
        Get
            Return <tblPurchase_insert><![CDATA[
  INSERT INTO [tblPurchase]
  (
      [PurchaseId],
      [VendorId],
      [PurchaseDate],
      [PO_No],
      [InvoiceNo],
      [TotalAmount],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Session]
  )
  VALUES
  (
      @PurchaseId_,
      @VendorId_,
      @PurchaseDate_,
      @PO_No_,
      @InvoiceNo_,
      @TotalAmount_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @Session_
  )
]]></tblPurchase_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblPurchase_update
        Get
            Return <tblPurchase_update><![CDATA[
UPDATE [tblPurchase]
Set 
    [VendorId]=@VendorId_,
    [PurchaseDate]=@PurchaseDate_,
    [PO_No]=@PO_No_,
    [InvoiceNo]=@InvoiceNo_,
    [TotalAmount]=@TotalAmount_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [Session]=@Session_
 WHERE [PurchaseId]=@PurchaseId_
]]></tblPurchase_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblPurchase_select
        Get
            Return <tblPurchase_select><![CDATA[
SELECT 
      [PurchaseId],
      [VendorId],
      [PurchaseDate],
      [PO_No],
      [InvoiceNo],
      [TotalAmount],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Session]
FROM [tblPurchase]
    WHERE 1=1
]]></tblPurchase_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblPurchase_Delete_By_RowID
        Get
            Return <tblPurchase_Delete_By_RowID><![CDATA[
DELETE FROM [tblPurchase] WHERE [PurchaseId]=@PurchaseId_
]]></tblPurchase_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblPurchase_Delete_By_SELECT
        Get
            Return <tblPurchase_Delete_By_SELECT><![CDATA[
DELETE FROM [tblPurchase] WHERE 1=1
]]></tblPurchase_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblPurchase_MAXID
        Get
            Return <tblPurchase_MAXID><![CDATA[
SELECT MAX([PurchaseId]) FROM [tblPurchase] WHERE 1=1
]]></tblPurchase_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblPurchase_MAXID, _conn)
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
    ByVal VendorId_ As Int32, _
    ByVal PurchaseDate_ As DateTime, _
    ByVal PO_No_ As String, _
    ByVal InvoiceNo_ As String, _
    ByVal TotalAmount_ As Decimal, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Session_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim PurchaseId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblPurchase_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@PurchaseId_", PurchaseId_)
            .AddWithValue("@VendorId_", VendorId_)
            .AddWithValue("@PurchaseDate_", PurchaseDate_)
            .AddWithValue("@PO_No_", PO_No_)
            .AddWithValue("@InvoiceNo_", InvoiceNo_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Session_", Session_)

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
        Return PurchaseId_
    End Function



    Function Update(
    ByVal VendorId_ As Int32, _
    ByVal PurchaseDate_ As DateTime, _
    ByVal PO_No_ As String, _
    ByVal InvoiceNo_ As String, _
    ByVal TotalAmount_ As Decimal, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Session_ As String, _
    ByVal PurchaseId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblPurchase_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@VendorId_", VendorId_)
            .AddWithValue("@PurchaseDate_", PurchaseDate_)
            .AddWithValue("@PO_No_", PO_No_)
            .AddWithValue("@InvoiceNo_", InvoiceNo_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@PurchaseId_", PurchaseId_)

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

        Return PurchaseId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.PurchaseId
                fn = "PurchaseId"
            Case FieldName.VendorId
                fn = "VendorId"
            Case FieldName.PurchaseDate
                fn = "PurchaseDate"
            Case FieldName.PO_No
                fn = "PO_No"
            Case FieldName.InvoiceNo
                fn = "InvoiceNo"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblPurchase] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblPurchase_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal PurchaseId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblPurchase_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@PurchaseId_", PurchaseId_)

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
        Return PurchaseId_
    End Function



    Function Selection_One_Row( _
     ByVal PurchaseId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblPurchase_select & "  AND [PurchaseId]=@PurchaseId_"

        With comSelection.Parameters
            .AddWithValue("@PurchaseId_", PurchaseId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("PurchaseId") Is DBNull.Value Then : .PurchaseId_ = dt.Rows(0).Item("PurchaseId") : End If
                If Not dt.Rows(0).Item("VendorId") Is DBNull.Value Then : .VendorId_ = dt.Rows(0).Item("VendorId") : End If
                If Not dt.Rows(0).Item("PurchaseDate") Is DBNull.Value Then : .PurchaseDate_ = dt.Rows(0).Item("PurchaseDate") : End If
                If Not dt.Rows(0).Item("PO_No") Is DBNull.Value Then : .PO_No_ = dt.Rows(0).Item("PO_No") : End If
                If Not dt.Rows(0).Item("InvoiceNo") Is DBNull.Value Then : .InvoiceNo_ = dt.Rows(0).Item("InvoiceNo") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblPurchase_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("PurchaseId") Is DBNull.Value Then : .PurchaseId_ = dt.Rows(0).Item("PurchaseId") : End If
                If Not dt.Rows(0).Item("VendorId") Is DBNull.Value Then : .VendorId_ = dt.Rows(0).Item("VendorId") : End If
                If Not dt.Rows(0).Item("PurchaseDate") Is DBNull.Value Then : .PurchaseDate_ = dt.Rows(0).Item("PurchaseDate") : End If
                If Not dt.Rows(0).Item("PO_No") Is DBNull.Value Then : .PO_No_ = dt.Rows(0).Item("PO_No") : End If
                If Not dt.Rows(0).Item("InvoiceNo") Is DBNull.Value Then : .InvoiceNo_ = dt.Rows(0).Item("InvoiceNo") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.PurchaseId
                fn = "PurchaseId"
            Case FieldName.VendorId
                fn = "VendorId"
            Case FieldName.PurchaseDate
                fn = "PurchaseDate"
            Case FieldName.PO_No
                fn = "PO_No"
            Case FieldName.InvoiceNo
                fn = "InvoiceNo"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblPurchase] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.PurchaseId
                fn = "PurchaseId"
            Case FieldName.VendorId
                fn = "VendorId"
            Case FieldName.PurchaseDate
                fn = "PurchaseDate"
            Case FieldName.PO_No
                fn = "PO_No"
            Case FieldName.InvoiceNo
                fn = "InvoiceNo"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblPurchase] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblProductPrice
    Public Shared tablename As String = "tblProductPrice"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim PID_ As Int32
        Dim CostPrice_ As Decimal
        Dim SellPrice_ As Decimal
        Dim EntryDate_ As DateTime
        Dim UserId_ As Int32
        Dim VendorId_ As Int32
        Dim UnitOfMesuare_ As String
        Dim VendorItemCode_ As String

    End Structure


    Enum FieldName


        [ItemSl]
        [PID]
        [CostPrice]
        [SellPrice]
        [EntryDate]
        [UserId]
        [VendorId]
        [UnitOfMesuare]
        [VendorItemCode]

    End Enum


    Public ReadOnly Property tblProductPrice_insert
        Get
            Return <tblProductPrice_insert><![CDATA[
  INSERT INTO [tblProductPrice]
  (
      [ItemSl],
      [PID],
      [CostPrice],
      [SellPrice],
      [EntryDate],
      [UserId],
      [VendorId],
      [UnitOfMesuare],
      [VendorItemCode]
  )
  VALUES
  (
      @ItemSl_,
      @PID_,
      @CostPrice_,
      @SellPrice_,
      @EntryDate_,
      @UserId_,
      @VendorId_,
      @UnitOfMesuare_,
      @VendorItemCode_
  )
]]></tblProductPrice_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductPrice_update
        Get
            Return <tblProductPrice_update><![CDATA[
UPDATE [tblProductPrice]
Set 
    [PID]=@PID_,
    [CostPrice]=@CostPrice_,
    [SellPrice]=@SellPrice_,
    [EntryDate]=@EntryDate_,
    [UserId]=@UserId_,
    [VendorId]=@VendorId_,
    [UnitOfMesuare]=@UnitOfMesuare_,
    [VendorItemCode]=@VendorItemCode_
 WHERE [ItemSl]=@ItemSl_
]]></tblProductPrice_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblProductPrice_select
        Get
            Return <tblProductPrice_select><![CDATA[
SELECT 
      [ItemSl],
      [PID],
      [CostPrice],
      [SellPrice],
      [EntryDate],
      [UserId],
      [VendorId],
      [UnitOfMesuare],
      [VendorItemCode]
FROM [tblProductPrice]
    WHERE 1=1
]]></tblProductPrice_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductPrice_Delete_By_RowID
        Get
            Return <tblProductPrice_Delete_By_RowID><![CDATA[
DELETE FROM [tblProductPrice] WHERE [ItemSl]=@ItemSl_
]]></tblProductPrice_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductPrice_Delete_By_SELECT
        Get
            Return <tblProductPrice_Delete_By_SELECT><![CDATA[
DELETE FROM [tblProductPrice] WHERE 1=1
]]></tblProductPrice_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductPrice_MAXID
        Get
            Return <tblProductPrice_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblProductPrice] WHERE 1=1
]]></tblProductPrice_MAXID>.Value
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
    ByVal PID_ As Int32, _
    ByVal CostPrice_ As Decimal, _
    ByVal SellPrice_ As Decimal, _
    ByVal EntryDate_ As DateTime, _
    ByVal UserId_ As Int32, _
    ByVal VendorId_ As Int32, _
    ByVal UnitOfMesuare_ As String, _
    ByVal VendorItemCode_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@PID_", PID_)
            .AddWithValue("@CostPrice_", CostPrice_)
            .AddWithValue("@SellPrice_", SellPrice_)
            .AddWithValue("@EntryDate_", EntryDate_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@VendorId_", VendorId_)
            .AddWithValue("@UnitOfMesuare_", UnitOfMesuare_)
            .AddWithValue("@VendorItemCode_", VendorItemCode_)

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
        Return ItemSl_
    End Function



    Function Update(
    ByVal PID_ As Int32, _
    ByVal CostPrice_ As Decimal, _
    ByVal SellPrice_ As Decimal, _
    ByVal EntryDate_ As DateTime, _
    ByVal UserId_ As Int32, _
    ByVal VendorId_ As Int32, _
    ByVal UnitOfMesuare_ As String, _
    ByVal VendorItemCode_ As String, _
    ByVal ItemSl_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@PID_", PID_)
            .AddWithValue("@CostPrice_", CostPrice_)
            .AddWithValue("@SellPrice_", SellPrice_)
            .AddWithValue("@EntryDate_", EntryDate_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@VendorId_", VendorId_)
            .AddWithValue("@UnitOfMesuare_", UnitOfMesuare_)
            .AddWithValue("@VendorItemCode_", VendorItemCode_)
            .AddWithValue("@ItemSl_", ItemSl_)

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

        Return ItemSl_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.PID
                fn = "PID"
            Case FieldName.CostPrice
                fn = "CostPrice"
            Case FieldName.SellPrice
                fn = "SellPrice"
            Case FieldName.EntryDate
                fn = "EntryDate"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.VendorId
                fn = "VendorId"
            Case FieldName.UnitOfMesuare
                fn = "UnitOfMesuare"
            Case FieldName.VendorItemCode
                fn = "VendorItemCode"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblProductPrice] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblProductPrice_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblProductPrice_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

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
        Return ItemSl_
    End Function



    Function Selection_One_Row( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblProductPrice_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("PID") Is DBNull.Value Then : .PID_ = dt.Rows(0).Item("PID") : End If
                If Not dt.Rows(0).Item("CostPrice") Is DBNull.Value Then : .CostPrice_ = dt.Rows(0).Item("CostPrice") : End If
                If Not dt.Rows(0).Item("SellPrice") Is DBNull.Value Then : .SellPrice_ = dt.Rows(0).Item("SellPrice") : End If
                If Not dt.Rows(0).Item("EntryDate") Is DBNull.Value Then : .EntryDate_ = dt.Rows(0).Item("EntryDate") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("VendorId") Is DBNull.Value Then : .VendorId_ = dt.Rows(0).Item("VendorId") : End If
                If Not dt.Rows(0).Item("UnitOfMesuare") Is DBNull.Value Then : .UnitOfMesuare_ = dt.Rows(0).Item("UnitOfMesuare") : End If
                If Not dt.Rows(0).Item("VendorItemCode") Is DBNull.Value Then : .VendorItemCode_ = dt.Rows(0).Item("VendorItemCode") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblProductPrice_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("PID") Is DBNull.Value Then : .PID_ = dt.Rows(0).Item("PID") : End If
                If Not dt.Rows(0).Item("CostPrice") Is DBNull.Value Then : .CostPrice_ = dt.Rows(0).Item("CostPrice") : End If
                If Not dt.Rows(0).Item("SellPrice") Is DBNull.Value Then : .SellPrice_ = dt.Rows(0).Item("SellPrice") : End If
                If Not dt.Rows(0).Item("EntryDate") Is DBNull.Value Then : .EntryDate_ = dt.Rows(0).Item("EntryDate") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("VendorId") Is DBNull.Value Then : .VendorId_ = dt.Rows(0).Item("VendorId") : End If
                If Not dt.Rows(0).Item("UnitOfMesuare") Is DBNull.Value Then : .UnitOfMesuare_ = dt.Rows(0).Item("UnitOfMesuare") : End If
                If Not dt.Rows(0).Item("VendorItemCode") Is DBNull.Value Then : .VendorItemCode_ = dt.Rows(0).Item("VendorItemCode") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.PID
                fn = "PID"
            Case FieldName.CostPrice
                fn = "CostPrice"
            Case FieldName.SellPrice
                fn = "SellPrice"
            Case FieldName.EntryDate
                fn = "EntryDate"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.VendorId
                fn = "VendorId"
            Case FieldName.UnitOfMesuare
                fn = "UnitOfMesuare"
            Case FieldName.VendorItemCode
                fn = "VendorItemCode"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblProductPrice] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.PID
                fn = "PID"
            Case FieldName.CostPrice
                fn = "CostPrice"
            Case FieldName.SellPrice
                fn = "SellPrice"
            Case FieldName.EntryDate
                fn = "EntryDate"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.VendorId
                fn = "VendorId"
            Case FieldName.UnitOfMesuare
                fn = "UnitOfMesuare"
            Case FieldName.VendorItemCode
                fn = "VendorItemCode"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblProductPrice] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblTemplate
    Public Shared tablename As String = "tblTemplate"


    Structure Fields


        Dim TemplateId_ As Int32
        Dim TemplateName_ As String
        Dim CutomerId_ As Int32
        Dim TotalItems_ As Int32
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim Remarks_ As String
        Dim Comments_ As String

    End Structure


    Enum FieldName


        [TemplateId]
        [TemplateName]
        [CutomerId]
        [TotalItems]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [Remarks]
        [Comments]

    End Enum


    Public ReadOnly Property tblTemplate_insert
        Get
            Return <tblTemplate_insert><![CDATA[
  INSERT INTO [tblTemplate]
  (
      [TemplateId],
      [TemplateName],
      [CutomerId],
      [TotalItems],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Remarks],
      [Comments]
  )
  VALUES
  (
      @TemplateId_,
      @TemplateName_,
      @CutomerId_,
      @TotalItems_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @Remarks_,
      @Comments_
  )
]]></tblTemplate_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplate_update
        Get
            Return <tblTemplate_update><![CDATA[
UPDATE [tblTemplate]
Set 
    [TemplateName]=@TemplateName_,
    [CutomerId]=@CutomerId_,
    [TotalItems]=@TotalItems_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [Remarks]=@Remarks_,
    [Comments]=@Comments_
 WHERE [TemplateId]=@TemplateId_
]]></tblTemplate_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblTemplate_select
        Get
            Return <tblTemplate_select><![CDATA[
SELECT 
      [TemplateId],
      [TemplateName],
      [CutomerId],
      [TotalItems],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Remarks],
      [Comments]
FROM [tblTemplate]
    WHERE 1=1
]]></tblTemplate_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplate_Delete_By_RowID
        Get
            Return <tblTemplate_Delete_By_RowID><![CDATA[
DELETE FROM [tblTemplate] WHERE [TemplateId]=@TemplateId_
]]></tblTemplate_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplate_Delete_By_SELECT
        Get
            Return <tblTemplate_Delete_By_SELECT><![CDATA[
DELETE FROM [tblTemplate] WHERE 1=1
]]></tblTemplate_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplate_MAXID
        Get
            Return <tblTemplate_MAXID><![CDATA[
SELECT MAX([TemplateId]) FROM [tblTemplate] WHERE 1=1
]]></tblTemplate_MAXID>.Value
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
    ByVal TemplateName_ As String, _
    ByVal CutomerId_ As Int32, _
    ByVal TotalItems_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Comments_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim TemplateId_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@TemplateId_", TemplateId_)
            .AddWithValue("@TemplateName_", TemplateName_)
            .AddWithValue("@CutomerId_", CutomerId_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Comments_", Comments_)

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
        Return TemplateId_
    End Function



    Function Update(
    ByVal TemplateName_ As String, _
    ByVal CutomerId_ As Int32, _
    ByVal TotalItems_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Comments_ As String, _
    ByVal TemplateId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@TemplateName_", TemplateName_)
            .AddWithValue("@CutomerId_", CutomerId_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@TemplateId_", TemplateId_)

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

        Return TemplateId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.TemplateId
                fn = "TemplateId"
            Case FieldName.TemplateName
                fn = "TemplateName"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblTemplate] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblTemplate_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal TemplateId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblTemplate_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@TemplateId_", TemplateId_)

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
        Return TemplateId_
    End Function



    Function Selection_One_Row( _
     ByVal TemplateId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTemplate_select & "  AND [TemplateId]=@TemplateId_"

        With comSelection.Parameters
            .AddWithValue("@TemplateId_", TemplateId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("TemplateId") Is DBNull.Value Then : .TemplateId_ = dt.Rows(0).Item("TemplateId") : End If
                If Not dt.Rows(0).Item("TemplateName") Is DBNull.Value Then : .TemplateName_ = dt.Rows(0).Item("TemplateName") : End If
                If Not dt.Rows(0).Item("CutomerId") Is DBNull.Value Then : .CutomerId_ = dt.Rows(0).Item("CutomerId") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTemplate_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("TemplateId") Is DBNull.Value Then : .TemplateId_ = dt.Rows(0).Item("TemplateId") : End If
                If Not dt.Rows(0).Item("TemplateName") Is DBNull.Value Then : .TemplateName_ = dt.Rows(0).Item("TemplateName") : End If
                If Not dt.Rows(0).Item("CutomerId") Is DBNull.Value Then : .CutomerId_ = dt.Rows(0).Item("CutomerId") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.TemplateId
                fn = "TemplateId"
            Case FieldName.TemplateName
                fn = "TemplateName"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblTemplate] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.TemplateId
                fn = "TemplateId"
            Case FieldName.TemplateName
                fn = "TemplateName"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblTemplate] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblTemplateItems
    Public Shared tablename As String = "tblTemplateItems"


    Structure Fields


        Dim ItemId_ As Int32
        Dim TemplateId_ As Int32
        Dim Sl_ As Int32
        Dim ProductId_ As Int32
        Dim Notes_ As String
        Dim EntryDate_ As DateTime

    End Structure


    Enum FieldName


        [ItemId]
        [TemplateId]
        [Sl]
        [ProductId]
        [Notes]
        [EntryDate]

    End Enum


    Public ReadOnly Property tblTemplateItems_insert
        Get
            Return <tblTemplateItems_insert><![CDATA[
  INSERT INTO [tblTemplateItems]
  (
      [ItemId],
      [TemplateId],
      [Sl],
      [ProductId],
      [Notes],
      [EntryDate]
  )
  VALUES
  (
      @ItemId_,
      @TemplateId_,
      @Sl_,
      @ProductId_,
      @Notes_,
      @EntryDate_
  )
]]></tblTemplateItems_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplateItems_update
        Get
            Return <tblTemplateItems_update><![CDATA[
UPDATE [tblTemplateItems]
Set 
    [TemplateId]=@TemplateId_,
    [Sl]=@Sl_,
    [ProductId]=@ProductId_,
    [Notes]=@Notes_,
    [EntryDate]=@EntryDate_
 WHERE [ItemId]=@ItemId_
]]></tblTemplateItems_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblTemplateItems_select
        Get
            Return <tblTemplateItems_select><![CDATA[
SELECT 
      [ItemId],
      [TemplateId],
      [Sl],
      [ProductId],
      [Notes],
      [EntryDate]
FROM [tblTemplateItems]
    WHERE 1=1
]]></tblTemplateItems_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplateItems_Delete_By_RowID
        Get
            Return <tblTemplateItems_Delete_By_RowID><![CDATA[
DELETE FROM [tblTemplateItems] WHERE [ItemId]=@ItemId_
]]></tblTemplateItems_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplateItems_Delete_By_SELECT
        Get
            Return <tblTemplateItems_Delete_By_SELECT><![CDATA[
DELETE FROM [tblTemplateItems] WHERE 1=1
]]></tblTemplateItems_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblTemplateItems_MAXID
        Get
            Return <tblTemplateItems_MAXID><![CDATA[
SELECT MAX([ItemId]) FROM [tblTemplateItems] WHERE 1=1
]]></tblTemplateItems_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblTemplateItems_MAXID, _conn)
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
    ByVal TemplateId_ As Int32, _
    ByVal Sl_ As Int32, _
    ByVal ProductId_ As Int32, _
    ByVal Notes_ As String, _
    ByVal EntryDate_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblTemplateItems_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemId_", ItemId_)
            .AddWithValue("@TemplateId_", TemplateId_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@EntryDate_", EntryDate_)

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
        Return ItemId_
    End Function



    Function Update(
    ByVal TemplateId_ As Int32, _
    ByVal Sl_ As Int32, _
    ByVal ProductId_ As Int32, _
    ByVal Notes_ As String, _
    ByVal EntryDate_ As DateTime, _
    ByVal ItemId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblTemplateItems_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@TemplateId_", TemplateId_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@EntryDate_", EntryDate_)
            .AddWithValue("@ItemId_", ItemId_)

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

        Return ItemId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.TemplateId
                fn = "TemplateId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.EntryDate
                fn = "EntryDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblTemplateItems] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblTemplateItems_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblTemplateItems_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId_", ItemId_)

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
        Return ItemId_
    End Function



    Function Selection_One_Row( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTemplateItems_select & "  AND [ItemId]=@ItemId_"

        With comSelection.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("TemplateId") Is DBNull.Value Then : .TemplateId_ = dt.Rows(0).Item("TemplateId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("EntryDate") Is DBNull.Value Then : .EntryDate_ = dt.Rows(0).Item("EntryDate") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTemplateItems_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("TemplateId") Is DBNull.Value Then : .TemplateId_ = dt.Rows(0).Item("TemplateId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("EntryDate") Is DBNull.Value Then : .EntryDate_ = dt.Rows(0).Item("EntryDate") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.TemplateId
                fn = "TemplateId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.EntryDate
                fn = "EntryDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblTemplateItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.TemplateId
                fn = "TemplateId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.EntryDate
                fn = "EntryDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblTemplateItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblStock
    Public Shared tablename As String = "tblStock"


    Structure Fields


        Dim StockId_ As Int32
        Dim ProductId_ As Int32
        Dim Qty_ As Int64
        Dim TransactionId_ As Int32
        Dim TransactionType_ As String
        Dim Stocktype_ As String
        Dim CreatedBy_ As Int32
        Dim CreatedDate_ As DateTime
        Dim Remarks_ As String
        Dim Fresh_ As Int32
        Dim Frozen_ As Int32
        Dim TransactionDate_ As DateTime

    End Structure


    Enum FieldName


        [StockId]
        [ProductId]
        [Qty]
        [TransactionId]
        [TransactionType]
        [Stocktype]
        [CreatedBy]
        [CreatedDate]
        [Remarks]
        [Fresh]
        [Frozen]
        [TransactionDate]

    End Enum


    Public ReadOnly Property tblStock_insert
        Get
            Return <tblStock_insert><![CDATA[
  INSERT INTO [tblStock]
  (
      [StockId],
      [ProductId],
      [Qty],
      [TransactionId],
      [TransactionType],
      [Stocktype],
      [CreatedBy],
      [CreatedDate],
      [Remarks],
      [Fresh],
      [Frozen],
      [TransactionDate]
  )
  VALUES
  (
      @StockId_,
      @ProductId_,
      @Qty_,
      @TransactionId_,
      @TransactionType_,
      @Stocktype_,
      @CreatedBy_,
      @CreatedDate_,
      @Remarks_,
      @Fresh_,
      @Frozen_,
      @TransactionDate_
  )
]]></tblStock_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_update
        Get
            Return <tblStock_update><![CDATA[
UPDATE [tblStock]
Set 
    [ProductId]=@ProductId_,
    [Qty]=@Qty_,
    [TransactionId]=@TransactionId_,
    [TransactionType]=@TransactionType_,
    [Stocktype]=@Stocktype_,
    [CreatedBy]=@CreatedBy_,
    [CreatedDate]=@CreatedDate_,
    [Remarks]=@Remarks_,
    [Fresh]=@Fresh_,
    [Frozen]=@Frozen_,
    [TransactionDate]=@TransactionDate_
 WHERE [StockId]=@StockId_
]]></tblStock_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblStock_select
        Get
            Return <tblStock_select><![CDATA[
SELECT 
      [StockId],
      [ProductId],
      [Qty],
      [TransactionId],
      [TransactionType],
      [Stocktype],
      [CreatedBy],
      [CreatedDate],
      [Remarks],
      [Fresh],
      [Frozen],
      [TransactionDate]
FROM [tblStock]
    WHERE 1=1
]]></tblStock_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_Delete_By_RowID
        Get
            Return <tblStock_Delete_By_RowID><![CDATA[
DELETE FROM [tblStock] WHERE [StockId]=@StockId_
]]></tblStock_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_Delete_By_SELECT
        Get
            Return <tblStock_Delete_By_SELECT><![CDATA[
DELETE FROM [tblStock] WHERE 1=1
]]></tblStock_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_MAXID
        Get
            Return <tblStock_MAXID><![CDATA[
SELECT MAX([StockId]) FROM [tblStock] WHERE 1=1
]]></tblStock_MAXID>.Value
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
    ByVal ProductId_ As Int32, _
    ByVal Qty_ As Int64, _
    ByVal TransactionId_ As Int32, _
    ByVal TransactionType_ As String, _
    ByVal Stocktype_ As String, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
    ByVal Remarks_ As String, _
    ByVal Fresh_ As Int32, _
    ByVal Frozen_ As Int32, _
    ByVal TransactionDate_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim StockId_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@StockId_", StockId_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@TransactionId_", TransactionId_)
            .AddWithValue("@TransactionType_", TransactionType_)
            .AddWithValue("@Stocktype_", Stocktype_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Fresh_", Fresh_)
            .AddWithValue("@Frozen_", Frozen_)
            .AddWithValue("@TransactionDate_", TransactionDate_)

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
        Return StockId_
    End Function



    Function Update(
    ByVal ProductId_ As Int32, _
    ByVal Qty_ As Int64, _
    ByVal TransactionId_ As Int32, _
    ByVal TransactionType_ As String, _
    ByVal Stocktype_ As String, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
    ByVal Remarks_ As String, _
    ByVal Fresh_ As Int32, _
    ByVal Frozen_ As Int32, _
    ByVal TransactionDate_ As DateTime, _
    ByVal StockId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@TransactionId_", TransactionId_)
            .AddWithValue("@TransactionType_", TransactionType_)
            .AddWithValue("@Stocktype_", Stocktype_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Fresh_", Fresh_)
            .AddWithValue("@Frozen_", Frozen_)
            .AddWithValue("@TransactionDate_", TransactionDate_)
            .AddWithValue("@StockId_", StockId_)

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

        Return StockId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.TransactionId
                fn = "TransactionId"
            Case FieldName.TransactionType
                fn = "TransactionType"
            Case FieldName.Stocktype
                fn = "Stocktype"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
            Case FieldName.TransactionDate
                fn = "TransactionDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblStock] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblStock_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal StockId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblStock_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@StockId_", StockId_)

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
        Return StockId_
    End Function



    Function Selection_One_Row( _
     ByVal StockId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblStock_select & "  AND [StockId]=@StockId_"

        With comSelection.Parameters
            .AddWithValue("@StockId_", StockId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then : .StockId_ = dt.Rows(0).Item("StockId") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("TransactionId") Is DBNull.Value Then : .TransactionId_ = dt.Rows(0).Item("TransactionId") : End If
                If Not dt.Rows(0).Item("TransactionType") Is DBNull.Value Then : .TransactionType_ = dt.Rows(0).Item("TransactionType") : End If
                If Not dt.Rows(0).Item("Stocktype") Is DBNull.Value Then : .Stocktype_ = dt.Rows(0).Item("Stocktype") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Fresh") Is DBNull.Value Then : .Fresh_ = dt.Rows(0).Item("Fresh") : End If
                If Not dt.Rows(0).Item("Frozen") Is DBNull.Value Then : .Frozen_ = dt.Rows(0).Item("Frozen") : End If
                If Not dt.Rows(0).Item("TransactionDate") Is DBNull.Value Then : .TransactionDate_ = dt.Rows(0).Item("TransactionDate") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblStock_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then : .StockId_ = dt.Rows(0).Item("StockId") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("TransactionId") Is DBNull.Value Then : .TransactionId_ = dt.Rows(0).Item("TransactionId") : End If
                If Not dt.Rows(0).Item("TransactionType") Is DBNull.Value Then : .TransactionType_ = dt.Rows(0).Item("TransactionType") : End If
                If Not dt.Rows(0).Item("Stocktype") Is DBNull.Value Then : .Stocktype_ = dt.Rows(0).Item("Stocktype") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Fresh") Is DBNull.Value Then : .Fresh_ = dt.Rows(0).Item("Fresh") : End If
                If Not dt.Rows(0).Item("Frozen") Is DBNull.Value Then : .Frozen_ = dt.Rows(0).Item("Frozen") : End If
                If Not dt.Rows(0).Item("TransactionDate") Is DBNull.Value Then : .TransactionDate_ = dt.Rows(0).Item("TransactionDate") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.TransactionId
                fn = "TransactionId"
            Case FieldName.TransactionType
                fn = "TransactionType"
            Case FieldName.Stocktype
                fn = "Stocktype"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
            Case FieldName.TransactionDate
                fn = "TransactionDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.TransactionId
                fn = "TransactionId"
            Case FieldName.TransactionType
                fn = "TransactionType"
            Case FieldName.Stocktype
                fn = "Stocktype"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
            Case FieldName.TransactionDate
                fn = "TransactionDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblTarget
    Public Shared tablename As String = "tblTarget"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim ProductId_ As Int32
        Dim TargetQty_ As Int64
        Dim FrozenQty_ As Int64
        Dim FreshQty_ As Int64
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim Remarks_ As String
        Dim Status_ As String

    End Structure


    Enum FieldName


        [ItemSl]
        [ProductId]
        [TargetQty]
        [FrozenQty]
        [FreshQty]
        [CreatedDate]
        [CreatedBy]
        [Remarks]
        [Status]

    End Enum


    Public ReadOnly Property tblTarget_insert
        Get
            Return <tblTarget_insert><![CDATA[
  INSERT INTO [tblTarget]
  (
      [ItemSl],
      [ProductId],
      [TargetQty],
      [FrozenQty],
      [FreshQty],
      [CreatedDate],
      [CreatedBy],
      [Remarks],
      [Status]
  )
  VALUES
  (
      @ItemSl_,
      @ProductId_,
      @TargetQty_,
      @FrozenQty_,
      @FreshQty_,
      @CreatedDate_,
      @CreatedBy_,
      @Remarks_,
      @Status_
  )
]]></tblTarget_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblTarget_update
        Get
            Return <tblTarget_update><![CDATA[
UPDATE [tblTarget]
Set 
    [ProductId]=@ProductId_,
    [TargetQty]=@TargetQty_,
    [FrozenQty]=@FrozenQty_,
    [FreshQty]=@FreshQty_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [Remarks]=@Remarks_,
    [Status]=@Status_
 WHERE [ItemSl]=@ItemSl_
]]></tblTarget_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblTarget_select
        Get
            Return <tblTarget_select><![CDATA[
SELECT 
      [ItemSl],
      [ProductId],
      [TargetQty],
      [FrozenQty],
      [FreshQty],
      [CreatedDate],
      [CreatedBy],
      [Remarks],
      [Status]
FROM [tblTarget]
    WHERE 1=1
]]></tblTarget_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblTarget_Delete_By_RowID
        Get
            Return <tblTarget_Delete_By_RowID><![CDATA[
DELETE FROM [tblTarget] WHERE [ItemSl]=@ItemSl_
]]></tblTarget_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblTarget_Delete_By_SELECT
        Get
            Return <tblTarget_Delete_By_SELECT><![CDATA[
DELETE FROM [tblTarget] WHERE 1=1
]]></tblTarget_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblTarget_MAXID
        Get
            Return <tblTarget_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblTarget] WHERE 1=1
]]></tblTarget_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblTarget_MAXID, _conn)
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
    ByVal ProductId_ As Int32, _
    ByVal TargetQty_ As Int64, _
    ByVal FrozenQty_ As Int64, _
    ByVal FreshQty_ As Int64, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Status_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblTarget_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@TargetQty_", TargetQty_)
            .AddWithValue("@FrozenQty_", FrozenQty_)
            .AddWithValue("@FreshQty_", FreshQty_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Status_", Status_)

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
        Return ItemSl_
    End Function



    Function Update(
    ByVal ProductId_ As Int32, _
    ByVal TargetQty_ As Int64, _
    ByVal FrozenQty_ As Int64, _
    ByVal FreshQty_ As Int64, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Status_ As String, _
    ByVal ItemSl_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblTarget_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@TargetQty_", TargetQty_)
            .AddWithValue("@FrozenQty_", FrozenQty_)
            .AddWithValue("@FreshQty_", FreshQty_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@ItemSl_", ItemSl_)

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

        Return ItemSl_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.TargetQty
                fn = "TargetQty"
            Case FieldName.FrozenQty
                fn = "FrozenQty"
            Case FieldName.FreshQty
                fn = "FreshQty"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblTarget] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblTarget_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblTarget_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

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
        Return ItemSl_
    End Function



    Function Selection_One_Row( _
     ByVal ItemSl_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTarget_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("TargetQty") Is DBNull.Value Then : .TargetQty_ = dt.Rows(0).Item("TargetQty") : End If
                If Not dt.Rows(0).Item("FrozenQty") Is DBNull.Value Then : .FrozenQty_ = dt.Rows(0).Item("FrozenQty") : End If
                If Not dt.Rows(0).Item("FreshQty") Is DBNull.Value Then : .FreshQty_ = dt.Rows(0).Item("FreshQty") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTarget_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("TargetQty") Is DBNull.Value Then : .TargetQty_ = dt.Rows(0).Item("TargetQty") : End If
                If Not dt.Rows(0).Item("FrozenQty") Is DBNull.Value Then : .FrozenQty_ = dt.Rows(0).Item("FrozenQty") : End If
                If Not dt.Rows(0).Item("FreshQty") Is DBNull.Value Then : .FreshQty_ = dt.Rows(0).Item("FreshQty") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.TargetQty
                fn = "TargetQty"
            Case FieldName.FrozenQty
                fn = "FrozenQty"
            Case FieldName.FreshQty
                fn = "FreshQty"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblTarget] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.TargetQty
                fn = "TargetQty"
            Case FieldName.FrozenQty
                fn = "FrozenQty"
            Case FieldName.FreshQty
                fn = "FreshQty"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblTarget] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblOrderSchedule
    Public Shared tablename As String = "tblOrderSchedule"


    Structure Fields


        Dim OrderId_ As Int32
        Dim OrderNo_ As String
        Dim OrderSl_ As Int32
        Dim OrderDate_ As DateTime
        Dim DeliveryDate_ As DateTime
        Dim CutomerId_ As Int32
        Dim TotalItems_ As Int32
        Dim OrderAmount_ As Decimal
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim Status_ As String
        Dim StatusDate_ As DateTime
        Dim StatusBy_ As Int32
        Dim Remarks_ As String
        Dim Comments_ As String
        Dim Session_ As String
        Dim BranchId_ As Int32
        Dim BOLAddressID_ As Int32
        Dim ScheduleType_ As String
        Dim StartDate_ As DateTime
        Dim ScheduleInfo_ As String
        Dim Repeat_ As Int32
        Dim EndDate_ As DateTime

    End Structure


    Enum FieldName


        [OrderId]
        [OrderNo]
        [OrderSl]
        [OrderDate]
        [DeliveryDate]
        [CutomerId]
        [TotalItems]
        [OrderAmount]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [Status]
        [StatusDate]
        [StatusBy]
        [Remarks]
        [Comments]
        [Session]
        [BranchId]
        [BOLAddressID]
        [ScheduleType]
        [StartDate]
        [ScheduleInfo]
        [Repeat]
        [EndDate]

    End Enum


    Public ReadOnly Property tblOrderSchedule_insert
        Get
            Return <tblOrderSchedule_insert><![CDATA[
  INSERT INTO [tblOrderSchedule]
  (
      [OrderId],
      [OrderNo],
      [OrderSl],
      [OrderDate],
      [DeliveryDate],
      [CutomerId],
      [TotalItems],
      [OrderAmount],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Status],
      [StatusDate],
      [StatusBy],
      [Remarks],
      [Comments],
      [Session],
      [BranchId],
      [BOLAddressID],
      [ScheduleType],
      [StartDate],
      [ScheduleInfo],
      [Repeat],
      [EndDate]
  )
  VALUES
  (
      @OrderId_,
      @OrderNo_,
      @OrderSl_,
      @OrderDate_,
      @DeliveryDate_,
      @CutomerId_,
      @TotalItems_,
      @OrderAmount_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @Status_,
      @StatusDate_,
      @StatusBy_,
      @Remarks_,
      @Comments_,
      @Session_,
      @BranchId_,
      @BOLAddressID_,
      @ScheduleType_,
      @StartDate_,
      @ScheduleInfo_,
      @Repeat_,
      @EndDate_
  )
]]></tblOrderSchedule_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderSchedule_update
        Get
            Return <tblOrderSchedule_update><![CDATA[
UPDATE [tblOrderSchedule]
Set 
    [OrderNo]=@OrderNo_,
    [OrderSl]=@OrderSl_,
    [OrderDate]=@OrderDate_,
    [DeliveryDate]=@DeliveryDate_,
    [CutomerId]=@CutomerId_,
    [TotalItems]=@TotalItems_,
    [OrderAmount]=@OrderAmount_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [Status]=@Status_,
    [StatusDate]=@StatusDate_,
    [StatusBy]=@StatusBy_,
    [Remarks]=@Remarks_,
    [Comments]=@Comments_,
    [Session]=@Session_,
    [BranchId]=@BranchId_,
    [BOLAddressID]=@BOLAddressID_,
    [ScheduleType]=@ScheduleType_,
    [StartDate]=@StartDate_,
    [ScheduleInfo]=@ScheduleInfo_,
    [Repeat]=@Repeat_,
    [EndDate]=@EndDate_
 WHERE [OrderId]=@OrderId_
]]></tblOrderSchedule_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblOrderSchedule_select
        Get
            Return <tblOrderSchedule_select><![CDATA[
SELECT 
      [OrderId],
      [OrderNo],
      [OrderSl],
      [OrderDate],
      [DeliveryDate],
      [CutomerId],
      [TotalItems],
      [OrderAmount],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Status],
      [StatusDate],
      [StatusBy],
      [Remarks],
      [Comments],
      [Session],
      [BranchId],
      [BOLAddressID],
      [ScheduleType],
      [StartDate],
      [ScheduleInfo],
      [Repeat],
      [EndDate]
FROM [tblOrderSchedule]
    WHERE 1=1
]]></tblOrderSchedule_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderSchedule_Delete_By_RowID
        Get
            Return <tblOrderSchedule_Delete_By_RowID><![CDATA[
DELETE FROM [tblOrderSchedule] WHERE [OrderId]=@OrderId_
]]></tblOrderSchedule_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderSchedule_Delete_By_SELECT
        Get
            Return <tblOrderSchedule_Delete_By_SELECT><![CDATA[
DELETE FROM [tblOrderSchedule] WHERE 1=1
]]></tblOrderSchedule_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderSchedule_MAXID
        Get
            Return <tblOrderSchedule_MAXID><![CDATA[
SELECT MAX([OrderId]) FROM [tblOrderSchedule] WHERE 1=1
]]></tblOrderSchedule_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblOrderSchedule_MAXID, _conn)
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
    ByVal OrderNo_ As String, _
    ByVal OrderSl_ As Int32, _
    ByVal OrderDate_ As DateTime, _
    ByVal DeliveryDate_ As DateTime, _
    ByVal CutomerId_ As Int32, _
    ByVal TotalItems_ As Int32, _
    ByVal OrderAmount_ As Decimal, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Status_ As String, _
    ByVal StatusDate_ As DateTime, _
    ByVal StatusBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Comments_ As String, _
    ByVal Session_ As String, _
    ByVal BranchId_ As Int32, _
    ByVal BOLAddressID_ As Int32, _
    ByVal ScheduleType_ As String, _
    ByVal StartDate_ As DateTime, _
    ByVal ScheduleInfo_ As String, _
    ByVal Repeat_ As Int32, _
    ByVal EndDate_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim OrderId_ As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@OrderNo_", OrderNo_)
            .AddWithValue("@OrderSl_", OrderSl_)
            .AddWithValue("@OrderDate_", OrderDate_)
            .AddWithValue("@DeliveryDate_", DeliveryDate_)
            .AddWithValue("@CutomerId_", CutomerId_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@OrderAmount_", OrderAmount_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@StatusDate_", StatusDate_)
            .AddWithValue("@StatusBy_", StatusBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@BranchId_", BranchId_)
            .AddWithValue("@BOLAddressID_", BOLAddressID_)
            .AddWithValue("@ScheduleType_", ScheduleType_)
            .AddWithValue("@StartDate_", StartDate_)
            .AddWithValue("@ScheduleInfo_", ScheduleInfo_)
            .AddWithValue("@Repeat_", Repeat_)
            .AddWithValue("@EndDate_", EndDate_)

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
        Return OrderId_
    End Function



    Function Update(
    ByVal OrderNo_ As String, _
    ByVal OrderSl_ As Int32, _
    ByVal OrderDate_ As DateTime, _
    ByVal DeliveryDate_ As DateTime, _
    ByVal CutomerId_ As Int32, _
    ByVal TotalItems_ As Int32, _
    ByVal OrderAmount_ As Decimal, _
    ByVal CreatedDate_ As DateTime, _
    ByVal CreatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdatedBy_ As Int32, _
    ByVal Status_ As String, _
    ByVal StatusDate_ As DateTime, _
    ByVal StatusBy_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Comments_ As String, _
    ByVal Session_ As String, _
    ByVal BranchId_ As Int32, _
    ByVal BOLAddressID_ As Int32, _
    ByVal ScheduleType_ As String, _
    ByVal StartDate_ As DateTime, _
    ByVal ScheduleInfo_ As String, _
    ByVal Repeat_ As Int32, _
    ByVal EndDate_ As DateTime, _
    ByVal OrderId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

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
            .AddWithValue("@OrderNo_", OrderNo_)
            .AddWithValue("@OrderSl_", OrderSl_)
            .AddWithValue("@OrderDate_", OrderDate_)
            .AddWithValue("@DeliveryDate_", DeliveryDate_)
            .AddWithValue("@CutomerId_", CutomerId_)
            .AddWithValue("@TotalItems_", TotalItems_)
            .AddWithValue("@OrderAmount_", OrderAmount_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@StatusDate_", StatusDate_)
            .AddWithValue("@StatusBy_", StatusBy_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Comments_", Comments_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@BranchId_", BranchId_)
            .AddWithValue("@BOLAddressID_", BOLAddressID_)
            .AddWithValue("@ScheduleType_", ScheduleType_)
            .AddWithValue("@StartDate_", StartDate_)
            .AddWithValue("@ScheduleInfo_", ScheduleInfo_)
            .AddWithValue("@Repeat_", Repeat_)
            .AddWithValue("@EndDate_", EndDate_)
            .AddWithValue("@OrderId_", OrderId_)

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

        Return OrderId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.OrderNo
                fn = "OrderNo"
            Case FieldName.OrderSl
                fn = "OrderSl"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.DeliveryDate
                fn = "DeliveryDate"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.OrderAmount
                fn = "OrderAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.StatusBy
                fn = "StatusBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.BranchId
                fn = "BranchId"
            Case FieldName.BOLAddressID
                fn = "BOLAddressID"
            Case FieldName.ScheduleType
                fn = "ScheduleType"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.ScheduleInfo
                fn = "ScheduleInfo"
            Case FieldName.Repeat
                fn = "Repeat"
            Case FieldName.EndDate
                fn = "EndDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblOrderSchedule] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblOrderSchedule_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal OrderId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrderSchedule_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@OrderId_", OrderId_)

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
        Return OrderId_
    End Function



    Function Selection_One_Row( _
     ByVal OrderId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderSchedule_select & "  AND [OrderId]=@OrderId_"

        With comSelection.Parameters
            .AddWithValue("@OrderId_", OrderId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("OrderNo") Is DBNull.Value Then : .OrderNo_ = dt.Rows(0).Item("OrderNo") : End If
                If Not dt.Rows(0).Item("OrderSl") Is DBNull.Value Then : .OrderSl_ = dt.Rows(0).Item("OrderSl") : End If
                If Not dt.Rows(0).Item("OrderDate") Is DBNull.Value Then : .OrderDate_ = dt.Rows(0).Item("OrderDate") : End If
                If Not dt.Rows(0).Item("DeliveryDate") Is DBNull.Value Then : .DeliveryDate_ = dt.Rows(0).Item("DeliveryDate") : End If
                If Not dt.Rows(0).Item("CutomerId") Is DBNull.Value Then : .CutomerId_ = dt.Rows(0).Item("CutomerId") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("OrderAmount") Is DBNull.Value Then : .OrderAmount_ = dt.Rows(0).Item("OrderAmount") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("StatusDate") Is DBNull.Value Then : .StatusDate_ = dt.Rows(0).Item("StatusDate") : End If
                If Not dt.Rows(0).Item("StatusBy") Is DBNull.Value Then : .StatusBy_ = dt.Rows(0).Item("StatusBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("BranchId") Is DBNull.Value Then : .BranchId_ = dt.Rows(0).Item("BranchId") : End If
                If Not dt.Rows(0).Item("BOLAddressID") Is DBNull.Value Then : .BOLAddressID_ = dt.Rows(0).Item("BOLAddressID") : End If
                If Not dt.Rows(0).Item("ScheduleType") Is DBNull.Value Then : .ScheduleType_ = dt.Rows(0).Item("ScheduleType") : End If
                If Not dt.Rows(0).Item("StartDate") Is DBNull.Value Then : .StartDate_ = dt.Rows(0).Item("StartDate") : End If
                If Not dt.Rows(0).Item("ScheduleInfo") Is DBNull.Value Then : .ScheduleInfo_ = dt.Rows(0).Item("ScheduleInfo") : End If
                If Not dt.Rows(0).Item("Repeat") Is DBNull.Value Then : .Repeat_ = dt.Rows(0).Item("Repeat") : End If
                If Not dt.Rows(0).Item("EndDate") Is DBNull.Value Then : .EndDate_ = dt.Rows(0).Item("EndDate") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderSchedule_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("OrderNo") Is DBNull.Value Then : .OrderNo_ = dt.Rows(0).Item("OrderNo") : End If
                If Not dt.Rows(0).Item("OrderSl") Is DBNull.Value Then : .OrderSl_ = dt.Rows(0).Item("OrderSl") : End If
                If Not dt.Rows(0).Item("OrderDate") Is DBNull.Value Then : .OrderDate_ = dt.Rows(0).Item("OrderDate") : End If
                If Not dt.Rows(0).Item("DeliveryDate") Is DBNull.Value Then : .DeliveryDate_ = dt.Rows(0).Item("DeliveryDate") : End If
                If Not dt.Rows(0).Item("CutomerId") Is DBNull.Value Then : .CutomerId_ = dt.Rows(0).Item("CutomerId") : End If
                If Not dt.Rows(0).Item("TotalItems") Is DBNull.Value Then : .TotalItems_ = dt.Rows(0).Item("TotalItems") : End If
                If Not dt.Rows(0).Item("OrderAmount") Is DBNull.Value Then : .OrderAmount_ = dt.Rows(0).Item("OrderAmount") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("StatusDate") Is DBNull.Value Then : .StatusDate_ = dt.Rows(0).Item("StatusDate") : End If
                If Not dt.Rows(0).Item("StatusBy") Is DBNull.Value Then : .StatusBy_ = dt.Rows(0).Item("StatusBy") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Comments") Is DBNull.Value Then : .Comments_ = dt.Rows(0).Item("Comments") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("BranchId") Is DBNull.Value Then : .BranchId_ = dt.Rows(0).Item("BranchId") : End If
                If Not dt.Rows(0).Item("BOLAddressID") Is DBNull.Value Then : .BOLAddressID_ = dt.Rows(0).Item("BOLAddressID") : End If
                If Not dt.Rows(0).Item("ScheduleType") Is DBNull.Value Then : .ScheduleType_ = dt.Rows(0).Item("ScheduleType") : End If
                If Not dt.Rows(0).Item("StartDate") Is DBNull.Value Then : .StartDate_ = dt.Rows(0).Item("StartDate") : End If
                If Not dt.Rows(0).Item("ScheduleInfo") Is DBNull.Value Then : .ScheduleInfo_ = dt.Rows(0).Item("ScheduleInfo") : End If
                If Not dt.Rows(0).Item("Repeat") Is DBNull.Value Then : .Repeat_ = dt.Rows(0).Item("Repeat") : End If
                If Not dt.Rows(0).Item("EndDate") Is DBNull.Value Then : .EndDate_ = dt.Rows(0).Item("EndDate") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.OrderNo
                fn = "OrderNo"
            Case FieldName.OrderSl
                fn = "OrderSl"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.DeliveryDate
                fn = "DeliveryDate"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.OrderAmount
                fn = "OrderAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.StatusBy
                fn = "StatusBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.BranchId
                fn = "BranchId"
            Case FieldName.BOLAddressID
                fn = "BOLAddressID"
            Case FieldName.ScheduleType
                fn = "ScheduleType"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.ScheduleInfo
                fn = "ScheduleInfo"
            Case FieldName.Repeat
                fn = "Repeat"
            Case FieldName.EndDate
                fn = "EndDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblOrderSchedule] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.OrderNo
                fn = "OrderNo"
            Case FieldName.OrderSl
                fn = "OrderSl"
            Case FieldName.OrderDate
                fn = "OrderDate"
            Case FieldName.DeliveryDate
                fn = "DeliveryDate"
            Case FieldName.CutomerId
                fn = "CutomerId"
            Case FieldName.TotalItems
                fn = "TotalItems"
            Case FieldName.OrderAmount
                fn = "OrderAmount"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.StatusDate
                fn = "StatusDate"
            Case FieldName.StatusBy
                fn = "StatusBy"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Comments
                fn = "Comments"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.BranchId
                fn = "BranchId"
            Case FieldName.BOLAddressID
                fn = "BOLAddressID"
            Case FieldName.ScheduleType
                fn = "ScheduleType"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.ScheduleInfo
                fn = "ScheduleInfo"
            Case FieldName.Repeat
                fn = "Repeat"
            Case FieldName.EndDate
                fn = "EndDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblOrderSchedule] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblOrderScheduleItems
    Public Shared tablename As String = "tblOrderScheduleItems"


    Structure Fields


        Dim ItemId_ As Int32
        Dim OrderId_ As Int32
        Dim Sl_ As Int32
        Dim ProductId_ As Int32
        Dim Qty_ As Int32
        Dim Price_ As Decimal
        Dim Discount_ As Decimal
        Dim Extra_ As Decimal
        Dim Weight_ As String
        Dim SubTotal_ As Decimal
        Dim Notes_ As String
        Dim Fresh_ As Int32
        Dim Frozen_ As Int32

    End Structure


    Enum FieldName


        [ItemId]
        [OrderId]
        [Sl]
        [ProductId]
        [Qty]
        [Price]
        [Discount]
        [Extra]
        [Weight]
        [SubTotal]
        [Notes]
        [Fresh]
        [Frozen]

    End Enum


    Public ReadOnly Property tblOrderScheduleItems_insert
        Get
            Return <tblOrderScheduleItems_insert><![CDATA[
  INSERT INTO [tblOrderScheduleItems]
  (
      [ItemId],
      [OrderId],
      [Sl],
      [ProductId],
      [Qty],
      [Price],
      [Discount],
      [Extra],
      [Weight],
      [SubTotal],
      [Notes],
      [Fresh],
      [Frozen]
  )
  VALUES
  (
      @ItemId_,
      @OrderId_,
      @Sl_,
      @ProductId_,
      @Qty_,
      @Price_,
      @Discount_,
      @Extra_,
      @Weight_,
      @SubTotal_,
      @Notes_,
      @Fresh_,
      @Frozen_
  )
]]></tblOrderScheduleItems_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderScheduleItems_update
        Get
            Return <tblOrderScheduleItems_update><![CDATA[
UPDATE [tblOrderScheduleItems]
Set 
    [OrderId]=@OrderId_,
    [Sl]=@Sl_,
    [ProductId]=@ProductId_,
    [Qty]=@Qty_,
    [Price]=@Price_,
    [Discount]=@Discount_,
    [Extra]=@Extra_,
    [Weight]=@Weight_,
    [SubTotal]=@SubTotal_,
    [Notes]=@Notes_,
    [Fresh]=@Fresh_,
    [Frozen]=@Frozen_
 WHERE [ItemId]=@ItemId_
]]></tblOrderScheduleItems_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblOrderScheduleItems_select
        Get
            Return <tblOrderScheduleItems_select><![CDATA[
SELECT 
      [ItemId],
      [OrderId],
      [Sl],
      [ProductId],
      [Qty],
      [Price],
      [Discount],
      [Extra],
      [Weight],
      [SubTotal],
      [Notes],
      [Fresh],
      [Frozen]
FROM [tblOrderScheduleItems]
    WHERE 1=1
]]></tblOrderScheduleItems_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderScheduleItems_Delete_By_RowID
        Get
            Return <tblOrderScheduleItems_Delete_By_RowID><![CDATA[
DELETE FROM [tblOrderScheduleItems] WHERE [ItemId]=@ItemId_
]]></tblOrderScheduleItems_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderScheduleItems_Delete_By_SELECT
        Get
            Return <tblOrderScheduleItems_Delete_By_SELECT><![CDATA[
DELETE FROM [tblOrderScheduleItems] WHERE 1=1
]]></tblOrderScheduleItems_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblOrderScheduleItems_MAXID
        Get
            Return <tblOrderScheduleItems_MAXID><![CDATA[
SELECT MAX([ItemId]) FROM [tblOrderScheduleItems] WHERE 1=1
]]></tblOrderScheduleItems_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblOrderScheduleItems_MAXID, _conn)
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
    ByVal OrderId_ As Int32, _
    ByVal Sl_ As Int32, _
    ByVal ProductId_ As Int32, _
    ByVal Qty_ As Int32, _
    ByVal Price_ As Decimal, _
    ByVal Discount_ As Decimal, _
    ByVal Extra_ As Decimal, _
    ByVal Weight_ As String, _
    ByVal SubTotal_ As Decimal, _
    ByVal Notes_ As String, _
    ByVal Fresh_ As Int32, _
    ByVal Frozen_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblOrderScheduleItems_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemId_", ItemId_)
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Discount_", Discount_)
            .AddWithValue("@Extra_", Extra_)
            .AddWithValue("@Weight_", Weight_)
            .AddWithValue("@SubTotal_", SubTotal_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Fresh_", Fresh_)
            .AddWithValue("@Frozen_", Frozen_)

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
        Return ItemId_
    End Function



    Function Update(
    ByVal OrderId_ As Int32, _
    ByVal Sl_ As Int32, _
    ByVal ProductId_ As Int32, _
    ByVal Qty_ As Int32, _
    ByVal Price_ As Decimal, _
    ByVal Discount_ As Decimal, _
    ByVal Extra_ As Decimal, _
    ByVal Weight_ As String, _
    ByVal SubTotal_ As Decimal, _
    ByVal Notes_ As String, _
    ByVal Fresh_ As Int32, _
    ByVal Frozen_ As Int32, _
    ByVal ItemId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblOrderScheduleItems_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@OrderId_", OrderId_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Discount_", Discount_)
            .AddWithValue("@Extra_", Extra_)
            .AddWithValue("@Weight_", Weight_)
            .AddWithValue("@SubTotal_", SubTotal_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@Fresh_", Fresh_)
            .AddWithValue("@Frozen_", Frozen_)
            .AddWithValue("@ItemId_", ItemId_)

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

        Return ItemId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Extra
                fn = "Extra"
            Case FieldName.Weight
                fn = "Weight"
            Case FieldName.SubTotal
                fn = "SubTotal"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblOrderScheduleItems] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblOrderScheduleItems_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblOrderScheduleItems_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId_", ItemId_)

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
        Return ItemId_
    End Function



    Function Selection_One_Row( _
     ByVal ItemId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderScheduleItems_select & "  AND [ItemId]=@ItemId_"

        With comSelection.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Discount") Is DBNull.Value Then : .Discount_ = dt.Rows(0).Item("Discount") : End If
                If Not dt.Rows(0).Item("Extra") Is DBNull.Value Then : .Extra_ = dt.Rows(0).Item("Extra") : End If
                If Not dt.Rows(0).Item("Weight") Is DBNull.Value Then : .Weight_ = dt.Rows(0).Item("Weight") : End If
                If Not dt.Rows(0).Item("SubTotal") Is DBNull.Value Then : .SubTotal_ = dt.Rows(0).Item("SubTotal") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Fresh") Is DBNull.Value Then : .Fresh_ = dt.Rows(0).Item("Fresh") : End If
                If Not dt.Rows(0).Item("Frozen") Is DBNull.Value Then : .Frozen_ = dt.Rows(0).Item("Frozen") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblOrderScheduleItems_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("OrderId") Is DBNull.Value Then : .OrderId_ = dt.Rows(0).Item("OrderId") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Discount") Is DBNull.Value Then : .Discount_ = dt.Rows(0).Item("Discount") : End If
                If Not dt.Rows(0).Item("Extra") Is DBNull.Value Then : .Extra_ = dt.Rows(0).Item("Extra") : End If
                If Not dt.Rows(0).Item("Weight") Is DBNull.Value Then : .Weight_ = dt.Rows(0).Item("Weight") : End If
                If Not dt.Rows(0).Item("SubTotal") Is DBNull.Value Then : .SubTotal_ = dt.Rows(0).Item("SubTotal") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
                If Not dt.Rows(0).Item("Fresh") Is DBNull.Value Then : .Fresh_ = dt.Rows(0).Item("Fresh") : End If
                If Not dt.Rows(0).Item("Frozen") Is DBNull.Value Then : .Frozen_ = dt.Rows(0).Item("Frozen") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Extra
                fn = "Extra"
            Case FieldName.Weight
                fn = "Weight"
            Case FieldName.SubTotal
                fn = "SubTotal"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblOrderScheduleItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.OrderId
                fn = "OrderId"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Extra
                fn = "Extra"
            Case FieldName.Weight
                fn = "Weight"
            Case FieldName.SubTotal
                fn = "SubTotal"
            Case FieldName.Notes
                fn = "Notes"
            Case FieldName.Fresh
                fn = "Fresh"
            Case FieldName.Frozen
                fn = "Frozen"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblOrderScheduleItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblInvoiceStatus
    Public Shared tablename As String = "tblInvoiceStatus"


    Structure Fields


        Dim InvoiceNumber_ As String
        Dim CustomerID_ As String
        Dim Status_ As String

    End Structure


    Enum FieldName


        [InvoiceNumber]
        [CustomerID]
        [Status]

    End Enum


    Public ReadOnly Property tblInvoiceStatus_insert
        Get
            Return <tblInvoiceStatus_insert><![CDATA[
  INSERT INTO [tblInvoiceStatus]
  (
      [InvoiceNumber],
      [CustomerID],
      [Status]
  )
  VALUES
  (
      @InvoiceNumber_,
      @CustomerID_,
      @Status_
  )
]]></tblInvoiceStatus_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblInvoiceStatus_update
        Get
            Return <tblInvoiceStatus_update><![CDATA[
UPDATE [tblInvoiceStatus]
Set 
    [CustomerID]=@CustomerID_,
    [Status]=@Status_
 WHERE [InvoiceNumber]=@InvoiceNumber_
]]></tblInvoiceStatus_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblInvoiceStatus_select
        Get
            Return <tblInvoiceStatus_select><![CDATA[
SELECT 
      [InvoiceNumber],
      [CustomerID],
      [Status]
FROM [tblInvoiceStatus]
    WHERE 1=1
]]></tblInvoiceStatus_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblInvoiceStatus_Delete_By_RowID
        Get
            Return <tblInvoiceStatus_Delete_By_RowID><![CDATA[
DELETE FROM [tblInvoiceStatus] WHERE [InvoiceNumber]=@InvoiceNumber_
]]></tblInvoiceStatus_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblInvoiceStatus_Delete_By_SELECT
        Get
            Return <tblInvoiceStatus_Delete_By_SELECT><![CDATA[
DELETE FROM [tblInvoiceStatus] WHERE 1=1
]]></tblInvoiceStatus_Delete_By_SELECT>.Value
        End Get
    End Property


    Function Insert( _
    ByVal InvoiceNumber_ As String, _
    ByVal CustomerID_ As String, _
    ByVal Status_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing


        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblInvoiceStatus_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)
            .AddWithValue("@CustomerID_", CustomerID_)
            .AddWithValue("@Status_", Status_)

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
        Return 0
    End Function



    Function Update(
    ByVal CustomerID_ As String, _
    ByVal Status_ As String, _
    ByVal InvoiceNumber_ As String, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblInvoiceStatus_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@CustomerID_", CustomerID_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)

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

        Return 0
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InvoiceNumber
                fn = "InvoiceNumber"
            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblInvoiceStatus] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblInvoiceStatus_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal InvoiceNumber_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblInvoiceStatus_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)

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
        Return 0
    End Function



    Function Selection_One_Row( _
     ByVal InvoiceNumber_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblInvoiceStatus_select & "  AND [InvoiceNumber]=@InvoiceNumber_"

        With comSelection.Parameters
            .AddWithValue("@InvoiceNumber_", InvoiceNumber_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("InvoiceNumber") Is DBNull.Value Then : .InvoiceNumber_ = dt.Rows(0).Item("InvoiceNumber") : End If
                If Not dt.Rows(0).Item("CustomerID") Is DBNull.Value Then : .CustomerID_ = dt.Rows(0).Item("CustomerID") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblInvoiceStatus_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("InvoiceNumber") Is DBNull.Value Then : .InvoiceNumber_ = dt.Rows(0).Item("InvoiceNumber") : End If
                If Not dt.Rows(0).Item("CustomerID") Is DBNull.Value Then : .CustomerID_ = dt.Rows(0).Item("CustomerID") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InvoiceNumber
                fn = "InvoiceNumber"
            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblInvoiceStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InvoiceNumber
                fn = "InvoiceNumber"
            Case FieldName.CustomerID
                fn = "CustomerID"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblInvoiceStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblNotes
    Public Shared tablename As String = "tblNotes"


    Structure Fields


        Dim NoteId_ As Int32
        Dim NoteDate_ As DateTime
        Dim Notes_ As String

    End Structure


    Enum FieldName


        [NoteId]
        [NoteDate]
        [Notes]

    End Enum


    Public ReadOnly Property tblNotes_insert
        Get
            Return <tblNotes_insert><![CDATA[
  INSERT INTO [tblNotes]
  (
      [NoteId],
      [NoteDate],
      [Notes]
  )
  VALUES
  (
      @NoteId_,
      @NoteDate_,
      @Notes_
  )
]]></tblNotes_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblNotes_update
        Get
            Return <tblNotes_update><![CDATA[
UPDATE [tblNotes]
Set 
    [NoteDate]=@NoteDate_,
    [Notes]=@Notes_
 WHERE [NoteId]=@NoteId_
]]></tblNotes_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblNotes_select
        Get
            Return <tblNotes_select><![CDATA[
SELECT 
      [NoteId],
      [NoteDate],
      [Notes]
FROM [tblNotes]
    WHERE 1=1
]]></tblNotes_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblNotes_Delete_By_RowID
        Get
            Return <tblNotes_Delete_By_RowID><![CDATA[
DELETE FROM [tblNotes] WHERE [NoteId]=@NoteId_
]]></tblNotes_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblNotes_Delete_By_SELECT
        Get
            Return <tblNotes_Delete_By_SELECT><![CDATA[
DELETE FROM [tblNotes] WHERE 1=1
]]></tblNotes_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblNotes_MAXID
        Get
            Return <tblNotes_MAXID><![CDATA[
SELECT MAX([NoteId]) FROM [tblNotes] WHERE 1=1
]]></tblNotes_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblNotes_MAXID, _conn)
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
    ByVal NoteDate_ As DateTime, _
    ByVal Notes_ As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim NoteId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblNotes_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@NoteId_", NoteId_)
            .AddWithValue("@NoteDate_", NoteDate_)
            .AddWithValue("@Notes_", Notes_)

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
        Return NoteId_
    End Function



    Function Update(
    ByVal NoteDate_ As DateTime, _
    ByVal Notes_ As String, _
    ByVal NoteId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblNotes_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@NoteDate_", NoteDate_)
            .AddWithValue("@Notes_", Notes_)
            .AddWithValue("@NoteId_", NoteId_)

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

        Return NoteId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.NoteId
                fn = "NoteId"
            Case FieldName.NoteDate
                fn = "NoteDate"
            Case FieldName.Notes
                fn = "Notes"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblNotes] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblNotes_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal NoteId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblNotes_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@NoteId_", NoteId_)

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
        Return NoteId_
    End Function



    Function Selection_One_Row( _
     ByVal NoteId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblNotes_select & "  AND [NoteId]=@NoteId_"

        With comSelection.Parameters
            .AddWithValue("@NoteId_", NoteId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("NoteId") Is DBNull.Value Then : .NoteId_ = dt.Rows(0).Item("NoteId") : End If
                If Not dt.Rows(0).Item("NoteDate") Is DBNull.Value Then : .NoteDate_ = dt.Rows(0).Item("NoteDate") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblNotes_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("NoteId") Is DBNull.Value Then : .NoteId_ = dt.Rows(0).Item("NoteId") : End If
                If Not dt.Rows(0).Item("NoteDate") Is DBNull.Value Then : .NoteDate_ = dt.Rows(0).Item("NoteDate") : End If
                If Not dt.Rows(0).Item("Notes") Is DBNull.Value Then : .Notes_ = dt.Rows(0).Item("Notes") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.NoteId
                fn = "NoteId"
            Case FieldName.NoteDate
                fn = "NoteDate"
            Case FieldName.Notes
                fn = "Notes"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblNotes] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.NoteId
                fn = "NoteId"
            Case FieldName.NoteDate
                fn = "NoteDate"
            Case FieldName.Notes
                fn = "Notes"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblNotes] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblSubStock
    Public Shared tablename As String = "tblSubStock"


    Structure Fields


        Dim SubStockID_ As Int32
        Dim StockId_ As Int32
        Dim Category_ As String
        Dim ProductID_ As Int32
        Dim qty_ As Int32
        Dim UserID_ As Int32
        Dim CreatedDate_ As DateTime
        Dim UpdatedDate_ As DateTime
        Dim UpdateUser_ As Int32
        Dim Remarks_ As String
        Dim Status_ As String
        Dim SubCategoryID_ As Int32
        Dim Type_ As String
        Dim T_Date_ As DateTime

    End Structure


    Enum FieldName


        [SubStockID]
        [StockId]
        [Category]
        [ProductID]
        [qty]
        [UserID]
        [CreatedDate]
        [UpdatedDate]
        [UpdateUser]
        [Remarks]
        [Status]
        [SubCategoryID]
        [Type]
        [T_Date]

    End Enum


    Public ReadOnly Property tblSubStock_insert
        Get
            Return <tblSubStock_insert><![CDATA[
  INSERT INTO [tblSubStock]
  (
      [SubStockID],
      [StockId],
      [Category],
      [ProductID],
      [qty],
      [UserID],
      [CreatedDate],
      [UpdatedDate],
      [UpdateUser],
      [Remarks],
      [Status],
      [SubCategoryID],
      [Type],
      [T_Date]
  )
  VALUES
  (
      @SubStockID_,
      @StockId_,
      @Category_,
      @ProductID_,
      @qty_,
      @UserID_,
      @CreatedDate_,
      @UpdatedDate_,
      @UpdateUser_,
      @Remarks_,
      @Status_,
      @SubCategoryID_,
      @Type_,
      @T_Date_
  )
]]></tblSubStock_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblSubStock_update
        Get
            Return <tblSubStock_update><![CDATA[
UPDATE [tblSubStock]
Set 
    [StockId]=@StockId_,
    [Category]=@Category_,
    [ProductID]=@ProductID_,
    [qty]=@qty_,
    [UserID]=@UserID_,
    [CreatedDate]=@CreatedDate_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdateUser]=@UpdateUser_,
    [Remarks]=@Remarks_,
    [Status]=@Status_,
    [SubCategoryID]=@SubCategoryID_,
    [Type]=@Type_,
    [T_Date]=@T_Date_
 WHERE [SubStockID]=@SubStockID_
]]></tblSubStock_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblSubStock_select
        Get
            Return <tblSubStock_select><![CDATA[
SELECT 
      [SubStockID],
      [StockId],
      [Category],
      [ProductID],
      [qty],
      [UserID],
      [CreatedDate],
      [UpdatedDate],
      [UpdateUser],
      [Remarks],
      [Status],
      [SubCategoryID],
      [Type],
      [T_Date]
FROM [tblSubStock]
    WHERE 1=1
]]></tblSubStock_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblSubStock_Delete_By_RowID
        Get
            Return <tblSubStock_Delete_By_RowID><![CDATA[
DELETE FROM [tblSubStock] WHERE [SubStockID]=@SubStockID_
]]></tblSubStock_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblSubStock_Delete_By_SELECT
        Get
            Return <tblSubStock_Delete_By_SELECT><![CDATA[
DELETE FROM [tblSubStock] WHERE 1=1
]]></tblSubStock_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblSubStock_MAXID
        Get
            Return <tblSubStock_MAXID><![CDATA[
SELECT MAX([SubStockID]) FROM [tblSubStock] WHERE 1=1
]]></tblSubStock_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblSubStock_MAXID, _conn)
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
    ByVal StockId_ As Int32, _
    ByVal Category_ As String, _
    ByVal ProductID_ As Int32, _
    ByVal qty_ As Int32, _
    ByVal UserID_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdateUser_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Status_ As String, _
    ByVal SubCategoryID_ As Int32, _
    ByVal Type_ As String, _
    ByVal T_Date_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim SubStockID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblSubStock_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@SubStockID_", SubStockID_)
            .AddWithValue("@StockId_", StockId_)
            .AddWithValue("@Category_", Category_)
            .AddWithValue("@ProductID_", ProductID_)
            .AddWithValue("@qty_", qty_)
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdateUser_", UpdateUser_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@SubCategoryID_", SubCategoryID_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@T_Date_", T_Date_)

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
        Return SubStockID_
    End Function



    Function Update(
    ByVal StockId_ As Int32, _
    ByVal Category_ As String, _
    ByVal ProductID_ As Int32, _
    ByVal qty_ As Int32, _
    ByVal UserID_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal UpdateUser_ As Int32, _
    ByVal Remarks_ As String, _
    ByVal Status_ As String, _
    ByVal SubCategoryID_ As Int32, _
    ByVal Type_ As String, _
    ByVal T_Date_ As DateTime, _
    ByVal SubStockID_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblSubStock_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@StockId_", StockId_)
            .AddWithValue("@Category_", Category_)
            .AddWithValue("@ProductID_", ProductID_)
            .AddWithValue("@qty_", qty_)
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdateUser_", UpdateUser_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@SubCategoryID_", SubCategoryID_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@T_Date_", T_Date_)
            .AddWithValue("@SubStockID_", SubStockID_)

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

        Return SubStockID_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SubStockID
                fn = "SubStockID"
            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.qty
                fn = "qty"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdateUser
                fn = "UpdateUser"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.SubCategoryID
                fn = "SubCategoryID"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.T_Date
                fn = "T_Date"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblSubStock] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblSubStock_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal SubStockID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblSubStock_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@SubStockID_", SubStockID_)

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
        Return SubStockID_
    End Function



    Function Selection_One_Row( _
     ByVal SubStockID_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblSubStock_select & "  AND [SubStockID]=@SubStockID_"

        With comSelection.Parameters
            .AddWithValue("@SubStockID_", SubStockID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("SubStockID") Is DBNull.Value Then : .SubStockID_ = dt.Rows(0).Item("SubStockID") : End If
                If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then : .StockId_ = dt.Rows(0).Item("StockId") : End If
                If Not dt.Rows(0).Item("Category") Is DBNull.Value Then : .Category_ = dt.Rows(0).Item("Category") : End If
                If Not dt.Rows(0).Item("ProductID") Is DBNull.Value Then : .ProductID_ = dt.Rows(0).Item("ProductID") : End If
                If Not dt.Rows(0).Item("qty") Is DBNull.Value Then : .qty_ = dt.Rows(0).Item("qty") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdateUser") Is DBNull.Value Then : .UpdateUser_ = dt.Rows(0).Item("UpdateUser") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("SubCategoryID") Is DBNull.Value Then : .SubCategoryID_ = dt.Rows(0).Item("SubCategoryID") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("T_Date") Is DBNull.Value Then : .T_Date_ = dt.Rows(0).Item("T_Date") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblSubStock_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("SubStockID") Is DBNull.Value Then : .SubStockID_ = dt.Rows(0).Item("SubStockID") : End If
                If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then : .StockId_ = dt.Rows(0).Item("StockId") : End If
                If Not dt.Rows(0).Item("Category") Is DBNull.Value Then : .Category_ = dt.Rows(0).Item("Category") : End If
                If Not dt.Rows(0).Item("ProductID") Is DBNull.Value Then : .ProductID_ = dt.Rows(0).Item("ProductID") : End If
                If Not dt.Rows(0).Item("qty") Is DBNull.Value Then : .qty_ = dt.Rows(0).Item("qty") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdateUser") Is DBNull.Value Then : .UpdateUser_ = dt.Rows(0).Item("UpdateUser") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("SubCategoryID") Is DBNull.Value Then : .SubCategoryID_ = dt.Rows(0).Item("SubCategoryID") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("T_Date") Is DBNull.Value Then : .T_Date_ = dt.Rows(0).Item("T_Date") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SubStockID
                fn = "SubStockID"
            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.qty
                fn = "qty"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdateUser
                fn = "UpdateUser"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.SubCategoryID
                fn = "SubCategoryID"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.T_Date
                fn = "T_Date"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblSubStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SubStockID
                fn = "SubStockID"
            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.qty
                fn = "qty"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdateUser
                fn = "UpdateUser"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.SubCategoryID
                fn = "SubCategoryID"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.T_Date
                fn = "T_Date"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblSubStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblProductSub
    Public Shared tablename As String = "tblProductSub"


    Structure Fields


        Dim SubCatId_ As Int32
        Dim ProductId_ As Int32
        Dim SubCatName_ As String
        Dim CreatedBy_ As Int32
        Dim CreatedDate_ As DateTime

    End Structure


    Enum FieldName


        [SubCatId]
        [ProductId]
        [SubCatName]
        [CreatedBy]
        [CreatedDate]

    End Enum


    Public ReadOnly Property tblProductSub_insert
        Get
            Return <tblProductSub_insert><![CDATA[
  INSERT INTO [tblProductSub]
  (
      [SubCatId],
      [ProductId],
      [SubCatName],
      [CreatedBy],
      [CreatedDate]
  )
  VALUES
  (
      @SubCatId_,
      @ProductId_,
      @SubCatName_,
      @CreatedBy_,
      @CreatedDate_
  )
]]></tblProductSub_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductSub_update
        Get
            Return <tblProductSub_update><![CDATA[
UPDATE [tblProductSub]
Set 
    [ProductId]=@ProductId_,
    [SubCatName]=@SubCatName_,
    [CreatedBy]=@CreatedBy_,
    [CreatedDate]=@CreatedDate_
 WHERE [SubCatId]=@SubCatId_
]]></tblProductSub_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblProductSub_select
        Get
            Return <tblProductSub_select><![CDATA[
SELECT 
      [SubCatId],
      [ProductId],
      [SubCatName],
      [CreatedBy],
      [CreatedDate]
FROM [tblProductSub]
    WHERE 1=1
]]></tblProductSub_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductSub_Delete_By_RowID
        Get
            Return <tblProductSub_Delete_By_RowID><![CDATA[
DELETE FROM [tblProductSub] WHERE [SubCatId]=@SubCatId_
]]></tblProductSub_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductSub_Delete_By_SELECT
        Get
            Return <tblProductSub_Delete_By_SELECT><![CDATA[
DELETE FROM [tblProductSub] WHERE 1=1
]]></tblProductSub_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblProductSub_MAXID
        Get
            Return <tblProductSub_MAXID><![CDATA[
SELECT MAX([SubCatId]) FROM [tblProductSub] WHERE 1=1
]]></tblProductSub_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblProductSub_MAXID, _conn)
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
    ByVal ProductId_ As Int32, _
    ByVal SubCatName_ As String, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim SubCatId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblProductSub_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@SubCatId_", SubCatId_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@SubCatName_", SubCatName_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreatedDate_", CreatedDate_)

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
        Return SubCatId_
    End Function



    Function Update(
    ByVal ProductId_ As Int32, _
    ByVal SubCatName_ As String, _
    ByVal CreatedBy_ As Int32, _
    ByVal CreatedDate_ As DateTime, _
    ByVal SubCatId_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblProductSub_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@SubCatName_", SubCatName_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@SubCatId_", SubCatId_)

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

        Return SubCatId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SubCatId
                fn = "SubCatId"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.SubCatName
                fn = "SubCatName"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblProductSub] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblProductSub_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal SubCatId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblProductSub_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@SubCatId_", SubCatId_)

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
        Return SubCatId_
    End Function



    Function Selection_One_Row( _
     ByVal SubCatId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblProductSub_select & "  AND [SubCatId]=@SubCatId_"

        With comSelection.Parameters
            .AddWithValue("@SubCatId_", SubCatId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("SubCatId") Is DBNull.Value Then : .SubCatId_ = dt.Rows(0).Item("SubCatId") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("SubCatName") Is DBNull.Value Then : .SubCatName_ = dt.Rows(0).Item("SubCatName") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblProductSub_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("SubCatId") Is DBNull.Value Then : .SubCatId_ = dt.Rows(0).Item("SubCatId") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("SubCatName") Is DBNull.Value Then : .SubCatName_ = dt.Rows(0).Item("SubCatName") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SubCatId
                fn = "SubCatId"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.SubCatName
                fn = "SubCatName"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblProductSub] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.SubCatId
                fn = "SubCatId"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.SubCatName
                fn = "SubCatName"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblProductSub] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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


Public Class Database_Table_code_class_tblTask
    Public Shared tablename As String = "tblTask"


    Structure Fields


        Dim TaskId_ As Int32
        Dim CreatedDate_ As DateTime
        Dim TaskDate_ As DateTime
        Dim Task_ As String
        Dim TaskSubject_ As String
        Dim Details_ As String
        Dim Createdby_ As Int32
        Dim UpdatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim TaskStatus_ As String
        Dim AssignTo_ As Int32
        Dim AssignToDesc_ As String

    End Structure


    Enum FieldName


        [TaskId]
        [CreatedDate]
        [TaskDate]
        [Task]
        [TaskSubject]
        [Details]
        [Createdby]
        [UpdatedBy]
        [UpdatedDate]
        [TaskStatus]
        [AssignTo]
        [AssignToDesc]
    End Enum


    Public ReadOnly Property tblTask_insert
        Get
            Return <tblTask_insert><![CDATA[
  INSERT INTO [tblTask]
  (
      [TaskId],
      [CreatedDate],
      [TaskDate],
      [Task],
      [TaskSubject],
      [Details],
      [Createdby],
      [UpdatedBy],
      [UpdatedDate],
      [TaskStatus],
	  [AssignTo]
  )
  VALUES
  (
      @TaskId_,
      @CreatedDate_,
      @TaskDate_,
      @Task_,
      @TaskSubject_,
      @Details_,
      @Createdby_,
      @UpdatedBy_,
      @UpdatedDate_,
      @TaskStatus_,
	  @AssignTo_
  )
]]></tblTask_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblTask_update
        Get
            Return <tblTask_update><![CDATA[
UPDATE [tblTask]
Set 
    [CreatedDate]=@CreatedDate_,
    [TaskDate]=@TaskDate_,
    [Task]=@Task_,
    [TaskSubject]=@TaskSubject_,
    [Details]=@Details_,
    [Createdby]=@Createdby_,
    [UpdatedBy]=@UpdatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [TaskStatus]=@TaskStatus_,
    [AssignTo]=@AssignTo_
 WHERE [TaskId]=@TaskId_
]]></tblTask_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblTask_select
        Get
            Return <tblTask_select><![CDATA[
    SELECT 
          T.[TaskId],
          T.[CreatedDate],
          T.[TaskDate],
          T.[Task],
          T.[TaskSubject],
          T.[Details],
          T.[Createdby],
          T.[UpdatedBy],
          T.[UpdatedDate],
          T.[TaskStatus],
          T.[AssignTo], FullName as AssignToDesc
    FROM [tblTask] T left join tblUserDetails U on [AssignTo]=UserId
        WHERE 1=1
]]></tblTask_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblTask_Delete_By_RowID
        Get
            Return <tblTask_Delete_By_RowID><![CDATA[
DELETE FROM [tblTask] WHERE [TaskId]=@TaskId_
]]></tblTask_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblTask_Delete_By_SELECT
        Get
            Return <tblTask_Delete_By_SELECT><![CDATA[
DELETE FROM [tblTask] WHERE 1=1
]]></tblTask_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblTask_MAXID
        Get
            Return <tblTask_MAXID><![CDATA[
SELECT MAX([TaskId]) FROM [tblTask] WHERE 1=1
]]></tblTask_MAXID>.Value
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

        Dim comMaxID As New SqlCommand(tblTask_MAXID, _conn)
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
    ByVal CreatedDate_ As DateTime, _
    ByVal TaskDate_ As DateTime, _
    ByVal Task_ As String, _
    ByVal TaskSubject_ As String, _
    ByVal Details_ As String, _
    ByVal Createdby_ As Int32, _
    ByVal UpdatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal TaskStatus_ As String, _
    ByVal AssignTo_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim TaskId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblTask_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@TaskId_", TaskId_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@TaskDate_", TaskDate_)
            .AddWithValue("@Task_", Task_)
            .AddWithValue("@TaskSubject_", TaskSubject_)
            .AddWithValue("@Details_", Details_)
            .AddWithValue("@Createdby_", Createdby_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@TaskStatus_", TaskStatus_)
            .AddWithValue("@AssignTo_", AssignTo_)

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
        Return TaskId_
    End Function



    Function Update(
    ByVal CreatedDate_ As DateTime, _
    ByVal TaskDate_ As DateTime, _
    ByVal Task_ As String, _
    ByVal TaskSubject_ As String, _
    ByVal Details_ As String, _
    ByVal Createdby_ As Int32, _
    ByVal UpdatedBy_ As Int32, _
    ByVal UpdatedDate_ As DateTime, _
    ByVal TaskStatus_ As String, _
    ByVal TaskId_ As Int32, _
    ByVal AssignTo_ As Int32, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblTask_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@TaskDate_", TaskDate_)
            .AddWithValue("@Task_", Task_)
            .AddWithValue("@TaskSubject_", TaskSubject_)
            .AddWithValue("@Details_", Details_)
            .AddWithValue("@Createdby_", Createdby_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@TaskStatus_", TaskStatus_)
            .AddWithValue("@TaskId_", TaskId_)
            .AddWithValue("@AssignTo_", AssignTo_)

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

        Return TaskId_
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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.TaskId
                fn = "TaskId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.TaskDate
                fn = "TaskDate"
            Case FieldName.Task
                fn = "Task"
            Case FieldName.TaskSubject
                fn = "TaskSubject"
            Case FieldName.Details
                fn = "Details"
            Case FieldName.Createdby
                fn = "Createdby"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.TaskStatus
                fn = "TaskStatus"
            Case FieldName.AssignTo
                fn = "AssignTo"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblTask] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblTask_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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



    Function Delete_By_RowID( _
     ByVal TaskId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblTask_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@TaskId_", TaskId_)

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
        Return TaskId_
    End Function



    Function Selection_One_Row( _
     ByVal TaskId_ As Int32, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTask_select & "  AND [TaskId]=@TaskId_"

        With comSelection.Parameters
            .AddWithValue("@TaskId_", TaskId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("TaskId") Is DBNull.Value Then : .TaskId_ = dt.Rows(0).Item("TaskId") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("TaskDate") Is DBNull.Value Then : .TaskDate_ = dt.Rows(0).Item("TaskDate") : End If
                If Not dt.Rows(0).Item("Task") Is DBNull.Value Then : .Task_ = dt.Rows(0).Item("Task") : End If
                If Not dt.Rows(0).Item("TaskSubject") Is DBNull.Value Then : .TaskSubject_ = dt.Rows(0).Item("TaskSubject") : End If
                If Not dt.Rows(0).Item("Details") Is DBNull.Value Then : .Details_ = dt.Rows(0).Item("Details") : End If
                If Not dt.Rows(0).Item("Createdby") Is DBNull.Value Then : .Createdby_ = dt.Rows(0).Item("Createdby") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("TaskStatus") Is DBNull.Value Then : .TaskStatus_ = dt.Rows(0).Item("TaskStatus") : End If
                If Not dt.Rows(0).Item("AssignTo") Is DBNull.Value Then : .AssignTo_ = dt.Rows(0).Item("AssignTo") : End If
                If Not dt.Rows(0).Item("AssignToDesc") Is DBNull.Value Then : .AssignToDesc_ = dt.Rows(0).Item("AssignToDesc") : End If

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




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

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
        comSelection.CommandText = tblTask_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                comSelection.Parameters.Add(p)
            Next
        End If
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("TaskId") Is DBNull.Value Then : .TaskId_ = dt.Rows(0).Item("TaskId") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("TaskDate") Is DBNull.Value Then : .TaskDate_ = dt.Rows(0).Item("TaskDate") : End If
                If Not dt.Rows(0).Item("Task") Is DBNull.Value Then : .Task_ = dt.Rows(0).Item("Task") : End If
                If Not dt.Rows(0).Item("TaskSubject") Is DBNull.Value Then : .TaskSubject_ = dt.Rows(0).Item("TaskSubject") : End If
                If Not dt.Rows(0).Item("Details") Is DBNull.Value Then : .Details_ = dt.Rows(0).Item("Details") : End If
                If Not dt.Rows(0).Item("Createdby") Is DBNull.Value Then : .Createdby_ = dt.Rows(0).Item("Createdby") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("TaskStatus") Is DBNull.Value Then : .TaskStatus_ = dt.Rows(0).Item("TaskStatus") : End If
                If Not dt.Rows(0).Item("AssignTo") Is DBNull.Value Then : .AssignTo_ = dt.Rows(0).Item("TaskStatus") : End If
                If Not dt.Rows(0).Item("AssignToDesc") Is DBNull.Value Then : .AssignToDesc_ = dt.Rows(0).Item("AssignToDesc") : End If

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

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.TaskId
                fn = "TaskId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.TaskDate
                fn = "TaskDate"
            Case FieldName.Task
                fn = "Task"
            Case FieldName.TaskSubject
                fn = "TaskSubject"
            Case FieldName.Details
                fn = "Details"
            Case FieldName.Createdby
                fn = "Createdby"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.TaskStatus
                fn = "TaskStatus"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblTask] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.TaskId
                fn = "TaskId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.TaskDate
                fn = "TaskDate"
            Case FieldName.Task
                fn = "Task"
            Case FieldName.TaskSubject
                fn = "TaskSubject"
            Case FieldName.Details
                fn = "Details"
            Case FieldName.Createdby
                fn = "Createdby"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.TaskStatus
                fn = "TaskStatus"
            Case FieldName.AssignTo
                fn = "AssignTo"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblTask] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
                'Throw New Exception("No Records Found")
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