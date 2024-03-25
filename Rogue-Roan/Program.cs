using Rogue_Roan.Models;
using Rogue_Roan.Models.Ennemies;
using Rogue_Roan.Models.PlayerRaces;

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
            Console.WriteLine(player.ToString());







        }
    }
}