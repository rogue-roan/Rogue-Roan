using Rogue_Roan.Enums;
using Rogue_Roan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Ennemies
{
    public class Goblin : Monster
    {
        public Goblin(string name) : base("Gobelin", name, -1, -2, +2)
        {
            // donne 1D6 po
            Dice diceGold = new Dice(1, 6);
            Equipment.Add(Items.Gold, diceGold.Throw());

        }
    }
}
