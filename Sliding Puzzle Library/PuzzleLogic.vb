Imports System.Drawing
Imports System.Windows.Forms


Friend Class PuzzleLogic

    Private ReadOnly _PuzzleGame As PuzzleGame
    Private ReadOnly r As New Random()
    Friend LstImageOriginal As New List(Of Image)

    Private Score As Integer = 0
    Public Sub New(PuzzleGame As PuzzleGame)
        _PuzzleGame = PuzzleGame

    End Sub
#Region "Image Processing"
    Private Function SplitResizeImage(imgSource As Image) As List(Of Image)

        Dim lstOutput As New List(Of Image)
        Using img As New Bitmap(imgSource)

            Dim newWidth As Integer
            Dim newHeight As Integer
            Dim ratio As Double = (img.Width / img.Height)
            If img.Width < img.Height Then
                newHeight = (_PuzzleGame.PuzzleSize * 96) / ratio
                newWidth = newHeight * ratio
            Else
                newWidth = (_PuzzleGame.PuzzleSize * 96) * ratio
                newHeight = newWidth / ratio
            End If

            Using imgScale As New Bitmap(img, newWidth, newHeight)
                Dim h As Integer = (imgScale.Height / _PuzzleGame.PuzzleSize)
                Dim w As Integer = (imgScale.Width / _PuzzleGame.PuzzleSize)

                For i = 0 To _PuzzleGame.PuzzleSize - 1
                    For j = 0 To _PuzzleGame.PuzzleSize - 1
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
    Friend Sub LoadImage()

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

                        For i = 1 To _PuzzleGame.MaxLimit

                            Dim btn As PuzzleTile = _PuzzleGame.PuzzleBoard.GetNormalButton(i)
                            With btn
                                .BackgroundImage = LstImageOriginal(If(.Tag, .Name.Replace("PuzzleTile", Nothing)) - 1) 'coalesce if null/nothing
                            End With

                        Next
                    End Using
                End If
            End With
        End Using

    End Sub

#End Region

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
        If (_PuzzleGame.PuzzleSize Mod 2) = 0 Then

            Dim _countBottom As Integer = 0
            For i = Array.IndexOf(arr, 0) To arr.Count - 1 Step _PuzzleGame.PuzzleSize
                _countBottom += 1
            Next

            Return (_sumInversions Mod 2 = 0) = (_countBottom Mod 2 = 1)

        Else 'odd grid 3x3 5x5 7x7 etc
            Return (_sumInversions Mod 2) = 0
        End If

    End Function

    Friend Sub ShuffleBoard()

        Score = 0
        '------------------------------------------- Fisher-Yates shuffle algorithm used to generate solvable board ---------------------------------------

        'generate sequence number
        'ex 3x3 or _maxlimit = 9
        'output _baseArr() = {1,2,3,4,5,6,7,8,0}
1:      Dim _baseArr() As Integer = Enumerable.Range(1, _PuzzleGame.MaxLimit - 1).Concat(Enumerable.Repeat(0, 1)).ToArray()

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
            _baseArr(Array.IndexOf(_baseArr, 0)) = _PuzzleGame.MaxLimit


            For i = 0 To _PuzzleGame.MaxLimit - 1

                With _PuzzleGame.PuzzleBoard.GetNormalButton(i + 1)

                    .Enabled = False
                    .TileNumber = _baseArr(i)
                    .Tag = .TileNumber

                    If _PuzzleGame.PuzzleMode AndAlso LstImageOriginal.Count > 0 Then .BackgroundImage = LstImageOriginal(.TileNumber - 1)
                    If .TileNumber = _PuzzleGame.MaxLimit Then .TileNumber = ""

                End With

            Next

            _PuzzleGame.PuzzleBoard.Refresh()

        End If

    End Sub
    Friend Sub SetNeighborTiles()
        _PuzzleGame.PuzzleBoard.SetButtonDisabled()

        For i = 0 To _PuzzleGame.PuzzleBoard.GetAllNeighBoard.Count - 1
            _PuzzleGame.PuzzleBoard.GetAllNeighBoard(i).Enabled = True

            RemoveHandler _PuzzleGame.PuzzleBoard.GetAllNeighBoard(i).Click, AddressOf BtnClick
            AddHandler _PuzzleGame.PuzzleBoard.GetAllNeighBoard(i).Click, AddressOf BtnClick
        Next

        _PuzzleGame.PuzzleBoard.ScrollControlIntoView(_PuzzleGame.PuzzleBoard.GetEmptyButton)

    End Sub
    Private Function IsWin() As Boolean


        Dim count As Integer = _PuzzleGame.PuzzleBoard.Controls.OfType(Of PuzzleTile).Where(Function(x) x.TileNumber = x.Name.Replace("PuzzleTile", Nothing)).Count()

        If count = _PuzzleGame.MaxLimit - 1 Then Return True Else Return False

    End Function
    Friend Sub Swap(PrevButton As PuzzleTile, NextButton As PuzzleTile)

        If PrevButton.Visible AndAlso Not NextButton.Visible Then
            _PuzzleGame.PuzzleBoard.SetButtonDisabled()

            AnimateWindow(PrevButton.Handle, 50, AnimateWindowFlags.AW_HIDE Or AnimateWindowFlags.AW_BLEND)
            AnimateWindow(NextButton.Handle, 150, AnimateWindowFlags.AW_CENTER Or AnimateWindowFlags.AW_ACTIVATE)

            NextButton.TileNumber = PrevButton.TileNumber
            If _PuzzleGame.PuzzleMode Then NextButton.BackgroundImage = PrevButton.BackgroundImage

            PrevButton.TileNumber = "" 'if null then tile is not visible

            SetNeighborTiles()

            Score += 1
            _PuzzleGame.RaiseScoreEvent(Score)

            If IsWin() Then _PuzzleGame.EndGame() : _PuzzleGame.RaiseGameStateEvent(True) Else _PuzzleGame.RaiseGameStateEvent(False)
        End If

    End Sub


    Private Sub BtnClick(ByVal PrevButton As Object, ByVal e As EventArgs) 'if playing using mouse

        Swap(PrevButton, _PuzzleGame.PuzzleBoard.GetEmptyButton)

    End Sub

End Class
