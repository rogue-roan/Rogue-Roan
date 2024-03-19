using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue_Roan.Tools
{
    public class Dice
    {
        public Dice(int min, int max) {
            Min = min;
            Max = max;
        }
        public int Min { get; }
        public int Max { get; }

        public int Throw()
        {
            Random rnd = new Random();
            //La valeur max ne sera jamais atteinte par rnd, d'où le +1 sur max (ex : si max == 5 rnd atteindra maximum 4)
            return rnd.Next(Min, Max + 1);
        }
        public int BestOf(int nbDice, int nbKeep)
        {
            if( nbDice < nbKeep)
            {
                Console.WriteLine("Le nombre de dés gardés est supérieur au nombre de dés lancés.");
                return 0;
            }
            List<int> listThrows = new List<int>();

            for(int i = 0; i < nbDice; i++)
            {
                listThrows.Add(Throw());
            }
            listThrows.Sort();
            listThrows.Reverse();

            int sum = 0;

            for(int i = 0;i < nbKeep ;i++)
            {
                sum += listThrows[i];
            }

            return sum;
        }
    }
}
