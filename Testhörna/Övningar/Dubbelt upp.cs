using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dubbelt_upp
{
    class Program
    {
        static void Main(string[] args)
        {
            // deklarera variabler

            int[] tal = new int[5] { 10, 23, 5, 1, 15 };


            // For-loopen som ska se till så att talen visas
            for (int i = 0; i < tal.Length; i++)
            {
                Console.Write("{0} ",tal[i]);
            }

            Console.WriteLine();

            // 1 och 4 efter tal pekar på den "låda" som jag vill förändra värdet i, det här fallet det andra och femte talet i arrayen

            tal[1] *= 2;

            tal[4] *= 2;

            for (int i = 0; i < tal.Length; i++)
            {
                Console.Write("{0} ", tal[i]);
            }
            Console.WriteLine();












        }
    }
}
