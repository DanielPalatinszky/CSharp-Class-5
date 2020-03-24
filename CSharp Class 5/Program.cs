using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Class_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var szam = 10;
            Method1(szam);

            var tomb = new int[2];
            Method1(tomb);

            Method2(null); // Hiba lesz

            // Paraméterátadásnál ugyanúgy használhatunk kifejezéseket, mint bárhol máshol
            // Mindaddig helyes az átadés, amíg a típus megfelelő
            Method3(Method3());

            //--------------------------------------------------

            // Kollekciók: különböző típusú adatszerkezetek, amelyek valamilyen módon tárolják/visszaadják a bennük tárolt elemeket
            // Mi határozzuk meg mit tároljanak
            // using System.Collections.Generic;

            //--------------------------------------------------

            // Első kollekció amit megnézünk a lista
            // Lista: tetszőleges számú elemet képes tárolni azáltal, hogy a mérete dinamikusan változik ahogy újabb és újabb elemeket helyezünk el benne
            // A háttérben tömböt használ, de a kezelését elrejti előlünk
            // A relációs jelek közé írhatjuk be, hogy milyen típust tároljon:
            var list1 = new List<int>();

            // Kezdeti elemeket is adhatunk meg
            // Ilyenkor a zárójelek elhagyhatóak
            var list2 = new List<int> { 1, 2, 3 };

            // Új elem hozzáadása:
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);

            // Lekérhetjük mennyi elem fér bele jelenleg:
            Console.WriteLine(list2.Capacity);

            // Illetve lekérhetjük mennyi elem van pontosan benne (analóg a tömb Lengthe-el):
            Console.WriteLine(list2.Count);

            // Ha elérjük a kapacitást, akkor a háttérben egy dupla akkora tömböt fog lefoglalni, melybe áthelyezi a régi elemekt és mellé helyezi az újat
            // Ez egy lassú folyamat, főleg ha nagyon sok elem van a listában

            // Mi magunk is megadhatjuk kezdetben mekkora legyen a kapacitása:
            var list3 = new List<string>(10);

            // Indexelhetjük is:
            Console.WriteLine(list3[2]);

            // foreach is megy:
            foreach (var element in list3)
            {
                Console.WriteLine(element);
            }

            // Minden művelet megy ami egy tömbön:
            Console.WriteLine(list2.Sum());
            Console.WriteLine(list2.First());
            Console.WriteLine(list2.Last());
            // stb.

            // Egy teljes listát hozzáadhatunk egy másikhoz (amennyiben a típus megfelelő):
            list1.AddRange(list2);

            // Törölhetünk minden elemet:
            list1.Clear();

            // Lekérhetjük egy adott elem indexét
            var index = list2.IndexOf(2);

            // Törölhetünk egy adott elemet (balról az első előfordulás):
            list2.Remove(2);

            // Törölhetünk egy adott indexű elemet:
            list2.RemoveAt(2);

            // Beszúrhatunk egy elemet, egy adott indexre (a megadott indextől kezdve az összes elem csúszik egyet jobbra):
            list2.Insert(3, 2);

            // Készíthetünk belőle tömböt:
            var array = list2.ToArray();

            // Mikor használjuk a listákat?
            // Ha nem tudjuk pontosan hány elemet kell majd tárolnunk (ha tudjuk, akkor tömb) (pl. egy diák osztályzatai)

            //--------------------------------------------------

            // Második kollekció a dictionary
            // A dictionary kulcs-érték párokat használ
            // Azaz odaadunk neki egy kulcsot és ő visszaadja a kulcshoz tartozó értéket (nagyon gyors)
            // A relációs jelek között az első típus a kulcs típusa, a második az értéké
            var dict1 = new Dictionary<int, string>();

            // Létrehozhatjuk kezdeti értékekkel is (figyeljünk a belső blokkokra - első a kulcs, második az érték):
            var dict2 = new Dictionary<string, int>
            {
                { "Egy", 1 },
                { "Kettő", 2 }
            };

            // Egy szemléletes példa:
            var napokNeveiSorszamSzerint = new Dictionary<int, string>
            {
                { 1, "Hétfő" },
                { 2, "Kedd" },
                { 3, "Szerda" },
                { 4, "Csütörtök" },
                { 5, "Péntek" },
                { 6, "Szombat" },
                { 7, "Vasárnap" },
            };

            // Indexként megadhatjuk a kulcsot és ő visszaadja az értéket:
            Console.WriteLine(napokNeveiSorszamSzerint[2]); // Kedd
            Console.WriteLine(napokNeveiSorszamSzerint[4]); // Csütörtök
            Console.WriteLine(napokNeveiSorszamSzerint[7]); // Vasárnap

            // Fordítva is megy:
            var napokSorszamaiNevSzerint = new Dictionary<string, int>(7) // Kapacitás is megadható
            {
                { "Hétfő", 1 },
                { "Kedd", 2 },
                // stb.
            };

            // Vegyük észre, hogy az index nem az, hogy hanyadik elemet szeretnénk, hanem a kulcs a megfelelő típussal:
            Console.WriteLine(napokSorszamaiNevSzerint["Kedd"]); // 2

            // Hozzáadás (ha elérjük a kapacitást, ugyanúgy dinamikusan nőni fog, tehát bármennyi kulcs-érték párt tárolhat):
            napokSorszamaiNevSzerint.Add("Szerda", 3);

            // A hozzáadás hibát dob, ha egy létező kulcsot akarunk hozzáadni:
            napokSorszamaiNevSzerint.Add("Hétfő", 1); // Hiba

            // De akkor hogyan írhatunk felül elemet?
            // Megoldás: indexelés
            // Ha indexelünk, akkor ha még nem volt benne az adott kulcs a dictionary-ben akkor elhelyezi benne a megfelelő értékkel
            // Ha már benne volt, akkor felülírja az értéket
            napokSorszamaiNevSzerint["Hétfő"] = 7; // Felülírja a hétfő kulcs mögötti értéket
            Console.WriteLine(napokSorszamaiNevSzerint["Hétfő"]); // 7

            // foreach is megy, azonban kulcs-érték párokat kapunk:
            foreach (var napNeveSorszamSzerint in napokNeveiSorszamSzerint)
            {
                Console.WriteLine($"Kulcs: {napNeveSorszamSzerint.Key} Érték: {napNeveSorszamSzerint.Value}");
            }

            // Szokásos tömb műveletek működnek + Capacity, Count, Clear (mint listánál)
            // Van-e benne adott kulcs:
            var vanE1 = napokNeveiSorszamSzerint.ContainsKey(1);

            // Van-e benne adott érték:
            var vanE2 = napokNeveiSorszamSzerint.ContainsValue("Kedd");

            // Adott kulcsú elem törlése
            napokNeveiSorszamSzerint.Remove(1);

            // Kulcs-érték listává alakíthatjuk:
            var list4 = napokSorszamaiNevSzerint.ToList();

            // Itt fontos megjegyezni, hogy a kollekciók tetszőlegesen összetett típusokat képesek tárolni
            // Például:
            var dict3 = new Dictionary<int, List<string>>();
            dict3.Add(0, new List<string> { "A", "B", "C" });

            //--------------------------------------------------

            // Harmadik kollekció a tuple
            // A tuple tetszőleges típusokat képes tárolni egymás mellett
            // Például (csak úgy hozhatjuk létre, ha rögtön meg is adjuk az elemeket):
            var tuple1 = new Tuple<int, float, string, double, bool>(1, 2.1f, "A", 3.0, false);

            // ItemX-el érhetjük el az elemeket
            Console.WriteLine(tuple1.Item2); // 2.1f
            Console.WriteLine(tuple1.Item5); // false
            // stb.

            // Vegyük észre: egy tuple-t felhasználhatunk arra, hogy egy metóduból egyszerre több értékkel térjünk vissza
            var tuple2 = Method4();
            // Azonban ez nem a legszebb és jobb módszerek is vannak erre, amiket majd később veszünk

            // Egyszerűbb tuple létrehozási módszerek is vannak, de ezekről is majd később

            //--------------------------------------------------

            // A negyedik kollekciónk a queue, avagy sor
            // A sor egy FIFO (first-in-first-out) adatszerkezet, azaz az első elem amit beleteszünk, azt tudjuk legelőször kivenni
            // Létrehozás:
            var queue = new Queue<int>(); // kapacitás megadás lehetséges itt is

            // Ritkán hozzuk létre kezdeti elemekkel, de a listáknál látható módon megtehető

            // Elem elhelyezése:
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Legelső elem kivétele:
            Console.WriteLine(queue.Dequeue()); // 1, hiszen őt tettük bele legelőször
            Console.WriteLine(queue.Dequeue()); // 2
            Console.WriteLine(queue.Dequeue()); // 3, innentől üres a sor

            queue.Enqueue(10);
            queue.Enqueue(11);

            // Megtudjuk nézni a legelső elemet, anélkül, hogy kivennénk:
            var legelso = queue.Peek(); // 10

            // foreach is megy, de ritkán szoktuk
            foreach (var element in queue)
            {
                Console.WriteLine(element);
            }

            // Szokásos tömbös műveletek mennek + Capacity, Count mint listáknál

            // Mikor használjuk?
            // Amikor fontos a feldolgozás sorrendisége (pl. banki átutalás)

            //--------------------------------------------------

            // Az ötödik kollekciónk a stack, azaz verem
            // A verem egy LIFO (last-in-first-out) adatszerkezet, azaz az utolsó elem amit beleteszünk, azt tudjuk legelőször kivenni
            // Létrehozás:
            var stack = new Stack<int>(); // kapacitás megadás lehetséges itt is

            // Ritkán hozzuk létre kezdeti elemekkel, de a listáknál látható módon megtehető

            // Elem elhelyezése:
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Legutolsó elem kivétele:
            Console.WriteLine(stack.Pop()); // 3, hiszen őt tettük bele utoljára
            Console.WriteLine(stack.Pop()); // 2, 
            Console.WriteLine(stack.Pop()); // 1, innentől üres a stack

            stack.Push(10);
            stack.Push(11);

            // Megtudjuk nézni a legutolsó elemet, anélkül, hogy kivennénk:
            var legutolso = stack.Peek(); // 11

            // foreach is megy, de ritkán szoktuk
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            // Szokásos tömbös műveletek mennek + Capacity, Count mint listáknál

            // Mikor használjuk?
            // Amikor fontos a feldolgozás sorrendisége (pl. kártyajátékok)

            //--------------------------------------------------

            // A hatodik és egyben utolsó kollekciónk (mostanra) a hash set, azaz halmaz
            // A halmaz egyedi elemeket képes tárolni, azaz ha megpróbálunk egy olyan elemet elhelyezni benne amit már tárol, akkor eldobja
            // Létrehozás:
            var hashSet = new HashSet<int>(); // kapacitás megadás lehetséges itt is

            // Ritkán hozzuk létre kezdeti elemekkel, de a listáknál látható módon megtehető

            // Elemek elhelyezése mint listáknál:
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(3);

            // Azonban ha megpróbáljuk az egyik más tárolt elemet elhelyezni, akkor nem történik semmi:
            Console.WriteLine(hashSet.Count); // 3
            hashSet.Add(2);
            Console.WriteLine(hashSet.Count); // 3

            // foreach is megy
            foreach (var element in hashSet)
            {
                Console.WriteLine(element);
            }

            // Szokásos tömb műveletek működnek + Capacity, Count, Remove stb. mint listáknál

            // Mikor használjuk?
            // Amikor egyediséget szeretnénk kikényszeríteni

            // Például egyszerű lottó:
            var random = new Random();
            var lotto = new HashSet<int>(5);
            while (lotto.Count < 5)
            {
                lotto.Add(random.Next(1, 91));
            }

            //--------------------------------------------------

            // Rengeteg típusú kollekció van és sajátot is készíthetünk (később), de ezek a leggyakoribbak
        }

        // Korábban láttuk, hogy a változók érték szerint adódnak át
        // Azaz a metódusban a változó értékének módosítása nincs hatással az eredeti változóra
        static void Method1(int n)
        {
            n = 0;
        }

        // A tömbök átadása a tömb memóriacíme szerint történik
        // Emiatt a metódusban a tömbön végzett módosítások, az eredeti tömböt módosítják
        // Vegyük észre, hogy a paraméterátadás továbbra is érték szerint történik, csak ebben az esetben az érték maga a tömb memóriacíme
        static void Method1(int[] t)
        {
            t[0] = 2;
        }

        // Ügyeljünk arra, hogy a tömbök felvehetnek null értéket is (nincs memória foglalva a tömbnek)
        static void Method2(int[] t)
        {
            t[1] = 0; // Hiba, ha null a tömb
        }

        static int Method3()
        {
            return 2;
        }

        static void Method3(int n)
        {

        }

        static Tuple<int, string> Method4()
        {
            return new Tuple<int, string>(1, "A");
        }
    }
}
