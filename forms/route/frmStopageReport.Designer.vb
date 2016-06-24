<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStopageReport
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
        Me.components = New System.ComponentModel.Container()
        Me.tblBranchBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dbWengLeeDataSet = New WengLee_Application.dbWengLeeDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tblBranchTableAdapter = New WengLee_Application.dbWengLeeDataSetTableAdapters.tblBranchTableAdapter()
        CType(Me.tblBranchBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbWengLeeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblBranchBindingSource
        '
        Me.tblBranchBindingSource.DataMember = "tblBranch"
        Me.tblBranchBindingSource.DataSource = Me.dbWengLeeDataSet
        '
        'dbWengLeeDataSet
        '
        Me.dbWengLeeDataSet.DataSetName = "dbWengLeeDataSet"
        Me.dbWengLeeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1097, 516)
        Me.ReportViewer1.TabIndex = 1
        '
        'tblBranchTableAdapter
        '
        Me.tblBranchTableAdapter.ClearBeforeFill = True
        '
        'frmStopageReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 516)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmStopageReport"
        Me.Text = "Route List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tblBranchBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbWengLeeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblBranchBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dbWengLeeDataSet As WengLee_Application.dbWengLeeDataSet
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblBranchTableAdapter As WengLee_Application.dbWengLeeDataSetTableAdapters.tblBranchTableAdapter
End Class
