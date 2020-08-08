
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmWin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWin))
        Me.LblCongrats = New System.Windows.Forms.Label()
        Me.LblScore = New System.Windows.Forms.Label()
        Me.LblMode = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.LblTitle = New System.Windows.Forms.ToolStripLabel()
        Me.MenuClose = New System.Windows.Forms.ToolStripButton()
        Me.BtnNo = New Sliding_Puzzle_Library.PuzzleTile()
        Me.BtnYes = New Sliding_Puzzle_Library.PuzzleTile()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblCongrats
        '
        Me.LblCongrats.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblCongrats.Font = New System.Drawing.Font("Segoe Script", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCongrats.Location = New System.Drawing.Point(-1, 47)
        Me.LblCongrats.Name = "LblCongrats"
        Me.LblCongrats.Size = New System.Drawing.Size(342, 30)
        Me.LblCongrats.TabIndex = 128
        Me.LblCongrats.Text = "Congratulations !!!"
        Me.LblCongrats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblScore
        '
        Me.LblScore.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblScore.Font = New System.Drawing.Font("Segoe Script", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScore.Location = New System.Drawing.Point(-1, 82)
        Me.LblScore.Name = "LblScore"
        Me.LblScore.Size = New System.Drawing.Size(342, 30)
        Me.LblScore.TabIndex = 127
        Me.LblScore.Text = "Your Score: "
        Me.LblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMode
        '
        Me.LblMode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblMode.Font = New System.Drawing.Font("Segoe Script", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMode.Location = New System.Drawing.Point(-1, 136)
        Me.LblMode.Name = "LblMode"
        Me.LblMode.Size = New System.Drawing.Size(342, 36)
        Me.LblMode.TabIndex = 126
        Me.LblMode.Text = "Start New Game?"
        Me.LblMode.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.ToolStrip1.Size = New System.Drawing.Size(341, 33)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 129
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = False
        Me.LblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.Image = CType(resources.GetObject("LblTitle.Image"), System.Drawing.Image)
        Me.LblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(270, 24)
        Me.LblTitle.Text = "Sliding Puzzle"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuClose
        '
        Me.MenuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MenuClose.AutoSize = False
        Me.MenuClose.BackColor = System.Drawing.Color.Transparent
        Me.MenuClose.Image = CType(resources.GetObject("MenuClose.Image"), System.Drawing.Image)
        Me.MenuClose.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.MenuClose.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.MenuClose.Name = "MenuClose"
        Me.MenuClose.Size = New System.Drawing.Size(20, 20)
        Me.MenuClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnNo
        '
        Me.BtnNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnNo.BackColorDark = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.BtnNo.BackColorLight = System.Drawing.Color.White
        Me.BtnNo.Columns = 1
        Me.BtnNo.DrawBorderValidMove = False
        Me.BtnNo.DrawCheckMark = False
        Me.BtnNo.FlatAppearance.BorderSize = 0
        Me.BtnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNo.Font = New System.Drawing.Font("Segoe Script", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNo.IsDarkMode = False
        Me.BtnNo.Location = New System.Drawing.Point(168, 175)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Rows = 1
        Me.BtnNo.Size = New System.Drawing.Size(69, 38)
        Me.BtnNo.TabIndex = 3
        Me.BtnNo.TileNumber = "No"
        Me.BtnNo.TileSize = 96
        Me.BtnNo.UseVisualStyleBackColor = True
        '
        'BtnYes
        '
        Me.BtnYes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnYes.BackColorDark = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.BtnYes.BackColorLight = System.Drawing.Color.White
        Me.BtnYes.Columns = 1
        Me.BtnYes.DrawBorderValidMove = False
        Me.BtnYes.DrawCheckMark = False
        Me.BtnYes.FlatAppearance.BorderSize = 0
        Me.BtnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnYes.Font = New System.Drawing.Font("Segoe Script", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnYes.IsDarkMode = False
        Me.BtnYes.Location = New System.Drawing.Point(93, 175)
        Me.BtnYes.Name = "BtnYes"
        Me.BtnYes.Rows = 1
        Me.BtnYes.Size = New System.Drawing.Size(69, 38)
        Me.BtnYes.TabIndex = 2
        Me.BtnYes.TileNumber = "Yes"
        Me.BtnYes.TileSize = 96
        Me.BtnYes.UseVisualStyleBackColor = True
        '
        'FrmWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 227)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnNo)
        Me.Controls.Add(Me.BtnYes)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LblCongrats)
        Me.Controls.Add(Me.LblScore)
        Me.Controls.Add(Me.LblMode)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.SlidingPuzzle_VB.Net.My.Resources.Resources.cube
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmWin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents LblTitle As ToolStripLabel
    Friend WithEvents MenuClose As ToolStripButton
    Friend WithEvents LblCongrats As Label
    Friend WithEvents LblScore As Label
    Friend WithEvents LblMode As Label
    Friend WithEvents BtnYes As Sliding_Puzzle_Library.PuzzleTile
    Friend WithEvents BtnNo As Sliding_Puzzle_Library.PuzzleTile
End Class
