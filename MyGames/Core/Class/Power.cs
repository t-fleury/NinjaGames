using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core
{
    class Power
    {
        private int difficulty;

        public Power(string name)
        {
            switch (name)
            {
                case "dual": difficulty = 2;
                    break;
                case "sniper": difficulty = 3;
                    break;
                case "smg": difficulty = 1;
                    break;
                default :
                    break;
            }
        }

        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }
    }
}
