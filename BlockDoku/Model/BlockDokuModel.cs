using System;
using System.Collections.Generic;
using System.Linq;
using BlockDoku.Persistence;

namespace BlockDoku.Model
{
    public class BlockDokuModel
    {
        #region Private fields
        private Color[,] _gameTable;
        private Color[,] _displayTable;
        private Color[,] shape1;
        private Color[,] shape2;
        private Color[,] shape3;
        private Color[,] shape4;
        private Random generator;
        private int points;
        private IPersistence _persistence;
        #endregion

        #region Public properties
        public Color this[int x, int y]
        {
            get { return _gameTable[x, y]; }
        }
        public Color Display(int x, int y)
        {
            return _displayTable[x, y];
        }

        public int Points { get { return points; } }
        #endregion

        #region Events
        public event EventHandler<FieldChangedEventArgs> FieldChanged;
        public event EventHandler<DisplayChangedEventArgs> DisplayChanged;
        public event EventHandler GameOver;
        #endregion

        #region Constructors
        public BlockDokuModel()
        {
            points = 0;
            //init board
            _gameTable = new Color[4, 4];
            //init display
            _displayTable = new Color[2, 2];

            //initialize shapes

            //init shape1
            shape1 = new Color[2, 2];
            shape1[0, 0] = Color.Red;
            shape1[0, 1] = Color.White;
            shape1[1, 0] = Color.Blue;
            shape1[1, 1] = Color.White;

            //init shape2
            shape2 = new Color[2, 2];
            shape2[0, 0] = Color.White;
            shape2[0, 1] = Color.White;
            shape2[1, 0] = Color.Red;
            shape2[1, 1] = Color.Blue;

            //init shape3
            shape3 = new Color[2, 2];
            shape3[0, 0] = Color.Red;
            shape3[0, 1] = Color.White;
            shape3[1, 0] = Color.Blue;
            shape3[1, 1] = Color.Blue;

            //init shape4
            shape4 = new Color[2, 2];
            shape4[0, 0] = Color.Red;
            shape4[0, 1] = Color.Blue;
            shape4[1, 0] = Color.White;
            shape4[1, 1] = Color.Blue;


            generator = new Random();
            GenerateNewDisplay();
             

            NewGame();
        }
        #endregion

        public void NewGame()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    _gameTable[i, j] = Color.White;
                }
            }
            points = 0;
            GenerateNewDisplay();
        }

        public void LoadGame(string path)
        {
            if (_persistence == null) return;

            Color[] values = _persistence.Load(path);

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    _gameTable[i, j] = values[i * 4 + j];

                }
            }
        }

        public void SaveGame(string path)
        {
            if (_persistence == null) return;

            Color[] values = new Color[16];
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    values[i * 4 + j] = _gameTable[i, j];
                }
            }
            _persistence.Save(path, values);
        }

        public bool CanPlaceShapeOnBoard()
        {
            //
            bool piece1 = shape1[0, 0] == _displayTable[0, 0] && shape1[0, 1] == _displayTable[0, 1] &&
                shape1[1, 0] == _displayTable[1, 0] && shape1[1, 1] == _displayTable[1, 1];
            bool piece2 = shape2[0, 0] == _displayTable[0, 0] && shape2[0, 1] == _displayTable[0, 1] &&
                shape2[1, 0] == _displayTable[1, 0] && shape2[1, 1] == _displayTable[1, 1];
            bool piece3 = shape3[0, 0] == _displayTable[0, 0] && shape3[0, 1] == _displayTable[0, 1] &&
                shape3[1, 0] == _displayTable[1, 0] && shape3[1, 1] == _displayTable[1, 1];
            bool piece4 = shape4[0, 0] == _displayTable[0, 0] && shape4[0, 1] == _displayTable[0, 1] &&
                shape4[1, 0] == _displayTable[1, 0] && shape4[1, 1] == _displayTable[1, 1];
            //
            if (piece1)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if ((_gameTable[0, i] == Color.White && _gameTable[1, i] == Color.White) ||
                        (_gameTable[1, i] == Color.White && _gameTable[2, i] == Color.White) ||
                        (_gameTable[2, i] == Color.White && _gameTable[3, i] == Color.White)) return true;
                }
            } else if (piece2)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if ((_gameTable[i, 0] == Color.White && _gameTable[i, 1] == Color.White) ||
                        (_gameTable[i, 1] == Color.White && _gameTable[i, 2] == Color.White) ||
                        (_gameTable[i, 2] == Color.White && _gameTable[i, 3] == Color.White)) return true;
                }
            } else if (piece3)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if ((_gameTable[i, 0] == Color.White && _gameTable[i + 1, 0] == Color.White && _gameTable[i + 1, 1] == Color.White) ||
                        (_gameTable[i, 1] == Color.White && _gameTable[i + 1, 1] == Color.White && _gameTable[i + 1, 2] == Color.White) ||
                        (_gameTable[i, 2] == Color.White && _gameTable[i + 1, 2] == Color.White && _gameTable[i + 1, 3] == Color.White)) return true;
                }
            } else if (piece4)
            {
                for (int i = 0; i < 3; ++i)
                {
                    if ((_gameTable[i, 0] == Color.White && _gameTable[i, 1] == Color.White && _gameTable[i + 1, 1] == Color.White) ||
                        (_gameTable[i, 1] == Color.White && _gameTable[i, 2] == Color.White && _gameTable[i + 1, 2] == Color.White) ||
                        (_gameTable[i, 2] == Color.White && _gameTable[i, 3] == Color.White && _gameTable[i + 1, 3] == Color.White)) return true;
                }
            }
            return false;
        }

        private void GenerateNewDisplay()
        {
            int rnd = generator.Next(4);
            switch (rnd)
            {
                case 0:
                    _displayTable = shape1;
                    break;
                case 1:
                    _displayTable = shape2;
                    break;
                case 2:
                    _displayTable = shape3;
                    break;
                case 3:
                    _displayTable = shape4;
                    break;
            }
        }

        private void CheckColumnOrRowIsBlue()
        {
            bool flag;
            //check rows
            for (int i = 0; i < 4; ++i)
            {
                flag = true;
                for (int j = 0; j < 4; ++j)
                {
                    if (_gameTable[i, j] != Color.Blue)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        _gameTable[i, j] = Color.White;
                    }
                }
            }
            //check columns
            for (int i = 0; i < 4; ++i)
            {
                flag = true;
                for (int j = 0; j < 4; ++j)
                {
                    if (_gameTable[j, i] != Color.Blue)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        _gameTable[j, i] = Color.White;
                    }
                }
            }
        }

        public void StepGame(int x, int y)
        {
            //check if displaytable is not outside the board
            //check if displaytable equals to shape1
            bool shape1EqualsDisplaytable = true;
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    if (shape1[i, j] != _displayTable[i, j])
                    {
                        shape1EqualsDisplaytable = false;
                        break;
                    }
                }
            }

            //check if displaytable equals to shape2
            bool shape2EqualsDisplaytable = true;
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    if (shape2[i, j] != _displayTable[i, j])
                    {
                        shape2EqualsDisplaytable = false;
                        break;
                    }
                }
            }

            //check if displaytable equals to shape3
            bool shape3EqualsDisplaytable = true;
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    if (shape3[i, j] != _displayTable[i, j])
                    {
                        shape3EqualsDisplaytable = false;
                        break;
                    }
                }
            }

            //check if displaytable equals to shape4
            bool shape4EqualsDisplaytable = true;
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    if (shape4[i, j] != _displayTable[i, j])
                    {
                        shape4EqualsDisplaytable = false;
                        break;
                    }
                }
            }

            if (shape1EqualsDisplaytable)
            {
                if (x == 3 || _gameTable[x + 1, y] != Color.White || _gameTable[x, y] != Color.White)
                {
                    return;
                } else
                {
                    _gameTable[x + 1, y] = Color.Blue;
                }
            } else if (shape2EqualsDisplaytable)
            {
                if (y == 3 || _gameTable[x, y + 1] != Color.White || _gameTable[x, y] != Color.White)
                {
                    return;
                } else
                {
                    _gameTable[x, y + 1] = Color.Blue;
                }
            } else if (shape3EqualsDisplaytable)
            {
                if (x == 3 || y == 3 || _gameTable[x + 1, y] != Color.White || _gameTable[x + 1, y + 1] != Color.White || _gameTable[x, y] != Color.White)
                {
                    return;
                } else
                {
                    _gameTable[x + 1, y] = Color.Blue;
                    _gameTable[x + 1, y + 1] = Color.Blue;
                }
            } else if (shape4EqualsDisplaytable)
            {
                if (x == 3 || y == 3 || _gameTable[x, y + 1] != Color.White || _gameTable[x + 1, y + 1] != Color.White || _gameTable[x, y] != Color.White)
                {
                    return;
                } else
                {
                    _gameTable[x, y + 1] = Color.Blue;
                    _gameTable[x + 1, y + 1] = Color.Blue; 
                }
            }

            _gameTable[x, y] = Color.Blue;
            ++points;
            CheckColumnOrRowIsBlue();
            GenerateNewDisplay();
            if (!CanPlaceShapeOnBoard())
            {
                OnGameOver();
            }
        }

        #region Event triggers
        private void OnGameOver()
        {
            if (GameOver != null)
                GameOver(this, EventArgs.Empty);
        }
        #endregion



    }
}
