<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdeEditr
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreateCustomer = New System.Windows.Forms.Button()
        Me.btnCreateProduct = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRouteCity = New System.Windows.Forms.TextBox()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.btnOrderHistory = New System.Windows.Forms.Button()
        Me.btnDeleteOrder = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalCases = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(121, 21)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(121, 23)
        Me.txtOrderNo.TabIndex = 0
        Me.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPostOrder
        '
        Me.btnPostOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPostOrder.Location = New System.Drawing.Point(530, 443)
        Me.btnPostOrder.Name = "btnPostOrder"
        Me.btnPostOrder.Size = New System.Drawing.Size(231, 43)
        Me.btnPostOrder.TabIndex = 9
        Me.btnPostOrder.Text = "Update Order"
        Me.btnPostOrder.UseVisualStyleBackColor = True
        '
        'cmbCustomer
        '
        Me.cmbCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomer.Enabled = False
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(121, 50)
        Me.cmbCustomer.MaximumSize = New System.Drawing.Size(370, 0)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(361, 24)
        Me.cmbCustomer.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(489, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Order Date"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(490, 52)
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
        Me.cmbStatus.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled"})
        Me.cmbStatus.Location = New System.Drawing.Point(572, 49)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(189, 24)
        Me.cmbStatus.TabIndex = 2
        '
        'txtOrderDate
        '
        Me.txtOrderDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrderDate.CustomFormat = "MM/dd/yyyy"
        Me.txtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtOrderDate.Location = New System.Drawing.Point(572, 22)
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
        Me.dgItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PID, Me.ITEM, Me.QTY, Me.Type, Me.Column1, Me.Column2})
        Me.dgItemList.Location = New System.Drawing.Point(3, 11)
        Me.dgItemList.MultiSelect = False
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.RowHeadersVisible = False
        Me.dgItemList.RowTemplate.Height = 30
        Me.dgItemList.Size = New System.Drawing.Size(459, 388)
        Me.dgItemList.TabIndex = 11
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(530, 492)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(231, 43)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnCreateCustomer
        '
        Me.btnCreateCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateCustomer.Location = New System.Drawing.Point(530, 120)
        Me.btnCreateCustomer.Name = "btnCreateCustomer"
        Me.btnCreateCustomer.Size = New System.Drawing.Size(231, 43)
        Me.btnCreateCustomer.TabIndex = 4
        Me.btnCreateCustomer.Text = "Create Customer"
        Me.btnCreateCustomer.UseVisualStyleBackColor = True
        '
        'btnCreateProduct
        '
        Me.btnCreateProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateProduct.Enabled = False
        Me.btnCreateProduct.Location = New System.Drawing.Point(530, 218)
        Me.btnCreateProduct.Name = "btnCreateProduct"
        Me.btnCreateProduct.Size = New System.Drawing.Size(231, 43)
        Me.btnCreateProduct.TabIndex = 6
        Me.btnCreateProduct.Text = "Create Product"
        Me.btnCreateProduct.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Route City"
        '
        'txtRouteCity
        '
        Me.txtRouteCity.Location = New System.Drawing.Point(121, 80)
        Me.txtRouteCity.Name = "txtRouteCity"
        Me.txtRouteCity.ReadOnly = True
        Me.txtRouteCity.Size = New System.Drawing.Size(121, 23)
        Me.txtRouteCity.TabIndex = 0
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddProduct.Location = New System.Drawing.Point(530, 308)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(231, 43)
        Me.btnAddProduct.TabIndex = 7
        Me.btnAddProduct.Text = "Add Product"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'btnOrderHistory
        '
        Me.btnOrderHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrderHistory.Enabled = False
        Me.btnOrderHistory.Location = New System.Drawing.Point(529, 169)
        Me.btnOrderHistory.Name = "btnOrderHistory"
        Me.btnOrderHistory.Size = New System.Drawing.Size(231, 43)
        Me.btnOrderHistory.TabIndex = 5
        Me.btnOrderHistory.Text = "Show Order History"
        Me.btnOrderHistory.UseVisualStyleBackColor = True
        '
        'btnDeleteOrder
        '
        Me.btnDeleteOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteOrder.Location = New System.Drawing.Point(530, 394)
        Me.btnDeleteOrder.Name = "btnDeleteOrder"
        Me.btnDeleteOrder.Size = New System.Drawing.Size(231, 43)
        Me.btnDeleteOrder.TabIndex = 8
        Me.btnDeleteOrder.Text = "Delete Order"
        Me.btnDeleteOrder.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTotalCases)
        Me.GroupBox1.Controls.Add(Me.dgItemList)
        Me.GroupBox1.Location = New System.Drawing.Point(45, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(466, 429)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(3, 402)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(280, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Total :"
        '
        'lblTotalCases
        '
        Me.lblTotalCases.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCases.Location = New System.Drawing.Point(282, 402)
        Me.lblTotalCases.Name = "lblTotalCases"
        Me.lblTotalCases.Size = New System.Drawing.Size(180, 24)
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
        Me.QTY.Width = 160
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
        Me.Column2.HeaderText = ""
        Me.Column2.Image = Global.WengLee_Application.My.Resources.Resources.delete_enquiry
        Me.Column2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 20
        '
        'frmEditOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 563)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbCustomer)
        Me.Controls.Add(Me.txtOrderDate)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDeleteOrder)
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
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(750, 580)
        Me.Name = "frmEditOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Order"
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
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
    Friend WithEvents btnDeleteOrder As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCases As System.Windows.Forms.Label
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
End Class
