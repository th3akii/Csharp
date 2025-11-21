using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    interface IComparable
    {
        public bool jeVeciOd(Figura f);
    }

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
        protected int redniBroj;

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

    class Krug : Figura, IComparable
    {
        private int poluprecnik;

        public Krug()
        {
            poluprecnik = 1;
        }
        public Krug(int r, int br)
        {
            poluprecnik = r;
            redniBroj = br;
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
            Console.WriteLine("Krug #" + redniBroj);
            Console.WriteLine("Poluprecnik: " + poluprecnik);
            Console.WriteLine("Povrsina: " + povrsina());
            Console.WriteLine("Obim: " + obim());
        }

        public bool jeVeciOd(Figura f)
        {
            return this.povrsina() > f.povrsina();
        }
    }

    class Kvadrat : Figura, IComparable
    {
        private int stranica;

        public Kvadrat()
        {
            stranica = 1;
        }
        public Kvadrat(int a, int br)
        {
            stranica = a;
            redniBroj = br;
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
            Console.WriteLine("Kvadrat #" + redniBroj);
            Console.WriteLine("Duzina stranice: " + stranica);
            Console.WriteLine("Povrsina: " + povrsina());
            Console.WriteLine("Obim: " + obim());
        }

        public bool jeVeciOd(Figura f)
        {
            return this.povrsina() > f.povrsina();
        }
    }

    class Trougao : Figura, IComparable
    {
        private int a, b, c;

        public Trougao()
        {
            a = b = c = 1;
        }
        public Trougao(int a, int b, int c, int br)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            redniBroj = br;
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
            Console.WriteLine("Trougao #" + redniBroj);
            Console.WriteLine("Duzine stranica: " + a + ", " + b + ", " + c);
            Console.WriteLine("Povrsina: " + povrsina());
            Console.WriteLine("Obim: " + obim());
        }

        public bool jeVeciOd(Figura f)
        {
            return this.povrsina() > f.povrsina();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kvadrat kvadrat1 = new Kvadrat(5, 1);
            Krug krug = new Krug(5, 2);
            Kvadrat kvadrat2 = new Kvadrat(10, 3);

            List<Figura> figure = new List<Figura> { kvadrat1, krug, kvadrat2 };

            sortiraj(figure);
            foreach (Figura figura in figure)
            {
                figura.toString();
                Console.WriteLine();
            }
        }

        static void sortiraj(List<Figura> figure)
        {
            for (int i = 0; i < figure.Count - 1; i++)
            {
                for (int j = i + 1; j < figure.Count; j++)
                {
                    if (figure[i].povrsina() < figure[j].povrsina())
                    {
                        Figura temp = figure[i];
                        figure[i] = figure[j];
                        figure[j] = temp;
                    }
                }
            }
        }
    }
}
