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
            /*Vector2 tmp = new Vector2();
            tmp.X = 0;
            tmp.Y = 0;
            float scale = 0.67f;
            spriteBatch.Draw(texture, position, null, Color.White, 0.0f, tmp,scale,SpriteEffects.None,0.0f);*/
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
