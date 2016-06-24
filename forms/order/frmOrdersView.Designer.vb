<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdersView
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
        Me.dgOrder = New System.Windows.Forms.DataGridView()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.chkDateRange = New System.Windows.Forms.CheckBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEditOrder = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.chkCustomer = New System.Windows.Forms.CheckBox()
        Me.btnPrintBol = New System.Windows.Forms.Button()
        Me.btnUnlinkBOL = New System.Windows.Forms.Button()
        Me.btnLinkBol = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrintLabel = New System.Windows.Forms.Button()
        Me.btnCancelOrder = New System.Windows.Forms.Button()
        Me.btnFulFill = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblTotalOrder = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnPrintSalesOrder = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnViewRoute = New System.Windows.Forms.Button()
        Me.cmbRouteCity = New System.Windows.Forms.ComboBox()
        Me.chkRouteCity = New System.Windows.Forms.CheckBox()
        Me.CntlOrderView1 = New WengLee_Application.cntlOrderView()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgOrder
        '
        Me.dgOrder.AllowUserToAddRows = False
        Me.dgOrder.AllowUserToDeleteRows = False
        Me.dgOrder.AllowUserToOrderColumns = True
        Me.dgOrder.AllowUserToResizeRows = False
        Me.dgOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOrder.BackgroundColor = System.Drawing.Color.White
        Me.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgOrder.Location = New System.Drawing.Point(3, 54)
        Me.dgOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.dgOrder.MultiSelect = False
        Me.dgOrder.Name = "dgOrder"
        Me.dgOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOrder.Size = New System.Drawing.Size(784, 399)
        Me.dgOrder.TabIndex = 0
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkStatus.Location = New System.Drawing.Point(18, 6)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(67, 21)
        Me.chkStatus.TabIndex = 3
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDateRange.Location = New System.Drawing.Point(207, 5)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(107, 21)
        Me.chkDateRange.TabIndex = 3
        Me.chkDateRange.Text = "Date Range "
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MM/dd/yyyy"
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(315, 3)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(100, 23)
        Me.dtpFrom.TabIndex = 4
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MM/dd/yyyy"
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(454, 3)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(115, 23)
        Me.dtpTo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(424, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "To"
        '
        'btnEditOrder
        '
        Me.btnEditOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditOrder.Location = New System.Drawing.Point(691, 2)
        Me.btnEditOrder.Name = "btnEditOrder"
        Me.btnEditOrder.Size = New System.Drawing.Size(87, 30)
        Me.btnEditOrder.TabIndex = 6
        Me.btnEditOrder.Text = "Edit"
        Me.btnEditOrder.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled", "No Order", "On Hold"})
        Me.cmbStatus.Location = New System.Drawing.Point(87, 3)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(110, 24)
        Me.cmbStatus.TabIndex = 7
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(624, 1)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(161, 26)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbRouteCity)
        Me.Panel1.Controls.Add(Me.chkRouteCity)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmbCustomer)
        Me.Panel1.Controls.Add(Me.chkCustomer)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.chkStatus)
        Me.Panel1.Controls.Add(Me.dgOrder)
        Me.Panel1.Controls.Add(Me.chkDateRange)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 453)
        Me.Panel1.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(624, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 26)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Future Orders"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomer.Enabled = False
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(87, 29)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(250, 24)
        Me.cmbCustomer.TabIndex = 28
        '
        'chkCustomer
        '
        Me.chkCustomer.AutoSize = True
        Me.chkCustomer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCustomer.Location = New System.Drawing.Point(-1, 31)
        Me.chkCustomer.Name = "chkCustomer"
        Me.chkCustomer.Size = New System.Drawing.Size(87, 21)
        Me.chkCustomer.TabIndex = 27
        Me.chkCustomer.Text = "Customer"
        Me.chkCustomer.UseVisualStyleBackColor = True
        '
        'btnPrintBol
        '
        Me.btnPrintBol.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintBol.Location = New System.Drawing.Point(1061, 32)
        Me.btnPrintBol.Name = "btnPrintBol"
        Me.btnPrintBol.Size = New System.Drawing.Size(101, 30)
        Me.btnPrintBol.TabIndex = 32
        Me.btnPrintBol.Text = "Print BOL"
        Me.btnPrintBol.UseVisualStyleBackColor = True
        '
        'btnUnlinkBOL
        '
        Me.btnUnlinkBOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnlinkBOL.Location = New System.Drawing.Point(1161, 32)
        Me.btnUnlinkBOL.Name = "btnUnlinkBOL"
        Me.btnUnlinkBOL.Size = New System.Drawing.Size(128, 30)
        Me.btnUnlinkBOL.TabIndex = 31
        Me.btnUnlinkBOL.Text = "UnLink BOL"
        Me.btnUnlinkBOL.UseVisualStyleBackColor = True
        '
        'btnLinkBol
        '
        Me.btnLinkBol.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLinkBol.Location = New System.Drawing.Point(940, 32)
        Me.btnLinkBol.Name = "btnLinkBol"
        Me.btnLinkBol.Size = New System.Drawing.Size(122, 30)
        Me.btnLinkBol.TabIndex = 30
        Me.btnLinkBol.Text = "Link BOL"
        Me.btnLinkBol.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(514, 32)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(132, 30)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrintLabel
        '
        Me.btnPrintLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintLabel.Location = New System.Drawing.Point(691, 32)
        Me.btnPrintLabel.Name = "btnPrintLabel"
        Me.btnPrintLabel.Size = New System.Drawing.Size(130, 30)
        Me.btnPrintLabel.TabIndex = 25
        Me.btnPrintLabel.Text = "Print Label"
        Me.btnPrintLabel.UseVisualStyleBackColor = True
        '
        'btnCancelOrder
        '
        Me.btnCancelOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelOrder.Location = New System.Drawing.Point(1161, 2)
        Me.btnCancelOrder.Name = "btnCancelOrder"
        Me.btnCancelOrder.Size = New System.Drawing.Size(128, 30)
        Me.btnCancelOrder.TabIndex = 24
        Me.btnCancelOrder.Text = "Cancel"
        Me.btnCancelOrder.UseVisualStyleBackColor = True
        '
        'btnFulFill
        '
        Me.btnFulFill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFulFill.Location = New System.Drawing.Point(778, 2)
        Me.btnFulFill.Name = "btnFulFill"
        Me.btnFulFill.Size = New System.Drawing.Size(103, 30)
        Me.btnFulFill.TabIndex = 23
        Me.btnFulFill.Text = "Fulfill"
        Me.btnFulFill.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(1061, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(101, 30)
        Me.btnDelete.TabIndex = 22
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblTotalOrder
        '
        Me.lblTotalOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalOrder.AutoSize = True
        Me.lblTotalOrder.Location = New System.Drawing.Point(9, 8)
        Me.lblTotalOrder.Name = "lblTotalOrder"
        Me.lblTotalOrder.Size = New System.Drawing.Size(118, 17)
        Me.lblTotalOrder.TabIndex = 21
        Me.lblTotalOrder.Text = "Total : 0 Order(s)"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Gainsboro
        Me.Splitter1.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.WengLee_Application.My.MySettings.Default, "ReviewOrderSpliter1", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = Global.WengLee_Application.My.MySettings.Default.ReviewOrderSpliter1
        Me.Splitter1.MinimumSize = New System.Drawing.Size(3, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(10, 453)
        Me.Splitter1.TabIndex = 11
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CntlOrderView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(798, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(494, 453)
        Me.Panel2.TabIndex = 12
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Splitter1)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1292, 453)
        Me.Panel3.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnExport)
        Me.Panel4.Controls.Add(Me.btnPrintSalesOrder)
        Me.Panel4.Controls.Add(Me.btnPrint)
        Me.Panel4.Controls.Add(Me.btnViewRoute)
        Me.Panel4.Controls.Add(Me.btnPrintBol)
        Me.Panel4.Controls.Add(Me.lblTotalOrder)
        Me.Panel4.Controls.Add(Me.btnUnlinkBOL)
        Me.Panel4.Controls.Add(Me.btnEditOrder)
        Me.Panel4.Controls.Add(Me.btnLinkBol)
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnFulFill)
        Me.Panel4.Controls.Add(Me.btnClose)
        Me.Panel4.Controls.Add(Me.btnCancelOrder)
        Me.Panel4.Controls.Add(Me.btnPrintLabel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 453)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1292, 64)
        Me.Panel4.TabIndex = 13
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(395, 33)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(117, 29)
        Me.btnExport.TabIndex = 36
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnPrintSalesOrder
        '
        Me.btnPrintSalesOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintSalesOrder.Location = New System.Drawing.Point(514, 2)
        Me.btnPrintSalesOrder.Name = "btnPrintSalesOrder"
        Me.btnPrintSalesOrder.Size = New System.Drawing.Size(132, 30)
        Me.btnPrintSalesOrder.TabIndex = 35
        Me.btnPrintSalesOrder.Text = "Sales Order"
        Me.btnPrintSalesOrder.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(395, 2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(117, 30)
        Me.btnPrint.TabIndex = 34
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnViewRoute
        '
        Me.btnViewRoute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewRoute.Location = New System.Drawing.Point(820, 32)
        Me.btnViewRoute.Name = "btnViewRoute"
        Me.btnViewRoute.Size = New System.Drawing.Size(121, 30)
        Me.btnViewRoute.TabIndex = 33
        Me.btnViewRoute.Text = "View Route"
        Me.btnViewRoute.UseVisualStyleBackColor = True
        '
        'cmbRouteCity
        '
        Me.cmbRouteCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRouteCity.Enabled = False
        Me.cmbRouteCity.FormattingEnabled = True
        Me.cmbRouteCity.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled", "No Order", "On Hold"})
        Me.cmbRouteCity.Location = New System.Drawing.Point(439, 28)
        Me.cmbRouteCity.Name = "cmbRouteCity"
        Me.cmbRouteCity.Size = New System.Drawing.Size(130, 24)
        Me.cmbRouteCity.TabIndex = 31
        '
        'chkRouteCity
        '
        Me.chkRouteCity.AutoSize = True
        Me.chkRouteCity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRouteCity.Location = New System.Drawing.Point(343, 31)
        Me.chkRouteCity.Name = "chkRouteCity"
        Me.chkRouteCity.Size = New System.Drawing.Size(92, 21)
        Me.chkRouteCity.TabIndex = 30
        Me.chkRouteCity.Text = "Route City"
        Me.chkRouteCity.UseVisualStyleBackColor = True
        '
        'CntlOrderView1
        '
        Me.CntlOrderView1.BackColor = System.Drawing.Color.White
        Me.CntlOrderView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CntlOrderView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CntlOrderView1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CntlOrderView1.Location = New System.Drawing.Point(0, 0)
        Me.CntlOrderView1.Margin = New System.Windows.Forms.Padding(4)
        Me.CntlOrderView1.Name = "CntlOrderView1"
        Me.CntlOrderView1.Size = New System.Drawing.Size(494, 453)
        Me.CntlOrderView1.TabIndex = 0
        '
        'frmOrdersView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1292, 517)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmOrdersView"
        Me.Text = "View Order"
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEditOrder As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CntlOrderView1 As WengLee_Application.cntlOrderView
    Friend WithEvents lblTotalOrder As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnPrintLabel As System.Windows.Forms.Button
    Friend WithEvents btnCancelOrder As System.Windows.Forms.Button
    Friend WithEvents btnFulFill As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents btnUnlinkBOL As System.Windows.Forms.Button
    Friend WithEvents btnLinkBol As System.Windows.Forms.Button
    Friend WithEvents btnPrintBol As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnViewRoute As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPrintSalesOrder As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cmbRouteCity As ComboBox
    Friend WithEvents chkRouteCity As CheckBox
End Class
