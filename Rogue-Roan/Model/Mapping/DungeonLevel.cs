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

        public DungeonLevel()
        {
            DonjonRooms.Add(new Room(), new RoomPosition { TopOrigin = 0, LeftOrigin = 0 });
        }

        #region Debug Function
        public void DisplayDetail()
        {
            foreach (Room roomInDl in this.DonjonRooms.Keys)
            {
                Console.WriteLine($"{roomInDl} en position : {this.DonjonRooms.GetValueOrDefault(roomInDl).LeftOrigin}, {this.DonjonRooms.GetValueOrDefault(roomInDl).TopOrigin}");
            }
        }
        
    #endregion
}
    public struct RoomPosition
    {
        // Corner Top Left
        public int TopOrigin { get; set; }
        public int LeftOrigin { get; set; }
    }
}
