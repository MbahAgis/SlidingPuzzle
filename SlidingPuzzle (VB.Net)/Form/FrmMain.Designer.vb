<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.LblTimer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblScore = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubMenuMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuNumber = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubMenuSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.PuzzleSize3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PuzzleSize4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PuzzleSize5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PuzzleSizeCustom = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubMenuThemes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuLight = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuDark = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuImportImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuNewGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.LblTitle = New System.Windows.Forms.ToolStripLabel()
        Me.MenuClose = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTimer
        '
        Me.LblTimer.AutoSize = False
        Me.LblTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LblTimer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTimer.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.LblTimer.Name = "LblTimer"
        Me.LblTimer.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.LblTimer.Size = New System.Drawing.Size(220, 23)
        Me.LblTimer.Spring = True
        Me.LblTimer.Text = "Timer : 00:00:00"
        '
        'LblScore
        '
        Me.LblScore.AutoSize = False
        Me.LblScore.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScore.Margin = New System.Windows.Forms.Padding(5, 3, 0, 3)
        Me.LblScore.Name = "LblScore"
        Me.LblScore.Size = New System.Drawing.Size(70, 23)
        Me.LblScore.Text = "Score : 0"
        Me.LblScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AllowMerge = False
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblScore, Me.LblTimer})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 368)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(312, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 34
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOptions, Me.MenuImportImage, Me.MenuNewGame})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 33)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.MenuStrip1.Size = New System.Drawing.Size(312, 24)
        Me.MenuStrip1.TabIndex = 42
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuOptions
        '
        Me.MenuOptions.AutoSize = False
        Me.MenuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SubMenuMode, Me.SubMenuSize, Me.SubMenuThemes, Me.BtnExit})
        Me.MenuOptions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuOptions.Name = "MenuOptions"
        Me.MenuOptions.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.MenuOptions.ShortcutKeyDisplayString = ""
        Me.MenuOptions.ShowShortcutKeys = False
        Me.MenuOptions.Size = New System.Drawing.Size(55, 20)
        Me.MenuOptions.Text = "Options"
        Me.MenuOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SubMenuMode
        '
        Me.SubMenuMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuNumber, Me.MenuImage})
        Me.SubMenuMode.Name = "SubMenuMode"
        Me.SubMenuMode.Size = New System.Drawing.Size(141, 22)
        Me.SubMenuMode.Text = "Puzzle Mode"
        '
        'MenuNumber
        '
        Me.MenuNumber.Checked = True
        Me.MenuNumber.CheckOnClick = True
        Me.MenuNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuNumber.Name = "MenuNumber"
        Me.MenuNumber.Size = New System.Drawing.Size(118, 22)
        Me.MenuNumber.Text = "Number"
        '
        'MenuImage
        '
        Me.MenuImage.CheckOnClick = True
        Me.MenuImage.Name = "MenuImage"
        Me.MenuImage.Size = New System.Drawing.Size(118, 22)
        Me.MenuImage.Text = "Image"
        '
        'SubMenuSize
        '
        Me.SubMenuSize.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PuzzleSize3, Me.PuzzleSize4, Me.PuzzleSize5, Me.PuzzleSizeCustom})
        Me.SubMenuSize.Name = "SubMenuSize"
        Me.SubMenuSize.Size = New System.Drawing.Size(141, 22)
        Me.SubMenuSize.Text = "Puzzle Size"
        '
        'PuzzleSize3
        '
        Me.PuzzleSize3.Checked = True
        Me.PuzzleSize3.CheckOnClick = True
        Me.PuzzleSize3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PuzzleSize3.Name = "PuzzleSize3"
        Me.PuzzleSize3.Size = New System.Drawing.Size(116, 22)
        Me.PuzzleSize3.Text = "3 x 3"
        '
        'PuzzleSize4
        '
        Me.PuzzleSize4.CheckOnClick = True
        Me.PuzzleSize4.Name = "PuzzleSize4"
        Me.PuzzleSize4.Size = New System.Drawing.Size(116, 22)
        Me.PuzzleSize4.Text = "4 x 4"
        '
        'PuzzleSize5
        '
        Me.PuzzleSize5.CheckOnClick = True
        Me.PuzzleSize5.Name = "PuzzleSize5"
        Me.PuzzleSize5.Size = New System.Drawing.Size(116, 22)
        Me.PuzzleSize5.Text = "5 x 5"
        '
        'PuzzleSizeCustom
        '
        Me.PuzzleSizeCustom.CheckOnClick = True
        Me.PuzzleSizeCustom.Name = "PuzzleSizeCustom"
        Me.PuzzleSizeCustom.Size = New System.Drawing.Size(116, 22)
        Me.PuzzleSizeCustom.Text = "Custom"
        '
        'SubMenuThemes
        '
        Me.SubMenuThemes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuLight, Me.MenuDark})
        Me.SubMenuThemes.Name = "SubMenuThemes"
        Me.SubMenuThemes.Size = New System.Drawing.Size(141, 22)
        Me.SubMenuThemes.Text = "Themes"
        '
        'MenuLight
        '
        Me.MenuLight.Checked = True
        Me.MenuLight.CheckOnClick = True
        Me.MenuLight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MenuLight.Name = "MenuLight"
        Me.MenuLight.Size = New System.Drawing.Size(101, 22)
        Me.MenuLight.Text = "Light"
        '
        'MenuDark
        '
        Me.MenuDark.Name = "MenuDark"
        Me.MenuDark.Size = New System.Drawing.Size(101, 22)
        Me.MenuDark.Text = "Dark"
        '
        'BtnExit
        '
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.ShortcutKeyDisplayString = ""
        Me.BtnExit.Size = New System.Drawing.Size(141, 22)
        Me.BtnExit.Text = "Exit"
        '
        'MenuImportImage
        '
        Me.MenuImportImage.AutoSize = False
        Me.MenuImportImage.Enabled = False
        Me.MenuImportImage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuImportImage.Name = "MenuImportImage"
        Me.MenuImportImage.ShowShortcutKeys = False
        Me.MenuImportImage.Size = New System.Drawing.Size(110, 20)
        Me.MenuImportImage.Text = "Import New Image"
        Me.MenuImportImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuNewGame
        '
        Me.MenuNewGame.AutoSize = False
        Me.MenuNewGame.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuNewGame.Name = "MenuNewGame"
        Me.MenuNewGame.ShowShortcutKeys = False
        Me.MenuNewGame.Size = New System.Drawing.Size(92, 20)
        Me.MenuNewGame.Text = "(F2) New Game"
        Me.MenuNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblTitle, Me.MenuClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(5, 3, 1, 3)
        Me.ToolStrip1.ShowItemToolTips = False
        Me.ToolStrip1.Size = New System.Drawing.Size(312, 33)
        Me.ToolStrip1.TabIndex = 130
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = False
        Me.LblTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Image = CType(resources.GetObject("LblTitle.Image"), System.Drawing.Image)
        Me.LblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(270, 24)
        Me.LblTitle.Text = "Sliding Puzzle | Mode: Number | Size: 3 x 3"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuClose
        '
        Me.MenuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MenuClose.BackColor = System.Drawing.Color.Transparent
        Me.MenuClose.Image = CType(resources.GetObject("MenuClose.Image"), System.Drawing.Image)
        Me.MenuClose.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.MenuClose.Name = "MenuClose"
        Me.MenuClose.Size = New System.Drawing.Size(23, 24)
        '
        'FrmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(312, 397)
        Me.ControlBox = False
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(312, 397)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTimer As ToolStripStatusLabel
    Friend WithEvents LblScore As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuOptions As ToolStripMenuItem
    Friend WithEvents SubMenuMode As ToolStripMenuItem
    Friend WithEvents MenuNumber As ToolStripMenuItem
    Friend WithEvents MenuImage As ToolStripMenuItem
    Friend WithEvents SubMenuSize As ToolStripMenuItem
    Friend WithEvents PuzzleSize3 As ToolStripMenuItem
    Friend WithEvents PuzzleSize4 As ToolStripMenuItem
    Friend WithEvents PuzzleSize5 As ToolStripMenuItem
    Friend WithEvents PuzzleSizeCustom As ToolStripMenuItem
    Friend WithEvents SubMenuThemes As ToolStripMenuItem
    Friend WithEvents MenuLight As ToolStripMenuItem
    Friend WithEvents MenuDark As ToolStripMenuItem
    Friend WithEvents BtnExit As ToolStripMenuItem
    Friend WithEvents MenuImportImage As ToolStripMenuItem
    Friend WithEvents MenuNewGame As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents LblTitle As ToolStripLabel
    Friend WithEvents MenuClose As ToolStripButton
End Class
