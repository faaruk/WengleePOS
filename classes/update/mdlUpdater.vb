Imports System.IO

Module mdlUpdater
    Public CurrentVersion As String = "http://www.bidyutdas.com/wenglee/version.txt"
    Public UpdaterOnlineLocation As String = "http://www.bidyutdas.com/wenglee/updater.exe"
    Public UpdaterOfflineLocation As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "updater.exe")

    'WithEvents UploaderDownload As New Net.WebClient

    Sub CheckVersion()
        If DeveloperPc() Then
            Try
                My.Computer.FileSystem.WriteAllText("version.txt", My.Application.Info.Version.ToString, False)
            Catch ex As Exception
            End Try
        End If
        If Not DeveloperPc() Then
            Try
                Dim wb As New Net.WebClient
                Dim reader As StreamReader = New StreamReader(wb.OpenRead(CurrentVersion))
                Dim cv As String = reader.ReadToEnd.Trim
                If My.Application.Info.Version < New Version(cv) Then
                    MsgBox("New version " & cv & " of this app is found online. App will automatically download and restart", MsgBoxStyle.Information, "Version Alert")
                    StartUpdater()
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub

    Function CheckVersion2() As Boolean
        Dim rt As Boolean = False
        Try
            Dim wb As New Net.WebClient
            Dim reader As StreamReader = New StreamReader(wb.OpenRead(CurrentVersion))
            Dim cv As String = reader.ReadToEnd.Trim
            rt = My.Application.Info.Version < New Version(cv)
        Catch ex As Exception
        End Try
        Return rt
    End Function

    Sub StartUpdater()
        Try
            If IO.File.Exists(UpdaterOfflineLocation) Then
                IO.File.Delete(UpdaterOfflineLocation)
            End If
            'Check Whether File exists over internet. Then start what we have in resource.
            Dim UpdaterDownload As New Net.WebClient
            Try

                If UpdaterDownload.OpenRead(UpdaterOnlineLocation).Length = 0 Then
                    Throw New Exception("Uploader not found over internet")
                End If
                UpdaterDownload.DownloadFile(UpdaterOnlineLocation, UpdaterOfflineLocation)
            Catch ex As Exception
                'Since updater not found over internet we are going to start with what we have
                My.Computer.FileSystem.WriteAllBytes(UpdaterOfflineLocation, My.Resources.Updater, False)
            End Try
            'Start the process
            Process.Start(UpdaterOfflineLocation)
            Try
                Application.Exit()
                End
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Could not start updater.exe. Please start it manually.")
        End Try
    End Sub

End Module
