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

            // l'idée c'est de tout afficher, une valeur pour dire où se trouve la croix tout commence à 10 + pour augmenter - pour diminuer minimum 3 maximum 18 on affiche les points restants au dessus (calcule par X-valeur de chaque carac)

            int startCP = 22;
            int strenght = 10;
            string crossStrenght = "X";
            int strenghtCost = CostCalcul(strenght);
            int endurance = 10;
            string crossEndurance = " ";
            int enduranceCost = CostCalcul(endurance);
            int agility = 10;
            string crossAgility = " ";
            int agilityCost = CostCalcul(agility);
            int luck = 10;
            string crossLuck = " ";
            int luckCost = CostCalcul(luck);
            int costCP = strenghtCost + enduranceCost + agilityCost + luckCost;
            int CP = startCP - costCP;
            string error = "";
            char key =' ';

            int strenghtBonus = 2;
            int enduranceBonus = 2;
            int agilityBonus = 2;
            int luckBonus = 2;

            do
            {
                Console.Clear(); 
                costCP = strenghtCost + enduranceCost + agilityCost + luckCost;
                CP = startCP - costCP;

                Console.WriteLine($"il vous reste {CP} points {error}");
                Console.WriteLine();
                Console.WriteLine("╔═══════════════╦════╦════╦═════╦════╗");
                Console.WriteLine("║Caractéristique║base║race║total║coût║");
                Console.WriteLine("╠═══════════════╬════╬════╬═════╬════╣");


                // ╔ ╩ ╦ ╔ ═ ╗ ║ ╚ ╝ ╣ ­ ╠ ╬ 

                Console.WriteLine($"║[{crossStrenght}]Force\t║ {(strenght<10?" "+strenght:strenght)} ║{(strenghtBonus > 0 ? " " + strenghtBonus : strenghtBonus)}  ║ {(strenght+strenghtBonus<10?" "+ strenght + strenghtBonus: strenght + strenghtBonus)}  ║{(strenghtCost.ToString().Length == 1 ? "  " + strenghtCost : strenghtCost.ToString().Length == 2 ? " " + strenghtCost : strenghtCost)} ║");
                Console.WriteLine($"║[{crossEndurance}]Endurance\t║ {(endurance<10?" "+endurance:endurance)} ║{(enduranceBonus >0 ? " " + enduranceBonus : enduranceBonus)}  ║ {(endurance + enduranceBonus<10?" "+ endurance + enduranceBonus: endurance + enduranceBonus)}  ║{(enduranceCost.ToString().Length == 1 ? "  " + enduranceCost : enduranceCost.ToString().Length == 2 ? " " + enduranceCost : enduranceCost)} ║");
                Console.WriteLine($"║[{crossAgility}]Agilite\t║ {(agility < 10 ? " " + agility : agility)} ║{(agilityBonus > 0 ? " " + agilityBonus : agilityBonus)}  ║ {(agility + agilityBonus<10?" "+agility+agilityBonus: agility + agilityBonus)}  ║{(agilityCost.ToString().Length == 1 ? "  " + agilityCost : agilityCost.ToString().Length == 2 ? " " + agilityCost : agilityCost)} ║");
                Console.WriteLine($"║[{crossLuck}]Chance\t║ {(luck < 10 ? " " + luck : luck)} ║{(luckBonus > 0 ? " " + luckBonus : luckBonus)}  ║ {(luck + luckBonus < 10 ? " " + luck + luckBonus : luck + luckBonus)}  ║{(luckCost.ToString().Length == 1 ? "  " + luckCost : luckCost.ToString().Length == 2 ? " " + luckCost : luckCost)}║");
                Console.WriteLine("╚═══════════════╩════╩════╩═════╩════╝");
                Console.WriteLine("Tapez \"T\" pour terminer");


                //Console.WriteLine($"{(strenghtCost.ToString().Length==1?"  "+strenghtCost: strenghtCost.ToString().Length == 2 ?" "+strenghtCost:strenghtCost)}");

                key = Console.ReadKey().KeyChar;
                // cas : fleche du bas crossPosition = +1, si crossposition =4 alors +0
                // cas : fleche du haut crossPosition = -1, si crossposition =1 alors -0
                // cas : fleche a gauche
                // si crossposition = 1 alors force -1 (sauf si = 3) : redéfinir error
                // si crossposition = 2 alors endurance -1 (sauf si = 3) : redéfinir error
                // si crossposition = 3 alors agilité -1 (sauf si = 3) : redéfinir error
                // si crossposition = 4 alors chance -1 (sauf si = 3) : redéfinir error
                // cas : fleche a droite
                // si crossposition = 1 alors force +1 (sauf si = 18) : redéfinir error
                // si crossposition = 2 alors endurance +1 (sauf si = 18) : redéfinir error
                // si crossposition = 3 alors agilité +1 (sauf si = 18) : redéfinir error
                // si crossposition = 4 alors chance +1 (sauf si = 18) : redéfinir error
                // recalculer CP

                Console.WriteLine($"vous avez tapé {key}");



            } while (key != 't' && key != 'T');







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
        public static int CostCalcul(int carac)
        {
            switch (carac)
            {
                case 3:
                    return -13;
                case 4:
                    return -10;
                case 5:
                    return -7;
                case 6:
                    return -5;
                case 7:
                    return -3;
                case 8:
                    return -2;
                case 9:
                    return -1;
                case 11:
                    return 1;
                case 12:
                    return 2;
                case 13:
                    return 3;
                case 14:
                    return 5;
                case 15:
                    return 7;
                case 16:
                    return 10;
                case 17:
                    return 13;
                case 18:
                    return 17;
                default:
                    return 0;
            }


        }
    }
}
