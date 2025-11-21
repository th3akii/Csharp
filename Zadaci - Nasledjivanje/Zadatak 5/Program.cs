using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    abstract class Izraz
    {
        abstract public double vrednost();
        abstract public string toString();
    }

    class Konstanta : Izraz
    {
        private double vrednostKonstante;

        public Konstanta(double vrednostKonstante)
        {
            this.vrednostKonstante = vrednostKonstante;
        }

        public override double vrednost()
        {
            return vrednostKonstante;
        }

        public override string toString()
        {
            return vrednostKonstante.ToString();
        }
    }

    class Promenljiva : Izraz
    {
        private static Dictionary<string, Promenljiva> postojece = new Dictionary<string, Promenljiva>();

        private string ime;
        private double vrednostPromenljive;

        public Promenljiva(string ime, double vrednostPromenljive)
        {
            if (postojece.ContainsKey(ime))
            {
                throw new Exception("Promenljiva sa tim imenom vec postoji.");
            }
            this.ime = ime;
            this.vrednostPromenljive = vrednostPromenljive;
            postojece[ime] = this;
        }

        public Promenljiva(string ime) : this(ime, 0.0) { }

        public static void brisi(string ime)
        {
            if (postojece.ContainsKey(ime))
                postojece.Remove(ime);
        }

        public void postavi(double v)
        {
            vrednostPromenljive = v;
        }

        public void postavi(Izraz i)
        {
            vrednostPromenljive = i.vrednost();
        }

        public override double vrednost()
        {
            return vrednostPromenljive;
        }
        public override string toString()
        {
            return ime;
        }

        public static void ispisiSve()
        {
            foreach (var p in postojece)
            {
                Console.WriteLine($"{p.Key} =  {p.Value.vrednost()}");
            }
        }
    }

    abstract class IzrazSaOperacijom : Izraz
    {
        protected Izraz a;
        protected Izraz b;

        public IzrazSaOperacijom(Izraz a, Izraz b)
        {
            this.a = a;
            this.b = b;
        }
    }

    class Zbir : IzrazSaOperacijom
    {
        public Zbir(Izraz a, Izraz b) : base(a, b) { }

        public override double vrednost()
        {
            return a.vrednost() + b.vrednost();
        }

        public override string toString()
        {
            return "(" + a.toString() + "+" + b.toString() + ")";
        }
    }

    class Razlika : IzrazSaOperacijom
    {
        public Razlika(Izraz a, Izraz b) : base(a, b) { }

        public override double vrednost()
        {
            return a.vrednost() - b.vrednost();
        }

        public override string toString()
        {
            return "(" + a.toString() + "-" + b.toString() + ")";
        }
    }
    class Proizvod : IzrazSaOperacijom
    {
        public Proizvod(Izraz a, Izraz b) : base(a, b) { }

        public override double vrednost()
        {
            return a.vrednost() * b.vrednost();
        }

        public override string toString()
        {
            return "(" + a.toString() + "*" + b.toString() + ")";
        }
    }

    class Kolicnik : IzrazSaOperacijom
    {
        public Kolicnik(Izraz a, Izraz b) : base(a, b) { }

        public override double vrednost()
        {
            return a.vrednost() / b.vrednost();
        }

        public override string toString()
        {
            return "(" + a.toString() + "/" + b.toString() + ")";
        }
    }

    class Stepen : IzrazSaOperacijom
    {
        public Stepen(Izraz a, Izraz b) : base(a, b) { }

        public override double vrednost()
        {
            return Math.Pow(a.vrednost(), b.vrednost());
        }

        public override string toString()
        {
            return "(" + a.toString() + "^" + b.toString() + ")";
        }
    }

    class Dodela : Izraz
    {
        private Promenljiva promenljiva;
        private Izraz izraz;

        public Dodela(Promenljiva promenljiva, Izraz izraz)
        {
            this.promenljiva = promenljiva;
            this.izraz = izraz;
        }

        public override double vrednost()
        {
            double v = izraz.vrednost();
            promenljiva.postavi(v);
            return v;
        }

        public override string toString()
        {
            return promenljiva.toString() + " = " + izraz.toString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Unesite xmin: ");
            if (!double.TryParse(Console.ReadLine(), out double xmin)) return;
            Console.Write("Unesite xmax: ");
            if (!double.TryParse(Console.ReadLine(), out double xmax)) return;
            Console.Write("Unesite dx: ");
            if (!double.TryParse(Console.ReadLine(), out double dx)) return;

            Izraz Xmin = new Konstanta(xmin);
            Izraz Xmax = new Konstanta(xmax);
            Izraz Dx = new Konstanta(dx);

            Promenljiva x = new Promenljiva("x");

            Izraz xNa3 = new Stepen(x, new Konstanta(3));
            Izraz dvaX = new Proizvod(new Konstanta(2), x);
            Izraz cilj = new Razlika(xNa3, dvaX);

            Console.WriteLine();
            Console.WriteLine("x\tx^3 - 2x");
            for (double i = xmin; i <= xmax; i += dx)
            {
                x.postavi(i);
                double rez = cilj.vrednost();
                Console.WriteLine($"{i:G}\t{rez:G}");
            }

            Console.WriteLine();
            Promenljiva.ispisiSve();
        }
    }
}
