using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using MyGames.Core.Class;
using Microsoft.Xna.Framework;

namespace MyGames.Core
{
    class Perso : GameObject
    {
        protected int health;
        protected int dmg;
        protected int armor;
        protected List<Shoot> shoots;

        public Perso(int height, int width, int xPos, int yPos)
            : base(height, width, xPos, yPos) 
        {
            shoots = new List<Shoot>();
        }

        public List<Shoot> Shoots
        {
            get { return shoots; }
        }
    }
}
