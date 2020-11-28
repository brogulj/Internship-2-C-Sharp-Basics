using System;
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
        public static bool DaNe(int odabir){
                    var dane="";
                    System.Console.WriteLine("Jeste li sigurni da želite odabrati opciju broj "+odabir);
                    System.Console.WriteLine("pritisnite d za da ili n za ne");
                    dane=Console.ReadLine();
                    if(dane=="d") 
                    return true;
                    return false;
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
            var odabir = int.Parse(Console.ReadLine());                                           
            var dane=new Boolean();
            switch(odabir){
                case 0:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    palivozi=false;
                    break;
                case 1:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    IspisCijelePlayliste(dict);
                    break;
                case 2:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    IspisPoRednomBroju(dict);
                    break;
                case 3:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    IspisRednogBroja(dict);
                    break;
                case 4:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    DodavanjeNaPlaylistu(dict);
                    break;
                case 5:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    BrisanjePoBroju(dict);
                    break;
                
                case 6:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    BrisanjePoImenu(dict);
                    break;
                case 7:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    dict.Clear();
                    System.Console.WriteLine("Cijela lista je obrisana");
                    break;
                case 8:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    PromjeniImePjesme(dict);
                    break;
                case 9:
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    PromjeniRedniBroj(dict);
                    break;
                case 10:                                                                    
                    dane=DaNe(odabir);
                    if(!dane)
                    break;
                    Shuffle(dict);
                    break;
            }
            return palivozi;


        }
        //tempInt, tempInt2 i tempStr su nekakvi placeholderi koje koristim u vecini opcija u zadatku
        public static void Shuffle(Dictionary<int,string> dict){
            var tempStr="";
            var tempInt=0;
            var random=new Random();
                    for(int i=1;i<=dict.Count;i++){
                        tempInt=random.Next(1,dict.Count+1);
                        tempStr=dict[i];
                        dict[i]=dict[tempInt];
                        dict[tempInt]=tempStr;

                    }
                    System.Console.WriteLine("Playlista je shuffleana!");
        }
        public static void PromjeniRedniBroj(Dictionary<int,string> dict){
                    var tempStr="";
                    var tempInt=0;
                    var tempInt2=0;
                    System.Console.WriteLine("Unesite ime pjesme kojoj zelite promjeniti redni broj");
                    tempStr=Console.ReadLine();
                    while(tempInt==0){
                        foreach(var pair in dict){
                            if(pair.Value==tempStr){
                                tempInt=pair.Key;
                                break;
                            }
                        }
                        if(tempInt==0){
                            System.Console.WriteLine("Unijeli ste ime pjesme koja se ne nalazi na listi");
                            System.Console.WriteLine("Molimo vas unesite novo ime pjesme: ");
                            tempStr=Console.ReadLine();
                        }
                    }
                    System.Console.WriteLine("Unesite novi redni broj veći od 0 i manji od "+dict.Count);
                    tempInt2=int.Parse(Console.ReadLine());
                    dict[tempInt]=dict[tempInt2];
                    dict[tempInt2]=tempStr;
                    System.Console.WriteLine("Uspješno uređen redni broj");
        }
        public static void PromjeniImePjesme(Dictionary<int,string> dict){
                    var tempStr="";
                    var tempInt=0;
                    System.Console.WriteLine("Unesite redni broj pjesme kojoj zelite urediti ime: ");
                    tempInt=int.Parse(Console.ReadLine());
                    while(tempInt>dict.Count || tempInt<1){
                        System.Console.WriteLine("Unijeli ste redni broj koji nije na listi");
                        System.Console.WriteLine("Unesite redni broj pjesme kojoj zelite urediti ime: ");
                        tempInt=int.Parse(Console.ReadLine());
                    }
                    System.Console.WriteLine("Unesite novo ime pjesme za koju žeite da bude na rednom mjestu "+ tempInt);
                    tempStr=Console.ReadLine();
                    foreach(var pair in dict){
                        while(pair.Value== tempStr){
                            System.Console.WriteLine("Ta pjesma već postoji na playlisti, molimo vas unesite drugo ime");
                            tempStr=Console.ReadLine();
                        }
                    }
                    dict[tempInt]=tempStr;
                    System.Console.WriteLine("Uspješno uređeno ime");

        }
        public static void BrisanjePoImenu(Dictionary<int,string> dict){
                    var tempStr="";
                    var tempInt=0;
                    System.Console.WriteLine("Unesite ime pjesme koju zelite obrisati: ");
                    tempStr=Console.ReadLine();
                    while(tempInt==0){
                        foreach(var pair in dict){
                            if(pair.Value==tempStr){
                                tempInt=pair.Key;
                                break;
                            }
                        }
                        if(tempInt==0){
                            System.Console.WriteLine("Unijeli ste ime pjesme koja se ne nalazi na listi");
                            System.Console.WriteLine("Molimo vas unesite nov ime: ");
                            tempStr=Console.ReadLine();
                        }
                    }
                    for(var i=tempInt;i<dict.Count;i++){
                        dict[i]=dict[i+1];
                    }
                    dict.Remove(dict.Count);
                    System.Console.WriteLine("Pjesma je uspjesno obrisana sa playiste");

        }
        public static void BrisanjePoBroju(Dictionary<int,string> dict){
                var tempInt=0;

                System.Console.WriteLine("Unesite redni broj pjesme koju želite obrisati: "); 
                tempInt=int.Parse(Console.ReadLine());
                while(tempInt>dict.Count || tempInt<1){
                    System.Console.WriteLine("Unijeli ste redni broj koji nije na listi");
                    System.Console.WriteLine("Molimo vas unesite novi redni broj:");
                    tempInt=int.Parse(Console.ReadLine());
                }
                for(var i=tempInt;i<dict.Count;i++){
                    dict[i]=dict[i+1];
                }
                dict.Remove(dict.Count);
                System.Console.WriteLine("Pjesma je uspjesno obrisana sa playiste");

        }
        public static void DodavanjeNaPlaylistu(Dictionary<int,string> dict){
                var tempStr="";
                System.Console.WriteLine("Unesite ime pjesme koju želite dodati na playlistu");
                tempStr=Console.ReadLine();
                
                foreach(var pair in dict){
                    while(pair.Value== tempStr){                                            //while petlja iz koje necemo izac ako ne damo ime pjesme koje ne postoji na playlisti
                        System.Console.WriteLine("Ta pjesma već postoji na playlisti, molimo vas unesite drugo ime");
                        tempStr=Console.ReadLine();
                    }
                }
                dict[dict.Count+1]=tempStr;
                System.Console.WriteLine("Pjesma je uspjesno dodana na playlistu!");

        }
        public static void IspisRednogBroja(Dictionary<int,string> dict){
            var tempInt=0;
            var tempStr="";
            System.Console.WriteLine("unesite ime pjesme ciji redni broj zelite da se ispise");
            tempStr = Console.ReadLine();
            while(tempInt==0){
                foreach(var pair in dict){                                                  //foreach petlja koja trazi indeks po imenu pjesme
                    if(pair.Value==tempStr){
                        tempInt=pair.Key;
                        break;
                    }
                }
                if(tempInt==0){
                    System.Console.WriteLine("Unijeli ste ime pjesme koja se ne nalazi na listi");
                    System.Console.WriteLine("Molimo vas unesite novo ime:");
                    tempStr=Console.ReadLine();
                }
            }
            System.Console.WriteLine("Redni broj pjesme "+ tempStr + " je "+ tempInt);

        }
        public static void IspisPoRednomBroju(Dictionary<int,string> dict){
            var tempInt=0;
            System.Console.WriteLine("Unesite redni broj pjesme koje zelite da se ispise: ");
            tempInt = int.Parse(Console.ReadLine());
            while(tempInt>dict.Count || tempInt<1){
                System.Console.WriteLine("Unijeli ste redni broj koji nije na listi");
                System.Console.WriteLine("Molimo vas unesite novi redni broj:");
                tempInt=int.Parse(Console.ReadLine());
            }
            System.Console.WriteLine("Pjesma pod rednim brojem "+tempInt+" je "+dict[tempInt]+".");

        }
        public static void IspisCijelePlayliste(Dictionary<int,string> dict){
            System.Console.WriteLine("Playlista sadrzi slijedece pjesme");
            foreach(var pair in dict)
            {
                Console.WriteLine(pair.Key+". "+pair.Value);
            }
        }
    }
}