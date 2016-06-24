Imports System.Reflection
Imports System.IO

Public Class clsConnection
    Implements IDisposable
    Private conn As SqlConnection = Nothing
    Function connect() As SqlConnection

        If disposedValue Then
            Throw New Exception("Class disposed")
        End If

        If conn Is Nothing OrElse conn.State = ConnectionState.Closed OrElse conn.State = ConnectionState.Broken OrElse conn.State = ConnectionState.Connecting Then
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
            End If
            conn = New SqlConnection(connstr)
            conn.Open()
        End If
        Return conn
    End Function

    Private connTransfer As SqlConnection = Nothing
    Function connectTransfer() As SqlConnection
        If disposedValue Then
            Throw New Exception("Class disposed")
        End If
        If connTransfer Is Nothing OrElse connTransfer.State = ConnectionState.Closed OrElse connTransfer.State = ConnectionState.Broken OrElse connTransfer.State = ConnectionState.Connecting Then
            If connTransfer IsNot Nothing Then
                connTransfer.Close()
                connTransfer.Dispose()
            End If
            connTransfer = New SqlConnection(connstrTransfer)
            connTransfer.Open()
        End If
        Return connTransfer
    End Function

    Function connstr() As String
        'Dim connstr_text As String = ""
        'Try
        '    connstr_text = My.Computer.FileSystem.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\", "") & "\SERVER.txt")
        'Catch ex As Exception
        'End Try
        'If My.Computer.Name.ToUpper = "BIDYUT-LAPTOP" Or My.Computer.Name.ToUpper = "BIDYUT" Then
        If My.Computer.Name.ToUpper = "USER-PC" Then
            'Return "Data Source=192.168.0.99;Initial Catalog=dbWengLee;User ID=sa; password=Kumar"
            Return "Data Source=USER-PC\SQL2014;Initial Catalog=dbWenglee;User ID=sa; password=sql2014"
        Else
            Return "Data Source=WLFSERVER;Initial Catalog=dbWenglee;User ID=Odesk; password=PickAdmin!"
            'Return "Data Source=USER-PC\SQL2014;Initial Catalog=dbWenglee;User ID=sa; password=sql2014"
            'If connstr_text.Trim = "" Then
            '    Dim frm As New frmConnectionSettings
            '    If frm.ShowDialog = DialogResult.OK Then
            '        connstr_text = frm.encryted_str
            '    Else
            '        End
            '    End If
            'End If
            'Return Decrypt(connstr_text)
        End If
    End Function


    Function connstrTransfer() As String
        'Dim connstr_text As String = ""
        'Try
        '    connstr_text = My.Computer.FileSystem.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\", "") & "\SERVER.txt")
        'Catch ex As Exception
        'End Try
        'If My.Computer.Name.ToUpper = "BIDYUT-LAPTOP" Or My.Computer.Name.ToUpper = "BIDYUT" Then
        If My.Computer.Name.ToUpper = "USER-PC" Then
            'Return "Data Source=BIDYUT-LAPTOP;Initial Catalog=dbWengleeTransferer;User ID=sa; password=Kumar"
            Return "Data Source=USER-PC\SQL2014;Initial Catalog=dbWengleeTransferer;User ID=sa; password=sql2014"
        Else
            Return "Data Source=WLFSERVER;Initial Catalog=dbWengleeTransferer;User ID=Odesk; password=PickAdmin!"
            'Return "Data Source=USER-PC\SQL2014;Initial Catalog=dbWengleeTransferer;User ID=sa; password=sql2014"
            'If connstr_text.Trim = "" Then
            '    Dim frm As New frmConnectionSettings
            '    If frm.ShowDialog = DialogResult.OK Then
            '        connstr_text = frm.encryted_str
            '    Else
            '        End
            '    End If
            'End If
            'Return Decrypt(connstr_text)
        End If
    End Function



#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                conn.Close()
                conn.Dispose()
                If Not IsNothing(connTransfer) Then
                    connTransfer.Close()
                    connTransfer.Dispose()
                End If
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class
