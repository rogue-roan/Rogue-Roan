using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Model.Mapping
{
    public class DungeonLevel
    {
        public Dictionary<Room, RoomPosition> DonjonRooms = new Dictionary<Room, RoomPosition>();

        public DungeonLevel(uint minNumberOfRoom = 5)
        {
            if (minNumberOfRoom == 0) minNumberOfRoom = 5;

            for(int i = 0; i < minNumberOfRoom; i++)
            {
                DonjonRooms.Add(new Room(), new RoomPosition());
            }
        }

        #region Debug Function
        /// <summary>
        /// Function de debug of the dictionnary of all room of this specific dunjeon level
        /// </summary>
        public void DisplayDetail()
        {
            foreach (Room roomInDl in this.DonjonRooms.Keys)
            {
                Console.WriteLine($"{roomInDl} en position : {this.DonjonRooms.GetValueOrDefault(roomInDl).LeftOrigin}, {this.DonjonRooms.GetValueOrDefault(roomInDl).TopOrigin}");
            }
        }
        
    #endregion
}
    public class RoomPosition
    {
        // Corner Top Left
        public int TopOrigin { get; set; }
        public int LeftOrigin { get; set; }

        public RoomPosition(int top = 1, int left = 1) 
        {
            TopOrigin = top;
            LeftOrigin = left;
        }
    }
}
