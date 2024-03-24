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


        // A récuperer de Room ou autre?
        public static int roomWidth = 10;
        public static int roomHeight = 10;
        //Coefficient par lequel on divise la taille de la piece
        public int factor = 4;

        public void DecorateRoom(WallAttribute wallAttribute)
        {
            //Le max de déco sera aire de la piece divisé par factor
            int maxDecoration = (roomHeight * roomWidth) / factor;

            // Récupérer les positions des portes:
            int NorthDoor = (int)WallAttribute.NorthDoor;
            int SouthDoor = (int)WallAttribute.SouthDoor;
            int WestDoor = (int)WallAttribute.WestDoor;
            int EastDoor = (int)WallAttribute.EastDoor;

            var rnd = new Random();

            rnd.Next(1, 2);
            

            
        }    
    }

}
