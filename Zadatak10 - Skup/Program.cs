using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Skup
    {
        private double[] niz;
        private int brojClanova;

        public Skup()
        {
            this.niz = new double[100];
            this.brojClanova = 0;
        }
        public Skup(double n) : this()
        {
            niz[0] = n;
            this.brojClanova = 1;
        }

        public void kopiraj(double[] ulazniNiz, int n)
        {
            int index = 0;
            for (int i = 0; i < n && i < ulazniNiz.Length; i++)
            {
                if (ulazniNiz[i] != 0) { niz[index++] = ulazniNiz[i]; }
            }
            brojClanova = index;
        }

        public void unija(Skup skup1, Skup skup2)
        {
            //verovatno postoji mnogo bolji nacin samo ja ne znam
            int index = 0;
            HashSet<double> postoji = new HashSet<double>();

            for (int i = 0; i < skup1.brojClanova; i++)
            {
                this.niz[index++] = skup1.niz[i];
                postoji.Add(skup1.niz[i]);
            }
            for (int i = 0; i < skup2.brojClanova; i++)
            {
                if (!postoji.Contains(skup2.niz[i]))
                {
                    niz[index++] = skup2.niz[i];
                    postoji.Add(skup2.niz[i]);
                }
            }
            brojClanova = index;
        }

        public void presek(Skup skup1, Skup skup2)
        {
            int index = 0;
            HashSet<double> postoji = new HashSet<double>();

            for (int i = 0; i < skup1.brojClanova; i++)
            {
                postoji.Add(skup1.niz[i]);
            }
            for (int i = 0; i < skup2.brojClanova; i++)
            {
                if (postoji.Contains(skup2.niz[i]))
                {
                    niz[index++] = skup2.niz[i];
                }
            }
            brojClanova = index;
        }

        public void razlika(Skup skup1, Skup skup2)
        {
            int index = 0;
            HashSet<double> postoji = new HashSet<double>();

            for (int i = 0; i < skup2.brojClanova; i++)
            {
                postoji.Add(skup2.niz[i]);
            }
            for (int i = 0; i < skup1.brojClanova; i++)
            {
                if (!postoji.Contains(skup1.niz[i]))
                {
                    niz[index++] = skup1.niz[i];
                }
            }
            brojClanova = index;
        }

        public void citaj(double n)
        {
            if (brojClanova < niz.Length)
                niz[brojClanova++] = n;
        }

        public int velicina { get { return brojClanova; } }

        public void toString()
        {
            if (brojClanova != 0)
            {
                for (int i = 0; i < brojClanova - 1; i++)
                {
                    Console.Write(niz[i] + ", ");
                }
                Console.Write(niz[brojClanova - 1]);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Skup je prazan");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /* test sa fiksnim vrednostima
            Skup skupA = new Skup();
            skupA.kopiraj(new double[] { 1, 2, 3, 4, 0 }, 5);

            Skup skupB = new Skup();
            skupB.kopiraj(new double[] { 0, 2, 4, 6 }, 4);

            Console.Write("Skup A: ");
            skupA.toString();
            Console.Write("Skup B: ");
            skupB.toString();

            Skup unija = new Skup();
            unija.unija(skupA, skupB);
            Console.Write("Unija: ");
            unija.toString();

            Skup presek = new Skup();
            presek.presek(skupA, skupB);
            Console.Write("Presek: ");
            presek.toString();

            Skup razlika = new Skup();
            razlika.razlika(skupA, skupB);
            Console.Write("Razlika A \\ B: ");
            razlika.toString();

            Console.WriteLine(new string('-', 40));

            Skup skupC = new Skup();
            skupC.citaj(5);
            skupC.citaj(7);
            skupC.citaj(9);

            Skup skupD = new Skup();
            skupD.citaj(7);
            skupD.citaj(8);
            skupD.citaj(9);
            skupD.citaj(10);

            Console.Write("Skup C: ");
            skupC.toString();
            Console.Write("Skup D: ");
            skupD.toString();

            Skup unija2 = new Skup();
            unija2.unija(skupC, skupD);
            Console.Write("Unija: ");
            unija2.toString();

            Skup presek2 = new Skup();
            presek2.presek(skupC, skupD);
            Console.Write("Presek: ");
            presek2.toString();

            Skup razlika2 = new Skup();
            razlika2.razlika(skupC, skupD);
            Console.Write("Razlika C \\ D: ");
            razlika2.toString();
            */
        }
    }
}
