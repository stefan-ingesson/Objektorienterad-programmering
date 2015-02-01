using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    class Program
    {
        private const string HorisontalLine = "═";
        static void Main(string[] args)
        {

            ViewTestHeader("Test 1.\nTest av standardkonstruktorn.");
            Cooler cooler = new Cooler();
            Console.WriteLine(cooler.ToString());

            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar, <24.5 och 4>");
            Cooler coolerNumberTwo = new Cooler(24.5M, 4);
            Console.WriteLine(coolerNumberTwo.ToString());

            ViewTestHeader("Test 3.\nTest av konstruktorn med 4 parametrar, <19.5, 4, True och False> ");
            Cooler coolerNumberThree = new Cooler(19.5M, 4M, true, false);
            Console.WriteLine(coolerNumberThree.ToString());

            ViewTestHeader("Test 4.\nTest av kylning med metoden Tick");
            Cooler coolerNumberFour = new Cooler(5.3M, 4M, true, false);
            Run(coolerNumberFour, 10);
            Console.WriteLine(coolerNumberFour.ToString());

            ViewTestHeader("Test 5.\nTest av avstängt kylskåp med metoden Tick, vara avslaget och ha stängd dörr");
            Cooler coolerNumberFive = new Cooler(5.3M, 4M, false, false);
            Run(coolerNumberFive, 10);
            Console.WriteLine(coolerNumberFive.ToString());

            ViewTestHeader("Test 6.\nTest av påslaget kylskåp med metoden Tick, vara på och ha öppen dörr");
            Cooler coolerNumberSix = new Cooler(10.2M, 4M, true, true);
            Run(coolerNumberSix, 10);
            Console.WriteLine(coolerNumberSix.ToString());

            ViewTestHeader("Test 7.\nTest av avslaget kylskåp med metoden Tick, öppen dörr");
            Cooler coolerNumberSeven = new Cooler(19.7M, 4M, false, true);
            Run(coolerNumberSeven, 10);
            Console.WriteLine(coolerNumberSeven.ToString());

            ViewTestHeader("Test 8.\nTest av egenskaperna så att undantag kastas då innetemperatur och måltemperatur tilldelas felaktiga värden");
            try
            {
                Cooler coolerNumberEight = new Cooler();
                coolerNumberEight.InsideTemperature = 51;

                // om jag komer hit är det fel..

                //Run(coolerNumberEight, 10);
            }
            catch (ArgumentException ex)
            {
                // rätt att komma hit
                ViewErrorMessage(ex.Message);
            }

            try
            {
                Cooler coolerNumberEight = new Cooler();
                coolerNumberEight.InsideTemperature = -10;
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(ex.Message); //Med det här kan jag skriva in vilket felmeddelande jag vill ska visas om det blir ett ogiltigt värde av typen ArgumentException.
            }

            try
            {
                Cooler coolerNumberEight = new Cooler();
                coolerNumberEight.TargetTemperature = 21;
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                Cooler coolerNumberEight = new Cooler();
                coolerNumberEight.TargetTemperature = -5;
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(ex.Message);
            }

            ViewTestHeader("Test 9.\nTest av konstruktorerna så att undantag kastas då innetemperatur och måltemperatur tilldelas felaktiga värden");
            try
            {
                Cooler coolerNumberNine = new Cooler(51M, 4M, true, true);
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(ex.Message);
            }
            try
            {
                Cooler coolerNumberNine = new Cooler(-7M, 4M, true, true);
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(ex.Message);
            }
            try
            {
                Cooler coolerNumberNine = new Cooler(8M, 27M, true, true);
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(ex.Message);
            }
            try
            {
                Cooler coolerNumberNine = new Cooler(8M, -5M, true, true);
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(ex.Message);
            }
        }

        //Testmetod
        private static void Run(Cooler cooler, int minutes)
        {
            Console.WriteLine(cooler.ToString()); // Måste köra en gång innan, annars ändras mina argument 
            for (int numberOfMinutes = 0; numberOfMinutes < minutes; numberOfMinutes++)
            {
                cooler.Tick();
                Console.WriteLine(cooler.ToString());
            }
        }

        // Presenterar eventuella felmeddelanden
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        // Presenterar header
        public static void ViewTestHeader(string header) // Skapar en horisontell "rubrik" som tar emot sträng som argument.
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write(HorisontalLine);

            }
            Console.WriteLine();
            Console.WriteLine(header);
        }
    }
}
