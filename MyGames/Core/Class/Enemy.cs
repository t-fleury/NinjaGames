using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core
{       
    class Enemy : Perso
    {
        private string type;
        //Build enemy with a type
        public Enemy(int height, int width, int xPos, int yPos, string type)
            : base(height, width, xPos, yPos)
        {
            this.type = type;
            switch (this.type)
            {
                case "Lancer" :
                    health = 100;
                    armor = 50;
                    dmg = 20;
                    break;
                case "Crewman" :
                    health = 50;
                    armor = 50;
                    dmg = 50;
                    break;
                case "Charger" :
                    health = 150;
                    armor = 0;
                    dmg = 10;
                    break;
                case "Runner" :
                    health = 150;
                    armor = 10;
                    dmg = 30;
                    break;
                default :
                    break;
            }
        }
        #region TO DO

        public void fire(GameObject obj)
        {
        }

        #endregion

        #region get/set
        public String Type
        {
            get { return this.type; }
        }
        #endregion
    }
}
