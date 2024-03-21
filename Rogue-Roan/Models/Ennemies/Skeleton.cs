using Rogue_Roan.Enums;
using Rogue_Roan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Ennemies
{
    public class Skeleton : Monster
    {
        public Skeleton(string name) : base("Squelette", name, 2, 0, -2)
        {
            // donne 1D50 po
            Dice diceGold = new Dice(1, 50);
            Equipment.Add(Items.Gold,diceGold.Throw());
        }
    }
}
