using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGames.Core.Class;

namespace MyGames.Core
{
    class Model
    {
        /// <summary>
        ///     0 => Player (always)
        ///     1 - n => Building (n : numbers of building)
        ///     n+1 - m => Enemies (m : numbers of enemies)
        /// </summary>
        private List<GameObject> listObject;
        private float playerJump;

        public Model()
        {
            listObject = new List<GameObject>();
            listObject.Add(new Player(10, 10, 0, Controler.graphics.PreferredBackBufferHeight));
            listObject.Add(new Building(39, 10, 20, Controler.graphics.PreferredBackBufferHeight - 39));
            listObject.Add(new Building(39, 10, 35, Controler.graphics.PreferredBackBufferHeight - 39));
            listObject.Add(new Platform(10, 39, 50, Controler.graphics.PreferredBackBufferHeight - (2 * 39)));
            listObject.Add(new Platform(10, 39, 99, Controler.graphics.PreferredBackBufferHeight - (2 * 39)));
            listObject.Add(new Platform(10, 39, 99, Controler.graphics.PreferredBackBufferHeight - 20));
            listObject.Add(new Platform(10, 39, 148, Controler.graphics.PreferredBackBufferHeight - 20));
            playerJump = Player.PosY;
        }

        public void gravity()
        {
            if (Player.PosY + listObject[0].Height < Controler.graphics.PreferredBackBufferHeight)
            {
                Player.PosY += Player.Height / 6;
            }

        }

        #region Collisions
        /// <summary>
        /// Normal collision with player
        /// </summary>
        /// <returns> Blocked Axes </returns>
        public bool[] playerCollision()
        {
            bool[] blockedAxe = new bool[5] { false, false, false, false, false };
            foreach (GameObject ob in listObject)
            {
                if (ob.GetType() != typeof(Player))
                {
                    ///Right
                    if (Player.PosX + Player.Width == ob.PosX
                     && Player.PosY + Player.Height > ob.PosY
                     && Player.PosY < ob.PosY + ob.Height)
                    {
                        blockedAxe[0] = true;
                    }
                    ///Left
                    if (Player.PosX == ob.PosX + ob.Width
                     && Player.PosY + listObject[0].Height > ob.PosY
                     && Player.PosY < ob.PosY + ob.Height)
                    {
                        blockedAxe[1] = true;
                    }
                    ///Up
                    if (ob.PosY + ob.Height == Player.PosY
                     && Player.PosX < ob.PosX + ob.Width
                     && Player.PosX + listObject[0].Width > ob.PosX)
                    {
                        blockedAxe[2] = true;
                    }
                    ///Down
                    if ((ob.PosY == Player.PosY + Player.Height
                      && Player.PosX + Player.Width > ob.PosX
                      && Player.PosX < ob.PosX + ob.Width))
                    {
                        blockedAxe[3] = true;
                    }
                    ///Gravity
                    if (Player.PosY + Player.Height == Controler.graphics.PreferredBackBufferHeight)
                    {
                        blockedAxe[4] = true;
                    }
                }
            }
            return blockedAxe;
        }

        /// <summary>
        /// Use when player fall and use left or right key
        /// </summary>
        public bool[] playerCollisionFallCase()
        {
            bool[] blockedAxe = new bool[2] { false, false };
            foreach (GameObject ob in listObject)
            {
                if (ob.GetType() != typeof(Player))
                {
                    ///Right
                    if (Player.PosX + Player.Width == ob.PosX
                     && Player.PosY + Player.Height >= ob.PosY
                     && Player.PosY <= ob.PosY + ob.Height)
                    {
                        blockedAxe[0] = true;
                    }
                    ///Left
                    if (Player.PosX == ob.PosX + ob.Width
                     && Player.PosY + Player.Height >= ob.PosY
                     && Player.PosY <= ob.PosY + ob.Height)
                    {
                        blockedAxe[1] = true;
                    }
                }
            }
            return blockedAxe;
        }

        /// <summary>
        /// Use when in jump
        /// </summary>
        /// <returns></returns>
        public bool playerCollisionJumpCase()
        {
            bool blockedAxe = false;
            foreach (GameObject ob in listObject)
            {
                if (ob.GetType() != typeof(Player))
                {
                    if ((Player.PosX + Player.Width > ob.PosX
                     && Player.PosX + Player.Width < ob.PosX + ob.Width
                     && Player.PosY + Player.Height > ob.PosY
                     && Player.PosY < ob.PosY + ob.Height)
                     || (Player.PosX < ob.PosX + ob.Width
                     && Player.PosX > ob.PosX
                     && Player.PosY + Player.Height >= ob.PosY
                     && Player.PosY < ob.PosY + ob.Height))
                    {
                        blockedAxe = true;
                    }
                }
            }
            return blockedAxe;
        }
        #endregion

        #region Controls
        #region move/look
        public void move(KeyboardState state)
        {//directionnal cross
            if (state.IsKeyDown(Keys.Left))
            {
                Player.PosX--;
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                Player.PosX++;
            }
            if (state.IsKeyDown(Keys.Up))
            {//Watch top
            }
            if (state.IsKeyDown(Keys.Down))
            {//Watch bot if jump else action 
            }
        }
        #endregion

        #region jump
        public void firstJump()
        {
            playerJump = Player.PosY - 5 * Player.Height;
        }

        public void jump()
        {
            Player.PosY -= Player.Height / 2;
        }
        #endregion

        #region other gameplay key
        public void fire()
        {
            int height = 0;
            int width = 0;
            int dmg = 0;
            switch (Player.WeaponEquip)
            {
                case typeOfWeapon.MAIN:
                    {
                        dmg = Player.Weapons[0].Damage;
                    }
                    break;
                case typeOfWeapon.SECONDARY:
                    {
                        dmg = Player.Weapons[1].Damage;
                    }
                    break;
            }
            Player.Shoots.Add(new Shoot(height, width, (int)Player.PosX + Player.Width, (int)Player.PosY + (height / 2), dmg));
        }

        #region TO DO
        public void power()
        {//nade (throw a nade : 20dmg zone : 3*3) , dash (boost next attack (dmg or firerate up?) + armor : +20 tmp) or snipe (os : 200 dmg)
        }
        #endregion

        public void changeWeapons()
        {
            switch (Player.WeaponEquip)
            {
                case typeOfWeapon.MAIN:
                    Player.WeaponEquip = typeOfWeapon.SECONDARY;
                    break;
                case typeOfWeapon.SECONDARY:
                    Player.WeaponEquip = typeOfWeapon.MAIN;
                    break;
            }
        }
        #endregion
        #endregion

        #region Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            int i = 0;
            foreach (GameObject ob in listObject)
            {
                ob.Draw(spriteBatch);
                if (ob.GetType() == typeof(Player) || ob.GetType() == typeof(Enemy))
                {
                    DrawShoot(i, spriteBatch);
                }
                i++;
            }
        }

        private void DrawShoot(int i, SpriteBatch spriteBatch)
        {
            Perso tmp = (Perso)listObject[i];
            foreach (Shoot s in tmp.Shoots)
            {
                s.Draw(spriteBatch);
            }
        } 
        #endregion

        #region get/set
        public Player Player
        {
            get { return (Player)listObject[0]; }
        }

        public List<GameObject> Objects
        {
            get { return listObject; }
        }

        public float PlayerJump
        {
            get { return playerJump; }
            set { this.playerJump = value; }
        }
        #endregion

    }
}
