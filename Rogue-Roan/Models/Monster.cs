using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rogue_Roan.Models
{
    public abstract class Monster : Character
    {
        public Monster(string race, string name, int endRaceBonus, int strRaceBonus, int agiRaceBonus, int luckRaceBonus) : base(race, name, endRaceBonus, strRaceBonus, agiRaceBonus, luckRaceBonus)
        {

        }
    }
}
