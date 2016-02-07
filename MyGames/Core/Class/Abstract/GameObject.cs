using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGames.Core
{
    abstract class GameObject
    {
        protected int height;
        protected int width;
        protected Vector2 position;
        private Texture2D texture;

        public GameObject(int height, int width, int xPos, int yPos)
        {
            this.height = height;
            this.width = width;
            position.X = xPos;
            position.Y = yPos;
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        #region get/set
        public Vector2 Position
        {
            get { return position; }
        }

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }

        public float PosX
        {
            set { position.X = value; }
        }

        public float PosY
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        #endregion
    }
}
