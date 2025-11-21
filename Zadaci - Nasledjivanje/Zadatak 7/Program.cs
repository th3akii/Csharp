using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Tekst
    {
        private string tekst;

        public Tekst(string tekst)
        {
            this.tekst = tekst;
        }

        public string Txt
        {
            get { return tekst; }
            set { tekst = value; }
        }
        
        public string toString()
        {
            return "Poruka: " + tekst;
        }
    }

    abstract class Transformacija
    {
        public abstract Tekst sifruj(Tekst t);
        public abstract Tekst desifruj(Tekst t);
        public abstract string toString();
    }

    class Translacija : Transformacija
    {
        private int pomeraj;

        public Translacija(int pomeraj)
        {
            this.pomeraj = pomeraj;
        }
        
        public override Tekst sifruj(Tekst t)
        {
            string noviTekst = transliraj(t.Txt, pomeraj);
            return new Tekst(noviTekst);
        }

        public override Tekst desifruj(Tekst t)
        {
            string noviTekst = transliraj(t.Txt, -pomeraj);
            return new Tekst(noviTekst);
        }

        private string transliraj(string tekst, int pomeraj)
        {
            char[] niz = tekst.ToCharArray();
            for (int i = 0; i < niz.Length; i++)
            {
                niz[i] = (char)(niz[i] + pomeraj);
            }

            return new string(niz);
        }

        public override string toString()
        {
            return "Translacija za " + pomeraj;
        }
    }

    class Rotacija : Transformacija
    {
        private string smer;
        private int brMesta;

        public Rotacija(string smer, int brMesta)
        {
            this.smer = smer.ToLower();
            this.brMesta = brMesta;
        }

        public override Tekst sifruj(Tekst t)
        {
            string noviTekst = rotiraj(t.Txt, smer);
            return new Tekst(noviTekst);
        }

        public override Tekst desifruj(Tekst t)
        {
            if (smer == "levo")
            {
                string noviTekst = rotiraj(t.Txt, "desno");
                return new Tekst(noviTekst);
            }
            else
            {
                string noviTekst = rotiraj(t.Txt, "levo");
                return new Tekst(noviTekst);
            }
        }

        private string rotiraj(string tekst, string smer)
        {
            char[] niz = tekst.ToCharArray();
            brMesta = brMesta % niz.Length;

            if (smer == "levo")
            {
                for (int i = 0; i < brMesta; i++)
                {
                    char prvi = niz[0];
                    for (int j = 0; j < niz.Length - 1; j++)
                    {
                        niz[j] = niz[j + 1];
                    }
                    niz[niz.Length - 1] = prvi;
                }
            }
            else if (smer == "desno")
            {
                for (int i = 0; i < brMesta; i++)
                {
                    char poslednji = niz[niz.Length - 1];
                    for (int j = niz.Length - 1; j > 0; j--)
                    {
                        niz[j] = niz[j - 1];
                    }
                    niz[0] = poslednji;
                }
            }

            return new string(niz);
        }

        public override string toString()
        {
            return "Rotacija za " + brMesta + " mesta u " + smer;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Unesi tekst:");
            string ulaz = Console.ReadLine();
            Tekst tekst = new Tekst(ulaz);

            Console.Write("Broj transformacija? ");
            int n = int.Parse(Console.ReadLine());

            List<Transformacija> transformacije = new List<Transformacija>();
            Console.WriteLine("Niz transformacija?");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Unesite tip transformacije (r/t): ");
                string tip = Console.ReadLine();
                if (tip == "r")
                {
                    Console.Write("Unesite broj mesta: ");
                    int brMesta = int.Parse(Console.ReadLine());
                    Console.Write("Unesite smer (levo/desno): ");
                    string smer = Console.ReadLine();
                    transformacije.Add(new Rotacija(smer, brMesta));
                }
                else if (tip == "t")
                {
                    Console.Write("Unesite pomeraj: ");
                    int pomeraj = int.Parse(Console.ReadLine());
                    transformacije.Add(new Translacija(pomeraj));
                }
                else
                {
                    Console.WriteLine("Nepoznat tip transformacije.");
                    i--;
                }
            }
            
            Tekst sifrovaniTekst = tekst;
            foreach (Transformacija t in transformacije)
            {
                sifrovaniTekst = t.sifruj(sifrovaniTekst);
            }

            Console.WriteLine("Sifrovani tekst:");
            Console.WriteLine(sifrovaniTekst.Txt);

            Tekst desifrovaniTekst = sifrovaniTekst;
            for (int i = transformacije.Count - 1; i >= 0; i--)
            {
                desifrovaniTekst = transformacije[i].desifruj(desifrovaniTekst);
            }
            
            Console.WriteLine("Desifrovani tekst:");
            Console.WriteLine(desifrovaniTekst.Txt);
        }
    }
}
