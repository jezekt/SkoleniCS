�kol �. 1 - Kalkul�tor
======================

### Zad�n�
* vytvo�te konzolovou aplikaci, kter� bude umo��ovat prov�d�t z�kladn� matematick� operace (s��t�n�, od��t�n�, n�soben�, d�len�) na dvou ��slech.

### Step 1 - Z�kladn� forma
* takto m��e vypadat jeden z prvn�ch program� p�i absolvov�n� �kolen�
```c#
Console.WriteLine("Zadejte prvn� ��slo:");
string prvniCisloText = Console.ReadLine();
int prvniCislo = int.Parse(prvniCisloText);

Console.WriteLine("Zadejte druh� ��slo:");
string druheCisloText = Console.ReadLine();
int druheCislo = int.Parse(druheCisloText);

Console.WriteLine("Zadejte operand:");
string operand = Console.ReadLine();

Console.WriteLine("V�sledek:");
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
* program je sice funk�n�, ale m� n�kolik nedostatk�
	* nen� zde o�et�en vstup u�ivatele - pokud bude do programu zad�na hodnota, kterou program neo�ek�v� (nap�. p�smeno m�sto ��sla), tak program spadne;
	* program by mohl b�et ve smy�ce, dokud se ho u�ivate nerozhodne zav��t s�m.

