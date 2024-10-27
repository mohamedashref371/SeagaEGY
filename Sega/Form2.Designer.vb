<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Sega2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.downloadLink = New System.Windows.Forms.LinkLabel()
        Me.f1 = New System.Windows.Forms.Label()
        Me.B = New System.Windows.Forms.Label()
        Me.A = New System.Windows.Forms.Label()
        Me.I = New System.Windows.Forms.LinkLabel()
        Me.MyP = New System.Windows.Forms.LinkLabel()
        Me.f2 = New System.Windows.Forms.Label()
        Me.f3 = New System.Windows.Forms.Label()
        Me.f4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'downloadLink
        '
        Me.downloadLink.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.downloadLink.AutoSize = True
        Me.downloadLink.BackColor = System.Drawing.Color.Transparent
        Me.downloadLink.Font = New System.Drawing.Font("Tahoma", 13.0!)
        Me.downloadLink.ForeColor = System.Drawing.Color.Lime
        Me.downloadLink.LinkColor = System.Drawing.Color.HotPink
        Me.downloadLink.Location = New System.Drawing.Point(47, 19)
        Me.downloadLink.Name = "downloadLink"
        Me.downloadLink.Size = New System.Drawing.Size(462, 22)
        Me.downloadLink.TabIndex = 33
        Me.downloadLink.TabStop = True
        Me.downloadLink.Text = "Click here  to download the latest version of the program"
        '
        'f1
        '
        Me.f1.Location = New System.Drawing.Point(95, 58)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(25, 25)
        Me.f1.TabIndex = 34
        '
        'B
        '
        Me.B.AutoSize = True
        Me.B.BackColor = System.Drawing.Color.Transparent
        Me.B.Cursor = System.Windows.Forms.Cursors.Hand
        Me.B.Font = New System.Drawing.Font("Tahoma", 27.0!)
        Me.B.Image = Global.Sega.My.Resources.Resources.Family_Kings_and_Queens_of_Computer2
        Me.B.Location = New System.Drawing.Point(486, 67)
        Me.B.Name = "B"
        Me.B.Size = New System.Drawing.Size(52, 43)
        Me.B.TabIndex = 31
        Me.B.Text = "   "
        '
        'A
        '
        Me.A.AutoSize = True
        Me.A.BackColor = System.Drawing.Color.Transparent
        Me.A.Cursor = System.Windows.Forms.Cursors.Hand
        Me.A.Font = New System.Drawing.Font("Tahoma", 27.0!)
        Me.A.Image = Global.Sega.My.Resources.Resources.Family_Kings_and_Queens_of_Computer
        Me.A.Location = New System.Drawing.Point(12, 67)
        Me.A.Name = "A"
        Me.A.Size = New System.Drawing.Size(52, 43)
        Me.A.TabIndex = 30
        Me.A.Text = "   "
        '
        'I
        '
        Me.I.ActiveLinkColor = System.Drawing.Color.Fuchsia
        Me.I.AutoSize = True
        Me.I.BackColor = System.Drawing.Color.Transparent
        Me.I.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.I.LinkColor = System.Drawing.Color.Lime
        Me.I.Location = New System.Drawing.Point(149, 58)
        Me.I.Name = "I"
        Me.I.Size = New System.Drawing.Size(252, 24)
        Me.I.TabIndex = 1
        Me.I.TabStop = True
        Me.I.Text = "Mohamed Ashraf - Youtube"
        '
        'MyP
        '
        Me.MyP.ActiveLinkColor = System.Drawing.Color.Aqua
        Me.MyP.AutoSize = True
        Me.MyP.BackColor = System.Drawing.Color.Transparent
        Me.MyP.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.MyP.LinkColor = System.Drawing.Color.Red
        Me.MyP.Location = New System.Drawing.Point(100, 82)
        Me.MyP.Name = "MyP"
        Me.MyP.Size = New System.Drawing.Size(350, 24)
        Me.MyP.TabIndex = 0
        Me.MyP.TabStop = True
        Me.MyP.Text = "Family Kings and Queens of Computer"
        '
        'f2
        '
        Me.f2.Location = New System.Drawing.Point(434, 58)
        Me.f2.Name = "f2"
        Me.f2.Size = New System.Drawing.Size(25, 25)
        Me.f2.TabIndex = 35
        '
        'f3
        '
        Me.f3.Image = Global.Sega.My.Resources.Resources.FaceBook
        Me.f3.Location = New System.Drawing.Point(75, 82)
        Me.f3.Name = "f3"
        Me.f3.Size = New System.Drawing.Size(25, 25)
        Me.f3.TabIndex = 36
        '
        'f4
        '
        Me.f4.Image = Global.Sega.My.Resources.Resources.FaceBook
        Me.f4.Location = New System.Drawing.Point(450, 82)
        Me.f4.Name = "f4"
        Me.f4.Size = New System.Drawing.Size(25, 25)
        Me.f4.TabIndex = 37
        '
        'Sega2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(548, 118)
        Me.Controls.Add(Me.f4)
        Me.Controls.Add(Me.f3)
        Me.Controls.Add(Me.f2)
        Me.Controls.Add(Me.f1)
        Me.Controls.Add(Me.downloadLink)
        Me.Controls.Add(Me.B)
        Me.Controls.Add(Me.A)
        Me.Controls.Add(Me.I)
        Me.Controls.Add(Me.MyP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Sega2"
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MyP As LinkLabel
    Friend WithEvents I As LinkLabel
    Friend WithEvents A As Label
    Friend WithEvents B As Label
    Friend WithEvents downloadLink As LinkLabel
    Friend WithEvents f1 As Label
    Friend WithEvents f2 As Label
    Friend WithEvents f3 As Label
    Friend WithEvents f4 As Label
End Class
