using System;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    public class ConsoleInputReader
    {
        public int GetCisloZeVstupu(string textPozadavku)
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

        public MatematickaOperace GetMatematickaOperace()
        {
            while (true)
            {
                Console.WriteLine("Zadejte operand:");
                var vstup = Console.ReadLine();
                if (vstup == "+")
                {
                    return MatematickaOperace.Scitani;
                }
                if (vstup == "-")
                {
                    return MatematickaOperace.Odcitani;
                }
                if (vstup == "*")
                {
                    return MatematickaOperace.Nasobeni;
                }
                if (vstup == "/")
                {
                    return MatematickaOperace.Deleni;
                }
                Console.WriteLine($"'{vstup}' není platný operand.");
            }
        }


        private bool TryGetCislo(string cisloText, out int cislo)
        {

            if (!int.TryParse(cisloText, out cislo))
            {
                Console.WriteLine("Zadaný vstup není číslo.");
                return false;
            }
            return true;
        }

    }
}
