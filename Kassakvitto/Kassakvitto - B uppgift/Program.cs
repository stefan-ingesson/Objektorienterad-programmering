using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassakvitto___B
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                // Deklarera variabler
                double totalSumma = 0;
                uint erhalletBelopp = 0;
                int summa = 0;

                totalSumma = LasPositiveDouble("Ange totalsumma: ");

                //Här kommer min LasUInt metod. Med den skickar jag med två argument. Minimumvarde använder jag sedan för att se så att det erhållna beloppet är högre än vad den totala summan är
                uint minimumVarde = (uint)Math.Round(totalSumma);
                erhalletBelopp = LasUInt("Ange erhållet belopp: ", minimumVarde);

                //  Uträkningar
                //Öresavrunding
                int avrundning = (int)Math.Round(totalSumma);
                double avrundningOre = avrundning - totalSumma;

                // Beräkning för betalning
                int avrundningBetala = (int)Math.Round(totalSumma);
                double attBetala = avrundningBetala - avrundningOre;
                

                // Beräkning för pengar tillbaka
                uint pengarTillbaka = (uint)Math.Round(erhalletBelopp - attBetala);

                // Presentation
                // KVITTO
                Console.WriteLine("\n\nKVITTO");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Totalt\t\t : {0,10:c}", totalSumma);
                Console.WriteLine("Öresavrundning\t : {0,10:c}", avrundningOre);
                Console.WriteLine("Att betala\t :{0, 11:c0}", attBetala);
                Console.WriteLine("Kontant\t\t : {0,10:c0}", erhalletBelopp);
                Console.WriteLine("Tillbaka\t :{0, 11:c0}", pengarTillbaka);

                Console.WriteLine("----------------------------------------------");

                DelaUppIFaktorer(pengarTillbaka);

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck på valfri tangent för ny beräkning - Escape avslutar");
                Console.ResetColor();

            } while (Console.ReadKey(true).Key !=
                ConsoleKey.Escape);
        }

        // Metod för att läsa in totala summan
        private static double LasPositiveDouble(string prompt)
        {
            string varde = ""; // Den ifyllda summan
            double giltigSumma = 0;

            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumma: ");
                    varde = Console.ReadLine();
                    giltigSumma = double.Parse(varde);

                    if ((Math.Round(giltigSumma) <= 0))
                    {
                        throw new Exception();
                    }
                    return giltigSumma;
                }

                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! {0} kan inte tolkas som en giltig summa pengar", varde);
                    Console.ResetColor();
                }
            }
        }

        // Metod för att läsa in det erhållna beloppet. Minimumvarde använder jag för att jämföra den totala summan efter avrundning med det erhållna beloppet.
        private static uint LasUInt(string prompt, uint minimumVarde)
        {
            uint godkantBelopp = 0; 
            string varde = "";

            while (true)
            {
                try
                {
                    Console.Write("Ange erhållet belopp: ");
                    varde = Console.ReadLine();
                    godkantBelopp = uint.Parse(varde);

                    if (godkantBelopp < minimumVarde)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel! {0:c0} är ett för litet belopp", godkantBelopp);
                        Console.ResetColor();
                    }
                    else
                    {
                        return godkantBelopp;
                    }

                }

                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel! {0} kan inte tolkas som en giltig summa pengar", varde);
                    Console.ResetColor();
                }

            }

        }

        private static void DelaUppIFaktorer(uint vaxelPengar)
        {
            uint vaxelTillbaka = 0;
            uint[] pengarValorer = new uint[] { 500, 100, 50, 20, 10, 5, 1 }; // Array som bestämmer vilka valörer som ska beräknas

            // Array som tilldelar suffix till arrayen pengarValorer. Antalet i denna array måste stämma överens med antalet i ovanstående array!
            string[] valorDefinition = { "-lappar", "-lappar", "-lappar", "-lappar", "-kronor", "-kronor", "-kronor" };

            for (int i = 0; i < pengarValorer.Length; i++)
            {
                //Uträkning för sedlar och mynt
                vaxelTillbaka = vaxelPengar / pengarValorer[i];
                // Räknar ut växeln som blir över  
                vaxelPengar %= pengarValorer[i];

                //Mitt villkor för när det ska skrivas ut. Skiljer det sig från noll, så är villkoret uppfyllt
                if (vaxelTillbaka != 0)
                {
                    Console.WriteLine("{0, -17}: {1}", pengarValorer[i] + valorDefinition[i], vaxelTillbaka);
                }
            }
        }
    }
}

