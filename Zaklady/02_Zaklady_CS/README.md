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

