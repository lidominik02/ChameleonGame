using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChameleonGame.Persistence
{
    public class ChameleonTable
    {
        private int[,] _cameleonTable;
        private int[,] _colorTable;
        private int _size;

        public ChameleonTable(int size)
        {
            CurrentCameleon = 1;
            if (size % 2 == 0)
                throw new ArgumentException("Invalid size!", "size");
            else
            {
                _size = size;
                _cameleonTable = new int[size, size];
                _colorTable = new int[size, size];
            }
            for (int i = 0; i < _size; i++)
            {
                for (int j = i; j < _size - i; j++)
                {
                    if (i == (_size / 2) && j == (_size / 2))
                        continue;

                    if (i % 2 == 0)
                    {
                        _cameleonTable[i, j] = 1;
                        _colorTable[i, j] = 1;
                        if (i + j != size - 1)
                        {
                            _cameleonTable[j, i] = 1;
                            _colorTable[j, i] = 1;
                        }
                    }
                    else
                    {
                        _cameleonTable[i, j] = 2;
                        _colorTable[i, j] = 2;
                        if (i + j != size - 1)
                        {
                            _cameleonTable[j, i] = 2;
                            _colorTable[j, i] = 2;
                        }
                    }
                }
                for (int j = size - 1 - i; j < i + 1; j++)
                {
                    if (i == (_size / 2) && j == (_size / 2))
                        continue;

                    if (i % 2 == 1)
                    {
                        _cameleonTable[i, j] = 1;
                        _colorTable[i, j] = 1;
                        if (i + j != size - 1)
                        {
                            _cameleonTable[j, i] = 1;
                            _colorTable[j, i] = 1;
                        }
                    }
                    else
                    {
                        _cameleonTable[i, j] = 2;
                        _colorTable[i, j] = 2;
                        if (i + j != size - 1)
                        {
                            _cameleonTable[j, i] = 2;
                            _colorTable[j, i] = 2;
                        }
                    }
                }
            }
        }

        public ChameleonTable()
        {
            CurrentCameleon = 1;
            _size = 3;
            _cameleonTable = new int[_size, _size];
            _colorTable = new int[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = i; j < _size - i; j++)
                {
                    if (i == (_size / 2) && j == (_size / 2))
                        continue;

                    if (i % 2 == 0)
                    {
                        _cameleonTable[i, j] = 1;
                        _colorTable[i, j] = 1;
                        if (i + j != _size - 1)
                        {
                            _cameleonTable[j, i] = 1;
                            _colorTable[j, i] = 1;
                        }
                    }
                    else
                    {
                        _cameleonTable[i, j] = 2;
                        _colorTable[i, j] = 2;
                        if (i + j != _size - 1)
                        {
                            _cameleonTable[j, i] = 2;
                            _colorTable[j, i] = 2;
                        }
                    }
                }
                for (int j = _size - 1 - i; j < i + 1; j++)
                {
                    if (i == (_size / 2) && j == (_size / 2))
                        continue;

                    if (i % 2 == 1)
                    {
                        _cameleonTable[i, j] = 1;
                        _colorTable[i, j] = 1;
                        if (i + j != _size - 1)
                        {
                            _cameleonTable[j, i] = 1;
                            _colorTable[j, i] = 1;
                        }
                    }
                    else
                    {
                        _cameleonTable[i, j] = 2;
                        _colorTable[i, j] = 2;
                        if (i + j != _size - 1)
                        {
                            _cameleonTable[j, i] = 2;
                            _colorTable[j, i] = 2;
                        }
                    }
                }
            }
        }

        public int Size { get => _size; }

        public int CurrentCameleon { get; set; }

        public int this[int x, int y]
        {
            get { return GetValue(x, y); }
            set { SetValue(x,y,value); }
        }

        private int GetValue(int x, int y)
        {
            if (x < 0 || x >= _cameleonTable.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _cameleonTable.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");

            return _cameleonTable[x, y];
        }

        private void SetValue(int x, int y, int value)
        {
            if (x < 0 || x >= _cameleonTable.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _cameleonTable.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");
            if (value < 0 || value > 2)
                throw new ArgumentOutOfRangeException("value", "The value is out of range.");

            _cameleonTable[x, y] = value;
        }

        public int GetColor(int x, int y)
        {
            if (x < 0 || x >= _cameleonTable.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X coordinate is out of range.");
            if (y < 0 || y >= _cameleonTable.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y coordinate is out of range.");

            return _colorTable[x, y];
        }


        public bool Step(int x1, int y1, int x2, int y2)
        {
            if (x1 < 0 || x1 >= _cameleonTable.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X1 coordinate is out of range.");
            if (y1 < 0 || y1 >= _cameleonTable.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y1 coordinate is out of range.");
            if (x2 < 0 || x2 >= _cameleonTable.GetLength(0))
                throw new ArgumentOutOfRangeException("x", "The X2 coordinate is out of range.");
            if (y2 < 0 || y2 >= _cameleonTable.GetLength(1))
                throw new ArgumentOutOfRangeException("y", "The Y2 coordinate is out of range.");
            if (_cameleonTable[x1, y1] == 0)
                return false;
            
            if (Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2))) == 1 && (x1 == x2 || y1 == y2))
            {
                if (_cameleonTable[x2, y2] == 0)
                {
                    _cameleonTable[x2, y2] = _cameleonTable[x1, y1];
                    _cameleonTable[x1, y1] = 0;
                    return true;
                }
            }
            else if (Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2))) == 2 && (x1 == x2 || y1 == y2))
            {
                if (_cameleonTable[x2, y2] == 0)
                {
                    if (y1 < y2 && (_cameleonTable[x1, y1 + 1] != _cameleonTable[x1, y1]))
                    {
                        _cameleonTable[x1, y1 + 1] = 0;
                        _cameleonTable[x2, y2] = _cameleonTable[x1, y1];
                        _cameleonTable[x1, y1] = 0;
                        return true;
                    }
                    else if (y1 > y2 && (_cameleonTable[x1, y1 - 1] != _cameleonTable[x1, y1]))
                    {
                        _cameleonTable[x1, y1 - 1] = 0;
                        _cameleonTable[x2, y2] = _cameleonTable[x1, y1];
                        _cameleonTable[x1, y1] = 0;
                        return true;
                    }
                    else if (x1 < x2 && (_cameleonTable[x1 + 1, y1] != _cameleonTable[x1, y1]))
                    {
                        _cameleonTable[x1 + 1, y1] = 0;
                        _cameleonTable[x2, y2] = _cameleonTable[x1, y1];
                        _cameleonTable[x1, y1] = 0;
                        return true;
                    }
                    else if (x1 > x2 && (_cameleonTable[x1 - 1, y1] != _cameleonTable[x1, y1]))
                    {
                        _cameleonTable[x1 - 1, y1] = 0;
                        _cameleonTable[x2, y2] = _cameleonTable[x1, y1];
                        _cameleonTable[x1, y1] = 0;
                        return true;
                    }
                }
            }
            return false;
        }

        public int WinnerCameleon()
        {
            int numOfRC = 0;
            int numOfGC = 0;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_cameleonTable[i, j] == 1)
                        numOfRC++;
                    else if (_cameleonTable[i, j] == 2)
                        numOfGC++;
                }
            }

            if (numOfGC != 0 && numOfRC != 0)
                return 0;

            return (numOfGC == 0) ? 1 : 2;
        }

        public void ChangeColorExcept(int x, int y)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (x == i && y == j)
                        continue;

                    if (_colorTable[i, j] == 1 && _cameleonTable[i, j] != 0)
                    {
                        _cameleonTable[i, j] = 1;
                    }
                    else if (_colorTable[i, j] == 2 && _cameleonTable[i, j] != 0)
                    {
                        _cameleonTable[i, j] = 2;
                    }
                }
            }
        }

    }
}
