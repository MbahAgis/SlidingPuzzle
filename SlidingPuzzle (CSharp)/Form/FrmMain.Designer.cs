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
            this.LblTitle = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuClose = new System.Windows.Forms.ToolStripButton();
            this.MenuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDark = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLight = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSizeCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSize5 = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSize3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuSize = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleSize4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuMode = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.cPanel1 = new Sliding_Puzzle_Library.CPanel();
            this.ToolStrip1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = false;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LblTitle.Image = global::SlidingPuzzle_CSharp.Properties.Resources.cube1;
            this.LblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(270, 18);
            this.LblTitle.Text = " Sliding Puzzle | Mode: Number | Size: 3 x 3";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
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
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.ShowItemToolTips = false;
            this.ToolStrip1.Size = new System.Drawing.Size(312, 29);
            this.ToolStrip1.Stretch = true;
            this.ToolStrip1.TabIndex = 133;
            this.ToolStrip1.Text = "ToolStrip1";
            this.ToolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // MenuClose
            // 
            this.MenuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuClose.BackColor = System.Drawing.Color.Transparent;
            this.MenuClose.Image = ((System.Drawing.Image)(resources.GetObject("MenuClose.Image")));
            this.MenuClose.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.MenuClose.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.MenuClose.Name = "MenuClose";
            this.MenuClose.Size = new System.Drawing.Size(23, 20);
            this.MenuClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuClose.Click += new System.EventHandler(this.Close_Click);
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
            this.MenuNewGame.Click += new System.EventHandler(this.MenuNewGame_Click);
            // 
            // MenuImport
            // 
            this.MenuImport.AutoSize = false;
            this.MenuImport.Enabled = false;
            this.MenuImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuImport.Name = "MenuImport";
            this.MenuImport.ShowShortcutKeys = false;
            this.MenuImport.Size = new System.Drawing.Size(110, 20);
            this.MenuImport.Text = "Import New Image";
            this.MenuImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuImport.Click += new System.EventHandler(this.MenuImport_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.ShortcutKeyDisplayString = "";
            this.BtnExit.Size = new System.Drawing.Size(141, 22);
            this.BtnExit.Text = "Exit";
            this.BtnExit.Click += new System.EventHandler(this.Close_Click);
            // 
            // MenuDark
            // 
            this.MenuDark.Name = "MenuDark";
            this.MenuDark.Size = new System.Drawing.Size(101, 22);
            this.MenuDark.Text = "Dark";
            this.MenuDark.Click += new System.EventHandler(this.MenuIsDarkMode_Click);
            // 
            // MenuLight
            // 
            this.MenuLight.Checked = true;
            this.MenuLight.CheckOnClick = true;
            this.MenuLight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuLight.Name = "MenuLight";
            this.MenuLight.Size = new System.Drawing.Size(101, 22);
            this.MenuLight.Text = "Light";
            this.MenuLight.Click += new System.EventHandler(this.MenuIsDarkMode_Click);
            // 
            // SubMenuThemes
            // 
            this.SubMenuThemes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLight,
            this.MenuDark});
            this.SubMenuThemes.Name = "SubMenuThemes";
            this.SubMenuThemes.Size = new System.Drawing.Size(141, 22);
            this.SubMenuThemes.Text = "Themes";
            // 
            // PuzzleSizeCustom
            // 
            this.PuzzleSizeCustom.CheckOnClick = true;
            this.PuzzleSizeCustom.Name = "PuzzleSizeCustom";
            this.PuzzleSizeCustom.Size = new System.Drawing.Size(116, 22);
            this.PuzzleSizeCustom.Text = "Custom";
            this.PuzzleSizeCustom.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // PuzzleSize5
            // 
            this.PuzzleSize5.CheckOnClick = true;
            this.PuzzleSize5.Name = "PuzzleSize5";
            this.PuzzleSize5.Size = new System.Drawing.Size(116, 22);
            this.PuzzleSize5.Text = "5 x 5";
            this.PuzzleSize5.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // PuzzleSize3
            // 
            this.PuzzleSize3.Checked = true;
            this.PuzzleSize3.CheckOnClick = true;
            this.PuzzleSize3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PuzzleSize3.Name = "PuzzleSize3";
            this.PuzzleSize3.Size = new System.Drawing.Size(116, 22);
            this.PuzzleSize3.Text = "3 x 3";
            this.PuzzleSize3.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // SubMenuSize
            // 
            this.SubMenuSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PuzzleSize3,
            this.PuzzleSize4,
            this.PuzzleSize5,
            this.PuzzleSizeCustom});
            this.SubMenuSize.Name = "SubMenuSize";
            this.SubMenuSize.Size = new System.Drawing.Size(141, 22);
            this.SubMenuSize.Text = "Puzzle Size";
            // 
            // PuzzleSize4
            // 
            this.PuzzleSize4.CheckOnClick = true;
            this.PuzzleSize4.Name = "PuzzleSize4";
            this.PuzzleSize4.Size = new System.Drawing.Size(116, 22);
            this.PuzzleSize4.Text = "4 x 4";
            this.PuzzleSize4.Click += new System.EventHandler(this.MenuPuzzleSize_Click);
            // 
            // MenuImage
            // 
            this.MenuImage.CheckOnClick = true;
            this.MenuImage.Name = "MenuImage";
            this.MenuImage.Size = new System.Drawing.Size(118, 22);
            this.MenuImage.Text = "Image";
            this.MenuImage.Click += new System.EventHandler(this.MenuMode_Click);
            // 
            // MenuNumber
            // 
            this.MenuNumber.Checked = true;
            this.MenuNumber.CheckOnClick = true;
            this.MenuNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuNumber.Name = "MenuNumber";
            this.MenuNumber.Size = new System.Drawing.Size(118, 22);
            this.MenuNumber.Text = "Number";
            this.MenuNumber.Click += new System.EventHandler(this.MenuMode_Click);
            // 
            // SubMenuMode
            // 
            this.SubMenuMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNumber,
            this.MenuImage});
            this.SubMenuMode.Name = "SubMenuMode";
            this.SubMenuMode.Size = new System.Drawing.Size(141, 22);
            this.SubMenuMode.Text = "Puzzle Mode";
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
            // MenuStrip1
            // 
            this.MenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.MenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOptions,
            this.MenuImport,
            this.MenuNewGame});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 29);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuStrip1.Size = new System.Drawing.Size(312, 24);
            this.MenuStrip1.TabIndex = 132;
            this.MenuStrip1.Text = "MenuStrip1";
            this.MenuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.AllowMerge = false;
            this.StatusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblScore,
            this.LblTimer});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 361);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusStrip1.Size = new System.Drawing.Size(312, 29);
            this.StatusStrip1.SizingGrip = false;
            this.StatusStrip1.TabIndex = 131;
            this.StatusStrip1.Text = "StatusStrip1";
            this.StatusStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
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
            // cPanel1
            // 
            this.cPanel1.AutoScroll = true;
            this.cPanel1.AutoSize = true;
            this.cPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cPanel1.Location = new System.Drawing.Point(0, 53);
            this.cPanel1.Margin = new System.Windows.Forms.Padding(18);
            this.cPanel1.Name = "cPanel1";
            this.cPanel1.Size = new System.Drawing.Size(312, 308);
            this.cPanel1.TabIndex = 134;
            this.cPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(312, 390);
            this.Controls.Add(this.cPanel1);
            this.Controls.Add(this.MenuStrip1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ToolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(312, 390);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripLabel LblTitle;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton MenuClose;
        internal System.Windows.Forms.ToolStripMenuItem MenuNewGame;
        internal System.Windows.Forms.ToolStripMenuItem MenuImport;
        internal System.Windows.Forms.ToolStripMenuItem BtnExit;
        internal System.Windows.Forms.ToolStripMenuItem MenuDark;
        internal System.Windows.Forms.ToolStripMenuItem MenuLight;
        internal System.Windows.Forms.ToolStripMenuItem SubMenuThemes;
        internal System.Windows.Forms.ToolStripMenuItem PuzzleSizeCustom;
        internal System.Windows.Forms.ToolStripMenuItem PuzzleSize5;
        internal System.Windows.Forms.ToolStripMenuItem PuzzleSize3;
        internal System.Windows.Forms.ToolStripMenuItem SubMenuSize;
        internal System.Windows.Forms.ToolStripMenuItem PuzzleSize4;
        internal System.Windows.Forms.ToolStripMenuItem MenuImage;
        internal System.Windows.Forms.ToolStripMenuItem MenuNumber;
        internal System.Windows.Forms.ToolStripMenuItem SubMenuMode;
        internal System.Windows.Forms.ToolStripMenuItem MenuOptions;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel LblScore;
        internal System.Windows.Forms.ToolStripStatusLabel LblTimer;
        private Sliding_Puzzle_Library.CPanel cPanel1;
    }
}