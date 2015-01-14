using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace produkt
{
    class Program
    {
        static void Main(string[] args)
        {
            // deklarera variabler
            long produkt = 1;

            //uträkning
            for (int i = 1; i < 21; i+=1)
            {
                produkt *= i;

                
            }

            // presentation av resultat
            Console.WriteLine("Produkten av alla heltal mellan 1-20 är {0}", produkt);
        }
    }
}
