using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Stan
    {
        private int brStanara;
        private int kvadratura;

        public Stan(int kvadratura, int brStanara)
        {
            this.kvadratura = kvadratura;
            this.brStanara = brStanara;
        }

        public int BrStanara
        {
            get { return brStanara; }
            set { brStanara = value; }
        }

        public int Kvadratura
        {
            get { return kvadratura; }
            set { kvadratura = value; }
        }

        public string toString()
        {
            return $"Povrsina stana je {kvadratura}m2\n" +
                    $"Broj stanara je {brStanara}";
        }

        public virtual double porez(double cenaPoKvadratu)
        {
            double umanjenje = Math.Max(0, (brStanara - 2) * 0.05);
            return kvadratura * cenaPoKvadratu * (1 - umanjenje);
        }
    }

    abstract class StambeniObjekat
    {
        protected string adresa;

        public StambeniObjekat(string adresa)
        {
            this.adresa = adresa;
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        public abstract string toString();

        public abstract double porez(double cenaPoKvadratu);
    }

    class Kuca : StambeniObjekat
    {
        private Stan stan;

        public Kuca(string adresa, int kvadratura, int brStanara) : base(adresa)
        {
            stan = new Stan(kvadratura, brStanara);
        }

        public override string toString()
        {
            return "Kuca:\n" + "Adresa: {adresa}\n" + stan.toString();
        }

        public override double porez(double cenaPoKvadratu)
        {
            return stan.porez(cenaPoKvadratu);
        }
    }

    class Zgrada : StambeniObjekat
    {
        private int brStanova;
        private List<Stan> stanovi = new List<Stan>();

        public Zgrada(string adresa, int brStanova) : base(adresa)
        {
            
            this.brStanova = brStanova;
        }

        public void dodajStan(int kvadratura, int brStanara)
        {
            if (stanovi.Count < brStanova)
            {
                stanovi.Add(new Stan(kvadratura, brStanara));
            }
            else
            {
                Console.WriteLine("Ne mozete dodati vise stanova u zgradu.");
            }
        }

        public override string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Zgrada:\n");
            sb.Append($"Adresa: {adresa}\n");
            sb.Append($"Broj stanova je {brStanova}\n");
            for (int i = 0; i < stanovi.Count; i++)
            {
                sb.Append($"Stan #{i + 1}:\n");
                sb.Append(stanovi[i].toString() + "\n");
            }
            return sb.ToString();
        }

        public override double porez(double cenaPoKvadratu)
        {
            double ukupno = 0;
            foreach (Stan s in stanovi)
            {
                ukupno += s.porez(cenaPoKvadratu);
            }
            return ukupno;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Adresa? ");
            string adresa = Console.ReadLine();

            Console.Write("Tip stambenog objekta? (k za kucu, z za zgradu) ");
            char tip = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            StambeniObjekat objekat;

            if (tip == 'k')
            {
                Console.Write("Povrsina? ");
                double povrsina = double.Parse(Console.ReadLine());

                Console.Write("Broj stanara? ");
                int brojStanara = int.Parse(Console.ReadLine());

                objekat = new Kuca(adresa, (int)povrsina, brojStanara);
            }
            else if (tip == 'z')
            {
                Console.Write("Broj stanova? ");
                int brojStanova = int.Parse(Console.ReadLine());

                Zgrada zgrada = new Zgrada(adresa, brojStanova);

                for (int i = 0; i < brojStanova; i++)
                {
                    Console.WriteLine($"{i + 1}. stan:");
                    Console.Write("Povrsina? ");
                    double povrsina = double.Parse(Console.ReadLine());

                    Console.Write("Broj stanara? ");
                    int brojStanara = int.Parse(Console.ReadLine());

                    zgrada.dodajStan((int)povrsina, brojStanara);
                }

                objekat = zgrada;
            }
            else
            {
                Console.WriteLine("Nepoznat tip stambenog objekta.");
                return;
            }

            Console.Write("Cena poreza po kvadratu? ");
            double cenaPoKvadratu = double.Parse(Console.ReadLine());

            double ukupnoZaPlacanje = objekat.porez(cenaPoKvadratu);

            Console.WriteLine($"Treba da bude placeno {ukupnoZaPlacanje:F2} dinara za porez za objekat:");
            Console.WriteLine(objekat.toString());
        }
    }
}
