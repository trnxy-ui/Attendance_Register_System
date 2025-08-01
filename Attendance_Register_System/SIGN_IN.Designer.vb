<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SIGN_IN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SIGN_IN))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LablUserName = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnSignIn = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtUserId = New System.Windows.Forms.TextBox()
        Me.TxtNewUserId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.txtNewUserName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chlShowPassword = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(43, 78)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(238, 195)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'LablUserName
        '
        Me.LablUserName.AutoSize = True
        Me.LablUserName.Location = New System.Drawing.Point(364, 158)
        Me.LablUserName.Name = "LablUserName"
        Me.LablUserName.Size = New System.Drawing.Size(96, 13)
        Me.LablUserName.TabIndex = 7
        Me.LablUserName.Text = "OLD USER NAME"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(367, 242)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(98, 13)
        Me.lblPassword.TabIndex = 8
        Me.lblPassword.Text = " OLD PASSWORD"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 389)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(92, 13)
        Me.LinkLabel1.TabIndex = 9
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "BACK TO LOG IN"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(305, 192)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(312, 20)
        Me.txtUserName.TabIndex = 10
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(305, 271)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(312, 20)
        Me.txtPassword.TabIndex = 11
        '
        'btnSignIn
        '
        Me.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignIn.Location = New System.Drawing.Point(436, 335)
        Me.btnSignIn.Name = "btnSignIn"
        Me.btnSignIn.Size = New System.Drawing.Size(97, 23)
        Me.btnSignIn.TabIndex = 12
        Me.btnSignIn.Text = "SIGN IN"
        Me.btnSignIn.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.Location = New System.Drawing.Point(735, 335)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(97, 23)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(384, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "OLD USER ID "
        '
        'TxtUserId
        '
        Me.TxtUserId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtUserId.Location = New System.Drawing.Point(305, 108)
        Me.TxtUserId.Name = "TxtUserId"
        Me.TxtUserId.Size = New System.Drawing.Size(312, 20)
        Me.TxtUserId.TabIndex = 15
        '
        'TxtNewUserId
        '
        Me.TxtNewUserId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtNewUserId.Location = New System.Drawing.Point(738, 116)
        Me.TxtNewUserId.Name = "TxtNewUserId"
        Me.TxtNewUserId.Size = New System.Drawing.Size(312, 20)
        Me.TxtNewUserId.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(817, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "NEW USER ID"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(735, 271)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(315, 20)
        Me.txtNewPassword.TabIndex = 19
        '
        'txtNewUserName
        '
        Me.txtNewUserName.Location = New System.Drawing.Point(738, 192)
        Me.txtNewUserName.Name = "txtNewUserName"
        Me.txtNewUserName.Size = New System.Drawing.Size(312, 20)
        Me.txtNewUserName.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(800, 242)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "NEW PASSWORD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(797, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "NEW USER NAME"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wide Latin", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(420, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(242, 36)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "SIGN IN"
        '
        'chlShowPassword
        '
        Me.chlShowPassword.AutoSize = True
        Me.chlShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chlShowPassword.Location = New System.Drawing.Point(751, 297)
        Me.chlShowPassword.Name = "chlShowPassword"
        Me.chlShowPassword.Size = New System.Drawing.Size(101, 17)
        Me.chlShowPassword.TabIndex = 24
        Me.chlShowPassword.Text = "Show password"
        Me.chlShowPassword.UseVisualStyleBackColor = True
        '
        'SIGN_IN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1252, 411)
        Me.Controls.Add(Me.chlShowPassword)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtNewUserId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNewPassword)
        Me.Controls.Add(Me.txtNewUserName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtUserId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSignIn)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.LablUserName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "SIGN_IN"
        Me.Text = "SIGN_IN"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LablUserName As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnSignIn As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUserId As System.Windows.Forms.TextBox
    Friend WithEvents TxtNewUserId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNewUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chlShowPassword As System.Windows.Forms.CheckBox
End Class
