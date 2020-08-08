Imports System.Threading
Imports System.Windows.Forms

Public Class PuzzleGame

#Region "Property and Constructor"
    Private _IsDarkMode As Boolean = False
    Private _PuzzleMode As Boolean = False
    Private _PuzzleSize As Integer = 3

    Friend PuzzleBoard As PuzzleBoard
    Friend PuzzleLogic As PuzzleLogic

    Friend ReadOnly _Canvas As Control

    Private ReadOnly SW As New Stopwatch
    Private WithEvents GameTimer As New Windows.Forms.Timer

    Public Event Score(_Score As String)
    Public Event Ticker(_Time As String)
    Public Event GameState(_IsWin As Boolean)


    Public Property IsDarkMode As Boolean
        Get
            Return _IsDarkMode
        End Get
        Set(value As Boolean)
            If value <> _IsDarkMode Then
                _IsDarkMode = value
                SetBoardColor()
            End If
        End Set
    End Property

    Public Property PuzzleSize As Integer
        Get
            Return _PuzzleSize
        End Get
        Set(value As Integer)
            If value <> _PuzzleSize Then
                _PuzzleSize = value
                SetBoard()
            End If
        End Set
    End Property
    Friend ReadOnly Property MaxLimit As Integer
        Get
            Return PuzzleSize ^ 2
        End Get
    End Property
    Public Property PuzzleMode As Boolean
        Get
            Return _PuzzleMode
        End Get
        Set(value As Boolean)
            If value <> _PuzzleMode Then
                _PuzzleMode = value
                SetBoard()
            End If
        End Set
    End Property

    Public Sub New(Canvas As Control)
        _Canvas = Canvas
        SetBoard()

    End Sub
#End Region

#Region "Method"
    Private Sub SetBoard()
        SW.Stop()
        SW.Reset()
        GameTimer.Stop()

        RaiseEvent Score(0)
        RaiseEvent Ticker("00:00:00")

        If _Canvas.Controls.Find("CPanel1", True).Length > 0 Then
            _Canvas.Controls.Remove(DirectCast(_Canvas.Controls("CPanel1"), PuzzleBoard))
        End If



        PuzzleBoard = New PuzzleBoard(Me)

        PuzzleLogic = New PuzzleLogic(Me)

        With PuzzleBoard

            _Canvas.Controls.Add(PuzzleBoard)

            .SetBoard()

            .Dock = DockStyle.Fill
            .BringToFront()
            .Focus()
            .Enabled = False
        End With

        GC.Collect()

    End Sub

    Private Sub SetBoardColor()
        PuzzleBoard.SetBoardColor()
    End Sub

    Public Sub StartGame()
        SW.Stop()
        SW.Reset()
        GameTimer.Stop()

        RaiseEvent Score(0)
        RaiseEvent Ticker("00:00:00")
        PuzzleBoard.AutoScrollPosition = New Drawing.Point(0, 0)
        PuzzleBoard.Enabled = True
        For i = 0 To 9

            PuzzleLogic.ShuffleBoard()
            Thread.Sleep(25)
        Next

        PuzzleLogic.SetNeighborTiles()

        SW.Start()
        GameTimer.Start()
    End Sub

    Friend Sub EndGame()

        PuzzleBoard.SetButtonDisabled()
        SW.Stop()
        GameTimer.Stop()
        GC.Collect()
    End Sub
    Public Sub LoadNewImage()
        PuzzleLogic.LoadImage()
    End Sub
    Public Function IsAnyImage() As Boolean
        Dim bol As Boolean = False
        If PuzzleLogic.LstImageOriginal.Count > 0 Then bol = True
        Return bol
    End Function

#End Region

#Region "Events"
    Friend Sub RaiseScoreEvent(_score As Integer)
        RaiseEvent Score(_score)
    End Sub
    Friend Sub RaiseGameStateEvent(_isWin As Boolean)
        RaiseEvent GameState(_isWin)
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick

        RaiseEvent Ticker(String.Format("{0:00}:{1:00}:{2:00}", SW.Elapsed.Hours, SW.Elapsed.Minutes, SW.Elapsed.Seconds))
    End Sub
#End Region
End Class
