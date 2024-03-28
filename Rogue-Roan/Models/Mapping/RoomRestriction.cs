using Rogue_Roan.Model.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Mapping
{
    public class RoomRestriction
    {
        /// <summary>
        /// Création d'un chemin en forme de croix où le décor ne pourra pas etre posé.
        /// </summary>
        /// <param name="crossRoad">est un tableau de coordonées</param>

        private List<int[]> crossRoad = new List<int[]>();

        public List<int[]> crossRoadAssignation()
        {
            // Ligne vertical. i commence à 1 car les position en 0 concernent les portes qui me seront fournie
            for (int i = 1; i < RoomDecoration.roomWidth; i++)
            {
                crossRoad.Add(new int [] { i, RoomDecoration.roomWidth / 2 });
            }
            //Ligne horizontale. i commence à 1 car les position en 0 concerne les portes qui me seront fournie
            for (int i = 1; i < RoomDecoration.roomHeight; i++)
            {
                crossRoad.Add(new int[] { RoomDecoration.roomHeight / 2, i });
            }
            // Affichage des coordonnées
            foreach (var position in crossRoad)
            {
                Console.WriteLine($"Position: ({position[0]}, {position[1]})");
            }
            return crossRoad;
        }
   

        /// <summary>
        /// Création d'un chemin longeant les murs où le décor ne pourra pas etre posé.
        /// </summary>
        /// <param name="wallRoad">est un tableau de coordonées</param>

        int countWall = 0;
        public int[][] wallRoad = new int[(RoomDecoration.roomWidth-2)*2 + (RoomDecoration.roomHeight-2)*2][];
        public int[][] WallRoadAssignation()
        {
            //Console.WriteLine(RoomDecoration.roomWidth);
            //// Long du mur nord
            //for (int i = 1; i < RoomDecoration.roomWidth; i++)
            //{
            //    wallRoad[countWall] = new int[] { 1, i }; //Remplacer le 1 par une formule?
            //}
            //// Long du mur sud
            //for (int i = 1; i < RoomDecoration.roomWidth; i++)
            //{
            //    wallRoad[countWall] = new int[] { RoomDecoration.roomWidth-1, i };
            //}
            //// Long du mur ouest
            //for (int i = 2; i < RoomDecoration.roomHeight-2; i++)
            //{
            //    wallRoad[countWall] = new int[] { i, 1 };
            //}
            //// Long du mur est
            //for (int i = 2; i < RoomDecoration.roomHeight-2; i++)
            //{
            //    wallRoad[countWall] = new int[] { i, RoomDecoration.roomWidth-1 };
            //}
            //foreach (var position in wallRoad)
            //{
            //    Console.WriteLine($"Position: ({position[0]}, {position[1]})");
            //}



            // Long du mur nord
            for (int i = 1; i < RoomDecoration.roomWidth - 1; i++)
            {
                wallRoad[countWall] = new int[] { i, 1 };
                countWall++;
            }

            // Long du mur sud
            for (int i = 1; i < RoomDecoration.roomWidth - 1; i++)
            {
                wallRoad[countWall] = new int[] { i, RoomDecoration.roomHeight - 2 };
                countWall++;
            }

            // Long du mur ouest
            for (int i = 2; i < RoomDecoration.roomHeight - 2; i++)
            {
                wallRoad[countWall] = new int[] { 1, i };
                countWall++;
            }

            // Long du mur est
            for (int i = 2; i < RoomDecoration.roomHeight - 2; i++)
            {
                wallRoad[countWall] = new int[] { RoomDecoration.roomWidth - 2, i };
                countWall++;
            }
            // Affichage des coordonnées
            foreach (var position in crossRoad)
            {
                Console.WriteLine($"Position: ({position[0]}, {position[1]})");
            }
            return wallRoad;
        }

    }
}
