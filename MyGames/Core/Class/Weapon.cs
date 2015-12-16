using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGames.Core
{
    class Weapon
    {
        private int dmg;
        private float firerate;

        //Construct weapons with a type and a name
        public Weapon(String type, String name)
        {
            switch (type)
            {
                case "smg":
                    switch (name)
                    {
                        default:
                            dmg = 10;
                            firerate = 5.0f;
                            break;
                    }
                    break;
                case "sniper" :
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
                    dmg = 10;
                    firerate = 1.0f;
                    break;
            }
        }
    }
}
