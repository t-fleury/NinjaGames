using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core
{
    enum nameGun
    {
        classic_gun,
        plasma_gun,
        fire_gun,
        automatic_gun,
        colt
    };

    enum nameSmg
    {
        classic_smg,
        plasma_smg,
        fire_smg,

    };

    enum nameSniper
    {
        classic_sniper,
        plasma_sniper,
        automatic_sniper,
    };

    enum nameDual
    {
        dual_classic,
        dual_plasma,
        dual_fire,
        dual_automatic,
        dual_colt
    };

    class Weapon
    {
        private int dmg;
        private float firerate;
        private string name;
        private int ammo;

        //random Weapon
        public Weapon(string type)
        {
            Random tmp = new Random();
            switch (type)
            {
                case "gun":
                    switch (tmp.Next(0, 4))
                    {
                        default:
                            break;  
                    }
                    break;
                case "smg":
                    switch (tmp.Next(0, 2))
                    {
                        default:
                            break;
                    }
                    break;
                case "Sniper":
                    switch (tmp.Next(0, 2))
                    {
                        default:
                            break;
                    }
                    break;
                case "Dual":
                    switch (tmp.Next(0, 4))
                    {
                        default:
                            break;
                    }
                    break;
            }
        }

        //Construct weapons with a type and a name
        public Weapon(string type, string name)
        {
            switch (type)
            {
                case "smg":
                    switch (name)
                    {
                        default:
                            dmg = 10;
                            firerate = 5.0f;
                            name = "Classic";
                            ammo = -1;
                            break;
                    }
                    break;
                case "sniper":
                    switch (name)
                    {
                        default:
                            dmg = 50;
                            firerate = 0.5f;
                            break;
                    }
                    break;
                case "gun":
                    switch (name)
                    {
                        default:
                            dmg = 5;
                            firerate = 1.0f;
                            break;
                    }
                    break;
                case "dual":
                    switch (name)
                    {
                        default:
                            dmg = 20;
                            firerate = 2.5f;
                            break;
                    }
                    break;
                default:
                    switch (name) {
                        default:
                            dmg = 10;
                            firerate = 1.0f;
                            this.name = name;
                            ammo = -1;
                            break;
                }
                    break;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
