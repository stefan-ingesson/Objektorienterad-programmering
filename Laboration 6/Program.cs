using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_6
{
    class Program
    {
        static void Main(string[] args)
        {   //Do-while loop för meny
            do
            {
                {
                    Console.Clear();
                    int menuChoice;
                    ViewMenu();
                    if (int.TryParse(Console.ReadLine(), out menuChoice) && menuChoice >= 0 && menuChoice <= 2)
                    {
                        switch (menuChoice)
                        {
                            case 0:

                                return;

                            case 1:

                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" ╔══════════════════════════════════════════════════╗ ");
                                Console.WriteLine(" ║                      Kon                         ║ ");
                                Console.WriteLine(" ╚══════════════════════════════════════════════════╝ ");
                                Console.ResetColor();

                                ViewSolidDetail(CreateSolid(SolidType.CircularCone));
                                break;

                            case 2:
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("╔══════════════════════════════════════════════════════╗");
                                Console.WriteLine("║                       Cylinder                       ║");
                                Console.WriteLine("╚══════════════════════════════════════════════════════╝");
                                Console.ResetColor();
                                Console.WriteLine();
                                ViewSolidDetail(CreateSolid(SolidType.Cylinder));
                                break;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Fel! Du måste ange ett nummer mellan 0 - 2.");
                        Console.ResetColor();
                    }


                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nTryck valfri tangent för att börja om - ESC avslutar.");
                    Console.ResetColor();
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }


        private static Solid CreateSolid(SolidType solidType)
        {
            double radius = ReadDoubleGreaterThanZero(" Ange radien (r): ");
            double height = ReadDoubleGreaterThanZero(" Ange höjden (h): ");
            
            
            if (solidType == SolidType.CircularCone)
            {
                CircularCone newCone = new CircularCone(radius, height);
                return newCone;
            }

            Cylinder newCylinder = new Cylinder(radius, height);
            return newCylinder;
        }

        private static double ReadDoubleGreaterThanZero(string prompt)
        {
            double validateUserChoice;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    validateUserChoice = double.Parse(Console.ReadLine());
                    if (validateUserChoice <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Fel! Ange ett flyttal större än noll.");
                        Console.ResetColor();
                        continue;
                    }

                    return validateUserChoice;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" Fel! Ange ett flyttal större än noll.");
                    Console.ResetColor();
                }
            }
        }
        private static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║                   Solida Volymer                     ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("0. Avsluta.\n");
            Console.WriteLine("1. Kon.\n");
            Console.WriteLine("2. Cylinder.\n");
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.Write("Ange ditt menyval [0-2]: ");
        }

        private static void ViewSolidDetail(Solid solid)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔══════════════════════════════════════════════════╗ ");
            Console.WriteLine(" ║                    Detaljer                      ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(solid.ToString());
        }
    }
}

