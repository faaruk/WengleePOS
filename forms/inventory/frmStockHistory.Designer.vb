<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockHistory
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
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.chkFrozen = New System.Windows.Forms.CheckBox()
        Me.chkFresh = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.chkDateRange = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblTotalFresh = New System.Windows.Forms.Label()
        Me.lblTotalFrozen = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgHistory
        '
        Me.dgHistory.AllowUserToAddRows = False
        Me.dgHistory.AllowUserToDeleteRows = False
        Me.dgHistory.AllowUserToResizeRows = False
        Me.dgHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHistory.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgHistory.Location = New System.Drawing.Point(0, 40)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.RowHeadersVisible = False
        Me.dgHistory.Size = New System.Drawing.Size(1091, 642)
        Me.dgHistory.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Categories"
        Me.Column1.Name = "Column1"
        Me.Column1.Text = "Categories"
        Me.Column1.UseColumnTextForButtonValue = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(8, 687)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 36)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.chkFrozen)
        Me.Panel1.Controls.Add(Me.chkFresh)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.chkDateRange)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1090, 37)
        Me.Panel1.TabIndex = 5
        '
        'btnExport
        '
        Me.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(840, 7)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(140, 27)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'chkFrozen
        '
        Me.chkFrozen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkFrozen.AutoSize = True
        Me.chkFrozen.Checked = True
        Me.chkFrozen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFrozen.Location = New System.Drawing.Point(628, 11)
        Me.chkFrozen.Name = "chkFrozen"
        Me.chkFrozen.Size = New System.Drawing.Size(71, 21)
        Me.chkFrozen.TabIndex = 4
        Me.chkFrozen.Text = "Frozen"
        Me.chkFrozen.UseVisualStyleBackColor = True
        '
        'chkFresh
        '
        Me.chkFresh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkFresh.AutoSize = True
        Me.chkFresh.Checked = True
        Me.chkFresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFresh.Location = New System.Drawing.Point(559, 11)
        Me.chkFresh.Name = "chkFresh"
        Me.chkFresh.Size = New System.Drawing.Size(63, 21)
        Me.chkFresh.TabIndex = 4
        Me.chkFresh.Text = "Fresh"
        Me.chkFresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(389, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "To"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DateTimePicker2.Checked = False
        Me.DateTimePicker2.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(430, 7)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(112, 23)
        Me.DateTimePicker2.TabIndex = 2
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DateTimePicker1.Checked = False
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(271, 7)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(112, 23)
        Me.DateTimePicker1.TabIndex = 2
        '
        'chkDateRange
        '
        Me.chkDateRange.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDateRange.Location = New System.Drawing.Point(111, 9)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(146, 21)
        Me.chkDateRange.TabIndex = 1
        Me.chkDateRange.Text = "Select Date Range"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.Location = New System.Drawing.Point(705, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 27)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Show"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblTotalFresh
        '
        Me.lblTotalFresh.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalFresh.AutoSize = True
        Me.lblTotalFresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFresh.Location = New System.Drawing.Point(159, 699)
        Me.lblTotalFresh.Name = "lblTotalFresh"
        Me.lblTotalFresh.Size = New System.Drawing.Size(75, 13)
        Me.lblTotalFresh.TabIndex = 6
        Me.lblTotalFresh.Text = "Total Fresh:"
        '
        'lblTotalFrozen
        '
        Me.lblTotalFrozen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalFrozen.AutoSize = True
        Me.lblTotalFrozen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFrozen.Location = New System.Drawing.Point(308, 699)
        Me.lblTotalFrozen.Name = "lblTotalFrozen"
        Me.lblTotalFrozen.Size = New System.Drawing.Size(82, 13)
        Me.lblTotalFrozen.TabIndex = 7
        Me.lblTotalFrozen.Text = "Total Frozen:"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(528, 699)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(40, 13)
        Me.lblTotal.TabIndex = 8
        Me.lblTotal.Text = "Total:"
        '
        'frmStockHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 728)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblTotalFrozen)
        Me.Controls.Add(Me.lblTotalFresh)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgHistory)
        Me.Name = "frmStockHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Activity"
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgHistory As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkFrozen As System.Windows.Forms.CheckBox
    Friend WithEvents chkFresh As System.Windows.Forms.CheckBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblTotalFresh As System.Windows.Forms.Label
    Friend WithEvents lblTotalFrozen As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
End Class
