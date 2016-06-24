Imports Microsoft.Win32

Public Class frmViewMap

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Print.Click
        'WebBrowser1.Focus()
        'Panel1.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
        'e.Graphics.DrawImage(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
        'Dim bmp2 As Image = WebUti.ControlExtensions.DrawToImage(WebBrowser1)
        'e.Graphics.DrawImage(bmp2, New Rectangle(WebBrowser1.Location, WebBrowser1.Size))
        printHTMLFile(False, 1)
    End Sub

    Private Sub frmViewMap_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     End Sub

    Sub LoadMap(Attrib As String, type As String)
        Me.Activate()
        Me.Focus()
        Me.WindowState = FormWindowState.Maximized
        Dim Lnk As String = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyB401t_ObRkih8dkMIsIqZl-yUsODao3GU" & Attrib

        Select Case type
            Case "Direction"
                Lnk = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyB401t_ObRkih8dkMIsIqZl-yUsODao3GU" & Attrib
            Case "Place"
                Lnk = "https://www.google.com/maps/embed/v1/place?key=AIzaSyB401t_ObRkih8dkMIsIqZl-yUsODao3GU" & Attrib ' & "&zoom=10"
        End Select

        Dim str As String = "<HTML> <iframe frameborder=""0"" style=""border:0"" height=100% width=100% src=""" & Lnk & """></iframe></HTML>"
        Try

            PageLoc = My.Computer.FileSystem.SpecialDirectories.Temp & "\map1.html"
            My.Computer.FileSystem.WriteAllText(PageLoc, str, False)
        Catch ex As Exception
            PageLoc = My.Computer.FileSystem.SpecialDirectories.Temp & "\map2.html"
            My.Computer.FileSystem.WriteAllText(PageLoc, str, False)
        End Try
        WebBrowser1.Navigate(PageLoc)
    End Sub
    Dim PageLoc As String = ""
    Private Sub frmViewMap_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        WindowState = FormWindowState.Maximized
    End Sub

    Sub printHTMLFile(Portrait As Boolean, Copies As Integer)
        Const PAGESET_KEY As String = "Software\Microsoft\Internet Explorer\PageSetup"
        If Copies < 1 Then Exit Sub
        Dim MyKey As RegistryKey = Registry.CurrentUser.OpenSubKey(PAGESET_KEY, True)
        Dim TempFooter As String = MyKey.GetValue("footer").ToString()
        Dim TempHeader As String = MyKey.GetValue("header").ToString()
        Dim TempBottom As String = MyKey.GetValue("margin_bottom").ToString()
        Dim TempLeft As String = MyKey.GetValue("margin_left").ToString()
        Dim TempRight As String = MyKey.GetValue("margin_right").ToString()
        Dim TempTop As String = MyKey.GetValue("margin_top").ToString()
        MyKey.SetValue("footer", String.Empty)
        MyKey.SetValue("header", String.Empty)
        MyKey.SetValue("margin_bottom", "0.10000")
        MyKey.SetValue("margin_left", "0.10000")
        MyKey.SetValue("margin_right", "0.10000")
        MyKey.SetValue("margin_top", "0.10000")
        MyKey.Close()
        pageSet(Portrait)

        'Dim WB As WebBrowser = New WebBrowser()
        'WB.Navigate(FileName)
        'While WB.ReadyState <> WebBrowserReadyState.Complete
        '    'Thread.Sleep (100)
        '    Application.DoEvents()
        'End While
        For i As Integer = 1 To Copies
            WebBrowser1.Print()
        Next

        'MyKey = Registry.CurrentUser.OpenSubKey(PAGESET_KEY, True)
        'MyKey.SetValue("footer", TempFooter)
        'MyKey.SetValue("header", TempHeader)
        'MyKey.SetValue("margin_bottom", TempBottom)
        'MyKey.SetValue("margin_left", TempLeft)
        'MyKey.SetValue("margin_right", TempRight)
        'MyKey.SetValue("margin_top", TempTop)
        'MyKey.Close()
    End Sub

    Sub pageSet(Portrait As Boolean)
        ' page orientation settins on default printer
        Const DEVICE_KEY = "HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Windows"
        Const DEVMODE_KEY = "HKEY_CURRENT_USER\Printers\DevModePerUser"
        Const DEFAULT_DEVMODE_KEY = "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Print\Printers\"
        Dim DevStr As String = Registry.GetValue(DEVICE_KEY, "Device", String.Empty)
        Dim PrinterName As String = DevStr.Substring(0, (DevStr.IndexOf(",")))
        Dim DevMode() As Byte = Registry.GetValue(DEVMODE_KEY, PrinterName, Nothing)
        If DevMode Is Nothing Then
            DevMode = Registry.GetValue(DEFAULT_DEVMODE_KEY & PrinterName.Replace("\"c, ","c), "Default DevMode", Nothing)
        End If
        If Portrait Then
            DevMode(76) = 1
        Else
            DevMode(76) = 2
        End If
        Registry.SetValue(DEVMODE_KEY, PrinterName, DevMode)
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Process.Start(PageLoc)
    End Sub

End Class