Public Class frmMainAndAlsoStartupForm

    Dim objUserRules As New cls_tblUserRules

    Sub ShowLoginForm()
        Dim frm As New frmLogin
        Me.Hide()
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Show()
            UserDetailsToolStripMenuItem.Visible = objUserRules.CheckRule(cls_tblUserRules.Rules.UserDetails, UserId)
            FarmDetailsToolStripMenuItem.Visible = objUserRules.CheckRule(cls_tblUserRules.Rules.UserDetails, UserId)
        Else
            End
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DBidyutuserfolderDesktopToolStripMenuItem.Text = MyLocalSettings.FileLocation
        Text = "Wenglee POS Ver " & My.Application.Info.Version.ToString
    End Sub

    Private Sub ShortcutMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShortcutMenuToolStripMenuItem.Click
        pnlShortcut.Visible = ShortcutMenuToolStripMenuItem.Checked
    End Sub

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not UserLoggedIn Then
            ShowLoginForm()
        End If
        ToolStripStatusLabel1.Text = "Logged In : " & UserName & " - " & UserFullName & " at " & UserLoginTime.ToString
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Logout()
        ShowLoginForm()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click, btnCustomer.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Customers, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmCustomersView)
    End Sub

    Sub ShowChild(ByVal frm As Form)
        If OpenWindowAsChildWindowToolStripMenuItem.Checked Then
            frm.MdiParent = Me
            frm.Location = New Point(0, 0)
            frm.StartPosition = FormStartPosition.Manual
            frm.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Else
            frm.MdiParent = Nothing
            frm.StartPosition = FormStartPosition.CenterScreen
            If FullScreenToolStripMenuItem.Checked Then
                frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                frm.WindowState = FormWindowState.Maximized
            End If
        End If
        frm.Show()
        frm.Activate()
        frm.Focus()
    End Sub

    Private Sub btnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrder.Click, PostNewOrderToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.PostOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmOrderAdd)
    End Sub

    Private Sub btnReviewOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReviewOrder.Click, ReviewOrdersToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.ReviewOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmOrdersView)
    End Sub

    Private Sub btnCancelOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelOrder.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.CancelOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmOrdersCancelList)
    End Sub

    Private Sub btnProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Products, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmProductsView)
    End Sub

    Private Sub FarmDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FarmDetailsToolStripMenuItem.Click
        ShowChild(frmFarmDetails)
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        frmPreferences.ShowDialog()
    End Sub

    Private Sub btnFullFillOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFullFillOrder.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.FulFillOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmOrdersFulFillList)
    End Sub

    Private Sub btnAddRoutes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRoutes.Click, ViewRouteToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.ViewRoute, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmViewRoute)
    End Sub

    Private Sub btnPickQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickQty.Click, CaseTotalsToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.TotalCases, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmPickedQuantities)
    End Sub

    Private Sub UserDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserDetailsToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.UserDetails, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmUser)
    End Sub

    Private Sub PrintLableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintLableToolStripMenuItem.Click
        '  ShowChild(frmPrintLabel)
    End Sub

    Private Sub ExitToWindowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToWindowsToolStripMenuItem.Click
        End
    End Sub

    Private Sub FullScreenToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.CheckedChanged
        If FullScreenToolStripMenuItem.Checked Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Normal
            Me.WindowState = FormWindowState.Maximized
            FullScreenToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption
            StatusStrip1.Visible = False
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Maximized
            FullScreenToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
            StatusStrip1.Visible = True
        End If
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub TruckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TruckToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Truck, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmTruck)
    End Sub

    Private Sub DriverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DriverToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Driver, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmDriver)
    End Sub

    Private Sub BOLAddressesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BOLAddressesToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.BolAddress, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmBOLAddresses)
    End Sub

    Private Sub VendorsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VendorsToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Vendors, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmVendorView)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnReceiveStock.Click, ReceiveStockToolStripMenuItem.Click
        'MsgBox("Pending. Not Complete", MsgBoxStyle.Information, "Info")
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.ReceiveStock, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmPurchaseView)
    End Sub

    Private Sub PriceListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PriceListToolStripMenuItem.Click, btnPriceList.Click, PricesToolStripMenuItem1.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Prices, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmPriceList)
    End Sub

    Public Sub New()
        'This call is required by the designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        Location = Screen.FromPoint(MousePosition).WorkingArea.Location
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles OrderTemplateToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.OrderTemplate, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmTemplateView)
    End Sub

    Private Sub ScheduleOrderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ScheduleOrderToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.CreateSchedule, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmScheduledOrdersView)
    End Sub

    Private Sub txtScheduledOrders_Click(sender As System.Object, e As System.EventArgs) Handles txtScheduledOrders.Click, PostScheduleToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.PostSchedule, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmTodaysScheduledOrdersView)
    End Sub

    Private Sub EmailSetupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmailSetupToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.SalesOrder, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        frmSetupEmail.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnCalender.Click, CalenderToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Calender, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmCalender2)
    End Sub

    Private Sub tmrVersionChecker_Tick(sender As System.Object, e As System.EventArgs) Handles tmrVersionChecker.Tick
        If Not MyLocalSettings.DisableAutoUpdate Then
            If CheckVersion2() Then
                If MsgBox("New Version of this app is found online." & vbNewLine & "Press YES to update it now." & vbNewLine & "Press NO to Schedule the update after 2 Mins. In the meantime please save all your work.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Version Alert") = MsgBoxResult.Yes Then
                    StartUpdater()
                Else
                    tmrStartUpdater.Start()
                End If
            End If
        End If
    End Sub

    Private Sub tmrStartUpdater_Tick(sender As System.Object, e As System.EventArgs) Handles tmrStartUpdater.Tick
        tmrStartUpdater.Stop()
        MsgBox("Update will start now", MsgBoxStyle.Information, "Update Alert")
        StartUpdater()
    End Sub





    'Sub ShowInvoiceNotification()
    '    Dim dtListofInvoices As New DataTable
    '    Dim objConn As New clsConnection
    '    Dim con As SqlConnection = objConn.connectTransfer
    '    Dim da As New SqlDataAdapter("Select OrderNumber, InvoiceNumber , InvoiceDate , CustomerName , Contact , Address1 as [Address], CState as [State], Zip , Email , TotalAmount , ISNULL (LastPrintedBy ,'NOT PRINTED') as [LastPrintedBy] from tblInvoices a left outer join tblNotification b on a.InvoiceNumber = b.InvoiceNo and a.CustomerId= b.CustomerId left outer join tblCustomers c on a.CustomerId= c.CustomerId  where b.Pk_id is null order by InvoiceDate Desc", con)
    '    Try
    '        da.Fill(dtListofInvoices)
    '    Catch ex As Exception
    '    End Try
    'End Sub


    Private Sub btnInvoices_Click(sender As System.Object, e As System.EventArgs) Handles btnInvoices.Click, InvoicesToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Invoices, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmInvoices)
    End Sub


    Private Sub LatestOrderCustomerWiseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LatestOrderCustomerWiseToolStripMenuItem.Click
        ShowChild(frmCustomersLastOrder)
    End Sub

    Private Sub OrderDetailByCustomerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OrderDetailByCustomerToolStripMenuItem.Click

    End Sub


    Private Sub AutomaticaUpdateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AutomaticaUpdateToolStripMenuItem.Click
        Dim Sett As mdlLocalSettings.LocalSetting = MyLocalSettings
        Sett.DisableAutoUpdate = Not AutomaticaUpdateToolStripMenuItem.Checked
        MyLocalSettings = Sett
        SaveLocalSettings()
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click

    End Sub

    Private Sub PricesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PricesToolStripMenuItem.Click, btnInventory.Click, InventoryToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Inventory, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmInventoryList)
    End Sub



    Private Sub MapTestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MapTestToolStripMenuItem.Click
        frmViewMap.Show()
        'frmViewMap.LoadMap("&origin=46.414382,10.013988&destination=-33.8569,151.2152&avoid=tolls|highways")
        'frmViewMap.LoadMap("&origin=M.B.Tilla,Agartala&destination=Amtali,Tripura&waypoints=Battala,Agartala|rupasi+hall,Agartala&avoid=tolls|highways")
        'frmViewMap.LoadMap("&origin=M.B.Tilla,Agartala&destination=rupasi+hall,Agartala&waypoints=Battala,Agartala|Amtali,Tripura&avoid=tolls|highways")
        frmViewMap.LoadMap("&origin=140+W+Valley.,107,San+Gabriel,CA,91776&destination=120+E.+Valley+Blvd.,San+Gabriel,CA,91776&waypoints=500+N+Atlantic+Blvd.,200,Monterey+Park,CA,91754|500+W+Valley+Blvd,Alhambra,CA,91803&avoid=tolls|highways", "Direction")
    End Sub

    Private Sub DBidyutuserfolderDesktopToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DBidyutuserfolderDesktopToolStripMenuItem.Click
        Dim fi As New FolderBrowserDialog
        fi.SelectedPath = sender.text
        If fi.ShowDialog = Windows.Forms.DialogResult.OK Then
            MyLocalSettings.FileLocation = fi.SelectedPath
            SaveLocalSettings()
        End If
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        ShowChild(frmImportEmployee)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click, TasksToolStripMenuItem.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Tasks, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ' frmTaskList.Owner = Me
        frmTaskList.Show()
        frmTaskList.Activate()
        frmTaskList.Focus()
    End Sub

    Private Sub OrdersAfterRouteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OrdersAfterRouteToolStripMenuItem.Click
        frmOrdersafterRoute.ShowDialog()
    End Sub

    Private Sub btnFz_Click(sender As System.Object, e As System.EventArgs) Handles btnFz.Click
        If Not objUserRules.CheckRule(cls_tblUserRules.Rules.Inventory, UserId) Then
            MsgBox("You are not authorised to perform this task", MsgBoxStyle.Information, "info")
            Exit Sub
        End If
        ShowChild(frmInventoryListFz)
    End Sub
End Class
