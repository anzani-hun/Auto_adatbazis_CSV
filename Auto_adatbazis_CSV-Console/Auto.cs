using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace Auto_adatbazis_CSV_Console
{
    internal class Auto
    {
        //Sorszám;Márka;Modell;Gyártási év;Szín;Eladott darabszám;Átlagos eladási ár;
        //1;Toyota;Corolla;2019;Fehér;500;20000;
        /*
        Sorszám: Az autó sorszáma az eladott darabszám alapján
        Márka: Az autó márkája
        Modell: Az autó modellje
        Gyártási év: Az autó gyártási éve
        Szín: Az autó színe
        Eladott darabszám: Hány darabot adtak el az adott modellből
        Átlagos eladási ár: Az autó átlagos eladási ára euróban
        */

        public int sorszam;
        public string marka;
        public string modell;
        public int gyartasiEv;
        public string autoSzine;
        public int eladottDarabszam;
        public int eladasiAr;


        public Auto(int sorszam, string marka, string modell, int gyartasiEv, string autoSzine, int eladottDarabszam, int eladasiAr)
        {
            this.sorszam = sorszam;
            this.marka = marka;
            this.modell = modell;
            this.gyartasiEv = gyartasiEv;
            this.autoSzine = autoSzine;
            this.eladottDarabszam = eladottDarabszam;
            this.eladasiAr = eladasiAr;
        }
    }
}
