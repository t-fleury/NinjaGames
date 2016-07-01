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

        public Player(int height, int width, int xPos, int yPos)
            : base(height, width, xPos, yPos - height)
        {
            p = null;
            health = 100;
            dmg = 20;
            armor = 50;
            stealth = false;
            weapons = new Weapon[2] { null, null };
            weapons[0] = new Weapon("shuriken", "classic");
            weaponEquip = typeOfWeapon.MAIN;
        }


        /// <summary>
        /// Use one time per game
        /// Use to tranforsm the player and give him a power and a type of weapon
        /// </summary>
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

        public Weapon[] Weapons
        {
            get { return weapons; }
            set { weapons = value; }
        }
        #endregion
    }
};