Public Class frmCreateUser
    Dim objUser As New cls_tblUserDetails
    Dim objUserRules As New cls_tblUserRules
    Public editID As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtUserName.Text.Trim = "" Or txtPassword.Text.Trim = "" Then
            MsgBox("Username and Password cannot be blank", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtPassword.Text.Trim.Length < 6 Then
            MsgBox("Length of password must be greater than 6 characters", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If Not CheckForAlphaCharacters(txtPassword.Text) Then
            MsgBox("Password Must contain one alphabet", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If Not CheckForNumericCharacters(txtPassword.Text) Then
            MsgBox("Password Must contain one numeric character", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If Not CheckForSpecialCharacters(txtPassword.Text) Then
            MsgBox("Password Must contain one special character", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtFullName.Text.Trim = "" Then
            MsgBox("Fullname cannot be blank", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Try
            Dim UserId As Integer = 0
            If editID = 0 Then
                UserId = objUser.Insert(1, txtUserName.Text, Encrypt(txtPassword.Text), "OPERATOR", "OK", True, Now, Now, Now, UserId, Now, UserId, "2014-15", txtFullName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtEmail.Text)
            Else
                Dim ud As cls_tblUserDetails.Fields = objUser.Selection_One_Row(editID)
                objUser.Update(editID, 1, txtUserName.Text, Encrypt(txtPassword.Text), ud.UserType, ud.Status, ud.Enable, ud.LastLoginDate, ud.EnabledDate, ud.CreatedDate, ud.CreatedBy, Now, UserId, ud.Session, txtFullName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text, txtEmail.Text)
                UserId = editID
            End If

            Try
                objUserRules.Delete_By_SELECT("UserId=" & UserId.ToString)
            Catch ex As Exception
            End Try
            Dim Rules As String = ""
            For Each c As CheckBox In GroupBox1.Controls
                If c.Tag <> "" And c.Enabled Then
                    objUserRules.Insert(c.Tag, c.Checked, Now, UserId)
                    Rules += c.Tag + vbNewLine
                End If
            Next

            MsgBox("Saved", MsgBoxStyle.Information, "Info")
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Function CheckForAlphaCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function


    Function CheckForNumericCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Char.IsNumber(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function


    Function CheckForSpecialCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Not (Char.IsLetter(StringToCheck.Chars(i)) Or Char.IsNumber(StringToCheck.Chars(i))) Then
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub frmCreateUser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub frmCreateUser_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        If editID > 0 Then
            Dim ud As cls_tblUserDetails.Fields = objUser.Selection_One_Row(editID)
            txtUserName.Text = ud.UserName
            txtPassword.Text = Decrypt(ud.Password)
            txtFullName.Text = ud.FullName
            txtAddress.Text = ud.Address
            txtCity.Text = ud.City
            txtState.Text = ud.State
            txtPhone.Text = ud.Phone
            txtZip.Text = ud.Zip
            txtUserName.Text = ud.UserName
            txtEmail.Text = ud.Email

            For Each c As CheckBox In GroupBox1.Controls
                c.Checked = True
            Next
            Try
                Dim dt As DataTable = objUserRules.Selection(cls_tblUserRules.SelectionType.All, "UserId=" & editID.ToString)
                For Each dr As DataRow In dt.Rows
                    For Each c As CheckBox In GroupBox1.Controls
                        If c.Tag = dr("RuleName") Then
                            c.Checked = dr("Enabled")
                        End If
                    Next
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each c As CheckBox In GroupBox1.Controls
            c.Checked = False
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each c As CheckBox In GroupBox1.Controls
            c.Checked = True
        Next
    End Sub
End Class