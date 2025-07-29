Imports System.Data.OleDb 'imports the oledb functios in order to manipulate the database
Imports System.IO 'importing system input and output
Imports System.IO.FileStream
Imports System.Drawing.Image
Public Class FrmManage
    'creating the directory to my microsoft access
    Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dell\Documents\JEREMY PROJECT\Jeremy project\Attendance_Register_System\Attendance_Register_System\StudentInfo.mdb")
    Dim currentRow As Integer = -1
    Dim dr As OleDbDataReader
    Dim i As Integer
    Dim sex As String

    Private Sub FrmManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized 'the form opens in full view mode
        rbMale.Checked = True
        Try
            conn.Open() 'open connection
            lblConnstate.Text = "Connected"
            lblConnstate.ForeColor = Color.Lime
        Catch ex As Exception
            lblConnstate.Text = "Disconnected"
            lblConnstate.ForeColor = Color.Red
        End Try
        conn.Close() 'close connection
        LoadingDatagridview()
    End Sub
    Sub LoadingDatagridview()
        Try
            DataGridView1.Rows.Clear() 'initializing rows
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            Dim cmd As New OleDb.OleDbCommand("select * from PersonInfo", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("PersonId"), dr.Item("PersonName"), dr.Item("PersonSurname"), dr.Item("Sex"), dr.Item("DateOfBirth"), dr.Item("Phonenumber"), dr.Item("Class"), dr.Item("picture"), dr.Item("Address"), dr.Item("Parent's/Guardian'sPhonenumber"))
            End While
        Catch ex As Exception 'producing an error message rather than crashing
            Dim rather As DialogResult = MessageBox.Show(ex.Message)

        Finally
            If dr IsNot Nothing Then dr.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

    End Sub
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
    Sub save()
        'handling save button
        Try
            conn.Open()
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to insert this record?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If rbMale.Checked Then
                    sex = "Male"
                Else
                    sex = "Female"
                End If
                Dim ms As New MemoryStream()
                If PictureBox1.Image IsNot Nothing Then
                    PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                End If
                Dim ImgBytes As Byte() = ms.ToArray() 'insert the image
                Dim cmd1 As New OleDb.OleDbCommand("Insert into PersonInfo(PersonId,PersonName,PersonSurname,Sex,DateOfBirth,Phonenumber,Class,picture,Address,[Parent's/Guardian'sPhonenumber]) Values(@PesonId,@PersonName,@PersonSurname,@Sex,@DateOfBirth,@Phonenumber,@Class,@picture,@Address,@Parentphone)", conn)
                cmd1.Parameters.Clear() 'clears parameters
                cmd1.Parameters.AddWithValue("@PersonId", txtPersonId.Text)
                cmd1.Parameters.AddWithValue("@PersonName", txtPersonName.Text)
                cmd1.Parameters.AddWithValue("@PersonSurname", txtPersonSurname.Text)
                cmd1.Parameters.AddWithValue("@Sex", sex)
                cmd1.Parameters.AddWithValue("@DateOfBirth", dtpDateOfBirth.Value.ToShortDateString())
                cmd1.Parameters.AddWithValue("@Phonenumber", txtPhonenumber.Text)
                cmd1.Parameters.AddWithValue("@Class", txtClass.Text)
                cmd1.Parameters.AddWithValue("@picture", txtPicture.Text)
                cmd1.Parameters.AddWithValue("@Address", txtAddress.Text)
                cmd1.Parameters.AddWithValue("@Parentphone", txtParName.Text)
                i = cmd1.ExecuteNonQuery

                If i > 0 Then 'Validating the records
                    MsgBox(" successfully added ", MsgBoxStyle.Information, "Form Administrator")
                    clear()
                Else
                    MsgBox(" not added", MsgBoxStyle.Critical, "Form Administrator")
                End If

            End If
        Catch ex As Exception
            Dim noth As DialogResult = MessageBox.Show(ex.Message, "form administrator", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        Finally
            conn.Close()
            LoadingDatagridview()
        End Try
    End Sub
    Sub clear()
        'handling clear
        Try
            txtPersonId.Text = ""
            txtPersonName.Clear()
            txtPersonSurname.Clear()
            txtPhonenumber.Clear()
            txtClass.Clear()
            txtPicture.Clear()
            txtParName.Clear()
            txtAddress.Clear()
            Dim tempimage As Image = PictureBox1.Image
            PictureBox1.Image = Nothing
            If tempimage IsNot Nothing Then
                tempimage.Dispose()
            End If
            rbMale.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        'handling the search text box
        Try
            conn.Open()
            DataGridView1.Rows.Clear()
            Dim cmd4 As New OleDbCommand("select * from PersonInfo where PersonName like '%" & txtSearch.Text & "%' or Personsurname like '%" & txtSearch.Text & "%'", conn)
            dr = cmd4.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("PersonId"), dr.Item("PersonName"), dr.Item("PersonSurname"), dr.Item("Sex"), dr.Item("DateOfBirth"), dr.Item("Phonenumber"), dr.Item("Class"), dr.Item("picture"), dr.Item("Address"), dr.Item("Parent's/Guardian'sPhonenumber"))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        save()
    End Sub

    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        'handling the delete button
        Try
            conn.Open()
            Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to delete this record", "form administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result1 = DialogResult.Yes Then
                Dim cmd2 As New OleDbCommand("delete from PersonInfo where PersonId=@PersonId", conn)
                cmd2.Parameters.Clear()
                cmd2.Parameters.AddWithValue("@PersonId", txtPersonId.Text)
                i = cmd2.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Record successfully deleted", MsgBoxStyle.Information)
                Else
                    MsgBox("Failed", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                End If
            End If
        Catch ex As Exception
            Dim noth As DialogResult = MessageBox.Show("Please insert the record to delete", "form administrator", MessageBoxButtons.OK)
        Finally
            conn.Close()
            LoadingDatagridview()
            clear()
        End Try
    End Sub

    Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'handling the update button
        Try
            conn.Open()
            Dim cmd3 As New OleDbCommand("Update PersonInfo set PersonId=@PersonId,PersonName=@PersonName,PersonSurname=@PersonSurname,Sex=@Sex,DateOfBirth=@DateOfBirth,Phonenumber=@Phonenumber,Class=@Class,picture=@picture,Address=@Address,[Parent's/Guardian'sPhonenumber]=@ParentsPhoneNumber where PersonId=@PersonId", conn)
            If rbMale.Checked Then
                sex = "Male"
            Else
                sex = "Female"
            End If
            cmd3.Parameters.Clear()
            cmd3.Parameters.AddWithValue("@PersonId", txtPersonId.Text)
            cmd3.Parameters.AddWithValue("@PersonName", txtPersonName.Text)
            cmd3.Parameters.AddWithValue("@PersonSurname", txtPersonSurname.Text)
            cmd3.Parameters.AddWithValue("@sex", sex)
            cmd3.Parameters.AddWithValue("@DateOfBirth", dtpDateOfBirth.Value.ToShortDateString())
            cmd3.Parameters.AddWithValue("@Phonenumber", txtPhonenumber.Text)
            cmd3.Parameters.AddWithValue("@Class", txtClass.Text)
            If String.IsNullOrEmpty(txtPicture.Text) Then
                cmd3.Parameters.AddWithValue("@picture", DBNull.Value)
            Else
                cmd3.Parameters.AddWithValue("@picture", txtPicture.Text)
            End If
            cmd3.Parameters.AddWithValue("@Address", txtAddress.Text)
            cmd3.Parameters.AddWithValue("@ParentsPhoneNumber", txtParName.Text)
            i = cmd3.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Record successfully updated", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                clear()
            Else
                MsgBox("Failed to update", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox("error during update :" & ex.Message, MsgBoxStyle.Critical)
        Finally

            conn.Close()

        End Try
        LoadingDatagridview()
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            'handling the select-one-select-all function to te rows of the datagridview
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            If e.RowIndex >= 0 Then
                'making sure datagrid view values appear in text boxes

                txtPersonId.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtPersonName.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
                txtPersonSurname.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
                sex = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString()
                dtpDateOfBirth.Value = CDate(DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString())
                txtPhonenumber.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtClass.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString()
                txtPicture.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString()
                If sex = "Male" Then
                    rbMale.Checked = True
                Else
                    rbFemale.Checked = True
                End If
            End If
            'handling when the pictures will appear in the piturebox
            If Not IsDBNull(DataGridView1.Rows(e.RowIndex).Cells(7).Value) Then
                Dim imgpath As String = If(DataGridView1.Rows(e.RowIndex).Cells(7).Value, "".ToString())

                If Not String.IsNullOrEmpty(imgpath) AndAlso File.Exists(imgpath) Then
                    PictureBox1.Image = Image.FromFile(imgpath)
                Else
                    Dim tempimage As Image = PictureBox1.Image
                    PictureBox1 = Nothing
                    If tempimage IsNot Nothing Or txtPicture.Text = "" Then
                        tempimage.Dispose()
                    End If
                End If
            End If
            txtAddress.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString()
            txtParName.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString()
                catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateOfBirth.ValueChanged
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        'handling the close button
        Dim mes As DialogResult = MessageBox.Show("Are you sure you want to close the program?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If mes = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub DomainUpDown1_SelectedItemChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub txtPicture_TextChanged(sender As Object, e As EventArgs) Handles txtPicture.TextChanged
        If (System.IO.File.Exists(txtPicture.Text)) Then
            PictureBox1.Image = Image.FromFile(txtPicture.Text)

        End If
        If txtPicture.Text = "" Then
            PictureBox1.Hide()
        Else
            PictureBox1.Show()
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image File|*.jpg;*.png;*.jpeg;*.bmp" 'extract all types of images
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            txtPicture.Text = openFileDialog.FileName.ToString() 'insert the pictures directory and name in the pIcture textbox
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        FrmHome.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        'Moving to the last record
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0)
        Else
            MessageBox.Show("No records found")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        'moving to the first record
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)
        Else
            MessageBox.Show("No records found")
        End If
    End Sub
    Private Sub LoadingCurrentRow()
        Try
            If currentRow >= 0 AndAlso currentRow < DataGridView1.Rows.Count Then
                'handling the select-one-select-all function to te rows of the datagridview
                DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                'making sure datagrid view values appear in text boxes
                If DataGridView1.Rows(currentRow).Cells(0).Value.ToString IsNot Nothing Then
                    txtPersonId.Text = DataGridView1.Rows(currentRow).Cells(0).Value.ToString()
                End If
                If DataGridView1.Rows(currentRow).Cells(1).Value.ToString IsNot Nothing Then

                    txtPersonName.Text = DataGridView1.Rows(currentRow).Cells(1).Value.ToString()
                End If
                If DataGridView1.Rows(currentRow).Cells(2).Value.ToString IsNot Nothing Then

                    txtPersonSurname.Text = DataGridView1.Rows(currentRow).Cells(2).Value.ToString()
                End If
                If DataGridView1.Rows(currentRow).Cells(3).Value.ToString IsNot Nothing Then

                    sex = DataGridView1.Rows(currentRow).Cells(3).Value.ToString()
                End If
                If DataGridView1.Rows(currentRow).Cells(4).Value.ToString IsNot Nothing Then

                    dtpDateOfBirth.Value = CDate(DataGridView1.Rows(currentRow).Cells(4).Value.ToString())
                End If
                If DataGridView1.Rows(currentRow).Cells(5).Value.ToString IsNot Nothing Then

                    txtPhonenumber.Text = DataGridView1.Rows(currentRow).Cells(5).Value.ToString()
                End If
                If DataGridView1.Rows(currentRow).Cells(6).Value.ToString IsNot Nothing Then

                    txtClass.Text = DataGridView1.Rows(currentRow).Cells(6).Value.ToString()
                End If
                If DataGridView1.Rows(currentRow).Cells(7).Value.ToString IsNot Nothing Then

                    txtPicture.Text = DataGridView1.Rows(currentRow).Cells(7).Value.ToString()
                End If
                If sex = "Male" Then
                    rbMale.Checked = True
                Else
                    rbFemale.Checked = True
                End If

                'handling when the pictures will appear in the piturebox
                If Not IsDBNull(DataGridView1.Rows(currentRow).Cells(7).Value) Then
                    Dim imgpath As String = If(DataGridView1.Rows(currentRow).Cells(7).Value, "".ToString())

                    If Not String.IsNullOrEmpty(imgpath) AndAlso File.Exists(imgpath) Then
                        PictureBox1.Image = Image.FromFile(imgpath)
                    Else
                        Dim tempimage As Image = PictureBox1.Image
                        PictureBox1 = Nothing
                        If tempimage IsNot Nothing Or txtPicture.Text = "" Then
                            tempimage.Dispose()
                        End If
                    End If
                End If
                If DataGridView1.Rows(currentRow).Cells(8).Value.ToString IsNot Nothing Then

                    txtAddress.Text = DataGridView1.Rows(currentRow).Cells(8).Value.ToString()
                End If
                If DataGridView1.Rows(currentRow).Cells(9).Value.ToString IsNot Nothing Then

                    txtParName.Text = DataGridView1.Rows(currentRow).Cells(9).Value.ToString()
                End If
                    DataGridView1.CurrentCell = DataGridView1.Rows(currentRow).Cells(0)
                DataGridView1.Rows(currentRow).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        'Handlng the 'next' button
        Try
            If currentRow < DataGridView1.Rows.Count Then
                currentRow += 1
                LoadingCurrentRow()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        'Handling the previous button
        Try
            If currentRow > 0 Then
                currentRow -= 1
                LoadingCurrentRow()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Delete()
    End Sub

    Private Sub Delete()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            Dim result As DialogResult = MessageBox.Show("You are going to delete the Person  whole  Info database, are you up for that?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim ensure As DialogResult = MessageBox.Show("Are you really sure?", "Form Administrator", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ensure = DialogResult.Yes Then
                    conn.Open()
                    Dim deleteEverything As New OleDb.OleDbCommand("Delete from PersonInfo", conn)
                    i = deleteEverything.ExecuteNonQuery()
                    If i > 0 Then
                        MsgBox("Deletion successfull!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Form Administrator")
                    Else
                        MsgBox("Failed!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Form Administrator")
                    End If
                    LoadingDatagridview()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR :" & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub
End Class