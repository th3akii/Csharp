using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Element
    {
        private int broj;
        private Element? sledeci;

        public Element(int broj)
        {
            this.broj = broj;
            this.sledeci = null;
        }
        public Element(int broj, Element sledeci) : this(broj)
        {
            this.sledeci = sledeci;
        }

        public Element getSledeci
        {
            get { return this.sledeci!; }
        }
        public int getBroj { get { return this.broj; } }
        public Element setSledeci
        {
            set
            {
                this.sledeci = value;
            }
        }
    }

    public class Red
    {
        private Element prvi;
        private Element poslednji;

        public Red()
        {
            this.prvi = null!;
            this.poslednji = null!;
        }

        public void stavi(int n)
        {
            Element element = new Element(n);

            if (this.poslednji == null)
            {
                prvi = element;
                poslednji = element;
                return;
            }

            poslednji.setSledeci = element;
            poslednji = element;
        }

        public int uzmi()
        {
            int broj = prvi.getBroj;
            prvi = prvi.getSledeci;

            if (prvi == null)
            {
                poslednji = null!;
            }

            return broj;
        }

        public void prazni()
        {
            while (prvi != null)
            {
                Element trenutni = prvi;
                prvi = prvi.getSledeci;
                trenutni.setSledeci = null!;
            }
            poslednji = null!;
        }

        public bool prazan()
        {
            return prvi == null;
        }

        public void toString()
        {
            if (prvi == null)
            {
                Console.WriteLine("Lista je prazna");
                return;
            }

            Element trenutni = prvi;
            while (trenutni != null)
            {
                Console.Write(trenutni.getBroj);
                if (trenutni.getSledeci != null)
                {
                    Console.Write(", ");
                }
                trenutni = trenutni.getSledeci;
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Red red = new Red();

            Console.WriteLine("Da li je red prazan? " + red.prazan());

            Console.WriteLine("Dodaje 10, 20, 30 u red");
            red.stavi(10);
            red.stavi(20);
            red.stavi(30);

            Console.WriteLine("Sadrzaj reda:");
            red.toString();

            Console.WriteLine("Da li je red prazan? " + red.prazan());

            Console.WriteLine("Uzmi iz reda: " + red.uzmi());

            Console.WriteLine("Sadrzaj reda nakon uzimanja:");
            red.toString();

            Console.WriteLine("Dodaj 40 u red.");
            red.stavi(40);

            Console.WriteLine("Sadrzaj reda nakon dodavanja:");
            red.toString();

            Console.WriteLine("Prazni red");
            red.prazni();

            Console.WriteLine("Da li je red prazan? " + red.prazan());
        }
    }
}