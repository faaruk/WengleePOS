<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cntlRouteView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgItemList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORDERID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalCartons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderDiscrepancy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLoadNcr = New System.Windows.Forms.Button()
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " "
        '
        'dgItemList
        '
        Me.dgItemList.AllowUserToAddRows = False
        Me.dgItemList.AllowUserToDeleteRows = False
        Me.dgItemList.AllowUserToResizeColumns = False
        Me.dgItemList.AllowUserToResizeRows = False
        Me.dgItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgItemList.BackgroundColor = System.Drawing.Color.White
        Me.dgItemList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgItemList.ColumnHeadersHeight = 25
        Me.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column2, Me.QTY, Me.ORDERID, Me.InvoiceNumber, Me.TotalCartons, Me.OrderDiscrepancy, Me.Column6})
        Me.dgItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgItemList.Location = New System.Drawing.Point(0, 16)
        Me.dgItemList.Name = "dgItemList"
        Me.dgItemList.RowHeadersWidth = 20
        Me.dgItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgItemList.Size = New System.Drawing.Size(550, 418)
        Me.dgItemList.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.dgItemList, "Alt + Click to show the order")
        '
        'Column1
        '
        Me.Column1.HeaderText = "SL."
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 57
        '
        'Column3
        '
        Me.Column3.HeaderText = "ORDER NO"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 97
        '
        'Column2
        '
        Me.Column2.HeaderText = "CUSTOMER (ALT+CLICK)"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 193
        '
        'QTY
        '
        Me.QTY.HeaderText = "TOTAL"
        Me.QTY.Name = "QTY"
        Me.QTY.ReadOnly = True
        Me.QTY.Width = 73
        '
        'ORDERID
        '
        Me.ORDERID.HeaderText = "ORDERID"
        Me.ORDERID.Name = "ORDERID"
        Me.ORDERID.ReadOnly = True
        Me.ORDERID.Visible = False
        Me.ORDERID.Width = 82
        '
        'InvoiceNumber
        '
        Me.InvoiceNumber.HeaderText = "INVOICE #"
        Me.InvoiceNumber.Name = "InvoiceNumber"
        Me.InvoiceNumber.Width = 105
        '
        'TotalCartons
        '
        Me.TotalCartons.HeaderText = "InvoiceCartons"
        Me.TotalCartons.Name = "TotalCartons"
        Me.TotalCartons.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TotalCartons.Width = 145
        '
        'OrderDiscrepancy
        '
        Me.OrderDiscrepancy.HeaderText = "OrderDiscrepancy"
        Me.OrderDiscrepancy.Name = "OrderDiscrepancy"
        Me.OrderDiscrepancy.Width = 161
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 434)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(550, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = " "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(401, -1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(148, 23)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(400, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Print Label"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnLoadNcr
        '
        Me.btnLoadNcr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadNcr.Location = New System.Drawing.Point(400, 39)
        Me.btnLoadNcr.Name = "btnLoadNcr"
        Me.btnLoadNcr.Size = New System.Drawing.Size(148, 23)
        Me.btnLoadNcr.TabIndex = 8
        Me.btnLoadNcr.Text = "Load NCR Orders"
        Me.btnLoadNcr.UseVisualStyleBackColor = True
        Me.btnLoadNcr.Visible = False
        '
        'cntlRouteView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnLoadNcr)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.dgItemList)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "cntlRouteView"
        Me.Size = New System.Drawing.Size(550, 452)
        CType(Me.dgItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgItemList As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCartons As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderDiscrepancy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnLoadNcr As System.Windows.Forms.Button

End Class
