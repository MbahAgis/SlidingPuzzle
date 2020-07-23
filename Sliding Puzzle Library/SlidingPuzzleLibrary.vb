
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms

Public Class CPuzzle

#Region "Property"
    Private _score, _idxCurrentButton As Integer
    Private _time As String
    Private _isNewGame As Boolean = False
    Private Const TileSize As Integer = 96
    Private Const TilesSpace As Double = 1.06

    Private _IsDarkMode As Boolean = False
    Private _mode As Boolean = False
    Private _PuzzleSize As Integer = 3
    Private _maxLimit As Integer = _PuzzleSize ^ 2

    Private ReadOnly r As New Random
    Private ReadOnly _sw As New Stopwatch
    Private WithEvents GameTimer As New Windows.Forms.Timer
    Private WithEvents BgwAppearance, BgwShuffle As New BackgroundWorker
    Private WithEvents Board As CPanel

    Private LstImageOriginal As New List(Of Image)
    Private ReadOnly LstNeighbor As New List(Of CButton)

    Public Event Ticker(Time As String)
    Public Event CountClick(Score As Integer, WinStatus As Boolean)
    Public Event IsBusy(BgwBusyStatus As Boolean, TextStatus As String)

    Public Sub New(Canvas As CPanel)
        Board = Canvas
        BgwAppearance.WorkerSupportsCancellation = True
        BgwShuffle.WorkerSupportsCancellation = True
        PuzzleSize = _PuzzleSize
        Mode = _mode
        IsDarkMode = _IsDarkMode

        SetBoard(True)
    End Sub

    Public Property IsDarkMode As Boolean
        Get
            Return _IsDarkMode
        End Get
        Set(value As Boolean)
            _IsDarkMode = value
            SetBoardColor()
        End Set
    End Property

    Public Property PuzzleSize As Integer
        Get
            Return _PuzzleSize
        End Get
        Set(value As Integer)
            If value <> _PuzzleSize Then
                _PuzzleSize = value
                SetBoard(True)
            End If
        End Set
    End Property
    Public Property Mode As Boolean
        Get
            Return _mode
        End Get
        Set(value As Boolean)
            If value <> _mode Then
                _mode = value
                SetBoard(True)
            End If
        End Set
    End Property
#End Region
#Region "Image Processing"
    Private Function SplitResizeImage(imgSource As Image) As List(Of Image)

        Dim lstOutput As New List(Of Image)
        Using img As New Bitmap(imgSource)

            Dim newWidth As Integer
            Dim newHeight As Integer
            Dim ratio As Double = (img.Width / img.Height)
            If img.Width < img.Height Then
                newHeight = (PuzzleSize * TileSize) / ratio
                newWidth = newHeight * ratio
            Else
                newWidth = (PuzzleSize * TileSize) * ratio
                newHeight = newWidth / ratio
            End If

            Using imgScale As New Bitmap(img, newWidth, newHeight)
                Dim h As Integer = (imgScale.Height / PuzzleSize)
                Dim w As Integer = (imgScale.Width / PuzzleSize)

                For i = 0 To PuzzleSize - 1
                    For j = 0 To PuzzleSize - 1
                        Dim offset As Integer = ((j * PuzzleSize) + i)
                        Dim arrImage As New Bitmap(w, h)

                        Using gr As Graphics = Graphics.FromImage(arrImage)
                            gr.DrawImage(imgScale, New Rectangle(5, 5, w - 5, h - 5), New Rectangle(j * w, i * h, w, h), GraphicsUnit.Pixel)
                        End Using
                        lstOutput.Add(arrImage)
                    Next
                Next
            End Using
        End Using
        Return lstOutput
    End Function
    Public Sub LoadImage()

        Using OFD As New OpenFileDialog()
            With OFD
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                .FileName = Nothing
                .Multiselect = False
                .Title = "Pick an Image"
                .Filter = "Image files (*.jpg, , *.bmp, *.png) | *.jpg; *.bmp; *.png"
                If .ShowDialog = 1 Then
                    Using img As New Bitmap(Image.FromFile(.FileName))
                        LstImageOriginal = SplitResizeImage(img)
                        For i = 1 To _maxLimit
                            Dim btn As CButton = DirectCast(Board.Controls("CButton" & i), CButton)
                            With btn
                                .BackgroundImage = LstImageOriginal(If(.Tag, .Name.Replace("CButton", Nothing)) - 1) 'coalesce if null/nothing
                            End With
                        Next
                    End Using
                End If
            End With
        End Using

    End Sub
#End Region

#Region "Board Appearance"
    Private Sub SetBoardColor()
        If Board.InvokeRequired Then
            Board.Invoke(New MethodInvoker(Sub() SetBoardColor()))
        Else
            If _IsDarkMode Then Board.BackColor = Color.FromArgb(48, 48, 48) Else Board.BackColor = Color.FromArgb(238, 238, 242)

            For i = 0 To Board.Controls.Count - 1
                DirectCast(Board.Controls(i), CButton).IsDarkMode = IsDarkMode
            Next
        End If
    End Sub
    Private Sub SetBoard(IsFirstSetup As Boolean)
        _score = 0
        _time = "00:00:00"
        _sw.Stop()
        _sw.Reset()
        GameTimer.Stop()

        RaiseEvent CountClick(_score, IsWin)
        RaiseEvent Ticker(_time)

        If IsFirstSetup Then
            _isNewGame = False
            LstImageOriginal.Clear()
            _maxLimit = PuzzleSize ^ 2

            RaiseEvent IsBusy(True, "Resizing Board")
            If Not BgwAppearance.IsBusy Then
                BgwAppearance.RunWorkerAsync()
            End If

        Else
            _isNewGame = True
            Board.AutoScrollPosition = New Point(0, 0)
            If Not BgwShuffle.IsBusy Then BgwShuffle.RunWorkerAsync()
        End If

    End Sub

    Private Sub SetTiles()
        If Board.InvokeRequired Then
            Board.Invoke(New MethodInvoker(Sub() SetTiles()))
        Else

            Board.Visible = False
            Board.Controls.Clear()

            For i = 0 To PuzzleSize - 1
                For j = 0 To PuzzleSize - 1

                    'n = y * w + x
                    Dim offset As Integer = ((j * PuzzleSize) + i) + 1
                    Dim btn As New CButton
                    With btn
                        .Name = "CButton" & offset
                        .TileNumber = .Name.Replace("CButton", Nothing)
                        .TileSize = TileSize
                        .Location = New Point(5 + (i * TileSize) * TilesSpace,
                                                 5 + (j * TileSize) * TilesSpace) 'i: left, j: top
                        .IsDarkMode = IsDarkMode
                        .DrawCheckMark = True
                        .DrawBorderValidMove = True
                        .Enabled = False
                        .Rows = j + 1
                        .Columns = i + 1

                        If offset = _maxLimit Then .Visible = False
                        Board.Controls.Add(btn)
                        RemoveHandler .Click, AddressOf BtnClick

                        AddHandler .Click, AddressOf BtnClick

                    End With
                Next
            Next

            Board.Visible = True
        End If
    End Sub
    Private Sub BgwAppearance_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwAppearance.DoWork
        Try
            SetTiles()
        Catch ex As Exception
            e.Result = ex.ToString
            e.Cancel = True
        End Try

    End Sub

    Private Sub BgwAppearance_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwAppearance.RunWorkerCompleted

        RaiseEvent IsBusy(BgwAppearance.IsBusy, "Sliding Puzzle")
        If Not e.Cancelled Then
            Board.Focus()
        Else
            MsgBox(e.Result.ToString)
        End If

    End Sub
#End Region
#Region "Game Logic"
    Private Function IsSolvable(arr() As Integer) As Boolean

        '1. calculate inversions
        Dim _sumInversions As Integer = 0

        For i = 0 To arr.Count - 1
            For j = i + 1 To arr.Count - 1
                If arr(i) > arr(j) AndAlso arr(j) > 0 Then _sumInversions += 1

            Next
        Next

        '2. check the rules
        'even grid 4x4 6x6 8x8 etc
        If (PuzzleSize Mod 2) = 0 Then

            Dim _countBottom As Integer = 0
            For i = Array.IndexOf(arr, 0) To arr.Count - 1 Step PuzzleSize
                _countBottom += 1
            Next

            Return (_sumInversions Mod 2 = 0) = (_countBottom Mod 2 = 1)

        Else 'odd grid 3x3 5x5 7x7 etc
            Return (_sumInversions Mod 2) = 0
        End If

    End Function

    Private Sub ShuffleBoard()
1:      If Board.InvokeRequired Then
            Board.Invoke(New MethodInvoker(Sub() ShuffleBoard()))
        Else

            RaiseEvent IsBusy(BgwShuffle.IsBusy, "Reshuffle The Board")

            '------------------------------------------- Fisher-Yates shuffle algorithm used to generate solvable board ---------------------------------------

            'generate sequence number
            'ex 3x3 or _maxlimit = 9
            'output _baseArr() = {1,2,3,4,5,6,7,8,0}
            Dim _baseArr() As Integer = Enumerable.Range(1, _maxLimit - 1).Concat(Enumerable.Repeat(0, 1)).ToArray()

            For i = 0 To _baseArr.Count - 2
                Dim j As Integer = r.Next(i + 1, _baseArr.Count)
                Dim temp As Integer = _baseArr(j)
                _baseArr(j) = _baseArr(i)
                _baseArr(i) = temp

            Next
            '---------------------------------------------------------------------------------------------------------------------------------

            If Not IsSolvable(_baseArr) Then
                GoTo 1
            Else

                'if solvable, then replace 0 number with _maxlimit
                _baseArr(Array.IndexOf(_baseArr, 0)) = _maxLimit


                For i = 0 To _maxLimit - 1
                    Dim btn As CButton = DirectCast(Board.Controls("CButton" & (i + 1)), CButton)
                    If btn IsNot Nothing Then
                        With btn
                            .Enabled = False
                            If _isNewGame Then .TileNumber = _baseArr(i) Else .TileNumber = i + 1
                            .Tag = .TileNumber

                            If Mode AndAlso LstImageOriginal.Count > 0 Then .BackgroundImage = LstImageOriginal(.TileNumber - 1)
                            If .TileNumber = _maxLimit Then .TileNumber = 0 : _idxCurrentButton = .Name.Replace("CButton", Nothing)

                        End With
                    End If
                Next


                Board.Update()
            End If
        End If
    End Sub
    Private Sub BgwShuffle_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgwShuffle.DoWork
        Try
            For i = 1 To 10 'shuffle 10 times
                ShuffleBoard()
                Thread.Sleep(25)
            Next
        Catch ex As Exception
            e.Result = ex.ToString
            e.Cancel = True
        End Try
    End Sub

    Private Sub BgwShuffle_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgwShuffle.RunWorkerCompleted

        RaiseEvent IsBusy(BgwShuffle.IsBusy, "Sliding Puzzle")
        If Not e.Cancelled Then
            SetNeighborTiles()
            _sw.Start()
            GameTimer.Start()
            Board.Focus()
        Else
            MsgBox(e.Result.ToString)
        End If

    End Sub
    Private Sub SetNeighborTiles()
        If Board.InvokeRequired Then
            Board.Invoke(New MethodInvoker(Sub() SetNeighborTiles()))
        Else

            LstNeighbor.Clear()

            For i = 0 To _maxLimit - 1
                Board.Controls(i).Enabled = False
            Next


            'rules left top right bottom
            Dim rules() As Integer = {_idxCurrentButton - 1, _idxCurrentButton - (PuzzleSize), _idxCurrentButton + 1, _idxCurrentButton + (PuzzleSize)}

            For i = 0 To rules.Length - 1

                'limit all neighbor tiles
                If rules(i) < 1 Or rules(i) > _maxLimit Then rules(i) = _idxCurrentButton

                'extra rules left and right neighbor
                If (i Mod 2 = 0) AndAlso DirectCast(Board.Controls("CButton" & rules(i)), CButton).Rows <> DirectCast(Board.Controls("CButton" & _idxCurrentButton), CButton).Rows Then rules(i) = _idxCurrentButton

                Board.Controls("CButton" & rules(i)).Enabled = True

                LstNeighbor.Add(Board.Controls("CButton" & rules(i)))
            Next
            Board.Controls("CButton" & _idxCurrentButton).Enabled = False
            Board.ScrollControlIntoView(Board.Controls("CButton" & _idxCurrentButton))
            Board.Update()

        End If
    End Sub
    Private Sub BtnClick(ByVal PrevButton As Object, ByVal e As EventArgs) 'if playing using mouse

        If DirectCast(PrevButton, CButton) IsNot Nothing Then Play(PrevButton)

    End Sub
    Private Sub Swap(Button1 As CButton, Button2 As CButton)

        With Button2
            .TileNumber = Button1.TileNumber
            If Mode Then .BackgroundImage = Button1.BackgroundImage
        End With

        With Button1
            .TileNumber = 0 'if 0 then tile is not visible
            _idxCurrentButton = .Name.Replace("CButton", Nothing)
        End With

        SetNeighborTiles()
        Board.Focus()

        _score += 1

    End Sub
    Private Sub Play(PrevButton As CButton)

        Dim nextButton As CButton = DirectCast(Board.Controls("CButton" & _idxCurrentButton), CButton)

        If PrevButton.Enabled AndAlso Not nextButton.Enabled Then Swap(PrevButton, nextButton)

        If IsWin() Then EndGame()

        RaiseEvent CountClick(_score, IsWin)

    End Sub

    Private Function IsWin() As Boolean
        Dim count As Integer = 0
        For i = 1 To _maxLimit
            Dim btn As CButton = DirectCast(Board.Controls("CButton" & i), CButton)
            If btn IsNot Nothing Then If btn.TileNumber = btn.Name.Replace("CButton", Nothing) Then count += 1
        Next

        If _score > 0 AndAlso count = _maxLimit - 1 Then Return True Else Return False

    End Function

    Public Function IsAnyImage() As Boolean
        Dim bol As Boolean = False
        If LstImageOriginal.Count > 0 Then bol = True

        Return bol
    End Function

    Public Sub StartGame()
        SetBoard(False)
    End Sub
    Private Sub EndGame()
        _isNewGame = False
        For i = 0 To Board.Controls.Count - 1
            Board.Controls(i).Enabled = False
        Next
        _sw.Stop()
        GameTimer.Stop()
        GC.Collect()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick

        _time = String.Format("{0:00}:{1:00}:{2:00}", _sw.Elapsed.TotalHours, _sw.Elapsed.TotalMinutes, _sw.Elapsed.Seconds)

        RaiseEvent Ticker(_time)

    End Sub

    Private Sub Board_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Board.PreviewKeyDown 'if playing using keyboard
        If _isNewGame Then
            Select Case e.KeyCode
                Case Keys.Left
                    Play(LstNeighbor(2))
                Case Keys.Right
                    Play(LstNeighbor(0))
                Case Keys.Up
                    Play(LstNeighbor(3))
                Case Keys.Down
                    Play(LstNeighbor(1))
                Case Keys.F2
                    StartGame()
            End Select

        End If
    End Sub

#End Region
End Class

Public Class CButton
    Inherits Button

#Region "Property"
    Private _IsDarkMode As Boolean = False
    Private _backColor As Color = Color.White
    Private _DrawCheckMark As Boolean = True
    Private _DrawBorderValidMove As Boolean = True
    Private _BackColorLight As Color = Color.White
    Private _BackColorDark As Color = Color.FromArgb(66, 66, 66)

    Private _isHover As Boolean = False
    Private _TileNumber As String = 1
    Private _TileSize As Integer = 96
    Private _TileNumberAlign As StringAlignment = StringAlignment.Center
    Private _TileNumberLineAlign As StringAlignment = StringAlignment.Center

    Public Property Columns As Integer = 1
    Public Property Rows As Integer = 1

    Public Property DrawCheckMark As Boolean
        Get
            Return _DrawCheckMark
        End Get
        Set
            If Value <> _DrawCheckMark Then
                _DrawCheckMark = Value
                Invalidate()
            End If
        End Set
    End Property

    Public Property TileSize As Integer
        Get
            Return _TileSize
        End Get
        Set
            If Value <> _TileSize Then
                _TileSize = Value
                Size = New Size(_TileSize, _TileSize)
                Invalidate()
            End If
        End Set
    End Property
    Public Property TileNumber As String
        Get
            Return _TileNumber
        End Get
        Set(value As String)
            _TileNumber = value
            If _TileNumber = "0" Then
                Visible = False
            Else
                Visible = True

            End If
            Invalidate()
        End Set

    End Property

    Public Property TileNumberAlign As StringAlignment
        Get
            Return _TileNumberAlign
        End Get
        Set
            If Value <> _TileNumberAlign Then
                _TileNumberAlign = Value

                Invalidate()
            End If
        End Set
    End Property
    Public Property TileNumberLineAlign As StringAlignment
        Get
            Return _TileNumberLineAlign
        End Get
        Set(value As StringAlignment)
            If value <> _TileNumberLineAlign Then
                _TileNumberLineAlign = value
                Invalidate()
            End If

        End Set
    End Property
    Public Property IsDarkMode As Boolean
        Get
            Return _IsDarkMode
        End Get
        Set(value As Boolean)
            If value <> _IsDarkMode Then
                _IsDarkMode = value

                BackColor = _backColor
                Invalidate()
            End If
        End Set
    End Property
    Public Overrides Property BackgroundImage As Image
        Get
            Return MyBase.BackgroundImage
        End Get
        Set(value As Image)
            If value IsNot Nothing Then
                BackgroundImageLayout = ImageLayout.Stretch
            End If

            MyBase.BackgroundImage = value
        End Set
    End Property
    Public Overrides Property BackColor As Color
        Get
            Return _backColor
        End Get
        Set(value As Color)

            _backColor = value
            If _IsDarkMode Then
                _backColor = If(_isHover, InvertColor(BackColorDark), BackColorDark)
            Else
                _backColor = If(_isHover, Color.FromArgb(0, 166, 236), BackColorLight)
            End If

            MyBase.BackColor = _backColor
            Invalidate()
        End Set
    End Property
    Public Property BackColorLight As Color
        Get
            Return _BackColorLight
        End Get
        Set(value As Color)
            If Not _IsDarkMode Then
                If value.ToArgb() <> _BackColorLight.ToArgb() Then
                    _BackColorLight = value
                    BackColor = _BackColorLight
                    Invalidate()
                End If
            End If
        End Set
    End Property
    Public Property BackColorDark As Color
        Get
            Return _BackColorDark
        End Get
        Set(value As Color)
            If _IsDarkMode Then
                If value.ToArgb() <> _BackColorDark.ToArgb() Then

                    _BackColorDark = value
                    BackColor = _BackColorDark
                    Invalidate()
                End If
            End If

        End Set
    End Property

    Public Property DrawBorderValidMove As Boolean
        Get
            Return _DrawBorderValidMove
        End Get
        Set(value As Boolean)
            If value <> _DrawBorderValidMove Then
                _DrawBorderValidMove = value
                Invalidate()
            End If
        End Set
    End Property
#End Region
    Public Sub New()
        FlatStyle = FlatStyle.Flat
        FlatAppearance.BorderSize = 0

        Size = New Size(_TileSize, _TileSize)
        Font = New Font("Segoe Script", 18, FontStyle.Regular, GraphicsUnit.Point)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        UpdateStyles()
    End Sub

#Region "Event"
    Private Sub CButton_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter, Me.GotFocus
        _isHover = True
        BackColor = _backColor
        Cursor = Cursors.Hand
    End Sub

    Private Sub CButton_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave, Me.LostFocus
        _isHover = False
        BackColor = _backColor
        Cursor = Cursors.Default
    End Sub
    Private Sub CButton_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias

        If DrawBorderValidMove Then 'draw border for valid move tile
            If Enabled Then
                Using pn As New Pen(
                      If(IsDarkMode, InvertColor(BackColor), If(_isHover, BackColor, Color.FromArgb(87, 198, 249))), 'color
                        If(_isHover, 18, 12)) 'pen size
                    e.Graphics.DrawRectangle(pn, ClientRectangle)
                End Using
            Else
                If BackgroundImage IsNot Nothing Then
                    e.Graphics.DrawRectangle(New Pen(_backColor, 16), ClientRectangle)
                End If

            End If
        End If

        'draw checkmark
        If DrawCheckMark Then
            If TileNumber.ToString = Name.Replace("CButton", Nothing) Then
                Dim rect As Rectangle = ClientRectangle
                rect.X += 2
                rect.Y += 2
                e.Graphics.DrawString(ChrW(&H2714), Font, Brushes.Green, rect)

            End If
        End If

        'tile foreColor
        Using brush As New SolidBrush(If(IsDarkMode, If(_isHover, InvertColor(Color.FromArgb(200, 255, 255, 255)), Color.FromArgb(200, 255, 255, 255)), 'forecolor darkmode
                 If(_isHover, InvertColor(Color.FromArgb(165, 0, 0, 0)), Color.FromArgb(200, 0, 0, 0))))
            e.Graphics.DrawString(TileNumber, Font, brush, ClientRectangle, New StringFormat With {.Alignment = TileNumberAlign, .LineAlignment = TileNumberLineAlign})
        End Using
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        SetRoundedEdges(Me)
    End Sub

#End Region

End Class

Public Class CPanel
    Inherits Panel

    Public Sub New()
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        AutoScroll = True
        Margin = New Padding(18)

        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        UpdateStyles()
    End Sub


    Protected Overrides Sub WndProc(ByRef m As Message)
        'hide the scrollbar
        MyBase.WndProc(m)
        ShowScrollBar(Handle, ScrollBarDirection.SB_BOTH, False)

    End Sub
    'Horizontal Scroll Shortcut Key (Ctrl + Scroll)
    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        If VScroll AndAlso (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            VScroll = False
            MyBase.OnMouseWheel(e)
            VScroll = True
        Else
            MyBase.OnMouseWheel(e)
        End If
    End Sub

End Class

Public Class CustomRenderer
    Inherits ToolStripProfessionalRenderer
    Implements IDisposable

    Private disposedValue As Boolean
    Public Property IsDarkMode As Boolean = False
    'light
    Private ReadOnly _ColorGradientLight As Color = ControlPaint.Light(Color.FromArgb(26, 115, 176))
    Private ReadOnly _ColorArrowCheckSelectedLight As Color = Color.White
    Private ReadOnly _ColorArrowCheckNormalLight As Color = Color.FromArgb(50, 0, 0, 0)

    'dark
    Private ReadOnly _ColorGradientDark As Color = ControlPaint.Dark(Color.FromArgb(26, 115, 176), 0.25)
    Private ReadOnly _ColorArrowCheckSelectedDark As Color = Color.FromArgb(255, 0, 255, 0)
    Private ReadOnly _ColorArrowCheckNormalDark As Color = Color.FromArgb(100, 0, 0, 0)
    Public Sub New(_IsDarkMode As Boolean)
        MyBase.New(New CustomColorTable(_IsDarkMode))
        RoundedEdges = False
        IsDarkMode = _IsDarkMode
    End Sub

    'draw toolstrip, menustrip, statusstrip font
    Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
        Using fnt As New Font("Segoe UI", 9, If(e.Item.Name = "LblTitle", FontStyle.Italic Or FontStyle.Bold, FontStyle.Regular), GraphicsUnit.Point)
            Dim rc As Rectangle = e.TextRectangle

            rc.Width = e.Item.Width
            e.TextFont = fnt
            e.TextRectangle = rc
            e.TextColor = If(IsDarkMode, Color.FromArgb(50, 255, 255, 255), Color.FromArgb(150, 222, 222, 222))
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        End Using

        MyBase.OnRenderItemText(e)
    End Sub

    'change backcolor main menu
    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        If IsDarkMode Then
            e.ToolStrip.BackColor = Color.FromArgb(33, 33, 33)

            MyBase.OnRenderToolStripBackground(e)
        Else
            Using b As New LinearGradientBrush(e.AffectedBounds, _ColorGradientLight, _ColorGradientDark, LinearGradientMode.Horizontal)
                e.Graphics.FillRectangle(b, e.AffectedBounds)
            End Using
        End If

    End Sub

    'change backcolor submenu/dropdown toolstripmenuitem ; default gray
    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If e.ToolStrip.IsDropDown Then
            Dim rc As Rectangle = New Rectangle(Point.Empty, e.Item.Size)
            If IsDarkMode Then

                Using brush As SolidBrush = New SolidBrush(Color.FromArgb(33, 33, 33))
                    e.Graphics.FillRectangle(brush, rc)
                End Using

            Else
                Using b As New LinearGradientBrush(rc, _ColorGradientLight, _ColorGradientDark, LinearGradientMode.Horizontal)
                    e.Graphics.FillRectangle(b, rc)
                End Using
            End If

            MyBase.OnRenderMenuItemBackground(e)
        Else
            MyBase.OnRenderMenuItemBackground(e)
        End If

    End Sub
    'change arrow color
    Protected Overrides Sub OnRenderArrow(ByVal e As ToolStripArrowRenderEventArgs)
        If e.Item.Selected Then e.ArrowColor = If(IsDarkMode, _ColorArrowCheckSelectedDark, _ColorArrowCheckSelectedLight) _
            Else e.ArrowColor = If(IsDarkMode, _ColorArrowCheckNormalDark, _ColorArrowCheckNormalLight)

        MyBase.OnRenderArrow(e)
    End Sub

    'remove border toolstrip
    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        If TypeOf e.ToolStrip Is ToolStrip Then Else MyBase.OnRenderToolStripBorder(e)
    End Sub

    'change checkmark color
    Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)
        Dim bounds As Rectangle = e.ImageRectangle
        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias

        'background checkmark
        e.Graphics.FillRectangle(New SolidBrush(If(IsDarkMode, Color.FromArgb(60, 60, 60), Color.FromArgb(150, 200, 200, 200))), bounds)


        Using fnt As New Font("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point)
            If e.Item.Selected AndAlso CType(e.Item, ToolStripMenuItem).Checked Then
                'draw the checkmark with full color
                e.Graphics.DrawString(ChrW(&H2714), fnt, New SolidBrush(If(IsDarkMode, _ColorArrowCheckSelectedDark, _ColorArrowCheckSelectedLight)), bounds)
            Else
                'draw the checkmark with transparancy
                e.Graphics.DrawString(ChrW(&H2714), fnt, New SolidBrush(If(IsDarkMode, _ColorArrowCheckNormalDark, _ColorArrowCheckNormalLight)), bounds)

            End If
        End Using
    End Sub
    'coloring the highlighted button in toolstrip, ex; close button on form
    Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)

        If Not e.Item.Selected Then
            MyBase.OnRenderButtonBackground(e)
        Else
            Dim rectangle As Rectangle = New Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1)

            'backcolor
            e.Graphics.FillRectangle(New SolidBrush(If(IsDarkMode, Color.FromArgb(66, 66, 66), Color.FromArgb(30, 98, 145))), rectangle)

            'border
            If IsDarkMode Then e.Graphics.DrawRectangle(New Pen(Color.FromArgb(33, 33, 33)), rectangle)

        End If

    End Sub





#Region "Dispose"


    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class

Public Class CustomColorTable
    Inherits ProfessionalColorTable

    Private ReadOnly _ColorMenuSelectedDark As Color = Color.FromArgb(66, 66, 66)
    Private ReadOnly _ColorMenuPressedDark As Color = Color.FromArgb(23, 23, 23)

    Private ReadOnly _ColorMenuSelectedLight As Color = Color.FromArgb(75, 181, 201, 214)
    Private ReadOnly _ColorMenuPressedLight As Color = Color.FromArgb(75, 40, 40, 40)

    Public ReadOnly Property IsDarkMode As Boolean = False
    Public Sub New(IsDarkModeColor As Boolean)
        IsDarkMode = IsDarkModeColor
        UseSystemColors = False

    End Sub

#Region "Color MenuStrip Hover, Selected, Pressed"
    Public Overrides ReadOnly Property MenuBorder As Color
        Get

            Return Color.Empty
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder As Color
        Get
            Return Color.Empty
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected As Color
        Get

            Return If(IsDarkMode, _ColorMenuSelectedDark, _ColorMenuSelectedLight)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
        Get

            Return If(IsDarkMode, _ColorMenuSelectedDark, _ColorMenuSelectedLight)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
        Get

            Return If(IsDarkMode, _ColorMenuSelectedDark, _ColorMenuSelectedLight)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
        Get
            Return If(IsDarkMode, _ColorMenuPressedDark, _ColorMenuPressedLight)

        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientMiddle As Color
        Get
            Return If(IsDarkMode, _ColorMenuPressedDark, _ColorMenuPressedLight)

        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
        Get
            Return If(IsDarkMode, _ColorMenuPressedDark, _ColorMenuPressedLight)

        End Get
    End Property

#End Region
End Class

Public Module Module1

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr

    End Function

    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Public Function CreateRoundRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer, ByVal nWidthEllipse As Integer, ByVal nHeightEllipse As Integer) As IntPtr

    End Function

    <DllImport("Gdi32.dll", EntryPoint:="DeleteObject")>
    Public Function DeleteObject(ByVal hObject As IntPtr) As Boolean

    End Function

    <DllImport("user32.dll")>
    Private Function ReleaseCapture() As Boolean
    End Function

    '-------------------- win32api hide/schow scrollbar panel ------------
    Public Enum ScrollBarDirection
        SB_HORZ = 0
        SB_VERT = 1
        SB_CTL = 2
        SB_BOTH = 3
    End Enum
    <DllImport("user32.dll")>
    Public Function ShowScrollBar(ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Const WM_NCLBUTTONDOWN As Integer = 161
    Public Const HT_CAPTION As Integer = 2

    Public Sub SetMouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(sender.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)

        End If
    End Sub
    '-----------------------------------------------------------------

    Public Sub SetRoundedEdges(Ctl As Control)
        Dim rndRect As IntPtr = CreateRoundRectRgn(0, 0, Ctl.Width, Ctl.Height, 15, 15)
        Ctl.Region = Region.FromHrgn(rndRect)

        DeleteObject(rndRect)
    End Sub
    Public Function InvertColor(ClrSource As Color) As Color
        Return Color.FromArgb(255 - ClrSource.R, 255 - ClrSource.G, 255 - ClrSource.B)
    End Function
End Module
