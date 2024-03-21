using Rogue_Roan.Enums;
using Rogue_Roan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Ennemies
{
    public class Orc : Monster
    {
        public Orc(string name) : base("Orque", name, 1, 2, -2)
        {
            // donne 1D20 po
            Dice diceGold = new Dice(1, 20);
            Equipment.Add(Items.Gold, diceGold.Throw());

        }
    }
}
