using Rogue_Roan.Enums.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Mapping
{
    internal class RoomDecoration
    {
        // Une piece 10x10
        // Je vais prendre une piece vide et la remplir
        // Il faut vérifier plusieurs chose:
        // -La position des portes afin de ne pas les bloquer
        // -Un nombre de case minimum qui doit etre vide

        // A la fin je dois renvoyer un layout de piece

        public void DecorateRoom(int roomHeight, int roomWidth, WallAttribute wallAttribute)
        {
            //Coefficient par lequel on divise la taille de la piece
            int factor = 4;
            //Le max de déco sera aire de la piece divisé par factor
            int maxDecoration = (roomHeight * roomWidth) / factor;


            // Récupérer les positions des portes:
            int NorthDoor = 0;
            int SouthDoor = 0;
            int WestDoor = 0;
            int EastDoor = 0;


            // Comment s'assurer qu'il y ai tjs un chemin dans la piece?
            /*
             * Soit définir un ou des chemin et empecher la création de décors dessus?
             * 
             */
            if (NorthDoor)
            {

            }
        }



    
    }

    // Il faudrait refactoriser les méthode d'assignation avec des formules mathématiques
    public class RoomRestriction
    {
        // Chemin de croix
        public int[][] crossWalk = new int[10][];
        public void CrossRoadAssignation()
        {
            crossWalk[0] = new int[] { 0, 5 };
            crossWalk[1] = new int[] { 1, 5 };
            crossWalk[2] = new int[] { 2, 5 };
            crossWalk[3] = new int[] { 3, 5 };
            crossWalk[4] = new int[] { 4, 5 };
            crossWalk[5] = new int[] { 5, 5 };
            crossWalk[6] = new int[] { 6, 5 };
            crossWalk[7] = new int[] { 7, 5 };
            crossWalk[8] = new int[] { 8, 5 };
            crossWalk[9] = new int[] { 9, 5 };
            crossWalk[10] = new int[] { 10, 5 };
        }

        // Chemin longeant les murs

        public int[][] wallRoad = new int[34][];
        public void WallRoadAssignation()
        {
            // Long du mur nord
            wallRoad[0] = new int[] { 1, 1 };
            wallRoad[1] = new int[] { 1, 2 };
            wallRoad[2] = new int[] { 1, 3 };
            wallRoad[3] = new int[] { 1, 4 };
            wallRoad[4] = new int[] { 1, 5 };
            wallRoad[5] = new int[] { 1, 6 };
            wallRoad[6] = new int[] { 1, 7 };
            wallRoad[7] = new int[] { 1, 8 };
            wallRoad[8] = new int[] { 1, 9 };
            // Long du mur sud
            wallRoad[9] = new int[] { 9, 1 };
            wallRoad[10] = new int[] { 9, 2 };
            wallRoad[11] = new int[] { 9, 3 };
            wallRoad[12] = new int[] { 9, 4 };
            wallRoad[13] = new int[] { 9, 5 };
            wallRoad[14] = new int[] { 9, 6 };
            wallRoad[15] = new int[] { 9, 7 };
            wallRoad[16] = new int[] { 9, 8 };
            wallRoad[17] = new int[] { 9, 9 };
            // Long du mur ouest
            wallRoad[18] = new int[] { 2, 1 };
            wallRoad[19] = new int[] { 3, 1 };
            wallRoad[20] = new int[] { 4, 1 };
            wallRoad[21] = new int[] { 5, 1 };
            wallRoad[22] = new int[] { 6, 1 };
            wallRoad[23] = new int[] { 7, 1 };
            wallRoad[24] = new int[] { 8, 1 };
            // Long du mur est
            wallRoad[25] = new int[] { 9, 9 };
            wallRoad[26] = new int[] { 2, 9 };
            wallRoad[27] = new int[] { 3, 9 };
            wallRoad[28] = new int[] { 4, 9 };
            wallRoad[29] = new int[] { 5, 9 };
            wallRoad[30] = new int[] { 6, 9 };
            wallRoad[31] = new int[] { 7, 9 };
            wallRoad[32] = new int[] { 8, 9 };
            // Portes
            wallRoad[33] = new int[] { 5, 0 };
            wallRoad[34] = new int[] { 5, 10 };
        }
    }
}
