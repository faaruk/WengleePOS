<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateTemplate
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
        Me.txtTemplateName = New System.Windows.Forms.TextBox()
        Me.btnPostOrder = New System.Windows.Forms.Button()
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
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'txtTemplateName
        '
        Me.txtTemplateName.Location = New System.Drawing.Point(114, 23)
        Me.txtTemplateName.Name = "txtTemplateName"
        Me.txtTemplateName.Size = New System.Drawing.Size(365, 23)
        Me.txtTemplateName.TabIndex = 0
        '
        'btnPostOrder
        '
        Me.btnPostOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPostOrder.Location = New System.Drawing.Point(649, 485)
        Me.btnPostOrder.Name = "btnPostOrder"
        Me.btnPostOrder.Size = New System.Drawing.Size(121, 38)
        Me.btnPostOrder.TabIndex = 9
        Me.btnPostOrder.Text = "Save"
        Me.btnPostOrder.UseVisualStyleBackColor = True
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
        Me.dgItemList.Location = New System.Drawing.Point(48, 13)
        Me.dgItemList.MultiSelect = False
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.RowHeadersVisible = False
        Me.dgItemList.RowTemplate.Height = 30
        Me.dgItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemList.Size = New System.Drawing.Size(669, 351)
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
        Me.Fresh.Visible = False
        '
        'Frozen
        '
        Me.Frozen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Frozen.DefaultCellStyle = DataGridViewCellStyle3
        Me.Frozen.HeaderText = "Frozen"
        Me.Frozen.Name = "Frozen"
        Me.Frozen.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(55, 485)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(121, 38)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddProduct.Location = New System.Drawing.Point(334, 485)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(121, 38)
        Me.btnAddProduct.TabIndex = 7
        Me.btnAddProduct.Text = "Add Product"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnUp)
        Me.GroupBox1.Controls.Add(Me.btnDown)
        Me.GroupBox1.Controls.Add(Me.dgItemList)
        Me.GroupBox1.Location = New System.Drawing.Point(49, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(721, 370)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'btnUp
        '
        Me.btnUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp.Location = New System.Drawing.Point(3, 13)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(44, 163)
        Me.btnUp.TabIndex = 20
        Me.btnUp.Text = "↑"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown.Location = New System.Drawing.Point(3, 202)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(44, 163)
        Me.btnDown.TabIndex = 21
        Me.btnDown.Text = "↓"
        Me.btnDown.UseVisualStyleBackColor = True
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(114, 82)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(202, 21)
        Me.CheckBox1.TabIndex = 17
        Me.CheckBox1.Text = "For All Customer (universal)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmbCustomer
        '
        Me.cmbCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomer.Enabled = False
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(114, 52)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(365, 24)
        Me.cmbCustomer.TabIndex = 0
        '
        'frmCreateTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 556)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbCustomer)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddProduct)
        Me.Controls.Add(Me.btnPostOrder)
        Me.Controls.Add(Me.txtTemplateName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(750, 500)
        Me.Name = "frmCreateTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Template"
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTemplateName As System.Windows.Forms.TextBox
    Friend WithEvents btnPostOrder As System.Windows.Forms.Button
    Friend WithEvents dgItemList As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAddProduct As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents PID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Fresh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frozen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
End Class
