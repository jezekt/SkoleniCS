using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    public class Kontakt
    {
        // PROPERTIES - VLASTNOSTI
        public string Jmeno { get; }
        public string Prijmeni { get; }
        public string Telefon { get; }

        // METHODS - METODY
        public void VypisDetaily()
        {
            Console.WriteLine("Jméno: " + Jmeno + "; Příjmení: " + Prijmeni + "; Telefon: " + Telefon + ".");
        }

        // CONSTRUCTORS - KONSTRUKTORY
        public Kontakt(string jmeno, string prijmeni, string telefon)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Telefon = telefon;
        }
    }
}
