using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JezekT.SkoleniCS.Kalkulator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte první číslo:");
            string prvniCisloText = Console.ReadLine();
            int prvniCislo = int.Parse(prvniCisloText);

            Console.WriteLine("Zadejte druhé číslo:");
            string druheCisloText = Console.ReadLine();
            int druheCislo = int.Parse(druheCisloText);

            Console.WriteLine("Zadejte operand:");
            string operand = Console.ReadLine();

            Console.WriteLine("Výsledek:");
            switch (operand)
            {
                case "+":
                    Console.WriteLine(prvniCislo + druheCislo);
                    break;
                case "-":
                    Console.WriteLine(prvniCislo - druheCislo);
                    break;
                case "*":
                    Console.WriteLine(prvniCislo*druheCislo);
                    break;
                case "/":
                    Console.WriteLine(prvniCislo/druheCislo);
                    break;
            }

            Console.ReadLine();
        }
    }
}
