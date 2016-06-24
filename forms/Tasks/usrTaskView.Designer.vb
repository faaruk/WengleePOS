<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrTaskView
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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.lblAssignTo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.MinimumSize = New System.Drawing.Size(171, 23)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(180, 23)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Date and Subject"
        '
        'lblTask
        '
        Me.lblTask.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTask.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTask.Location = New System.Drawing.Point(0, 23)
        Me.lblTask.MinimumSize = New System.Drawing.Size(171, 23)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(180, 23)
        Me.lblTask.TabIndex = 1
        Me.lblTask.Text = "Task"
        '
        'lblDetails
        '
        Me.lblDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(0, 46)
        Me.lblDetails.MinimumSize = New System.Drawing.Size(171, 23)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(180, 26)
        Me.lblDetails.TabIndex = 2
        Me.lblDetails.Text = "Details"
        '
        'lblAssignTo
        '
        Me.lblAssignTo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAssignTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignTo.Location = New System.Drawing.Point(0, 72)
        Me.lblAssignTo.MinimumSize = New System.Drawing.Size(171, 23)
        Me.lblAssignTo.Name = "lblAssignTo"
        Me.lblAssignTo.Size = New System.Drawing.Size(180, 23)
        Me.lblAssignTo.TabIndex = 3
        Me.lblAssignTo.Text = "Details"
        '
        'usrTaskView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblAssignTo)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblTask)
        Me.Controls.Add(Me.lblHeader)
        Me.Name = "usrTaskView"
        Me.Size = New System.Drawing.Size(180, 22)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblTask As Label
    Friend WithEvents lblDetails As Label
    Friend WithEvents lblAssignTo As System.Windows.Forms.Label
End Class
