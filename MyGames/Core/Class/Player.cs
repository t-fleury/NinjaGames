using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MyGames.Core
{

    enum typeOfWeapon
    {
        MAIN,
        SECONDARY
    }

    class Player : Perso
    {
        private bool stealth;
        private Power p;
        private Weapon[] weapons;
        private typeOfWeapon weaponEquip;
        private int jump;

        public Player(int height, int width, int xPos, int yPos)
            : base(height, width, xPos, yPos-height)
        {
            jump = 0;
            p = null;
            health = 100;
            dmg = 20;
            armor = 50;
            stealth = false;
            weapons = new Weapon[2] {null, null};
            weapons[0] = new Weapon("shuriken", "classic");
            weaponEquip = typeOfWeapon.MAIN;
        }


        //Use one time per game
        public void Transformation(int choix)
        {
            weapons = null;
            switch (choix)
            {
                case 1: 
                    p = new Power("sniper");
                    weapons[0] = new Weapon("sniper", "classic");   
                    health *= 1 / 2;
                    break;
                case 2: 
                    p = new Power("smg");
                    weapons[0] = new Weapon("smg", "classic");
                    health += 100;
                    break;
                default:
                    p = new Power("dual");
                    weapons[0] = new Weapon("dual", "classic");
                    break;
            }
            weapons[1] = new Weapon("gun", "classic");
            weaponEquip = 0;
        }

        #region Control
        public void control(KeyboardState state)
        {
            if(state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Down))
            {
                move(state);
            }
            if (state.IsKeyDown(Keys.X))
            {
                fire();
            }
            if(state.IsKeyDown(Keys.Q))
            {
                changeWeapons();
            }
            if (state.IsKeyDown(Keys.C))
            {
                power();
            }
        }

        private void move(KeyboardState state)
        {//directionnal cross
            if (state.IsKeyDown(Keys.Left))
            {
                position.X--;
            }else if (state.IsKeyDown(Keys.Right))
            {
                position.X++;
            }
            if(state.IsKeyDown(Keys.W))
            {
                position.Y -= height/2;
            }
            if (state.IsKeyDown(Keys.Up))
            {//Watch top
            }
            if (state.IsKeyDown(Keys.Down))
            {//Watch bot if jump else action 
            }
        }

        #region TO DO
        private void fire()
        {//use weapon[x].firerate to change the "fire key mode" like key pressed = continue shot or key pressed = one shot
        }

        private void power()
        {//nade (throw a nade : 20dmg zone : 3*3) , dash (boost next attack (dmg or firerate up?) + armor : +20 tmp) or snipe (os : 200 dmg)
        }
        #endregion

        private void changeWeapons()
        {//if key pressed => TO DO
            switch (weaponEquip)
            {
                case typeOfWeapon.MAIN:
                    weaponEquip = typeOfWeapon.SECONDARY;
                    break;
                case typeOfWeapon.SECONDARY:
                    weaponEquip = typeOfWeapon.MAIN;
                    break;
            }
        }
        #endregion

        #region get/set

        public bool Stealth
        {
            get { return stealth; }
            set { stealth = value; }
        }

        public typeOfWeapon WeaponEquip
        {
            get { return weaponEquip; }
            set { weaponEquip = value; }
        }
        #endregion
    }
};