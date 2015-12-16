using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core
{
    // All non-movable things for the moments
    class Building : GameObject
    {
        public Building(int height, int width, int xPos, int yPos)
            : base(height, width, xPos, yPos)
        {}
    }
}
