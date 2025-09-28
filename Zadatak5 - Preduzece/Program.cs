using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Zadaci
{
    class Zaposleni
    {
        private string ime;
        private double plata;
        private Sef? sef;

        public Zaposleni(string ime, double plata)
        {
            this.ime = ime;
            this.plata = plata;
        }

        public void postaviPlatu(double plata)
        {
            this.plata = plata;
        }

        public void postaviSefa(Sef sef)
        {
            this.sef = sef;
        }

        public double getPlata
        {
            get { return this.plata; }
        }

        public bool jesteSef(Sef sef)
        {
            return this.sef == sef;
        }

        public void ispisi()
        {
            if (this.sef != null)
            {
                Console.WriteLine("Osoba {0} ima platu {1} i sef te osobe je {2}", ime, plata, this.sef.getPseudonim);
            }
            else
            {
                Console.WriteLine("Osoba {0} ima platu {1} i nema sefa", ime, plata);
            }
        }
    }

    class Sef
    {
        private string pseudonim;
        private string odeljenje;
        private string datum;

        public Sef(string pseudonim)
        {
            this.pseudonim = pseudonim;
            this.odeljenje = "Prodaja";
            this.datum = DateTime.Now.ToString("dd.MM.yyyy");
        }

        public void povecajPlatu(Zaposleni zaposleni, double povecanje)
        {
            if (zaposleni.jesteSef(this))
            {
                zaposleni.postaviPlatu(zaposleni.getPlata + povecanje);
                Console.WriteLine("Uspesno povecana plata");
            }
            else
            {
                Console.WriteLine("Mozete povecati platu samo svom zaposlenom");
            }
        }

        public string getPseudonim
        {
            get { return this.pseudonim; }
        }

        public void ispisiZaposlenog(Zaposleni zaposleni)
        {
            zaposleni.ispisi();
        }

        public void ispisi()
        {
            Console.WriteLine("{0} je na odeljenu {1} datuma {2}", pseudonim, odeljenje, datum);
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Sef sef1 = new Sef("Joca");
            Sef sef2 = new Sef("Boca");

            Zaposleni zaposleni1 = new Zaposleni("Pera", 50000);
            Zaposleni zaposleni2 = new Zaposleni("Mika", 45000);
            Zaposleni zaposleni3 = new Zaposleni("Laza", 40000); // nema sefa
            
            zaposleni1.postaviSefa(sef1);
            zaposleni2.postaviSefa(sef2);
            
            Console.WriteLine("=== POCETNO STANJE ===");
            zaposleni1.ispisi();
            zaposleni2.ispisi();
            zaposleni3.ispisi();
            
            Console.WriteLine("\n=== TESTIRANJE POVECANJA PLATA ===");
            
            // treba da radi
            Console.WriteLine("Sef1 pokusava da poveca platu Peri:");
            sef1.povecajPlatu(zaposleni1, 5000);
            
            // treba da ispise gresku
            Console.WriteLine("\nSef2 pokusava da poveca platu Peri:");
            sef2.povecajPlatu(zaposleni1, 3000);
            
            // treba da radi
            Console.WriteLine("\nSef2 pokusava da poveca platu Miki:");
            sef2.povecajPlatu(zaposleni2, 7000);
            
            Console.WriteLine("\n=== FINALNO STANJE ===");
            zaposleni1.ispisi();
            zaposleni2.ispisi();
            zaposleni3.ispisi();
            
            Console.WriteLine("\n=== INFORMACIJE O sEFOVIMA ===");
            sef1.ispisi();
            sef2.ispisi();
            */
        }
    }
}