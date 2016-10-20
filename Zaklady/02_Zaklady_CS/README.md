2 Základy C#
============

### 1 - Založení projektu
* Spustit Visual Studio 2015;
* File > New > Project > Console Application (Installed - Templates - Visual C# - Windows).

### 2 - Hello World
* do tìla metody `Main()` vepsat následující kód:
```c#
Console.WriteLine("Hello world");
Console.ReadKey();
```
* vyèistit kód:
  * odstranit zbyteèné `using` direktivy;
  * odstranit zbyteèné vstupní argumenty metody `Main()`.
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
* spustit aplikaci v režimu ladìní - tlaèítko `Start` nebo klávesa `F5`;
* dojde ke kompilaci souborù a ke spuštìní aplikace;
* objeví se konzole s nápisem "Hello World";
* jakoukoliv klávesou konzoli ukonèit.

>Bonus - Stejný program nyní vytvoøit bez Visual Studia za pomoci textového editoru a `csc.exe`.

### 3 - Datové typy, promìnné a výrazy
* pøehled datových typù je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/types-and-variables);
* deklarace promìnných
```c#
// Explicitní typování
int x; // deklarace promìnné
x = 1000000; // naplnìní promìnné hodnotou
byte y = 125; // deklarace promìnné a naplnìní hodnotou

// Implicitní typování - o typu rozhodne kompilátor
var soucet = x + y; // deklarace promìnné a naplnìní hodnotou
```
* implicitní a explicitní pøetypování je popsáno [zde](https://msdn.microsoft.com/cs-cz/library/ms173105.aspx)
```c#
int x = 150;
byte y = 1;
int soucet = x + y;

// Implicitní pøetypování
long z = x; // implicitní pøevod typu int (32 bit) na typ long (64 bit)
//y = x; // nelze provést - nelze zapsat hodnotu typu int (32 bit) do promìnné typu byte (8 bit)
x = y; // lze provést - promìnná y je typu byte a její hodnotu lze zapsat do promìnné typu int

// Explicitní pøetypování
y = (byte) soucet;
```
* pøevod øetìzce na èíslo
```c#
string text = "text";
//int i = text; // nelze pøetypovat string na typ int
int i = int.Parse(text); // v tomto pøípadì dojde bìhem pøetypování k výjimce
i = int.Parse("1256"); // øetìzec "1256" bude pøeveden na celé èíslo 1256

if (int.TryParse(text, out i))
{
	Console.WriteLine("Pøetypování se zdaøilo.");
}
else
{
	Console.WriteLine("Nelze pøetypovat.");
}
```
* výrazy jsou uvedeny [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/expressions).

### 4 - Výètové typy
* popis výètových typù je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/enums).
```c#
public enum DruhVystupu
{
    Informace,
    Varovani,
    Chyba
}
```
* použití výètového typu
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

