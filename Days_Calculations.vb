Imports System.Data.OleDb 'Importing the Oledb data
Public Class Days_Calculations
    Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dell\Documents\JEREMY PROJECT\Jeremy project\Attendance_Register_System\Attendance_Register_System\StudentInfo.mdb")
    Dim dr As OleDbDataReader
    Dim i As Integer 'Global variables
    Dim presence As String

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmHome.Show()
        Me.Hide()
    End Sub

    Private Sub Days_Calculations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        loadingDgv2()
        Loadingdatagridview() 'Calling the sub procedure of loading a dataridview
        loadingFunctions()
        If lblDaysPassed.Text = LblTotalDays.Text Then
            clear()
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Handling close button
        Dim close As DialogResult = MessageBox.Show("Are you sure you want to close the programme?", "Form administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If close = DialogResult.Yes Then
            Me.Close()

        Else

            MsgBox("And we are back once again", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "For Administrator")
        End If
    End Sub

    Private Sub Loadingdatagridview()
        Try 'Handling exception
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open() 'opening connection
            Dim reading As New OleDb.OleDbCommand("Select PersonId,PersonName,PersonSurname,Sum(IIF(Attendence_Status='Present',1,0)) As Days_of_Presence,Sum(IIF(Attendence_Status='Absent',1,0)) As Days_of_Absence from Attendences Group by PersonId,PersonName,PersonSurname ", conn)
            dr = reading.ExecuteReader()
            DataGridView1.Rows.Clear()
            While dr.Read
                'adding columns to the datagrid view
                DataGridView1.Rows.Add(dr.Item("PersonId"), dr.Item("PersonName"), dr.Item("PersonSurname"), dr.Item("Days_of_Presence"), dr.Item("Days_of_Absence"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        'Handling button enter
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim reading As New OleDb.OleDbCommand("Select Count(*) from Total_days", conn)
            Dim j As Integer = Convert.ToInt32(reading.ExecuteScalar()) 'storin a returned result
            If j = 0 Then
                insert()
                loadingFunctions()
            ElseIf j > 0 Then
                delete()
                insert()
                loadingFunctions()
            Else
                MsgBox("Failed", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Form Administrator")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

    End Sub

    Private Sub totalDays() 'Returning total days
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim totaldays As New OleDb.OleDbCommand("Select Total_days_of_attendence from Total_days", conn)
            dr = totaldays.ExecuteReader()
            If dr.Read Then
                LblTotalDays.Text = dr.Item("Total_days_of_attendence").ToString()
            Else
                LblTotalDays.Text = 0 'store total days in a label
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub daysPassed() 'calculating days passed
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim totaldays As New OleDb.OleDbCommand("Select Days_Passed from Total_days", conn)
            dr = totaldays.ExecuteReader()
            If dr.Read Then
                lblDaysPassed.Text = dr.Item("Days_Passed").ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close() 'Close connection
        End Try
    End Sub
    Private Sub daysLeft() 'Calculating days left
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim totaldays As New OleDb.OleDbCommand("Select Days_Left from Total_days", conn)
            dr = totaldays.ExecuteReader()
            If dr.Read Then
                lblDaysLeft.Text = dr.Item("Days_Left").ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub clear() 'Handling clear
        lblDaysLeft.Text = 0
        lblDaysPassed.Text = 0
        LblTotalDays.Text = 0

    End Sub

    Private Sub updateTotal_days() 'Updating total days
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            Dim OpenigDate As Date = dtpOpening.Value
            Dim closingDate As Date = dtpclosing.Value
            Dim totalDays1 As Integer = DateDiff(DateInterval.Day, OpenigDate, closingDate)
            Dim CurrentDate As Date = dtpCurrent.Value
            Dim daysLeft1 As Integer = DateDiff(DateInterval.Day, CurrentDate, closingDate)
            If daysLeft1 <= 0 Then
                daysLeft1 = 0
            End If
            Dim daysPassed1 As Integer = DateDiff(DateInterval.Day, OpenigDate, CurrentDate)
            Dim input As New OleDb.OleDbCommand("Insert into Total_days(OpeningDate,ClosingDate,Total_days_of_attendence,Days_Left,Days_Passed,LastUpdate) values(@OpeningDate,@ClosingDate,@Total_days_of_attendence,@Days_Left,@Days_Passed,@LastUpdate)", conn)
            input.Parameters.Clear()
            input.Parameters.AddWithValue("@OpeningDate", OpenigDate.ToShortDateString())
            input.Parameters.AddWithValue("@ClosingDate", closingDate.ToShortDateString())
            input.Parameters.AddWithValue("@Total_days_of_attendence", totalDays1)
            input.Parameters.AddWithValue("@Days_Left", daysLeft1)
            input.Parameters.AddWithValue("@Days_Passed", daysPassed1)
            input.Parameters.AddWithValue("@LastUpdate", CurrentDate.ToShortDateString())
            i = input.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Successfully Updated the total days number!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Form Administrator")
            Else
                MsgBox("Failed!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Form Administrator")
            End If
            loadingDgv2()
        Catch ex As Exception
            MsgBox(ex.Message) 'returns a messege rather than crashing
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub delete() 'Deleting every record of total_days table
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim remove As New OleDb.OleDbCommand("Delete from Total_Days", conn)
            i = remove.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub insert() 'Handling insert
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            Dim OpenigDate As Date = dtpOpening.Value
            Dim closingDate As Date = dtpclosing.Value
            Dim totalDays1 As Integer = DateDiff(DateInterval.Day, OpenigDate, closingDate)
            Dim CurrentDate As Date = dtpCurrent.Value
            Dim daysLeft1 As Integer = DateDiff(DateInterval.Day, CurrentDate, closingDate)
            If daysLeft1 <= 0 Then
                daysLeft1 = 0
            End If
            Dim daysPassed1 As Integer = DateDiff(DateInterval.Day, OpenigDate, CurrentDate)
            Dim input As New OleDb.OleDbCommand("Insert into Total_days(OpeningDate,ClosingDate,Total_days_of_attendence,Days_Left,Days_Passed,LastUpdate) values(@OpeningDate,@ClosingDate,@Total_days_of_attendence,@Days_Left,@Days_Passed,@LastUpdate)", conn)
            input.Parameters.Clear()
            input.Parameters.AddWithValue("@OpeningDate", OpenigDate.ToShortDateString())
            input.Parameters.AddWithValue("@ClosingDate", closingDate.ToShortDateString())
            input.Parameters.AddWithValue("@Total_days_of_attendence", totalDays1)
            input.Parameters.AddWithValue("@Days_Left", daysLeft1)
            input.Parameters.AddWithValue("@Days_Passed", daysPassed1)
            input.Parameters.AddWithValue("@LastUpdate", CurrentDate.ToShortDateString())
            i = input.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Successfully created the total days number!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Form Administrator")
            Else
                MsgBox("Failed!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Form Administrator")
            End If
            loadingDgv2()
        Catch ex As Exception
            MsgBox(ex.Message) 'returns a messege rather than crashing
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub loadingDgv2()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim read As New OleDb.OleDbCommand("Select OpeningDate,ClosingDate,LastUpdate from Total_days ", conn)
            dr = read.ExecuteReader()
            dgvOpeningClosing.Rows.Clear()
            While dr.Read
                dgvOpeningClosing.Rows.Add(dr.Item("OpeningDate"), dr.Item("ClosingDate"), dr.Item("LastUpdate"))
                dtpOpening.Value = dr.Item("OpeningDate")
                dtpclosing.Value = dr.Item("ClosingDate")
                dtpCurrent.Value = dr.Item("LastUpdate")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If dr IsNot Nothing Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim reading As New OleDb.OleDbCommand("Select Count(*) from Total_days", conn)
            Dim j As Integer = Convert.ToInt32(reading.ExecuteScalar()) 'storing a returned result
            If j > 0 Then
                delete()
                updateTotal_days()

            Else
                MsgBox("No values to update", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Form Administrator")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        loadingFunctions()
    End Sub

    Private Sub loadingFunctions()
        totalDays() 'Calling the sub procedure of total days
        daysLeft() 'Calling the sub procedue of days left
        daysPassed() 'Calling the sub procedure of days passed
    End Sub

    Private Sub dgvOpeningClosing_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOpeningClosing.CellClick
        Try
            dgvOpeningClosing.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If e.RowIndex >= 0 Then
                dtpOpening.Value = CDate(dgvOpeningClosing.Rows(e.RowIndex).Cells(0).Value.ToString())
                dtpclosing.Value = CDate(dgvOpeningClosing.Rows(e.RowIndex).Cells(1).Value.ToString())
                dtpCurrent.Value = CDate(dgvOpeningClosing.Rows(e.RowIndex).Cells(2).Value.ToString())
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class