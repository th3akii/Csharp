using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Valjak
    {
        protected int poluprecnik; protected int visina;
        public Valjak()
        {
            poluprecnik = 1; visina = 1;
        }
        public Valjak(int r, int h)
        {
            poluprecnik = r; visina = h;
        }
        public int Poluprecnik
        {
            get { return poluprecnik; }
            set { poluprecnik = value; }
        }
        public int Visina
        {
            get { return visina; }
            set { visina = value; }
        }

        public double zapremina()
        {
            return Math.PI * poluprecnik * poluprecnik * visina;
        }
        public void toString()
        {
            Console.WriteLine($"({poluprecnik}, {visina})");
        }
    }

    class Kanta : Valjak
    {
        private int sadrzaj;
        public Kanta() : base()
        {
            sadrzaj = 0;
        }
        public Kanta(int r, int h, int s) : base(r, h)
        {
            sadrzaj = s;
        }

        public int Sadrzaj
        {
            get { return sadrzaj; }
            set { sadrzaj = value; }
        }
        public bool puna
        {
            get
            {
                if (sadrzaj == zapremina())
                    return true;
                else
                    return false;
            }
        }
        public bool prazna
        {
            get
            {
                if (sadrzaj == 0)
                    return true;
                else
                    return false;
            }
        }
        public void prazni()
        {
            sadrzaj = 0;
        }

        public double dodaj(int kolicina)
        {
            if (sadrzaj + kolicina <= zapremina())
            {
                sadrzaj += kolicina;
                return kolicina;
            }
            else
            {
                double pom = (double)sadrzaj;
                sadrzaj = (int)zapremina();
                return zapremina() - pom;
            }
        }
        public double ukloni(int kolicina)
        {
            if (sadrzaj - kolicina <= 0)
            {
                int pom = sadrzaj;
                sadrzaj = 0;
                return sadrzaj;
            }
            else
            {
                sadrzaj -= kolicina;
                return kolicina;
            }
        }

        public void prespi(Kanta kanta)
        {
            if((sadrzaj + kanta.Sadrzaj) <= kanta.zapremina())
            {
                sadrzaj = 0;
                kanta.Sadrzaj += sadrzaj;
            }
            else
            {
                sadrzaj = (int)kanta.zapremina() - kanta.Sadrzaj;
                kanta.Sadrzaj = (int)kanta.zapremina();
            }
        }
        
        public void toString()
        {
            Console.WriteLine($"({poluprecnik}, {visina}), sadrzaj: {sadrzaj} (zapremina: {zapremina()})");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Valjak valjak = new Valjak(3, 4);
            Kanta kanta1 = new Kanta(4, 3, 0);
            Kanta kanta2 = new Kanta(2, 4, 30);

            Console.WriteLine("Valjak:");
            valjak.toString();

            Console.WriteLine("Kanta 1:");
            kanta1.toString();

            Console.WriteLine("Kanta 2:");
            kanta2.toString();

            kanta1.dodaj(120);
            kanta2.dodaj(10);

            kanta1.prespi(kanta2);

            Console.WriteLine("Kanta 1:");
            kanta1.toString();

            Console.WriteLine("Kanta 2:");
            kanta2.toString();
        }
    }
}
