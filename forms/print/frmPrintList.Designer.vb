<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintList))
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.ButtonX6 = New System.Windows.Forms.Button()
        Me.Slider1 = New System.Windows.Forms.TrackBar()
        Me.LabelX1 = New System.Windows.Forms.Label()
        Me.LabelX2 = New System.Windows.Forms.Label()
        Me.TextBoxX2 = New System.Windows.Forms.TextBox()
        Me.TextBoxX1 = New System.Windows.Forms.TextBox()
        CType(Me.Slider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintPreviewControl1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.PrintPreviewControl1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(1, 33)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(857, 379)
        Me.PrintPreviewControl1.TabIndex = 0
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.Location = New System.Drawing.Point(6, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(39, 23)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "Print"
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.Location = New System.Drawing.Point(96, 4)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(39, 23)
        Me.btnPrev.TabIndex = 3
        Me.btnPrev.Text = "Prev"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.Location = New System.Drawing.Point(141, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(39, 23)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = "Next"
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.Location = New System.Drawing.Point(186, 4)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(39, 23)
        Me.btnLast.TabIndex = 5
        Me.btnLast.Text = "Last"
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.Location = New System.Drawing.Point(51, 4)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(39, 23)
        Me.btnFirst.TabIndex = 6
        Me.btnFirst.Text = "First"
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.Location = New System.Drawing.Point(231, 4)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(78, 23)
        Me.ButtonX6.TabIndex = 11
        Me.ButtonX6.Text = "Page Setup"
        '
        'Slider1
        '
        Me.Slider1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        Me.Slider1.Location = New System.Drawing.Point(454, 2)
        Me.Slider1.Maximum = 250
        Me.Slider1.Minimum = 25
        Me.Slider1.Name = "Slider1"
        Me.Slider1.Size = New System.Drawing.Size(393, 45)
        Me.Slider1.TabIndex = 2
        Me.Slider1.Text = "Zoom"
        Me.Slider1.Value = 100
        '
        'LabelX1
        '
        Me.LabelX1.Location = New System.Drawing.Point(307, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(35, 23)
        Me.LabelX1.TabIndex = 9
        Me.LabelX1.Text = "Page"
        '
        'LabelX2
        '
        Me.LabelX2.Location = New System.Drawing.Point(372, 10)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(16, 23)
        Me.LabelX2.TabIndex = 10
        Me.LabelX2.Text = "of"
        '
        'TextBoxX2
        '
        Me.TextBoxX2.Location = New System.Drawing.Point(336, 7)
        Me.TextBoxX2.Name = "TextBoxX2"
        Me.TextBoxX2.ReadOnly = True
        Me.TextBoxX2.Size = New System.Drawing.Size(34, 20)
        Me.TextBoxX2.TabIndex = 8
        Me.TextBoxX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxX1
        '
        Me.TextBoxX1.Location = New System.Drawing.Point(385, 7)
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.ReadOnly = True
        Me.TextBoxX1.Size = New System.Drawing.Size(34, 20)
        Me.TextBoxX1.TabIndex = 7
        Me.TextBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmPrintList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 413)
        Me.Controls.Add(Me.PrintPreviewControl1)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.TextBoxX2)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Slider1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Name = "frmPrintList"
        Me.Text = "Print Preview"
        CType(Me.Slider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnPrint As Button
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents btnFirst As Button
    Friend WithEvents ButtonX6 As Button
    Private WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Slider1 As TrackBar
    Friend WithEvents LabelX1 As Label
    Friend WithEvents LabelX2 As Label
    Friend WithEvents TextBoxX2 As TextBox
    Friend WithEvents TextBoxX1 As TextBox
End Class
