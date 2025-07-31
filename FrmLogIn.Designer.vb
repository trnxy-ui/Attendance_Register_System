<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogIn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogIn))
        Me.LblUname = New System.Windows.Forms.Label()
        Me.LblPassword = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chlShowPassword = New System.Windows.Forms.CheckBox()
        Me.lnkSignIn = New System.Windows.Forms.LinkLabel()
        Me.lblDays = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblask = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblUname
        '
        Me.LblUname.AutoSize = True
        Me.LblUname.Location = New System.Drawing.Point(330, 133)
        Me.LblUname.Name = "LblUname"
        Me.LblUname.Size = New System.Drawing.Size(71, 13)
        Me.LblUname.TabIndex = 0
        Me.LblUname.Text = "USER NAME"
        '
        'LblPassword
        '
        Me.LblPassword.AutoSize = True
        Me.LblPassword.Location = New System.Drawing.Point(330, 197)
        Me.LblPassword.Name = "LblPassword"
        Me.LblPassword.Size = New System.Drawing.Size(70, 13)
        Me.LblPassword.TabIndex = 1
        Me.LblPassword.Text = "PASSWORD"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(320, 162)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(261, 20)
        Me.txtUserName.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(320, 228)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(264, 20)
        Me.txtPassword.TabIndex = 3
        '
        'btnInsert
        '
        Me.btnInsert.BackColor = System.Drawing.Color.Lime
        Me.btnInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise
        Me.btnInsert.FlatAppearance.BorderSize = 5
        Me.btnInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.btnInsert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.btnInsert.ForeColor = System.Drawing.Color.Black
        Me.btnInsert.Location = New System.Drawing.Point(320, 312)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(134, 32)
        Me.btnInsert.TabIndex = 4
        Me.btnInsert.Text = "INSERT"
        Me.btnInsert.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(30, 93)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(238, 223)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'chlShowPassword
        '
        Me.chlShowPassword.AutoSize = True
        Me.chlShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chlShowPassword.Location = New System.Drawing.Point(333, 254)
        Me.chlShowPassword.Name = "chlShowPassword"
        Me.chlShowPassword.Size = New System.Drawing.Size(101, 17)
        Me.chlShowPassword.TabIndex = 6
        Me.chlShowPassword.Text = "Show password"
        Me.chlShowPassword.UseVisualStyleBackColor = True
        '
        'lnkSignIn
        '
        Me.lnkSignIn.AutoSize = True
        Me.lnkSignIn.Location = New System.Drawing.Point(173, 371)
        Me.lnkSignIn.Name = "lnkSignIn"
        Me.lnkSignIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lnkSignIn.Size = New System.Drawing.Size(80, 13)
        Me.lnkSignIn.TabIndex = 7
        Me.lnkSignIn.TabStop = True
        Me.lnkSignIn.Text = "SIGN IN HERE"
        '
        'lblDays
        '
        Me.lblDays.AutoSize = True
        Me.lblDays.Location = New System.Drawing.Point(662, 371)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Size = New System.Drawing.Size(13, 13)
        Me.lblDays.TabIndex = 8
        Me.lblDays.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wide Latin", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(315, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 26)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "LOG IN"
        '
        'lblask
        '
        Me.lblask.AutoSize = True
        Me.lblask.Location = New System.Drawing.Point(11, 371)
        Me.lblask.Name = "lblask"
        Me.lblask.Size = New System.Drawing.Size(0, 13)
        Me.lblask.TabIndex = 10
        '
        'FrmLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(698, 393)
        Me.Controls.Add(Me.lblask)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDays)
        Me.Controls.Add(Me.lnkSignIn)
        Me.Controls.Add(Me.chlShowPassword)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.LblPassword)
        Me.Controls.Add(Me.LblUname)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Name = "FrmLogIn"
        Me.Text = "LOG IN NOW"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblUname As System.Windows.Forms.Label
    Friend WithEvents LblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chlShowPassword As System.Windows.Forms.CheckBox
    Protected WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents lnkSignIn As System.Windows.Forms.LinkLabel
    Friend WithEvents lblDays As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblask As System.Windows.Forms.Label

End Class
