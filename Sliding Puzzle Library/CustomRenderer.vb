Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

Public Class CustomRenderer
    Inherits ToolStripProfessionalRenderer
    Implements IDisposable

    Public Property IsDarkMode As Boolean = False
    'light
    Private ReadOnly _ColorGradientLight As Color = ControlPaint.Light(Color.FromArgb(26, 115, 176))
    Private ReadOnly _ColorArrowCheckSelectedLight As Color = Color.White
    Private ReadOnly _ColorArrowCheckNormalLight As Color = Color.FromArgb(50, 0, 0, 0)

    'dark
    Private ReadOnly _ColorGradientDark As Color = ControlPaint.Dark(Color.FromArgb(26, 115, 176), 0.25)
    Private ReadOnly _ColorArrowCheckSelectedDark As Color = Color.FromArgb(255, 0, 255, 0)
    Private ReadOnly _ColorArrowCheckNormalDark As Color = Color.FromArgb(100, 0, 0, 0)
    Private disposedValue As Boolean

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

            Dim rect As Rectangle = New Rectangle(-1, -1, e.Item.Size.Width, e.Item.Size.Height)

            'backcolor
            e.Graphics.FillRectangle(New SolidBrush(If(IsDarkMode, Color.FromArgb(66, 66, 66), Color.FromArgb(30, 98, 145))), rect)

            'border
            If IsDarkMode Then e.Graphics.DrawRectangle(New Pen(Color.FromArgb(33, 33, 33)), rect)

        End If

    End Sub

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
End Class

