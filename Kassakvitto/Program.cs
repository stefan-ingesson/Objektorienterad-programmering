using System;


namespace kassakvitto
{
    class Program
    {
        // Bestämmer värde på mina variabler som används för valörberäkningen

        private const int femhundra = 500;
        private const int etthundra = 100;
        private const int femtio = 50;
        private const int tjugo = 20;
        private const int tio = 10;
        private const int fem = 5;
        private const int ett = 1;
        

        static void Main(string[] args)
        {

            

            double totalSumma = 0;
            int erhalletBelopp = 0;
            double summa = 0;


            // Läser in totalasumman och eventuella felmeddelanden
            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumma: ");

                    totalSumma = double.Parse(Console.ReadLine());
                    if (totalSumma < 0.6)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras!");
                        Console.ResetColor();
                        return;



                    }
                    break;
                }

                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktig inmatning! Försök igen");
                    Console.ResetColor();
                }
            }

            // Läser in det erhållna beloppet plus eventuella felmeddelanden
            while (true)
            {
                try
                {
                    Console.Write("Erhållet belopp: ");

                    erhalletBelopp = int.Parse(Console.ReadLine());

                    break;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Erhållet belopp felaktig!");
                    Console.ResetColor();

                }
            }

            // Totalsumma större än erhållet belopp
            if (totalSumma > erhalletBelopp)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Erhållet belopp är för litet. Köpet kunde inte genomföras.");
                return;
            }



            // avrundning till antal ören som dras bort
            int avrundning = (int)Math.Round(totalSumma);
            double avrundningOre = avrundning - totalSumma;

            

            // avrundning till antal kronor att betala
            int avrundningBetala = (int)Math.Round(totalSumma);
            double attBetala = avrundningBetala - avrundningOre;



            // beräkning pengar tillbaka
            int pengarTillbaka = (int)Math.Round(erhalletBelopp - totalSumma);


            string totalt = "Totalt";
            string öresavrundning = "Öresavrundning";
            string betala = "Att betala";
            string kontant = "Kontant";
            string tillbaka = "Tillbaka";


            // KVITTO
            Console.WriteLine("\n\nKVITTO");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Totalt\t\t : {0, 15:c}", totalSumma);
            Console.WriteLine("Öresavrundning\t : {0, 15:c}", avrundningOre);
            Console.WriteLine("Att betala\t : {0, 15:c0}", attBetala);
            Console.WriteLine("Kontant\t\t : {0, 15:c0}", erhalletBelopp);
            Console.WriteLine("Tillbaka\t : {0, 15:c0}", pengarTillbaka);

            Console.WriteLine("----------------------------------------------");



            int femhundralapp = 0;
            int etthundralapp = 0;
            int femtiolapp = 0;
            int tjugolapp = 0;
            int tiokr = 0;
            int femkr = 0;
            int ettkr = 0;



            // Uträkning för valörer
            femhundralapp = pengarTillbaka / 500;
            pengarTillbaka = pengarTillbaka % femhundra;
            etthundralapp = pengarTillbaka / 100;
            pengarTillbaka = pengarTillbaka % etthundra;
            femtiolapp = pengarTillbaka / 50;
            pengarTillbaka = pengarTillbaka % femtio;
            tjugolapp = pengarTillbaka / 20;
            pengarTillbaka = pengarTillbaka % tjugo;
            tiokr = pengarTillbaka / 10;
            pengarTillbaka = pengarTillbaka % tio;
            femkr = pengarTillbaka / 5;
            pengarTillbaka = pengarTillbaka % fem;
            ettkr = pengarTillbaka / ett;
            pengarTillbaka = pengarTillbaka % ett;

           


            // Utskrift av valörer
            if (femhundralapp >= 1)
            {
                Console.WriteLine(" {0, -16}: {1:f0}", "500-lappar", femhundralapp);
                
            }

            if (etthundralapp >= 1)
            {
                Console.WriteLine(" {0, -16}: {1:f0}", "100-lappar", etthundralapp);
            }

            if (femtiolapp >= 1)
            {
                Console.WriteLine("  {0, -15}: {1:f0}", "50-lappar", femtiolapp);
            }

            if (tjugolapp >= 1)
            {
                Console.WriteLine("  {0, -15}: {1:f0}", "20-lappar",tjugolapp);
            }

            if (tiokr >= 1)
            {
                Console.WriteLine("  {0, -15}: {1:f0}", "10-kronor", tiokr);
            }

            if (femkr >= 1)
            {
                Console.WriteLine("   {0, -14}: {1:f0}", "5-kronor", femkr);
            }

            if (ettkr >= 1)
            {
                Console.WriteLine("   {0, -14}: {1:f0}", "1-kronor", ettkr);
            }


        }
    }
}
