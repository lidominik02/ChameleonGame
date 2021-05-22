using ChameleonGame.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonGame.Model
{
    public class ChameleonModel
    {
        private ChameleonTable _table;
        private IDataAccess _dataAccess;

        public event EventHandler<CameleonEventArgs> GameOver;
        public event EventHandler TableRefresh;

        public ChameleonModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _table = new ChameleonTable();
        }

        public void NewGame(int size)
        {
            _table = new ChameleonTable(size);
        }

        public ChameleonTable Table { get => _table;}

        public int Size { get => _table.Size; }
        public string CurrentCameleon { get => (_table.CurrentCameleon == 1 ? "Piros kaméleon" : "Zöld kaméleon"); }

        public bool Step(int x1,int y1, int x2, int y2)
        {
            if (_table.CurrentCameleon != _table[x1, y1])
                return false;
            if(_table.Step(x1, y1, x2, y2))
            {
                _table.CurrentCameleon = _table.CurrentCameleon == 1 ? 2 : 1;
                _table.ChangeColorExcept(x2,y2);
                OnTableRefresh();
                var winnerCameleon = _table.WinnerCameleon();
                if (winnerCameleon != 0)
                {
                    _table.CurrentCameleon = _table.CurrentCameleon == 1 ? 2 : 1;
                    OnGameOver(winnerCameleon);
                }

                return true;
            }
            return false;
        }

        public async Task LoadGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _table = await _dataAccess.LoadAsync(path);
        }

        public async Task SaveGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _table);
        }

        private void OnTableRefresh()
        {
            if (TableRefresh != null)
                TableRefresh(this,new EventArgs());
        }

        private void OnGameOver(int winnerCameleon)
        {
            if (GameOver != null)
                GameOver(this, new CameleonEventArgs(winnerCameleon));
        }
    }
}
