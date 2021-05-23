using ChameleonGame.Model;
using ChameleonGame.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChameleonGame
{
    public partial class ChameleonForm : Form
    {
        private ChameleonModel _model;
        private GridButton[,] _buttons;
        private GridButton _prevButton;
        private IDataAccess _dataAccess;
        public ChameleonForm()
        {
            InitializeComponent();
            _dataAccess = new ChameleonFileDataAccess();
            _model = new ChameleonModel(_dataAccess);
            _model.TableRefresh += new EventHandler(OnRefreshTable);
            _model.GameOver += OnGameOver;
            _prevButton = null;
            _threeByThreeNewGame.Click += ThreeByThreeNewGame_Click;
            _fiveByFiveNewGame.Click += FiveByFiveNewGame_Click;
            _sevenBySevenNewGame.Click += SevenBySevenNewGame_Click;
            _saveMenuItem.Click += SaveMenuItem_Click;
            _loadMenuItem.Click += LoadMenuItem_Click;
        }

        private void OnGameOver(object sender, ChameleonEventArgs e)
        {
            string winner = (e.WinnerChameleon == 1) ? "Piros Kaméleon" : "Zöld Kaméleon";
            MessageBox.Show("A játéknak vége!\nA győztes: "+winner);
            
            int size = _model.Size;
            for (Int32 i = 0; i < size; i++)
            {
                for (Int32 j = 0; j < size; j++)
                {
                    _buttons[i, j].Enabled = false;
                }
            }
        }

        private async void LoadMenuItem_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                _openFileDialog.RestoreDirectory = true;
                try
                {
                    await _model.LoadGameAsync(_openFileDialog.FileName);
                }
                catch (ChameleonDataException)
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _model.NewGame(3);
                }
                GenerateTable();
                _statusLabel.Text = _model.CurrentChameleon + " következik.";
            }
        }

        private async void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                _saveFileDialog.RestoreDirectory = true;
                try
                {
                    await _model.SaveGameAsync(_saveFileDialog.FileName);
                }
                catch (ChameleonDataException)
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SevenBySevenNewGame_Click(object sender, EventArgs e)
        {
            _model.NewGame(7);
            GenerateTable();
            _statusLabel.Text = _model.CurrentChameleon + " következik.";
        }

        private void FiveByFiveNewGame_Click(object sender, EventArgs e)
        {
            _model.NewGame(5);
            GenerateTable();
            _statusLabel.Text = _model.CurrentChameleon + " következik.";
        }

        private void ThreeByThreeNewGame_Click(object sender, EventArgs e)
        {
            _model.NewGame(3);
            GenerateTable();
            _statusLabel.Text = _model.CurrentChameleon + " következik.";
        }

        private void CameleonForm_Load(object sender, EventArgs e)
        {
            _model.NewGame(5);
            GenerateTable();
            _statusLabel.Text = _model.CurrentChameleon+" következik.";
        }

        private void OnRefreshTable(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void GenerateTable()
        {
            int size = _model.Size;
            _buttons = new GridButton[size, size];
            _tableLayout.Controls.Clear();
            _tableLayout.RowCount = size;
            _tableLayout.ColumnCount = size;

            for (Int32 i = 0; i < size; i++)
            {
                for (Int32 j = 0; j < size; j++)
                {
                    _buttons[i, j] = new GridButton(i, j);
                    _buttons[i, j].Margin = Padding.Empty;
                    _buttons[i, j].FlatAppearance.BorderSize = 0;
                    _buttons[i, j].FlatStyle = FlatStyle.Flat;

                    if (_model.Table.GetColor(i, j) == 1)
                    {
                        _buttons[i, j].BackColor = Color.LightPink;
                    }
                    else if (_model.Table.GetColor(i, j) == 2)
                    {
                        _buttons[i, j].BackColor = Color.LightGreen;
                    }
                    else if(_model.Table.GetColor(i, j) == 0)
                    {
                        _buttons[i, j].BackColor = Color.Gray;
                    }


                    if (_model.Table[i,j] == 1)
                    {
                        _buttons[i, j].Image = Properties.Resources.red_chameleon;
                    }
                    else if (_model.Table[i, j] == 2)
                    { 
                        _buttons[i, j].Image = Properties.Resources.green_chameleon;
                    }
                    _buttons[i, j].Dock = DockStyle.Fill;
                    _buttons[i, j].Click += new EventHandler(Button_Click);
                    _tableLayout.Controls.Add(_buttons[i, j], j, i);
                }
            }

            _tableLayout.RowStyles.Clear();
            _tableLayout.ColumnStyles.Clear();

            for (int i = 0; i < size; i++)
            {
                _tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 1 / Convert.ToSingle(size)));
            }
            for (int j = 0; j < size; j++)
            {
                _tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / Convert.ToSingle(size)));
            }
        }

        private void RefreshTable()
        {
            int size = _model.Size;

            for (Int32 i = 0; i < size; i++)
            {
                for (Int32 j = 0; j < size; j++)
                {
                    _buttons[i, j].Margin = Padding.Empty;
                    _buttons[i, j].FlatAppearance.BorderSize = 0;
                    _buttons[i, j].FlatStyle = FlatStyle.Flat;
                    if (_model.Table[i, j] == 1)
                    {
                        _buttons[i, j].Image = Properties.Resources.red_chameleon;
                    }
                    else if (_model.Table[i, j] == 2)
                    {
                        _buttons[i, j].Image = Properties.Resources.green_chameleon;
                    }
                    else
                    {
                        _buttons[i, j].Image = null;
                    }
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var currentButton = sender as GridButton;

            if (_prevButton is null)
            {
                _prevButton = currentButton;
                if (_model.Table[_prevButton.X, _prevButton.Y] == 0)
                    _prevButton = null;
                return;
            }

            int x1 = _prevButton.X;
            int y1 = _prevButton.Y;
            int x2 = currentButton.X;
            int y2 = currentButton.Y;
            if(!_model.Step(x1, y1, x2, y2))
            {
                MessageBox.Show("Érvénytelen lépés!");
            }
            _prevButton = null;
            _statusLabel.Text = _model.CurrentChameleon + " következik.";
        }
    }
}
