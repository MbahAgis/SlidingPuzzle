Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Module ModuleHelper

    <DllImport("user32.dll")>
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr

    End Function

    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Function CreateRoundRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer, ByVal nWidthEllipse As Integer, ByVal nHeightEllipse As Integer) As IntPtr

    End Function

    <DllImport("Gdi32.dll", EntryPoint:="DeleteObject")>
    Public Function DeleteObject(hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function

    <DllImport("user32.dll")>
    Private Function ReleaseCapture() As Boolean
    End Function

    <Flags()>
    Enum AnimateWindowFlags
        AW_HOR_POSITIVE = &H1
        AW_HOR_NEGATIVE = &H2
        AW_VER_POSITIVE = &H4
        AW_VER_NEGATIVE = &H8
        AW_CENTER = &H10
        AW_HIDE = &H10000
        AW_ACTIVATE = &H20000
        AW_SLIDE = &H40000
        AW_BLEND = &H80000
    End Enum
    <DllImport("user32.dll")>
    Public Function AnimateWindow(ByVal hwnd As IntPtr, ByVal time As Integer, ByVal flags As AnimateWindowFlags) As Boolean
    End Function

    '-------------------- win32api hide/schow scrollbar panel ------------
    <Flags()>
    Enum ScrollBarDirection
        SB_HORZ = 0
        SB_VERT = 1
        SB_CTL = 2
        SB_BOTH = 3
    End Enum
    <DllImport("user32.dll")>
    Public Function ShowScrollBar(ByVal hWnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As Boolean
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = 161
    Private Const HT_CAPTION As Integer = 2

    Public Sub SetMouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(sender.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)

        End If
    End Sub
    '-----------------------------------------------------------------

    Public Sub SetRoundedEdges(Ctl As Control)
        Dim rndRect As IntPtr = CreateRoundRectRgn(0, 0, Ctl.ClientRectangle.Width, Ctl.ClientRectangle.Height, 15, 15)
        Ctl.Region = Region.FromHrgn(rndRect)

        DeleteObject(rndRect)
    End Sub
    Public Function InvertColor(ClrSource As Color) As Color
        Return Color.FromArgb(255 - ClrSource.R, 255 - ClrSource.G, 255 - ClrSource.B)
    End Function
End Module
