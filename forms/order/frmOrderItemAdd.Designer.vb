<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderItemAdd
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgProduct = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSubCategory = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgCategory = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgSubCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgProduct, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgSubCategory, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgCategory, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1035, 480)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'dgProduct
        '
        Me.dgProduct.AllowUserToAddRows = False
        Me.dgProduct.AllowUserToDeleteRows = False
        Me.dgProduct.AllowUserToResizeColumns = False
        Me.dgProduct.AllowUserToResizeRows = False
        Me.dgProduct.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.DataGridViewTextBoxColumn2})
        Me.dgProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgProduct.Location = New System.Drawing.Point(694, 4)
        Me.dgProduct.Margin = New System.Windows.Forms.Padding(4)
        Me.dgProduct.Name = "dgProduct"
        Me.dgProduct.RowHeadersVisible = False
        Me.dgProduct.RowTemplate.Height = 32
        Me.dgProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProduct.Size = New System.Drawing.Size(337, 472)
        Me.dgProduct.TabIndex = 2
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "ProductId"
        Me.Column2.HeaderText = "ProductId"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ProductName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Product/Item"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'dgSubCategory
        '
        Me.dgSubCategory.AllowUserToAddRows = False
        Me.dgSubCategory.AllowUserToDeleteRows = False
        Me.dgSubCategory.AllowUserToResizeColumns = False
        Me.dgSubCategory.AllowUserToResizeRows = False
        Me.dgSubCategory.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgSubCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSubCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.dgSubCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSubCategory.Location = New System.Drawing.Point(349, 4)
        Me.dgSubCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgSubCategory.Name = "dgSubCategory"
        Me.dgSubCategory.RowHeadersVisible = False
        Me.dgSubCategory.RowTemplate.Height = 32
        Me.dgSubCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSubCategory.Size = New System.Drawing.Size(337, 472)
        Me.dgSubCategory.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SubCategory"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Sub - Category"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'dgCategory
        '
        Me.dgCategory.AllowUserToAddRows = False
        Me.dgCategory.AllowUserToDeleteRows = False
        Me.dgCategory.AllowUserToResizeColumns = False
        Me.dgCategory.AllowUserToResizeRows = False
        Me.dgCategory.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCategory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCategory.Location = New System.Drawing.Point(4, 4)
        Me.dgCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgCategory.Name = "dgCategory"
        Me.dgCategory.RowHeadersVisible = False
        Me.dgCategory.RowTemplate.Height = 32
        Me.dgCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCategory.Size = New System.Drawing.Size(337, 472)
        Me.dgCategory.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "Category"
        Me.Column1.HeaderText = "Category"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(863, 492)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(172, 37)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Done"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 512)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "* Use Ctrl + Click to select multiple items"
        '
        'frmAddOrderItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1048, 529)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddOrderItem"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Order Item"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgSubCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgCategory As System.Windows.Forms.DataGridView
    Friend WithEvents dgProduct As System.Windows.Forms.DataGridView
    Friend WithEvents dgSubCategory As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
