﻿using System;
using System.Collections.Generic;
namespace playlistDump
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            var playlist = new Dictionary<int, string>(){
                {1,"Konan"},
                {2,"Drei Millionen"},
                {3,"Model"},
                {4,"Swaguša"},
                {5,"Hayabusa"},
                {6,"Pazar"},
                {7,"Umjetnik Erotike"},
                {8,"Swag Iznad Svega"},
                {9,"Mejaši"},
                {10,"Skidaj Gaće"},
                {11,"Komuna"},
                {12,"Daj Pare"}
            };
            var nastavi=true;
            while(nastavi){                                         
                nastavi = Menu(playlist);                                                           //nastavi je bool koji govori oce li se program nastaviti, tu je cisto zbog switch casea 0
            }
            return;
        }

        public static bool Menu(Dictionary<int, string> dict){
            Boolean palivozi= true;                                                                //palivozi isto bool, koristimo ga da odredimo nastavi poslije zavrsene funkcije
            System.Console.WriteLine(" Odaberite akciju:");
            System.Console.WriteLine(" 1 - Ispis cijele liste");
            System.Console.WriteLine(" 2 - Ispis imena pjesme unosom pripadajućeg rednog broja");
            System.Console.WriteLine(" 3 - Ispis rednog broja pjesme unosom pripadajućeg imena");
            System.Console.WriteLine(" 4 - Unos nove pjesme");
            System.Console.WriteLine(" 5 - Brisanje pjesme po rednom broju");
            System.Console.WriteLine(" 6 - Brisanje pjesme po imenu");
            System.Console.WriteLine(" 7 - Brisanje cijele liste");
            System.Console.WriteLine(" 8 - Uređivanje imena pjesme");
            System.Console.WriteLine(" 9 - Uređivanje rednog broja pjesme");
            System.Console.WriteLine("10 - Shuffle liste");
            System.Console.WriteLine(" 0 - Izlaz iz aplikacije");
            var odabir = int.Parse(Console.ReadLine());                                           //tempInt, tempInt2 i tempStr su nekakvi placeholderi koje koristim u vecini opcija u zadatku
            var tempInt=0;
            var tempInt2=0;
            var tempStr="";
            switch(odabir){
                case 0:
                    palivozi=false;
                    break;
                case 1:
                    System.Console.WriteLine("Playlista sadrzi slijedece pjesme");
                    foreach(var pair in dict)
                    {
                        Console.WriteLine(pair.Key+". "+pair.Value);
                    }
                    break;
                case 2:
                    System.Console.WriteLine("Unesite redni broj pjesme koje zelite da se ispise: ");
                    tempInt = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Pjesma pod rednim brojem "+tempInt+" je "+dict[tempInt]+".");
                    break;
                case 3:
                    System.Console.WriteLine("unesite ime pjesme ciji redni broj zelite da se ispise");
                    tempStr = Console.ReadLine();
                    foreach(var pair in dict){                                                  //foreach petlja koja trazi indeks po imenu pjesme
                        if(pair.Value==tempStr){
                            tempInt=pair.Key;
                            break;
                        }
                    }
                    System.Console.WriteLine("Redni broj pjesme "+ tempStr + " je "+ tempInt);
                    break;
                case 4:
                    System.Console.WriteLine("Unesite ime pjesme koju želite dodati na playlistu");
                    tempStr=Console.ReadLine();
                    
                    foreach(var pair in dict){
                        while(pair.Value== tempStr){                                            //while petlja iz koje necemo izac ako ne damo ime pjesme koje ne postoji na playlisti
                            System.Console.WriteLine("Ta pjesma već postoji na playlisti, molimo vas unesite drugo ime");
                            tempStr=Console.ReadLine();
                        }
                    }
                    dict[dict.Count+1]=tempStr;
                    break;
                case 5:
                    System.Console.WriteLine("Unesite redni broj pjesme koju želite obrisati: "); //umisto da sve pisme pomicen za jedan samo san uzea zadnju i pribacia je na misto ove i onda obrisa zadnju :)
                    tempInt=int.Parse(Console.ReadLine());
                    dict[tempInt]=dict[dict.Count];
                    dict.Remove(dict.Count);
                    break;
                
                case 6:
                    System.Console.WriteLine("Unesite ime pjesme koju zelite obrisati: ");
                    tempStr=Console.ReadLine();
                    foreach(var pair in dict){
                        if(pair.Value==tempStr){
                            tempInt=pair.Key;
                            break;
                        }
                    }
                    dict[tempInt]=dict[dict.Count];
                    dict.Remove(dict.Count);
                    break;
                case 7:
                    System.Console.WriteLine("Cijela lista je obrisana");
                    dict.Clear();
                    break;
                case 8:
                    System.Console.WriteLine("Unesite redni broj pjesme kojoj zelite urediti ime: ");
                    tempInt=int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Unesite novo ime pjesme za koju žeite da bude na rednom mjestu "+ tempInt);
                    tempStr=Console.ReadLine();
                    foreach(var pair in dict){
                        while(pair.Value== tempStr){
                            System.Console.WriteLine("Ta pjesma već postoji na playlisti, molimo vas unesite drugo ime");
                            tempStr=Console.ReadLine();
                        }
                    }
                    dict[tempInt]=tempStr;
                    break;
                case 9:
                    System.Console.WriteLine("Unesite ime pjesme kojoj zelite promjeniti redni broj");
                    tempStr=Console.ReadLine();
                    foreach(var pair in dict){
                        if(pair.Value==tempStr){
                            tempInt=pair.Key;
                            break;
                        }
                    }
                    System.Console.WriteLine("Unesite novi redni broj");
                    tempInt2=int.Parse(Console.ReadLine());
                    dict[tempInt]=dict[tempInt2];
                    dict[tempInt2]=tempStr;
                    break;
                case 10:
                    var random=new Random();
                    for(int i=1;i<=dict.Count;i++){
                        tempInt=random.Next(1,dict.Count+1);
                        tempStr=dict[i];
                        dict[i]=dict[tempInt];
                        dict[tempInt]=tempStr;

                    }
                    break;
            }
            return palivozi;


        }
        
    }
}