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
            player = new Player(10, 39, 0, Controler.graphics.PreferredBackBufferHeight - 39);
            building = new Building(10, 10, Controler.graphics.PreferredBackBufferWidth / 2, Controler.graphics.PreferredBackBufferHeight - 10);
        }

        public void gravity()
        {
            if (player.Position.Y + player.Height < Controler.graphics.PreferredBackBufferHeight)
            {
                player.Jump--;
                player.PosY = player.PosY + player.Height / 4;
            }
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

        public Building Building
        {
            get { return building; }
        }
    }
}
