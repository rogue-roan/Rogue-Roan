using Microsoft.VisualBasic;
using Rogue_Roan.Models;
using Rogue_Roan.Models.Ennemies;
using Rogue_Roan.Models.PlayerRaces;
//Console.OutputEncoding = System.Text.Encoding.UTF8;

namespace Rogue_Roan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dwarf Gimli = new Dwarf("Gimli");
            //Orc Tapdur = new Orc("Tapdur");

            //Console.WriteLine(Gimli.ToString());
            //Console.WriteLine();

            //Console.WriteLine(Tapdur.ToString());
            //Console.WriteLine();

            //Game.Game.Fight(Gimli, Tapdur);

            Player player = Game.Game.CreateHero();
            //Console.WriteLine(player.ToString());

            //Console.WriteLine("Appuyez sur une touche...");
            //var key = Console.ReadKey();
            //Console.WriteLine($"Code de la touche : {key.Key}");


            //Console.WriteLine("TEST");
            //Console.WriteLine("haut ↑");
            //Console.WriteLine("bas ↓");
            //Console.WriteLine("gauche ←");
            //Console.WriteLine("droite →");

            //for (int i = 0; i < 300; i++)
            //{
            //Console.Write(Strings.ChrW(205));

            //}

            //Console.Write(Strings.ChrW(2191));




        }
    }
}