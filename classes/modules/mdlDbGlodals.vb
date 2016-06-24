Module mdlDbGlodals
    Public Sub FillComBoBox(ByVal cmb As ComboBox, ByVal tablename As String, ByVal display As String, ByVal value As String, Optional ByVal selectstring As String = "", Optional ByVal FirstItemText As String = "-Select-")
        Dim objConn As New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim da As New SqlDataAdapter(" Select [" & display & "],[" & value & "] from [" & tablename & "] Where 1=1 " & IIf(selectstring.Trim <> "", IIf(selectstring.Trim.ToUpper.StartsWith("AND"), selectstring, " AND " & selectstring), "") & " Order by [" & display & "]", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim dr As DataRow = dt.NewRow
        dr(0) = FirstItemText
        dr(1) = "0"
        dt.Rows.InsertAt(dr, 0)
        cmb.DisplayMember = display
        cmb.ValueMember = value
        cmb.DataSource = dt
    End Sub

    Public Sub FillComBoBox(ByVal cmb As DataGridViewComboBoxColumn, ByVal tablename As String, ByVal display As String, ByVal value As String, Optional ByVal selectstring As String = "", Optional ByVal FirstItemText As String = "-Select-")
        Dim objConn As New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim da As New SqlDataAdapter(" Select [" & display & "],[" & value & "] from [" & tablename & "] Where 1=1 " & IIf(selectstring.Trim <> "", IIf(selectstring.Trim.ToUpper.StartsWith("AND"), selectstring, " AND " & selectstring), "") & " Order by [" & display & "]", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim dr As DataRow = dt.NewRow
        dr(0) = FirstItemText
        dr(1) = "0"
        dt.Rows.InsertAt(dr, 0)
        cmb.DisplayMember = display
        cmb.ValueMember = value
        cmb.DataSource = dt
    End Sub


    Public Function ExecuteAdapter(ByVal Query As String, Optional ByVal _params As List(Of SqlParameter) = Nothing) As DataTable
        Dim objConn As New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim da As New SqlDataAdapter(Query, conn)
        Dim dt As New DataTable
        If Not _params Is Nothing Then
            For Each p As SqlParameter In _params
                da.SelectCommand.Parameters.Add(p)
            Next
        End If
        da.Fill(dt)
        Return dt
    End Function

    Sub RefreshTransfererDB()

        'WENGLEE -U transfer -P WLFtrans88! -Q "exec USER_SP_UPDATE_TRANSFER_DB"
        Dim con As New SqlConnection("Data Source=WLFSERVER;Initial Catalog=WENGLEE;User ID=transfer; password=WLFtrans88!")
        Dim com As New SqlCommand("USER_SP_UPDATE_TRANSFER_DB", con)
        Try
            con.Close()
            con.Open()
            com.CommandType = CommandType.StoredProcedure
            com.CommandTimeout = 0
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Dispose()
            com.Dispose()
        End Try
    End Sub


End Module
