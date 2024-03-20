namespace Rogue_Roan.Model.Mapping
{
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
