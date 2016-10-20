using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            PouzitiIf();
            Console.ReadLine();
        }


        private static void PouzitiIf()
        {
            var i = 5;

            if (i > 10)
            {
                Console.WriteLine("Číslo je větší než 10.");
            }
            else if (i > 5)
            {
                Console.WriteLine("Číslo je větší než 5 a menší rovno 10.");
            }
            else
            {
                Console.WriteLine("Číslo je menší rovno 5.");
            }

            // Alternativní zápis 1
            if (i > 10) Console.WriteLine("Číslo je větší než 10.");
            else if (i > 5) Console.WriteLine("Číslo je větší než 5 a menší rovno 10.");
            else Console.WriteLine("Číslo je menší rovno 5.");

            // Alternativní zápis 2
            if (i > 10)
                Console.WriteLine("Číslo je větší než 10.");
            else if
                (i > 5) Console.WriteLine("Číslo je větší než 5 a menší rovno 10.");
            else // v případě, že je potřeba použít více řádků, je nutno použít složené závorky
            {
                var text = "Číslo je menší rovno 5.";
                Console.WriteLine(text);
            }
        }

        private static void PouzitiWhile()
        {
            // Vypíše čísla od 1 do 10
            var i = 1;
            while (i <= 10)
            {
                Console.WriteLine(i);
                i++;
            }
        }

        private static void PouzitiDo()
        {
            string s;
            do
            {
                Console.WriteLine("Pro opuštění smyčky napište 'exit' a stiskněte ENTER");
                s = Console.ReadLine();

            } while (s != "exit");

            Console.WriteLine("OK");
        }

        private static void PouzitiSwitch()
        {
            var denVTydnu = DayOfWeek.Friday;

            switch (denVTydnu)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Pondělí");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("Úterý");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("Středa");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Čtvrtek");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Pátek");
                    break;
                case DayOfWeek.Saturday: // složený případ
                case DayOfWeek.Sunday:
                    Console.WriteLine("Víkend");
                    break;
                default: // v případě, kdy nastane možnost, která není specifikována výše
                    throw new NotImplementedException("Tento den v týdnu není implementován.");
            }
        }

        private static void PouzitiFor()
        {
            var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // int i = 0 - deklarace a počáteční naplnění proměnné, která se používá v podmínce cyklu
            // i < 6 - podmínka cyklu
            // i++ - výraz, který je proveden po každé iteraci
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(cisla[i]);
            }

            for (int i = 9; i > 5; i = i - 1)
            {
                Console.WriteLine(cisla[i]);
            }

        }


        private static void PouzitiForeach()
        {
            var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            // projde všechny prvky kolekce cisla
            // v každé iteraci je odpovídající prvek naplněn do proměnné cislo
            foreach (var cislo in cisla)
            {
                Console.WriteLine(cislo);
            }
        }

        private static void PouzitiBreak()
        {
            var email = "test@best.cz";
            var jednotliveZnaky = email.ToCharArray();
            string uzivatel = "";
            for (int i = 0; i < jednotliveZnaky.Length; i++)
            {
                var znak = jednotliveZnaky[i];
                if (znak == '@')
                {
                    // opustí cyklus for a pokračuje v běhu
                    break;
                }
                uzivatel += znak;
            }

            Console.WriteLine(uzivatel);
        }

        private static void PouzitiContinue()
        {
            var cisla = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            Console.WriteLine("Sudá čísla:");
            foreach (var cislo in cisla)
            {
                if (cislo%2 != 0)
                {
                    // pokračuje v další iteraci cyklu foreach
                    continue;
                }
                Console.WriteLine(cislo);
            }
        }

        private static void PouzitiTryCatch()
        {
            try // blok ve kterém se má provést odchycení výjimky
            {
                var x = 10;
                var y = 0;
                var podil = x/y;

                Console.WriteLine(podil);
            }
            catch (DivideByZeroException ex) // blok ve kterém se řeší odchycená výjimka
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
