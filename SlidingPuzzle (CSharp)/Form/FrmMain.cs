using Microsoft.VisualBasic;
using Sliding_Puzzle_Library;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static Sliding_Puzzle_Library.ModuleHelper;

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

        private PuzzleGame _PuzzleGame;

        public PuzzleGame PuzzleGame
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PuzzleGame;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PuzzleGame != null)
                {
                    _PuzzleGame.Score -= PuzzleGame_Score;
                    _PuzzleGame.Ticker -= PuzzleGame_Ticker;
                    _PuzzleGame.GameState -= PuzzleGame_GameState;
                }

                _PuzzleGame = value;
                if (_PuzzleGame != null)
                {
                    _PuzzleGame.Score += PuzzleGame_Score;
                    _PuzzleGame.Ticker += PuzzleGame_Ticker;
                    _PuzzleGame.GameState += PuzzleGame_GameState;
                }
            }
        }

        private bool PuzzleMode;
        private string ModeString = "Number";
        private int PuzzleSize = 3;
        public bool IsDarkMode;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            ChangeTheme(false, true);
            AnimateWindow(Handle, 200, AnimateWindowFlags.AW_BLEND);
            PuzzleGame = new PuzzleGame(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            AnimateWindow(Handle, 400, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                StartGame();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ChangeTheme(bool IsChanged, bool IsFirstTime)
        {
            if (IsChanged)
            {
                AnimateWindow(Handle, 150, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);
            }

            using (var CstmRenderer = new CustomRenderer(IsDarkMode))
            {
                MenuStrip1.Renderer = CstmRenderer;
                StatusStrip1.Renderer = CstmRenderer;
                ToolStrip1.Renderer = CstmRenderer;
                if (!IsFirstTime)
                {
                    PuzzleGame.IsDarkMode = IsDarkMode;
                }

                BackColor = IsDarkMode ? Color.FromArgb(48, 48, 48) : Color.FromArgb(238, 238, 242);
            }

            if (IsChanged)
            {
                Show();
            }
        }

        private void SetBoard(bool IsChanged)
        {
            if (IsChanged)
            {
                AnimateWindow(Handle, 250, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);
            }

            PuzzleGame.PuzzleMode = PuzzleMode;
            PuzzleGame.PuzzleSize = PuzzleSize;
            if (IsChanged)
            {
                Show();
                Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2);
                Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2);
            }
        }

        private bool SetMenuCheckedState(object OldValue, object NewValue, ToolStripMenuItem ParentMenu)
        {
            ToolStripMenuItem chkMenu = (ToolStripMenuItem)NewValue;
            foreach (ToolStripMenuItem x in ParentMenu.DropDownItems)
            {
                x.Checked = x.Name == chkMenu.Name;
            }

            bool isChanged = false;
            if ((string)OldValue != chkMenu.Text)
            {
                isChanged = true;
            }

            return isChanged;
        }

        private void MenuMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem chkMenu = (ToolStripMenuItem)sender;
            bool isChanged = SetMenuCheckedState(ModeString, sender, SubMenuMode);

            if (chkMenu.Text == "Image")
            {
                MenuImportImage.Enabled = true;
                PuzzleMode = true;
            }
            else
            {
                MenuImportImage.Enabled = false;
                PuzzleMode = false;
            }

            ModeString = chkMenu.Text;
            SetWaitCursor("Changing puzzle mode", new Action(() => SetBoard(isChanged)));
        }

        private void MenuIsDarkMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem chkMenu = (ToolStripMenuItem)sender;
            bool isChanged = SetMenuCheckedState(IsDarkMode ? "Dark" : "Light", sender, SubMenuThemes);
            IsDarkMode = chkMenu.Text == "Dark";

            SetWaitCursor("Changing color theme", new Action(() => ChangeTheme(isChanged, false)));
        }

        private void MenuPuzzleSize_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem chkMenu = (ToolStripMenuItem)sender;
            bool isChanged = SetMenuCheckedState(string.Format("{0} x {0}", PuzzleSize), chkMenu, SubMenuSize);
            if (chkMenu.Text != "Custom")
            {
                PuzzleSize = Convert.ToInt32(Strings.Right(chkMenu.Text, 1));
            }
            else
            {
            // inputBox validation
            ReInput:

                string userInput = Interaction.InputBox("Enter Number From 4 - 20 Ex: 4 (It Means 4 x 4)", "Custom Size", "10");
                if (!Information.IsNumeric(userInput))
                {
                    Interaction.MsgBox("You must input number between 4 and 20", (MsgBoxStyle)((int)MsgBoxStyle.Exclamation + (int)MsgBoxStyle.OkOnly), "Information");
                    goto ReInput;
                }
                else
                {
                    if (Convert.ToInt32(userInput) > 20 || Convert.ToInt32(userInput) < 4)
                    {
                        Interaction.MsgBox("You must input number between 4 and 20", (MsgBoxStyle)(int)MsgBoxStyle.Exclamation + (int)MsgBoxStyle.OkOnly, "Information");
                        goto ReInput;
                    }
                    else
                    {
                        PuzzleSize = Convert.ToInt32(userInput);
                    }
                }
            }

            SetWaitCursor("Changing puzzle size", new Action(() => SetBoard(isChanged)));
        }

        public void StartGame()
        {
            if (PuzzleGame.PuzzleMode && !PuzzleGame.IsAnyImage())
            {
                Interaction.MsgBox("Please choose an image first", (MsgBoxStyle)((int)MsgBoxStyle.Exclamation + (int)MsgBoxStyle.OkOnly), "Information");
                return;
            }

            SetWaitCursor("Randomize Board", new Action(() => PuzzleGame.StartGame()));
        }

        private void SetWaitCursor(string TextStatus, Action Method)
        {
            Application.UseWaitCursor = true;
            Cursor = Cursors.WaitCursor;
            MenuStrip1.Enabled = false;
            LblTitle.Text = TextStatus;
            LblTitle.GetCurrentParent().Update();
            Method();
            LblTitle.Text = string.Format("Sliding Puzzle | Mode: {0} | Size: {1} x {1}", ModeString, PuzzleSize);
            MenuStrip1.Enabled = true;
            Application.UseWaitCursor = false;
            Cursor = Cursors.Default;
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void MenuImportImage_Click(object sender, EventArgs e)
        {
            PuzzleGame.LoadNewImage();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PuzzleGame_Score(string _score)
        {
            LblScore.Text = "Score : " + _score;
        }

        private void PuzzleGame_Ticker(string _time)
        {
            LblTimer.Text = "Timer : " + _time;
        }

        private void PuzzleGame_GameState(bool _isWin)
        {
            if (_isWin)
            {
                using (FrmWin frm = new FrmWin())
                {
                    frm.Owner = this;
                    using (CustomRenderer CstmRenderer = new CustomRenderer(IsDarkMode))
                    {
                        frm.ToolStrip1.Renderer = CstmRenderer;
                    }

                    frm.LblScore.Text = "Your " + LblScore.Text;
                    frm.LblMode.Text = PuzzleMode ? "Start New Game With New Image?" : "Start New Game?";
                    frm.LblTitle.Text = LblTitle.Text;
                    frm.ShowDialog();
                }
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            SetMouseDown(this, e);
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            SetRoundedEdges(this);
        }
    }
}