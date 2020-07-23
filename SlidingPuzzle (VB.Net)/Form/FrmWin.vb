Imports Sliding_Puzzle_Library
Public Class FrmWin

    Private Sub SetColor()
        Dim bckColor, frColor As Color
        If DirectCast(Owner, FrmMain).IsDarkMode Then
            bckColor = Color.FromArgb(48, 48, 48)
            frColor = Color.White
            BtnYes.IsDarkMode = True
            BtnNo.IsDarkMode = True
        Else
            bckColor = Color.FromArgb(238, 238, 242)
            frColor = Color.Black
            BtnYes.IsDarkMode = False
            BtnNo.IsDarkMode = False
        End If
        BackColor = bckColor
        For Each x As Control In Controls
            If TypeOf x Is Label Then
                x.BackColor = bckColor
                x.ForeColor = frColor
            End If
        Next
        BtnYes.Focus()
    End Sub
    Private Sub FrmWin_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Using media As New Media.SoundPlayer(My.Resources.Ta_Da)
            media.Play()
        End Using

    End Sub

    Private Sub FrmWin_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetColor()

    End Sub
    Private Sub FrmWin_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, ToolStrip1.MouseDown,
            LblTitle.MouseDown, MenuClose.MouseDown, LblCongrats.MouseDown, LblMode.MouseDown, LblScore.MouseDown
        SetMouseDown(Me, e)
    End Sub
    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles BtnYes.Click
        Close()
        DirectCast(Me.Owner, FrmMain).NewPuzzle.StartGame()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs) Handles MenuClose.Click, BtnNo.Click
        Close()
    End Sub
    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)
        SetRoundedEdges(Me)
    End Sub

End Class