using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lotteriintäkt
{
    class Program
    {
        static void Main(string[] args)
        {
            // deklarera variabler
            var summa = 0;
            
            // summering av lotter
            for (int i = 2; i < 102; i+=2)
            {
                summa += i;
            }
            //presentation av resultat
            Console.WriteLine("Ringen med lotter ger intäkten {0:c0}", summa);
        }
    }
}
