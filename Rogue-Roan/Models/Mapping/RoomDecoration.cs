using Rogue_Roan.Enums.Mapping;
using Rogue_Roan.Model.Mapping;
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



                                                /// <summary>
                                                /// ///////////////////////////// Mettre la taille des salles dans le constructeur 
                                                /// </summary>
        // A récuperer de Room ou autre?
        public static int roomWidth = 10;
        public static int roomHeight = 10;
        //Coefficient par lequel on divise la taille de la piece
        public int factor = 4;

        // Path est un tableau qui contiendra les coordonées du chemin à laisser libre.
        int[][] path;
        public int[][] DecorateRoom(WallAttribute wallAttribute)
        {
            //Le max de déco sera aire de la piece divisé par factor
            int maxDecoration = (roomHeight * roomWidth) / factor;

            // Récupérer les positions des portes:
            int NorthDoor = (int)WallAttribute.NorthDoor;
            int SouthDoor = (int)WallAttribute.SouthDoor;
            int WestDoor = (int)WallAttribute.WestDoor;
            int EastDoor = (int)WallAttribute.EastDoor;

            Console.WriteLine("Coucou");

            // Choix du chemin libre
            var rnd = new Random();
            int random = rnd.Next(1, 2);
            RoomRestriction room = new RoomRestriction();
            random = 1;
            switch (random)
            {
                case 1:
                    path = room.CrossRoadAssignation();
                    break;
                case 2:
                    path = room.WallRoadAssignation();
                    break;
            }
            // Disposition des bloc de décors (faire une enum? ou une classe roomType?)
            //Console.WriteLine(path);

            return path;
        }   
        
        public void DecorateRoom2()
        {
            // Aller choisir le type de niveau (eau-foret..)
            var rnd = new Random();
            int random = rnd.Next(1, 2);




        }
    }

}
