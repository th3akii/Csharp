using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    public class Transakcije
    {
        private static int nextID = 100; //nikad nece postojati isti id nezavisno od automata
        private int ID;

        private string vrsta;
        private double iznos;

        public Transakcije(string vrsta, double iznos)
        {
            this.vrsta = vrsta;
            this.iznos = iznos;
            this.ID = nextID++;
        }

        public double efektivno(string vrsta, double iznos)
        {
            return vrsta == "uplata" ? iznos : -iznos;
        }

        public string toString(double stanje)
        {
            return "ID: " + ID + " | Vrtsa: " + vrsta + " | Iznos: " + iznos + " | " + "Stanje: " + stanje + " | Efektivno: (" + efektivno(vrsta, iznos) + ")";
        }
    }

    public class AutomatNovca
    {
        private double pocetno = 10000;
        private double stanje;

        private Transakcije[] transakcije;
        private double[] transakcijeStanje;
        private int brojTransakcija;

        public AutomatNovca()
        {
            stanje = pocetno;
            transakcije = new Transakcije[100];
            transakcijeStanje = new double[100];
            brojTransakcija = 0;
        }
        
        public Transakcije podigniIznos(double n)
        {

            stanje -= n;
            Transakcije t = new Transakcije("isplata", n);
            if (brojTransakcija < transakcije.Length)
            {
                transakcije[brojTransakcija] = t;
                transakcijeStanje[brojTransakcija++] = stanje;
            }
            return t;
        }

        public Transakcije uloziIznos(double n)
        {
            stanje += n;
            Transakcije t = new Transakcije("uplata", n);
            if (brojTransakcija < transakcije.Length)
            {
                transakcije[brojTransakcija] = t;
                transakcijeStanje[brojTransakcija++] = stanje;
            }
            return t;
        }

        public void VratiStanje()
        {
            stanje = pocetno;
        }

        public void IspisiStanje()
        {
            Console.Write(stanje);
        }

        public void IspisiSveTransakcije()
        {
            Console.WriteLine("Sve transakcije na ovom automatu:");

            if (brojTransakcija == 0)
            {
                Console.WriteLine("Nema transakcija.");
                return;
            }

            for (int i = 0; i < brojTransakcija; i++)
            {
                Console.WriteLine(transakcije[i].toString(transakcijeStanje[i]));
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AutomatNovca NoviBeograd = new AutomatNovca();
            AutomatNovca StariGrad = new AutomatNovca();

            Console.Write("Novi Beograd: "); NoviBeograd.IspisiStanje(); Console.WriteLine();
            Console.Write("Stari Grad: "); StariGrad.IspisiStanje(); Console.WriteLine();

            NoviBeograd.uloziIznos(1002.03);
            StariGrad.podigniIznos(234.55);

            Console.Write("Novi Beograd: "); NoviBeograd.IspisiStanje(); Console.WriteLine();
            Console.Write("Stari Grad: "); StariGrad.IspisiStanje(); Console.WriteLine();

            int n;
            int brojAutomata = 1;
            double iznos;

            do
            {
                Console.WriteLine("(1) Izabrati automat, (2) uplata, (3) isplata, (4) Ispis stanja, (5)Ispis transakcija, (0) Kraj.");
                n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Automat 1 ili 2");
                        brojAutomata = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Unesite iznos za uplatu");
                        iznos = Convert.ToDouble(Console.ReadLine());
                        if (brojAutomata == 1) NoviBeograd.uloziIznos(iznos);
                        else StariGrad.uloziIznos(iznos);
                        break;
                    case 3:
                        Console.WriteLine("Unesite iznos za isplatu");
                        iznos = Convert.ToDouble(Console.ReadLine());
                        if (brojAutomata == 1) NoviBeograd.podigniIznos(iznos);
                        else StariGrad.podigniIznos(iznos);
                        break;
                    case 4:
                        if (brojAutomata == 1) { Console.Write("Novi Beograd: "); NoviBeograd.IspisiStanje(); Console.WriteLine(); }
                        else { Console.Write("Stari Grad: "); StariGrad.IspisiStanje(); Console.WriteLine(); }
                        break;
                    case 5:
                        if (brojAutomata == 1) NoviBeograd.IspisiSveTransakcije();
                        else StariGrad.IspisiSveTransakcije();
                        break;
                    default:
                        break;
                }
            } while (n != 0);
        }
    }
}