using Rogue_Roan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Game
{
    public class Game
    {
        public static void Fight(Player hero, Monster monster)
        {
            while (!hero.IsDead && !monster.IsDead)
            {

                hero.Hits(monster);
                if (!monster.IsDead)
                {
                    monster.Hits(hero);
                }

            }

            if (hero.IsDead)
            {

                return;
            }
            Console.WriteLine($"{hero.Name} a terrassé {monster.Name}.");
            hero.Loot(monster); 
            hero.RegenerateLife();
            Console.ReadKey();

        }
    }
}
