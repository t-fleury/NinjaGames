using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGames.Core
{
    class Model
    {
        /// <summary>
        /// memo : 
        ///     0 => Player (always)
        ///     1 - n => Building (n : numbers of building)
        ///     n+1 - m => Enemies (m : numbers of enemies)
        /// </summary>
        private List<GameObject> listObject;

        public Model()
        {
            listObject = new List<GameObject>();
            listObject.Add(new Player(10, 10, 0, Controler.graphics.PreferredBackBufferHeight));
            listObject.Add(new Building(39, 10, 20, Controler.graphics.PreferredBackBufferHeight - 39));
            listObject.Add(new Building(39, 10, 35, Controler.graphics.PreferredBackBufferHeight - 39));
        }

        public void gravity()
        {
            if (listObject[0].PosY + listObject[0].Height < Controler.graphics.PreferredBackBufferHeight)
            {
                listObject[0].PosY = listObject[0].PosY + listObject[0].Height / 6;
            }
            
        }

        #region collision
        public bool[] playerCollision()
        {
            bool[] blockedAxe = new bool[4] { false, false, false, false };
            foreach (GameObject ob in listObject)
            {
                if (ob.GetType() != typeof(Player))
                {
                    if (listObject[0].PosX + listObject[0].Width == ob.PosX
                        && listObject[0].PosY >= ob.PosY
                        && listObject[0].PosY <= ob.PosY + ob.Height)
                    {
                        blockedAxe[0] = true;
                    }
                    if (listObject[0].PosX == ob.PosX + ob.Width
                       && listObject[0].PosY >= ob.PosY
                       && listObject[0].PosY <= ob.PosY + ob.Height)
                    {
                        blockedAxe[1] = true;
                    }
                    if (ob.PosY + ob.Height == listObject[0].PosY
                       && listObject[0].PosX >= ob.PosX
                       && listObject[0].PosX <= ob.PosX + ob.Width)
                    {
                        blockedAxe[2] = true;
                    }
                    if (ob.PosY == listObject[0].PosY + listObject[0].Height
                       && listObject[0].PosX + listObject[0].Width > ob.PosX
                       && listObject[0].PosX < ob.PosX + ob.Width)
                    {
                        blockedAxe[3] = true;
                    }
                }
            }
            return blockedAxe;
        } 
        #endregion

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject obj in listObject)
            {
                obj.Draw(spriteBatch);
            }
        }

        #region get/set
        public Player Player
        {
            get { return (Player)listObject[0]; }
        }

        public List<GameObject> Objects
        {
            get { return listObject; }
        } 
        #endregion

    }
}
