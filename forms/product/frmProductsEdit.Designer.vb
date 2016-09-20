<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductsEdit
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.txtSubCategory = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.chkTrack = New System.Windows.Forms.CheckBox()
        Me.chkFz = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(458, 50)
        Me.Panel2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 302)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(458, 82)
        Me.Panel1.TabIndex = 6
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(281, 20)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(119, 35)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Unit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Sub Category"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Name"
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(171, 198)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(229, 26)
        Me.txtUnit.TabIndex = 4
        Me.txtUnit.Text = "Case(s)"
        '
        'txtSubCategory
        '
        Me.txtSubCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSubCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSubCategory.Location = New System.Drawing.Point(171, 166)
        Me.txtSubCategory.Name = "txtSubCategory"
        Me.txtSubCategory.Size = New System.Drawing.Size(229, 26)
        Me.txtSubCategory.TabIndex = 3
        '
        'txtCategory
        '
        Me.txtCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCategory.Location = New System.Drawing.Point(171, 134)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(229, 26)
        Me.txtCategory.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(171, 70)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(229, 26)
        Me.txtName.TabIndex = 0
        '
        'txtFullName
        '
        Me.txtFullName.AcceptsReturn = True
        Me.txtFullName.Location = New System.Drawing.Point(171, 102)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(229, 26)
        Me.txtFullName.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Full Name"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(171, 230)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(229, 26)
        Me.txtCode.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Item Code"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(171, 262)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(71, 24)
        Me.chkActive.TabIndex = 13
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'chkTrack
        '
        Me.chkTrack.AutoSize = True
        Me.chkTrack.Location = New System.Drawing.Point(248, 262)
        Me.chkTrack.Name = "chkTrack"
        Me.chkTrack.Size = New System.Drawing.Size(136, 24)
        Me.chkTrack.TabIndex = 14
        Me.chkTrack.Text = "Track Inventory"
        Me.chkTrack.UseVisualStyleBackColor = True
        '
        'chkFz
        '
        Me.chkFz.AutoSize = True
        Me.chkFz.Location = New System.Drawing.Point(386, 263)
        Me.chkFz.Name = "chkFz"
        Me.chkFz.Size = New System.Drawing.Size(48, 24)
        Me.chkFz.TabIndex = 15
        Me.chkFz.Text = "FZ"
        Me.chkFz.UseVisualStyleBackColor = True
        '
        'frmProductsEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 384)
        Me.Controls.Add(Me.chkFz)
        Me.Controls.Add(Me.chkTrack)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtSubCategory)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.txtName)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductsEdit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Product"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtSubCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents chkTrack As CheckBox
    Friend WithEvents chkFz As System.Windows.Forms.CheckBox
End Class
