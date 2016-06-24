'Class Version : 1.0.0.2
'Created Dated : 13/03/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_t_tblCustomer
Inherits Database_Table_code_class_tblCustomer

    Enum SelectionType
        All = 0
        DISTINCT_ROUTECITY = 1
    End Enum
    Private ReadOnly Property tblCustomer_Select_DISTINCT_ROUTECITY
        Get
            Return <tblCustomer_Select><![CDATA[

SELECT DISTINCT routecity
FROM(
    SELECT routecity
    FROM tblcustomer
    UNION ALL
    SELECT routecity
    FROM tblcustomer_bol ) n
WHERE routecity NOT IN( '' )

 
                    ]]></tblCustomer_Select>.Value
        End Get
    End Property
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
                comSelection.CommandText = tblCustomer_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.DISTINCT_ROUTECITY
                If _SelectString <> "" Then
                    Throw New Exception("Select string not required")
                End If
                comSelection.CommandText = tblCustomer_Select_DISTINCT_ROUTECITY '& IIf(_SelectString <> "", IIf(_SelectString.Trim.ToUpper.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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
                'Throw New Exception("No Records Found")
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

End Class