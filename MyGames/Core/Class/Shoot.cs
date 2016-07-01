using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core.Class
{
    class Shoot : GameObject
    {
        private int dmg;

        public Shoot(int height, int width, int xPos, int yPos, int dmg)
            : base(height, width, xPos, yPos)
        {
            this.Texture = Controler.shoot;
            this.dmg = dmg;
        }

        public void move()
        {
            this.PosX++;
        }
    }
}
