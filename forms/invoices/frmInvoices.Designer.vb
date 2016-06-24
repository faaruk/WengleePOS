<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoices
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
        Me.dgInvoices = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.OrderNumber = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Status = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.chkDateRange = New System.Windows.Forms.CheckBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.CntlInvoiceView1 = New WengLee_Application.cntlInvoiceView()
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgInvoices
        '
        Me.dgInvoices.AllowUserToAddRows = False
        Me.dgInvoices.AllowUserToDeleteRows = False
        Me.dgInvoices.AllowUserToOrderColumns = True
        Me.dgInvoices.AllowUserToResizeRows = False
        Me.dgInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.OrderNumber, Me.Status})
        Me.dgInvoices.Location = New System.Drawing.Point(0, 43)
        Me.dgInvoices.Name = "dgInvoices"
        Me.dgInvoices.RowHeadersVisible = False
        Me.dgInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgInvoices.Size = New System.Drawing.Size(1077, 642)
        Me.dgInvoices.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Link With Order"
        Me.Column1.Name = "Column1"
        Me.Column1.Text = "Link With Order"
        Me.Column1.Width = 87
        '
        'OrderNumber
        '
        Me.OrderNumber.DataPropertyName = "OrderNumber"
        Me.OrderNumber.HeaderText = "OrderNumber"
        Me.OrderNumber.Name = "OrderNumber"
        Me.OrderNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.OrderNumber.Width = 95
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.Width = 43
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(859, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(215, 35)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Load NCR Orders"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDateRange.Checked = True
        Me.chkDateRange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDateRange.Location = New System.Drawing.Point(9, 12)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(115, 24)
        Me.chkDateRange.TabIndex = 3
        Me.chkDateRange.Text = "Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(139, 8)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(128, 26)
        Me.dtp1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(269, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "To"
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(302, 8)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(128, 26)
        Me.dtp2.TabIndex = 6
        '
        'btnReload
        '
        Me.btnReload.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReload.Location = New System.Drawing.Point(436, 5)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(162, 35)
        Me.btnReload.TabIndex = 7
        Me.btnReload.Text = "Refresh"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'CntlInvoiceView1
        '
        Me.CntlInvoiceView1.BackColor = System.Drawing.Color.White
        Me.CntlInvoiceView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CntlInvoiceView1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CntlInvoiceView1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CntlInvoiceView1.Location = New System.Drawing.Point(1018, 0)
        Me.CntlInvoiceView1.Margin = New System.Windows.Forms.Padding(4)
        Me.CntlInvoiceView1.Name = "CntlInvoiceView1"
        Me.CntlInvoiceView1.Size = New System.Drawing.Size(59, 685)
        Me.CntlInvoiceView1.TabIndex = 2
        Me.CntlInvoiceView1.Visible = False
        '
        'frmInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 685)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.dtp2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.chkDateRange)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dgInvoices)
        Me.Controls.Add(Me.CntlInvoiceView1)
        Me.Name = "frmInvoices"
        Me.Text = "Invoices"
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents CntlInvoiceView1 As WengLee_Application.cntlInvoiceView
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents dtp1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents OrderNumber As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewButtonColumn
End Class
