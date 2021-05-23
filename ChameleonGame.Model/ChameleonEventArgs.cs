using ChameleonGame.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChameleonGame.Model
{
    public class ChameleonEventArgs
    {
        private int _WinnerChameleon;

        public ChameleonEventArgs(int winnerChameleon)
        {
            WinnerChameleon = winnerChameleon;
        }

        public int WinnerChameleon { get => _WinnerChameleon; private set => _WinnerChameleon = value; }
    }
}
