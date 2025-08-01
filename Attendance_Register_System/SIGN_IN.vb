Imports System.Data.OleDb
Public Class SIGN_IN
    Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dell\Documents\JEREMY_PROJECT\Jeremy_project\Attendance_Register_System\Attendance_Register_System\StudentInfo.mdb")
    Dim i, j As Integer

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmLogIn.Show()
        Me.Hide()
    End Sub
    Private Sub clear() 'Handlin clear
        txtPassword.Clear()
        TxtUserId.Clear()
        txtUserName.Clear()
        txtNewPassword.Clear()
        TxtNewUserId.Clear()
        txtNewUserName.Clear()
    End Sub

    Private Sub btnSignIn_Click(sender As Object, e As EventArgs) Handles btnSignIn.Click
        Try
            If txtPassword.Text = Nothing Or txtUserName.Text = Nothing Then
                MsgBox(" ENTER CREDENTIALS IN THE OLD INFORMATION TEXTBOXES PLEASE", MsgBoxStyle.Exclamation, "Form Administrator")
            Else
            End If
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd As New OleDbCommand("select count(*) from UserPassword where UserName=? and UserPassword=?", conn)
            cmd.Parameters.AddWithValue("@1", OleDbType.VarChar).Value = txtUserName.Text
            cmd.Parameters.AddWithValue("@2", OleDbType.VarChar).Value = txtPassword.Text
            Dim count = Convert.ToInt32(cmd.ExecuteScalar()) 'return present and absent as 1 or 0 
            If count > 0 Then 'validating
                Dim result As DialogResult = MessageBox.Show("Records matched! Do you want to add a new account now?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    delete()
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Dim insert As New OleDb.OleDbCommand("Insert into UserPassword(UserId,UserName,UserPassword) values(@UserId,@UserName,@userPassword)", conn)
                    insert.Parameters.Clear()
                    insert.Parameters.AddWithValue("@UserId", TxtNewUserId.Text)
                    insert.Parameters.AddWithValue("@UserName", txtNewUserName.Text)
                    insert.Parameters.AddWithValue("@UserPassword", txtNewPassword.Text)
                    i = insert.ExecuteNonQuery()
                    If i > 0 Then
                        Dim result1 As DialogResult = MessageBox.Show("Account successfully added!", "Form Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        FrmHome.Show()
                        Me.Hide()
                    Else
                        Dim failed As DialogResult = MessageBox.Show("Failed to add new account!", "Form Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                Dim failed As DialogResult = MessageBox.Show("Invalid account, you cannot change the account", "Form Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch error1 As Exception
            MsgBox(error1.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

    End Sub
    Private Sub delete()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim delete As New OleDb.OleDbCommand("Delete * from UserPassword where UserName=@UserName and UserPassword=@UserPassword", conn)
            delete.Parameters.Clear()
            delete.Parameters.AddWithValue("@UserName", txtUserName.Text)
            delete.Parameters.AddWithValue("@UserPassword", txtPassword.Text)
            i = delete.ExecuteNonQuery() 'Executing a delete query
            If i > 0 Then

            Else
                MsgBox("Failed to delete account", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Form Administrator")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub chlShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chlShowPassword.CheckedChanged
        If chlShowPassword.Checked Then 'handling checkbox
            txtNewPassword.UseSystemPasswordChar = False
        Else
            txtNewPassword.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub SIGN_IN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNewPassword.UseSystemPasswordChar = True
    End Sub
End Class