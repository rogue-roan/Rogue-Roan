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

        public int Height { get; set; }

        public int Width { get; set; }

        public Room()
        {
            Height = 10;
            Width = 10;
            WallAtribute = WallAttribute.None;
        }
        #region Debug Function
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
