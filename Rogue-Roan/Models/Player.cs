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
        //public Character(string race, string name, int endurance, int strength, int agility, int endRaceBonus, int strRaceBonus, int agiRaceBonus)
        //public Monster(string race, string name, int endRaceBonus, int strRaceBonus, int agiRaceBonus) : base(race, name, 0, 0, 0, endRaceBonus, strRaceBonus, agiRaceBonus)
        public Player(string race, string name, int endRaceBonus, int strRaceBonus, int agiRaceBonus, int luckRaceBonus, int endurance, int strength, int agility, int luck) : base(race, name, endRaceBonus, strRaceBonus, agiRaceBonus, endurance, strength, agility)
        {

            // créer la chance du Player

            if (endurance != 0 && strength != 0 && agility != 0)
            {
                // Création du personnage avec des valeurs spécifiées
                _luck = luck;
            }
            else
            {
                // Création du personnage avec des valeurs basées sur des jets de dés
                Dice dice = new Dice(1, 6); // dé utilisé pour la création de personnage
                LuckRaceBonus = luckRaceBonus;

                int luckThrow = dice.BestOf(4, 3);

                _luck = luckThrow + luckRaceBonus;
            }

            // identifier les PV max pour qu'il puisse se régénérer

            HPMax = HP;
        }
        private int HPMax { get; set; }


        // valeur minimale
        private int minValue = 3;

        // Chance
        private int _luck;
        public int Luck
        {
            get
            {
                return _luck;
            }
            set
            {
                if (value < minValue) { value = minValue; }
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
