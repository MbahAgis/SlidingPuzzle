
Imports System.Drawing
Imports System.Drawing.Text
Imports System.Windows.Forms

Public Class PuzzleTile
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
            If value <> _TileNumber Then
                _TileNumber = value
                If String.IsNullOrEmpty(_TileNumber) Then
                    Visible = False
                Else
                    Visible = True
                End If

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
        Size = New Size(96, 96)
        Font = New Font("Segoe Script", 18, FontStyle.Regular, GraphicsUnit.Point)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        UpdateStyles()
        SetRoundedEdges(Me)

    End Sub
    Private Sub SetHoverColor()
        _isHover = True
        BackColor = _backColor
        Cursor = Cursors.Hand
    End Sub
    Private Sub SetNormalColor()
        _isHover = False
        BackColor = _backColor
        Cursor = Cursors.Default
    End Sub

#Region "Event"

    Private Sub PuzzleTile_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter, Me.GotFocus
        SetHoverColor()

    End Sub
    Private Sub PuzzleTile_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave, Me.LostFocus
        SetNormalColor()
    End Sub
    Private Sub PuzzleTile_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

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

        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias

        'draw checkmark
        If DrawCheckMark Then
            If TileNumber.ToString = Name.Replace("PuzzleTile", Nothing) Then
                Dim rect As Rectangle = ClientRectangle
                rect.X += 2
                rect.Y += 2
                e.Graphics.DrawString(ChrW(&H2714), Font, Brushes.Green, rect)

            End If
        End If

        'tile foreColor
        Using brush As New SolidBrush(If(IsDarkMode, If(_isHover, InvertColor(Color.FromArgb(200, 255, 255, 255)), Color.FromArgb(200, 255, 255, 255)), 'forecolor darkmode
             If(_isHover, InvertColor(Color.FromArgb(165, 0, 0, 0)), Color.FromArgb(200, 0, 0, 0))))
            e.Graphics.DrawString(TileNumber, Font, brush, ClientRectangle, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End Using


    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        SetRoundedEdges(Me)
    End Sub
#End Region

End Class