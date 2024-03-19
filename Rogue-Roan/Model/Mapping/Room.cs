using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Model.Mapping
{
    public class Room
    {
        private WallAttribute _wallAtribute;

        public WallAttribute WallAtribute
        {
            get { return _wallAtribute; }
            set { _wallAtribute = value; }
        }

        // Dimension without Walls
        public int Height { get; set; }
        public int Width { get; set; }

        public Room()
        {
            Height = 10;
            Width = 10;
            WallAtribute = WallAttribute.NorthOpening;
        }
        public WallAttribute randomWallAttribute()
        {
            Random random = new Random();

            int doors = random.Next(0, 16);

            int opening = random.Next(16, 257);
            if (opening == 256) opening = 0;

            return (WallAttribute)(((doors & (opening >> 4))) | opening);
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

    [Flags]
    public enum WallAttribute : int
    { 
        None = 0,
        // Doors
        NorthDoor = 1,
        WestDoor = 2,
        SouthDoor = 4,
        EastDoor = 8,
        // Openings
        NorthOpening = 16,
        WestOpening = 32,
        SouthOpening = 64,
        EastOpening = 128
    }
}
