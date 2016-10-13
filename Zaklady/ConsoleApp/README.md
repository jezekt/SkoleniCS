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