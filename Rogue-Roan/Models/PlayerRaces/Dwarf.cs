using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.PlayerRaces
{
    public class Dwarf : Player
    {
        public Dwarf(string name, int endurance=0, int strength=0, int agility=0, int luck=0) : base("Nain", name, 2, 2, -2, 0, endurance, strength, agility, luck)
        {

        }
    }
}
