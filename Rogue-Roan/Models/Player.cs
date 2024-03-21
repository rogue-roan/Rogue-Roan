using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models
{
    public abstract class Player : Character
    {
        public Player(string race, string name, int endRaceBonus, int strRaceBonus, int agiRaceBonus, int luckRaceBonus) : base(race, name, endRaceBonus, strRaceBonus, agiRaceBonus, luckRaceBonus)
        {
            HPMax = HP;
        }
        private int HPMax {  get; set; }

        public void RegenerateLife()
        {
            HP = HPMax;
            Console.WriteLine($"{Name} revient à {HP} Points de vie");
        }
        public void Loot(Monster target)
        {
            foreach (var item in target.Equipment)
            {
                Console.WriteLine($"{Name} loot {item.Value} {item.Key} sur {target.Name}");
                if (Equipment.ContainsKey(item.Key))
                {
                    Equipment[item.Key] += item.Value;
                }
                else
                {
                    Equipment.Add(item.Key, item.Value);
                }

            }
            target.Equipment.Clear();
        }
    }
}
