<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaserEdit
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPostOrder = New System.Windows.Forms.Button()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.dgItemList = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreateCustomer = New System.Windows.Forms.Button()
        Me.btnCreateProduct = New System.Windows.Forms.Button()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalCases = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPO_No = New System.Windows.Forms.TextBox()
        Me.PID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Fresh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Frozen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Vendor"
        '
        'btnPostOrder
        '
        Me.btnPostOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPostOrder.Location = New System.Drawing.Point(544, 426)
        Me.btnPostOrder.Name = "btnPostOrder"
        Me.btnPostOrder.Size = New System.Drawing.Size(231, 43)
        Me.btnPostOrder.TabIndex = 7
        Me.btnPostOrder.Text = "Save"
        Me.btnPostOrder.UseVisualStyleBackColor = True
        '
        'cmbCustomer
        '
        Me.cmbCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(165, 48)
        Me.cmbCustomer.MaximumSize = New System.Drawing.Size(370, 0)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(321, 24)
        Me.cmbCustomer.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Purchase Date"
        '
        'txtOrderDate
        '
        Me.txtOrderDate.CustomFormat = "MM/dd/yyyy"
        Me.txtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtOrderDate.Location = New System.Drawing.Point(165, 19)
        Me.txtOrderDate.Name = "txtOrderDate"
        Me.txtOrderDate.Size = New System.Drawing.Size(189, 23)
        Me.txtOrderDate.TabIndex = 0
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
        Me.dgItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PID, Me.ITEM, Me.QTY, Me.Type, Me.Column1, Me.Column2, Me.Fresh, Me.Frozen, Me.Column3})
        Me.dgItemList.Location = New System.Drawing.Point(6, 13)
        Me.dgItemList.MultiSelect = False
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.RowHeadersVisible = False
        Me.dgItemList.RowTemplate.Height = 30
        Me.dgItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemList.Size = New System.Drawing.Size(480, 331)
        Me.dgItemList.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(544, 475)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(231, 43)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreateCustomer
        '
        Me.btnCreateCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateCustomer.Location = New System.Drawing.Point(544, 123)
        Me.btnCreateCustomer.Name = "btnCreateCustomer"
        Me.btnCreateCustomer.Size = New System.Drawing.Size(231, 38)
        Me.btnCreateCustomer.TabIndex = 9
        Me.btnCreateCustomer.Text = "Create Vendor"
        Me.btnCreateCustomer.UseVisualStyleBackColor = True
        '
        'btnCreateProduct
        '
        Me.btnCreateProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateProduct.Location = New System.Drawing.Point(544, 167)
        Me.btnCreateProduct.Name = "btnCreateProduct"
        Me.btnCreateProduct.Size = New System.Drawing.Size(231, 38)
        Me.btnCreateProduct.TabIndex = 10
        Me.btnCreateProduct.Text = "Create Product"
        Me.btnCreateProduct.UseVisualStyleBackColor = True
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddProduct.Location = New System.Drawing.Point(544, 211)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(231, 38)
        Me.btnAddProduct.TabIndex = 6
        Me.btnAddProduct.Text = "Add Product"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTotalCases)
        Me.GroupBox1.Controls.Add(Me.dgItemList)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 382)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(3, 352)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(308, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Total :"
        '
        'lblTotalCases
        '
        Me.lblTotalCases.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCases.Location = New System.Drawing.Point(310, 352)
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
        'txtComment
        '
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(31, 435)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComment.Size = New System.Drawing.Size(494, 83)
        Me.txtComment.TabIndex = 5
        Me.txtComment.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 416)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Comments"
        Me.Label7.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Invoice No"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Location = New System.Drawing.Point(165, 78)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(321, 23)
        Me.txtInvoiceNo.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Purchase Order No"
        '
        'txtPO_No
        '
        Me.txtPO_No.Location = New System.Drawing.Point(165, 107)
        Me.txtPO_No.Name = "txtPO_No"
        Me.txtPO_No.Size = New System.Drawing.Size(280, 23)
        Me.txtPO_No.TabIndex = 3
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
        Me.QTY.HeaderText = "Qty"
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
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "PO Notes"
        Me.Column3.Name = "Column3"
        '
        'frmPurchaserEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 554)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbCustomer)
        Me.Controls.Add(Me.txtOrderDate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddProduct)
        Me.Controls.Add(Me.btnCreateProduct)
        Me.Controls.Add(Me.btnCreateCustomer)
        Me.Controls.Add(Me.btnPostOrder)
        Me.Controls.Add(Me.txtPO_No)
        Me.Controls.Add(Me.txtInvoiceNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(750, 500)
        Me.Name = "frmPurchaserEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Purchase Invoice"
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPostOrder As System.Windows.Forms.Button
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgItemList As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCreateCustomer As System.Windows.Forms.Button
    Friend WithEvents btnCreateProduct As System.Windows.Forms.Button
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCases As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPO_No As System.Windows.Forms.TextBox
    Friend WithEvents PID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Fresh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frozen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
