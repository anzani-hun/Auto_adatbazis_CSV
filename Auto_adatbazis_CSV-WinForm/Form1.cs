using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_adatbazis_CSV_WinForm
{
    public partial class Form1 : Form
    {

        List<Auto> autoLista = new List<Auto>();


        public Form1()
        {
            InitializeComponent();


            {
                using (StreamReader sr = new StreamReader("autok.csv"))
                {
                    //FEJLÉC kihagyása:
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {

                        /*
                        public int sorszam;
                        public string marka;
                        public string modell;
                        public int gyartasiEv;
                        public string autoSzine;
                        public int eladottDarabszam;
                        public int eladasiAr;*/

                        string[] sor = sr.ReadLine().Split(';');
                        int sorszam = int.Parse(sor[0]);
                        string marka = sor[1];
                        string modell = sor[2];
                        int gyartasiEv = int.Parse(sor[3]);
                        string autoSzine = sor[4];
                        int eladottDarabszam = int.Parse(sor[5]);
                        int eladasiAr = int.Parse(sor[6]);

                        autoLista.Add(new Auto(sorszam, marka, modell, gyartasiEv, autoSzine, eladottDarabszam, eladasiAr));
                    }
                }

            }
        }

        private void buttonBetolt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV fájlok (*.csv)|*.csv|Összes fájl (*.*)|*.*";
            openFileDialog.Title = "Válasszon egy CSV fájlt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string eleresiUt = openFileDialog.FileName;


                // Itt megteheted az autók listával, amit szeretnél
                // Például kiírhatod őket a konzolra:
                foreach (Auto adat in autoLista)
                {
                    Console.WriteLine($"Marka: {adat.marka}, Modell: {adat.modell}, Eladott darabszam: {adat.eladottDarabszam}");
                }
            }
        }

        private void buttonBezar_Click(object sender, EventArgs e)
        {
            // Rákérdez, hogy valóban ki akarunk-e lépni
            DialogResult result = MessageBox.Show("Biztosan ki szeretne lépni?", "Kilépés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Bezárja az alkalmazást
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // A megadott URL megnyitása az alapértelmezett böngészőben
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://richardkorom.hu/feladatok/vizsga/szakmai-vizsga-gyakorlat/",
                UseShellExecute = true
            });
        }
    }
}