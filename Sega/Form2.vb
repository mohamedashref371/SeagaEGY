Public Class Sega2
    Public Ihash As String = "pULIUS4lIIoFMk2BkLn2XudZtxuCp6TJ5tbRul4G2P0="

    Private Sub Sega2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Now.Day = 5 And Now.Month = 11 Then
            ClientSize = New Size(548, 158)
            MyP.Location = New Point(100, 125) : I.Location = New Point(123, 101)
            f1.Location = New Point(95, 101) : f2.Location = New Point(434, 101) : f3.Location = New Point(75, 125) : f4.Location = New Point(450, 125)
            A.Location = New Point(12, 109) : B.Location = New Point(486, 109)
            LMhmd.Location = New Point(160, 77)
            dy.Visible = True
        End If
    End Sub

    Private Sub MyP_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles MyP.LinkClicked
        Process.Start("https://facebook.com/FamilyKingsandQueensofcomputer371")
    End Sub

    Private Sub I_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles I.LinkClicked
        Process.Start("https://facebook.com/Mohamed3713317")
    End Sub

    Private Sub ckh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ckh.LinkClicked
        If Now.Day Mod 2 = 0 Then
            Process.Start("https://www.mediafire.com/file/0wv97m4n96q5y0v")
        Else
            Process.Start("https://www.mediafire.com/folder/97yewsgabttb1")
        End If
    End Sub

    Private Sub A_Click(sender As Object, e As EventArgs) Handles A.Click
        Process.Start("https://www.mediafire.com/folder/f7ywtgzgczv3b")
    End Sub

    Private Sub B_Click(sender As Object, e As EventArgs) Handles B.Click
        Process.Start("https://www.mediafire.com/file/mdmwg5pwwjo4g3l")
    End Sub
End Class