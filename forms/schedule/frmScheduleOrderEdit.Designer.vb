<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScheduleOrderEdit
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.btnPostOrder = New System.Windows.Forms.Button()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.dgItemList = New System.Windows.Forms.DataGridView()
        Me.PID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Fresh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frozen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreateCustomer = New System.Windows.Forms.Button()
        Me.btnCreateProduct = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRouteCity = New System.Windows.Forms.TextBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.btnOrderHistory = New System.Windows.Forms.Button()
        Me.btnLinkAddress = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalCases = New System.Windows.Forms.Label()
        Me.lblLastOrder = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnNoOrder = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnShowBOLAddress = New System.Windows.Forms.Button()
        Me.txtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.txtRepeat = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdbMonthly = New System.Windows.Forms.RadioButton()
        Me.rdbWeekly = New System.Windows.Forms.RadioButton()
        Me.rdbDaily = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkSaturday = New System.Windows.Forms.CheckBox()
        Me.chkFriday = New System.Windows.Forms.CheckBox()
        Me.chkThursday = New System.Windows.Forms.CheckBox()
        Me.chkWednesDay = New System.Windows.Forms.CheckBox()
        Me.chkTuesday = New System.Windows.Forms.CheckBox()
        Me.chkMonday = New System.Windows.Forms.CheckBox()
        Me.chkSunday = New System.Windows.Forms.CheckBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(114, 16)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(121, 23)
        Me.txtOrderNo.TabIndex = 0
        Me.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPostOrder
        '
        Me.btnPostOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPostOrder.Location = New System.Drawing.Point(534, 513)
        Me.btnPostOrder.Name = "btnPostOrder"
        Me.btnPostOrder.Size = New System.Drawing.Size(231, 43)
        Me.btnPostOrder.TabIndex = 9
        Me.btnPostOrder.Text = "Update Schedule Order"
        Me.btnPostOrder.UseVisualStyleBackColor = True
        '
        'cmbCustomer
        '
        Me.cmbCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(114, 45)
        Me.cmbCustomer.MaximumSize = New System.Drawing.Size(370, 0)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(361, 24)
        Me.cmbCustomer.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(492, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Date"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(532, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Status"
        Me.Label4.Visible = False
        '
        'cmbStatus
        '
        Me.cmbStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled"})
        Me.cmbStatus.Location = New System.Drawing.Point(576, 312)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(189, 24)
        Me.cmbStatus.TabIndex = 2
        Me.cmbStatus.Visible = False
        '
        'txtOrderDate
        '
        Me.txtOrderDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderDate.CustomFormat = "MM/dd/yyyy"
        Me.txtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtOrderDate.Location = New System.Drawing.Point(575, 14)
        Me.txtOrderDate.Name = "txtOrderDate"
        Me.txtOrderDate.Size = New System.Drawing.Size(189, 23)
        Me.txtOrderDate.TabIndex = 1
        '
        'dgItemList
        '
        Me.dgItemList.AllowDrop = True
        Me.dgItemList.AllowUserToAddRows = False
        Me.dgItemList.AllowUserToDeleteRows = False
        Me.dgItemList.AllowUserToResizeColumns = False
        Me.dgItemList.AllowUserToResizeRows = False
        Me.dgItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgItemList.BackgroundColor = System.Drawing.Color.White
        Me.dgItemList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PID, Me.ITEM, Me.QTY, Me.Type, Me.Column1, Me.Column2, Me.Fresh, Me.Frozen, Me.ColumnItemId})
        Me.dgItemList.Location = New System.Drawing.Point(6, 13)
        Me.dgItemList.MultiSelect = False
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.RowHeadersVisible = False
        Me.dgItemList.RowTemplate.Height = 30
        Me.dgItemList.Size = New System.Drawing.Size(452, 224)
        Me.dgItemList.TabIndex = 11
        '
        'PID
        '
        Me.PID.HeaderText = "PID"
        Me.PID.Name = "PID"
        Me.PID.Visible = False
        '
        'ITEM
        '
        Me.ITEM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ITEM.HeaderText = "Item"
        Me.ITEM.Name = "ITEM"
        Me.ITEM.ReadOnly = True
        Me.ITEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'QTY
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QTY.DefaultCellStyle = DataGridViewCellStyle1
        Me.QTY.HeaderText = "Case Qty"
        Me.QTY.Name = "QTY"
        Me.QTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.QTY.Visible = False
        Me.QTY.Width = 110
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Type.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Category"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Delete"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.Text = "Delete"
        Me.Column2.ToolTipText = "Delete"
        Me.Column2.UseColumnTextForButtonValue = True
        Me.Column2.Width = 60
        '
        'Fresh
        '
        Me.Fresh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fresh.DefaultCellStyle = DataGridViewCellStyle2
        Me.Fresh.HeaderText = "Fresh"
        Me.Fresh.Name = "Fresh"
        '
        'Frozen
        '
        Me.Frozen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Frozen.DefaultCellStyle = DataGridViewCellStyle3
        Me.Frozen.HeaderText = "Frozen"
        Me.Frozen.Name = "Frozen"
        '
        'ColumnItemId
        '
        Me.ColumnItemId.HeaderText = "ItemId"
        Me.ColumnItemId.Name = "ColumnItemId"
        Me.ColumnItemId.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(534, 562)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(231, 43)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreateCustomer
        '
        Me.btnCreateCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateCustomer.Location = New System.Drawing.Point(535, 71)
        Me.btnCreateCustomer.Name = "btnCreateCustomer"
        Me.btnCreateCustomer.Size = New System.Drawing.Size(231, 38)
        Me.btnCreateCustomer.TabIndex = 4
        Me.btnCreateCustomer.Text = "Create Customer"
        Me.btnCreateCustomer.UseVisualStyleBackColor = True
        '
        'btnCreateProduct
        '
        Me.btnCreateProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateProduct.Location = New System.Drawing.Point(535, 115)
        Me.btnCreateProduct.Name = "btnCreateProduct"
        Me.btnCreateProduct.Size = New System.Drawing.Size(231, 38)
        Me.btnCreateProduct.TabIndex = 6
        Me.btnCreateProduct.Text = "Create Product"
        Me.btnCreateProduct.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Route City"
        '
        'txtRouteCity
        '
        Me.txtRouteCity.Location = New System.Drawing.Point(114, 75)
        Me.txtRouteCity.Name = "txtRouteCity"
        Me.txtRouteCity.ReadOnly = True
        Me.txtRouteCity.Size = New System.Drawing.Size(121, 23)
        Me.txtRouteCity.TabIndex = 0
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddProduct.Location = New System.Drawing.Point(535, 159)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(231, 38)
        Me.btnAddProduct.TabIndex = 7
        Me.btnAddProduct.Text = "Add Product"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'btnOrderHistory
        '
        Me.btnOrderHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrderHistory.Location = New System.Drawing.Point(297, 604)
        Me.btnOrderHistory.Name = "btnOrderHistory"
        Me.btnOrderHistory.Size = New System.Drawing.Size(231, 38)
        Me.btnOrderHistory.TabIndex = 5
        Me.btnOrderHistory.Text = "Show Order History"
        Me.btnOrderHistory.UseVisualStyleBackColor = True
        Me.btnOrderHistory.Visible = False
        '
        'btnLinkAddress
        '
        Me.btnLinkAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLinkAddress.Location = New System.Drawing.Point(534, 461)
        Me.btnLinkAddress.Name = "btnLinkAddress"
        Me.btnLinkAddress.Size = New System.Drawing.Size(231, 38)
        Me.btnLinkAddress.TabIndex = 8
        Me.btnLinkAddress.Text = "Link BOL Drop-Off"
        Me.btnLinkAddress.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTotalCases)
        Me.GroupBox1.Controls.Add(Me.dgItemList)
        Me.GroupBox1.Location = New System.Drawing.Point(49, 228)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(466, 275)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(3, 245)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(280, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Total :"
        '
        'lblTotalCases
        '
        Me.lblTotalCases.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCases.Location = New System.Drawing.Point(282, 245)
        Me.lblTotalCases.Name = "lblTotalCases"
        Me.lblTotalCases.Size = New System.Drawing.Size(177, 24)
        Me.lblTotalCases.TabIndex = 12
        Me.lblTotalCases.Text = "Label7"
        Me.lblTotalCases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLastOrder
        '
        Me.lblLastOrder.AutoSize = True
        Me.lblLastOrder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLastOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastOrder.ForeColor = System.Drawing.Color.Red
        Me.lblLastOrder.Location = New System.Drawing.Point(39, 98)
        Me.lblLastOrder.Name = "lblLastOrder"
        Me.lblLastOrder.Size = New System.Drawing.Size(0, 17)
        Me.lblLastOrder.TabIndex = 13
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(49, 517)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComment.Size = New System.Drawing.Size(466, 88)
        Me.txtComment.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(48, 501)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Comments"
        '
        'btnNoOrder
        '
        Me.btnNoOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNoOrder.Location = New System.Drawing.Point(114, 599)
        Me.btnNoOrder.Name = "btnNoOrder"
        Me.btnNoOrder.Size = New System.Drawing.Size(231, 43)
        Me.btnNoOrder.TabIndex = 16
        Me.btnNoOrder.Text = "No Order"
        Me.btnNoOrder.UseVisualStyleBackColor = True
        Me.btnNoOrder.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(592, 339)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(187, 21)
        Me.CheckBox1.TabIndex = 17
        Me.CheckBox1.Text = "Save '0'(Zero) QTY Items"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'btnShowBOLAddress
        '
        Me.btnShowBOLAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowBOLAddress.Location = New System.Drawing.Point(534, 417)
        Me.btnShowBOLAddress.Name = "btnShowBOLAddress"
        Me.btnShowBOLAddress.Size = New System.Drawing.Size(231, 38)
        Me.btnShowBOLAddress.TabIndex = 18
        Me.btnShowBOLAddress.Text = "Show BOL Drop-Off"
        Me.btnShowBOLAddress.UseVisualStyleBackColor = True
        '
        'txtStartDate
        '
        Me.txtStartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartDate.CustomFormat = "MM/dd/yyyy"
        Me.txtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtStartDate.Location = New System.Drawing.Point(56, 3)
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.Size = New System.Drawing.Size(121, 23)
        Me.txtStartDate.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Start"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CheckBox2)
        Me.Panel1.Controls.Add(Me.txtRepeat)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtEndDate)
        Me.Panel1.Controls.Add(Me.txtStartDate)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(33, 101)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 127)
        Me.Panel1.TabIndex = 21
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(187, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(52, 21)
        Me.CheckBox2.TabIndex = 26
        Me.CheckBox2.Text = "End"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'txtRepeat
        '
        Me.txtRepeat.Location = New System.Drawing.Point(108, 101)
        Me.txtRepeat.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtRepeat.Name = "txtRepeat"
        Me.txtRepeat.Size = New System.Drawing.Size(56, 23)
        Me.txtRepeat.TabIndex = 25
        Me.txtRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(169, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 17)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Day"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 17)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Repeat every"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 17)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Schedule Type"
        '
        'txtEndDate
        '
        Me.txtEndDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEndDate.CustomFormat = "MM/dd/yyyy"
        Me.txtEndDate.Enabled = False
        Me.txtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtEndDate.Location = New System.Drawing.Point(242, 3)
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.Size = New System.Drawing.Size(121, 23)
        Me.txtEndDate.TabIndex = 20
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rdbMonthly)
        Me.Panel3.Controls.Add(Me.rdbWeekly)
        Me.Panel3.Controls.Add(Me.rdbDaily)
        Me.Panel3.Location = New System.Drawing.Point(117, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(230, 28)
        Me.Panel3.TabIndex = 24
        '
        'rdbMonthly
        '
        Me.rdbMonthly.AutoSize = True
        Me.rdbMonthly.Location = New System.Drawing.Point(145, 5)
        Me.rdbMonthly.Name = "rdbMonthly"
        Me.rdbMonthly.Size = New System.Drawing.Size(75, 21)
        Me.rdbMonthly.TabIndex = 21
        Me.rdbMonthly.Text = "Monthly"
        Me.rdbMonthly.UseVisualStyleBackColor = True
        '
        'rdbWeekly
        '
        Me.rdbWeekly.AutoSize = True
        Me.rdbWeekly.Location = New System.Drawing.Point(67, 5)
        Me.rdbWeekly.Name = "rdbWeekly"
        Me.rdbWeekly.Size = New System.Drawing.Size(72, 21)
        Me.rdbWeekly.TabIndex = 21
        Me.rdbWeekly.Text = "Weekly"
        Me.rdbWeekly.UseVisualStyleBackColor = True
        '
        'rdbDaily
        '
        Me.rdbDaily.AutoSize = True
        Me.rdbDaily.Checked = True
        Me.rdbDaily.Location = New System.Drawing.Point(4, 5)
        Me.rdbDaily.Name = "rdbDaily"
        Me.rdbDaily.Size = New System.Drawing.Size(57, 21)
        Me.rdbDaily.TabIndex = 21
        Me.rdbDaily.TabStop = True
        Me.rdbDaily.Text = "Daily"
        Me.rdbDaily.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkSaturday)
        Me.Panel2.Controls.Add(Me.chkFriday)
        Me.Panel2.Controls.Add(Me.chkThursday)
        Me.Panel2.Controls.Add(Me.chkWednesDay)
        Me.Panel2.Controls.Add(Me.chkTuesday)
        Me.Panel2.Controls.Add(Me.chkMonday)
        Me.Panel2.Controls.Add(Me.chkSunday)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(35, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 48)
        Me.Panel2.TabIndex = 23
        '
        'chkSaturday
        '
        Me.chkSaturday.AutoSize = True
        Me.chkSaturday.Checked = True
        Me.chkSaturday.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaturday.Location = New System.Drawing.Point(170, 23)
        Me.chkSaturday.Name = "chkSaturday"
        Me.chkSaturday.Size = New System.Drawing.Size(84, 21)
        Me.chkSaturday.TabIndex = 22
        Me.chkSaturday.Tag = "6"
        Me.chkSaturday.Text = "Saturday"
        Me.chkSaturday.UseVisualStyleBackColor = True
        '
        'chkFriday
        '
        Me.chkFriday.AutoSize = True
        Me.chkFriday.Checked = True
        Me.chkFriday.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFriday.Location = New System.Drawing.Point(106, 23)
        Me.chkFriday.Name = "chkFriday"
        Me.chkFriday.Size = New System.Drawing.Size(66, 21)
        Me.chkFriday.TabIndex = 22
        Me.chkFriday.Tag = "5"
        Me.chkFriday.Text = "Friday"
        Me.chkFriday.UseVisualStyleBackColor = True
        '
        'chkThursday
        '
        Me.chkThursday.AutoSize = True
        Me.chkThursday.Checked = True
        Me.chkThursday.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkThursday.Location = New System.Drawing.Point(21, 23)
        Me.chkThursday.Name = "chkThursday"
        Me.chkThursday.Size = New System.Drawing.Size(87, 21)
        Me.chkThursday.TabIndex = 22
        Me.chkThursday.Tag = "4"
        Me.chkThursday.Text = "Thursday"
        Me.chkThursday.UseVisualStyleBackColor = True
        '
        'chkWednesDay
        '
        Me.chkWednesDay.AutoSize = True
        Me.chkWednesDay.Checked = True
        Me.chkWednesDay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWednesDay.Location = New System.Drawing.Point(248, 4)
        Me.chkWednesDay.Name = "chkWednesDay"
        Me.chkWednesDay.Size = New System.Drawing.Size(102, 21)
        Me.chkWednesDay.TabIndex = 22
        Me.chkWednesDay.Tag = "3"
        Me.chkWednesDay.Text = "Wednesday"
        Me.chkWednesDay.UseVisualStyleBackColor = True
        '
        'chkTuesday
        '
        Me.chkTuesday.AutoSize = True
        Me.chkTuesday.Checked = True
        Me.chkTuesday.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTuesday.Location = New System.Drawing.Point(170, 4)
        Me.chkTuesday.Name = "chkTuesday"
        Me.chkTuesday.Size = New System.Drawing.Size(82, 21)
        Me.chkTuesday.TabIndex = 22
        Me.chkTuesday.Tag = "2"
        Me.chkTuesday.Text = "Tuesday"
        Me.chkTuesday.UseVisualStyleBackColor = True
        '
        'chkMonday
        '
        Me.chkMonday.AutoSize = True
        Me.chkMonday.Checked = True
        Me.chkMonday.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMonday.Location = New System.Drawing.Point(93, 4)
        Me.chkMonday.Name = "chkMonday"
        Me.chkMonday.Size = New System.Drawing.Size(77, 21)
        Me.chkMonday.TabIndex = 22
        Me.chkMonday.Tag = "1"
        Me.chkMonday.Text = "Monday"
        Me.chkMonday.UseVisualStyleBackColor = True
        '
        'chkSunday
        '
        Me.chkSunday.AutoSize = True
        Me.chkSunday.Checked = True
        Me.chkSunday.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSunday.Location = New System.Drawing.Point(21, 4)
        Me.chkSunday.Name = "chkSunday"
        Me.chkSunday.Size = New System.Drawing.Size(75, 21)
        Me.chkSunday.TabIndex = 22
        Me.chkSunday.Tag = "0"
        Me.chkSunday.Text = "Sunday"
        Me.chkSunday.UseVisualStyleBackColor = True
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.WengLee_Application.My.Resources.Resources.delete_enquiry
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 10
        '
        'frmScheduleOrderEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 644)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnShowBOLAddress)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnNoOrder)
        Me.Controls.Add(Me.lblLastOrder)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbCustomer)
        Me.Controls.Add(Me.txtOrderDate)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLinkAddress)
        Me.Controls.Add(Me.btnAddProduct)
        Me.Controls.Add(Me.btnCreateProduct)
        Me.Controls.Add(Me.btnOrderHistory)
        Me.Controls.Add(Me.btnCreateCustomer)
        Me.Controls.Add(Me.btnPostOrder)
        Me.Controls.Add(Me.txtRouteCity)
        Me.Controls.Add(Me.txtOrderNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(750, 500)
        Me.Name = "frmScheduleOrderEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Schedule Order"
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents btnPostOrder As System.Windows.Forms.Button
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgItemList As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCreateCustomer As System.Windows.Forms.Button
    Friend WithEvents btnCreateProduct As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRouteCity As System.Windows.Forms.TextBox
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents btnOrderHistory As System.Windows.Forms.Button
    Friend WithEvents btnLinkAddress As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCases As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents lblLastOrder As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnNoOrder As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnShowBOLAddress As System.Windows.Forms.Button
    Friend WithEvents txtStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rdbMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents rdbWeekly As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDaily As System.Windows.Forms.RadioButton
    Friend WithEvents chkSaturday As System.Windows.Forms.CheckBox
    Friend WithEvents chkFriday As System.Windows.Forms.CheckBox
    Friend WithEvents chkThursday As System.Windows.Forms.CheckBox
    Friend WithEvents chkWednesDay As System.Windows.Forms.CheckBox
    Friend WithEvents chkTuesday As System.Windows.Forms.CheckBox
    Friend WithEvents chkMonday As System.Windows.Forms.CheckBox
    Friend WithEvents chkSunday As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents PID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Fresh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frozen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnItemId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
