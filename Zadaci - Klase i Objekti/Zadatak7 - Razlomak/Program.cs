using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadaci
{
    class Razlomak
    {
        private int a; private int b;

        public Razlomak()
        {
            this.b = 1;
        }

        public Razlomak(int a) : this()
        {
            this.a = a;
        }

        public Razlomak(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Imenilac ne može biti nula.");
            }
            this.a = a;
            this.b = b;

            srediRazlomak();
        }

        private void srediRazlomak()
        {
            int nzd = NZD(Math.Abs(a), Math.Abs(b));
            this.a = a / nzd;
            this.b = b / nzd;

            if (this.b < 0)
            {
                this.a *= -1;
                this.b *= -1;
            }
        }

        private int NZD(int x, int y)
        {
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }

        private int getBrojilac
        {
            get { return this.a; }
        }
        private int getImenilac
        {
            get { return this.b; }
        }

        public void dodaj(Razlomak razlomak)
        {
            //a/b + c/d = (a*d + c*b) / (b*d)
            int noviA = this.a * razlomak.getImenilac + razlomak.getBrojilac * this.b;
            int noviB = this.b * razlomak.getImenilac;
            this.a = noviA;
            this.b = noviB;
            srediRazlomak();
        }
        public void oduzmi(Razlomak razlomak)
        {
            //a/b - c/d = (a*d - c*b) / (b*d)
            int noviA = this.a * razlomak.getImenilac - razlomak.getBrojilac * this.b;
            int noviB = this.b * razlomak.getImenilac;
            this.a = noviA;
            this.b = noviB;
            srediRazlomak();
        }
        public void pomnozi(Razlomak razlomak)
        {
            this.a *= razlomak.getBrojilac;
            this.b *= razlomak.getImenilac;
            srediRazlomak();
        }
        public void podeli(Razlomak razlomak)
        {
            if (razlomak.getBrojilac == 0)
            {
                throw new ArgumentException("Ne može se deliti razlomkom čiji je brojilac nula.");
            }
            this.a *= razlomak.getImenilac;
            this.b *= razlomak.getBrojilac;
            srediRazlomak();
        }

        public void toString()
        {
            if (this.b == 1)
            {
                Console.WriteLine("Resenje: {0}", this.a);
            }
            else if (this.a == this.b)
            {
                Console.WriteLine("Resenje je: 1");
            }
            else
            {
                Console.WriteLine("Resenje je: {0} / {1}", a, b);
            }
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Razlomak r1 = new Razlomak(1, 2);
            Razlomak r2 = new Razlomak(3, 4);

            r1.toString(); // Razlomak je: 1 / 2
            r2.toString(); // Razlomak je: 3 / 4

            r1.dodaj(r2);  // 1/2 + 3/4 = 5/4
            r1.toString(); // Razlomak je: 5 / 4

            r1.oduzmi(new Razlomak(1, 4)); // 5/4 - 1/4 = 1
            r1.toString(); // Razlomak je: 1 / 1

            r1.pomnozi(new Razlomak(2, 3)); // 1 * 2/3 = 2/3
            r1.toString(); // Razlomak je: 2 / 3

            r1.podeli(new Razlomak(1, 6)); // (2/3) / (1/6) = 4
            r1.toString(); // Razlomak je: 4 / 1

            Razlomak r3 = new Razlomak(10, 20); // treba da bude 1/2
            r3.toString(); // Razlomak je: 1 / 2

            Razlomak r4 = new Razlomak(-2, -4); // treba da bude 1/2
            r4.toString(); // Razlomak je: 1 / 2

            Razlomak r5 = new Razlomak(2, -4); // treba da bude -1/2
            r5.toString(); // Razlomak je: -1 / 2
        }
    }
}