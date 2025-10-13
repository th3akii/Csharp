using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadaci
{
    class Kompleksni
    {
        private double re; private double im;

        public Kompleksni(double re)
        {
            this.re = re;
        }

        public Kompleksni(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public double getRe { get { return this.re; } }
        public double getIm { get { return this.im; } }

        public double abs()
        {
            return Math.Sqrt(this.re * this.re + this.im * this.im);
        }
        public Kompleksni konjg()
        {
            return new Kompleksni(this.re, -this.im);
        }
        public Kompleksni zbir(Kompleksni z)
        {
            return new Kompleksni(this.re + z.re, this.im + z.im);
        }
        public Kompleksni razlika(Kompleksni z)
        {
            return new Kompleksni(this.re - z.re, this.im - z.im);
        }
        public Kompleksni proizvod(Kompleksni z)
        {
            double real = this.re * z.re - this.im * z.im;
            double imag = this.re * z.im + this.im * z.re;
            return new Kompleksni(real, imag);
        }
        public Kompleksni kolicnik(Kompleksni z)
        {
            double nazivnik = z.re * z.re + z.im * z.im;
            double real = (this.re * z.re + this.im * z.im) / nazivnik;
            double imag = (this.im * z.re - this.re * z.im) / nazivnik;
            return new Kompleksni(real, imag);
        }

        public void ucitaj()
        {
            Console.WriteLine("Unesite realni deo broja");
            this.re = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Unesite imaginarni deo broja");
            this.im = Convert.ToDouble(Console.ReadLine());
        }

        public string toString()
        {
            if (this.im > 0)
            {
                return this.re + " + " + this.im + "i";
            }
            else if (this.im < 0)
            {
                return this.re + " - " + -1 * this.im + "i";
            }
            else
            {
                return Convert.ToString(this.re);
            }
        }
    }

    class NizKompleksni
    {
        private Kompleksni[] nizKompleksnih;
        private int index;

        public NizKompleksni(int n)
        {
            this.nizKompleksnih = new Kompleksni[n];
            this.index = 0;
        }
        public NizKompleksni()
        {
            this.nizKompleksnih = new Kompleksni[10];
            this.index = 0;
        }

        public int duzina { get { return this.nizKompleksnih.Length; } }

        public void postavi(Kompleksni z) { this.nizKompleksnih[index++] = z; }

        public void toString()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(nizKompleksnih[i].toString());
            }
        }

       public Kompleksni poli(Kompleksni z)
        {
            Kompleksni poli = new Kompleksni(0, 0);
            Kompleksni stepen = new Kompleksni(1, 0);
        
            for (int i = 0; i < index; i++)
            {
                poli = poli.zbir(nizKompleksnih[i].proizvod(stepen));
                stepen = stepen.proizvod(z);
            }
            return poli;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {  
            Console.Write("Unesite stepen polinoma: ");
            int n = Convert.ToInt32(Console.ReadLine());
            NizKompleksni polinom = new NizKompleksni(n + 1);

            Console.WriteLine("Unesite koeficijente polinoma (realni i imaginarni deo):");
            for (int i = 0; i <= n; i++)
            {
                Console.Write("a[{0}] realni deo: ", i);
                double re = Convert.ToDouble(Console.ReadLine());
                Console.Write("a[{0}] imaginarni deo: ", i);
                double im = Convert.ToDouble(Console.ReadLine());
                polinom.postavi(new Kompleksni(re, im));
            }

            Console.Write("Unesite xmin: ");
            double xmin = Convert.ToDouble(Console.ReadLine());
            Console.Write("Unesite xmax: ");
            double xmax = Convert.ToDouble(Console.ReadLine());
            Console.Write("Unesite dx: ");
            double dx = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nVrednosti polinoma za x iz intervala:");
            for (double x = xmin; x <= xmax; x += dx)
            {
                Kompleksni vrednost = polinom.poli(new Kompleksni(x, 0));
                Console.WriteLine("x[{0}] = {1}", x, vrednost.toString());
            }
        }
    }
}
