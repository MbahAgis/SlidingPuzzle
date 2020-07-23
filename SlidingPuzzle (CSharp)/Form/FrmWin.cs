using Sliding_Puzzle_Library;
using SlidingPuzzle_CSharp;
using SlidingPuzzle_CSharp.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SlidingPuzzle_CSharp
{
    public partial class FrmWin : Form
    {
        public FrmWin()
        {
            InitializeComponent();
        }

        private void SetColor()
        {
            Color bckColor, frColor;
            if (((FrmMain)Owner).IsDarkMode)
            {
                bckColor = Color.FromArgb(48, 48, 48);
                frColor = Color.White;
                BtnYes.IsDarkMode = true;
                BtnNo.IsDarkMode = true;
            }
            else
            {
                bckColor = Color.FromArgb(238, 238, 242);
                frColor = Color.Black;
                BtnYes.IsDarkMode = false;
                BtnNo.IsDarkMode = false;
            }

            BackColor = bckColor;
            foreach (Control x in Controls)
            {
                if (x is Label)
                {
                    x.BackColor = bckColor;
                    x.ForeColor = frColor;
                }
            }

            BtnYes.Focus();
        }

        private void FrmWin_Shown(object sender, EventArgs e)
        {
            using (var media = new System.Media.SoundPlayer(Resources.Ta_Da))
            {
                media.Play();
            }
        }

        private void FrmWin_Load(object sender, EventArgs e)
        {
            SetColor();
        }

        private void FrmWin_MouseDown(object sender, MouseEventArgs e)
        {
            Module1.SetMouseDown(this, e);
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            Close();
            ((FrmMain)Owner).NewPuzzle.StartGame();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Module1.SetRoundedEdges(this);
        }
    }
}
