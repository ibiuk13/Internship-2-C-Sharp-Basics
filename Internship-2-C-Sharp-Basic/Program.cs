using System;
using System.Collections.Generic;
using System.Linq;

namespace Internship_2_C_Sharp_Basic
{
    class Program
    {
        public static void Izbornik()
        {
            Console.WriteLine("Izbornik: \n1 - Ispis cijele liste \n" +
                "2 - Ispis imena pjesme unosom pripadajućeg rednog broja \n" +
                "3 - Ispis rednog broja pjesme unosom pripadajućeg imena \n" +
                "4 - Unos nove pjesme \n" +
                "5 - Brisanje pjesme po rednom broju \n" +
                "6 - Brisanje pjesme po imenu \n" +
                "7 - Brisanje cijele liste \n" +
                "8 - Uređivanje imena pjesme \n" +
                "9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi \n" +
                "10 - Shuffle pjesama \n" +
                "0 - Izlaz iz aplikacije \n");
        }
        private static Random rng = new Random();
        public static void Shuffle(Dictionary<int, string> dictionary)
        {
            Random rand = new Random();
            var lista1 = new List<int>();
            var lista2 = new List<string>();
            foreach (var pair in dictionary)
            {
                lista1.Add(pair.Key);
                lista2.Add(pair.Value);
                dictionary.Remove(pair.Key);
            }
            int n = lista2.Count;
            while(n>1)
            {
                n--;
                int a= rng.Next(n + 1);
                Swap(lista2, a, n); 
            }
            for (int i = lista1.Count - 1; i >= 0; i--)
            {
                dictionary.Add(lista1[i], lista2[i]);
            }

        }
        public static void Swap(List<string> list, int indexA, int indexB)
        {
            string tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        static void Ispis(Dictionary<int, string> dictionary)
        {
            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair.Key + ". " + pair.Value + "\n");
            }

        }
        static void IspisImena(int n, Dictionary<int, string> dictionary)
        {
            if(dictionary.ContainsKey(n)) Console.WriteLine(dictionary[n] + "\n");
            else Console.WriteLine("Nema pjesme s traženim brojem \n");
        }
        static void IspisBroja(string name, Dictionary<int, string> dictionary)
        {
            int c = 0;
            foreach (var pair in dictionary)
            {
                if (pair.Value == name) { Console.WriteLine(pair.Key + "\n"); c++; }
            }
            if (c == 0) Console.WriteLine("Nema pjesme s traženim imenom \n");
        }
        static void Dodaj(int br, string nova, Dictionary<int, string> dictionary)
        {
            foreach (var pair in dictionary)
            {
                if (pair.Value == nova) { Console.WriteLine("Ta pjesma vec postoji \n"); return; }
            }
            dictionary.Add(br, nova);
        }
        static void ObrisiBr(int br, Dictionary<int, string> dictionary)
        {
            dictionary.Remove(br);
            var lista1 = new List<int>();
            var lista2 = new List<string>();
            foreach (var pair in dictionary)
            {
                if (pair.Key > br)
                {
                    lista1.Add(pair.Key);
                    lista2.Add(pair.Value);
                    dictionary.Remove(pair.Key);
                }
            }
                dictionary.Remove(br);
            for (int i = lista1.Count - 1; i >= 0; i--)
            {
                dictionary.Add(lista1[i] - 1, lista2[i]);
            }

        }
        static void ObrisiIme(string name, Dictionary<int, string> dictionary)
        {
            var k= new int();
            var lista1 = new List<int>();
            var lista2 = new List<string>();
            foreach (var pair in dictionary)
            {
                if (pair.Value == name) { k = pair.Key; dictionary.Remove(pair.Key);}
            }
    
            foreach (var pair in dictionary)
            {
                if (pair.Key > k)
                {
                    lista1.Add(pair.Key);
                    lista2.Add(pair.Value);
                    dictionary.Remove(pair.Key);
                }
            }
            
            for (int i = lista1.Count - 1; i >= 0; i--)
            {
                dictionary.Add(lista1[i] - 1, lista2[i]);
            }
        }
        static void ObrisiList(Dictionary<int, string> dictionary)
        {
            foreach (var pair in dictionary) dictionary.Remove(pair.Key);
        }
        static void PromjenaIme(int br, string ime, Dictionary<int, string> dictionary)
        {
            if (dictionary.ContainsKey(br)) dictionary[br] = ime;
            else Console.WriteLine("Nema pjesme s traženim brojem \n");
        }
        static void Premjesti(int stari, int novi , Dictionary<int, string> dictionary)
        {
            var lista1 = new List<int>();
            var lista2 = new List<string>();


            foreach (var pair in dictionary)
            {
                lista1.Add(pair.Key);
                lista2.Add(pair.Value);
                dictionary.Remove(pair.Key);
            }
            var lista3 = new List<string>();
            if (novi < stari)
            {
                for (int i = 0; i < lista2.Count; i++)
                {
                    if (i < novi-1) lista3.Add(lista2[i]); 
                }
                lista3.Add(lista2[stari-1]);
                for(int i=novi-1;i<lista2.Count;i++)
                {
                    if(lista2[i]!=lista2[stari-1]) lista3.Add (lista2[i]);
                }
            }
            else
            {
                for (int i = 0; i < lista2.Count; i++)
                {
                    if (i < stari-1) lista3.Add(lista2[i]);
                }
                for(int i=0;i<novi-stari;i++) Swap(lista2, stari-1+i, stari+i);
                for (int i = stari-1; i < lista2.Count; i++) lista3.Add(lista2[i]);

            }
            for (int i = lista1.Count - 1; i >=0; i--)
            {
                dictionary.Add(lista1[i], lista3[i]);
            }
        }
    
        static void Main(string[] args)
        {
            Izbornik();

            var playlist = new Dictionary <int, string>()
            {
                { 1 , "Swedish House Mafia - Don't You Worry Child"},
                { 2 , "Avicii - The Nights"},
                { 3 , "Ivana Brkic - Oci Boje Kestena"},
                { 4 , "Prljavo Kazaliste - Marina"},
                { 5 , "Daleka Obala - Noc Je Prekrasna"},
                { 6 , "In Vivo - Tu tu tu" },
                { 7, "50 Cent - In Da Club" }
            };
            var izbor = new int();
            var br = 7;
            do
            {
                izbor = int.Parse(Console.ReadLine());
                switch (izbor)
                { 
                    case 1:
                        {
                            Ispis(playlist);
                            Console.WriteLine("Želite li se vratiti na izbornik? \n 1 - DA     0 - NE \n");
                            var a = int.Parse(Console.ReadLine());
                            if (a == 1) { Izbornik(); break; }
                            else break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Unesite željeni broj: \n");
                            var n = int.Parse(Console.ReadLine());
                            IspisImena(n, playlist);
                            Console.WriteLine("Želite li se vratiti na izbornik? \n 1 - DA     0 - NE \n");
                            var a = int.Parse(Console.ReadLine());
                            if (a == 1) { Izbornik(); break; }
                            else break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Unesite ime tražene pjesme: \n");
                            string ime = Console.ReadLine();
                            IspisBroja(ime, playlist); Console.WriteLine("Želite li se vratiti na izbornik? \n 1 - DA     0 - NE \n");
                            var a = int.Parse(Console.ReadLine());
                            if (a == 1) { Izbornik(); break; }
                            else break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Unesite ime pjesme koju želite dodati");
                            string novaPjesma = Console.ReadLine();
                            Console.WriteLine("Želite li dodati novu pjesmu \n 1 - DA     0 - NE \n");
                            var b = int.Parse(Console.ReadLine());
                            if (b == 1)
                            {
                                br++; Dodaj(br, novaPjesma, playlist); break;
                            }
                            else break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Unesite redni broj pjesme koju želite izbrisati: \n");
                            var b = int.Parse(Console.ReadLine());
                            Console.WriteLine("Želite li obrisati pjesmu na " + b + ". mjestu \n 1 - DA     0 - NE \n");
                            var x = int.Parse(Console.ReadLine());
                            if (x == 1) { ObrisiBr(b, playlist); break; }
                            else break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Unesite ime pjesme koju želite izbrisati: \n");
                            string b = Console.ReadLine();
                            Console.WriteLine("Želite li obrisati pjesmu sa sljedećim imenom: " + b + " \n 1 - DA     0 - NE \n");
                            var x = int.Parse(Console.ReadLine());
                            if (x == 1) { ObrisiIme(b, playlist); break; }
                            else break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Želite li obrisati cijelu listu? \n 1 - DA     0 - NE \n");
                            var x = int.Parse(Console.ReadLine());
                            if (x == 1) { ObrisiList(playlist); break; }
                            else break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Unesite redni broj pjesme kojoj želite promijeniti ime: \n");
                            var b = int.Parse(Console.ReadLine());
                            Console.WriteLine("Unesite novo ime pjesme: \n");
                            string novo = Console.ReadLine();
                            Console.WriteLine("Želite li promijeniti ime pjesmi na " + b + ". mjestu \n 1 - DA     0 - NE \n");
                            var a = int.Parse(Console.ReadLine());
                            if (a == 1) { PromjenaIme(b,novo, playlist); break; }
                            else break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Unesite redni broj pjesme koju želite premjestiti: \n");
                            var stari= int.Parse(Console.ReadLine());
                            Console.WriteLine("Unesite novi redni broj za tu pjesmu: \n");
                            var novi= int.Parse(Console.ReadLine());
                            Console.WriteLine("Želite li premjestiti pjesmu sa " + stari + ". mjesta na " + novi +". mjesto \n 1 - DA     0 - NE \n");
                            var x = int.Parse(Console.ReadLine());
                            if (x == 1) { Premjesti(stari, novi, playlist);  break; }
                            else break;
                        }
                    case 10:
                        {
                            Console.WriteLine("Želite li shuffleati listu?\n 1 - DA     0 - NE \n");
                            var x = int.Parse(Console.ReadLine());
                            if (x == 1) { Shuffle(playlist); break; }
                            else break;

                        }
                }
            } while (izbor != 0);                            
            }
        }
    }


