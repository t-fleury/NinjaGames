using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core
{
    abstract class Perso : GameObject
    {
        protected int health;
        protected int dmg;
        protected int armor;

        public Perso(int height, int width, int xPos, int yPos)
            : base(height, width, xPos, yPos) 
        {}
    }
}
