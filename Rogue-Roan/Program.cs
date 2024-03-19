using Rogue_Roan.Model.Mapping;

namespace Rogue_Roan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonLevel dl = new DungeonLevel(10);

            dl.DisplayDetail();
        }
    }
}