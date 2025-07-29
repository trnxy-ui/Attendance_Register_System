Imports System.Data.OleDb
Public Class MarkAttendences
    Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dell\Documents\JEREMY PROJECT\Jeremy project\Attendance_Register_System\Attendance_Register_System\StudentInfo.mdb")
    Dim dr As OleDbDataReader
    Dim i As Integer
    Dim presence As String
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        FrmHome.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to Close the Programme?", "form administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result1 = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub MarkAttendences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized 'the form comes in full view mode
        LoadingDataGridView()
        loadingdatagridview2()
    End Sub

    Private Sub LoadingDataGridView()
        Try
            'initializing rows

            DataGridView1.Rows.Clear()
            conn.Open()
            Dim cmd As New OleDb.OleDbCommand("Select PersonId,PersonName,PersonSurname from PersonInfo", conn) 'making a variale that stores the select query
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("PersonId"), dr.Item("PersonName"), dr.Item("PersonSurname"))
            End While
       
        Catch ex As Exception
            MsgBox("Error :" & ex.Message)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close() 'closing the connection state
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Making sure that the records show in text boxes when the datagridview1 rows are being selected in 
        Try

            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If e.RowIndex >= 0 Then
                txtPersonId.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtPersonName.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
                txtPersonSurname.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Handling the 'mark' button
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            If rbnAbsent.Checked Then 'Handling the radio buttons
                presence = "Absent"
            Else
                presence = "Present"
            End If

            Dim cmd As New OleDb.OleDbCommand("Insert into Attendences (PersonId,PersonName,PersonSurname,Attendence_Status,Date_of_Attendence) values(@PersonId,@PersonName,@PersonSurname,@Attendence_Status,@Date_of_Attendence)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@PersonId", txtPersonId.Text)
            cmd.Parameters.AddWithValue("@PersonName", txtPersonName.Text)
            cmd.Parameters.AddWithValue("@PersonSurname", txtPersonSurname.Text)
            cmd.Parameters.AddWithValue("@Attendence_Status", presence)
            cmd.Parameters.AddWithValue("@Date_Of_Attendence", DateTime.Now.ToShortDateString)
            i = cmd.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Marked Sucessfully!", MessageBoxIcon.Information, "Form Administrator")
            Else
                MsgBox("Failed!", MessageBoxIcon.Information, "Form Administrator")
            End If
            DataGridView2.Rows.Clear()
            loadingdatagridview2()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try


        Days_Calculations.DataGridView1.Update()
    End Sub
    Private Sub loadingdatagridview2()
        'A function to load the datagrid view 2
        Try
            If conn.State = ConnectionState.Open Then conn.Close()

            DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            conn.Open()
            Dim cmd2 As New OleDb.OleDbCommand("Select * from Attendences ", conn)
            dr = cmd2.ExecuteReader()
            While dr.Read()
                DataGridView2.Rows.Add(dr.Item("PersonId"), dr.Item("PersonName"), dr.Item("PersonSurname"), dr.Item("Attendence_Status"), dr.Item("Date_of_Attendence"))

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            If dr IsNot Nothing Then
                dr.Close()
            End If


        End Try
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        'Making sure that the records show in text boxes when the datagridview2 rows are being selected in 
        Try

            DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If e.RowIndex >= 0 Then
                txtPersonId.Text = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtPersonName.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString()
                txtPersonSurname.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString()
                presence = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString()
                DtpDate.Value = CDate(DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString())
                If presence = "Present" Then
                    rbnPresent.Checked = True
                Else
                    rbnAbsent.Checked = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to delete this record", "form administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result1 = DialogResult.Yes Then
                Dim cmd As New OleDb.OleDbCommand("Delete from Attendences where PersonId=@PersonId", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@PersonId", txtPersonId.Text)
                i = cmd.ExecuteNonQuery()
                If i > 0 Then
                    MsgBox("Record successfully deleted", MsgBoxStyle.Information)
                Else
                    MsgBox("Failed", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                End If
            End If
            DataGridView2.Rows.Clear()
            loadingdatagridview2()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtPersonId.Clear()
        txtPersonName.Clear()
        txtPersonSurname.Clear()
        rbnAbsent.Checked = False
        rbnPresent.Checked = True
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'handling the search text box
        Try
            conn.Open()
            DataGridView2.Rows.Clear()
            Dim cmd As New OleDbCommand("select * from Attendences where Date_of_Attendence like '%" & txtSearch.Text & "%' or PersonSurname like '%" & txtSearch.Text & "%' or PersonName like '%" & txtSearch.Text & "%'", conn)
            dr = cmd.ExecuteReader
            While dr.Read 'adding the selected rows to the dataridview
                DataGridView2.Rows.Add(dr.Item("PersonId"), dr.Item("PersonName"), dr.Item("PersonSurname"), dr.Item("Attendence_Status"), dr.Item("Date_of_Attendence"))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        delete()
        LoadingDataGridView()
        loadingdatagridview2()
    End Sub
    Private Sub delete()
        Try 'Deletin all the rocords in a database
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim result As DialogResult = MessageBox.Show("You are going to delete the whole Mark Attedances database, are you up for that?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim ensure As DialogResult = MessageBox.Show("Are you really sure?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ensure = DialogResult.Yes Then
                    conn.Open()
                    Dim deleteEverything As New OleDb.OleDbCommand("Delete from Attendences", conn)
                    i = deleteEverything.ExecuteNonQuery()
                    If i > 0 Then
                        MsgBox("Deletion successfull!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Form Administrator")
                    Else
                        MsgBox("Failed!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Form Administrator")
                    End If
                    loadingdatagridview2()
                    LoadingDataGridView()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR :" & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub
End Class