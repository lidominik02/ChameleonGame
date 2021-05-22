using ChameleonGame.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonGame.Model
{
    public class CameleonEventArgs
    {
        private int _winnerCameleon;

        public CameleonEventArgs(int winnerCameleon)
        {
            WinnerCameleon = winnerCameleon;
        }

        public int WinnerCameleon { get => _winnerCameleon; private set => _winnerCameleon = value; }
    }
}
