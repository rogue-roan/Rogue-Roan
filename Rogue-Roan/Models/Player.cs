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
            LuckRaceBonus = luckRaceBonus; 
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
                float lootWithLuckBonus = 1 + ((float)Luck / 100); // le loot est modifié par la chance du joueur
                Console.WriteLine($"la valeur de loot est {lootWithLuckBonus}");

                int numberOfStuff = (int)(item.Value*lootWithLuckBonus);
                Console.WriteLine($"{Name} trouve {numberOfStuff} {item.Key} sur {target.Name}");
                if (Equipment.ContainsKey(item.Key))
                {
                    Equipment[item.Key] += numberOfStuff;
                }
                else
                {
                    Equipment.Add(item.Key, numberOfStuff);
                }

            }
            target.Equipment.Clear();
        }
        // override de ToString pour qu'il affiche le texte lorsque player.ToString();
        public override string ToString()
        {
            return base.ToString()+$", Chance : {Luck}";
        }
    }
}
