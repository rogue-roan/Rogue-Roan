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

        public Room startingRoom { get; set; }

        public DungeonLevel(uint minNumberOfRoom = 5)
        {
            if (minNumberOfRoom == 0) minNumberOfRoom = 5;

            startingRoom = new Room(false, WallAttribute.EastOpening);
            DonjonRooms.Add(startingRoom, new RoomPosition());

            DonjonRooms.Add(new Room(false, WallAttribute.WestOpening), new RoomPosition(0,10));
            /*for (int i = 0; i < minNumberOfRoom - 1; i++)
            {
            }/**/
        }
        
        /// <summary>
        /// This function will indicate if all opening and door of each room are connected to something
        /// 
        /// TODO Complete this function
        /// </summary>
        /// <returns>true if valid</returns>
        public bool isValid()
        {
            return ToValidate() == WallAttribute.None ? true : false;
        }

        private WallAttribute ToValidate()
        {
            List<RoomPosition> doorN = new List<RoomPosition>();
            List<RoomPosition> doorS = new List<RoomPosition>();
            List<RoomPosition> doorW = new List<RoomPosition>();
            List<RoomPosition> doorE = new List<RoomPosition>();

            List<RoomPosition> openingN = new List<RoomPosition>();
            List<RoomPosition> openingS = new List<RoomPosition>();
            List<RoomPosition> openingW = new List<RoomPosition>();
            List<RoomPosition> openingE = new List<RoomPosition>();

            foreach (Room roomInDl in this.DonjonRooms.Keys)
            {
                if (roomInDl.HasThisWallAttribute(WallAttribute.NorthDoor))
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheWall = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheWall.LeftOrigin += roomInDl.Width / 2;

                    RoomPosition? southCandidate = doorS.Find(roomPosition => (roomPosition.LeftOrigin == pointOfTheWall.LeftOrigin && roomPosition.TopOrigin + 1 == pointOfTheWall.TopOrigin));

                    if (southCandidate is null) doorN.Add(pointOfTheWall);
                    else doorS.Remove(southCandidate);
                }
                else if (roomInDl.HasThisWallAttribute(WallAttribute.NorthOpening))
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheOpening = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheOpening.LeftOrigin += roomInDl.Width / 2;

                    RoomPosition? southCandidate = openingS.Find(roomPosition => (roomPosition.LeftOrigin == pointOfTheOpening.LeftOrigin && roomPosition.TopOrigin + 1 == pointOfTheOpening.TopOrigin));

                    if (southCandidate is null) openingN.Add(pointOfTheOpening);
                    else openingS.Remove(southCandidate);
                }

                if (roomInDl.HasThisWallAttribute(WallAttribute.SouthDoor))
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheWall = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheWall.LeftOrigin += roomInDl.Width / 2;
                    pointOfTheWall.TopOrigin += roomInDl.Height - 1;

                    RoomPosition? northCandidate = doorN.Find(roomPosition => (roomPosition.LeftOrigin == pointOfTheWall.LeftOrigin && roomPosition.TopOrigin - 1 == pointOfTheWall.TopOrigin));
                    
                    if (northCandidate is null) doorS.Add(pointOfTheWall);
                    else doorN.Remove(northCandidate);
                }
                else if (roomInDl.HasThisWallAttribute(WallAttribute.SouthOpening)) 
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheOpening = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheOpening.LeftOrigin += roomInDl.Width / 2;
                    pointOfTheOpening.TopOrigin += roomInDl.Height - 1;

                    RoomPosition? northCandidate = openingS.Find(roomPosition => (roomPosition.LeftOrigin == pointOfTheOpening.LeftOrigin && roomPosition.TopOrigin - 1 == pointOfTheOpening.TopOrigin));

                    if (northCandidate is null) openingS.Add(pointOfTheOpening);
                    else openingN.Remove(northCandidate);
                }

                if (roomInDl.HasThisWallAttribute(WallAttribute.EastDoor))
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheWall = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheWall.TopOrigin += roomInDl.Height / 2;
                    pointOfTheWall.LeftOrigin += roomInDl.Width - 1;

                    RoomPosition? westCandidate = doorW.Find(roomPosition => (roomPosition.LeftOrigin - 1 == pointOfTheWall.LeftOrigin && roomPosition.TopOrigin == pointOfTheWall.TopOrigin));

                    if (westCandidate is null) doorE.Add(pointOfTheWall);
                    else doorW.Remove(westCandidate);
                }
                else if (roomInDl.HasThisWallAttribute(WallAttribute.EastOpening))
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheOpening = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheOpening.LeftOrigin += roomInDl.Width - 1;
                    pointOfTheOpening.TopOrigin += roomInDl.Height / 2;

                    RoomPosition? westCandidate = openingW.Find(roomPosition => (roomPosition.LeftOrigin - 1 == pointOfTheOpening.LeftOrigin && roomPosition.TopOrigin == pointOfTheOpening.TopOrigin));

                    if (westCandidate is null) openingE.Add(pointOfTheOpening);
                    else openingW.Remove(westCandidate);
                }

                if (roomInDl.HasThisWallAttribute(WallAttribute.WestDoor))
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheWall = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheWall.TopOrigin += roomInDl.Height / 2;

                    RoomPosition? eastCandidate = doorE.Find(roomPosition => (roomPosition.LeftOrigin + 1 == pointOfTheWall.LeftOrigin && roomPosition.TopOrigin == pointOfTheWall.TopOrigin));

                    if (eastCandidate is null) doorW.Add(pointOfTheWall);
                    else doorE.Remove(eastCandidate);
                }
                else if (roomInDl.HasThisWallAttribute(WallAttribute.WestOpening))
                {
                    RoomPosition originOfThisRoom = DonjonRooms[roomInDl];

                    RoomPosition pointOfTheOpening = (RoomPosition)originOfThisRoom.Clone();
                    pointOfTheOpening.TopOrigin += roomInDl.Height / 2;

                    RoomPosition? eastCandidate = openingE.Find(roomPosition => (roomPosition.LeftOrigin + 1 == pointOfTheOpening.LeftOrigin && roomPosition.TopOrigin == pointOfTheOpening.TopOrigin));

                    if (eastCandidate is null) openingW.Add(pointOfTheOpening);
                    else openingE.Remove(eastCandidate);
                }
            }

            // conditionnal 2 : room position (room overlapsed)
            // conditionnal 3 : doors connected

            WallAttribute attribute = WallAttribute.None;

            if (doorN.Count() > 0) attribute |= WallAttribute.SouthDoor; 
            if (doorS.Count() > 0) attribute |= WallAttribute.NorthDoor;

            if (doorE.Count() > 0) attribute |= WallAttribute.WestDoor;
            if (doorW.Count() > 0) attribute |=  WallAttribute.EastDoor;

            if (openingN.Count() > 0) attribute |= WallAttribute.SouthOpening;
            if (openingS.Count() > 0) attribute |= WallAttribute.NorthOpening;

            if (openingE.Count() > 0) attribute |= WallAttribute.WestOpening;
            if (openingW.Count() > 0) attribute |= WallAttribute.EastOpening;

            return attribute;
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

        public string[][] DrawLevel()
        {
            // size of the level
            int widthLevel = 0, heightLevel = 0;
            foreach (Room roomInDl in this.DonjonRooms.Keys)
            {
                if (DonjonRooms[roomInDl].TopOrigin + roomInDl.Height > heightLevel) heightLevel = DonjonRooms[roomInDl].TopOrigin + roomInDl.Height;
                if (DonjonRooms[roomInDl].LeftOrigin + roomInDl.Width > widthLevel) widthLevel = DonjonRooms[roomInDl].LeftOrigin + roomInDl.Width;
            }

            // initialization of the level canvas
            string[][] canvas = new string[heightLevel][];
            for(int i = 0; i < canvas.GetLength(0); i++)
            {
                canvas[i] = new string[widthLevel];
                for(int j = 0; j < canvas[i].GetLength(0); j++)
                {
                    canvas[i][j] = " ";
                }
            }

            //took all room content and put it in the canvas
            foreach (Room roomInDl in this.DonjonRooms.Keys)
            {
                for(int i = 0; i < roomInDl.Content.GetLength(0); i++)
                {
                    for (int j = 0; j < roomInDl.Content[i].GetLength(0); j++)
                    {
                        canvas[DonjonRooms[roomInDl].TopOrigin + i][DonjonRooms[roomInDl].LeftOrigin + j] = roomInDl.Content[i][j] == " "? ".": roomInDl.Content[i][j];
                    }
                }
            }

            return canvas;
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
