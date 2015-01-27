using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace lönerevision_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int antalLoner;

            do
            {
                antalLoner = ReadInt("Ange antal löner: ");

                if (antalLoner < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ResetColor();
                    Console.WriteLine("Fel! Du måste ange minst 2 löner för att kunna göra en beräkning");
                }

                else
                {
                    ProcessSalaries(antalLoner);
                }

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck tangent för ny beräkning - Escape för att avsluta");
                Console.ResetColor();


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static void ProcessSalaries(int antalLoner)
        {
            int[] loner = new int[antalLoner];
            


            for (int loneRaknare = 0; loneRaknare < loner.Length; loneRaknare++)
            {
                loner[loneRaknare] = ReadInt("Ange lön nummer " + (loneRaknare + 1) + ": ");
            }
            Console.WriteLine();


            // Uträkning för medianlön
            Console.WriteLine("-----------------------------");
            int[] lonerSorterade = new int[antalLoner];

            Array.Copy(loner, lonerSorterade, antalLoner);

            Array.Sort(lonerSorterade);

            decimal median;
            if ((antalLoner % 2) == 0)
            {
                int medianvarde1 = lonerSorterade[(antalLoner / 2) - 1];
                int medianvarde2 = lonerSorterade[(antalLoner / 2)];
                median = (medianvarde1 + medianvarde2) / 2.0m;
            }

            else
            {
                median = lonerSorterade[(antalLoner / 2)];
            }
            Console.WriteLine();

            Console.WriteLine("Medianlön:\t {0:c0}", median);
            Console.WriteLine("Medellön:\t {0:c0} ", loner.Average());
            Console.WriteLine("Lönespridning:\t {0:c0} ", loner.Max() - loner.Min());
            Console.WriteLine("-----------------------------");

            // For-loop för att skriva ut tre löner på varje rad
            for (int i = 0; i < loner.Length; i++)
            {
                if (i % 3 != 0)
                {
                    Console.Write("{0, 8}", loner[i]);
                }

                else
                {
                    Console.WriteLine();
                    Console.Write("{0, 8}", loner[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static int ReadInt(string prompt)
        {
            string userInput = null;
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    userInput = Console.ReadLine();
                    return int.Parse(userInput);

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("FEL! '{0}' kan inte tolkas som ett heltal. ", userInput);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

        }
    }

}

