<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalender
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
        Me.Calendar1 = New Calendar.NET.Calendar()
        Me.SuspendLayout()
        '
        'Calendar1
        '
        Me.Calendar1.AllowEditingEvents = True
        Me.Calendar1.CalendarDate = New Date(2014, 10, 10, 2, 25, 31, 372)
        Me.Calendar1.CalendarView = Calendar.NET.CalendarViews.Month
        Me.Calendar1.DateHeaderFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Calendar1.DayOfWeekFont = New System.Drawing.Font("Arial", 10.0!)
        Me.Calendar1.DaysFont = New System.Drawing.Font("Arial", 10.0!)
        Me.Calendar1.DayViewTimeFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Calendar1.DimDisabledEvents = True
        Me.Calendar1.HighlightCurrentDay = True
        Me.Calendar1.LoadPresetHolidays = True
        Me.Calendar1.Location = New System.Drawing.Point(12, 12)
        Me.Calendar1.Name = "Calendar1"
        Me.Calendar1.ShowArrowControls = True
        Me.Calendar1.ShowDashedBorderOnDisabledEvents = True
        Me.Calendar1.ShowDateInHeader = True
        Me.Calendar1.ShowDisabledEvents = True
        Me.Calendar1.ShowEventTooltips = True
        Me.Calendar1.ShowTodayButton = True
        Me.Calendar1.Size = New System.Drawing.Size(663, 559)
        Me.Calendar1.TabIndex = 0
        Me.Calendar1.TodayFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        '
        'frmCalender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 583)
        Me.Controls.Add(Me.Calendar1)
        Me.Name = "frmCalender"
        Me.Text = "frmCalender"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Calendar1 As Calendar.NET.Calendar
End Class
