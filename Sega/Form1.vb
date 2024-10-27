Public Class Sega
    Dim sg As String = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData.Replace(Application.ProductVersion, "")
    Dim msg As MsgBoxStyle = vbInformation
    Dim split As String = "\"
    Dim temp As Integer
    Dim busy As Boolean = False
    Dim swap As Integer = -1
    Dim lwz As Integer = 2
    Dim lwc As Integer = 2
    Dim plyFrst As Integer = 0
    Dim sn As Integer = 1
    Dim keyboard As Boolean = True
    Dim hold As Boolean = False
    Dim undo1 As String = ""
    Dim redo1 As String = ""
    Dim img As Boolean = False
    Dim ok As Integer = 0
    Dim buttons As Integer = 1
    Dim bgClr As Integer = 245
    Dim theBest As Integer = 0

    Dim theGame As New List(Of Integer)
    Dim fastGame As New List(Of Integer)
    Dim thePieces As New List(Of PictureBox)
    Dim locations As New List(Of Point) ' Locations of Pieces
    Dim originalLocations As List(Of Point)

    Dim clr As Color
    Dim bitmap As Bitmap
    Dim zx As Boolean = False
    Dim cv As Boolean = False
    Dim images As New List(Of Bitmap) ' from My.Resources
    Dim readyImages As New List(Of Bitmap)

    Private Sub Sega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = Icon.FromHandle(My.Resources.cv.GetHicon())
        If Not CheckHash(Sega2.LMhmd.Text, Sega2.Ihash) Then End
        ld.Enabled = My.Computer.FileSystem.FileExists(sg + "save.seaga")
        thePieces.AddRange({PB1, z1, z2, z3, a1, a2, a3, c1, c2, c3})
        For i = 0 To thePieces.Count - 1
            locations.Add(thePieces(i).Location)
        Next
        images.AddRange({My.Resources.zx, My.Resources.cv, My.Resources.Rotat, My.Resources.XO3, My.Resources.XO7, My.Resources._as, My.Resources.sleep, My.Resources.win})

        ' theGame(0) is player role, 10 is selected piece, 11-13, 17-19 is movementOfPieces, 14 is level, 15 is who started playing first, 16 is style of game
        theGame.AddRange({3, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 4, 3, 0, 0, 0, 0, 2})
        fastGame.AddRange({0, 1, 2, 3, 4, 5, 6, 7, 8, 9})
        iLevel() : plyFrstN() : nsn() ' سيكون هنا عربي وانجليزي بدل هذا السطر
        pic() : XO5()
        Text = Text.Replace(".371.3317", "")
    End Sub

#Region "Keys and Mouse 🤷‍"
    Private Sub nm12_Key(sender As Object, e As KeyEventArgs) Handles name1.KeyDown, name2.KeyDown, fst.KeyDown, fstAr.KeyDown
        If e.KeyCode = Keys.F11 Then
            keyboard = True
            name1.Visible = False
            name2.Visible = False
            fst.Visible = False : fstAr.Visible = False
            name1.Visible = True
            name2.Visible = True
            If buttons = 5 Then
                If lang.Text = "عربي" Then
                    fstAr.Visible = True
                Else
                    fst.Visible = True
                End If
            End If
        End If
        If keyboard Then
            If e.KeyCode = Keys.F2 Then
                If sv.Enabled = True Then
                    sve()
                End If
            ElseIf e.KeyCode = Keys.F4 Then
                If ld.Enabled = True Then
                    lde()
                End If
            ElseIf e.KeyCode = Keys.F8 Then
                If bgClr < 255 Then
                    bgClr += 1
                End If
                clr2()
            ElseIf e.KeyCode = Keys.F6 Then
                If bgClr > 185 Then
                    bgClr -= 1
                End If
                clr2()
            ElseIf e.KeyCode = Keys.F9 Then
                theBest = Not theBest
            ElseIf e.KeyCode = Keys.F10 Then
                If help.Visible Then
                    helping()
                End If
            ElseIf e.KeyCode = Keys.F5 Then
                If ok1.Visible Then
                    If Not ok1.Checked OrElse Not ok2.Checked Then
                        ok1.Checked = True : ok2.Checked = True
                    Else
                        ok1.Checked = False
                        If Not computer.Checked Then ok2.Checked = False
                    End If
                End If
            ElseIf e.KeyCode = Keys.F7 Then
                img2()
            ElseIf e.KeyCode = Keys.F12 Then
                B5()
            ElseIf e.KeyCode = Keys.F1 Then
                RstA()
            ElseIf e.KeyCode = Keys.F3 Then
                Rst()
            End If
        End If
    End Sub

    Private Sub Sega_Key(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, MyClass.KeyDown, Me.KeyDown, Bu1.KeyDown, rest.KeyDown, restA.KeyDown, start.KeyDown, Bu5.KeyDown, Bu6.KeyDown, Bu7.KeyDown, lang.KeyDown, help.KeyDown, B10.KeyDown, B11.KeyDown, XO.KeyDown, OX.KeyDown, secret.KeyDown, level.KeyDown, computer.KeyDown, playFirst.KeyDown, undo.KeyDown, redo.KeyDown, ok1.KeyDown, ok2.KeyDown, NoS.KeyDown, VaH.KeyDown, ns.KeyDown, nsAr.KeyDown, sv.KeyDown, ld.KeyDown, rh.KeyDown, rr.KeyDown, rl.KeyDown, rv.KeyDown, sv1.KeyDown, ld1.KeyDown, RB0.KeyDown, RB1.KeyDown, RB2.KeyDown, zoomIn.KeyDown, zoomOut.KeyDown
        If keyboard Then
            If e.KeyCode = Keys.NumPad7 OrElse e.KeyCode = Keys.Q Then
                zxcvi(fastGame(1))
            ElseIf e.KeyCode = Keys.NumPad8 OrElse e.KeyCode = Keys.W Then
                zxcvi(fastGame(2))
            ElseIf e.KeyCode = Keys.NumPad9 OrElse e.KeyCode = Keys.E Then
                zxcvi(fastGame(3))
            ElseIf e.KeyCode = Keys.NumPad4 OrElse e.KeyCode = Keys.A Then
                zxcvi(fastGame(4))
            ElseIf e.KeyCode = Keys.NumPad5 OrElse e.KeyCode = Keys.S Then
                zxcvi(fastGame(5))
            ElseIf e.KeyCode = Keys.NumPad6 OrElse e.KeyCode = Keys.D Then
                zxcvi(fastGame(6))
            ElseIf e.KeyCode = Keys.NumPad1 OrElse e.KeyCode = Keys.Z Then
                zxcvi(fastGame(7))
            ElseIf e.KeyCode = Keys.NumPad2 OrElse e.KeyCode = Keys.X Then
                zxcvi(fastGame(8))
            ElseIf e.KeyCode = Keys.NumPad3 OrElse e.KeyCode = Keys.C Then
                zxcvi(fastGame(9))
            ElseIf e.KeyCode = Keys.F2 OrElse e.KeyCode = Keys.O Then
                If sv.Enabled = True Then
                    sve()
                End If
            ElseIf e.KeyCode = Keys.F4 OrElse e.KeyCode = Keys.L Then
                If ld.Enabled = True Then
                    lde()
                End If
            ElseIf e.KeyCode = Keys.R Then
                If sv.Enabled = True Then
                    sve1()
                End If
            ElseIf e.KeyCode = Keys.F Then
                lde1()
            ElseIf e.KeyCode = Keys.F8 Then
                If bgClr < 255 Then
                    bgClr += 1
                End If
                clr2()
            ElseIf e.KeyCode = Keys.F6 Then
                If bgClr > 185 Then
                    bgClr -= 1
                End If
                clr2()
            ElseIf e.KeyCode = Keys.M OrElse e.KeyCode = Keys.F9 Then
                theBest = Not theBest
            ElseIf e.KeyCode = Keys.H OrElse e.KeyCode = Keys.F10 Then
                If help.Visible = True Then
                    helping()
                End If
            ElseIf e.KeyCode = Keys.F5 Then
                If ok1.Visible Then
                    If Not ok1.Checked OrElse Not ok2.Checked Then
                        ok1.Checked = True : ok2.Checked = True
                    Else
                        ok1.Checked = False
                        If Not computer.Checked Then ok2.Checked = False
                    End If
                End If
            ElseIf e.KeyCode = Keys.F7 Then
                img2()
            ElseIf e.KeyCode = Keys.G Then
                language()
            ElseIf e.KeyCode = Keys.U Then
                If undo.Enabled = True Then
                    undoSub()
                End If
            ElseIf e.KeyCode = Keys.I Then
                If redo.Enabled = True Then
                    redoSub()
                End If
            ElseIf e.KeyCode = Keys.T Then
                If computer.Checked = False Then
                    computer.Checked = True
                ElseIf computer.Checked = True AndAlso Not busy Then
                    computer.Checked = False
                End If
            ElseIf e.KeyCode = Keys.Y Then
                If theGame(14) = 7 Then
                    theGame(14) = 0
                Else
                    theGame(14) += 1
                End If
                iLevel()
            ElseIf e.KeyCode = Keys.F12 Then
                B5()
            ElseIf e.KeyCode = Keys.D1 Then
                buttons = 1
                B67()
            ElseIf e.KeyCode = Keys.D2 Then
                buttons = 2
                B67()
            ElseIf e.KeyCode = Keys.D3 Then
                buttons = 3
                B67()
            ElseIf e.KeyCode = Keys.D4 Then
                buttons = 4
                B67()
            ElseIf e.KeyCode = Keys.D5 Then
                buttons = 5
                B67()
            ElseIf e.KeyCode = Keys.D6 Then
                buttons = 6
                B67()
            ElseIf e.KeyCode = Keys.P Then
                If start.Visible = True Then
                    StartSub()
                End If
            ElseIf e.KeyCode = Keys.B OrElse e.KeyCode = Keys.F1 Then
                RstA()
            ElseIf e.KeyCode = Keys.N OrElse e.KeyCode = Keys.F3 Then
                Rst()
            ElseIf e.KeyCode = Keys.J Then
                If VaH.Checked = True Then
                    VaH.Checked = False
                Else
                    VaH.Checked = True
                End If
            ElseIf e.KeyCode = Keys.K Then
                If NoS.Checked = True Then
                    NoS.Checked = False
                Else
                    NoS.Checked = True
                End If
            ElseIf e.KeyCode = Keys.V AndAlso My.Computer.FileSystem.FileExists(sg + "New Text Document.txt") Then
                If help.Visible = True Then
                    sve()
                    helping()
                End If
            End If
        End If
        If e.KeyCode = Keys.F11 Then
            If keyboard Then
                keyboard = False
                TTen.Active = False : TTar.Active = False
            Else
                keyboard = True
            End If
        End If
    End Sub

    Sub clr2()
        clr = Color.FromArgb(bgClr, bgClr, bgClr)
        BackColor = clr
        name1.BackColor = clr
        name2.BackColor = clr
        level.BackColor = clr
        ns.BackColor = clr : nsAr.BackColor = clr
        playFirst.BackColor = clr
        fst.BackColor = clr : fstAr.BackColor = clr
    End Sub

    Sub img2()
        If Not img Then
            If OFD2.ShowDialog() = DialogResult.OK Then
                Try
                    BackgroundImage = Image.FromFile(OFD2.FileName)
                    img = True
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            BackgroundImage = Nothing
            img = False
        End If
    End Sub


    Private Sub sgM(sender As Object, e As EventArgs) Handles MyBase.MouseEnter, MyClass.MouseEnter, Me.MouseEnter, PB1.MouseEnter, Pwait.MouseEnter, PB4.MouseEnter, PB5.MouseEnter, PB6.MouseEnter, PB7.MouseEnter, PB8.MouseEnter, PB9.MouseEnter, P10.MouseEnter, P11.MouseEnter, wait.MouseEnter, player1.MouseEnter, player2.MouseEnter, name1.MouseEnter, name2.MouseEnter, win1.MouseEnter, win2.MouseEnter, step1.MouseEnter, step2.MouseEnter, computer.MouseEnter, level.MouseEnter, ok1.MouseEnter, ok2.MouseEnter, VaH.MouseEnter, NoS.MouseEnter, secret.MouseEnter, lns.MouseEnter, ns.MouseEnter, playFirst.MouseEnter, Lf.MouseEnter, fst.MouseDown, fstAr.MouseDown, undo.MouseEnter, redo.MouseEnter, rr.MouseEnter, rl.MouseEnter, rh.MouseEnter, rv.MouseEnter, sv.MouseEnter, ld.MouseEnter, sv1.MouseEnter, ld1.MouseEnter, Bu1.MouseEnter, rest.MouseEnter, restA.MouseEnter, start.MouseEnter, Bu5.MouseEnter, Bu6.MouseEnter, Bu7.MouseEnter, lang.MouseEnter, help.MouseEnter, B10.MouseEnter, B11.MouseEnter, XO.MouseEnter, OX.MouseEnter, a1.MouseDown, a2.MouseDown, a3.MouseDown, z1.Click, z2.Click, z3.Click, c1.Click, c2.Click, c3.Click
        hold = False
    End Sub

    Private Sub z1_MouseDown(sender As Object, e As MouseEventArgs) Handles z1.MouseDown
        If theGame(0) = 0 Then
            hold = True
            zxcvi(1)
        Else
            hold = False
        End If
    End Sub

    Private Sub z2_MouseDown(sender As Object, e As MouseEventArgs) Handles z2.MouseDown
        If theGame(0) = 0 Then
            hold = True
            zxcvi(2)
        Else
            hold = False
        End If
    End Sub

    Private Sub z3_MouseDown(sender As Object, e As MouseEventArgs) Handles z3.MouseDown
        If theGame(0) = 0 Then
            hold = True
            zxcvi(3)
        Else
            hold = False
        End If
    End Sub

    Private Sub c1_MouseDown(sender As Object, e As MouseEventArgs) Handles c1.MouseDown
        If theGame(0) = 1 AndAlso Not computer.Checked Then
            hold = True
            zxcvi(7)
        Else
            hold = False
        End If
    End Sub

    Private Sub c2_MouseDown(sender As Object, e As MouseEventArgs) Handles c2.MouseDown
        If theGame(0) = 1 AndAlso Not computer.Checked Then
            hold = True
            zxcvi(8)
        Else
            hold = False
        End If
    End Sub

    Private Sub c3_MouseDown(sender As Object, e As MouseEventArgs) Handles c3.MouseDown
        If theGame(0) = 1 AndAlso Not computer.Checked Then
            hold = True
            zxcvi(9)
        Else
            hold = False
        End If
    End Sub

    Private Sub a1_Click(sender As Object, e As EventArgs) Handles a1.Click
        zxcvi(4)
    End Sub

    Private Sub a1_Mouse(sender As Object, e As EventArgs) Handles a1.MouseMove, a1.MouseEnter, a1.MouseHover
        If hold Then zxcvi(4)
    End Sub

    Private Sub a2_Click(sender As Object, e As EventArgs) Handles a2.Click
        zxcvi(5)
    End Sub

    Private Sub a2_Mouse(sender As Object, e As EventArgs) Handles a2.MouseMove, a2.MouseEnter, a2.MouseHover
        If hold Then zxcvi(5)
    End Sub

    Private Sub a3_Click(sender As Object, e As EventArgs) Handles a3.Click
        zxcvi(6)
    End Sub

    Private Sub a3_Mouse(sender As Object, e As EventArgs) Handles a3.MouseMove, a3.MouseEnter, a3.MouseHover
        If hold Then zxcvi(6)
    End Sub
#End Region

    Sub zxcvi(i As Integer)
        If theGame(0) = 0 AndAlso (i = 1 OrElse i = 2 OrElse i = 3) OrElse theGame(0) = 1 AndAlso (i = 7 OrElse i = 8 OrElse i = 9) AndAlso Not computer.Checked Then
            theGame(10) = i
            loc()
        ElseIf theGame(10) > 0 AndAlso (i = 4 OrElse i = 5 OrElse i = 6) Then
            moving(i, theGame(10), 1)
            If theGame(0) = 0 Then
                step1.Text = step1.Text + 1
                theGame(0) = 1
            ElseIf theGame(0) = 1 Then
                step2.Text = step2.Text + 1
                theGame(0) = 0
            End If
            undo1 += i.ToString + theGame(10).ToString
            theGame(10) = 0
            redo1 = ""
            loc()
            rf() : ne() : Wn() : ComputerTurn()
        End If
    End Sub

    Sub moving(a As Integer, zc As Integer, plus As Integer)
        temp = theGame(a) : theGame(a) = theGame(zc) : theGame(zc) = temp
        temp = fastGame(theGame(a)) : fastGame(theGame(a)) = fastGame(theGame(zc)) : fastGame(theGame(zc)) = temp
        theGame(zc + 10) += plus
    End Sub

    Sub fastGameUpdate()
        For i = 1 To 9
            fastGame(theGame(i)) = i
        Next
    End Sub

#Region "start, stop and style"
    Private Sub start_Click(sender As Object, e As EventArgs) Handles start.Click
        StartSub()
    End Sub

    Sub StartSub()
        If start.Text = "Start" OrElse start.Text = "إبدأ" Then
            If lang.Text = "عربي" Then
                start.Text = "Stop"
            Else
                start.Text = "توقف"
            End If
            Dim rand = New Random
            theGame(15) = rand.Next(0, 2)
            PB1.BackgroundImage = images(theGame(15))
            T1.Start()
        Else
            T1.Stop()
            start.Visible = False
            If lang.Text = "عربي" Then
                start.Text = "Start"
            Else
                start.Text = "إبدأ"
            End If
            theGame(0) = theGame(15)
            help.Visible = True
            ox2() : ComputerTurn()
            secret.Visible = True
            hp.Visible = True
            sv.Enabled = True
            ok1.Visible = True : ok2.Visible = True
            If computer.Checked Then ok2.Checked = True
            im0.Visible = False : im1.Visible = False : im2.Visible = False
            RB0.Visible = False : RB1.Visible = False : RB2.Visible = False
            zoomIn.Visible = False : zoomOut.Visible = False
            If buttons = 2 Then sv1.Visible = True
        End If
    End Sub

    Private Sub T1_Tick(sender As Object, e As EventArgs) Handles T1.Tick
        theGame(15) = 1 - theGame(15)
        PB1.BackgroundImage = images(theGame(15))
    End Sub

    Sub ox2()
        PB1.BackgroundImage = Nothing : OX.BackgroundImage = Nothing
        If theGame(0) > 2 Then Exit Sub
        PB1.BackgroundImage = images(theGame(0))
        OX.BackgroundImage = images(1 - theGame(0))
    End Sub

    Sub Positions()
        theGame(10) = 0
        If theGame(16) = 1 Then
            theGame(1) = 1 : theGame(2) = 8 : theGame(3) = 3 : theGame(4) = 4 : theGame(5) = 5 : theGame(6) = 6 : theGame(7) = 7 : theGame(8) = 2 : theGame(9) = 9
        ElseIf theGame(16) = 2 Then
            theGame(8) = 1 : theGame(3) = 2 : theGame(4) = 3 : theGame(1) = 4 : theGame(5) = 5 : theGame(9) = 6 : theGame(6) = 7 : theGame(7) = 8 : theGame(2) = 9
        Else
            For i = 1 To 9
                theGame(i) = i
            Next
        End If
        For i = 1 To 9
            If i = 4 OrElse i = 5 OrElse i = 6 Then
            Else
                theGame(10 + i) = theGame(16)
            End If
        Next
        fastGameUpdate() ' new
    End Sub

    Private Sub Rest_Click(sender As Object, e As EventArgs) Handles rest.Click
        Rst()
    End Sub

    Sub Rst()
        If Not busy Then
            Positions()
            step1.Text = "0" : step2.Text = "0"
            undo1 = "" : redo1 = "" : nf() : rf()
            ok1.Text = "OK" : ok = -1 * (ok1.Checked AndAlso ok2.Checked)
            If ok = 1 Then ok1.Text += " +1"
            ok2.Text = ok1.Text
            loc()
            If lang.Text = "عربي" Then
                start.Text = "Start"
            Else
                start.Text = "إبدأ"
            End If
            T1.Stop()
            If start.Visible = True Then
                theGame(15) = 3
                PB1.BackgroundImage = Nothing
            Else
                theGame(0) = theGame(15)
                ox2() : ComputerTurn()
            End If
            theGame(20) = 2
        End If
    End Sub

    Private Sub RestA_Click(sender As Object, e As EventArgs) Handles restA.Click
        RstA()
    End Sub

    Sub RstA()
        If Not busy Then
            theGame(16) = 0
            theGame(15) = 3
            Rst()
            theGame(0) = 3
            win1.Text = "0" : win2.Text = "0"
            PB1.BackgroundImage = Nothing
            sv.Enabled = False
            sv1.Visible = False
            If start.Visible = True Then
                ' name1.Text = "Player1" : name2.Text = "Player2"
                VaH.Checked = True
                computer.Checked = False
            End If
            start.Visible = True
            NoS.Checked = False
            help.Visible = False
            XO.Visible = False
            OX.Visible = False
            secret.Visible = False
            secret.Checked = False
            hp.Visible = False
            ok1.Visible = False : ok2.Visible = False
            im0.Visible = True : im1.Visible = True : im2.Visible = True
            RB0.Visible = True : RB1.Visible = True : RB2.Visible = True
            zoomIn.Visible = True : zoomOut.Visible = True ' جديد
        End If
    End Sub

    Private Sub RB0_CheckedChanged(sender As Object, e As EventArgs) Handles RB0.Click
        If theGame(16) <> 0 Then
            theGame(16) = 0
            Positions()
            loc1() : pic()
        End If
    End Sub

    Private Sub RB1_CheckedChanged(sender As Object, e As EventArgs) Handles RB1.Click
        If theGame(16) <> 1 Then
            theGame(16) = 1
            Positions()
            loc1() : pic()
        End If
    End Sub

    Private Sub RB2_CheckedChanged(sender As Object, e As EventArgs) Handles RB2.Click
        If theGame(16) <> 2 Then
            theGame(16) = 2
            Positions()
            loc1() : pic()
            If Not My.Computer.FileSystem.FileExists(sg + "ABC.seaga") Then
                My.Computer.FileSystem.WriteAllText(sg + "ABC.seaga", "", False)
                buttons = 4
                B67()
            End If
        End If
    End Sub
#End Region

#Region "the win"
    Sub wn19()
        If aRLine(1, 2, 3) Then
            lwz = 0
        Else
            lwz = 2
        End If
        If aBLine(7, 8, 9) Then
            lwc = 1
        Else
            lwc = 2
        End If
    End Sub

    Sub wn37()
        If plyFrst = 0 Then
            If lwz = 0 Then
                theGame(0) = 0
            Else
                theGame(0) = 1
            End If
        ElseIf plyFrst = 1 Then
            If lwz = 0 Then
                theGame(0) = 1
            Else
                theGame(0) = 0
            End If
        ElseIf plyFrst = 2 Then
            theGame(0) = 1 - theGame(15)
        ElseIf plyFrst = 3 Then
            start.Visible = True
            theGame(0) = 3
            sv.Enabled = False
            sv1.Visible = False
            help.Visible = False
            XO.Visible = False
            OX.Visible = False
            secret.Visible = False
            secret.Checked = False
            hp.Visible = False
            ok1.Visible = False : ok2.Visible = False
            PB1.BackgroundImage = Nothing
            zoomIn.Visible = True : zoomOut.Visible = True
        ElseIf plyFrst = 4 Then
            Dim rand = New Random
            theGame(0) = rand.Next(0, 2)
        End If
        theGame(15) = theGame(0)
    End Sub

    Sub Wn()
        Dim txt, txt1 As String
        If lang.Text = "عربي" Then
            txt = "You won, " : txt1 = "Excellent"
        Else
            txt = "انت فزت يا " : txt1 = "ممتاز"
        End If
        If name1.Text.Trim = "" Then name1.Text = name1.Tag
        If name2.Text.Trim = "" Then name2.Text = name2.Tag

        wn19()
        If Not NoS.Checked OrElse (NoS.Checked AndAlso step1.Text = step2.Text AndAlso theGame(20) = 2) Then
            If lwz = 0 AndAlso lwc = 2 Then
                win1.Text += 1
                zc(1, win:=True) : zc(2, win:=True) : zc(3, win:=True)
                MsgBox(txt + name1.Text, msg, txt1) '
                wn37()
                Rst()
            End If
            If lwc = 1 AndAlso lwz = 2 Then
                win2.Text += 1
                zc(7, win:=True) : zc(8, win:=True) : zc(9, win:=True)
                MsgBox(txt + name2.Text, msg, txt1) '
                wn37()
                Rst()
            End If
        ElseIf step1.Text <> step2.Text AndAlso NoS.Checked AndAlso theGame(20) = 2 Then
            If lwz = 0 Then
                If step1.Text = step2.Text + 1 AndAlso theGame(0) = 1 Then theGame(20) = 0
                zc(1, win:=True) : zc(2, win:=True) : zc(3, win:=True)
            End If
            If lwc = 1 Then
                If step2.Text = step1.Text + 1 AndAlso theGame(0) = 0 Then theGame(20) = 1
                zc(7, win:=True) : zc(8, win:=True) : zc(9, win:=True)
            End If
        ElseIf theGame(20) < 2 Then
            If step1.Text = step2.Text Then
                If theGame(20) = 0 Then
                    If lwc = 1 Then
                        undo1 = "" : redo1 = ""
                        theGame(11) = 0 : theGame(12) = 0 : theGame(13) = 0 : theGame(17) = 0 : theGame(18) = 0 : theGame(19) = 0
                        nf()
                        rf()
                        theGame(20) = 2
                        zc(1, sleep:=True) : zc(2, sleep:=True) : zc(3, sleep:=True)
                        zc(7, sleep:=True) : zc(8, sleep:=True) : zc(9, sleep:=True)
                        theGame(0) = sn
                        PB1.BackgroundImage = images(sn)
                        OX.BackgroundImage = images(1 - sn)
                    Else
                        win1.Text = win1.Text + 1
                        MsgBox(txt + name1.Text, msg, txt1) '
                        wn37()
                        Rst()
                    End If
                ElseIf theGame(20) = 1 Then
                    If lwz = 0 Then
                        undo1 = "" : redo1 = ""
                        theGame(11) = 0 : theGame(12) = 0 : theGame(13) = 0 : theGame(17) = 0 : theGame(18) = 0 : theGame(19) = 0
                        nf()
                        rf()
                        theGame(20) = 2
                        zc(1, sleep:=True) : zc(2, sleep:=True) : zc(3, sleep:=True)
                        zc(7, sleep:=True) : zc(8, sleep:=True) : zc(9, sleep:=True)
                        theGame(0) = 1 - sn
                        PB1.BackgroundImage = images(theGame(0))
                        OX.BackgroundImage = images(1 - theGame(0))
                    Else
                        win2.Text = win2.Text + 1
                        MsgBox(txt + name2.Text, msg, txt1) '
                        wn37()
                        Rst()
                    End If
                End If
            Else
                theGame(20) = 2
                Wn()
            End If
        End If
    End Sub
#End Region

#Region "interface"
    Sub lcn()
        If computer.Checked Then
            name2.Tag = "Computer"
            name1.Tag = "Player"
            If name2.Text.ToLower = "player2" OrElse name2.Text.Trim = "" Then name2.Text = name2.Tag
            If name1.Text.ToLower = "player1" OrElse name1.Text.Trim = "" Then name1.Text = name1.Tag
        Else
            name2.Tag = "Player2"
            name1.Tag = "Player1"
            If name2.Text.ToLower = "computer" OrElse name2.Text.Trim = "" Then name2.Text = name2.Tag
            If name1.Text.ToLower = "player" OrElse name1.Text.Trim = "" Then name1.Text = name1.Tag
        End If
    End Sub

    Sub loc1()
        For i = 1 To 9
            thePieces(i).Location = locations(theGame(i))
        Next
    End Sub

    Sub zc(z As Integer, Optional selected As Boolean = False, Optional sleep As Boolean = False, Optional win As Boolean = False) ' image of piece   ' slow
        If z <= 3 Then
            bitmap = New Bitmap(images(0))
        ElseIf z >= 7 Then
            bitmap = New Bitmap(images(1))
        Else
            bitmap = New Bitmap(images(5))
        End If
        If selected Then Graphics.FromImage(bitmap).DrawImage(images(5), New Point(0, 0))
        If sleep Then
            Graphics.FromImage(bitmap).DrawImage(images(6), New Point(images(0).Width - images(6).Width, 0))
        ElseIf win Then
            Graphics.FromImage(bitmap).DrawImage(images(7), New Point(images(0).Width - images(7).Width, 0))
        End If
        thePieces(z).BackgroundImage = bitmap
    End Sub

    Sub pic()
        For i = 7 To 9
            zc(i, theGame(10) = i, theGame(10 + i) = 0, lwc = 1)
        Next
        For i = 1 To 3
            zc(i, theGame(10) = i, theGame(10 + i) = 0, lwz = 0)
        Next
        zc(4) : zc(5) : zc(6)
        If theBest >= 4 AndAlso theBest <= 6 Then
            zc(theBest, win:=True) : theBest = -1
        End If
    End Sub

    Sub loc()
        If theGame(10) = 0 Then
            a1.Visible = False
            a2.Visible = False
            a3.Visible = False
        Else
            a1.Visible = True
            a2.Visible = True
            a3.Visible = True
        End If
        loc1()
        If start.Visible = True Then
            im0.Visible = True
            im1.Visible = True
            im2.Visible = True
            RB0.Visible = True
            RB1.Visible = True
            RB2.Visible = True
        Else
            im0.Visible = False
            im1.Visible = False
            im2.Visible = False
            RB0.Visible = False
            RB1.Visible = False
            RB2.Visible = False
        End If
        If theGame(16) = 0 Then
            RB0.Checked = True
        ElseIf theGame(16) = 1 Then
            RB1.Checked = True
        ElseIf theGame(16) = 2 Then
            RB2.Checked = True
        End If
        wn19()
        pic()
        ox2()
    End Sub
#End Region

#Region "Computer"
    Private Sub Computer_CheckedChanged(sender As Object, e As EventArgs) Handles computer.CheckedChanged
        If Not busy Then
            If computer.Checked = True Then
                If theGame(0) = 1 Then
                    theGame(10) = 0
                    a1.Visible = False : a2.Visible = False : a3.Visible = False
                End If
                lcn()
                ok2.Enabled = False
                If ok2.Visible Then ok2.Checked = True
                ComputerTurn()
            Else
                lcn()
                ok2.Enabled = True
            End If
        Else
            computer.Checked = True '
        End If
    End Sub

    Private Sub fst_ValueChanged(sender As Object, e As EventArgs) Handles fst.ValueChanged
        Try
            If fst.Value >= 1 Then T2.Interval = fst.Value
            If fst.Value <> fstAr.Value Then fstAr.Value = fst.Value
        Catch ex As Exception
            fst.Value = 175
        End Try
    End Sub

    Private Sub fstAr_ValueChanged(sender As Object, e As EventArgs) Handles fstAr.ValueChanged
        Try
            If fst.Value <> fstAr.Value Then fst.Value = fstAr.Value
        Catch ex As Exception
            fstAr.Value = 175
        End Try
    End Sub

    Private Sub T2_Tick(sender As Object, e As EventArgs) Handles T2.Tick
        T2.Stop()
        ComputerIntelligence()
    End Sub

    Sub ComputerTurn()
        If Not busy AndAlso computer.Checked AndAlso theGame(0) = 1 AndAlso Not start.Visible Then
            busy = True
            Pwait.Visible = True : wait.Visible = True
            If fst.Value = 0 Then
                ComputerIntelligence()
            Else
                T2.Start()
            End If
        End If
    End Sub

    Sub ComputerIntelligence()
        Dim rand = New Random
        Dim constant As Integer = rand.Next(0, 100)
        Dim game, temp As New List(Of Byte)
        Dim i As Integer = 0
        game.AddRange({4, 7, 4, 8, 4, 9, 5, 7, 5, 8, 5, 9, 6, 7, 6, 8, 6, 9})
        temp.AddRange(game)
        If theGame(14) = 0 Then GoTo theEnd

        ''''''''''''''''''''If Not VaH.Checked AndAlso NoS.Checked AndAlso step2.Text = step1.Text Then  <إختيار الفوز القطري>  End If

        While i < game.Count - 1
            If ComputerWin(game(i), game(i + 1)) Then
                i += 2
            Else
                game.RemoveAt(i) : game.RemoveAt(i)
            End If
        End While
        If game.Count = 0 Then
            game.AddRange(temp)
        Else
            GoTo theEnd
        End If

        If theGame(14) >= 2 Then
            i = 0
            While i < game.Count - 1
                If OpponentNotWin(game(i), game(i + 1)) Then
                    i += 2
                Else
                    game.RemoveAt(i) : game.RemoveAt(i)
                End If
            End While
            If game.Count = 0 Then
                game.AddRange(temp)
                GoTo theEnd
            Else
                temp.Clear()
                temp.AddRange(game)
            End If
        End If

        If theGame(14) >= 3 Then ' محاولة الفوز الثنائي
            i = 0
            While i < game.Count - 1
                If ComputerDouWin(game(i), game(i + 1)) Then
                    i += 2
                Else
                    game.RemoveAt(i) : game.RemoveAt(i)
                End If
            End While
            If game.Count = 0 Then
                game.AddRange(temp)
            Else
                temp.Clear()
                temp.AddRange(game)
            End If
        End If

        ' التيقظ لعملية الفوز الثنائي ومنعه
        If theGame(14) = 7 OrElse theGame(14) = 6 AndAlso constant < 75 OrElse theGame(14) = 5 AndAlso constant < 50 OrElse theGame(14) = 4 AndAlso constant < 25 Then
            i = 0
            While i < game.Count - 1
                If OpponentNotDouWin(game(i), game(i + 1)) Then
                    i += 2
                Else
                    game.RemoveAt(i) : game.RemoveAt(i)
                End If
            End While
            If game.Count = 0 Then
                game.AddRange(temp)
            Else
                temp.Clear()
                temp.AddRange(game)
            End If
        End If

        If theGame(17) = 0 OrElse theGame(18) = 0 OrElse theGame(19) = 0 Then

            ' حالات خاصة
            If Not VaH.Checked AndAlso theGame(14) >= 6 Then ' أسوأ ما قمت به في حياتي .. جيدة ولكن ليست رائعة

                i = 0
                While i < game.Count - 1
                    If ComputerSpecialCases(game(i), game(i + 1)) Then
                        i += 2
                    Else
                        game.RemoveAt(i) : game.RemoveAt(i)
                    End If
                End While
                If game.Count = 0 Then
                    game.AddRange(temp)
                Else
                    temp.Clear()
                    temp.AddRange(game)
                End If

                i = 0
                While i < game.Count - 1
                    If DiagonalCatchingSleeperComputerPiece(game(i), game(i + 1)) Then
                        i += 2
                    Else
                        game.RemoveAt(i) : game.RemoveAt(i)
                    End If
                End While
                If game.Count = 0 Then
                    game.AddRange(temp)
                Else
                    temp.Clear()
                    temp.AddRange(game)
                End If

                i = 0
                While i < game.Count - 1
                    If OpponentSpecialCases(game(i), game(i + 1)) Then
                        i += 2
                    Else
                        game.RemoveAt(i) : game.RemoveAt(i)
                    End If
                End While
                If game.Count = 0 Then
                    game.AddRange(temp)
                Else
                    temp.Clear()
                    temp.AddRange(game)
                End If
            End If ' النهاية الغريبة

            i = 0
            While i < game.Count - 1 ' تحريك النائم
                If SleeperPiece(game(i + 1)) Then
                    i += 2
                Else
                    game.RemoveAt(i) : game.RemoveAt(i)
                End If
            End While
            If game.Count = 0 Then
                game.AddRange(temp)
            Else
                temp.Clear()
                temp.AddRange(game)
            End If

            If theGame(14) = 7 AndAlso Not VaH.Checked Then ' وضع القطعة في المنتصف
                i = 0
                While i < game.Count - 1
                    If PieceInMiddle(game(i), game(i + 1)) Then
                        i += 2
                    Else
                        game.RemoveAt(i) : game.RemoveAt(i)
                    End If
                End While
                If game.Count = 0 Then
                    game.AddRange(temp)
                Else
                    temp.Clear()
                    temp.AddRange(game)
                End If
            End If

        End If

theEnd:
        If swap >= 0 Then
            theGame(14) = swap
            swap = -1
            If theGame(0) = 0 Then
                swapping()
                For i = 0 To game.Count / 2 - 1
                    game(i * 2 + 1) -= 6
                Next
            End If
        End If
        Choosing(game)
    End Sub

    Sub Choosing(ByRef game As List(Of Byte))
        Dim rand = New Random
        Dim choose As Integer = rand.Next(0, game.Count / 2)
        theGame(10) = game(choose * 2 + 1)
        Pwait.Visible = False : wait.Visible = False
        busy = False
        If theBest = 0 OrElse computer.Checked AndAlso theGame(0) = 1 Then
            zxcvi(game(choose * 2))
        Else
            theBest = game(choose * 2) : loc()
        End If
    End Sub

#Region "Computer Intelligence Functions"
    Sub TempMove(a As Integer, zc As Integer, plus As Integer)
        temp = theGame(a) : theGame(a) = theGame(zc) : theGame(zc) = temp
        theGame(zc + 10) += plus
    End Sub

    Function SleeperPiece(blue As Byte) As Boolean
        Return theGame(blue + 10) = 0
    End Function

    Function ComputerWin(space As Byte, blue As Byte) As Boolean
        Dim yes As Boolean = False
        TempMove(space, blue, 1)
        If aBLine(7, 8, 9) Then yes = True
        TempMove(space, blue, -1)
        Return yes
    End Function

    Function OpponentNotWin(space As Byte, blue As Byte) As Boolean
        Dim yes As Boolean = False
        TempMove(space, blue, 1)
        For k = 4 To 6
            If aRLine(1, 2, k) OrElse aRLine(1, 3, k) OrElse aRLine(2, 3, k) Then GoTo break
        Next
        yes = True
break:
        TempMove(space, blue, -1)
        Return yes
    End Function

    Function ComputerDouWin(space As Byte, blue As Byte) As Boolean
        Dim counter As Integer = 0
        TempMove(space, blue, 1)
        If theGame(17) > 0 AndAlso theGame(18) > 0 AndAlso (hLine(7, 8, 4) OrElse hLine(7, 8, 5) OrElse hLine(7, 8, 6)) OrElse theGame(17) > 0 AndAlso theGame(19) > 0 AndAlso (hLine(7, 9, 4) OrElse hLine(7, 9, 5) OrElse hLine(7, 9, 6)) OrElse theGame(18) > 0 AndAlso theGame(19) > 0 AndAlso (hLine(8, 9, 4) OrElse hLine(8, 9, 5) OrElse hLine(8, 9, 6)) Then
            counter += 1
        End If
        If theGame(17) > 0 AndAlso theGame(18) > 0 AndAlso (vLine(7, 8, 4) OrElse vLine(7, 8, 5) OrElse vLine(7, 8, 6)) OrElse theGame(17) > 0 AndAlso theGame(19) > 0 AndAlso (vLine(7, 9, 4) OrElse vLine(7, 9, 5) OrElse vLine(7, 9, 6)) OrElse theGame(18) > 0 AndAlso theGame(19) > 0 AndAlso (vLine(8, 9, 4) OrElse vLine(8, 9, 5) OrElse vLine(8, 9, 6)) Then
            counter += 1
        End If
        If Not VaH.Checked Then
            If theGame(17) > 0 AndAlso theGame(18) > 0 AndAlso (mDiagonal(7, 8, 4) OrElse mDiagonal(7, 8, 5) OrElse mDiagonal(7, 8, 6)) OrElse theGame(17) > 0 AndAlso theGame(19) > 0 AndAlso (mDiagonal(7, 9, 4) OrElse mDiagonal(7, 9, 5) OrElse mDiagonal(7, 9, 6)) OrElse theGame(18) > 0 AndAlso theGame(19) > 0 AndAlso (mDiagonal(8, 9, 4) OrElse mDiagonal(8, 9, 5) OrElse mDiagonal(8, 9, 6)) Then
                counter += 1
            End If
            If theGame(17) > 0 AndAlso theGame(18) > 0 AndAlso (sDiagonal(7, 8, 4) OrElse sDiagonal(7, 8, 5) OrElse sDiagonal(7, 8, 6)) OrElse theGame(17) > 0 AndAlso theGame(19) > 0 AndAlso (sDiagonal(7, 9, 4) OrElse sDiagonal(7, 9, 5) OrElse sDiagonal(7, 9, 6)) OrElse theGame(18) > 0 AndAlso theGame(19) > 0 AndAlso (sDiagonal(8, 9, 4) OrElse sDiagonal(8, 9, 5) OrElse sDiagonal(8, 9, 6)) Then
                counter += 1
            End If
        End If
        TempMove(space, blue, -1)
        Return counter > 1
    End Function

    Function OpponentNotDouWin(space As Byte, blue As Byte) As Boolean
        Dim counter As Integer = 0
        TempMove(space, blue, 1)
        For i = 4 To 6
            For j = 1 To 3
                counter = 0
                TempMove(i, j, 1)
                If aBLine(7, 8, 4) OrElse aBLine(7, 8, 5) OrElse aBLine(7, 8, 6) OrElse aBLine(7, 9, 4) OrElse aBLine(7, 9, 5) OrElse aBLine(7, 9, 6) OrElse aBLine(8, 9, 4) OrElse aBLine(8, 9, 5) OrElse aBLine(8, 9, 6) Then
                Else
                    If theGame(11) > 0 AndAlso theGame(12) > 0 AndAlso (hLine(1, 2, 4) OrElse hLine(1, 2, 5) OrElse hLine(1, 2, 6)) OrElse theGame(11) > 0 AndAlso theGame(13) > 0 AndAlso (hLine(1, 3, 4) OrElse hLine(1, 3, 5) OrElse hLine(1, 3, 6)) OrElse theGame(12) > 0 AndAlso theGame(13) > 0 AndAlso (hLine(2, 3, 4) OrElse hLine(2, 3, 5) OrElse hLine(2, 3, 6)) Then
                        counter += 1
                    End If
                    If theGame(11) > 0 AndAlso theGame(12) > 0 AndAlso (vLine(1, 2, 4) OrElse vLine(1, 2, 5) OrElse vLine(1, 2, 6)) OrElse theGame(11) > 0 AndAlso theGame(13) > 0 AndAlso (vLine(1, 3, 4) OrElse vLine(1, 3, 5) OrElse vLine(1, 3, 6)) OrElse theGame(12) > 0 AndAlso theGame(13) > 0 AndAlso (vLine(2, 3, 4) OrElse vLine(2, 3, 5) OrElse vLine(2, 3, 6)) Then
                        counter += 1
                    End If
                    If Not VaH.Checked Then
                        If theGame(11) > 0 AndAlso theGame(12) > 0 AndAlso (mDiagonal(1, 2, 4) OrElse mDiagonal(1, 2, 5) OrElse mDiagonal(1, 2, 6)) OrElse theGame(11) > 0 AndAlso theGame(13) > 0 AndAlso (mDiagonal(1, 3, 4) OrElse mDiagonal(1, 3, 5) OrElse mDiagonal(1, 3, 6)) OrElse theGame(12) > 0 AndAlso theGame(13) > 0 AndAlso (mDiagonal(2, 3, 4) OrElse mDiagonal(2, 3, 5) OrElse mDiagonal(2, 3, 6)) Then
                            counter += 1
                        End If
                        If theGame(11) > 0 AndAlso theGame(12) > 0 AndAlso (sDiagonal(1, 2, 4) OrElse sDiagonal(1, 2, 5) OrElse sDiagonal(1, 2, 6)) OrElse theGame(11) > 0 AndAlso theGame(13) > 0 AndAlso (sDiagonal(1, 3, 4) OrElse sDiagonal(1, 3, 5) OrElse sDiagonal(1, 3, 6)) OrElse theGame(12) > 0 AndAlso theGame(13) > 0 AndAlso (sDiagonal(2, 3, 4) OrElse sDiagonal(2, 3, 5) OrElse sDiagonal(2, 3, 6)) Then
                            counter += 1
                        End If
                    End If
                End If
                TempMove(i, j, -1)
                If counter > 1 Then GoTo break
            Next
        Next
break:
        TempMove(space, blue, -1)
        Return counter <= 1
    End Function

    Function PieceInMiddle(space As Byte, blue As Byte) As Boolean
        Dim yes As Boolean = False
        TempMove(space, blue, 1)
        If aBlueLoc(5) Then yes = True
        TempMove(space, blue, -1)
        Return yes
    End Function

    Function ComputerSpecialCases(space As Byte, blue As Byte) As Boolean
        Dim yes As Boolean = False
        TempMove(space, blue, 1)
        For i = 4 To 6
            For j = 1 To 3
                TempMove(i, j, 1)
                For i1 = 4 To 6
                    For j1 = 7 To 9
                        If ComputerWin(i1, j1) OrElse ComputerDouWin(i1, j1) Then
                            yes = True
                            GoTo break
                        ElseIf i1 = 6 AndAlso j1 = 9 Then
                            yes = False
                        End If
                    Next
                Next
break:
                TempMove(i, j, -1)
                If Not yes Then GoTo break2
            Next
        Next
break2:
        TempMove(space, blue, -1)
        Return yes
    End Function

    Function OpponentSpecialCases(space As Byte, blue As Byte) As Boolean
        Dim yes As Boolean = False
        TempMove(space, blue, 1)
        For i = 4 To 6
            For j = 1 To 3
                TempMove(i, j, 1)
                For i1 = 4 To 6
                    For j1 = 7 To 9
                        If OpponentNotWin(i1, j1) AndAlso DiagonalCatchingSleeperComputerPiece(i1, j1) AndAlso OpponentNotDouWin(i1, j1) Then
                            yes = True
                            GoTo break
                        ElseIf i1 = 6 AndAlso j1 = 9 Then
                            yes = False
                        End If
                    Next
                Next
break:
                TempMove(i, j, -1)
                If Not yes Then GoTo break2
            Next
        Next
break2:
        TempMove(space, blue, -1)
        Return yes
    End Function

    Function DiagonalCatchingSleeperOpponentPiece(space As Byte, blue As Byte) As Boolean ' مستبعدة
        Dim yes As Boolean = False
        TempMove(space, blue, 1)
        If aBlueLoc(5) AndAlso (aBlueLoc(9) AndAlso RedLoc(1) OrElse aBlueLoc(7) AndAlso RedLoc(3) OrElse aBlueLoc(3) AndAlso RedLoc(7) OrElse aBlueLoc(1) AndAlso RedLoc(9)) Then yes = True
        TempMove(space, blue, -1)
        Return yes
    End Function

    Function DiagonalCatchingSleeperComputerPiece(space As Byte, blue As Byte) As Boolean
        Dim yes As Boolean = True
        TempMove(space, blue, 1)
        For i = 4 To 6
            For j = 1 To 3
                TempMove(i, j, 1)
                If aRedLoc(5) AndAlso (aRedLoc(9) AndAlso BlueLoc(1) OrElse aRedLoc(7) AndAlso BlueLoc(3) OrElse aRedLoc(3) AndAlso BlueLoc(7) OrElse aRedLoc(1) AndAlso BlueLoc(9)) Then
                    yes = False
                End If
                TempMove(i, j, -1)
                If Not yes Then GoTo break
            Next
        Next
break:
        TempMove(space, blue, -1)
        Return yes
    End Function

    Function redIdle(piece As Byte) As Boolean
        Return piece <= 3 AndAlso theGame(10 + piece) = 0
    End Function

    Function blueIdle(piece As Byte) As Boolean
        Return piece >= 7 AndAlso theGame(10 + piece) = 0
    End Function

    Function aRLine(piece1 As Byte, piece2 As Byte, piece3 As Byte) As Boolean ' active red in line
        If redIdle(piece1) OrElse redIdle(piece2) OrElse redIdle(piece3) Then Return False
        Return line(piece1, piece2, piece3)
    End Function

    Function aBLine(piece1 As Byte, piece2 As Byte, piece3 As Byte) As Boolean ' active blue in line
        If blueIdle(piece1) OrElse blueIdle(piece2) OrElse blueIdle(piece3) Then Return False
        Return line(piece1, piece2, piece3)
    End Function

    Function hLine(piece1 As Byte, piece2 As Byte, piece3 As Byte) As Boolean ' Horizontal line
        For i = 1 To 7 Step 3
            If (theGame(piece1) = i OrElse theGame(piece2) = i OrElse theGame(piece3) = i) AndAlso (theGame(piece1) = i + 1 OrElse theGame(piece2) = i + 1 OrElse theGame(piece3) = i + 1) AndAlso (theGame(piece1) = i + 2 OrElse theGame(piece2) = i + 2 OrElse theGame(piece3) = i + 2) Then Return True
        Next
        Return False
    End Function

    Function vLine(piece1 As Byte, piece2 As Byte, piece3 As Byte) As Boolean ' Vertical line
        For i = 1 To 3
            If (theGame(piece1) = i OrElse theGame(piece2) = i OrElse theGame(piece3) = i) AndAlso (theGame(piece1) = i + 3 OrElse theGame(piece2) = i + 3 OrElse theGame(piece3) = i + 3) AndAlso (theGame(piece1) = i + 6 OrElse theGame(piece2) = i + 6 OrElse theGame(piece3) = i + 6) Then Return True
        Next
        Return False
    End Function

    Function mDiagonal(piece1 As Byte, piece2 As Byte, piece3 As Byte) As Boolean ' Main Diagonal
        Return (theGame(piece1) = 1 OrElse theGame(piece2) = 1 OrElse theGame(piece3) = 1) AndAlso (theGame(piece1) = 5 OrElse theGame(piece2) = 5 OrElse theGame(piece3) = 5) AndAlso (theGame(piece1) = 9 OrElse theGame(piece2) = 9 OrElse theGame(piece3) = 9)
    End Function

    Function sDiagonal(piece1 As Byte, piece2 As Byte, piece3 As Byte) As Boolean ' Secondary Diagonal
        Return (theGame(piece1) = 3 OrElse theGame(piece2) = 3 OrElse theGame(piece3) = 3) AndAlso (theGame(piece1) = 5 OrElse theGame(piece2) = 5 OrElse theGame(piece3) = 5) AndAlso (theGame(piece1) = 7 OrElse theGame(piece2) = 7 OrElse theGame(piece3) = 7)
    End Function

    Function line(piece1 As Byte, piece2 As Byte, piece3 As Byte) As Boolean
        If hLine(piece1, piece2, piece3) Then Return True
        If vLine(piece1, piece2, piece3) Then Return True
        Return Not VaH.Checked AndAlso (mDiagonal(piece1, piece2, piece3) OrElse sDiagonal(piece1, piece2, piece3))
    End Function

    Function RedLoc(loc As Byte) As Boolean
        Return theGame(1) = loc AndAlso theGame(11) = 0 OrElse theGame(2) = loc AndAlso theGame(12) = 0 OrElse theGame(3) = loc AndAlso theGame(13) = 0
    End Function

    Function aRedLoc(loc As Byte) As Boolean
        Return theGame(1) = loc AndAlso theGame(11) > 0 OrElse theGame(2) = loc AndAlso theGame(12) > 0 OrElse theGame(3) = loc AndAlso theGame(13) > 0
    End Function

    Function BlueLoc(loc As Byte) As Boolean
        Return theGame(7) = loc AndAlso theGame(17) = 0 OrElse theGame(8) = loc AndAlso theGame(18) = 0 OrElse theGame(9) = loc AndAlso theGame(19) = 0
    End Function

    Function aBlueLoc(loc As Byte) As Boolean
        Return theGame(7) = loc AndAlso theGame(17) > 0 OrElse theGame(8) = loc AndAlso theGame(18) > 0 OrElse theGame(9) = loc AndAlso theGame(19) > 0
    End Function
#End Region
#End Region

#Region "language"
    Sub language()
        If lang.Text = "عربي" Then
            Bu1.Text = "حول"
            rest.Text = "إعادة بدء"
            restA.Text = "إعادة بدء الكل"
            If start.Text = "Start" Then
                start.Text = "إبدأ"
            Else
                start.Text = "توقف"
            End If
            Bu5.Text = "كيفية إستخدام لوحة المفاتيح للعب"
            lang.Text = "English"
            VaH.Text = "عمودي وأفقي فقط"
            NoS.Text = "خطوات كلا اللاعبين تكون متساوية"
            computer.Text = "الحاسوب"
            wait.Text = "...إنتظر"
            Sega2.Text = "حول"
            Sega2.ckh.Text = "إضغط هنا  لتحميل آخر إصدار من اللعبة"
            Sega2.ckh.Location = New Point(120, 9)
            level.Items.Clear()
            level.Items.AddRange({"غبي", "مبتدئ", "متوسط", "جيد", "متقدم", "جيد جدا", "ممتاز", "محترف"})
            level.RightToLeft = RightToLeft.Yes
            iLevel()
            playFirst.Items.Clear()
            playFirst.Items.AddRange({"الفائز يلعب أولا", "الخاسر يلعب أولا", "الذي لعب أولا يلعب آخرا المرة القادمة", "إختيار من سيلعب أولا بالقرعة", "إختيار من سيلعب أولا تلقائيا"})
            plyFrstN()
            nsn()
            sv.Text = "حفظ"
            ld.Text = "تحميل "
            help.Text = "مساعدة"
            TTar.Active = TTen.Active : TTen.Active = False
            msg = vbInformation + vbMsgBoxRight + vbMsgBoxRtlReading
            If buttons = 5 Then
                Lf.Visible = False : fst.Visible = False
                LfAr.Visible = True : fstAr.Visible = True
            End If
            If B11.Visible = True Then
                lns.Visible = False : ns.Visible = False
                lnsAr.Visible = True : nsAr.Visible = True
            End If
        Else
            Bu1.Text = "About"
            rest.Text = "Restart"
            restA.Text = "Restart All"
            If start.Text = "إبدأ" Then
                start.Text = "Start"
            Else
                start.Text = "Stop"
            End If
            Bu5.Text = "How to use the keyboard to play"
            lang.Text = "عربي"
            VaH.Text = "Vertical and Horizontal only"
            NoS.Text = "The steps of both players be equal"
            computer.Text = "Computer"
            wait.Text = "Wait..."
            Sega2.Text = "About"
            Sega2.ckh.Text = "Click here  to download the latest version of the game"
            Sega2.ckh.Location = New Point(58, 9)
            level.Items.Clear()
            level.Items.AddRange({"Stupid", "Beginner", "Medium", "Good", "Advanced", "Very Good", "Excellent", "Professional"})
            level.RightToLeft = RightToLeft.No
            iLevel()
            playFirst.Items.Clear()
            playFirst.Items.AddRange({"The winner plays first", "The loser plays first", "Who played first, plays second next time", "Choose who will play first by lot", "Choose who will play first automatically"})
            plyFrstN()
            nsn()
            sv.Text = "Save"
            ld.Text = "Load"
            help.Text = "Help"
            TTen.Active = TTar.Active : TTar.Active = False
            msg = vbInformation
            If buttons = 5 Then
                LfAr.Visible = False : fstAr.Visible = False
                Lf.Visible = True : fst.Visible = True
            End If
            If B11.Visible = True Then
                lnsAr.Visible = False : nsAr.Visible = False
                lns.Visible = True : ns.Visible = True
            End If
        End If
    End Sub

    Private Sub lang_Click(sender As Object, e As EventArgs) Handles lang.Click
        language()
    End Sub
#End Region

#Region "save and load"
    Function SaveG() As String
        Dim wer As String = win1.Text + split + win2.Text + split + step1.Text + split + step2.Text + split + name1.Text.Replace(split, " ") + split + name2.Text.Replace(split, " ") + split + undo1 + split + redo1 ' 0 to 7
        For i = 0 To 20
            wer += split + theGame(i).ToString ' 8 to 28
        Next

        Return wer + split + (VaH.Checked * -1).ToString + split + (NoS.Checked * -1).ToString + split + (computer.Checked * -1).ToString + split + (ok1.Checked * ok2.Checked).ToString + split + ok.ToString + split + plyFrst.ToString + split + sn.ToString
    End Function

    Sub sve()
        If Not busy Then
            My.Computer.FileSystem.WriteAllText(sg + "save.seaga", SaveG(), False)
            ld.Enabled = True
        End If
    End Sub

    Private Sub sv_Click(sender As Object, e As EventArgs) Handles sv.Click
        sve()
    End Sub

    Sub sve1()
        If Not busy Then
            Dim ssf As Integer
            If My.Computer.FileSystem.FileExists(sg + "num.seaga") Then
                ssf = My.Computer.FileSystem.ReadAllText(sg + "num.seaga")
            Else
                ssf = 1
            End If
            SFD.FileName = "SEAGA" + ssf.ToString + ".seaga"
            If SFD.ShowDialog() = DialogResult.OK Then
                Dim saveF As String = AES(SaveG(), True)
                If saveF <> "" Then
                    My.Computer.FileSystem.WriteAllText(SFD.FileName, saveF, False)
                    Dim sd1 As String = ssf + 1
                    My.Computer.FileSystem.WriteAllText(sg + "num.seaga", sd1, False)
                End If
            End If
        End If
    End Sub

    Private Sub sv1_Click(sender As Object, e As EventArgs) Handles sv1.Click
        sve1()
    End Sub

    Sub LoadG(ByRef file As String)
        Try
            Dim Data As String() = file.Split(split)
            If Data.Length <> 36 Then
                MsgBox("Error!", msg, ":(")
                Exit Sub
            End If

            win1.Text = Data(0) : win2.Text = Data(1)
            step1.Text = Data(2) : step2.Text = Data(3)
            name1.Text = Data(4) : name2.Text = Data(5)
            undo1 = Data(6) : redo1 = Data(7)
            For i = 0 To 20
                theGame(i) = Data(i + 8) ' 8 to 28
            Next
            fastGameUpdate() ' new
            VaH.Checked = Data(29) : NoS.Checked = Data(30)
            computer.Checked = Data(31)
            ok1.Checked = Data(32) : ok2.Checked = Data(32) : ok = Data(33)
            plyFrst = Data(34) : sn = Data(35).Substring(0, 1)

            start.Visible = False : ok1.Visible = True : ok2.Visible = True
            help.Visible = True : secret.Visible = True : hp.Visible = True
            zoomIn.Visible = False : zoomOut.Visible = False
            If lang.Text = "عربي" Then
                start.Text = "Start"
            Else
                start.Text = "إبدأ"
            End If
            T1.Stop()

            lcn()
            nf()
            rf()
            If undo1.Length > 0 Then ne()
            If redo1.Length > 0 Then re()
            iLevel()
            ok1.Text = "OK"
            If ok > 0 Then ok1.Text += " +" + ok.ToString
            ok2.Text = ok1.Text

            plyFrstN()
            nsn()
            loc()
            sv.Enabled = True
            If buttons = 2 Then
                sv1.Visible = True
            End If
            ComputerTurn() ' not important except in the worst case
        Catch ex As Exception
            MsgBox(ex.Message, msg, ":(")
        End Try
    End Sub

    Sub lde()
        If Not busy Then LoadG(My.Computer.FileSystem.ReadAllText(sg + "save.seaga"))
    End Sub

    Private Sub ld_Click(sender As Object, e As EventArgs) Handles ld.Click
        lde()
    End Sub

    Sub lde1()
        If Not busy Then
            If OFD.ShowDialog() = DialogResult.OK Then
                Dim loadF = AES(My.Computer.FileSystem.ReadAllText(OFD.FileName), False)
                If loadF = "" Then
                    MsgBox("Error!", msg, ":(")
                Else
                    LoadG(loadF)
                End If
            End If
        End If
    End Sub

    Private Sub ld1_Click(sender As Object, e As EventArgs) Handles ld1.Click
        lde1()
    End Sub
#End Region

#Region "settings"
    Private Sub Bu6_Click(sender As Object, e As EventArgs) Handles Bu6.Click
        buttons += 1
        B67()
    End Sub

    Private Sub Bu7_Click(sender As Object, e As EventArgs) Handles Bu7.Click
        buttons -= 1
        Bu6.TabIndex = 6
        B67()
        Bu6.TabIndex = 4
    End Sub

    Sub B67()
        If buttons = 1 Then
            Bu7.Visible = False
            Bu1.Visible = True
            rest.Visible = True
            restA.Visible = True
        Else
            Bu1.Visible = False
            rest.Visible = False
            restA.Visible = False
            Bu7.Visible = True
        End If
        If buttons = 2 Then
            lang.Visible = True
            sv.Visible = True
            If sv.Enabled = True Then
                sv1.Visible = True
            Else
                sv1.Visible = False
            End If
            ld.Visible = True
            ld1.Visible = True
        Else
            lang.Visible = False
            sv.Visible = False
            sv1.Visible = False
            ld.Visible = False
            ld1.Visible = False
        End If
        If buttons = 3 Then
            playFirst.Visible = True
        Else : playFirst.Visible = False
        End If
        If buttons = 4 Then
            rl.Visible = True
            rr.Visible = True
            rh.Visible = True
            rv.Visible = True
        Else
            rl.Visible = False
            rr.Visible = False
            rh.Visible = False
            rv.Visible = False
        End If
        If buttons = 5 Then
            If lang.Text = "عربي" Then
                Lf.Visible = True
                fst.Visible = True
            Else
                LfAr.Visible = True
                fstAr.Visible = True
            End If
        Else
            Lf.Visible = False : LfAr.Visible = False
            fst.Visible = False : fstAr.Visible = False
        End If
        If buttons = 6 Then
            Bu6.Visible = False
            Bu5.Visible = True
        Else
            Bu5.Visible = False
            Bu6.Visible = True
        End If
    End Sub
#End Region

#Region "rotation"
    Private Sub rl_Click(sender As Object, e As EventArgs) Handles rl.Click
        If Not busy Then
            theGame(fastGame(3)) = 1
            theGame(fastGame(6)) = 2
            theGame(fastGame(9)) = 3
            theGame(fastGame(8)) = 6
            theGame(fastGame(7)) = 9
            theGame(fastGame(4)) = 8
            theGame(fastGame(1)) = 7
            theGame(fastGame(2)) = 4
            fastGameUpdate()
            loc()
        End If
    End Sub

    Private Sub rr_Click(sender As Object, e As EventArgs) Handles rr.Click
        If Not busy Then
            theGame(fastGame(1)) = 3
            theGame(fastGame(2)) = 6
            theGame(fastGame(3)) = 9
            theGame(fastGame(6)) = 8
            theGame(fastGame(9)) = 7
            theGame(fastGame(8)) = 4
            theGame(fastGame(7)) = 1
            theGame(fastGame(4)) = 2
            fastGameUpdate()
            loc()
        End If
    End Sub

    Private Sub rh_Click(sender As Object, e As EventArgs) Handles rh.Click
        If Not busy Then
            theGame(fastGame(1)) = 3
            theGame(fastGame(4)) = 6
            theGame(fastGame(7)) = 9
            theGame(fastGame(3)) = 1
            theGame(fastGame(6)) = 4
            theGame(fastGame(9)) = 7
            fastGameUpdate()
            loc()
        End If
    End Sub

    Private Sub rv_Click(sender As Object, e As EventArgs) Handles rv.Click
        If Not busy Then
            theGame(fastGame(1)) = 7
            theGame(fastGame(2)) = 8
            theGame(fastGame(3)) = 9
            theGame(fastGame(7)) = 1
            theGame(fastGame(8)) = 2
            theGame(fastGame(9)) = 3
            fastGameUpdate()
            loc()
        End If
    End Sub
#End Region

#Region "cheating"
    Sub swapping()
        swapSub(1, 7) : swapSub2(11, 17)
        swapSub(2, 8) : swapSub2(12, 18)
        swapSub(3, 9) : swapSub2(13, 19)
    End Sub

    Sub swapSub(z As Integer, c As Integer)
        temp = theGame(z) : theGame(z) = theGame(c) : theGame(c) = temp
        temp = fastGame(theGame(z)) : fastGame(theGame(z)) = fastGame(theGame(c)) : fastGame(theGame(c)) = temp
    End Sub

    Sub swapSub2(z As Integer, c As Integer)
        temp = theGame(z) : theGame(z) = theGame(c) : theGame(c) = temp
    End Sub

    Sub helping()
        If Not busy Then
            If ok1.Checked AndAlso ok2.Checked Then
                If theGame(0) = "0" Then
                    busy = True
                    swapping()
                    swap = theGame(14)
                    theGame(14) = 7
                    ComputerIntelligence()
                    busy = False
                ElseIf theGame(0) = "1" AndAlso Not computer.Checked Then
                    busy = True
                    swap = theGame(14)
                    theGame(14) = 7
                    ComputerIntelligence()
                End If
            Else
                ooo()
            End If
        End If
    End Sub

    Private Sub help_Click(sender As Object, e As EventArgs) Handles help.Click
        helping()
    End Sub

    Sub undoSub()
        If Not busy Then
            If ok1.Checked = True AndAlso ok2.Checked = True Then
                Dim gh As String
                gh = undo1.Substring(undo1.Length - 2)
                redo1 += gh
                undo1 = undo1.Substring(0, undo1.Length - 2)
                moving(gh(0).ToString, gh(1).ToString, -1)
                theGame(20) = 2
                If theGame(0) = 0 Then
                    theGame(0) = 1
                ElseIf theGame(0) = 1 Then
                    theGame(0) = 0
                End If
                theGame(10) = 0
                If gh(1) = "1" OrElse gh(1) = "2" OrElse gh(1) = "3" Then
                    step1.Text = step1.Text - 1
                Else
                    step2.Text = step2.Text - 1
                End If
                If undo1.Length = 0 Then
                    nf()
                End If
                re()
                loc() : ComputerTurn()
                If VaH.Checked = False Then
                    Wn()
                End If
            Else
                ooo()
            End If
        End If
    End Sub

    Private Sub undo_Click(sender As Object, e As EventArgs) Handles undo.Click
        undoSub()
    End Sub

    Sub redoSub()
        If Not busy Then
            If ok1.Checked = True AndAlso ok2.Checked = True Then
                Dim gh As String
                gh = redo1.Substring(redo1.Length - 2)
                undo1 += gh
                redo1 = redo1.Substring(0, redo1.Length - 2)
                moving(gh(0).ToString, gh(1).ToString, 1)
                If theGame(0) = 0 Then
                    theGame(0) = 1
                ElseIf theGame(0) = 1 Then
                    theGame(0) = 0
                End If
                theGame(10) = 0
                If gh(1) = "1" OrElse gh(1) = "2" OrElse gh(1) = "3" Then
                    step1.Text = step1.Text + 1
                Else
                    step2.Text = step2.Text + 1
                End If
                If redo1.Length = 0 Then
                    rf()
                End If
                ne()
                loc() : ComputerTurn()
                Wn()
            Else
                ooo()
            End If
        End If
    End Sub

    Private Sub redo_Click(sender As Object, e As EventArgs) Handles redo.Click
        redoSub()
    End Sub

    Private Sub secret_CheckedChanged(sender As Object, e As EventArgs) Handles secret.CheckedChanged
        If secret.Checked Then
            XO.Visible = True : OX.Visible = True
        Else
            XO.Visible = False : OX.Visible = False
        End If
    End Sub

    Sub ne()
        undo.Enabled = True
        undo.BackgroundImage = My.Resources.nd
    End Sub

    Sub re()
        redo.Enabled = True
        redo.BackgroundImage = My.Resources.rd
    End Sub

    Sub nf()
        undo.Enabled = False
        undo.BackgroundImage = My.Resources.undo
    End Sub

    Sub rf()
        redo.Enabled = False
        redo.BackgroundImage = My.Resources.redo
    End Sub

    Private Sub XO_Click(sender As Object, e As EventArgs) Handles XO.Click
        If Not busy Then
            If ok1.Checked = True AndAlso ok2.Checked = True Then
                busy = True
                swapping()
                Dim temp As String = step1.Text : step1.Text = step2.Text : step2.Text = temp
                theGame(0) = 1 - theGame(0)
                If theGame(15) = 0 Then ' can not be theGame(15) = 1 - theGame(15)
                    theGame(15) = 1
                ElseIf theGame(15) = 1 Then
                    theGame(15) = 0
                End If
                If theGame(20) = 0 Then
                    theGame(20) = 1
                ElseIf theGame(20) = 1 Then
                    theGame(20) = 0
                End If
                If theGame(10) > 6 Then
                    theGame(10) -= 6
                ElseIf theGame(10) > 0 Then
                    theGame(10) += 6
                End If
                undo1 = undo1.Replace("1", "a").Replace("2", "b").Replace("3", "c")
                undo1 = undo1.Replace("7", "1").Replace("8", "2").Replace("9", "3")
                undo1 = undo1.Replace("a", "7").Replace("b", "8").Replace("c", "9")
                redo1 = redo1.Replace("1", "a").Replace("2", "b").Replace("3", "c")
                redo1 = redo1.Replace("7", "1").Replace("8", "2").Replace("9", "3")
                redo1 = redo1.Replace("a", "7").Replace("b", "8").Replace("c", "9")
                loc()
                busy = False
                ComputerTurn()
            Else
                ooo()
            End If
        End If
    End Sub

    Private Sub OX_Click(sender As Object, e As EventArgs) Handles OX.Click
        If Not busy Then
            If ok1.Checked = True AndAlso ok2.Checked = True Then
                busy = True
                If theGame(0) = "0" Then
                    theGame(0) = "1"
                ElseIf theGame(0) = "1" Then
                    theGame(0) = "0"
                End If
                theGame(10) = "0"
                loc()
                busy = False
                ComputerTurn()
            Else
                ooo()
            End If
        End If
    End Sub

    Sub ooo()
        If lang.Text = "عربي" Then
            MsgBox(("Both of you should agree to this feature by pressing OK"), msg, "warning...")
        Else
            MsgBox(("على كليكما ان توافقا معا على هذه الخاصية بالضغط على موافق"), msg, "تحذير...")
        End If
    End Sub

    Private Sub hp_Click(sender As Object, e As EventArgs) Handles hp.Click
        If lang.Text = "عربي" Then
            MsgBox(("These tools help you to break free from the limitations of the game for the purpose of experimenting or to know the possibilities of different steps or training and learning or cheating and both players must agree to these features together by clicking on (OK)"), msg, "؟!?")
        Else
            MsgBox(("هذه الأدوات تساعدك على التحرر من قيود اللعبة بغرض التجربة أو معرفة إحتمالات الخطوات المختلفة أو التدريب والتعلم أو الغش وعلى كلا اللاعبين أن يوافقا معا على هذه الخواص بالضغط على موافق"), msg, "؟!?")
        End If
        If ok1.Checked AndAlso ok2.Checked Then
            For i = 1 To 9
                TTen.SetToolTip(thePieces(i), i)
            Next
        End If
    End Sub

    Private Sub ok_CheCha(sender As Object, e As EventArgs) Handles ok1.CheckedChanged, ok2.CheckedChanged
        If ok1.Checked AndAlso ok2.Checked Then
            ok += 1
            ok1.Text = "OK +" + ok.ToString
            ok2.Text = "OK +" + ok.ToString
        Else
            For i = 1 To 9
                TTen.SetToolTip(thePieces(i), "")
            Next
        End If
    End Sub
#End Region

#Region "Buttons"
    Private Sub Bu1_Click(sender As Object, e As EventArgs) Handles Bu1.Click
        If lang.Text = "English" Then
            Sega2.Text = "حول"
            Sega2.ckh.Text = "إضغط هنا  لتحميل آخر إصدار من اللعبة"
            Sega2.ckh.Location = New Point(120, 9)
        End If
        Sega2.Show()
    End Sub

    Private Sub VaH_CheckedChanged(sender As Object, e As EventArgs) Handles VaH.CheckedChanged
        If theGame.Count = 0 Then Exit Sub
        If Not VaH.Checked Then
            If theGame(20) = 2 Then
                Wn()
            End If
        Else
            If mDiagonal(1, 2, 3) OrElse sDiagonal(1, 2, 3) OrElse mDiagonal(7, 8, 9) OrElse sDiagonal(7, 8, 9) Then
                theGame(20) = 2
                loc()
            End If
        End If
    End Sub

    Private Sub NoS_Click(sender As Object, e As EventArgs) Handles NoS.Click
        If NoS.Checked = True Then
            If lang.Text = "عربي" Then
                If MsgBox(("- If you activate this feature, the number of steps of both players must be equal to win one of you.
- This feature was made in 2018 for experimental purposes and remains with the game as a souvenir.
- Are you sure you want to enable this feature ?!"), vbYesNo + vbQuestion, "Warning...") = MsgBoxResult.Yes Then
                Else
                    NoS.Checked = False
                End If
            Else
                If MsgBox(("- لو قمت بتفعيل هذه الخاصية،  يجب ان تكون عدد خطوات كلا اللاعبين متساوية ليفوز واحد منكما.
- تمت تلك الخاصية في ٢٠١٨ لأغراض تجريبية وبقيت مع اللعبة كتذكار.
- هل انت متأكد من انك تريد تفعيل هذه الخاصية ?!"), vbYesNo + vbQuestion + vbMsgBoxRight + vbMsgBoxRtlReading, "تحذير...") = MsgBoxResult.Yes Then
                Else
                    NoS.Checked = False
                End If
            End If
            If theGame(20) < 2 Then
                Wn()
            End If
        Else
            Wn()
        End If
    End Sub

    Private Sub NoS_CheckedChanged(sender As Object, e As EventArgs) Handles NoS.CheckedChanged
        If NoS.Checked = True Then
            step1.Visible = True : step2.Visible = True
        Else
            step1.Visible = False : step2.Visible = False
        End If
    End Sub

    Private Sub B10_Click(sender As Object, e As EventArgs) Handles B10.Click
        B11.Visible = True
        B10.Visible = False
        NoS.Visible = False
        If lang.Text = "عربي" Then
            ns.Visible = True
            lns.Visible = True
        Else
            nsAr.Visible = True
            lnsAr.Visible = True
        End If
    End Sub

    Private Sub B11_Click(sender As Object, e As EventArgs) Handles B11.Click
        B10.TabIndex = 22
        B10.Visible = True
        B11.Visible = False
        ns.Visible = False : nsAr.Visible = False
        lns.Visible = False : lnsAr.Visible = False
        B10.TabIndex = 20
        NoS.Visible = True
    End Sub

    Private Sub Bu5_Click(sender As Object, e As EventArgs) Handles Bu5.Click
        B5()
    End Sub

    Sub B5()
        If lang.Text = "عربي" Then
            MsgBox("- If you want to play with the keyboard, Press the 1, 2, 3, 4, 5, 6, 7, 8, 9, z, x, c, a, s, d, q, w or e buttons.
- Use numbers and letters on the keyboard as if they were game boxes.
- Save: F2 or O    - Load: F4 or L    - Save As: R    - Open: F
- Help: F10 or H    - Undo: U    - Redo: I    - OK: F5    - Arabic: G
- Computer: T     - Change the computer's intelligence level: Y
- Start or Stop: P    - Restart All: B or F1    - Restart: N or F3
- Switch the settings buttons: 1! 2@ 3# 4$ 5% 6^
- V & H only or not: J    - Steps of players be equal or not: K
- Download latest version  and  About the designer: M
- Allow the help feature to auto move: F9
- Reduce the lighting: F6 - Raise the lighting: F8 ... Press long.
- Add background: F7    - Enable or disable play to the keyboard: F11
- If you want to continue playing with the keyboard, Do not press the writing boxes.. 
And If you press the writing boxes, press F11 to remove the pressure.", msg, "How to use the keyboard to play ?!")
        Else
            MsgBox("- لو اردت اللعب بلوحة المفاتيح، إضغط على ازرار 1، 2، 3، 4، 5، 6، 7، 8، 9، ئ، ء، ؤ، ش، س، ي، ض، ص أو ث.
- إستخدم الأرقام والحروف التي في لوحة المفاتيح كما لو كانت مربعات اللعبة.
- حفظ: F2 أو خ    - تحميل: F4 أو م    - حفظ كـ: ق     - فتح: ب
- مساعدة: F10 أو أ    - تراجع: ع    - إعادة: هـ    - موافق: F5    - إنجليزي: ل
- الحاسوب: ف     - تغيير مستوى ذكاء الحاسوب: غ
- إبدأ أو توقف: ح    - إعادة بدء الكل: لا أو F1    - إعادة بدء: ى أو F3
- تبديل أزرار الإعدادات: 1! 2@ 3# 4$ 5% 6^
- عمودي أو أفقي فقط أو لا: ت    - خطوات اللاعبين يجب تساويهما أو لا: ن
- تحميل آخر إصدار  و  عن المصمم : ة
- السماح لميزة المساعدة بالتحريك التلقائي: F9
- خفض الإضاءة: F6 - رفع الإضاءة: F8 ... إضغط مطولاً.
- إضافة خلفية: F7    - تمكين أو عدم تمكين اللعب بلوحة المفاتيح: F11
- لو اردت الاستمرار في اللعب بلوحة المفاتيح، لا تضغط على مربعات الكتابة.. 
ولو ضغطت على مربعات الكتابة إضغط على F11 لإزالة الضغط.", msg, "كيفية إستخدام لوحة المفاتيح للعب ؟!")
        End If
    End Sub
#End Region

#Region "ToolTipTitle"
    Private Sub Sega_MouseHover(sender As Object, e As EventArgs) Handles MyBase.MouseHover, hp.MouseHover, z1.MouseHover, z2.MouseHover, z3.MouseHover, a1.MouseHover, a2.MouseHover, a3.MouseHover, c1.MouseHover, c2.MouseHover, c3.MouseHover, undo.MouseHover, redo.MouseHover, win1.MouseHover, win2.MouseHover, step1.MouseHover, step2.MouseHover, im0.MouseHover, im1.MouseHover, im2.MouseHover, player1.MouseHover, player2.MouseHover, name1.MouseHover, name2.MouseHover
        TTar.ToolTipTitle = "" : TTen.ToolTipTitle = ""
    End Sub

    Private Sub Secret_MouseHover(sender As Object, e As EventArgs) Handles secret.MouseHover
        TTar.ToolTipTitle = "!سر"
        TTen.ToolTipTitle = "Secret!"
    End Sub

    Private Sub XO_MouseHover(sender As Object, e As EventArgs) Handles XO.MouseHover
        TTar.ToolTipTitle = "لا أعرف ماذا سيفعل اللاعب الآخر إذا كان مكاني"
        TTen.ToolTipTitle = "I don't know what the other player would do if he was me."
    End Sub

    Private Sub OX_MouseHover(sender As Object, e As EventArgs) Handles OX.MouseHover
        TTar.ToolTipTitle = "ماذا سيحدث إذا تخطيت دوري؟"
        TTen.ToolTipTitle = "What will happen if I skip my turn?"
    End Sub

    Private Sub Help_MouseHover(sender As Object, e As EventArgs) Handles help.MouseHover
        TTar.ToolTipTitle = "ساعدني أرجوك أيها الحاسوب المحترف للغاية"
        TTen.ToolTipTitle = "Please help me, very professional computer."
    End Sub
#End Region

#Region "ChangeColors"
    Sub switchColorRG(picture As Bitmap)
        For i = 0 To picture.Width - 1
            For j = 0 To picture.Height - 1
                clr = picture.GetPixel(i, j)
                If clr.A = 0 Then Continue For
                picture.SetPixel(i, j, Color.FromArgb(clr.A, clr.G, clr.R, clr.B))
            Next
        Next
    End Sub

    Sub switchColorGB(picture As Bitmap)
        For i = 0 To picture.Width - 1
            For j = 0 To picture.Height - 1
                clr = picture.GetPixel(i, j)
                If clr.A = 0 Then Continue For
                picture.SetPixel(i, j, Color.FromArgb(clr.A, clr.R, clr.B, clr.G))
            Next
        Next
    End Sub

    Private Sub player1_Click(sender As Object, e As EventArgs) Handles player1.Click
        If zx Then
            switchColorRG(images(0))
            switchColorRG(images(3))
        Else
            switchColorGB(images(0))
            switchColorGB(images(3))
        End If
        zx = Not zx

        XO5()
        Dim num = images(0).Width * 0.3
        clr = images(0).GetPixel(num, num)
        player1.ForeColor = clr
        name1.ForeColor = clr
        win1.ForeColor = clr
        step1.ForeColor = clr
        ok1.ForeColor = clr
        pic() : ox2()
    End Sub

    Private Sub player2_Click(sender As Object, e As EventArgs) Handles player2.Click
        TTen.SetToolTip(player2, "") : TTar.SetToolTip(player2, "")
        If cv Then
            switchColorRG(images(1))
            switchColorRG(images(2))
            switchColorRG(images(4))
        Else
            switchColorGB(images(1))
            switchColorGB(images(2))
            switchColorGB(images(4))
        End If
        cv = Not cv

        Pwait.BackgroundImage = images(2)
        Icon = Icon.FromHandle(images(1).GetHicon())
        XO5()
        Dim num = images(1).Width * 0.3
        clr = images(1).GetPixel(num, num)
        player2.ForeColor = clr
        name2.ForeColor = clr
        intelligence.ForeColor = clr
        level.ForeColor = clr
        computer.ForeColor = clr
        win2.ForeColor = clr
        step2.ForeColor = clr
        wait.ForeColor = clr
        ok2.ForeColor = clr
        Lf.ForeColor = clr : LfAr.ForeColor = clr
        fst.ForeColor = clr : fstAr.ForeColor = clr
        pic() : ox2()
    End Sub

    Private Sub XO5()
        bitmap = New Bitmap(44, 100)
        Graphics.FromImage(bitmap).DrawImage(images(0), 0, 0, 44, 44)
        Graphics.FromImage(bitmap).DrawImage(images(1), 0, 56, 44, 44)
        Graphics.FromImage(bitmap).DrawImage(images(3), New Point(2, 17))
        Graphics.FromImage(bitmap).DrawImage(images(4), New Point(2, 17))
        XO.BackgroundImage = Nothing : XO.BackgroundImage = bitmap
    End Sub
#End Region

#Region "ComboBoxes"
    Sub iLevel()
        level.SelectedIndex = theGame(14)
    End Sub

    Private Sub level_SelectedIndexChanged(sender As Object, e As EventArgs) Handles level.SelectedIndexChanged
        theGame(14) = level.SelectedIndex
        intelligence.Text = Math.Round(theGame(14) * 100 / 7).ToString + "%"
    End Sub

    Sub plyFrstN()
        playFirst.SelectedIndex = plyFrst
    End Sub

    Private Sub playFirst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles playFirst.SelectedIndexChanged
        plyFrst = playFirst.SelectedIndex
    End Sub

    Sub nsn()
        ns.SelectedIndex = sn
    End Sub

    Private Sub ns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ns.SelectedIndexChanged
        sn = ns.SelectedIndex
        If nsAr.SelectedIndex <> sn Then nsAr.SelectedIndex = sn
    End Sub

    Private Sub nsAr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nsAr.SelectedIndexChanged
        sn = nsAr.SelectedIndex
        If ns.SelectedIndex <> sn Then ns.SelectedIndex = sn
    End Sub
#End Region

#Region "zoom"
    Private Sub zoomIn_Click(sender As Object, e As EventArgs) Handles zoomIn.Click
        If zoom.x = 0 Then
            zoom.zoom()
            originalLocations = locations.ToList
        End If
        zoom.zoomIn()
        For i = 0 To locations.Count - 1
            locations(i) = zoom.newPoint(originalLocations(i))
        Next
        loc1()
    End Sub

    Private Sub zoomOut_Click(sender As Object, e As EventArgs) Handles zoomOut.Click
        If Size.Width > 481 Then
            zoom.zoomOut()
            For i = 0 To locations.Count - 1
                locations(i) = zoom.newPoint(originalLocations(i))
            Next
            loc1()
        End If
    End Sub
#End Region
End Class
