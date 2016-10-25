using System;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var prvniCislo = GetCisloZeVstupu("Zadejte první číslo:");
                var druheCislo = GetCisloZeVstupu("Zadejte druhé číslo:");
                var operand = GetOperand();

                Console.WriteLine("Výsledek:");
                switch (operand)
                {
                    case "+":
                        Console.WriteLine(GetSoucet(prvniCislo, druheCislo));
                        break;
                    case "-":
                        Console.WriteLine(GetRozdil(prvniCislo, druheCislo));
                        break;
                    case "*":
                        Console.WriteLine(GetSoucin(prvniCislo, druheCislo));
                        break;
                    case "/":
                        Console.WriteLine(GetPodil(prvniCislo, druheCislo));
                        break;
                    default:
                        Console.WriteLine("Neplatný operand.");
                        break;
                }

                Console.ReadLine();
            }
        }

        private static int GetCisloZeVstupu(string textPozadavku)
        {
            int cislo;
            string cisloText;
            do
            {
                Console.WriteLine(textPozadavku);
                cisloText = Console.ReadLine();
            } while (!TryGetCislo(cisloText, out cislo));

            return cislo;
        }

        private static bool TryGetCislo(string cisloText, out int cislo)
        {

            if (!int.TryParse(cisloText, out cislo))
            {
                Console.WriteLine("Zadaný vstup není číslo.");
                return false;
            }
            return true;
        }

        private static string GetOperand()
        {
            Console.WriteLine("Zadejte operand:");
            return Console.ReadLine();
        }

        private static int GetSoucet(int x, int y)
        {
            int soucet = x + y;
            return soucet;
        }

        private static int GetRozdil(int x, int y)
        {
            return x - y;
        }

        private static int GetSoucin(int x, int y)
        {
            return x * y;
        }

        private static int GetPodil(int x, int y)
        {
            return x / y;
        }
    }
}
