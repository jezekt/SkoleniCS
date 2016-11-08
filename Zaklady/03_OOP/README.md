3 Objektově orientované programování
====================================

* česky psaný tutoriál k základům OOP je [zde](http://www.itnetwork.cz/csharp/oop);

### 1 Objekty
* v [úkolech](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly) předchozího bloku se vytvářel kalkulátor, který bude schopný provádět základní matematické operace;
* v [prvním úkolu](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_1_Kalkulator#Úkol-č-1---kalkulátor) byl vytvořen funkční program, ve kterém byl ošetřen vstup uživatele. Celý kód byl však součástí souboru `Program.cs`. Takový zápis by se s přibývající funkčností stal nepřehledný;
* výsledkem [druhého úkolů](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_2_Trida_Kalkulator#Úkol-č-2---třída-kalkulátor) tedy bylo přepsání kódu do tříd. Byly stanoveny tři oblasti (*matematické operace*, *čtení vstupu* a *řízení procesu výpočtu*), za které zodpovídaly tři různé třídy. Vytvoření tříd, které jsou zodpovědné za určitou oblast, byl první krok k přechodu ze *strukturovaně* psaného kódu na *objektově* psaný kód. Při spuštění programu jsou vždy vytvořeny tři objekty, které zabezpečují výpočet.

>Poznámka - Třída reprezentuje datový typ, který je vytvořen programátorem (např. [string](https://msdn.microsoft.com/en-us/library/362314fe.aspx) - alias pro datový typ `System.String`, je definován ve třídě [String](https://msdn.microsoft.com/en-us/library/system.string.aspx)). Třída [Kalkulator](https://github.com/jezekt/SkoleniCS/tree/master/Zaklady/02_Zaklady_CS/Ukoly/Ukol_2_Trida_Kalkulator#třída-kalkulátor) je tedy datový typ, ve kterém je definováno, jak provádět základní matematické operace (*sčítání*, *odčítání*, *násobení* a *dělení*). Samotné provedení těcho operací však vykonává *objekt*, který je datového typu `Kalkulator` - ¹jinak řečeno instance třídy `Kalkulator`.
>
>¹ mezi objektem a instancí je určitý rozdíl - pro potřeby pochopení OOP budou pokládány za rovnocenné termíny.


#### Zjednodušený příklad
„Představte si třídu jako návod na sestavení nějakého stroje např. robota. Třída `Kalkulator` definuje robota, který umí počítat. Pokud chci, využívat funkčnost takového robota, tak jej musím nejprve vytvořit. To udělám pomocí klíčového slova *new* (např. *var robotPoctar = new Kalkulator()*). 

Vznikne mi tak nový objekt/robot typu `Kalkulator`, který je schopen provádět sčítání, odčítání, násobení a dělení. Když chci znát výsledek součtu dvou čísel, tak se zeptám vytvořeného robota, který byl přiřazen do proměnné *robotPoctar*. Dotaz na výsledek bude vypadat takto: *var vysledekSouctu = robotPoctar.GetSoucet(1, 1)*. 

Dále potřebuji nějakého robota, který bude číst vstup uživatele. K tomu mi bude sloužit robot typu `ConsoleInputReader`. Opět si ho vytvořím pomocí slovíčka *new*. Mám tedy již dva roboty - jeden, který umí počítat a druhý, který umí číst z konzole. 

Potřeboval bych ještě nějakého, který využije ty dva a společně tak uživateli umožní používat konzoli, jako jednoduchou kalkulačku. K takovému účelu si vytvořím robota typu `ConsoleEquationSolver` a při jeho stavbě použiji dva zmíněné roboty. Sestavený robot typu `ConsoleEquationSolver` poté samostatně řídí průběh výpočtu (od čtení z konzole, přes výpočet až po výpis výsledku).“

>Poznámka - Ve zjednodušeném příkladu se programátor na kód nedívá jako na výčet proměnných a metod poskládaných do funkčního celku, ale chápe ho jako prostředek, pomocí kterého vytváří vlastní prostředí, kde **objekty** zabezpečují fungování systému.