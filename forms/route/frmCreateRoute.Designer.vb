<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateRoute
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbRouteCity = New System.Windows.Forms.ComboBox()
        Me.chkRouteCity = New System.Windows.Forms.CheckBox()
        Me.lblTotalOrder = New System.Windows.Forms.Label()
        Me.dgOrder = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.chkDateRange = New System.Windows.Forms.CheckBox()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.btnLessOrder = New System.Windows.Forms.Button()
        Me.btnAddOrder = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbDriver = New System.Windows.Forms.ComboBox()
        Me.cmbTruck = New System.Windows.Forms.ComboBox()
        Me.lblOrderTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSaveRoute = New System.Windows.Forms.Button()
        Me.btnSaveAndPrintRoute = New System.Windows.Forms.Button()
        Me.txtRouteName = New System.Windows.Forms.TextBox()
        Me.dgRouteCities = New System.Windows.Forms.DataGridView()
        Me.OrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RouteCity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Route = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblCaseTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel1.SuspendLayout()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgRouteCities, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbRouteCity)
        Me.Panel1.Controls.Add(Me.chkRouteCity)
        Me.Panel1.Controls.Add(Me.lblTotalOrder)
        Me.Panel1.Controls.Add(Me.dgOrder)
        Me.Panel1.Controls.Add(Me.btnUp)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.chkDateRange)
        Me.Panel1.Controls.Add(Me.chkStatus)
        Me.Panel1.Controls.Add(Me.btnLessOrder)
        Me.Panel1.Controls.Add(Me.btnAddOrder)
        Me.Panel1.Controls.Add(Me.btnDown)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 459)
        Me.Panel1.TabIndex = 0
        '
        'cmbRouteCity
        '
        Me.cmbRouteCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRouteCity.Enabled = False
        Me.cmbRouteCity.FormattingEnabled = True
        Me.cmbRouteCity.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled", "No Order", "On Hold"})
        Me.cmbRouteCity.Location = New System.Drawing.Point(101, 34)
        Me.cmbRouteCity.Name = "cmbRouteCity"
        Me.cmbRouteCity.Size = New System.Drawing.Size(171, 24)
        Me.cmbRouteCity.TabIndex = 35
        '
        'chkRouteCity
        '
        Me.chkRouteCity.AutoSize = True
        Me.chkRouteCity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRouteCity.Location = New System.Drawing.Point(2, 36)
        Me.chkRouteCity.Name = "chkRouteCity"
        Me.chkRouteCity.Size = New System.Drawing.Size(92, 21)
        Me.chkRouteCity.TabIndex = 34
        Me.chkRouteCity.Text = "Route City"
        Me.chkRouteCity.UseVisualStyleBackColor = True
        '
        'lblTotalOrder
        '
        Me.lblTotalOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalOrder.AutoSize = True
        Me.lblTotalOrder.Location = New System.Drawing.Point(10, 439)
        Me.lblTotalOrder.Name = "lblTotalOrder"
        Me.lblTotalOrder.Size = New System.Drawing.Size(118, 17)
        Me.lblTotalOrder.TabIndex = 20
        Me.lblTotalOrder.Text = "Total : 0 Order(s)"
        '
        'dgOrder
        '
        Me.dgOrder.AllowUserToAddRows = False
        Me.dgOrder.AllowUserToDeleteRows = False
        Me.dgOrder.AllowUserToResizeColumns = False
        Me.dgOrder.AllowUserToResizeRows = False
        Me.dgOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgOrder.BackgroundColor = System.Drawing.Color.White
        Me.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4})
        Me.dgOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgOrder.Location = New System.Drawing.Point(13, 65)
        Me.dgOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.dgOrder.MultiSelect = False
        Me.dgOrder.Name = "dgOrder"
        Me.dgOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOrder.Size = New System.Drawing.Size(628, 370)
        Me.dgOrder.TabIndex = 9
        '
        'Column4
        '
        Me.Column4.HeaderText = "Map"
        Me.Column4.Name = "Column4"
        Me.Column4.Text = "Map"
        Me.Column4.UseColumnTextForButtonValue = True
        Me.Column4.Width = 41
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp.Location = New System.Drawing.Point(636, 308)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(44, 60)
        Me.btnUp.TabIndex = 18
        Me.btnUp.Text = "↑"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(566, 32)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(103, 30)
        Me.btnRefresh.TabIndex = 16
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled", "No Order", "On Hold", "Picked"})
        Me.cmbStatus.Location = New System.Drawing.Point(101, 7)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(171, 24)
        Me.cmbStatus.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(515, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "To"
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MM/dd/yyyy"
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(545, 8)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(115, 23)
        Me.dtpTo.TabIndex = 13
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MM/dd/yyyy"
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(394, 8)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(115, 23)
        Me.dtpFrom.TabIndex = 12
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDateRange.Location = New System.Drawing.Point(281, 10)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(107, 21)
        Me.chkDateRange.TabIndex = 10
        Me.chkDateRange.Text = "Date Range "
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkStatus.Location = New System.Drawing.Point(26, 9)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(67, 21)
        Me.chkStatus.TabIndex = 11
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'btnLessOrder
        '
        Me.btnLessOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLessOrder.Location = New System.Drawing.Point(640, 130)
        Me.btnLessOrder.Name = "btnLessOrder"
        Me.btnLessOrder.Size = New System.Drawing.Size(32, 62)
        Me.btnLessOrder.TabIndex = 17
        Me.btnLessOrder.Text = "<<"
        Me.btnLessOrder.UseVisualStyleBackColor = True
        '
        'btnAddOrder
        '
        Me.btnAddOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddOrder.Location = New System.Drawing.Point(640, 64)
        Me.btnAddOrder.Name = "btnAddOrder"
        Me.btnAddOrder.Size = New System.Drawing.Size(32, 60)
        Me.btnAddOrder.TabIndex = 17
        Me.btnAddOrder.Text = ">>"
        Me.btnAddOrder.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown.Location = New System.Drawing.Point(636, 374)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(44, 62)
        Me.btnDown.TabIndex = 19
        Me.btnDown.Text = "↓"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmbDriver)
        Me.Panel2.Controls.Add(Me.cmbTruck)
        Me.Panel2.Controls.Add(Me.lblOrderTotal)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnSaveRoute)
        Me.Panel2.Controls.Add(Me.btnSaveAndPrintRoute)
        Me.Panel2.Controls.Add(Me.txtRouteName)
        Me.Panel2.Controls.Add(Me.dgRouteCities)
        Me.Panel2.Controls.Add(Me.lblCaseTotal)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(675, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(335, 459)
        Me.Panel2.TabIndex = 1
        '
        'cmbDriver
        '
        Me.cmbDriver.FormattingEnabled = True
        Me.cmbDriver.Location = New System.Drawing.Point(155, 55)
        Me.cmbDriver.Name = "cmbDriver"
        Me.cmbDriver.Size = New System.Drawing.Size(167, 24)
        Me.cmbDriver.TabIndex = 16
        '
        'cmbTruck
        '
        Me.cmbTruck.FormattingEnabled = True
        Me.cmbTruck.Location = New System.Drawing.Point(7, 55)
        Me.cmbTruck.Name = "cmbTruck"
        Me.cmbTruck.Size = New System.Drawing.Size(145, 24)
        Me.cmbTruck.TabIndex = 15
        '
        'lblOrderTotal
        '
        Me.lblOrderTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOrderTotal.AutoSize = True
        Me.lblOrderTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderTotal.Location = New System.Drawing.Point(6, 390)
        Me.lblOrderTotal.Name = "lblOrderTotal"
        Me.lblOrderTotal.Size = New System.Drawing.Size(72, 17)
        Me.lblOrderTotal.TabIndex = 14
        Me.lblOrderTotal.Text = "0 Orders"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Enter Route Name"
        '
        'btnSaveRoute
        '
        Me.btnSaveRoute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveRoute.Location = New System.Drawing.Point(126, 418)
        Me.btnSaveRoute.Name = "btnSaveRoute"
        Me.btnSaveRoute.Size = New System.Drawing.Size(93, 37)
        Me.btnSaveRoute.TabIndex = 12
        Me.btnSaveRoute.Text = "Save Route"
        Me.btnSaveRoute.UseVisualStyleBackColor = True
        '
        'btnSaveAndPrintRoute
        '
        Me.btnSaveAndPrintRoute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAndPrintRoute.Location = New System.Drawing.Point(225, 418)
        Me.btnSaveAndPrintRoute.Name = "btnSaveAndPrintRoute"
        Me.btnSaveAndPrintRoute.Size = New System.Drawing.Size(97, 37)
        Me.btnSaveAndPrintRoute.TabIndex = 12
        Me.btnSaveAndPrintRoute.Text = "Save && Print"
        Me.btnSaveAndPrintRoute.UseVisualStyleBackColor = True
        '
        'txtRouteName
        '
        Me.txtRouteName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRouteName.Location = New System.Drawing.Point(6, 18)
        Me.txtRouteName.Name = "txtRouteName"
        Me.txtRouteName.Size = New System.Drawing.Size(316, 23)
        Me.txtRouteName.TabIndex = 11
        '
        'dgRouteCities
        '
        Me.dgRouteCities.AllowUserToAddRows = False
        Me.dgRouteCities.AllowUserToDeleteRows = False
        Me.dgRouteCities.AllowUserToResizeColumns = False
        Me.dgRouteCities.AllowUserToResizeRows = False
        Me.dgRouteCities.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRouteCities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgRouteCities.BackgroundColor = System.Drawing.Color.White
        Me.dgRouteCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRouteCities.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderID, Me.OrderNO, Me.RouteCity, Me.Route, Me.Column2, Me.Column3, Me.Column1})
        Me.dgRouteCities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgRouteCities.Location = New System.Drawing.Point(7, 80)
        Me.dgRouteCities.Margin = New System.Windows.Forms.Padding(4)
        Me.dgRouteCities.MultiSelect = False
        Me.dgRouteCities.Name = "dgRouteCities"
        Me.dgRouteCities.RowHeadersVisible = False
        Me.dgRouteCities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRouteCities.Size = New System.Drawing.Size(315, 306)
        Me.dgRouteCities.TabIndex = 10
        '
        'OrderID
        '
        Me.OrderID.HeaderText = "OrderID"
        Me.OrderID.Name = "OrderID"
        Me.OrderID.ReadOnly = True
        Me.OrderID.Visible = False
        Me.OrderID.Width = 64
        '
        'OrderNO
        '
        Me.OrderNO.HeaderText = "Order NO"
        Me.OrderNO.Name = "OrderNO"
        Me.OrderNO.ReadOnly = True
        Me.OrderNO.Width = 87
        '
        'RouteCity
        '
        Me.RouteCity.HeaderText = "Route City"
        Me.RouteCity.Name = "RouteCity"
        Me.RouteCity.ReadOnly = True
        Me.RouteCity.Visible = False
        Me.RouteCity.Width = 98
        '
        'Route
        '
        Me.Route.HeaderText = "Route"
        Me.Route.Name = "Route"
        Me.Route.ReadOnly = True
        Me.Route.Visible = False
        Me.Route.Width = 71
        '
        'Column2
        '
        Me.Column2.HeaderText = "Customer Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Column2.Width = 123
        '
        'Column3
        '
        Me.Column3.HeaderText = "Case(s)"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Column3.Width = 82
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'lblCaseTotal
        '
        Me.lblCaseTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaseTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaseTotal.Location = New System.Drawing.Point(111, 385)
        Me.lblCaseTotal.Name = "lblCaseTotal"
        Me.lblCaseTotal.Size = New System.Drawing.Size(217, 34)
        Me.lblCaseTotal.TabIndex = 14
        Me.lblCaseTotal.Text = "0 Cases"
        Me.lblCaseTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Truck"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Driver"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(670, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(5, 459)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'frmCreateRoute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 459)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCreateRoute"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Route"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgRouteCities, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents btnLessOrder As System.Windows.Forms.Button
    Friend WithEvents btnAddOrder As System.Windows.Forms.Button
    Friend WithEvents dgRouteCities As System.Windows.Forms.DataGridView
    Friend WithEvents btnSaveRoute As System.Windows.Forms.Button
    Friend WithEvents btnSaveAndPrintRoute As System.Windows.Forms.Button
    Friend WithEvents txtRouteName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents lblCaseTotal As System.Windows.Forms.Label
    Friend WithEvents lblOrderTotal As System.Windows.Forms.Label
    Friend WithEvents cmbDriver As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTruck As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalOrder As System.Windows.Forms.Label
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents cmbRouteCity As ComboBox
    Friend WithEvents chkRouteCity As CheckBox
    Friend WithEvents OrderID As DataGridViewTextBoxColumn
    Friend WithEvents OrderNO As DataGridViewTextBoxColumn
    Friend WithEvents RouteCity As DataGridViewTextBoxColumn
    Friend WithEvents Route As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
