Imports System.IO
Public Class clsDBUpdate
     
    Function CheckDBVerification() As Boolean
        Dim ret As Boolean = False
        Dim objCon As New clsConnection
        Dim con As SqlConnection = Nothing
        con = objCon.connect()
        Dim version As Integer = 0
        Try
            Dim com As New SqlCommand("Select max(convert(integer,Version)) from tblVersion", con)
            version = com.ExecuteScalar
        Catch ex As Exception
        End Try

        Try
            If version < 13 Then
                executeSqlScript(My.Resources.Version_13, con)
            End If
            If version < 14 Then
                executeSqlScript(My.Resources.Version_14, con)
            End If
            If version < 15 Then
                executeSqlScript(My.Resources.Version_15, con)
            End If
            If version < 16 Then
                executeSqlScript(My.Resources.Version_16, con)
            End If
            If version < 17 Then
                executeSqlScript(My.Resources.Version_17, con)
            End If
            If version < 18 Then ' 27/09/2015
                executeSqlScript(My.Resources.Version_18, con)
            End If
            If version < 19 Then ' 28/09/2015
                executeSqlScript(My.Resources.Version_19, con)
            End If
        Catch ex As Exception
        End Try

        objCon.Dispose()
        Return ret
    End Function
    
    Public Sub executeSqlScript(ByVal sqlScript As String, ByVal connection As SqlConnection)
        Dim command As SqlCommand = connection.CreateCommand()
        Dim sqlScriptReader = New StringReader(sqlScript)
        Dim sqlBatch = New StringWriter()
        While (sqlScriptReader.Peek() <> -1)
            Dim sqlScriptLine = sqlScriptReader.ReadLine()
            If (sqlScriptLine.Trim().ToUpper() = "GO") Then
                command.CommandText = sqlBatch.ToString()
                executeBatch(command)
                sqlBatch = New StringWriter()
            Else
                sqlBatch.WriteLine(sqlScriptLine)
            End If
        End While
        command.CommandText = sqlBatch.ToString()
        executeBatch(command)


    End Sub

    Sub executeBatch(ByVal command As SqlCommand)

        Try
            If (command.CommandText.Trim() <> String.Empty) Then
                command.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try

    End Sub
 

End Class


