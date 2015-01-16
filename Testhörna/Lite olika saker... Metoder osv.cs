using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            //int numberOfTimes;
            //Console.Write("Ange hur många gånger du ska hälsa på Monica: ");
            //numberOfTimes = int.Parse(Console.ReadLine());

            //for (int i = 0; i < numberOfTimes; i++)
            //{
            //    Console.WriteLine("Hej Monika! Hej på dig Monika!");
            //}

            //int count = 3;

            //while (count < 3)
            //{
            //    Console.WriteLine("Bläe");
            //    count++;
            //}

            //count = 0;
            //do
            //{
            //    Console.WriteLine("Huehuehuehue");
            //    count++;
            //} while (count <3);

            //int number;
            //int summa = 0;

            //Console.Write("Ange heltalen som ska summeras. 0 avbryter: ");
            //number = int.Parse(Console.ReadLine());

            //do
            //{
            //    summa += number;
            //    number = int.Parse(Console.ReadLine());

            //} while (number != 0);


            //Console.WriteLine("{0}", summa);

            //int number;
            //try
            //{
            //    Console.WriteLine("Ange ett heltal");
            //    number = int.Parse(Console.ReadLine());
            //    Console.WriteLine(number);    
            //}
            //catch (FormatException)
            //{

            //    Console.WriteLine("Fel format");
            //}

            //int value = 9;
            //if (value > 0 && value < 10)
            //{

            //        Console.WriteLine("{0} är i intervallet mellan 0 och 10", value);
            //}
            //else
            //{
            //    Console.WriteLine("Numret är större än intervallet");
            //}

            //for (int row = 2; row < 20; row++)
            //{


            //    for (int col = 2; col < 20; col++)
            //    {
            //        Console.Write("{0,4}", row * col);
            //    }
            //    Console.WriteLine();
            //}





            // Uppdelning i olika metoder
            string firstName;
            string lastName;
            string fullName;


            // Kallar på de olika metoderna
            firstName = GetUserInput("Ange ditt förnamn: ");
            lastName = GetUserInput("Ange ditt efternamn: ");
            fullName = GetFullName(firstName, lastName);
            DisplayGreeting(fullName);
            //Console.Write("Ange ditt förnamn: ");
            //firstName = Console.ReadLine();
            //Console.Write("Ange ditt efternamn: ");
            //lastName = Console.ReadLine();
            //fullName = String.Format("{0} {1}", firstName, lastName);


        }

        // Metoden GetUserInput. String prompt innebär att det läser in värdet som blir ifyllt och returnerar det
        static string GetUserInput(string prompt)
        {
            string input;
            Console.Write(prompt);
            input = Console.ReadLine();
            return input;
        }

        // Metoden GetFullName. Returnerar strängarna fName och lName 
        static string GetFullName(string fName, string lName)
        {

            return String.Format("{0} {1}", fName, lName);
        }


        // Metod för att visa upp hälsning
        static void DisplayGreeting(string fullName)
        {
            Console.WriteLine("Ditt fullständiga namn är {0}", fullName);
        }
    }
}
