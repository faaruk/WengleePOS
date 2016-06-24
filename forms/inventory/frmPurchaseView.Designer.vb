<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseView
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
        Me.chkDateRange = New System.Windows.Forms.CheckBox()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEditOrder = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnAddOrder = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.chkCustomer = New System.Windows.Forms.CheckBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblTotalOrder = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CntlOrderView1 = New WengLee_Application.cntlPurchaseView()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.dgOrder.Size = New System.Drawing.Size(735, 424)
        Me.dgOrder.TabIndex = 0
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDateRange.Location = New System.Drawing.Point(12, 4)
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
        Me.dtpFrom.Location = New System.Drawing.Point(134, 2)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(115, 23)
        Me.dtpFrom.TabIndex = 4
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MM/dd/yyyy"
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(285, 2)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(115, 23)
        Me.dtpTo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(255, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "To"
        '
        'btnEditOrder
        '
        Me.btnEditOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditOrder.Location = New System.Drawing.Point(562, 483)
        Me.btnEditOrder.Name = "btnEditOrder"
        Me.btnEditOrder.Size = New System.Drawing.Size(66, 30)
        Me.btnEditOrder.TabIndex = 6
        Me.btnEditOrder.Text = "Edit"
        Me.btnEditOrder.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(633, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(103, 30)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnAddOrder
        '
        Me.btnAddOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddOrder.Location = New System.Drawing.Point(634, 483)
        Me.btnAddOrder.Name = "btnAddOrder"
        Me.btnAddOrder.Size = New System.Drawing.Size(102, 30)
        Me.btnAddOrder.TabIndex = 9
        Me.btnAddOrder.Text = "Add"
        Me.btnAddOrder.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmbCustomer)
        Me.Panel1.Controls.Add(Me.chkCustomer)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.lblTotalOrder)
        Me.Panel1.Controls.Add(Me.btnAddOrder)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.btnEditOrder)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.chkDateRange)
        Me.Panel1.Controls.Add(Me.dgOrder)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(739, 517)
        Me.Panel1.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(336, 483)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 30)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "View Stock Details"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCustomer.Enabled = False
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(134, 28)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(367, 24)
        Me.cmbCustomer.TabIndex = 28
        '
        'chkCustomer
        '
        Me.chkCustomer.AutoSize = True
        Me.chkCustomer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCustomer.Location = New System.Drawing.Point(46, 30)
        Me.chkCustomer.Name = "chkCustomer"
        Me.chkCustomer.Size = New System.Drawing.Size(73, 21)
        Me.chkCustomer.TabIndex = 27
        Me.chkCustomer.Text = "Vendor"
        Me.chkCustomer.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(476, 483)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 30)
        Me.btnDelete.TabIndex = 22
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblTotalOrder
        '
        Me.lblTotalOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalOrder.AutoSize = True
        Me.lblTotalOrder.Location = New System.Drawing.Point(3, 480)
        Me.lblTotalOrder.Name = "lblTotalOrder"
        Me.lblTotalOrder.Size = New System.Drawing.Size(118, 17)
        Me.lblTotalOrder.TabIndex = 21
        Me.lblTotalOrder.Text = "Total : 0 Order(s)"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.Gainsboro
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(739, 0)
        Me.Splitter1.MinimumSize = New System.Drawing.Size(3, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(10, 517)
        Me.Splitter1.TabIndex = 11
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CntlOrderView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(749, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(494, 517)
        Me.Panel2.TabIndex = 12
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
        Me.CntlOrderView1.Size = New System.Drawing.Size(494, 517)
        Me.CntlOrderView1.TabIndex = 0
        '
        'frmPurchaseView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1243, 517)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPurchaseView"
        Me.Text = "View Inventory"
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEditOrder As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnAddOrder As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CntlOrderView1 As WengLee_Application.cntlPurchaseView
    Friend WithEvents lblTotalOrder As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents chkCustomer As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
