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
                Console.WriteLine($"{p.Key} = {p.Value.vrednost()}");
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

    abstract class Naredba
    {
        public static int nivo = 0;
        public abstract void radi();
        public abstract void toString();
    }

    class Prosta : Naredba
    {
        private Izraz izraz;

        public Prosta(Izraz izraz)
        {
            this.izraz = izraz;
        }

        public override void radi()
        {
            izraz.vrednost();
        }

        public override void toString()
        {
            Console.WriteLine(new string(' ', nivo * 2) + izraz.toString() + ";");
        }
    }

    class Sekvenca : Naredba
    {
        private List<Naredba> naredbe = new List<Naredba>();

        public void dodaj(Naredba n)
        {
            naredbe.Add(n);
        }

        public void dodaj(Izraz i)
        {
            naredbe.Add(new Prosta(i));
        }

        public override void radi()
        {
            nivo++;
            foreach (var n in naredbe)
            {
                n.radi();
            }
            nivo--;
        }

        public override void toString()
        {
            Console.WriteLine(new string(' ', nivo * 2) + "{");
            nivo++;
            foreach (var n in naredbe)
            {
                n.toString();
            }
            nivo--;
            Console.WriteLine(new string(' ', nivo * 2) + "}");
        }
    }

    class Selekcija : Naredba
    {
        private Izraz uslov;
        private Naredba tacnoNaredba;
        private Naredba netacnoNaredba;

        public Selekcija(Izraz uslov, Naredba tacnoNaredba, Naredba netacnoNaredba)
        {
            this.uslov = uslov;
            this.tacnoNaredba = tacnoNaredba;
            this.netacnoNaredba = netacnoNaredba;
        }

        public override void radi()
        {
            nivo++;
            if (uslov.vrednost() != 0)
            {
                tacnoNaredba.radi();
            }
            else
            {
                netacnoNaredba.radi();
            }
            nivo--;
        }

        public override void toString()
        {
            Console.WriteLine(new string(' ', nivo * 2) + "if (" + uslov.toString() + " != 0) ");
            nivo++;
            tacnoNaredba.toString();
            nivo--;
            Console.WriteLine(new string(' ', nivo * 2) + "else ");
            nivo++;
            netacnoNaredba.toString();
            nivo--;
        }
    }

    class Ciklus : Naredba
    {
        private Izraz uslov;
        private Naredba naredba;

        public Ciklus(Izraz uslov, Naredba naredba)
        {
            this.uslov = uslov;
            this.naredba = naredba;
        }

        public override void radi()
        {
            nivo++;
            while (uslov.vrednost() != 0)
            {
                naredba.radi();
            }
            nivo--;
        }

        public override void toString()
        {
            Console.WriteLine(new string(' ', nivo * 2) + "while (" + uslov.toString() + " != 0) ");
            nivo++;
            naredba.toString();
            nivo--;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Promenljiva n = new Promenljiva("n", 5);
            Promenljiva i = new Promenljiva("i", 1);
            Promenljiva f = new Promenljiva("f", 1);
            Promenljiva k = new Promenljiva("k");

            Sekvenca ciklusSekvenca = new Sekvenca();
            ciklusSekvenca.dodaj(new Prosta(new Dodela(i, new Zbir(i, new Konstanta(1)))));
            ciklusSekvenca.dodaj(  new Prosta(new Dodela(f, new Proizvod(f, i))));

            Ciklus ciklus = new Ciklus(
                new Razlika(n, i),
                ciklusSekvenca
            );

            Selekcija selekcija = new Selekcija(
                new Razlika(f, new Konstanta(100)),
                new Prosta(new Dodela(k, new Konstanta(4))),
                new Prosta(new Dodela(k, new Konstanta(5)))
            );

            Sekvenca program = new Sekvenca();
            program.dodaj(n);
            program.dodaj(f);
            program.dodaj(ciklus);
            program.dodaj(selekcija);

            Console.WriteLine("Program:");
            program.toString();

            program.radi();

            Console.WriteLine("Vrednosti promenljivih:");
            Promenljiva.ispisiSve();
        }
    }
}
