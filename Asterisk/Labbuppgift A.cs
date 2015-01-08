using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rita_med_asterisk
{
    internal class Program
    {
        private static void Main(string[] args)
        {


            // For-loop för raderna
            for (int row = 0; row < 25; row++)
            {

                // Min if-sats som säger att varannan rad ska ha ett mellanslag
                if (row % 2 != 0)
                {
                    Console.Write(" ");
                }

                // For-loop för kolumnerna
                for (int column = 0; column < 39; column++)
                {

                    // Switch-satsen som med hjälp av modulo berättar vilken färg de olika asteriskerna ska ha
                    switch (row % 3)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }
                    Console.Write("* ");

                }
                Console.WriteLine();
                Console.ResetColor();
            }

        }

    }
}






