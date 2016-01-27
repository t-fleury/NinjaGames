using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MyGames.Core
{
    class Model
    {
        private Player player;
        private Building building;

        public Model()
        {
            player = new Player(10, 10, 0, Controler.graphics.PreferredBackBufferHeight);
            building = new Building(10, 39, Controler.graphics.PreferredBackBufferWidth / 2, Controler.graphics.PreferredBackBufferHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            building.Draw(spriteBatch);
        }

        public Player Player
        {
            get { return player; }
        }
    }
}
