using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rogue_Roan.Enums.Mapping;

namespace Rogue_Roan.Model.Mapping
{
    public class Room
    {
        // How is this room is defined ? 
        // doors north ? full opened ?
        private WallAttribute _wallAtribute;

        public WallAttribute WallAtribute
        {
            get { return _wallAtribute; }
            set { _wallAtribute = value; }
        }

        // Wall included
        public int Height { get; set; }
        public int Width { get; set; }

        // What is in this room (wall included)
        private string[][] _content;

        public string[][] Content
        {
            get { return _content; }
            private set { _content = value; }
        }

        /// <summary>
        /// Constructor of a room
        /// </summary>
        /// <param name="randomGeneration">is Room generation from a random value for all his doors and openings ?</param>
        /// <param name="constraint">constraint for some or all wall</param>
        public Room(bool randomGeneration = true, WallAttribute constraint = ~WallAttribute.None)
        {
            Height = 10;
            Width = 10;
            if (randomGeneration) WallAtribute = randomWallAttribute(constraint);
            else WallAtribute = constraint;

            Content = DrawRoom();
        }

        /// <summary>
        /// Function of generation in a random way
        /// </summary>
        /// /// <param name="constraint">first wallAttributed wanted</param>
        /// <returns>Combinaison of wall attribute</returns>
        public WallAttribute randomWallAttribute(WallAttribute constraint = ~WallAttribute.None)
        {
            Random random = new Random();
            
            // remind :
            // 0 =>  0000
            // 15 => 1111
            int doors = random.Next(0, 16);

            int opening = random.Next(0, 16);
            opening = (int)((WallAttribute)opening & ~constraint);

            // rule opening > door
            doors = doors & ~opening;

            //opening is 4 bit highter
            // 00001 => 10000
            opening <<= 4;

            return constraint | (~constraint & (WallAttribute)(doors | opening));
        }

        /// <summary>
        /// In this function, this room gain is wall from his WallAtribute
        /// In the futur, It will also have some decoration
        /// </summary>
        /// <returns></returns>
        public string[][] DrawRoom()
        {
            // initialisation
            string[][] room = new string[Height][];
            for(int i = 0; i < room.GetLength(0); i++)
            {
                room[i] = new string[Width];
                for(int j = 0; j < room[i].GetLength(0); j++)
                {
                    room[i][j] = " ";
                }
            }

            PutSomeWall(room);


            return room;
        }
        private void PutSomeWall(string[][] room)
        {

            // put some wall
            for (int i = 0; i < room.GetLength(0); i++)
            {
                for (int j = 0; j < room[i].GetLength(0); j++)
                {
                    // lines
                    // first line
                    if (i == 0)
                    {
                        if (HasThisWallAttribute(WallAttribute.NorthOpening))
                        {
                            if ((!HasThisWallAttribute(WallAttribute.WestOpening) && j == 0) ||
                                (!HasThisWallAttribute(WallAttribute.EastOpening) && j == room[i].GetLength(0) - 1))
                            {
                                DrawWall(room, i, j);
                            }
                        }
                        else if (HasThisWallAttribute(WallAttribute.NorthDoor))
                        {
                            if (j != room[i].GetLength(0) / 2)
                                DrawWall(room, i, j);
                        }
                        else
                        {
                            DrawWall(room, i, j);
                        }
                    }
                    // last line
                    if (i == room.GetLength(0) - 1)
                    {
                        if (HasThisWallAttribute(WallAttribute.SouthOpening))
                        {
                            if ((!HasThisWallAttribute(WallAttribute.WestOpening) && j == 0) ||
                                (!HasThisWallAttribute(WallAttribute.EastOpening) && j == room[i].GetLength(0) - 1))
                            {
                                DrawWall(room, i, j);
                            }
                        }
                        else if (HasThisWallAttribute(WallAttribute.SouthDoor))
                        {
                            if (j != room[i].GetLength(0) / 2)
                                DrawWall(room, i, j);
                        }
                        else
                        {
                            DrawWall(room, i, j);
                        }
                    }

                    // columns
                    // first column
                    if (j == 0)
                    {
                        if (HasThisWallAttribute(WallAttribute.WestOpening))
                        {
                            if ((!HasThisWallAttribute(WallAttribute.NorthOpening) && i == 0) ||
                                (!HasThisWallAttribute(WallAttribute.SouthOpening) && i == room[i].GetLength(0) - 1))
                            {
                                DrawWall(room, i, j);
                            }
                        }
                        else if (HasThisWallAttribute(WallAttribute.WestDoor))
                        {
                            if (i != room[i].GetLength(0) / 2)
                                DrawWall(room, i, j);
                        }
                        else
                        {
                            DrawWall(room, i, j);
                        }
                    }
                    // last column
                    if (j == room.GetLength(0) - 1)
                    {
                        if (HasThisWallAttribute(WallAttribute.EastOpening))
                        {
                            if ((!HasThisWallAttribute(WallAttribute.NorthOpening) && i == 0) ||
                                (!HasThisWallAttribute(WallAttribute.SouthOpening) && i == room[i].GetLength(0) - 1))
                            {
                                DrawWall(room, i, j);
                            }
                        }
                        else if (HasThisWallAttribute(WallAttribute.EastDoor))
                        {
                            if (i != room[i].GetLength(0) / 2)
                                DrawWall(room, i, j);
                        }
                        else
                        {
                            DrawWall(room, i, j);
                        }
                    }
                }
            }
        }
        private void DrawWall(string[][] room, int line, int row)
        {
            room[line][row] = "=";
        }

        public void ReBuild(WallAttribute newAttribute)
        {
            this.WallAtribute |= newAttribute;

            Content = DrawRoom();
            //PutSomeWall(Content);
        }
        #region Debug Function
        /// <summary>
        /// Function that return if this room has this attribute
        /// </summary>
        /// <param name="wallAttribute">Wall attribute to check</param>
        /// <returns>Presence of this attribute</returns>
        public bool HasThisWallAttribute(WallAttribute wallAttribute)
        {
            return this.WallAtribute.HasFlag(wallAttribute);
        }
        public override string ToString()
        {
            return $"type de piéce : { this.WallAtribute }, largeur: { this.Width }, hauteur: { this.Height }";
        }
        #endregion
    }

    
}
