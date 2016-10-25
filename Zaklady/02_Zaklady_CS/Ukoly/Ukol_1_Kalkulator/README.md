Úkol è. 1 - Kalkulátor
======================

### Zadání
* vytvoøte konzolovou aplikaci, která bude umožòovat provádìt základní matematické operace (sèítání, odèítání, násobení, dìlení) na dvou èíslech.

### Step 1 - Základní forma
* takto mùže vypadat jeden z prvních programù pøi absolvování školení
```c#
Console.WriteLine("Zadejte první èíslo:");
string prvniCisloText = Console.ReadLine();
int prvniCislo = int.Parse(prvniCisloText);

Console.WriteLine("Zadejte druhé èíslo:");
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
```
* program je sice funkèní, ale má nìkolik nedostatkù
	* není zde ošetøen vstup uživatele - pokud bude do programu zadána hodnota, kterou program neoèekává (napø. písmeno místo èísla), tak program spadne;
	* program by mohl bìžet ve smyèce, dokud se ho uživate nerozhodne zavøít sám.

