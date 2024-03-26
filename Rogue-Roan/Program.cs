using Rogue_Roan.Enums.Mapping;
using Rogue_Roan.Model.Mapping;
using Rogue_Roan.Models.Mapping;
using System.Text;

namespace Rogue_Roan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create dunjeon
            DungeonLevel dl = new DungeonLevel(10);

            // display his composition
            dl.DisplayDetail();

            //display each room of the dunjeon
            Console.ReadLine();
            foreach (Room roomInDl in dl.DonjonRooms.Keys)
            {
                Console.Clear();

                Console.WriteLine($"{roomInDl} en position : {dl.DonjonRooms.GetValueOrDefault(roomInDl).LeftOrigin}, {dl.DonjonRooms.GetValueOrDefault(roomInDl).TopOrigin}");

                string[][] room = roomInDl.DrawRoom();

                for (int i = 0; i < room.GetLength(0); i++)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int j = 0; j < room[i].GetLength(0); j++)
                    {
                        sb.Append(room[i][j]);
                    }
                    Console.WriteLine(sb.ToString());
                }

                Console.ReadLine();
            }


            // Antoine Stuff
            RoomDecoration roomD = new RoomDecoration();
            WallAttribute wallE = WallAttribute.None;
            roomD.DecorateRoom(wallE);
        }
    }
}