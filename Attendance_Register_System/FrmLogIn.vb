Imports System.Data.OleDb
Imports System.Data
Public Class FrmLogIn
    Dim i As Integer
    Dim dr As OleDbDataReader
    Dim connection As New OleDbConnection(My.Settings.StudentInfoConnectionString)
    Private Sub FrmLogIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If btnInsert.Focused Then
            btnInsert.BackColor = Color.AliceBlue
            btnInsert.FlatAppearance.MouseDownBackColor = Color.Azure

        End If
        lbldaysLeft()
        Try 'Being interactive
            If connection.State = ConnectionState.Open Then connection.Close()
            connection.Open()
            Dim cmd As New OleDbCommand("select count(*) from UserPassword", connection)
            Dim count = Convert.ToInt32(cmd.ExecuteScalar())
            If count > 0 Then
                lblask.Text = "Want to add new password?"
                lnkSignIn.Text = "CLICK HERE"
            Else
                lblask.Text = ""
                lnkSignIn.Text = "SIGN IN HERE"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        If txtPassword.Text = Nothing Or txtUserName.Text = Nothing Then
            MsgBox("ENTER CREDENTIALS PLEASE", MsgBoxStyle.Exclamation, "Form Administrator")
        Else
            If connection.State = ConnectionState.Closed Then

                connection.Open()
            End If
            Dim cmd As New OleDbCommand("select count(*) from UserPassword where UserName=? and UserPassword=?", connection)
            cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtUserName.Text
            cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtPassword.Text
            Dim count = Convert.ToInt32(cmd.ExecuteScalar()) 'return present and absent as 1 or 0 
            If count > 0 Then 'validating
                MsgBox("Logging In success", MsgBoxStyle.Information, "Form Administrator")
                Dim CheckAttendences As New OleDbCommand("Select Days_Left from Total_days", connection)
                i = Convert.ToInt32(CheckAttendences.ExecuteScalar())
                If i <= 0 Then
                    lblDays.Text = 0
                    Days_Calculations.Show()
                    If Days_Calculations.Enabled = True Then
                        MsgBox("Please insert the total days being attended", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Form Administrator")
                        Me.Hide()

                    End If
                Else
                    FrmHome.Show()
                    Me.Hide()
                End If

                txtUserName.Clear()
                txtPassword.Clear()

            Else
                MsgBox("Account not found check credentials", MsgBoxStyle.Critical, "Form Administrator")
            End If
        End If
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        txtPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chlShowPassword.CheckedChanged
        If chlShowPassword.Checked Then 'handling checkbox
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSignIn.LinkClicked
        SIGN_IN.Show()
        Me.Hide()
    End Sub

    Private Sub lbldaysLeft()
        Try
            If connection.State = ConnectionState.Open Then connection.Close()
            connection.Open()
            Dim totaldays As New OleDbCommand("Select Days_Left from Total_Days", connection)
            dr = totaldays.ExecuteReader()
            If dr.Read Then
                lblDays.Text = dr.Item("Days_Left")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
            If dr IsNot Nothing Then dr.Close()
        End Try
    End Sub
End Class