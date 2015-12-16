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
        private int stealth;
        private Power p;
        private Weapon[] weapons;
        private typeOfWeapon weaponEquip;

        public Player(int height, int width, int xPos, int yPos)
            : base(height, width, xPos, yPos)
        {
            p = null;
            health = 100;
            dmg = 20;
            armor = 50;
            stealth = 75;
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

        #region Control (TO DO)
        public void move(KeyboardState state)
        {//directionnal cross
        }

        public void fire(KeyboardState state)
        {//use weapon[x].firerate to change the "fire key mode" like key pressed = continue shot or key pressed = one shot
        }

        public void power(KeyboardState state)
        {//nade (throw a nade : 20dmg zone : 3*3) , dash (boost next attack (dmg or firerate up?) + armor : +20 tmp) or snipe (os : 200 dmg)
        }

        public void changeWeapons(KeyboardState state)
        {//if key pressed => TO DO
            switch (weaponEquip)
            {
                case typeOfWeapon.MAIN: weaponEquip = typeOfWeapon.SECONDARY;
                    break;
                case typeOfWeapon.SECONDARY: weaponEquip = typeOfWeapon.MAIN;
                    break;
            }
        }

        #endregion

        public int Stealth
        {
            get { return stealth; }
            set { stealth = value; }
        }

        public typeOfWeapon WeaponEquip
        {
            get { return weaponEquip; }
            set { weaponEquip = value; }
        }
    }
}
;