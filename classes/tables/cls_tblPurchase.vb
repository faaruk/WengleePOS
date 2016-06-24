Public Class cls_tblPurchase
    Public Shared tablename As String = "tblPurchase"
    Structure Fields
        Dim PurchaseId As Integer
        Dim VendorId As Integer
        Dim PurchaseDate As Date
        Dim PO_No As String
        Dim InvoiceNo As String
        Dim TotalAmount As Decimal
        Dim CreatedDate As Date
        Dim CreatedBy As Integer
        Dim UpdatedDate As Date
        Dim UpdatedBy As Integer
        Dim Session As String
    End Structure

    Enum FieldName
        PurchaseId
        VendorId
        PurchaseDate
        PO_No
        InvoiceNo
        TotalAmount
        CreatedDate
        CreatedBy
        UpdatedDate
        UpdatedBy
        Session
    End Enum

    Private ReadOnly Property tblPurchase_insert
        Get
            Return <tblPurchase_insert><![CDATA[
INSERT INTO  [tblPurchase]
           ([PurchaseId]
           ,[VendorId]
           ,[PurchaseDate]
           ,[PO_No]
           ,[InvoiceNo]
           ,[TotalAmount]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedBy]
           ,[Session])
     VALUES
           (@PurchaseId 
           ,@VendorId 
           ,@PurchaseDate 
           ,@PO_No 
           ,@InvoiceNo 
           ,@TotalAmount
           ,@CreatedDate
           ,@CreatedBy
           ,@UpdatedDate
           ,@UpdatedBy
           ,@Session )
                    ]]></tblPurchase_insert>.Value
        End Get
    End Property
    Private ReadOnly Property tblPurchase_update
        Get
            Return <tblPurchase_update><![CDATA[
UPDATE [tblPurchase]
   SET [VendorId] = @VendorId 
      ,[PurchaseDate] = @PurchaseDate 
      ,[PO_No] = @PO_No 
      ,[InvoiceNo] = @InvoiceNo 
      ,[TotalAmount] = @TotalAmount 
      ,[CreatedDate] = @CreatedDate 
      ,[CreatedBy] = @CreatedBy 
      ,[UpdatedDate] = @UpdatedDate 
      ,[UpdatedBy] = @UpdatedBy 
      ,[Session] = @Session 
WHERE
[PurchaseId]=@PurchaseId


                    ]]></tblPurchase_update>.Value
        End Get
    End Property

    Private ReadOnly Property tblPurchase_Delete_By_PurchaseId
        Get
            Return <tblPurchase_Delete><![CDATA[

DELETE FROM
[tblPurchase] 
WHERE
[PurchaseId]=@PurchaseId
                    ]]></tblPurchase_Delete>.Value
        End Get
    End Property

    Private ReadOnly Property tblPurchase_Delete_By_SELECT
        Get
            Return <tblPurchase_Delete><![CDATA[

DELETE FROM
[tblPurchase] 
WHERE
1=1
                    ]]></tblPurchase_Delete>.Value
        End Get
    End Property
    Private ReadOnly Property tblPurchase_MAXID
        Get
            Return <tblPurchase_MAXID><![CDATA[

SELECT MAX([PurchaseId]) FROM [tblPurchase] WHERE 1=1
                    ]]></tblPurchase_MAXID>.Value
        End Get
    End Property
    Private ReadOnly Property tblPurchase_Select
        Get
            Return <tblPurchase_Select><![CDATA[
SELECT [PurchaseId]
      ,[VendorId]
      ,[PurchaseDate]
      ,[PO_No]
      ,[InvoiceNo]
      ,[TotalAmount]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[UpdatedDate]
           ,[UpdatedBy]
           ,[Session]

 FROM [tblPurchase] 

WHERE 1=1
                    ]]></tblPurchase_Select>.Value
        End Get
    End Property
    Private ReadOnly Property tblPurchase_Select_Review
        Get
            Return <tblPurchase_Select><![CDATA[
SELECT a.[PurchaseId]
      ,a.[VendorId]
      ,b.VendorName
      ,a.[PurchaseDate]
      ,a.[PO_No]
      ,a.[InvoiceNo]
      ,a.[TotalAmount]
    ,a.[CreatedDate]
    ,d.UserName as  [CreatedBy]
    ,a.[UpdatedDate]
    ,e.UserName as  [UpdatedBy]
    ,a.[Session]
    ,c.TotalItems 

 FROM [tblPurchase] a
 left outer join 
 [tblVendor] b  on a.VendorId = b.VendorID 
 left outer join 
 (select SUM(qty) as totalitems, TransactionId  from tblStock where TransactionType ='PURCHASE' group by TransactionId , TransactionType ) c on a.PurchaseId = c.TransactionId 
 left outer join 
 tblUserDetails d  on a.createdby = d.UserId  
  left outer join 
 tblUserDetails e  on a.updatedby = e.UserId  

WHERE 1=1
                    ]]></tblPurchase_Select>.Value
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
          VendorId As Integer, _
          PurchaseDate As Date, _
          PO_No As String, _
          InvoiceNo As String, _
          TotalAmount As Decimal, _
          CreatedDate As Date, _
          CreatedBy As Integer, _
          UpdatedDate As Date, _
          UpdatedBy As Integer, _
          Session As String, _
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim PurchaseId As Integer = MaxID_PlusOne(_conn, _transac)

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
            .AddWithValue("@PurchaseId", PurchaseId)
            .AddWithValue("@VendorId", VendorId)
            .AddWithValue("@PurchaseDate", PurchaseDate)
            .AddWithValue("@PO_No", PO_No)
            .AddWithValue("@InvoiceNo", InvoiceNo)
            .AddWithValue("@TotalAmount", TotalAmount) 
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Session", Session)
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
        Return PurchaseId
    End Function

    Function Update(ByVal PurchaseId As Integer, _
                     ByVal VendorId As Integer, _
                     ByVal PurchaseDate As Date, _
                     ByVal PO_No As String, _
                     ByVal InvoiceNo As String, _
                     ByVal TotalAmount As Decimal, _
          CreatedDate As Date, _
          CreatedBy As Integer, _
          UpdatedDate As Date, _
          UpdatedBy As Integer, _
          Session As String, _
                     Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


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
            .AddWithValue("@VendorId", VendorId)
            .AddWithValue("@PurchaseDate", PurchaseDate)
            .AddWithValue("@PO_No", PO_No)
            .AddWithValue("@InvoiceNo", InvoiceNo)
            .AddWithValue("@TotalAmount", TotalAmount)
            .AddWithValue("@CreatedDate", CreatedDate)
            .AddWithValue("@CreatedBy", CreatedBy)
            .AddWithValue("@UpdatedDate", UpdatedDate)
            .AddWithValue("@UpdatedBy", UpdatedBy)
            .AddWithValue("@Session", Session)
            .AddWithValue("@PurchaseId", PurchaseId)
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

        Return PurchaseId
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

        Dim comUpdate As New SqlCommand("Update [tblPurchase] Set [" & _fieldName.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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

        Dim comDelete As New SqlCommand(tblPurchase_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
    Function Delete_By_PurchaseId(ByRef PurchaseId As Integer, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblPurchase_Delete_By_PurchaseId, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@PurchaseId", PurchaseId)
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
        Return PurchaseId
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
                comSelection.CommandText = tblPurchase_Select & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.Review
                comSelection.CommandText = tblPurchase_Select_Review & IIf(_SelectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
    Function Selection_One_Row(ByVal PurchaseId As Integer, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields
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
        comSelection.CommandText = tblPurchase_Select & " AND [PurchaseId]=@PurchaseId"
        comSelection.Parameters.AddWithValue("@PurchaseId", PurchaseId)

        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                Throw New Exception("No Records Found")
            End If
            With return_field
                .PurchaseId = dt.Rows(0).Item("PurchaseId")
                .VendorId = dt.Rows(0).Item("VendorId")
                .PurchaseDate = dt.Rows(0).Item("PurchaseDate")
                .PO_No = dt.Rows(0).Item("PO_No")
                .InvoiceNo = dt.Rows(0).Item("InvoiceNo")
                .TotalAmount = dt.Rows(0).Item("TotalAmount")
                .CreatedDate = dt.Rows(0).Item("CreatedDate")
                .CreatedBy = dt.Rows(0).Item("CreatedBy")
                .UpdatedDate = dt.Rows(0).Item("UpdatedDate")
                .UpdatedBy = dt.Rows(0).Item("UpdatedBy")
                .Session = dt.Rows(0).Item("Session")
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

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & _fieldName.ToString & "  from [tblPurchase] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & _fieldName.ToString & "  from [tblPurchase] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectstring.Trim.ToUpper.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
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
