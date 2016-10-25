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
            while (true)
            {
                Console.WriteLine("Zadejte první číslo:");
                string prvniCisloText = Console.ReadLine();
                int prvniCislo;
                if (int.TryParse(prvniCisloText, out prvniCislo))
                {
                    Console.WriteLine("Zadejte druhé číslo:");
                    string druheCisloText = Console.ReadLine();
                    int druheCislo;
                    if (int.TryParse(druheCisloText, out druheCislo))
                    {
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
                                Console.WriteLine(prvniCislo * druheCislo);
                                break;
                            case "/":
                                Console.WriteLine((decimal)prvniCislo / druheCislo);
                                break;
                            default:
                                Console.WriteLine("Neplatný operand.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{druheCisloText} není číslo.");
                    }
                }
                else
                {
                    Console.WriteLine($"{prvniCisloText} není číslo.");
                }

                Console.ReadLine();
            }
        }
    }
}
