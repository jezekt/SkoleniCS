# Školení jazyka C# - Základy - ConsoleApp

V této sekci jsou podklady pro školení základů programování konzolové aplikace v jazyce `C#`.

Osnova školení
==============
1. Úvod do C# a .NET Framework
2. Praktické příklady
  * Step 0 - Založení projektu,
  * Step 1 - Hello World.

1 Úvod do C# a .NET Frameworku
==============================

### Vývoj programovacích jazyků
* vývoj programovacích jazyků je popsán [zde](http://www.itnetwork.cz/csharp/zaklady/c-sharp-tutorial-uvod-do-jazyka-a-dot-net-framework).

### Vytváření assembly (.dll, .exe)
* jak vytvořit sestavení pomocí `csc.exe` je popsáno [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/program-structure);
* jak vytvořit sestavení pomocí Visual Studia je ukázáno na [videu](https://www.youtube.com/watch?v=ruf4U9_Rbss).

### Čtení IL
* jak zobrazit IL kód sestavení pomocí nástroje `ildasm.exe` je ukázáno na [videu](https://www.youtube.com/watch?v=D_1Op4TBM-Y).

2 Praktické příklady
====================
### Step 0 - Založení projektu
* Spustit Visual Studio 2015;
* File > New > Project > Console Application (Installed - Templates - Visual C# - Windows).

### Step 1 - Hello World
* do těla metody `Main()` vepsat následující kód:
```c#
Console.WriteLine("Hello world");
Console.ReadKey();
```
* vyčistit kód:
  * odstranit zbytečné `using` direktivy;
  * odstranit zbytečné vstupní argumenty metody `Main()`.
```c#
using System;

namespace JezekT.SkoleniCS.Zaklady.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
        }
    }
}
```
* spustit aplikaci v režimu ladění - tlačítko `Start` nebo klávesa `F5`;
* dojde ke kompilaci souborů a ke spuštění aplikace;
* objeví se konzole s nápisem "Hello World";
* jakoukoliv klávesou konzoli ukončit.

>Bonus - Stejný program nyní vytvořit bez Visual Studia za pomoci `csc.exe`.

### Step 2 - Datové typy, proměnné a výrazy
* přehled datových typů je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/types-and-variables);
* deklarace proměnných
```c#
// Explicitní typování
int x; // deklarace proměnné
x = 1000000; // naplnění proměnné hodnotou
byte y = 125; // deklarace proměnné a naplnění hodnotou

// Implicitní typování - o typu rozhodne kompilátor
var soucet = x + y; // deklarace proměnné a naplnění hodnotou
```
* implicitní a explicitní přetypování je popsáno [zde](https://msdn.microsoft.com/cs-cz/library/ms173105.aspx)
```c#
int x = 150;
byte y = 1;
int soucet = x + y;

// Implicitní přetypování
long z = x; // implicitní převod typu int (32 bit) na typ long (64 bit)
//y = x; // nelze provést - nelze zapsat hodnotu typu int (32 bit) do proměnné typu byte (8 bit)
x = y; // lze provést - proměnná y je typu byte a její hodnotu lze zapsat do proměnné typu int

// Explicitní přetypování
y = (byte) soucet;
```
* převod řetězce na číslo
```c#
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
```

* výrazy jsou uvedeny [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/expressions).

### Step 3 - Výčtové typy
* popis výčtových typů je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/enums).
```c#
public enum DruhVystupu
{
    Informace,
    Varovani,
    Chyba
}
```
* použití výčtového typu
```c#
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

```
### Step 4 - Příkazy
* přehled příkazů je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/statements).
