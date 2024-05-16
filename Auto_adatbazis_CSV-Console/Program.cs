using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CSV beolvasáshoz:
using System.IO;



namespace Auto_adatbazis_CSV_Console
{
    internal class Program
    {
        //statikus lista létrehozása:
        static List<Auto> autoLista = new List<Auto>();

        static void Main(string[] args)
        {

            adatbazisBeolvasas();

            Console.WriteLine("Adatbázis beolvasása kész!");

            //5. feladat:
            Console.WriteLine($"\n005. feladat: {autoLista.Count} autó található a listában");


            //6. feladat:
            //Számolja meg, hogy a forrásállományban szereplő autók átlagosan hány darabot adtak el, majd jelenítse meg a képernyőn 1 tizedesjegy pontossággal! 
            autoAtlagosEladasa();


            //7. feladat:
            //Írja ki a minta szerint azoknak az autóknak a márkáit és modelljeit, valamint a gyártási évet, amelyeket az elmúlt 5 évben gyártottak.
            Console.WriteLine($"\n007. feladat: Az elmúlt 5 évben gyártott autók: ");
            elmultOtEvbenGyartottak();


            //8. feladat:
            //Írassa ki a mintának megfelelően, hogy az egyes márkákhoz hány eladott autó tartozik!
            Console.WriteLine($"\n008. feladat: Legsikeresebb márkák listája az eladott darabszám alapján: ");
            sorbarendez();

            Console.ReadKey();
        }

        private static void sorbarendez()
        {
            // LINQ használata a rendezéshez eladottDarabszam szerint csökkenő sorrendben
            var rendezettListaCsokkeno = autoLista.OrderByDescending(auto => auto.eladottDarabszam).ToList();

            foreach (var adat in rendezettListaCsokkeno)
            {
                Console.WriteLine($"\t{adat.marka} {adat.modell}: {adat.eladottDarabszam}");
            }
        }

        private static void elmultOtEvbenGyartottak()
        {
            //a feladatsor éve: 2023
            int mostaniEv = 2023;

            foreach (Auto adat in autoLista)
            {
                if (mostaniEv - 5 < adat.gyartasiEv && mostaniEv > adat.gyartasiEv)
                {
                    Console.WriteLine($"\t- {adat.marka} {adat.modell}: {adat.gyartasiEv}");
                }
            }


        }

        private static void autoAtlagosEladasa()
        {
            //lambda operátorral 
            double autoAtlag = autoLista.Average(p => p.eladottDarabszam);
            autoAtlag = Math.Round(autoAtlag, 1);

            Console.WriteLine($"\n006. feladat: Az átlagosan eladott autók darabszáma: {autoAtlag} ");
        }

        private static void adatbazisBeolvasas()
        {
            using (StreamReader sr = new StreamReader("autok.csv", Encoding.UTF8))
            {
                //mivel van fejléc ezért az első sort ne kezelje
                sr.ReadLine();

                //olvassa amíg nem ér a végére!
                while (!sr.EndOfStream)
                {
                    //string listába olvassa:
                    string[] sor = sr.ReadLine().Split(';');

                    //példányosítása:
                    //int sorszam, string marka, string modell, int gyartasiEv, string autoSzine, int eladottDarabszam, int eladasiAr
                    Auto auto = new Auto(int.Parse(sor[0]), sor[1], sor[2], int.Parse(sor[3]), sor[4], int.Parse(sor[5]), int.Parse(sor[6]));

                    autoLista.Add(auto);

                }
            }
        }
    }
}
