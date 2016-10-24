using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Kontakty();
            Console.ReadLine();
        }

        private static void Kontakty()
        {
            // pole Kontaktů se třemi instancemi třídy Kontakt
            var seznamKontaktu = new[]
            {
                new Kontakt("Jan", "Novák", "111 202 303"),
                new Kontakt("Jiří", "Čech", "333 123 321"),
                new Kontakt("Kamil", "Chvátal", "888 888 888")
            };

            foreach (var kontakt in seznamKontaktu)
            {
                kontakt.VypisDetaily();
            }
        }

        private static void Budik()
        {
            var budik = new Budik {VypisujCas = true}; // vytvoření nové instance třídy Budik
            budik.Buzeni += OnBuzeni; // připsání ke sledování událost Buzeni - metoda OnBuzeni()  
            budik.NastavitBudik(DateTime.Now.AddSeconds(5)); // nastavení budíku na 5 s dopředu
            Console.WriteLine($"Budík nastaven na {budik.CasBuzeni}.");

            budik.ZapnoutBudik();
        }

        private static void OnBuzeni()
        {
            Console.WriteLine("Budík spustil událost buzení...CRRRRRRR!");
        }

    }
}
