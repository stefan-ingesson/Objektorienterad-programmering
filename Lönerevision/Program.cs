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
            int antalLöner;

            do
            {
                antalLöner = ReadInt("Ange antal löner: ");

                if (antalLöner < 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ResetColor();
                    Console.WriteLine("Fel! Du måste ange minst 2 löner för att kunna göra en beräkning");
                }

                else
                {
                    ProcessSalaries(antalLöner);
                }

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck tangent för ny beräkning - Escape för att avsluta");
                Console.ResetColor();


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        private static void ProcessSalaries(int antalLöner)
        {
            int[] löner = new int[antalLöner];
            


            for (int löneRäknare = 0; löneRäknare < löner.Length; löneRäknare++)
            {
                löner[löneRäknare] = ReadInt("Ange lön nummer " + (löneRäknare + 1) + ": ");
            }
            Console.WriteLine();


            // Uträkning för medianlön
            Console.WriteLine("-----------------------------");
            int[] lönerSorterade = new int[antalLöner];

            Array.Copy(löner, lönerSorterade, antalLöner);
            //Array.Copy(salariesValues, salariesValuesSorted, count);

            Array.Sort(lönerSorterade);

            int median;
            if ((antalLöner % 2) == 0)
            {
                int medianvärde1 = lönerSorterade[(antalLöner / 2) - 1];
                int medianvärde2 = lönerSorterade[(antalLöner / 2) - 1];
                median = (medianvärde1 + medianvärde2) / 2;
            }

            else
            {
                median = lönerSorterade[(antalLöner / 2)];
            }
            Console.WriteLine();

            Console.WriteLine("Medianlön:\t {0:c0}", median);
            Console.WriteLine("Medellön:\t {0:c0} ", löner.Average());
            Console.WriteLine("Lönespridning:\t {0:c0} ", löner.Max() - löner.Min());
            Console.WriteLine("-----------------------------");

            // For-loop för att skriva ut tre löner på varje rad
            for (int i = 0; i < löner.Length; i++)
            {
                if (i % 3 != 0)
                {
                    Console.Write("{0, 8}", löner[i]);
                }

                else
                {
                    Console.WriteLine();
                    Console.Write("{0, 8}", löner[i]);
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

