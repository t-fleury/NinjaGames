using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core
{
    class Building : GameObject
    {
        public Building(int height, int width, int xPos, int yPos)
            : base(height, width, xPos, yPos)
        {}
    }
}
