Imports System.Drawing
Imports System.Windows.Forms

Friend Class PuzzleBoard
    Inherits Panel

    Private ReadOnly _PuzzleGame As PuzzleGame
    Public Sub New(PuzzleGame As PuzzleGame)
        _PuzzleGame = PuzzleGame
        Name = "CPanel1"
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        AutoScroll = True
        Padding = New Padding(0, 0, 2, 2)
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

#Region "Board Appearance"
    Friend Sub SetBoardColor()
        If _PuzzleGame.IsDarkMode Then BackColor = Color.FromArgb(48, 48, 48) Else BackColor = Color.FromArgb(238, 238, 242)

        For Each x In Controls.OfType(Of PuzzleTile)
            x.IsDarkMode = _PuzzleGame.IsDarkMode
        Next

    End Sub

    Friend Sub SetBoard()

        Dim btn(_PuzzleGame.MaxLimit - 1) As PuzzleTile
        For i = 0 To _PuzzleGame.PuzzleSize - 1
            For j = 0 To _PuzzleGame.PuzzleSize - 1

                'n = y * w + x
                Dim offset As Integer = ((j * _PuzzleGame.PuzzleSize) + i) + 1
                btn(offset - 1) = New PuzzleTile()
                With btn(offset - 1)
                    .Name = "PuzzleTile" & offset
                    .TileNumber = .Name.Replace("PuzzleTile", Nothing)
                    .TileSize = 96
                    .Location = New Point(5 + (i * 96) * 1.07,
                                                             5 + (j * 96) * 1.07) 'i: left, j: top
                    .IsDarkMode = _PuzzleGame.IsDarkMode
                    .DrawCheckMark = True
                    .DrawBorderValidMove = True
                    .Enabled = False
                    .Rows = j + 1
                    .Columns = i + 1

                    If offset = _PuzzleGame.MaxLimit Then .TileNumber = ""


                End With
            Next
        Next
        Controls.AddRange(btn)

    End Sub



#End Region

#Region "Events"

    Private Sub PuzzleBoard_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        SetMouseDown(_PuzzleGame._Canvas, e)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        Select Case keyData
            Case Keys.Left
                _PuzzleGame.PuzzleLogic.Swap(GetAllNeighBoard(2), GetEmptyButton)
                Return True
            Case Keys.Up
                _PuzzleGame.PuzzleLogic.Swap(GetAllNeighBoard(3), GetEmptyButton)
                Return True
            Case Keys.Right
                _PuzzleGame.PuzzleLogic.Swap(GetAllNeighBoard(0), GetEmptyButton)
                Return True
            Case Keys.Down
                _PuzzleGame.PuzzleLogic.Swap(GetAllNeighBoard(1), GetEmptyButton)
                Return True
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region

    Friend Sub SetButtonDisabled()
        For Each x In Controls
            x.Enabled = False
        Next
        _PuzzleGame.PuzzleBoard.Focus()
    End Sub
    Friend Function GetNormalButton(Idx As Integer) As PuzzleTile
        Return DirectCast(Controls("PuzzleTile" & Idx), PuzzleTile)
    End Function
    Friend Function GetEmptyButton() As PuzzleTile
        Return Controls.OfType(Of PuzzleTile).Where(Function(x) x.TileNumber = "").First
    End Function
    Friend Function GetAllNeighBoard() As List(Of PuzzleTile)
        Dim listButton As New List(Of PuzzleTile) From {
            GetNeighborButton(GetEmptyButton.Rows, GetEmptyButton.Columns - 1), 'left
            GetNeighborButton(GetEmptyButton.Rows - 1, GetEmptyButton.Columns), 'top
            GetNeighborButton(GetEmptyButton.Rows, GetEmptyButton.Columns + 1), 'right
            GetNeighborButton(GetEmptyButton.Rows + 1, GetEmptyButton.Columns) 'bottom
        }

        Return listButton

    End Function
    Private Function GetNeighborButton(Rows As Integer, Columns As Integer) As PuzzleTile
        Dim btn As PuzzleTile = Controls.OfType(Of PuzzleTile).Where(Function(x) x.Rows = Rows AndAlso x.Columns = Columns).FirstOrDefault
        If btn Is Nothing Then
            Return GetEmptyButton()
        Else
            Return btn
        End If
    End Function

End Class
