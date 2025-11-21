using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Tacka
    {
        protected int x;
        protected int y;
        public static Tacka pocetak = new Tacka();

        public Tacka()
        {
            x = 0;
            y = 0;
        }
        public Tacka(int x)
        {
            this.x = x;
            y = 0;
        }
        public Tacka(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int TackaX
        {
            get { return x; }
            set { x = value; }
        }
        public int TackaY
        {
            get { return y; }
            set { y = value; }
        }

        public virtual void postavi(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void citaj()
        {
            Console.Write("Unesite x koordinatu: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Unesite y koordinatu: ");
            y = int.Parse(Console.ReadLine());
        }

        public virtual void toString()
        {
            Console.WriteLine("Koordinate tacke su: (" + x + ", " + y + ")");
        }
    }

    abstract class Figura : Tacka
    {
        protected Tacka teziste;
        public Figura() : base()
        {
            teziste = new Tacka();
        }
        public Figura(int x, int y)
        {
            teziste = new Tacka(x, y);
        }

        public override void postavi(int x, int y)
        {
            teziste.postavi(x, y);
        }

        public void pomeri(int x, int y)
        {
            teziste.TackaX += x;
            teziste.TackaY += y;
        }

        abstract public double povrsina();
        abstract public double obim();
    }

    class Krug : Figura
    {
        private int poluprecnik;

        public Krug()
        {
            poluprecnik = 1;
        }
        public Krug(int r)
        {
            poluprecnik = r;
        }
        public Krug(int r, Tacka t)
        {
            poluprecnik = r;
            teziste = t;
        }
        public override double povrsina()
        {
            return Math.PI * poluprecnik * poluprecnik;
        }
        public override double obim()
        {
            return 2 * Math.PI * poluprecnik;
        }

        public void citaj()
        {
            Console.Write("Unesite poluprecnik kruga: ");
            poluprecnik = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite koordinate tezista kruga:");
            teziste.citaj();
        }

        public override void toString()
        {
            Console.WriteLine("Poluprecnik: " + poluprecnik);
            Console.WriteLine("Povrsina: " + povrsina());
            Console.WriteLine("Obim: " + obim());
        }
    }

    class Kvadrat : Figura
    {
        private int stranica;

        public Kvadrat()
        {
            stranica = 1;
        }
        public Kvadrat(int a)
        {
            stranica = a;
        }

        public override double povrsina()
        {
            return stranica * stranica;
        }
        public override double obim()
        {
            return 4 * stranica;
        }

        public void citaj()
        {
            Console.Write("Unesite duzinu stranice kvadrata: ");
            stranica = int.Parse(Console.ReadLine());
        }

        public override void toString()
        {
            Console.WriteLine("Duzina stranice: " + stranica);
            Console.WriteLine("Povrsina: " + povrsina());
            Console.WriteLine("Obim: " + obim());
        }
    }

    class Trougao : Figura
    {
        private int a, b, c;

        public Trougao()
        {
            a = b = c = 1;
        }
        public Trougao(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double povrsina()
        {
            double s = obim() / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        public override double obim()
        {
            return a + b + c;
        }

        public void citaj()
        {
            Console.Write("Unesite duzinu prve stranice trougla: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Unesite duzinu druge stranice trougla: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("Unesite duzinu trece stranice trougla: ");
            c = int.Parse(Console.ReadLine());
        }

        public override void toString()
        {
            Console.WriteLine("Duzine stranica: " + a + ", " + b + ", " + c);
            Console.WriteLine("Povrsina: " + povrsina());
            Console.WriteLine("Obim: " + obim());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Figura> figure = new List<Figura>();
            string unos;

            do
            {
                Console.Write("Vrsta figure (O, K, T)? ");
                unos = Console.ReadLine()?.ToLower();

                if (unos == "o")
                {
                    Krug krug = new Krug();
                    krug.citaj();
                    figure.Add(krug);
                }
                else if (unos == "k")
                {
                    Kvadrat kvadrat = new Kvadrat();
                    kvadrat.citaj();
                    figure.Add(kvadrat);
                }
                else if (unos == "t")
                {
                    Trougao trougao = new Trougao();
                    trougao.citaj();
                    figure.Add(trougao);
                }
                else
                {
                    break;
                }
            } while (true);

            foreach (Figura figura in figure)
            {
                figura.toString();
                Console.WriteLine();
            }
        }
    }
}