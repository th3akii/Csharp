using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    abstract class Vozilo
    {
        protected int tezina;
        public Vozilo(int t)
        {
            tezina = t;
        }
        abstract public string vrsta();

        abstract public int Tezina;
        abstract public void toString();
    }

    class TeretnoVozilo : Vozilo
    {
        private int teret;
        public TeretnoVozilo(int tez, int ter) : base(tez)
        {
            teret = ter;
        }

        public override string vrsta()
        {
            return "Teretno vozilo";
        }

        public override int Tezina
        {
            get { return tezina + teret; }
        }

        public override void toString()
        {
            Console.WriteLine($"{vrsta()} [{tezina}, {teret}] - {Tezina} ");
        }
    }

    class PutnickoVozilo : Vozilo
    {
        private int brojPutnika;
        private int tezinaPutnika;

        public PutnickoVozilo(int tez, int brPutnika, int tezinaPoPutniku) : base(tez)
        {
            brojPutnika = brPutnika;
            tezinaPutnika = brPutnika * tezinaPoPutniku;
        }

        public override string vrsta()
        {
            return "Putnicko vozilo";
        }
        
        public override int Tezina
        {
            get { return tezina + tezinaPutnika; }
        }

        public override void toString()
        {
            Console.WriteLine($"{vrsta()} [{tezina}, {tezinaPutnika}] - {Tezina} ");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vozilo> vozila = new List<Vozilo>();
            string unos;

            do
            {
                Console.Write("Vrsta vozila (T, P)? ");
                unos = Console.ReadLine()?.ToLower();

                if (unos == "t")
                {
                    Console.Write("Sopstvena tezina? ");
                    int tezina = int.Parse(Console.ReadLine());

                    Console.Write("Teret? ");
                    int teret = int.Parse(Console.ReadLine());

                    vozila.Add(new TeretnoVozilo(tezina, teret));
                }
                else if (unos == "p")
                {
                    Console.Write("Sopstvena tezina? ");
                    int tezina = int.Parse(Console.ReadLine());

                    Console.Write("Srednja tezina putnika? ");
                    int tezinaPoPutniku = int.Parse(Console.ReadLine());

                    Console.Write("Broj putnika? ");
                    int brojPutnika = int.Parse(Console.ReadLine());

                    vozila.Add(new PutnickoVozilo(tezina, brojPutnika, tezinaPoPutniku));
                }
                else
                {
                    break;
                }
            } while (true);

            Console.Write("Nosivost mosta? ");
            int nosivostMosta = int.Parse(Console.ReadLine());

            Console.WriteLine("Mogu da predju most:");
            foreach (var vozilo in vozila)
            {
                if (vozilo.Tezina <= nosivostMosta)
                {
                    vozilo.toString();
                }
            }
        }
    }
}
