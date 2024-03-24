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

        public int[][] crossRoad = new int[RoomDecoration.roomWidth+RoomDecoration.roomHeight-4][];
        int count = 0;
        public void CrossRoadAssignation()
        {
            // Ligne vertical. i commence à 1 car les position en 0 concerne les portes qui me seront fournie
            for (int i = 1; i < RoomDecoration.roomWidth; i++)
            {
                crossRoad[count] = new int[] { i, RoomDecoration.roomWidth / 2 };
                count++;
            }
            //Ligne horizontale. i commence à 1 car les position en 0 concerne les portes qui me seront fournie
            for (int i = 1; i < RoomDecoration.roomHeight; i++)
            {
                crossRoad[count] = new int[] { i, RoomDecoration.roomHeight / 2 };
                count++;
            }
            // Affichage des coordonnées
            foreach (var position in crossRoad)
            {
                Console.WriteLine($"Position: ({position[0]}, {position[1]})");
            }
        }

        /// <summary>
        /// Création d'un chemin longeant les murs où le décor ne pourra pas etre posé.
        /// </summary>
        /// <param name="wallRoad">est un tableau de coordonées</param>

        public int[][] wallRoad = new int[(RoomDecoration.roomWidth-2)*2 + (RoomDecoration.roomHeight-2) * 2][];
        public void WallRoadAssignation()
        {
            // Long du mur nord
            for (int i = 1; i < RoomDecoration.roomWidth; i++)
            {
                wallRoad[i]
            }
        }

    }
}
