using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core.Class
{
    class Store : Perso
    {
        private Weapon[] WeaponSale;

        public Store(int height, int width, int xPos, int yPos, string type)
            : base(height, width, xPos, yPos) 
        {
            armor = 10000;
            health = 10000;
            dmg = 0;

            for(int i = 0; i >= 5; i++)
            {
                WeaponSale[i] = new Weapon(type);
            }
        }


    }
}