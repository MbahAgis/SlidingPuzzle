Imports System.Drawing
Imports System.Windows.Forms

Friend Class CustomColorTable
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
