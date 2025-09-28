using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    class Karta
    {
        public enum Boja { Pik, Karo, Herc, Tref };
        private char broj;
        private Boja znak;

        public Karta(string karta)
        {
            if (karta.Length > 2)
            {
                throw new ArgumentException("Karta može imati maksimalno 2 karaktera.");
            }
            this.broj = karta[0];
            switch (karta[1])
            {
                case 'P':
                    this.znak = Boja.Pik;
                    break;
                case 'H':
                    this.znak = Boja.Herc;
                    break;
                case 'K':
                    this.znak = Boja.Karo;
                    break;
                case 'T':
                    this.znak = Boja.Tref;
                    break;
                default:
                    throw new ArgumentException("Karta moze imati znak P, K, H ili T");
            }
        }

        private int getBroj
        {
            get
            {
                switch (broj)
                {
                    case 'A': return 15;
                    case 'K': return 13;
                    case 'Q': return 12;
                    case 'J': return 11;
                    case 'D': return 10;
                    case '9': return 9;
                    case '8': return 8;
                    case '7': return 7;
                    case '6': return 6;
                    case '5': return 5;
                    case '4': return 4;
                    case '3': return 3;
                    case '2': return 2;
                    default:
                        throw new ArgumentException("Nevalidan broj karte.");
                }
            }
        }

        public static Boja BojaPrveKarte;
        public static Boja AdutskaBoja;

        public int vrednost
        {
            get
            {
                int osnovnaVrednost = getBroj;
                int bonus = 0;

                if (this.znak == AdutskaBoja)
                {
                    bonus += 40;
                }
                if (znak == BojaPrveKarte)
                {
                    bonus += 20;
                }

                return osnovnaVrednost + bonus;
            }
        }

        public Boja bojaKarte
        {
            get
            {
                return znak;
            }
        }
        
        public string toString
        {
            get { return getBroj + " " + znak; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int brojKarata = 5;
                Karta[] baceneKarte = new Karta[brojKarata];
                baceneKarte[0] = new Karta("DT");
                baceneKarte[1] = new Karta("AT");
                baceneKarte[2] = new Karta("AP");
                baceneKarte[3] = new Karta("4K");
                baceneKarte[4] = new Karta("3K");

                Karta.AdutskaBoja = Karta.Boja.Karo;
                Karta.BojaPrveKarte = baceneKarte[0].bojaKarte;

                // Određivanje najjače karte
                int maxVr = baceneKarte[0].vrednost;
                int iMax = 0;
                for (int i = 1; i < brojKarata; i++)
                {
                    if (baceneKarte[i].vrednost > maxVr)
                    {
                        maxVr = baceneKarte[i].vrednost;
                        iMax = i;
                    }
                }

                // Prikaz najjače karte i njenog indeksa
                Console.WriteLine("Nosi igrac sa indeksom {0}", iMax);
                Console.WriteLine("To je karta {0}", baceneKarte[iMax].toString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
