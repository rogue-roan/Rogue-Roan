using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Mapping
{
    internal class RoomType
    {
        public class WaterRoom
        {
            public static int[][] water = new int[10][];
            public string color = "blue";

            public WaterRoom()            
            {
                water[0] = new int[] { 2, 2 };
                water[1] = new int[] { 2, 3 };
                water[2] = new int[] { 3, 2 };
                water[3] = new int[] { 3, 3 };

                water[4] = new int[] { 2, 7 };
                water[5] = new int[] { 2, 8 };
                water[6] = new int[] { 3, 7 };
                water[7] = new int[] { 3, 8 };

                water[8] = new int[] { 7, 2 };
                water[9] = new int[] { 7, 3 };
                water[10] = new int[] { 8, 2 };
                water[11] = new int[] { 8, 3 };

                water[12] = new int[] { 7, 7 };
                water[13] = new int[] { 7, 8 };
                water[14] = new int[] { 8, 7 };
                water[15] = new int[] { 8, 8 };
            }
            public int[][] getWaterRoom()
            {
                return water;
            }
        }
    }
    public class forestRoom
    {

    }
    
}
