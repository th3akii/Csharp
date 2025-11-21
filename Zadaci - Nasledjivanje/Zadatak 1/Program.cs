using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Osoba
    {
        protected string ime; protected string adresa;

        public void citaj()
        {
            Console.Write("Ime? "); ime = Console.ReadLine();
            Console.Write("Adresa? "); adresa = Console.ReadLine();
        }
        public void toString()
        {
            Console.WriteLine($"Ime osobe: {ime}");
            Console.WriteLine($"Adresa osobe: {adresa}");
        }
    }

    class Djak : Osoba
    {
        private string skola; private string razred;
        public void citaj()
        {
            base.citaj();
            Console.Write("Skola? "); skola = Console.ReadLine();
            Console.Write("Razred? "); razred = Console.ReadLine();
        }
        public void toString()
        {
            Console.WriteLine($"Ime ucenika: {ime}");
            Console.WriteLine($"Adresa ucenika: {adresa}");
            Console.WriteLine($"Skola ucenika: {skola}");
            Console.WriteLine($"Razred ucenika: {razred}");
        }
    }

    class Zaposleni : Osoba
    {
        private string firma; private string radnistaz;
        public void citaj()
        {
            base.citaj();
            Console.Write("Firma? "); firma = Console.ReadLine();
            Console.Write("Radni staz? "); radnistaz = Console.ReadLine();
        }
        public void toString()
        {
            Console.WriteLine($"Ime radnika: {ime}");
            Console.WriteLine($"Adresa radnika: {adresa}");
            Console.WriteLine($"Firma radnika: {firma}");
            Console.WriteLine($"Radni staz radnika: {radnistaz}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string n;
            Osoba[] nizOsoba = new Osoba[100];
            Djak[] nizDjaka = new Djak[100];
            Zaposleni[] nizZaposlenih = new Zaposleni[100];
            int brojacO = 0; int brojacD = 0; int brojacZ = 0;

            do
            {
                Console.WriteLine("O-osoba | D-djak | Z-zaposleni | K-kraj");
                n = Console.ReadLine();
                switch (n)
                {
                    case "O":
                        Osoba osoba = new Osoba();
                        osoba.citaj();
                        nizOsoba[brojacO++] = osoba;
                        break;
                    case "D":
                        Djak djak = new Djak();
                        djak.citaj();
                        nizDjaka[brojacD++] = djak;
                        break;
                    case "Z":
                        Zaposleni zaposleni = new Zaposleni();
                        zaposleni.citaj();
                        nizZaposlenih[brojacZ++] = zaposleni;
                        break;
                    default:
                        break;
                }
            }while(n != "K");

            Console.WriteLine("Prikaz ucitanih podataka:");
            for (int i = 0; i < brojacO; i++)
            {
                nizOsoba[i].toString();
            }
            for (int i = 0; i < brojacD; i++)
            {
                nizDjaka[i].toString();
            }
            for (int i = 0; i < brojacZ; i++)
            {
                nizZaposlenih[i].toString();
            }
        }
    }
}
