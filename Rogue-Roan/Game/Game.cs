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

            // initialisation des valeurs

            // Points de création
            int startCP = 22;
            int costCP = strenghtCost + enduranceCost + agilityCost + luckCost;
            int CP = startCP - costCP;

            // Force
            int strenght = 10;
            string crossStrenght = "X";
            int strenghtCost = CostCalcul(strenght);
            int strenghtBonus;

            // endurance
            int endurance = 10;
            string crossEndurance = " ";
            int enduranceCost = CostCalcul(endurance);
            int enduranceBonus;

            // Agilité
            int agility = 10;
            string crossAgility = " ";
            int agilityCost = CostCalcul(agility);
            int agilityBonus;

            // Chance
            int luck = 10;
            string crossLuck = " ";
            int luckCost = CostCalcul(luck);
            int luckBonus;

            // message en cas d'erreur
            string error = "";

            // Calcul des modificateurs raciaux
            switch (race)
            {
                case "Humain":
                    strenghtBonus = 1;
                    enduranceBonus = 0;
                    agilityBonus = 1;
                    luckBonus = 0;
                    break;
                case "Nain":
                    strenghtBonus = 2;
                    enduranceBonus = 2;
                    agilityBonus = -2;
                    luckBonus = 0;
                    break;
                case "Elfe":
                    strenghtBonus = 0;
                    enduranceBonus = -2;
                    agilityBonus = 2;
                    luckBonus = 2;
                    break;
                case "Halfelin":
                    strenghtBonus = -2;
                    enduranceBonus = 0;
                    agilityBonus = 2;
                    luckBonus = 2;
                    break;
                default:
                    strenghtBonus = 0;
                    enduranceBonus = 0;
                    agilityBonus = 0;
                    luckBonus = 0;
                    break;
            }


            // valeurs diverses

            ConsoleKey key;
            int crossPosition = 1;
            bool exit = false;

            do
            {
                
                Console.Clear(); // on efface l'écran
                costCP = strenghtCost + enduranceCost + agilityCost + luckCost; // on recalcule le cout total en CP
                CP = startCP - costCP; // valeur de CP actuelle

                Console.WriteLine($"il vous reste {CP} points");
                if (CP<0)
                {
                    Console.WriteLine("vous ne pouvez pas avoir un nombre de points négatif");
                }
                if (error!="") // s'il y a une erreur, on l'affiche
                {
                Console.WriteLine($"ATTENTION {error}");
                    error = "";
                }

                // affichage du tableau

                Console.WriteLine();
                Console.WriteLine("╔═══════════════╦════╦════╦═════╦════╗");
                Console.WriteLine("║Caractéristique║base║race║total║coût║");
                Console.WriteLine("╠═══════════════╬════╬════╬═════╬════╣");
                Console.WriteLine($"║[{crossStrenght}]Force\t║ {(strenght<10?" "+strenght:strenght)} ║{(strenghtBonus >= 0 ? " " + strenghtBonus : strenghtBonus)}  ║ {(strenght+strenghtBonus<10?" "+ (strenght + strenghtBonus): (strenght + strenghtBonus))}  ║{(strenghtCost.ToString().Length == 1 ? "  " + strenghtCost : strenghtCost.ToString().Length == 2 ? " " + strenghtCost : strenghtCost)} ║");
                Console.WriteLine($"║[{crossEndurance}]Endurance\t║ {(endurance<10?" "+endurance:endurance)} ║{(enduranceBonus >=0 ? " " + enduranceBonus : enduranceBonus)}  ║ {(endurance + enduranceBonus<10?" "+ (endurance + enduranceBonus): (endurance + enduranceBonus))}  ║{(enduranceCost.ToString().Length == 1 ? "  " + enduranceCost : enduranceCost.ToString().Length == 2 ? " " + enduranceCost : enduranceCost)} ║");
                Console.WriteLine($"║[{crossAgility}]Agilite\t║ {(agility < 10 ? " " + agility : agility)} ║{(agilityBonus >= 0 ? " " + agilityBonus : agilityBonus)}  ║ {(agility + agilityBonus<10?" "+(agility+agilityBonus): (agility + agilityBonus))}  ║{(agilityCost.ToString().Length == 1 ? "  " + agilityCost : agilityCost.ToString().Length == 2 ? " " + agilityCost : agilityCost)} ║");
                Console.WriteLine($"║[{crossLuck}]Chance\t║ {(luck < 10 ? " " + luck : luck)} ║{(luckBonus >= 0 ? " " + luckBonus : luckBonus)}  ║ {(luck + luckBonus < 10 ? " " + (luck + luckBonus) : (luck + luckBonus))}  ║{(luckCost.ToString().Length == 1 ? "  " + luckCost : luckCost.ToString().Length == 2 ? " " + luckCost : luckCost)} ║");
                Console.WriteLine("╚═══════════════╩════╩════╩═════╩════╝");
                Console.WriteLine();
                Console.WriteLine($"utilisez les fléches haut/bas pour sélectioner la caractéristique");
                Console.WriteLine($"utilisez les fléches gauches / droite pour modifier la caractéristique");
                Console.WriteLine("Tapez \"T\" pour terminer");

                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        // cas : fleche a gauche
                        switch (crossPosition)
                        {
                            case 1:
                                if (strenght<=7)
                                {
                                    error = "la force ne peut pas être inférieure à 7";
                                }
                                else
                                {
                                    strenght--;
                                }
                                break;
                            case 2:
                                if (endurance <= 7)
                                {
                                    error = "l'endurance ne peut pas être inférieure à 7";
                                }
                                else
                                {
                                    endurance--;
                                }
                                break;
                            case 3:
                                if (agility <= 7)
                                {
                                    error = "l'agilité ne peut pas être inférieure à 7";
                                }
                                else
                                {
                                    agility--;
                                }
                                break;
                            case 4:
                                if (luck <= 7)
                                {
                                    error = "la chance ne peut pas être inférieure à 7";
                                }
                                else
                                {
                                    luck--;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                // cas : fleche du haut crossPosition = -1, si crossposition =1 alors -0
                        if (crossPosition!=1)
                        {
                            crossPosition--;
                        }
                        
                        break;
                    case ConsoleKey.RightArrow:
                        switch (crossPosition)
                        {
                            case 1:
                                if (strenght >= 18)
                                {
                                    error = "la force ne peut pas être supérieure à 18";
                                }
                                else
                                {
                                    strenght++;
                                }
                                break;
                            case 2:
                                if (endurance >= 18)
                                {
                                    error = "l'endurance ne peut pas être supérieure à 18";
                                }
                                else
                                {
                                    endurance++;
                                }
                                break;
                            case 3:
                                if (agility >= 18)
                                {
                                    error = "l'agilité ne peut pas être supérieure à 18";
                                }
                                else
                                {
                                    agility++;
                                }
                                break;
                            case 4:
                                if (luck >= 18)
                                {
                                    error = "la chance ne peut pas être supérieure à 18";
                                }
                                else
                                {
                                    luck++;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        // cas : fleche du bas crossPosition = +1, si crossposition =4 alors +0
                        if (crossPosition != 4)
                        {
                            crossPosition++;
                        }

                        break;
                    case ConsoleKey.T:
                        if (CP==0 && error=="")
                        {
                        exit = true;
                        }
                        else if (CP>0)
                        {
                            error = "il vous reste " + CP + " points à dépenser";
                        }
                        break;
                    default:
                        break;
                }


                // on recalcule le cout de chaque caractéristique
                strenghtCost = CostCalcul(strenght);
                enduranceCost = CostCalcul(endurance);
                agilityCost = CostCalcul(agility);
                luckCost = CostCalcul(luck);

                // déplacement de la croix qui détermine sur quelle carac on joue
                switch (crossPosition)
                {
                    case 2:
                        crossStrenght = " ";
                        crossEndurance = "X";
                        crossAgility = " ";
                        crossLuck = " ";
                        break;
                    case 3:
                        crossStrenght = " ";
                        crossEndurance = " ";
                        crossAgility = "X";
                        crossLuck = " ";
                        break;
                    case 4:
                        crossStrenght = " ";
                        crossEndurance = " ";
                        crossAgility = " ";
                        crossLuck = "X";
                        break;
                    default:
                        crossStrenght = "X";
                        crossEndurance = " ";
                        crossAgility = " ";
                        crossLuck = " ";
                        break;

                }

            } while (!exit); // exit est vrai si la touche T est pressée et qu'il n'y a pas d'erreurs

            // retourner le personnage


            switch (race)
            {
                case "Nain":
                    return new Dwarf(name);
                    break;
                case "Elfe":
                    return new Elf(name);
                    break;
                case "Halfelin":
                    return new Halflin(name);
                    break;
                default:
                    return new Human(name);
                    break;
            }



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
