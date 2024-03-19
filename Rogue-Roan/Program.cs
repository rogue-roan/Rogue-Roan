namespace Rogue_Roan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int roomHeight = 100;
            int roomWidth = 100;

            int[] roomSize = { 100, 100 };


            for (int i = 0; i < roomSize[1]; i++)
            {
                Console.Write('-');
                for (int j = 0; j < roomSize[0]; j++)
                {
                    Console.Write('|');
                }
            }

        }
    }
}