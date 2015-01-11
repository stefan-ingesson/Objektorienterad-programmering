using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace arrays
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //int[] skoStorlek = {32, 43, 38, 40, 37};



            //for (int i = 0; i < skoStorlek.Length; i++)
            //{
            //   Console.WriteLine(skoStorlek[i]);
            //}

            //foreach (int skoStorlekar in skoStorlek)
            //{
            //    Console.WriteLine(skoStorlekar);
            //}


            //Första problemet i pdfen arrays
            int[] tentaResultat = new int[10] {10, 13, 19, 29, 12, 27, 30, 25, 21, 17};

            Console.WriteLine("Totalt antal poäng: " + tentaResultat.Sum());
            Console.WriteLine("Medelpoängen på tentan var: " + tentaResultat.Average());
            Console.WriteLine("Lägsta poängen var: " + tentaResultat.Min());
            Console.WriteLine("Högsta poängen var: " + tentaResultat.Max());


            Array.Sort(tentaResultat);
            foreach (int i in tentaResultat)
            {
                Console.Write(i + " ");
            }

            //int[] antalTentor = new int[10] {25, 75, 38, 53, 47, 15, 18, 63, 67, 48};

            //int[] tentaResultat;
            //int summa;


            // Console.WriteLine( );
            //   }
            //}

















        }
    }

}