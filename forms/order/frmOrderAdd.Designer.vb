<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderAdd
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreateCustomer = New System.Windows.Forms.Button()
        Me.btnCreateProduct = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRouteCity = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTemplate = New System.Windows.Forms.ComboBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.btnOrderHistory = New System.Windows.Forms.Button()
        Me.btnLinkAddress = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalCases = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.lblLastOrder = New System.Windows.Forms.Label()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnNoOrder = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnShowBOLAddress = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectPostOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtDOP = New System.Windows.Forms.TextBox()
        Me.lblDOP = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.btnPostOrder.Location = New System.Drawing.Point(551, 443)
        Me.btnPostOrder.Name = "btnPostOrder"
        Me.btnPostOrder.Size = New System.Drawing.Size(231, 43)
        Me.btnPostOrder.TabIndex = 9
        Me.btnPostOrder.Text = "Post Order"
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
        Me.Label3.Location = New System.Drawing.Point(522, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Order Date"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(522, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Status"
        '
        'cmbStatus
        '
        Me.cmbStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled", "On Hold"})
        Me.cmbStatus.Location = New System.Drawing.Point(620, 70)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(160, 24)
        Me.cmbStatus.TabIndex = 2
        '
        'txtOrderDate
        '
        Me.txtOrderDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderDate.CustomFormat = "MM/dd/yyyy"
        Me.txtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtOrderDate.Location = New System.Drawing.Point(620, 14)
        Me.txtOrderDate.Name = "txtOrderDate"
        Me.txtOrderDate.Size = New System.Drawing.Size(160, 23)
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
        Me.dgItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PID, Me.ITEM, Me.QTY, Me.Type, Me.Column1, Me.Column2, Me.Fresh, Me.Frozen})
        Me.dgItemList.Location = New System.Drawing.Point(6, 13)
        Me.dgItemList.MultiSelect = False
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.RowHeadersVisible = False
        Me.dgItemList.RowTemplate.Height = 30
        Me.dgItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemList.Size = New System.Drawing.Size(463, 360)
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
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.QTY.DefaultCellStyle = DataGridViewCellStyle16
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
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fresh.DefaultCellStyle = DataGridViewCellStyle17
        Me.Fresh.HeaderText = "Fresh"
        Me.Fresh.Name = "Fresh"
        '
        'Frozen
        '
        Me.Frozen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Frozen.DefaultCellStyle = DataGridViewCellStyle18
        Me.Frozen.HeaderText = "Frozen"
        Me.Frozen.Name = "Frozen"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(551, 539)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(231, 43)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreateCustomer
        '
        Me.btnCreateCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateCustomer.Location = New System.Drawing.Point(551, 136)
        Me.btnCreateCustomer.Name = "btnCreateCustomer"
        Me.btnCreateCustomer.Size = New System.Drawing.Size(231, 38)
        Me.btnCreateCustomer.TabIndex = 4
        Me.btnCreateCustomer.Text = "Create Customer"
        Me.btnCreateCustomer.UseVisualStyleBackColor = True
        '
        'btnCreateProduct
        '
        Me.btnCreateProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateProduct.Location = New System.Drawing.Point(551, 222)
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
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(522, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Template"
        '
        'cmbTemplate
        '
        Me.cmbTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemplate.FormattingEnabled = True
        Me.cmbTemplate.Items.AddRange(New Object() {"None", "Default"})
        Me.cmbTemplate.Location = New System.Drawing.Point(620, 98)
        Me.cmbTemplate.Name = "cmbTemplate"
        Me.cmbTemplate.Size = New System.Drawing.Size(138, 24)
        Me.cmbTemplate.TabIndex = 3
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddProduct.Location = New System.Drawing.Point(551, 265)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(231, 38)
        Me.btnAddProduct.TabIndex = 7
        Me.btnAddProduct.Text = "Add Product"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'btnOrderHistory
        '
        Me.btnOrderHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrderHistory.Location = New System.Drawing.Point(551, 179)
        Me.btnOrderHistory.Name = "btnOrderHistory"
        Me.btnOrderHistory.Size = New System.Drawing.Size(231, 38)
        Me.btnOrderHistory.TabIndex = 5
        Me.btnOrderHistory.Text = "Show Order History"
        Me.btnOrderHistory.UseVisualStyleBackColor = True
        '
        'btnLinkAddress
        '
        Me.btnLinkAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLinkAddress.Location = New System.Drawing.Point(551, 388)
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
        Me.GroupBox1.Location = New System.Drawing.Point(38, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 412)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(3, 380)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(291, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Total :"
        '
        'lblTotalCases
        '
        Me.lblTotalCases.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCases.Location = New System.Drawing.Point(293, 380)
        Me.lblTotalCases.Name = "lblTotalCases"
        Me.lblTotalCases.Size = New System.Drawing.Size(177, 24)
        Me.lblTotalCases.TabIndex = 12
        Me.lblTotalCases.Text = "Label7"
        Me.lblTotalCases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtComment.Location = New System.Drawing.Point(38, 555)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComment.Size = New System.Drawing.Size(477, 75)
        Me.txtComment.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 538)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Comments"
        '
        'btnNoOrder
        '
        Me.btnNoOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNoOrder.Location = New System.Drawing.Point(551, 587)
        Me.btnNoOrder.Name = "btnNoOrder"
        Me.btnNoOrder.Size = New System.Drawing.Size(231, 43)
        Me.btnNoOrder.TabIndex = 16
        Me.btnNoOrder.Text = "No Order"
        Me.btnNoOrder.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(539, 621)
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
        Me.btnShowBOLAddress.Location = New System.Drawing.Point(551, 346)
        Me.btnShowBOLAddress.Name = "btnShowBOLAddress"
        Me.btnShowBOLAddress.Size = New System.Drawing.Size(231, 38)
        Me.btnShowBOLAddress.TabIndex = 18
        Me.btnShowBOLAddress.Text = "Show BOL Drop-Off"
        Me.btnShowBOLAddress.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectPostOrderToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(226, 26)
        '
        'SelectPostOrderToolStripMenuItem
        '
        Me.SelectPostOrderToolStripMenuItem.Name = "SelectPostOrderToolStripMenuItem"
        Me.SelectPostOrderToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)
        Me.SelectPostOrderToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SelectPostOrderToolStripMenuItem.Text = "Select Post Order"
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDeliveryDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpDeliveryDate.Enabled = False
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(620, 41)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(160, 23)
        Me.dtpDeliveryDate.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(522, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Posting Date"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(551, 491)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 43)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Post Blank Order"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(759, 98)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 24)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "N"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtDOP
        '
        Me.txtDOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDOP.Location = New System.Drawing.Point(137, 514)
        Me.txtDOP.Name = "txtDOP"
        Me.txtDOP.ReadOnly = True
        Me.txtDOP.Size = New System.Drawing.Size(378, 23)
        Me.txtDOP.TabIndex = 24
        '
        'lblDOP
        '
        Me.lblDOP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDOP.AutoSize = True
        Me.lblDOP.Location = New System.Drawing.Point(35, 516)
        Me.lblDOP.Name = "lblDOP"
        Me.lblDOP.Size = New System.Drawing.Size(98, 17)
        Me.lblDOP.TabIndex = 25
        Me.lblDOP.Text = "Drop Off Point"
        '
        'lblNotes
        '
        Me.lblNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(38, 633)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(45, 17)
        Me.lblNotes.TabIndex = 26
        Me.lblNotes.Text = "Notes"
        '
        'frmOrderAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 669)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.lblDOP)
        Me.Controls.Add(Me.txtDOP)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtpDeliveryDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnShowBOLAddress)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnNoOrder)
        Me.Controls.Add(Me.lblLastOrder)
        Me.Controls.Add(Me.cmbCustomer)
        Me.Controls.Add(Me.txtOrderDate)
        Me.Controls.Add(Me.cmbTemplate)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLinkAddress)
        Me.Controls.Add(Me.btnAddProduct)
        Me.Controls.Add(Me.btnCreateProduct)
        Me.Controls.Add(Me.btnOrderHistory)
        Me.Controls.Add(Me.btnCreateCustomer)
        Me.Controls.Add(Me.btnPostOrder)
        Me.Controls.Add(Me.txtRouteCity)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtOrderNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(750, 500)
        Me.Name = "frmOrderAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Post Order"
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTemplate As System.Windows.Forms.ComboBox
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
    Friend WithEvents PID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Fresh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frozen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnShowBOLAddress As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SelectPostOrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtDOP As System.Windows.Forms.TextBox
    Friend WithEvents lblDOP As System.Windows.Forms.Label
    Friend WithEvents lblNotes As System.Windows.Forms.Label
End Class
