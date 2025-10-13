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

    class Lista
    {
        private Element prvi;
        
        public Lista(int prvi)
        {
            this.prvi = new Element(prvi);
        }

        public void prazni()
        {
            this.prvi = null!;
        }
        public int duzina()
        {
            int duzina = 0;
            Element trenutni = prvi;

            while(trenutni != null)
            {
                duzina++;
                trenutni = trenutni.getSledeci;
            }

            return duzina;
        }
        public void naPocetak(int n)
        {
            Element novi = new Element(n);
            novi.setSledeci = prvi;
            this.prvi = novi;
        }

        public void naKraj(int n)
        {
            Element novi = new Element(n);

            if (prvi == null)
            {
                prvi = novi;
                return;
            }

            Element trenutni = prvi;
            while (trenutni.getSledeci != null)
            {
                trenutni = trenutni.getSledeci;
            }

            trenutni.setSledeci = novi;
        }

        public void umetni(int n)
        {
            Element novi = new Element(n);

            if (prvi == null)
            {
                prvi = novi;
                return;
            }

            Element trenutni = prvi;
            while (trenutni.getSledeci != null && trenutni.getSledeci.getBroj < n)
            {
                trenutni = trenutni.getSledeci;
            }

            novi.setSledeci = trenutni.getSledeci;
            trenutni.setSledeci = novi;
        }

        public void izostavi(int n)
        {
            if (prvi == null) return;

            if (prvi.getBroj == n)
            {
                prvi = prvi.getSledeci;
                return;
            }


            Element trenutni = prvi;
            while (trenutni.getSledeci != null)
            {
                if (trenutni.getSledeci.getBroj == n)
                {
                    trenutni.setSledeci = trenutni.getSledeci.getSledeci;
                }

                trenutni = trenutni.getSledeci;
            }
        }

        public void citaj1(int n)
        {
            if (prvi == null)
            {
                prvi = new Element(Convert.ToInt32(Console.ReadLine()));
                n--;
            }

            Element trenutni = prvi;
            while (trenutni.getSledeci != null)
            {
                trenutni = trenutni.getSledeci;
            }

            for (int i = 0; i < n; i++)
            {
                Element element = new Element(Convert.ToInt32(Console.ReadLine()));
                trenutni.setSledeci = element;
                trenutni = element;
            }
        }
        public void citaj2(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Element element = new Element(Convert.ToInt32(Console.ReadLine()));
                element.setSledeci = prvi;
                prvi = element;
            }
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
            Lista lista = new Lista(5);
            Console.WriteLine("Lista nakon kreiranja sa pocetnim elementom 5:");
            lista.toString();
            Console.WriteLine();

            lista.naPocetak(3);
            Console.WriteLine("Lista nakon dodavanja 3 na pocetak:");
            lista.toString();
            Console.WriteLine();

            lista.naKraj(8);
            Console.WriteLine("Lista nakon dodavanja 8 na kraj:");
            lista.toString();
            Console.WriteLine();

            lista.umetni(6);
            Console.WriteLine("Lista nakon umetanja 6 (sortirana):");
            lista.toString();
            Console.WriteLine();

            lista.izostavi(3);
            Console.WriteLine("Lista nakon izostavljanja 3:");
            lista.toString();
            Console.WriteLine();

            Console.WriteLine("Unesite 3 nova elementa sa pocetka:");
            lista.citaj2(3);
            Console.WriteLine("Lista nakon čitanja 3 elementa sa pocetka:");
            lista.toString();
            Console.WriteLine();

            Console.WriteLine("Unesite 2 nova elementa na kraj:");
            lista.citaj1(2);
            Console.WriteLine("Lista nakon citanja 2 elementa na kraj:");
            lista.toString();
            Console.WriteLine();

            Console.WriteLine("Duzina liste je: " + lista.duzina());
        }
    }
}
