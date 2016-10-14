using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    class Program
    {
        static void Main()
        {
        }

        private static void DeklaracePromennych()
        {
            // Explicitní typování
            int x; // deklarace proměnné
            x = 1000000; // naplnění proměnné hodnotou
            byte y = 125; // deklarace proměnné a naplnění hodnotou

            // Implicitní typování - o typu rozhodne kompilátor
            var soucet = x + y; // deklarace proměnné a naplnění hodnotou
        }


        private static void PretypovaniCisel()
        {
            int x = 150;
            byte y = 1;
            int soucet = x + y;

            // Implicitní přetypování
            long z = x; // implicitní převod typu int (32 bit) na typ long (64 bit)
            //y = x; // nelze provést - nelze zapsat hodnotu typu int (32 bit) do proměnné typu byte (8 bit)
            x = y; // lze provést - proměnná y je typu byte a její hodnotu lze zapsat do proměnné typu int

            // Explicitní přetypování
            y = (byte) soucet;
        }

        private static void PretypovaniStringu()
        {
            string text = "text";
            //int i = text; // nelze přetypovat string na typ int
            int i = int.Parse(text); // v tomto případě dojde během přetypování k výjimce
            i = int.Parse("1256"); // řetězec "1256" bude převeden na celé číslo 1256

            if (int.TryParse(text, out i))
            {
                Console.WriteLine("Přetypování se zdařilo.");
            }
            else
            {
                Console.WriteLine("Nelze přetypovat.");
            }

        }


    }
}
