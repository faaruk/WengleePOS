﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockFutureOrdersFz
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.chkFrozen = New System.Windows.Forms.CheckBox()
        Me.chkFresh = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.lblTotalFrozen = New System.Windows.Forms.Label()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(8, 700)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 36)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(963, 700)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(136, 36)
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'chkFrozen
        '
        Me.chkFrozen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkFrozen.AutoSize = True
        Me.chkFrozen.Checked = True
        Me.chkFrozen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFrozen.Location = New System.Drawing.Point(701, 11)
        Me.chkFrozen.Name = "chkFrozen"
        Me.chkFrozen.Size = New System.Drawing.Size(58, 17)
        Me.chkFrozen.TabIndex = 8
        Me.chkFrozen.Text = "Frozen"
        Me.chkFrozen.UseVisualStyleBackColor = True
        Me.chkFrozen.Visible = False
        '
        'chkFresh
        '
        Me.chkFresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkFresh.AutoSize = True
        Me.chkFresh.Location = New System.Drawing.Point(632, 11)
        Me.chkFresh.Name = "chkFresh"
        Me.chkFresh.Size = New System.Drawing.Size(52, 17)
        Me.chkFresh.TabIndex = 9
        Me.chkFresh.Text = "Fresh"
        Me.chkFresh.UseVisualStyleBackColor = True
        Me.chkFresh.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(970, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 27)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Show"
        Me.Button2.UseVisualStyleBackColor = True
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
        Me.dgHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgHistory.Location = New System.Drawing.Point(0, 38)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.RowHeadersVisible = False
        Me.dgHistory.Size = New System.Drawing.Size(1112, 657)
        Me.dgHistory.TabIndex = 0
        '
        'chkStatus
        '
        Me.chkStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Checked = True
        Me.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStatus.Location = New System.Drawing.Point(806, 11)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(140, 17)
        Me.chkStatus.TabIndex = 10
        Me.chkStatus.Text = "Exclude Orders On Hold"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'lblTotalFrozen
        '
        Me.lblTotalFrozen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTotalFrozen.AutoSize = True
        Me.lblTotalFrozen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFrozen.Location = New System.Drawing.Point(170, 712)
        Me.lblTotalFrozen.Name = "lblTotalFrozen"
        Me.lblTotalFrozen.Size = New System.Drawing.Size(82, 13)
        Me.lblTotalFrozen.TabIndex = 11
        Me.lblTotalFrozen.Text = "Total Frozen:"
        '
        'frmStockFutureOrdersFz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1111, 741)
        Me.Controls.Add(Me.lblTotalFrozen)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.chkFrozen)
        Me.Controls.Add(Me.chkFresh)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgHistory)
        Me.Name = "frmStockFutureOrdersFz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price History"
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents chkFrozen As System.Windows.Forms.CheckBox
    Friend WithEvents chkFresh As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgHistory As System.Windows.Forms.DataGridView
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents lblTotalFrozen As System.Windows.Forms.Label
End Class
