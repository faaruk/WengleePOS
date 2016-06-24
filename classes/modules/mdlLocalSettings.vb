Imports Newtonsoft.Json

Module mdlLocalSettings
    '<Serializable()>
    'Structure LocalSetting
    '    Dim ReceiptPrinter As String
    '    Dim ReportPrinter As String
    '    Dim EmailUserName As String
    '    Dim EmailPass As String
    '    Dim DisableAutoUpdate As Boolean
    '    Dim FileLocation As String
    'End Structure
    <Serializable()>
    Class LocalSetting

        Sub New()
            RaiseEvent ReceiptPrinterChanged(Me)
            RaiseEvent ReportPrinterChanged(Me)
            RaiseEvent EmailUserNameChanged(Me)
            RaiseEvent EmailPassChanged(Me)
            RaiseEvent DisableAutoUpdateChanged(Me)
            RaiseEvent FileLocationChanged(Me)
        End Sub



        Dim vReceiptPrinter As String = ""
        Event ReceiptPrinterChanged(sender As LocalSetting)
        Public Property ReceiptPrinter As String
            Get
                Return vReceiptPrinter
            End Get
            Set(value As String)
                vReceiptPrinter = value
                RaiseEvent ReceiptPrinterChanged(Me)
            End Set
        End Property

        Dim vReportPrinter As String = ""
        Event ReportPrinterChanged(sender As LocalSetting)
        Public Property ReportPrinter As String
            Get
                Return vReportPrinter
            End Get
            Set(value As String)
                vReportPrinter = value
                RaiseEvent ReportPrinterChanged(Me)
            End Set
        End Property

        Dim vEmailUserName As String = ""
        Event EmailUserNameChanged(sender As LocalSetting)
        Public Property EmailUserName As String
            Get
                Return vEmailUserName
            End Get
            Set(value As String)
                vEmailUserName = value
                RaiseEvent EmailUserNameChanged(Me)
            End Set
        End Property


        Dim vEmailPass As String = ""
        Event EmailPassChanged(sender As LocalSetting)
        Public Property EmailPass As String
            Get
                Return vEmailPass
            End Get
            Set(value As String)
                vEmailPass = value
                RaiseEvent EmailPassChanged(Me)
            End Set
        End Property


        Dim vDisableAutoUpdate As Boolean = True
        Event DisableAutoUpdateChanged(sender As LocalSetting)
        Public Property DisableAutoUpdate As Boolean
            Get
                Return vDisableAutoUpdate
            End Get
            Set(value As Boolean)
                vDisableAutoUpdate = value
                RaiseEvent DisableAutoUpdateChanged(Me)
            End Set
        End Property


        Dim vFileLocation As String = ""
        Event FileLocationChanged(sender As LocalSetting)
        Public Property FileLocation As String
            Get
                Return vFileLocation
            End Get
            Set(value As String)
                vFileLocation = value
                RaiseEvent FileLocationChanged(Me)
            End Set
        End Property

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

    End Class

    Public WithEvents MyLocalSettings As LocalSetting = Nothing
    Dim localSettingsFile As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "localsettings.ini")

    Sub OnfileLocationChanged(sender As LocalSetting) Handles MyLocalSettings.FileLocationChanged
        frmMainAndAlsoStartupForm.DBidyutuserfolderDesktopToolStripMenuItem.Text = sender.FileLocation
    End Sub

    Public Sub LoadLocalSettings()
        Try
            If IO.File.Exists(localSettingsFile) Then
                MyLocalSettings = JsonConvert.DeserializeObject(Of LocalSetting)(IO.File.ReadAllText(localSettingsFile))
                SetAttr(localSettingsFile, FileAttribute.System + FileAttribute.Hidden)
            Else
                MyLocalSettings = New LocalSetting
                MyLocalSettings.ReceiptPrinter = ""
                MyLocalSettings.ReportPrinter = ""
                MyLocalSettings.FileLocation = ""
                MyLocalSettings.DisableAutoUpdate = False
                SaveLocalSettings()
            End If
            'AddHandler MyLocalSettings.FileLocationChanged, AddressOf OnfileLocationChanged
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SaveLocalSettings()
        Try
            IO.File.WriteAllText(localSettingsFile, JsonConvert.SerializeObject(MyLocalSettings), System.Text.Encoding.ASCII)

        Catch ex As Exception
        End Try
        SetAttr(localSettingsFile, FileAttribute.System + FileAttribute.Hidden)
    End Sub

End Module
