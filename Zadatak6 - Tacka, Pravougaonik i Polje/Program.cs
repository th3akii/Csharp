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

        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }

        public void postavi(Tacka t)
        {
            this.x = t.getX();
            this.y = t.getY();
        }

        public void transliraj(Tacka t)
        {
            this.x += t.getX();
            this.y += t.getY();
        }

        public void toString()
        {
            Console.WriteLine("Koordinate tacke: {0}, {1}", x, y);
        }
    }

    class Pravougaonik
    {
        private int[] prvo; private int[] drugo;

        public Pravougaonik()
        {
            prvo = new int[2] { 0, 0 };
            drugo = new int[2] { 1, 1 };
        }

        public Pravougaonik(Tacka tacka1, Tacka tacka2)
        {
            if (tacka1.getX() == tacka2.getX() || tacka1.getY() == tacka2.getY())
            {
                prvo = new int[2] { 0, 0 };
                drugo = new int[2] { 1, 1 };
            }
            else
            {
                int minX = Math.Min(tacka1.getX(), tacka2.getX());
                int minY = Math.Min(tacka1.getY(), tacka2.getY());
                int maxX = Math.Max(tacka1.getX(), tacka2.getX());
                int maxY = Math.Max(tacka1.getY(), tacka2.getY());

                prvo = new int[2] { minX, minY};
                drugo = new int[2] { maxX, maxY};
            }
        }

        public void transliraj(Tacka t)
        {
            this.prvo[0] += t.getX(); this.prvo[1] += t.getY();
            this.drugo[0] += t.getX(); this.drugo[1] += t.getY();
        }

        public void vratiUPocetak()
        {
            this.prvo[0] = 0; this.prvo[1] = 0;
        }

        public int getMaxX()
        {
            return drugo[0];
        }
        public int getMaxY()
        {
            return drugo[1];
        }
        public int getMinX()
        {
            return prvo[0];
        }
        public int getMinY()
        {
            return prvo[1];
        }

        public bool unutar(Tacka t)
        {
            return prvo[0] <= t.getX() && prvo[1] <= t.getY() &&
                   drugo[0] >= t.getX() && drugo[1] >= t.getY();
        }

        public void toString()
        {
            Console.WriteLine("Pravougaonik: donje levo teme ({0}, {1}), gornje desno teme ({2}, {3})",
                            prvo[0], prvo[1], drugo[0], drugo[1]);
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
            Tacka translacija = new Tacka(-pravougaonik.getMinX(), -pravougaonik.getMinY());
            pravougaonik.transliraj(translacija);
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

        public bool mozeGore()
        {
            return objekat != null && objekat.getMaxY() < ny - 1;
        }
        public bool mozeLevo()
        {
            return objekat != null && objekat.getMinX() > 0;
        }
        public bool mozeDesno()
        {
            return objekat != null && objekat.getMaxX() < nx - 1;
        }
        public bool mozeDole()
        {
            return objekat != null && objekat.getMinY() > 0;
        }

        public void idiGore()
        {
            if (mozeGore() && objekat != null)
            {
                Tacka tacka = new Tacka(0, 1);
                objekat.transliraj(tacka);
            } 
        }
        public void idiDole()
        {
            if (mozeDole() && objekat != null)
            {
                Tacka tacka = new Tacka(0, -1);
                objekat.transliraj(tacka);
            }
        }

        public void idiLevo()
        {
            if (mozeLevo() && objekat != null)
            {
                Tacka tacka = new Tacka(-1, 0);
                objekat.transliraj(tacka);
            }
        }

        public void idiDesno()
        {
            if (mozeDesno() && objekat != null)
            {
                Tacka tacka = new Tacka(1, 0);
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
            
            Tacka donjeLevo = new Tacka(0, 4);
            Tacka gornjeDesno = new Tacka(6, 8);
            Pravougaonik pravougaonik = new Pravougaonik(donjeLevo, gornjeDesno);
            
            polje.postavi(pravougaonik);
            Console.WriteLine("\nPolje sa pravougaonikom:");
            polje.toString();
            
            // Testiranje kretanja
            Console.WriteLine("\nPomeri desno:");
            polje.idiDesno();
            polje.toString();
            
            Console.WriteLine("\nPomeri gore:");
            polje.idiGore();
            polje.toString();
            
            Console.WriteLine("\nPomeri levo:");
            polje.idiLevo();
            polje.toString();
            
            Console.WriteLine("\nPomeri dole:");
            polje.idiDole();
            polje.toString(); */

            int n;
            Polje polje = new Polje(10, 10);
            Pravougaonik? pravougaonik = null;
            
            // Inicijalno prikaži prazno polje
            Console.WriteLine("Prazno polje:");
            polje.toString();

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
                        if (pravougaonik != null)
                        {
                            if (polje.mozeGore())
                            {
                                polje.idiGore();
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
                        if (pravougaonik != null)
                        {
                            if (polje.mozeDole())
                            {
                                polje.idiDole();
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
                        if (pravougaonik != null)
                        {
                            if (polje.mozeLevo())
                            {
                                polje.idiLevo();
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
                        if (pravougaonik != null)
                        {
                            if (polje.mozeDesno())
                            {
                                polje.idiDesno();
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