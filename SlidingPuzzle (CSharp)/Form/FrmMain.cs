using Microsoft.VisualBasic;
using Sliding_Puzzle_Library;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SlidingPuzzle_CSharp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            // This call is required by the designer.
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }

        private CPuzzle _NewPuzzle;

        public CPuzzle NewPuzzle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NewPuzzle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NewPuzzle != null)
                {
                    _NewPuzzle.CountClick -= NewPuzzle_CountClick;
                    _NewPuzzle.Ticker -= NewPuzzle_Ticker;
                    _NewPuzzle.IsBusy -= NewPuzzle_IsBusy;
                }

                _NewPuzzle = value;
                if (_NewPuzzle != null)
                {
                    _NewPuzzle.CountClick += NewPuzzle_CountClick;
                    _NewPuzzle.Ticker += NewPuzzle_Ticker;
                    _NewPuzzle.IsBusy += NewPuzzle_IsBusy;
                }
            }
        }

        private bool mode = false;
        private string modeString = "Number";
        public bool IsDarkMode = false;
        private int PuzzleSize = 3;

        private void ChangeTheme()
        {
            using (var CstmRenderer = new CustomRenderer(IsDarkMode))
            {
                MenuStrip1.Renderer = CstmRenderer;
                StatusStrip1.Renderer = CstmRenderer;
                ToolStrip1.Renderer = CstmRenderer;
                NewPuzzle.IsDarkMode = IsDarkMode;
                BackColor = IsDarkMode ? Color.FromArgb(48, 48, 48) : Color.FromArgb(238, 238, 242);
            }
        }

        private void MenuMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] chkMenu = { MenuImage, MenuNumber };
            ToolStripMenuItem currentLvl = (ToolStripMenuItem)sender;
            for (int i = 0; i < chkMenu.Length; i++)
            {
                if (chkMenu[i].Name != currentLvl.Name)
                {
                    chkMenu[i].Checked = false;
                }
                else
                {
                    chkMenu[i].Checked = true;

                    if (currentLvl.Text == "Number")
                    {
                        MenuImport.Enabled = false;
                        mode = false;
                    }
                    else
                    {
                        MenuImport.Enabled = true;
                        mode = true;
                    }
                }
            }

            modeString = currentLvl.Text;
            NewPuzzle.Mode = mode;
            NewPuzzle.PuzzleSize = PuzzleSize;
        }

        private void MenuIsDarkMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] chkMenu = { MenuLight, MenuDark };
            ToolStripMenuItem currentLvl = (ToolStripMenuItem)sender;
            for (int i = 0; i < chkMenu.Length; i++)
            {
                if (chkMenu[i].Name != currentLvl.Name)
                {
                    chkMenu[i].Checked = false;
                }
                else
                {
                    chkMenu[i].Checked = true;
                    if (chkMenu[i].Name == "MenuLight")
                    {
                        MenuDark.Checked = false;
                        IsDarkMode = false;
                    }
                    else
                    {
                        MenuLight.Checked = false;
                        IsDarkMode = true;
                    }
                }
            }

            ChangeTheme();
        }

        private void MenuPuzzleSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] chkMenu = { PuzzleSize3, PuzzleSize4, PuzzleSize5, PuzzleSizeCustom };
            ToolStripMenuItem currentLvl = (ToolStripMenuItem)sender;
            for (int i = 0; i < chkMenu.Length; i++)
            {
                if (chkMenu[i].Name != currentLvl.Name)
                {
                    chkMenu[i].Checked = false;
                }
                else
                {
                    chkMenu[i].Checked = true;
                    if (i < 3)
                    {
                        PuzzleSize = Convert.ToInt32(Strings.Right(currentLvl.Name, 1));
                    }
                    else
                    {
                    // inputBox validation
                    recreateInputBox:
                        ;
                        string userInput = Interaction.InputBox("Enter Number From 4 - 20 Ex: 4 (It Means 4 x 4)", "Custom Size", 10.ToString());
                        if (!Information.IsNumeric(userInput))
                        {
                            Interaction.MsgBox("You must input number between 4 and 20", (MsgBoxStyle)((int)MsgBoxStyle.Exclamation + (int)MsgBoxStyle.OkOnly), "Information");
                            goto recreateInputBox;
                        }
                        else if (Convert.ToDouble(userInput) > 50 || Convert.ToDouble(userInput) < 4)
                        {
                            Interaction.MsgBox("You must input number between 4 and 20", (MsgBoxStyle)((int)MsgBoxStyle.Exclamation + (int)MsgBoxStyle.OkOnly), "Information");
                            goto recreateInputBox;
                        }
                        else
                        {
                            PuzzleSize = Convert.ToInt32(userInput);
                        }
                    }

                    NewPuzzle.Mode = mode;
                    NewPuzzle.PuzzleSize = PuzzleSize;
                }
            }
        }

        private void StartGame()
        {
            if (NewPuzzle.Mode && !NewPuzzle.IsAnyImage())
            {
                Interaction.MsgBox("Please choose an image first", (MsgBoxStyle)((int)MsgBoxStyle.Exclamation + (int)MsgBoxStyle.OkOnly), "Information");
                return;
            }

            NewPuzzle.StartGame();
        }

        private void MenuNewGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void MenuImport_Click(object sender, EventArgs e)
        {
            NewPuzzle.LoadImage();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewPuzzle_CountClick(int Score, bool WinStatus)
        {
            LblScore.Text = "Score : " + Score;
            if (Score > 0 && WinStatus)
            {
                FrmWin frm = new FrmWin
                {
                    Owner = this
                };
                using (CustomRenderer CstmRenderer = new CustomRenderer(IsDarkMode))
                {
                    frm.ToolStrip1.Renderer = CstmRenderer;
                }

                frm.LblScore.Text = "Your " + LblScore.Text;

                frm.LblMode.Text = mode ? "Start New Game With New Image?" : "Start New Game?";

                frm.ShowDialog();
            }
        }

        private void NewPuzzle_Ticker(string Time)
        {
            LblTimer.Text = "Timer :" + Time;
        }

        private void NewPuzzle_IsBusy(bool BgwBusyStatus, string TextStatus)
        {
            string frmt = string.Format(" | Mode: {0} | Size: {1} x {1}", modeString, PuzzleSize);
            if (BgwBusyStatus)
            {
                Application.UseWaitCursor = true;
                base.Cursor = Cursors.WaitCursor;
                MenuStrip1.Enabled = false;
                LblTitle.Text = TextStatus;
            }
            else
            {
                MenuStrip1.Enabled = true;
                LblTitle.Text = TextStatus + frmt;
                Application.UseWaitCursor = false;
                base.Cursor = Cursors.Default;
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            Module1.SetMouseDown(this, e);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                StartGame();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            NewPuzzle = new CPuzzle(cPanel1);
            ChangeTheme();
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Module1.SetRoundedEdges(this);
            Top = Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Height / (double)2) - (Height / (double)2));
            Left = Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Width / (double)2) - (Width / (double)2));
            Update();
        }
    }
}