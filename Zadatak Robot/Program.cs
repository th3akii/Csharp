using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Robot
    {
        private int x; private int y;
        private char smer;

        public Robot(int x, int y, char smer)
        {
            this.x = x;
            this.y = y;
            if (smer != 'N' || smer != 'S' || smer != 'W' || smer != 'E')
            {
                this.smer = smer;
            }
            else
            {
                throw new ArgumentException("Orijentacija mora biti N, S, E ili W");
            }
        }

        public void napred()
        {
            switch(this.smer)
            {
                case 'N':
                    this.y++;
                    break;
                case 'S':
                    this.y--;
                    break;
                case 'W':
                    this.x--;
                    break;
                case 'E':
                    this.x++;
                    break;
            }
        }
        public void napred(int n)
        {
            switch (this.smer)
            {
                case 'N':
                    this.y += n;
                    break;
                case 'S':
                    this.y -= n;
                    break;
                case 'W':
                    this.x -= n;
                    break;
                case 'E':
                    this.x += n;
                    break;
            }
        }

        public void nalevo()
        {
            switch (this.smer)
            {
                case 'N':
                    this.smer = 'W';
                    break;
                case 'S':
                    this.smer = 'E';
                    break;
                case 'W':
                    this.smer = 'S';
                    break;
                case 'E':
                    this.smer = 'N';
                    break;
            }
        }
        public void nadesno()
        {
            switch (this.smer)
            {
                case 'N':
                    this.smer = 'E';
                    break;
                case 'S':
                    this.smer = 'W';
                    break;
                case 'W':
                    this.smer = 'N';
                    break;
                case 'E':
                    this.smer = 'S';
                    break;
            }
        }

        public string toString()
        {
            return "Robot(" + x + ", " + y + ", " + smer + ")";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Robot r1 = new Robot(2, 3, 'N');

            r1.napred();  // 1 polje napred
            r1.nadesno(); // okret nadesno
            r1.napred(5); // pet polja napred
            Console.WriteLine(r1.toString()); // ispis podataka o robotu
        }
    }
}
