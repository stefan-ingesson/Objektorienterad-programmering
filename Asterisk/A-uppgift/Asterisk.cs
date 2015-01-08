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
            for (int row = 0; row < 25; row++)
            {

                if (row % 2 != 0)
                {
                    Console.Write(" ");
                }

                for (int column = 0; column < 38; column++)
                {


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






