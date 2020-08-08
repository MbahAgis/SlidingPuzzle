    namespace SlidingPuzzle_CSharp
    {
        partial class FrmMain
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.LblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuMode = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuSize = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSize3 = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSize4 = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSize5 = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSizeCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLight = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDark = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LblTitle = new System.Windows.Forms.ToolStripLabel();
            this.MenuClose = new System.Windows.Forms.ToolStripButton();
            this.StatusStrip1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTimer
            // 
            this.LblTimer.AutoSize = false;
            this.LblTimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LblTimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.LblTimer.Name = "LblTimer";
            this.LblTimer.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LblTimer.Size = new System.Drawing.Size(220, 23);
            this.LblTimer.Spring = true;
            this.LblTimer.Text = "Timer : 00:00:00";
            this.LblTimer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // LblScore
            // 
            this.LblScore.AutoSize = false;
            this.LblScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScore.Margin = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.LblScore.Name = "LblScore";
            this.LblScore.Size = new System.Drawing.Size(70, 23);
            this.LblScore.Text = "Score : 0";
            this.LblScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblScore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.AllowMerge = false;
            this.StatusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblScore,
            this.LblTimer});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 368);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(312, 29);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 34;
            this.StatusStrip1.Text = "StatusStrip1";
            this.StatusStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.MenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOptions,
            this.MenuImportImage,
            this.MenuNewGame});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 33);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuStrip1.Size = new System.Drawing.Size(312, 24);
            this.MenuStrip1.TabIndex = 42;
            this.MenuStrip1.Text = "MenuStrip1";
            this.MenuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // MenuOptions
            // 
            this.MenuOptions.AutoSize = false;
            this.MenuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuMode,
            this.SubMenuSize,
            this.SubMenuThemes,
            this.BtnExit});
            this.MenuOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuOptions.Name = "MenuOptions";
            this.MenuOptions.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.MenuOptions.ShortcutKeyDisplayString = "";
            this.MenuOptions.ShowShortcutKeys = false;
            this.MenuOptions.Size = new System.Drawing.Size(55, 20);
            this.MenuOptions.Text = "Options";
            this.MenuOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubMenuMode
            // 
            this.SubMenuMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNumber,
            this.MenuImage});
            this.SubMenuMode.Name = "SubMenuMode";
            this.SubMenuMode.Size = new System.Drawing.Size(180, 22);
            this.SubMenuMode.Text = "Puzzle Mode";
            // 
            // MenuNumber
            // 
            this.MenuNumber.Checked = true;
            this.MenuNumber.CheckOnClick = true;
            this.MenuNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuNumber.Name = "MenuNumber";
            this.MenuNumber.Size = new System.Drawing.Size(180, 22);
            this.MenuNumber.Text = "Number";
            this.MenuNumber.Click += new System.EventHandler(this.MenuMode_Click);
            // 
            // MenuImage
            // 
            this.MenuImage.CheckOnClick = true;
            this.MenuImage.Name = "MenuImage";
            this.MenuImage.Size = new System.Drawing.Size(180, 22);
            this.MenuImage.Text = "Image";
            this.MenuImage.Click += new System.EventHandler(this.MenuMode_Click);
            // 
            // SubMenuSize
            // 
            this.SubMenuSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PuzzleSize3,
            this.PuzzleSize4,
            this.PuzzleSize5,
            this.PuzzleSizeCustom});
            this.SubMenuSize.Name = "SubMenuSize";
            this.SubMenuSize.Size = new System.Drawing.Size(180, 22);
            this.SubMenuSize.Text = "Puzzle Size";
            // 
            // PuzzleSize3
            // 
            this.PuzzleSize3.Checked = true;
            this.PuzzleSize3.CheckOnClick = true;
            this.PuzzleSize3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PuzzleSize3.Name = "PuzzleSize3";
            this.PuzzleSize3.Size = new System.Drawing.Size(180, 22);
            this.PuzzleSize3.Text = "3 x 3";
            this.PuzzleSize3.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // PuzzleSize4
            // 
            this.PuzzleSize4.CheckOnClick = true;
            this.PuzzleSize4.Name = "PuzzleSize4";
            this.PuzzleSize4.Size = new System.Drawing.Size(180, 22);
            this.PuzzleSize4.Text = "4 x 4";
            this.PuzzleSize4.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // PuzzleSize5
            // 
            this.PuzzleSize5.CheckOnClick = true;
            this.PuzzleSize5.Name = "PuzzleSize5";
            this.PuzzleSize5.Size = new System.Drawing.Size(180, 22);
            this.PuzzleSize5.Text = "5 x 5";
            this.PuzzleSize5.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // PuzzleSizeCustom
            // 
            this.PuzzleSizeCustom.CheckOnClick = true;
            this.PuzzleSizeCustom.Name = "PuzzleSizeCustom";
            this.PuzzleSizeCustom.Size = new System.Drawing.Size(180, 22);
            this.PuzzleSizeCustom.Text = "Custom";
            this.PuzzleSizeCustom.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // SubMenuThemes
            // 
            this.SubMenuThemes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLight,
            this.MenuDark});
            this.SubMenuThemes.Name = "SubMenuThemes";
            this.SubMenuThemes.Size = new System.Drawing.Size(180, 22);
            this.SubMenuThemes.Text = "Themes";
            // 
            // MenuLight
            // 
            this.MenuLight.Checked = true;
            this.MenuLight.CheckOnClick = true;
            this.MenuLight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuLight.Name = "MenuLight";
            this.MenuLight.Size = new System.Drawing.Size(180, 22);
            this.MenuLight.Text = "Light";
            this.MenuLight.Click += new System.EventHandler(this.MenuIsDarkMode_Click);
            // 
            // MenuDark
            // 
            this.MenuDark.Name = "MenuDark";
            this.MenuDark.Size = new System.Drawing.Size(180, 22);
            this.MenuDark.Text = "Dark";
            this.MenuDark.Click += new System.EventHandler(this.MenuIsDarkMode_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.ShortcutKeyDisplayString = "";
            this.BtnExit.Size = new System.Drawing.Size(180, 22);
            this.BtnExit.Text = "Exit";
            this.BtnExit.Click += new System.EventHandler(this.Close_Click);
            // 
            // MenuImportImage
            // 
            this.MenuImportImage.AutoSize = false;
            this.MenuImportImage.Enabled = false;
            this.MenuImportImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuImportImage.Name = "MenuImportImage";
            this.MenuImportImage.ShowShortcutKeys = false;
            this.MenuImportImage.Size = new System.Drawing.Size(110, 20);
            this.MenuImportImage.Text = "Import New Image";
            this.MenuImportImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuImportImage.Click += new System.EventHandler(this.MenuImportImage_Click);
            // 
            // MenuNewGame
            // 
            this.MenuNewGame.AutoSize = false;
            this.MenuNewGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuNewGame.Name = "MenuNewGame";
            this.MenuNewGame.ShowShortcutKeys = false;
            this.MenuNewGame.Size = new System.Drawing.Size(92, 20);
            this.MenuNewGame.Text = "(F2) New Game";
            this.MenuNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuNewGame.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblTitle,
            this.MenuClose});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 1, 3);
            this.ToolStrip1.ShowItemToolTips = false;
            this.ToolStrip1.Size = new System.Drawing.Size(312, 33);
            this.ToolStrip1.TabIndex = 130;
            this.ToolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = false;
            this.LblTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Image = global::SlidingPuzzle_CSharp.Properties.Resources.cube1;
            this.LblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitle.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(270, 24);
            this.LblTitle.Text = "Sliding Puzzle | Mode: Number | Size: 3 x 3";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // MenuClose
            // 
            this.MenuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuClose.BackColor = System.Drawing.Color.Transparent;
            this.MenuClose.Image = ((System.Drawing.Image)(resources.GetObject("MenuClose.Image")));
            this.MenuClose.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.MenuClose.Name = "MenuClose";
            this.MenuClose.Size = new System.Drawing.Size(23, 24);
            this.MenuClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(312, 397);
            this.ControlBox = false;
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(312, 397);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            internal System.Windows.Forms.ToolStripStatusLabel LblTimer;
            internal System.Windows.Forms.ToolStripStatusLabel LblScore; 
            internal System.Windows.Forms.StatusStrip StatusStrip1; 
            internal System.Windows.Forms.MenuStrip MenuStrip1; 
            internal System.Windows.Forms.ToolStripMenuItem MenuOptions; 
            internal System.Windows.Forms.ToolStripMenuItem SubMenuMode; 
            internal System.Windows.Forms.ToolStripMenuItem MenuNumber; 
            internal System.Windows.Forms.ToolStripMenuItem MenuImage; 
            internal System.Windows.Forms.ToolStripMenuItem SubMenuSize; 
            internal System.Windows.Forms.ToolStripMenuItem PuzzleSize3; 
            internal System.Windows.Forms.ToolStripMenuItem PuzzleSize4; 
            internal System.Windows.Forms.ToolStripMenuItem PuzzleSize5; 
            internal System.Windows.Forms.ToolStripMenuItem PuzzleSizeCustom; 
            internal System.Windows.Forms.ToolStripMenuItem SubMenuThemes; 
            internal System.Windows.Forms.ToolStripMenuItem MenuLight; 
            internal System.Windows.Forms.ToolStripMenuItem MenuDark; 
            internal System.Windows.Forms.ToolStripMenuItem BtnExit; 
            internal System.Windows.Forms.ToolStripMenuItem MenuImportImage; 
            internal System.Windows.Forms.ToolStripMenuItem MenuNewGame; 
            internal System.Windows.Forms.ToolStrip ToolStrip1; 
            internal System.Windows.Forms.ToolStripLabel LblTitle; 
            internal System.Windows.Forms.ToolStripButton MenuClose;
    }
    }