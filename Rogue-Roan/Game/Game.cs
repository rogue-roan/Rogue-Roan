using Rogue_Roan.Models;
using Rogue_Roan.Models.PlayerRaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Rogue_Roan.Enums;

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
            Console.WriteLine("Appuyez sur une touche pour quitter");
            Console.ReadKey();
        }
        public static Player CreateHero()
        {

            int choix = 0;
            do
            {
                Console.WriteLine("voulez-vous un personnage prétiré(1) ou voulez-vous le créer vous même (2) ?");
                choix = int.Parse(Console.ReadLine());
            } while (choix < 1 || choix > 2);

            switch (choix)
            {
                case 1:
                    return PreGenHero();
                default:
                    return HomeMadeHero();
            }




            // le code ci dessous est pour avoir la trame
            // l'idée c'est : 1) prétiré ou fait maison ?
            // Si prétiré : choix de la race et choix du nom

            //int raceChoosen = 1;
            //string name = "toto";
            //switch (raceChoosen)
            //{
            //    case 1:
            //        return new Dwarf(name); 
            //    case 2:
            //        return new Elf(name);
            //    case 3:
            //        return new Halflin(name);
            //    default:
            //        return new Human(name);
            //}

            // si custom : créer la suite : même systeme que pathfinder : 12 PC

        }

        public static Player HomeMadeHero()
        {
            // demander le nom
            string name = NameChoice();

            // demander la race
            string race = RaceChoice();

            // demander les stats
            // pas de methode car je n'utiliserai ça qu'ici


            // retourner le personnage

            return new Human(name);
        }

        public static Player PreGenHero()
        {
            // demander le nom
            string name = NameChoice();

            // demander la race
            string race = RaceChoice();

            switch (race)
            {
                case "Elfe":
                    return new Elf(name);
                case "Nain":
                    return new Dwarf(name);
                case "Halfelin":
                    return new Halflin(name);
                default:
                    return new Human(name);
            }
        }

        public static string RaceChoice()
        {
            string raceChoice = "";

            // faire une boucle sur le nombre d'items dans enum pour afficher chaque race disponible
            Console.WriteLine("Voici les races de personnage disponibles ?");

            foreach (Races race in Enum.GetValues(typeof(Races)))
            {
                Console.WriteLine($"{race}");
            }

            bool validRaceChoice = false;
            do
            {
                Console.WriteLine("Faites votre choix ?");
                raceChoice = Console.ReadLine();

                // verifier si le choix est valide
                foreach (Races race in Enum.GetValues(typeof(Races)))
                {
                    if (raceChoice == race.ToString())
                    {
                        validRaceChoice = true;
                    }
                }
            } while (!validRaceChoice);

            return raceChoice;
        }
        public static string NameChoice()
        {
            string name = "";
            do
            {
                Console.WriteLine("Quel sera le nom de votre personnage ?");
                name = Console.ReadLine();
            } while (name == "");

            return name;
        }
    }
}
