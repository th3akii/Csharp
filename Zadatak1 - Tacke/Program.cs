using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    public class Tacka
    {
        private double x;
        private double y;

        public Tacka()
        {
            this.x = 0;
            this.y = 0;
        }

        public Tacka(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Tacka(double x)
        {
            this.x = x;
            this.y = 0;
        }

        public void postavi(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void ucitaj()
        {
            this.x = Convert.ToDouble(Console.Read());
            this.y = Convert.ToDouble(Console.Read());
        }

        public double rastojanje()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public double rastojanje(Tacka O)
        {
            double rastojanjeX = Math.Abs(this.x - O.x);
            double rastojanjeY = Math.Abs(this.y - O.y);

            return Math.Sqrt(rastojanjeX * rastojanjeX + rastojanjeY * rastojanjeY);
        }

        public string toString
        {
            get {
                string strX = Convert.ToString(this.x);
                string strY = Convert.ToString(this.y);
                return "( " + strX + " , " + strY  + " ) ";
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Tacka A = new Tacka(2, 3);
            Tacka B = new Tacka();
            Tacka C = new Tacka(4);

            Console.WriteLine(A.toString);
            Console.WriteLine(B.toString);
            Console.WriteLine(C.toString);

            B.postavi(5, 5);
            Console.WriteLine(B.toString);

            Console.WriteLine("Rastojanje tacke A od koordinatnog pocetka je : {0}", A.rastojanje());
            Console.WriteLine("Rastojanje tacke B od koordinatnog pocetka je : {0}", B.rastojanje());
            Console.WriteLine("Rastojanje tacke C od koordinatnog pocetka je : {0}", C.rastojanje());

            Console.WriteLine("Rastojanje tacke A od tacke B je : {0}", A.rastojanje(B));
            Console.WriteLine("Rastojanje tacke B od tacke C je : {0}", B.rastojanje(C));
            Console.WriteLine("Rastojanje tacke C od tacke A je : {0}", C.rastojanje(A));

            Console.WriteLine("x, y?");
            Tacka D = new Tacka();
            D.ucitaj();

            Console.WriteLine("Rastojanje tacke A od tacke B je : {0}", A.rastojanje(B));
            Console.WriteLine("Rastojanje tacke B od tacke C je : {0}", B.rastojanje(C));
            Console.WriteLine("Rastojanje tacke C od tacke A je : {0}", C.rastojanje(A));
            Console.WriteLine("Rastojanje tacke A od tacke D je : {0}", A.rastojanje(D));
        }
    }
}
