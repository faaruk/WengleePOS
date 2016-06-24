Public Class usrTaskView
    Dim MaxWidth_ As Integer = 0
    Property MaxWidth As Integer
        Get
            Return MaxWidth_
        End Get
        Set(value As Integer)
            lblHeader.MaximumSize = New Size(value, 1000)
            lblTask.MaximumSize = New Size(value, 1000)
            lblDetails.MaximumSize = New Size(value, 1000)
            MaxWidth_ = value
        End Set
    End Property

    Private Sub lblDetails_TextChanged(sender As Object, e As EventArgs) Handles lblDetails.TextChanged
        With lblDetails
            .Height = .CreateGraphics.MeasureString(.Text, .Font, .Width - 5).Height
        End With
    End Sub

    Private Sub lblHeader_TextChanged(sender As Object, e As EventArgs) Handles lblHeader.TextChanged
        With lblHeader
            .Height = .CreateGraphics.MeasureString(.Text, .Font, .Width - 5).Height
        End With
    End Sub

    Private Sub lblTask_TextChanged(sender As Object, e As EventArgs) Handles lblTask.TextChanged
        With lblTask
            .Height = .CreateGraphics.MeasureString(.Text, .Font, .Width - 5).Height
        End With
    End Sub

    Private Sub usrTaskView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub usrTaskView_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        MaxWidth = Me.Width
    End Sub

    Private Sub lblDetails_Click(sender As Object, e As EventArgs) Handles lblDetails.Click
        Me.InvokeOnClick(Me, Nothing)
    End Sub

    Private Sub lblTask_Click(sender As Object, e As EventArgs) Handles lblTask.Click
        Me.InvokeOnClick(Me, Nothing)

    End Sub

    Private Sub lblHeader_Click(sender As Object, e As EventArgs) Handles lblHeader.Click
        Me.InvokeOnClick(Me, Nothing)

    End Sub
End Class
