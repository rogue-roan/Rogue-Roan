using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.PlayerRaces
{
    public class Human : Player
    {
        public Human(string name, int endurance = 0, int strength = 0, int agility = 0, int luck = 0) : base("Humain",name,0,1,1,0, endurance, strength, agility, luck)
        {

        }
    }
}
