using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            VypisVystup("Toto je informace.", DruhVystupu.Informace);
            VypisVystup("Toto je varování.", DruhVystupu.Varovani);
            VypisVystup("Toto je chyba.", DruhVystupu.Chyba);

            Console.ReadKey();
        }

        private static void VypisVystup(string text, DruhVystupu druhVystupu)
        {
            switch (druhVystupu)
            {
                case DruhVystupu.Informace:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case DruhVystupu.Varovani:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case DruhVystupu.Chyba:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    throw new NotImplementedException();
            }
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
