using Rogue_Roan.Enums.Mapping;
using Rogue_Roan.Model.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Models.Mapping
{

    /// <summary>
    /// La classe RoomDecoration est chargée de renvoyer des listes de coordonnées qui serviront à décorer les salles
    /// </summary>
    internal class RoomDecoration
    {
        /// <summary>
        /// !!Il faudrait stocker roomWidth et roomHeigth autre part!!
        /// </summary>
        /// <param name="roomWidth">Largeur d'une salle</param>
        /// <param name="roomHeigth">Hauteur d'une salle</param>
        /// <param name="freePath">Liste de coordonées qui représentent un chemin qui doit être laissé vide afin de toujours permettre au personnage de traverser une piece</param>
        /// <param name="finalPath">Hauteur d'une salle</param>
 
        public static int roomWidth = 10;
        public static int roomHeight = 10;
        List<int[]> freePath = new List<int[]>();
        List<int[]> finalPath = new List<int[]>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wallAttribute"></param>
        /// <returns></returns>
        public List<int[]> DecorateRoom(WallAttribute wallAttribute)
        {

            // Récupérer les positions des portes:
            int NorthDoor = (int)WallAttribute.NorthDoor;
            int SouthDoor = (int)WallAttribute.SouthDoor;
            int WestDoor = (int)WallAttribute.WestDoor;
            int EastDoor = (int)WallAttribute.EastDoor;

            freePath = chooseFreePath();


            return finalPath;

        }

        /// <summary>
        /// Sélectionne aléatoirement un chemin libre dans la salle grâce à RoomRestriction
        /// </summary>
        /// <returns>Il retourne une liste de coordonées</returns>
        public List<int[]> chooseFreePath()
        {
            RoomRestriction room = new RoomRestriction();
            var rnd = new Random();
            int random = rnd.Next(0, 2);
            // Je ne travaille que sur un seul chemin libre actuellement
            random = 0;                      
            switch (random)
            {
                case 0:
                    freePath = room.crossRoadAssignation();
                    break;
                case 1:
                    //freePath = room.WallRoadAssignation();
                    break;
            }
            return freePath;
        }

        /// <summary>
        /// Permet, grace à la classe RoomFloor de générer une liste de coordonées aléatoire qui serviront à décorer la pièce avec des cases de décors.
        /// </summary>
        /// <returns>Retourne une liste de coordonées ou sera placé le décors</returns>
        public List<int[]> generateRoomFloor()
        {
            RoomFloor roomFloor = new RoomFloor();
            List<int[]> actualroomFloor = roomFloor.generateRandomFloor();

            Console.WriteLine("Tableau venant de floor:");
            foreach (var coordinates in actualroomFloor)
            {
                Console.WriteLine($"Position: ({coordinates[0]}, {coordinates[1]})");
            }
            return actualroomFloor;
        }
        
        /// <summary>
        /// Permet de choisir le type de décor qui sera généré aux coordonées contenue dans path
        /// </summary>
        public void roomType()
        {
            
            // Aller choisir le type de niveau (eau-foret..)
            var rnd = new Random();
            int random = rnd.Next(1, 2);
            random = 1;

            switch (random)
            {
                case 1:
                    RoomType.WaterRoom roomType = new RoomType.WaterRoom();
                    string color = roomType.color;
                    int[][] water = roomType.getWaterRoom();
                    break;
            }


        }
    }

}
