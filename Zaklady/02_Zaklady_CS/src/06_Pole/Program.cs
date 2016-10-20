using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            JednorozmernaPole();
            Console.ReadLine();
        }


        private static void JednorozmernaPole()
        {
            var cisla = GetPoleCisel(10);
            VypisVsechnaCisla(cisla);

            // Další způsoby vytvoření pole
            var definovanaCislaA = new int[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
            var definofavaCislaB = new[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };
            int[] definovanaCislaC = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 };

            var tretiPrvek = definovanaCislaC[2]; // získání hodnoty třetího prvku pole pomocí indexu (index je od 0 do n)
        }

        private static void VicerozmernaPole()
        {
            var matice = GetDvojrozmernePoleCisel(3, 5);
            VypisMatici(matice);
        }

        private static void VicenasobnaPole()
        {
            var polePoli = GetPolePoli(10);
            VypisPolePoli(polePoli);
        }


        private static int[] GetPoleCisel(int velikost)
        {
            var cisla = new int[velikost]; // vytvoření pole o dané velikosti
            for (int i = 0; i < cisla.Length; i++)
            {
                cisla[i] = i + 1; // naplnění konkrétního prvku pole hodnotou
            }
            return cisla;
        }

        private static int[,] GetDvojrozmernePoleCisel(int i, int j)
        {
            var matice = new int[i, j]; // definice dvojrozměrného pole

            int hodnota = 0;
            for (int k = 0; k < i; k++)
            {
                for (int l = 0; l < j; l++)
                {
                    matice[k, l] = hodnota; // naplnění hodnoty prvku pole řádku k a sloupce l
                    hodnota++;
                }
                hodnota = 0;
            }

            return matice;
        }

        private static int[][] GetPolePoli(int i)
        {
            var hlavniPole = new int[i][]; // definice pole polí
            for (int k = 0; k < i; k++)
            {
                var prvek = GetPoleCisel(k+1);
                hlavniPole[k] = prvek; // prvek hlavního pole je pole čísel
            }
            return hlavniPole;
        }


        private static void VypisVsechnaCisla(int[] cisla)
        {
            foreach (var cislo in cisla)
            {
                Console.WriteLine(cislo);
            }
        }

        private static void VypisMatici(int[,] matice)
        {
            var pocetRadku = matice.GetLength(0);
            var pocetSloupcu = matice.GetLength(1);

            for (int i = 0; i < pocetRadku; i++)
            {
                for (int j = 0; j < pocetSloupcu; j++)
                {
                    Console.Write(matice[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private static void VypisPolePoli(int[][] polePoli)
        {
            foreach (var prvek in polePoli)
            {
                foreach (var cislo in prvek)
                {
                    Console.Write(cislo + ",");
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(";");
                Console.WriteLine();
            }
        }
    }
}
