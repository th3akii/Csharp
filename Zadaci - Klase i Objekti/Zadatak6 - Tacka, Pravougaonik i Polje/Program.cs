using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Zadaci
{
    class Tacka
    {
        private int x; private int y;

        public Tacka(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Tacka()
        {
            this.x = 0;
            this.y = 0;
        }

        public int getX
        {
            get { return this.x; }
        }
        public int getY
        {
            get { return this.y; }
        }

        public void postavi(Tacka t)
        {
            this.x = t.getX;
            this.y = t.getY;
        }

        public void transliraj(Tacka t)
        {
            this.x += t.getX;
            this.y += t.getY;
        }

        public void toString()
        {
            Console.WriteLine("Koordinate tacke: {0}, {1}", x, y);
        }
    }

    class Pravougaonik
    {
        private Tacka prvo; private Tacka drugo;

        public Pravougaonik()
        {
            prvo = new Tacka(0, 0);
            drugo = new Tacka(1, 1);
        }

        public Pravougaonik(Tacka tacka1, Tacka tacka2) :this()
        {
            if (tacka1.getX != tacka2.getX && tacka1.getY != tacka2.getY)
            {
                prvo = tacka1;
                drugo = tacka2;
            }
        }

        public void transliraj(Tacka t)
        {
            this.prvo.transliraj(t);
            this.drugo.transliraj(t);
        }

        public void vratiUPocetak()
        {
            this.drugo.transliraj(new Tacka(-prvo.getX, -prvo.getY));
            this.prvo.postavi(new Tacka(0, 0));
        }

        public int getMaxX
        {
            get { return drugo.getX; }
        }
        public int getMaxY
        {
            get { return drugo.getY; }
        }
        public int getMinX
        {
            get { return prvo.getX; }
        }
        public int getMinY
        {
            get { return prvo.getY; }
        }

        public bool unutar(Tacka t)
        {
            return prvo.getX <= t.getX && prvo.getY <= t.getY &&
                   drugo.getX >= t.getX && drugo.getY >= t.getY;
        }

        public void toString()
        {
            Console.WriteLine("Pravougaonik: donje levo teme ({0}, {1}), gornje desno teme ({2}, {3})",
                            prvo.getX, prvo.getY, drugo.getX, drugo.getY);
        }
    }

    class Polje
    {
        private int nx; private int ny;
        Pravougaonik? objekat;

        public Polje(int x, int y)
        {
            this.nx = x;
            this.ny = y;
        }

        public Polje(int x, int y, Pravougaonik pravougaonik) : this(x, y)
        {
            pravougaonik.vratiUPocetak();
            this.objekat = pravougaonik;
        }

        public void postavi(Pravougaonik pravougaonik)
        {
            /* 
            postavlja pravougaonik na 0, 0 kao pocetak
            kao sto se trazi u zadatku mada je to glupo
            pa sam stavio pod komentarom 
            Tacka translacija = new Tacka(-pravougaonik.getMinX(), -pravougaonik.getMinY());
            pravougaonik.transliraj(translacija);
            */
            this.objekat = pravougaonik;
        }

        public void ukloni()
        {
            this.objekat = null;
        }

        public bool mozeGore(int n)
        {
            return objekat != null && objekat.getMaxY + n < ny - 1;
        }
        public bool mozeLevo(int n)
        {
            return objekat != null && objekat.getMinX - n > 0;
        }
        public bool mozeDesno(int n)
        {
            return objekat != null && objekat.getMaxX + n < nx - 1;
        }
        public bool mozeDole(int n)
        {
            return objekat != null && objekat.getMinY - n > 0;
        }

        public void idiGore(int n)
        {
            if (mozeGore(n) && objekat != null)
            {
                Tacka tacka = new Tacka(0, n);
                objekat.transliraj(tacka);
            } 
        }
        public void idiDole(int n)
        {
            if (mozeDole(n) && objekat != null)
            {
                Tacka tacka = new Tacka(0, -n);
                objekat.transliraj(tacka);
            }
        }

        public void idiLevo(int n)
        {
            if (mozeLevo(n) && objekat != null)
            {
                Tacka tacka = new Tacka(-n, 0);
                objekat.transliraj(tacka);
            }
        }

        public void idiDesno(int n)
        {
            if (mozeDesno(n) && objekat != null)
            {
                Tacka tacka = new Tacka(n, 0);
                objekat.transliraj(tacka);
            }
        }

        public void toString()
        {
            for (int y = ny - 1; y >= 0; y--)
            {
                for (int x = 0; x < nx; x++)
                {
                    Tacka trenutnaTacka = new Tacka(x, y);

                    if (objekat != null && objekat.unutar(trenutnaTacka))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /* ovo je bio test ali ga ostavljam da ne mora rucno da se proverava
            Polje polje = new Polje(10, 10);
            Console.WriteLine("Prazno polje:");
            polje.toString();

            Tacka donjeLevo = new Tacka(2, 3);
            Tacka gornjeDesno = new Tacka(6, 7);
            Pravougaonik pravougaonik = new Pravougaonik(donjeLevo, gornjeDesno);

            polje.postavi(pravougaonik);
            Console.WriteLine("\nPolje sa pravougaonikom:");
            polje.toString();

            Console.WriteLine("\nPomeri desno za 2:");
            if (polje.mozeDesno(2))
            {
                polje.idiDesno(2);
                Console.WriteLine("Pravougaonik pomeren desno.");
            }
            else
            {
                Console.WriteLine("Ne može desno!");
            }
            polje.toString();

            Console.WriteLine("\nPomeri gore za 1:");
            if (polje.mozeGore(1))
            {
                polje.idiGore(1);
                Console.WriteLine("Pravougaonik pomeren gore.");
            }
            else
            {
                Console.WriteLine("Ne može gore!");
            }
            polje.toString();

            Console.WriteLine("\nPomeri levo za 3:");
            if (polje.mozeLevo(3))
            {
                polje.idiLevo(3);
                Console.WriteLine("Pravougaonik pomeren levo.");
            }
            else
            {
                Console.WriteLine("Ne može levo!");
            }
            polje.toString();

            Console.WriteLine("\nPomeri dole za 2:");
            if (polje.mozeDole(2))
            {
                polje.idiDole(2);
                Console.WriteLine("Pravougaonik pomeren dole.");
            }
            else
            {
                Console.WriteLine("Ne može dole!");
            }
            polje.toString();

            Console.WriteLine("\nUkloni pravougaonik:");
            polje.ukloni();
            polje.toString(); */

            int n;
            Polje polje = new Polje(10, 10);
            Pravougaonik? pravougaonik = null;
            
            Console.WriteLine("Prazno polje:");
            polje.toString();
            int brojPolja;

            do
            {
                Console.WriteLine("(1) pravougaonik | (2) gore | (3) dole | (4) levo | (5) desno | (0) kraj");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1: // postavljanje pravougaonika
                        Console.WriteLine("Unesite koordinate za dve tacke x1, y1, x2, y2:");
                        int x1 = Convert.ToInt32(Console.ReadLine());
                        int y1 = Convert.ToInt32(Console.ReadLine());
                        int x2 = Convert.ToInt32(Console.ReadLine());
                        int y2 = Convert.ToInt32(Console.ReadLine());
                        Tacka donjeLevo = new Tacka(x1, y1);
                        Tacka gornjeDesno = new Tacka(x2, y2);
                        pravougaonik = new Pravougaonik(donjeLevo, gornjeDesno);

                        polje.postavi(pravougaonik);
                        Console.WriteLine("Polje sa pravougaonikom:");
                        polje.toString();
                        break;

                    case 2: // Gore
                        brojPolja = Convert.ToInt32(Console.ReadLine());
                        if (pravougaonik != null)
                        {
                            if (polje.mozeGore(brojPolja))
                            {
                                polje.idiGore(brojPolja);
                                Console.WriteLine("Pravougaonik pomeren gore:");
                            }
                            else
                            {
                                Console.WriteLine("Pravougaonik ne može da se pomeri gore!");
                            }
                            polje.toString();
                        }
                        else
                        {
                            Console.WriteLine("Prvo postavite pravougaonik (opcija 1)!");
                        }
                        break;

                    case 3: // Dole
                        brojPolja = Convert.ToInt32(Console.ReadLine());
                        if (pravougaonik != null)
                        {
                            if (polje.mozeDole(brojPolja))
                            {
                                polje.idiDole(brojPolja);
                                Console.WriteLine("Pravougaonik pomeren dole:");
                            }
                            else
                            {
                                Console.WriteLine("Pravougaonik ne može da se pomeri dole!");
                            }
                            polje.toString();
                        }
                        else
                        {
                            Console.WriteLine("Prvo postavite pravougaonik (opcija 1)!");
                        }
                        break;

                    case 4: // Levo
                        brojPolja = Convert.ToInt32(Console.ReadLine());
                        if (pravougaonik != null)
                        {
                            if (polje.mozeLevo(brojPolja))
                            {
                                polje.idiLevo(brojPolja);
                                Console.WriteLine("Pravougaonik pomeren levo:");
                            }
                            else
                            {
                                Console.WriteLine("Pravougaonik ne može da se pomeri levo!");
                            }
                            polje.toString();
                        }
                        else
                        {
                            Console.WriteLine("Prvo postavite pravougaonik (opcija 1)!");
                        }
                        break;

                    case 5: // Desno
                        brojPolja = Convert.ToInt32(Console.ReadLine());
                        if (pravougaonik != null)
                        {
                            if (polje.mozeDesno(brojPolja))
                            {
                                polje.idiDesno(brojPolja);
                                Console.WriteLine("Pravougaonik pomeren desno:");
                            }
                            else
                            {
                                Console.WriteLine("Pravougaonik ne može da se pomeri desno!");
                            }
                            polje.toString();
                        }
                        else
                        {
                            Console.WriteLine("Prvo postavite pravougaonik (opcija 1)!");
                        }
                        break;

                    case 0: // Kraj
                        Console.WriteLine("Program završen.");
                        break;

                    default:
                        Console.WriteLine("Nepoznata opcija, pokušajte ponovo.");
                        break;
                }
            } while (n != 0);
        }
    }
}
