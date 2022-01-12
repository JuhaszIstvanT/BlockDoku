using System;
using System.Drawing;
using BlockDoku.Model;
using System.Windows.Forms;
using BlockDoku.View;

namespace BlockDoku
{
    public partial class Form1 : Form
    {
        #region Private fields
        private BlockDokuModel _model;
        private Button[,] _board;
        private Button[,] _display;
        #endregion

        #region Constructors
        public Form1()
        {
            InitializeComponent();

            _model = new BlockDokuModel();
            _model.GameOver += new EventHandler(Model_GameOver);
        }
        #endregion

        #region Private methods
        private void GenerateBoard()
        {
            _board = new Button[4, 4];
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    _board[i, j] = new GridButton(i, j);
                    _board[i, j].Location = new Point(20 + 100 * i, 60 + 100 * j);
                    _board[i, j].Size = new Size(100, 100);
                    _board[i, j].Dock = DockStyle.Fill;
                    _board[i, j].BackColor = System.Drawing.Color.White;
                    _board[i, j].MouseClick += new MouseEventHandler(Board_MouseClick);

                    _boardLayoutPanel.Controls.Add(_board[i, j], j, i);
                }
            }
        }

        private void GenerateDisplay()
        {
            _display = new Button[2, 2];
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    _display[i, j] = new GridButton(i, j);
                    _display[i, j].Location = new Point(500 + 100 * i, 160 + 100 * j);
                    _display[i, j].Size = new Size(100, 100);
                    _display[i, j].Dock = DockStyle.Fill;
                    _display[i, j].BackColor = System.Drawing.Color.White;

                    _displayLayoutPanel.Controls.Add(_display[i, j], j, i);
                }
            }
        }

        private void SetTable()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    switch (_model[i, j])
                    {
                        case Model.Color.White:
                            _board[i, j].BackColor = System.Drawing.Color.White;
                            break;
                        case Model.Color.Blue:
                            _board[i, j].BackColor = System.Drawing.Color.Blue;
                            break;
                    }
                }
            }
        }

        private void SetDisplay()
        {
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    switch (_model.Display(i, j))
                    {
                        case Model.Color.White:
                            _display[i, j].BackColor = System.Drawing.Color.White;
                            break;
                        case Model.Color.Blue:
                            _display[i, j].BackColor = System.Drawing.Color.Blue;
                            break;
                        case Model.Color.Red:
                            _display[i, j].BackColor = System.Drawing.Color.Red;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Model event handlers

        private void Model_GameOver(object sender, EventArgs e)
        {
            int p = Int32.Parse(pointBox.Text) + 1;
            DialogResult dialogResult = MessageBox.Show(p + "Pontot szerzett " + "Szeretne újat kezdeni?", "Játék vége!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialogResult == DialogResult.Yes)
            {
                _model.NewGame();
                SetTable();
                SetDisplay();
            } else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
            }
               
        }

        #endregion

        #region Form event handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            _model.NewGame();
            GenerateBoard();
            GenerateDisplay();
            SetDisplay();
        }
        #endregion

        #region Grid event handlers
        private void Board_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (sender as GridButton).GridX;
            int y = (sender as GridButton).GridY;
            _model.StepGame(x, y);
            pointBox.Text = _model.Points.ToString();
            SetTable();
            SetDisplay();
        }
        #endregion

        private void MenuGameLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pers
                    }
                }
            }
        }
    }
}
