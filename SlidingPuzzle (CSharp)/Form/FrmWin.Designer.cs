namespace SlidingPuzzle_CSharp
{
    partial class FrmWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWin));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LblTitle = new System.Windows.Forms.ToolStripLabel();
            this.MenuClose = new System.Windows.Forms.ToolStripButton();
            this.LblCongrats = new System.Windows.Forms.Label();
            this.LblScore = new System.Windows.Forms.Label();
            this.LblMode = new System.Windows.Forms.Label();
            this.BtnNo = new Sliding_Puzzle_Library.CButton();
            this.BtnYes = new Sliding_Puzzle_Library.CButton();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.ToolStrip1.ShowItemToolTips = false;
            this.ToolStrip1.Size = new System.Drawing.Size(341, 27);
            this.ToolStrip1.Stretch = true;
            this.ToolStrip1.TabIndex = 133;
            this.ToolStrip1.Text = "ToolStrip1";
            this.ToolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmWin_MouseDown);
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = false;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Image = global::SlidingPuzzle_CSharp.Properties.Resources.cube1;
            this.LblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitle.Margin = new System.Windows.Forms.Padding(7, 1, 0, 2);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(150, 24);
            this.LblTitle.Text = " Sliding Puzzle";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmWin_MouseDown);
            // 
            // MenuClose
            // 
            this.MenuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuClose.AutoSize = false;
            this.MenuClose.BackColor = System.Drawing.Color.Transparent;
            this.MenuClose.Image = ((System.Drawing.Image)(resources.GetObject("MenuClose.Image")));
            this.MenuClose.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.MenuClose.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.MenuClose.Name = "MenuClose";
            this.MenuClose.Size = new System.Drawing.Size(20, 20);
            this.MenuClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuClose.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // LblCongrats
            // 
            this.LblCongrats.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblCongrats.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCongrats.Location = new System.Drawing.Point(-1, 47);
            this.LblCongrats.Name = "LblCongrats";
            this.LblCongrats.Size = new System.Drawing.Size(342, 30);
            this.LblCongrats.TabIndex = 132;
            this.LblCongrats.Text = "Congratulations !!!";
            this.LblCongrats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCongrats.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmWin_MouseDown);
            // 
            // LblScore
            // 
            this.LblScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblScore.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblScore.Location = new System.Drawing.Point(-1, 82);
            this.LblScore.Name = "LblScore";
            this.LblScore.Size = new System.Drawing.Size(342, 30);
            this.LblScore.TabIndex = 131;
            this.LblScore.Text = "Your Score: ";
            this.LblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblScore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmWin_MouseDown);
            // 
            // LblMode
            // 
            this.LblMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblMode.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMode.Location = new System.Drawing.Point(-1, 136);
            this.LblMode.Name = "LblMode";
            this.LblMode.Size = new System.Drawing.Size(342, 36);
            this.LblMode.TabIndex = 130;
            this.LblMode.Text = "Start New Game?";
            this.LblMode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmWin_MouseDown);
            // 
            // BtnNo
            // 
            this.BtnNo.BackColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BtnNo.BackColorLight = System.Drawing.Color.White;
            this.BtnNo.Columns = 1;
            this.BtnNo.DrawBorderValidMove = false;
            this.BtnNo.DrawCheckMark = false;
            this.BtnNo.FlatAppearance.BorderSize = 0;
            this.BtnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNo.Font = new System.Drawing.Font("Segoe Script", 14.25F);
            this.BtnNo.IsDarkMode = false;
            this.BtnNo.Location = new System.Drawing.Point(168, 175);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Rows = 1;
            this.BtnNo.Size = new System.Drawing.Size(69, 38);
            this.BtnNo.TabIndex = 135;
            this.BtnNo.TileNumber = "No";
            this.BtnNo.TileNumberAlign = System.Drawing.StringAlignment.Center;
            this.BtnNo.TileNumberLineAlign = System.Drawing.StringAlignment.Far;
            this.BtnNo.TileSize = 96;
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            this.BtnNo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmWin_MouseDown);
            // 
            // BtnYes
            // 
            this.BtnYes.BackColorDark = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BtnYes.BackColorLight = System.Drawing.Color.White;
            this.BtnYes.Columns = 1;
            this.BtnYes.DrawBorderValidMove = false;
            this.BtnYes.DrawCheckMark = false;
            this.BtnYes.FlatAppearance.BorderSize = 0;
            this.BtnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnYes.Font = new System.Drawing.Font("Segoe Script", 14.25F);
            this.BtnYes.IsDarkMode = false;
            this.BtnYes.Location = new System.Drawing.Point(93, 175);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Rows = 1;
            this.BtnYes.Size = new System.Drawing.Size(69, 38);
            this.BtnYes.TabIndex = 134;
            this.BtnYes.TileNumber = "Yes";
            this.BtnYes.TileNumberAlign = System.Drawing.StringAlignment.Center;
            this.BtnYes.TileNumberLineAlign = System.Drawing.StringAlignment.Far;
            this.BtnYes.TileSize = 96;
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            this.BtnYes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmWin_MouseDown);
            // 
            // FrmWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 227);
            this.ControlBox = false;
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.BtnYes);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.LblCongrats);
            this.Controls.Add(this.LblScore);
            this.Controls.Add(this.LblMode);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmWin_Load);
            this.Shown += new System.EventHandler(this.FrmWin_Shown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripLabel LblTitle;
        internal System.Windows.Forms.ToolStripButton MenuClose;
        internal System.Windows.Forms.Label LblCongrats;
        internal System.Windows.Forms.Label LblScore;
        internal System.Windows.Forms.Label LblMode;
        private Sliding_Puzzle_Library.CButton BtnYes;
        private Sliding_Puzzle_Library.CButton BtnNo;
    }
}