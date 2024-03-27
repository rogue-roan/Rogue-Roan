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

            startingRoom = new Room(true);
            DonjonRooms.Add(startingRoom, new RoomPosition());

            Dictionary<RoomPosition, WallAttribute> howToCompleteLevel = ToValidate();

            while(!IsValid())
            {
                foreach (RoomPosition position in howToCompleteLevel.Keys)
                {
                    Room nextRoom = null;

                    WallAttribute opposite = WallAttribute.None;
                    if (howToCompleteLevel[position].HasFlag(WallAttribute.NorthDoor)) opposite = WallAttribute.SouthDoor;
                    else if (howToCompleteLevel[position].HasFlag(WallAttribute.SouthDoor)) opposite = WallAttribute.NorthDoor;
                    else if (howToCompleteLevel[position].HasFlag(WallAttribute.WestDoor)) opposite = WallAttribute.EastDoor;
                    else if (howToCompleteLevel[position].HasFlag(WallAttribute.EastDoor)) opposite = WallAttribute.WestDoor;

                    else if (howToCompleteLevel[position].HasFlag(WallAttribute.NorthOpening)) opposite = WallAttribute.SouthOpening;
                    else if (howToCompleteLevel[position].HasFlag(WallAttribute.SouthOpening)) opposite = WallAttribute.NorthOpening;
                    else if (howToCompleteLevel[position].HasFlag(WallAttribute.WestOpening)) opposite = WallAttribute.EastOpening;
                    else if (howToCompleteLevel[position].HasFlag(WallAttribute.EastOpening)) opposite = WallAttribute.WestOpening;

                    nextRoom = new Room(DonjonRooms.Keys.Count < minNumberOfRoom, opposite);
                    // Must be change for each orientation of each room

                    RoomPosition futurPosition = null;
                    if (opposite.HasFlag(WallAttribute.NorthDoor) || opposite.HasFlag(WallAttribute.NorthOpening))
                        futurPosition = new RoomPosition(position.TopOrigin + nextRoom.Height, position.LeftOrigin);
                    else if (opposite.HasFlag(WallAttribute.SouthDoor) || opposite.HasFlag(WallAttribute.SouthOpening))
                        futurPosition = new RoomPosition(position.TopOrigin - nextRoom.Height, position.LeftOrigin);
                    else if (opposite.HasFlag(WallAttribute.WestDoor) || opposite.HasFlag(WallAttribute.WestOpening))
                        futurPosition = new RoomPosition(position.TopOrigin, position.LeftOrigin + nextRoom.Width);
                    else if (opposite.HasFlag(WallAttribute.EastDoor) || opposite.HasFlag(WallAttribute.EastOpening))
                        futurPosition = new RoomPosition(position.TopOrigin, position.LeftOrigin - nextRoom.Width);

                    if (futurPosition is not null)
                    {
                        if(DonjonRooms.Values.Where(position => position.Equals(futurPosition)).Count() > 0)
                        {
                            Room room = GetRoomWithThisPosition(futurPosition.TopOrigin, futurPosition.LeftOrigin);
                            
                            room.ReBuild(opposite);
                        }
                        else DonjonRooms.Add(nextRoom, futurPosition);
                    }
                }

                howToCompleteLevel = ToValidate();
            }

            normalizePosition();
        }

        /// <summary>
        /// Change position so there is only positive position
        /// And the lowest value possible
        /// </summary>
        private void normalizePosition()
        {
            int? minLine = null, minRow = null;
            foreach(Room room in DonjonRooms.Keys)
            {
                if (minLine is null || DonjonRooms[room].TopOrigin < minLine) minLine = DonjonRooms[room].TopOrigin;
                if (minRow is null || DonjonRooms[room].LeftOrigin < minRow) minRow = DonjonRooms[room].LeftOrigin;
            }

            if((minLine != 0 || minRow != 0 ) && minLine is not null && minRow is not null)
            {
                foreach (Room room in DonjonRooms.Keys)
                {
                    DonjonRooms[room] = new RoomPosition(DonjonRooms[room].TopOrigin - minLine.Value, DonjonRooms[room].LeftOrigin - minRow.Value);
                }
            }
        }
        
        /// <summary>
        /// This function will indicate if all opening and door of each room are connected to something
        /// </summary>
        /// <returns>true if valid</returns>
        public bool IsValid()
        {
            return ToValidate().Keys.Count() < 1;
        }
        /// <summary>
        /// This function will change
        /// </summary>
        /// <returns></returns>
        public Dictionary<RoomPosition, WallAttribute> ToValidate()
        {
            List<RoomPosition> doorN = new List<RoomPosition>();
            List<RoomPosition> doorS = new List<RoomPosition>();
            List<RoomPosition> doorW = new List<RoomPosition>();
            List<RoomPosition> doorE = new List<RoomPosition>();

            List<RoomPosition> openingN = new List<RoomPosition>();
            List<RoomPosition> openingS = new List<RoomPosition>();
            List<RoomPosition> openingW = new List<RoomPosition>();
            List<RoomPosition> openingE = new List<RoomPosition>();

            // Loop in all room currently in this level
            foreach (Room roomInDl in this.DonjonRooms.Keys)
            {
                // each iteration :
                // check a case about one of his possible wall attribute (for example a door to his north wall)
                // if ok, take the origin position of the room to find the door/opening position
                // check if there is a possible door/opening next (opposite wall and with a good poistion)
                // if this candidate exists, we can remove it
                // if not, we can store the position of this door/opening for later

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

                    RoomPosition? northCandidate = openingN.Find(roomPosition => (roomPosition.LeftOrigin == pointOfTheOpening.LeftOrigin && roomPosition.TopOrigin - 1 == pointOfTheOpening.TopOrigin));

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

            // Pull out what is needed to complete this level
            Dictionary<RoomPosition, WallAttribute> toValidate = new Dictionary<RoomPosition, WallAttribute>();

            if (doorN.Count() > 0) fillValidate(toValidate, doorN, WallAttribute.NorthDoor);
            if (doorS.Count() > 0) fillValidate(toValidate, doorS, WallAttribute.SouthDoor);
            if (doorW.Count() > 0) fillValidate(toValidate, doorW, WallAttribute.WestDoor);
            if (doorE.Count() > 0) fillValidate(toValidate, doorE, WallAttribute.EastDoor);

            if (openingN.Count() > 0) fillValidate(toValidate, openingN, WallAttribute.NorthOpening);
            if (openingS.Count() > 0) fillValidate(toValidate, openingS, WallAttribute.SouthOpening);
            if (openingW.Count() > 0) fillValidate(toValidate, openingW, WallAttribute.WestOpening);
            if (openingE.Count() > 0) fillValidate(toValidate, openingE, WallAttribute.EastOpening);

            return toValidate;
        }
        private void fillValidate (Dictionary<RoomPosition, WallAttribute> dictionnary, List<RoomPosition> positions, WallAttribute wallType)
        {
            foreach (RoomPosition position in positions)
            {
                Room? room = GetRoomWithThisPosition(position.TopOrigin, position.LeftOrigin);
                if (room is not null)
                {
                    //if (dictionnary.ContainsKey(DonjonRooms[room])) dictionnary[DonjonRooms[room]] |= wallType;
                    //else dictionnary.Add(DonjonRooms[room], wallType);
                    if (!dictionnary.ContainsKey(DonjonRooms[room])) dictionnary.Add(DonjonRooms[room], wallType);
                }
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
            Console.WriteLine($"This dunjeon is {(IsValid() ? "Valid":"not Valid")}");
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
                        canvas[DonjonRooms[roomInDl].TopOrigin + i][DonjonRooms[roomInDl].LeftOrigin + j] = roomInDl.Content[i][j] == " "? " ": roomInDl.Content[i][j];
                    }
                }
            }

            return canvas;
        }
        
        public Room? GetRoomWithThisPosition(int line, int row)
        {
            foreach(Room roomInThisLevel in DonjonRooms.Keys)
            {
                int firstLine = DonjonRooms[roomInThisLevel].TopOrigin, lastLine = firstLine + roomInThisLevel.Height - 1;
                int firstRow = DonjonRooms[roomInThisLevel].LeftOrigin, lastRow = firstRow + roomInThisLevel.Width - 1;

                if(line >= firstLine && line <= lastLine &&
                    row >= firstRow && row <= lastRow)
                {
                    return roomInThisLevel;
                }
            }
            return null;
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
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            else if (obj.GetType() != typeof(RoomPosition)) return false;
            else if (((RoomPosition)obj).TopOrigin != this.TopOrigin || ((RoomPosition)obj).LeftOrigin != this.LeftOrigin) return false;
            return true;
        }
    }
}
