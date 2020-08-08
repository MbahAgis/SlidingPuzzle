Imports Sliding_Puzzle_Library

Public Class FrmMain
#Region "Variable, Constructor, FormAnimation"
    Public WithEvents PuzzleGame As PuzzleGame

    Private PuzzleMode As Boolean = False
    Private ModeString As String = "Number"
    Private PuzzleSize As Integer = 3
    Public IsDarkMode As Boolean = False


    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        UpdateStyles()

    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
        ChangeTheme(False, True)
        AnimateWindow(Handle, 200, AnimateWindowFlags.AW_BLEND)
        PuzzleGame = New PuzzleGame(Me)

    End Sub

    Protected Overrides Sub OnClosed(e As EventArgs)
        MyBase.OnClosed(e)
        AnimateWindow(Handle, 400, AnimateWindowFlags.AW_HIDE Or AnimateWindowFlags.AW_BLEND)
    End Sub

#End Region
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.F2 Then
            StartGame()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#Region "MenuStripClick Event"

    Private Sub ChangeTheme(IsChanged As Boolean, IsFirstTime As Boolean)

        If IsChanged Then AnimateWindow(Handle, 150, AnimateWindowFlags.AW_HIDE Or AnimateWindowFlags.AW_BLEND)
        Using CstmRenderer As New CustomRenderer(IsDarkMode)
            MenuStrip1.Renderer = CstmRenderer
            StatusStrip1.Renderer = CstmRenderer
            ToolStrip1.Renderer = CstmRenderer
            If Not IsFirstTime Then PuzzleGame.IsDarkMode = IsDarkMode
            If IsDarkMode Then BackColor = Color.FromArgb(48, 48, 48) Else BackColor = Color.FromArgb(238, 238, 242)
        End Using
        If IsChanged Then Show()

    End Sub
    Private Sub SetBoard(IsChanged As Boolean)

        If IsChanged Then AnimateWindow(Handle, 250, AnimateWindowFlags.AW_HIDE Or AnimateWindowFlags.AW_BLEND)
        PuzzleGame.PuzzleMode = PuzzleMode
        PuzzleGame.PuzzleSize = PuzzleSize

        If IsChanged Then
            Show()
            Top = ((Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2))
            Left = ((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2))
        End If


    End Sub
    Private Function SetMenuCheckedState(OldValue As Object, NewValue As Object, ParentMenu As ToolStripMenuItem) As Boolean
        Dim chkMenu As ToolStripMenuItem = CType(NewValue, ToolStripMenuItem)
        For Each x As ToolStripMenuItem In ParentMenu.DropDownItems
            If x IsNot chkMenu Then
                x.Checked = False
            Else
                x.Checked = True
            End If
        Next

        Dim isChanged As Boolean = False
        If OldValue <> chkMenu.Text Then isChanged = True

        Return isChanged
    End Function
    Private Sub MenuMode_Click(sender As Object, e As EventArgs) Handles MenuImage.Click, MenuNumber.Click
        Dim isChanged As Boolean = SetMenuCheckedState(ModeString, sender, SubMenuMode)

        If sender.Text = "Image" Then MenuImportImage.Enabled = True : PuzzleMode = True Else MenuImportImage.Enabled = False : PuzzleMode = False
        ModeString = sender.Text

        SetWaitCursor("Changing puzzle mode", New Action(Sub() SetBoard(isChanged)))
    End Sub
    Private Sub MenuIsDarkMode_Click(sender As Object, e As EventArgs) Handles MenuLight.Click, MenuDark.Click
        Dim isChanged As Boolean = SetMenuCheckedState(If(IsDarkMode, "Dark", "Light"), sender, SubMenuThemes)

        If sender.Text = "Dark" Then IsDarkMode = True Else IsDarkMode = False

        SetWaitCursor("Changing color theme", New Action(Sub() ChangeTheme(isChanged, False)))
    End Sub
    Private Sub MenuPuzzleSize_Click(sender As Object, e As EventArgs) Handles PuzzleSize3.Click, PuzzleSize4.Click, PuzzleSize5.Click, PuzzleSizeCustom.Click
        Dim isChanged As Boolean = SetMenuCheckedState(String.Format("{0} x {0}", PuzzleSize), sender, SubMenuSize)
        If Not sender.Text = "Custom" Then
            PuzzleSize = Strings.Right(sender.Text, 1)
        Else
            'inputBox validation
1:          Dim userInput As String = InputBox("Enter Number From 4 - 20 Ex: 4 (It Means 4 x 4)", "Custom Size", 10)
            If Not IsNumeric(userInput) Then
                MsgBox("You must input number between 4 and 20", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Information")
                GoTo 1
            Else
                If userInput > 20 Or userInput < 4 Then
                    MsgBox("You must input number between 4 and 20", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Information")
                    GoTo 1
                Else
                    PuzzleSize = userInput
                End If
            End If
        End If

        SetWaitCursor("Changing puzzle size", New Action(Sub() SetBoard(isChanged)))
    End Sub
#End Region
    Public Sub StartGame()

        If PuzzleGame.PuzzleMode AndAlso Not PuzzleGame.IsAnyImage Then
            MsgBox("Please choose an image first", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Information")
            Exit Sub
        End If

        SetWaitCursor("Randomize Board", New Action(Sub() PuzzleGame.StartGame()))

    End Sub
    Private Sub SetWaitCursor(TextStatus As String, Method As Action)

        Application.UseWaitCursor = True
        Cursor = Cursors.WaitCursor
        MenuStrip1.Enabled = False
        LblTitle.Text = TextStatus
        LblTitle.GetCurrentParent.Update()


        Method()
        LblTitle.Text = String.Format("Sliding Puzzle | Mode: {0} | Size: {1} x {1}", ModeString, PuzzleSize)


        MenuStrip1.Enabled = True
        Application.UseWaitCursor = False
        Cursor = Cursors.Default

    End Sub
    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuNewGame.Click
        StartGame()
    End Sub
    Private Sub MenuImportImage_Click(sender As Object, e As EventArgs) Handles MenuImportImage.Click

        PuzzleGame.LoadNewImage()

    End Sub
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles MenuClose.Click, BtnExit.Click
        Close()
    End Sub



    Private Sub PuzzleGame_Score(_score As String) Handles PuzzleGame.Score
        LblScore.Text = "Score : " & _score
    End Sub

    Private Sub PuzzleGame_Ticker(_time As String) Handles PuzzleGame.Ticker
        LblTimer.Text = "Timer : " & _time
    End Sub

    Private Sub PuzzleGame_GameState(_isWin As Boolean) Handles PuzzleGame.GameState
        If _isWin Then
            Dim frm As New FrmWin
            With frm
                .Owner = Me
                Using CstmRenderer As New CustomRenderer(IsDarkMode)
                    .ToolStrip1.Renderer = CstmRenderer
                End Using

                .LblScore.Text = "Your " & LblScore.Text
                If PuzzleMode Then .LblMode.Text = "Start New Game With New Image?" Else .LblMode.Text = "Start New Game?"
                .LblTitle.Text = LblTitle.Text
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub FrmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, ToolStrip1.MouseDown,
        StatusStrip1.MouseDown, LblTitle.MouseDown, MenuStrip1.MouseDown, LblScore.MouseDown, LblTimer.MouseDown

        SetMouseDown(Me, e)
    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SetRoundedEdges(Me)
    End Sub

End Class

