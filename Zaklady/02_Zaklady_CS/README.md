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

