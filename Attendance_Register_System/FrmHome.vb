Public Class FrmHome
    Private Sub FrmHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Enabled = True Then
            Me.WindowState = FormWindowState.Maximized
            MsgBox("Welcome to where lives are changed", MsgBoxStyle.Information, "HOME")
        End If
        If LblAttendances.Enabled Then
        ElseIf LblManage.Enabled Then
        End If
    End Sub

    Private Sub LblManage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LblManage.LinkClicked
        FrmManage.Show() 'showing home form
        Me.Hide()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Dim closing As DialogResult = MessageBox.Show("Are you sure you want to close the program?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If closing = DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub LblAttendances_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblAttendances.LinkClicked
        MarkAttendences.Show() 'showin mark attendances form 
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Days_Calculations.Show() ' showing days calculations form
        Me.Hide()
    End Sub
End Class