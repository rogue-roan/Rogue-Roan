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
        public Goblin(string name, int endRaceBonus, int strRaceBonus, int agiRaceBonus) : base("Gobelin", name, -1, -2, +2)
        {


            // donne 1D100 po
            Dice diceGold = new Dice(1, 100);
            Equipment.Add(Items.Gold, diceGold.Throw());

        }

        public Goblin(string name) : base("Gobelin", "billy", 8, 15, 17)
        {

        }




        //int bonusStrength = -2;
        //int bonusEndurance = -1;
        //int bonusAgility = 2;

        //Dice carac = new Dice(1, 6);

        //int baseStrength = carac.BestOf(4, 3);
        //int baseEndurance = carac.BestOf(4, 3);
        //int baseAgility = carac.BestOf(4, 3);

        //strength = baseStrength + bonusStrength; // 8
        //    endurance = baseEndurance + bonusEndurance; // 15
        //    agility = baseAgility + bonusAgility; // 12

        //    // Goblin Billy = new Goblin("billy", 8, 15, 12)

    }
}
