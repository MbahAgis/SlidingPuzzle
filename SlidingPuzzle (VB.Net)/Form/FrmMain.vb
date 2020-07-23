
Imports Sliding_Puzzle_Library

Public Class FrmMain

    Public WithEvents NewPuzzle As CPuzzle
    Private mode As Boolean = False
    Private modeString As String = "Number"
    Public IsDarkMode As Boolean = False
    Private PuzzleSize As Integer = 3

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        UpdateStyles()
    End Sub
    Private Sub ChangeTheme()
        Using CstmRenderer As New CustomRenderer(IsDarkMode)
            MenuStrip1.Renderer = CstmRenderer
            StatusStrip1.Renderer = CstmRenderer
            ToolStrip1.Renderer = CstmRenderer
            NewPuzzle.IsDarkMode = IsDarkMode
            If IsDarkMode Then BackColor = Color.FromArgb(48, 48, 48) Else BackColor = Color.FromArgb(238, 238, 242)
        End Using
    End Sub
    Private Sub MenuMode_Click(sender As Object, e As EventArgs) Handles MenuImage.Click, MenuNumber.Click
        Dim chkMenu() As ToolStripMenuItem = {MenuImage, MenuNumber}
        Dim currentLvl As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        For i = 0 To chkMenu.Length - 1
            If chkMenu(i).Name <> currentLvl.Name Then
                chkMenu(i).Checked = False
            Else
                chkMenu(i).Checked = True
                ' Dim frmt As String = String.Format(" | Mode: {0} | Size: {1} x {1}", currentLvl.Text, PuzzleSize + 2)
                If currentLvl.Text = "Number" Then MenuImport.Enabled = False : mode = False Else MenuImport.Enabled = True : mode = True
            End If
        Next
        modeString = currentLvl.Text
        NewPuzzle.Mode = mode
        NewPuzzle.PuzzleSize = PuzzleSize

    End Sub
    Private Sub MenuIsDarkMode_Click(sender As Object, e As EventArgs) Handles MenuLight.Click, MenuDark.Click
        Dim chkMenu() As ToolStripMenuItem = {MenuLight, MenuDark}
        Dim currentLvl As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        For i = 0 To chkMenu.Length - 1
            If chkMenu(i).Name <> currentLvl.Name Then
                chkMenu(i).Checked = False
            Else
                chkMenu(i).Checked = True
                If chkMenu(i).Name = "MenuLight" Then MenuDark.Checked = False : IsDarkMode = False Else MenuLight.Checked = False : IsDarkMode = True
            End If
        Next
        ChangeTheme()
    End Sub
    Private Sub MenuPuzzleSize_Click(sender As Object, e As EventArgs) Handles PuzzleSize3.Click, PuzzleSize4.Click, PuzzleSize5.Click, PuzzleSizeCustom.Click
        Dim chkMenu() As ToolStripMenuItem = {PuzzleSize3, PuzzleSize4, PuzzleSize5, PuzzleSizeCustom}
        Dim currentLvl As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        For i = 0 To chkMenu.Length - 1
            If chkMenu(i).Name <> currentLvl.Name Then
                chkMenu(i).Checked = False
            Else
                chkMenu(i).Checked = True
                If i < 3 Then
                    PuzzleSize = Strings.Right(currentLvl.Name, 1)
                Else
                    'inputBox validation
1:                  Dim userInput As String = InputBox("Enter Number From 4 - 20 Ex: 4 (It Means 4 x 4)", "Custom Size", 10)
                    If Not IsNumeric(userInput) Then
                        MsgBox("You must input number between 4 and 20", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Information")
                        GoTo 1
                    Else
                        If userInput > 50 Or userInput < 4 Then
                            MsgBox("You must input number between 4 and 20", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Information")
                            GoTo 1
                        Else
                            PuzzleSize = userInput
                        End If
                    End If
                End If
                NewPuzzle.Mode = mode
                NewPuzzle.PuzzleSize = PuzzleSize
            End If
        Next
    End Sub
    Private Sub StartGame()
        If NewPuzzle.Mode Then
            If Not NewPuzzle.IsAnyImage Then
                MsgBox("Please choose an image first", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Information")
                Exit Sub
            End If
        End If
        NewPuzzle.StartGame()
    End Sub
    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuNewGame.Click
        StartGame()
    End Sub
    Private Sub MenuImport_Click(sender As Object, e As EventArgs) Handles MenuImport.Click
        NewPuzzle.LoadImage()
    End Sub
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles MenuClose.Click, BtnExit.Click
        Close()
    End Sub
    Private Sub NewPuzzle_CountClick(Score As Integer, WinStatus As Boolean) Handles NewPuzzle.CountClick
        LblScore.Text = "Score : " & Score
        If Score > 0 AndAlso WinStatus Then
            Dim frm As New FrmWin
            With frm
                .Owner = Me
                Using CstmRenderer As New CustomRenderer(IsDarkMode)
                    .ToolStrip1.Renderer = CstmRenderer
                End Using

                .LblScore.Text = "Your " & LblScore.Text
                If mode Then .LblMode.Text = "Start New Game With New Image?" Else .LblMode.Text = "Start New Game?"

                .ShowDialog()
            End With
        End If
    End Sub
    Private Sub NewPuzzle_Ticker(Time As String) Handles NewPuzzle.Ticker
        LblTimer.Text = "Timer :" & Time
    End Sub
    Private Sub NewPuzzle_IsBusy(BgwBusyStatus As Boolean, TextStatus As String) Handles NewPuzzle.IsBusy
        Dim frmt As String = String.Format(" | Mode: {0} | Size: {1} x {1}", modeString, PuzzleSize)

        If BgwBusyStatus Then
            Application.UseWaitCursor = True
            Cursor = Cursors.WaitCursor
            MenuStrip1.Enabled = False
            LblTitle.Text = TextStatus

        Else
            MenuStrip1.Enabled = True
            LblTitle.Text = TextStatus & frmt
            Application.UseWaitCursor = False
            Cursor = Cursors.Default

        End If

    End Sub

    Private Sub FrmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, ToolStrip1.MouseDown,
        StatusStrip1.MouseDown, LblTitle.MouseDown, MenuStrip1.MouseDown, LblScore.MouseDown, LblTimer.MouseDown, CPanel1.MouseDown
        SetMouseDown(Me, e)
    End Sub
    Private Sub FrmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            StartGame()
        End If
    End Sub
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewPuzzle = New CPuzzle(CPanel1)
        ChangeTheme()
        MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        SetRoundedEdges(Me)
        Top = ((Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2))
        Left = ((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2))

        Update()
    End Sub
End Class

