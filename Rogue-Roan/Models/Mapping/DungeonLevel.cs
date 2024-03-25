using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Roan.Enums.Mapping;

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
                DonjonRooms.Add(new Room(randomGeneration : true, WallAttribute.NorthDoor), new RoomPosition());
            }
        }
        
        /// <summary>
        /// This function will indicate if all opening and door of each room are connected to something
        /// 
        /// TODO Complete this function
        /// </summary>
        /// <returns>true if valid</returns>
        public bool isValid()
        {
            // index about number of door without connection
            int doorY = 0, doorX = 0;
            // index about number of opening without connection
            int openingY = 0, openingX = 0;

            foreach (Room roomInDl in this.DonjonRooms.Keys)
            {
                if (roomInDl.HasThisWallAttribute(WallAttribute.NorthDoor)) doorY++;
                else if (roomInDl.HasThisWallAttribute(WallAttribute.NorthOpening)) openingY++;

                if (roomInDl.HasThisWallAttribute(WallAttribute.SouthDoor)) doorY--;
                else if (roomInDl.HasThisWallAttribute(WallAttribute.SouthOpening)) openingY--;

                if (roomInDl.HasThisWallAttribute(WallAttribute.EastDoor)) doorX++;
                else if (roomInDl.HasThisWallAttribute(WallAttribute.EastOpening)) openingX++;

                if (roomInDl.HasThisWallAttribute(WallAttribute.WestDoor)) doorX--;
                else if (roomInDl.HasThisWallAttribute(WallAttribute.WestOpening)) openingX--;
            }

            // conditionnal 2 : room position (room overlapsed)
            // conditionnal 3 : doors connected

            if (doorY == 0 && openingY == 0) return true;
            return false;
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
            Console.WriteLine($"This dunjeon is {(isValid() ? "Valid":"not Valid")}");
        }
        
    #endregion
}
    public class RoomPosition : ICloneable
    {
        // Corner Top Left
        public int TopOrigin { get; set; }
        public int LeftOrigin { get; set; }

        public RoomPosition(int top = 0, int left = 0) 
        {
            TopOrigin = top;
            LeftOrigin = left;
        }

        public object Clone()
        {
            return new RoomPosition(top:TopOrigin, left:LeftOrigin);
        }
    }
}
