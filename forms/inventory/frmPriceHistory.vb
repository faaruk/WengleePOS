Public Class frmPriceHistory
    Dim objProductPrice As New cls_tblProductPrice

    Private _ProductID As Integer = 0

    Public Property ProductId As Integer
        Get
            Return _ProductID
        End Get
        Set(value As Integer)
            _ProductID = value
            LoadList()
        End Set
    End Property

    Sub LoadList()

        Try

            Dim dt As DataTable = objProductPrice.Selection(cls_tblProductPrice.SelectionType.All_With_user, "[PID]=" & _ProductID.ToString & " Order By ItemSl Desc")
            dgHistory.DataSource = dt
            dgHistory.Columns("PID").Visible = False
            dgHistory.Columns("UserId").Visible = False
            dgHistory.Columns("ItemSl").Visible = False
            dgHistory.Columns("CostPrice").HeaderText = "C.P."
            dgHistory.Columns("SellPrice").HeaderText = "S.P."
            dgHistory.Columns("UserName").HeaderText = "By"
            dgHistory.Columns("CostPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgHistory.Columns("SellPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgHistory.Columns(" ").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmPriceHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmPriceHistory_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        Try
            dgHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgHistory.Columns(" ").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class