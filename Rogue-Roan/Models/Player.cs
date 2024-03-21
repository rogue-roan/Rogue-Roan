using Rogue_Roan.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models
{
    public abstract class Player : Character
    {
        public Player(string race, string name, int endRaceBonus, int strRaceBonus, int agiRaceBonus, int luckRaceBonus) : base(race, name, endRaceBonus, strRaceBonus, agiRaceBonus)
        {
            Dice dice = new Dice(1, 6); // dé utilisé pour la création de personnage
            HPMax = HP;
            LuckRaceBonus = luckRaceBonus; // à enlever, seuls les Pjs ont de la chance à moins que la chance ne serve pour les monstres pour déterminer leur loot ?
            _luck = dice.BestOf(4, 3);
        }
        private int HPMax { get; set; }
        // Chance
        private int _luck;
        public int Luck
        {
            get
            {
                return _luck + LuckRaceBonus;
            }
        }
        public int LuckRaceBonus { get; set; }
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
        // override de ToString pour qu'il affiche le texte lorsque player.ToString();
        public override string ToString()
        {
            return base.ToString()+$", Chance {Luck}";
        }
    }
}
