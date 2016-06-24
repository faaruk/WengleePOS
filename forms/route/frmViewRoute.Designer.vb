<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewRoute
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.chkDateRange = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblTotalOrder = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cmbRouteCity = New System.Windows.Forms.ComboBox()
        Me.chkRouteCity = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.btnLoadNcr = New System.Windows.Forms.Button()
        Me.CntlRouteView1 = New WengLee_Application.cntlRouteView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(15, 40)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(866, 455)
        Me.DataGridView1.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.HeaderText = "Pick List"
        Me.Column3.Name = "Column3"
        Me.Column3.Text = "Pick List"
        Me.Column3.ToolTipText = "Pick List"
        Me.Column3.UseColumnTextForButtonValue = True
        Me.Column3.Width = 60
        '
        'Column1
        '
        Me.Column1.HeaderText = "Route List"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "Route List"
        Me.Column1.ToolTipText = "Route List"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 43
        '
        'Column2
        '
        Me.Column2.HeaderText = "Map"
        Me.Column2.Name = "Column2"
        Me.Column2.Text = "Map"
        Me.Column2.UseColumnTextForButtonValue = True
        Me.Column2.Width = 40
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(678, 7)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(101, 26)
        Me.btnRefresh.TabIndex = 21
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(530, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "To"
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.CustomFormat = "MM/dd/yyyy"
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(565, 9)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(107, 23)
        Me.dtpTo.TabIndex = 19
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.CustomFormat = "MM/dd/yyyy"
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(415, 9)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(107, 23)
        Me.dtpFrom.TabIndex = 18
        '
        'chkDateRange
        '
        Me.chkDateRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDateRange.Checked = True
        Me.chkDateRange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDateRange.Location = New System.Drawing.Point(300, 10)
        Me.chkDateRange.Margin = New System.Windows.Forms.Padding(4)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(107, 21)
        Me.chkDateRange.TabIndex = 17
        Me.chkDateRange.Text = "Date Range "
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(740, 502)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 40)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Delete"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(597, 502)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(137, 40)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Edit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(454, 502)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(137, 40)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblTotalOrder
        '
        Me.lblTotalOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalOrder.AutoSize = True
        Me.lblTotalOrder.Location = New System.Drawing.Point(12, 502)
        Me.lblTotalOrder.Name = "lblTotalOrder"
        Me.lblTotalOrder.Size = New System.Drawing.Size(171, 17)
        Me.lblTotalOrder.TabIndex = 23
        Me.lblTotalOrder.Text = "Total : 0 Shipent Route(s)"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.cmbRouteCity)
        Me.Panel1.Controls.Add(Me.chkRouteCity)
        Me.Panel1.Controls.Add(Me.lblTotalOrder)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpTo)
        Me.Panel1.Controls.Add(Me.dtpFrom)
        Me.Panel1.Controls.Add(Me.chkDateRange)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(883, 554)
        Me.Panel1.TabIndex = 24
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(107, 276)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(716, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 36
        Me.ProgressBar1.Visible = False
        '
        'cmbRouteCity
        '
        Me.cmbRouteCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRouteCity.Enabled = False
        Me.cmbRouteCity.FormattingEnabled = True
        Me.cmbRouteCity.Items.AddRange(New Object() {"-Select-", "Open", "Fulfilled", "Delivered", "Cancelled", "No Order", "On Hold"})
        Me.cmbRouteCity.Location = New System.Drawing.Point(107, 7)
        Me.cmbRouteCity.Name = "cmbRouteCity"
        Me.cmbRouteCity.Size = New System.Drawing.Size(130, 24)
        Me.cmbRouteCity.TabIndex = 33
        '
        'chkRouteCity
        '
        Me.chkRouteCity.AutoSize = True
        Me.chkRouteCity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRouteCity.Location = New System.Drawing.Point(11, 10)
        Me.chkRouteCity.Name = "chkRouteCity"
        Me.chkRouteCity.Size = New System.Drawing.Size(92, 21)
        Me.chkRouteCity.TabIndex = 32
        Me.chkRouteCity.Text = "Route City"
        Me.chkRouteCity.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.CntlRouteView1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(890, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(426, 554)
        Me.Panel2.TabIndex = 25
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.WengLee_Application.My.Resources.Resources.pop_out_120
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.DarkGray
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(883, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(7, 554)
        Me.Splitter1.TabIndex = 26
        Me.Splitter1.TabStop = False
        '
        'btnLoadNcr
        '
        Me.btnLoadNcr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadNcr.Location = New System.Drawing.Point(780, 7)
        Me.btnLoadNcr.Name = "btnLoadNcr"
        Me.btnLoadNcr.Size = New System.Drawing.Size(101, 26)
        Me.btnLoadNcr.TabIndex = 34
        Me.btnLoadNcr.Text = "Load NCR"
        Me.btnLoadNcr.UseVisualStyleBackColor = True
        '
        'CntlRouteView1
        '
        Me.CntlRouteView1.BackColor = System.Drawing.Color.White
        Me.CntlRouteView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CntlRouteView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CntlRouteView1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CntlRouteView1.Location = New System.Drawing.Point(0, 0)
        Me.CntlRouteView1.Margin = New System.Windows.Forms.Padding(4)
        Me.CntlRouteView1.Name = "CntlRouteView1"
        Me.CntlRouteView1.Size = New System.Drawing.Size(426, 554)
        Me.CntlRouteView1.TabIndex = 0
        '
        'frmViewRoute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 554)
        Me.Controls.Add(Me.btnLoadNcr)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmViewRoute"
        Me.ShowIcon = False
        Me.Text = "View Routes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDateRange As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lblTotalOrder As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents CntlRouteView1 As WengLee_Application.cntlRouteView
    Friend WithEvents cmbRouteCity As ComboBox
    Friend WithEvents chkRouteCity As CheckBox
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoadNcr As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
