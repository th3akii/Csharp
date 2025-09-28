using System;
using System.Collections.Generic;
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
                return this.re + " - " + -1*this.im + "i";
            }
            else
            {
                return Convert.ToString(this.re);
            }
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Kompleksni z1 = new Kompleksni(0, 0);
            Console.WriteLine("Unos prvog kompleksnog broja:");
            z1.ucitaj();

            Kompleksni z2 = new Kompleksni(2, -5);

            // Prikaz brojeva
            Console.WriteLine("\nPrvi broj: " + z1.toString());
            Console.WriteLine("Drugi broj: " + z2.toString());

            Kompleksni zbir = z1.zbir(z2);
            Console.WriteLine("\nZbir: " + zbir.toString());

            Kompleksni razlika = z1.razlika(z2);
            Console.WriteLine("Razlika: " + razlika.toString());

            Kompleksni proizvod = z1.proizvod(z2);
            Console.WriteLine("Proizvod: " + proizvod.toString());

            Kompleksni kolicnik = z1.kolicnik(z2);
            Console.WriteLine("Količnik: " + kolicnik.toString());

            Console.WriteLine("\nModul prvog broja: " + z1.abs());

            Kompleksni konj = z1.konjg();
            Console.WriteLine("Konjugovani prvog broja: " + konj.toString());
        }
    }
}