Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.


    Partial Friend Class MyApplication
        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            If UserLoggedIn Then
                Logout()
            End If
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            '//Setup Refernce Location
            If Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "Newtonsoft.Json.dll")) Then
                My.Computer.FileSystem.WriteAllBytes(My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "Newtonsoft.Json.dll"), My.Resources.Newtonsoft_Json, False)
            End If

            SetAttr(My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "Newtonsoft.Json.dll"), FileAttribute.System + FileAttribute.Hidden)

            'CheckVersion()
            LoadLocalSettings()

            'Try
            '    Dim objUpdate As New clsDBUpdate
            '    objUpdate.CheckDBVerification()
            'Catch ex As Exception
            'End Try
        End Sub

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            'TODO: If Logged in Show main Screen else show Login Window

        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MsgBox(e.Exception.Message, MsgBoxStyle.Critical, "Info")
        End Sub

    End Class


End Namespace

