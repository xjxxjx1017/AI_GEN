using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_GEN
{
    class Spaceship
    {
        public int hull;                        // HP
        public int size;                        // SIZE
        public int speed;                       // SPD              
        public int power;                       // EN
        public int shield;                      // HP+, EN cost     // Resist critical damage
        public int weapon;                      // ATT
        public int weapon_range;                // R
        public int weapon_cost;                 // ATT EN usage
        public int reproduce;                   // Reproduce rate 
        public int reproduce_cost;              // Reproduce EN cost
        public int resource_capasity;           // EN max
        public int resource_gain_speed;         // EN gain speed

    }
}
