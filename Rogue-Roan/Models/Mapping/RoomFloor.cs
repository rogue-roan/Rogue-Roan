using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Mapping
{
    internal class RoomFloor
    {
        int width = RoomDecoration.roomHeight;
        int height = RoomDecoration.roomWidth;

        List<int[]> floorMap = new List<int[]>();


        public List<int[]> generateRandomFloor()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Random rnd = new Random();
                    int choice = rnd.Next(0, 5);
                    if (choice == 1)
                    {
                        floorMap.Add(new int[] {y,x});
                    }
                }
            }
            return floorMap;
        }
    }
}
