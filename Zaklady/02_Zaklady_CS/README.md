2 Z�klady C#
============

### 1 - Zalo�en� projektu
* Spustit Visual Studio 2015;
* File > New > Project > Console Application (Installed - Templates - Visual C# - Windows).

### 2 - Hello World
* do t�la metody `Main()` vepsat n�sleduj�c� k�d:
```c#
Console.WriteLine("Hello world");
Console.ReadKey();
```
* vy�istit k�d:
  * odstranit zbyte�n� `using` direktivy;
  * odstranit zbyte�n� vstupn� argumenty metody `Main()`.
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
* spustit aplikaci v re�imu lad�n� - tla��tko `Start` nebo kl�vesa `F5`;
* dojde ke kompilaci soubor� a ke spu�t�n� aplikace;
* objev� se konzole s n�pisem "Hello World";
* jakoukoliv kl�vesou konzoli ukon�it.

>Bonus - Stejn� program nyn� vytvo�it bez Visual Studia za pomoci textov�ho editoru a `csc.exe`.

### 3 - Datov� typy, prom�nn� a v�razy
* p�ehled datov�ch typ� je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/types-and-variables);
* deklarace prom�nn�ch
```c#
// Explicitn� typov�n�
int x; // deklarace prom�nn�
x = 1000000; // napln�n� prom�nn� hodnotou
byte y = 125; // deklarace prom�nn� a napln�n� hodnotou

// Implicitn� typov�n� - o typu rozhodne kompil�tor
var soucet = x + y; // deklarace prom�nn� a napln�n� hodnotou
```
* implicitn� a explicitn� p�etypov�n� je pops�no [zde](https://msdn.microsoft.com/cs-cz/library/ms173105.aspx)
```c#
int x = 150;
byte y = 1;
int soucet = x + y;

// Implicitn� p�etypov�n�
long z = x; // implicitn� p�evod typu int (32 bit) na typ long (64 bit)
//y = x; // nelze prov�st - nelze zapsat hodnotu typu int (32 bit) do prom�nn� typu byte (8 bit)
x = y; // lze prov�st - prom�nn� y je typu byte a jej� hodnotu lze zapsat do prom�nn� typu int

// Explicitn� p�etypov�n�
y = (byte) soucet;
```
* p�evod �et�zce na ��slo
```c#
string text = "text";
//int i = text; // nelze p�etypovat string na typ int
int i = int.Parse(text); // v tomto p��pad� dojde b�hem p�etypov�n� k v�jimce
i = int.Parse("1256"); // �et�zec "1256" bude p�eveden na cel� ��slo 1256

if (int.TryParse(text, out i))
{
	Console.WriteLine("P�etypov�n� se zda�ilo.");
}
else
{
	Console.WriteLine("Nelze p�etypovat.");
}
```
* v�razy jsou uvedeny [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/expressions).

### 4 - V��tov� typy
* popis v��tov�ch typ� je uveden [zde](https://docs.microsoft.com/cs-cz/dotnet/articles/csharp/tour-of-csharp/enums).
```c#
public enum DruhVystupu
{
    Informace,
    Varovani,
    Chyba
}
```
* pou�it� v��tov�ho typu
```c#
static void Main()
{
    VypisVystup("Toto je informace.", DruhVystupu.Informace);
    VypisVystup("Toto je varov�n�.", DruhVystupu.Varovani);
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

