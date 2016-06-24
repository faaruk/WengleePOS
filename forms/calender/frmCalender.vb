Public Class frmCalender

    Private Sub frmCalender_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     



        Dim d As New Calendar.NET.CustomEvent
        d.Date = Today.AddDays(3)
        d.EventColor = Color.Red
        d.EventText = "New order to Wenglee"
        Calendar1.AddEvent(d.Clone)

    End Sub
End Class