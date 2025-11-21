using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci
{
    public interface ZivoBice
    {
        string zivi();
        string predstaviSe();
    }
    public interface Zivotinja : ZivoBice
    {
        string kreciSe();
    }
    public interface Biljka : ZivoBice
    {
        string vrsiFotosintezu();
    }
    public interface Vodozemac : Zivotinja
    {
        string plivaj();
    }
    public interface Ptica : Zivotinja
    {
        string leti();
    }

    public interface Cujni
    {
        string oglasiSe();
    }

    class Zaba : Cujni, Vodozemac
    {
        public string zivi()
        {
            return "uzivam u vodi";
        }

        public string kreciSe()
        {
            return "skakucem";
        }

        public string plivaj()
        {
            return "plivam hitro";
        }

        public string oglasiSe()
        {
            return "kre kre";
        }

        public string predstaviSe()
        {
            return "Ja sam Zaba";
        }
    }

    class Lasta : Cujni, Ptica
    {
        public string zivi()
        {
            return "radujem se prolecu";
        }

        public string kreciSe()
        {
            return "hodam i skakucem";
        }

        public string leti()
        {
            return "letim dugo";
        }

        public string oglasiSe()
        {
            return "ciju ci";
        }

        public string predstaviSe()
        {
            return "Ja sam Lasta";
        }
    }

    class Macka : Cujni, Zivotinja
    {
        public string oglasiSe()
        {
            return "mjau mjau";
        }

        public string kreciSe()
        {
            return "krecem se graciozno";
        }

        public string predstaviSe()
        {
            return "Ja sam Macka";
        }

        public string zivi()
        {
            return "zivim lagodno";
        }
    }

    class Bakterija : ZivoBice
    {
        public string predstaviSe()
        {
            return "Ja sam Bakterija";
        }

        public string zivi()
        {
            return "zivim brzo";
        }
    }

    class Jabuka : Biljka
    {
        public string predstaviSe()
        {
            return "Ja sam Jabuka";
        }

        public string vrsiFotosintezu()
        {
            return "vrsim fotosintezu sa efikasnoscu 5%";
        }

        public string zivi()
        {
            return "rastem na drvetu";
        }
    }

    class Ruza : Biljka
    {
        public string predstaviSe()
        {
            return "Ja sam Ruza";
        }

        public string vrsiFotosintezu()
        {
            return "vrsim fotosintezu uspesno";
        }

        public string zivi()
        {
            return "mirisem divno";
        }
    }

    class Koza : Zivotinja, Cujni
    {
        public string kreciSe()
        {
            return "pentram se po liticama";
        }

        public string predstaviSe()
        {
            return "Ja sam Koza";
        }

        public string zivi()
        {
            return "uzivam na planini";
        }

        public string oglasiSe()
        {
            return "Me-e-e me-e-e-e";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<ZivoBice> zivaBica = new List<ZivoBice>();
            zivaBica.Add(new Zaba());
            zivaBica.Add(new Lasta());
            zivaBica.Add(new Macka());
            zivaBica.Add(new Bakterija());
            zivaBica.Add(new Jabuka());
            zivaBica.Add(new Ruza());
            zivaBica.Add(new Koza());

            foreach (ZivoBice zb in zivaBica)
            {
                StringBuilder sb = new StringBuilder();

                if (zb is Cujni)
                {
                    Cujni cujno = (Cujni)zb;
                    sb.Append(cujno.oglasiSe() + ", ");
                }

                sb.Append(zb.predstaviSe() + ", ");
                sb.Append(zb.zivi() + ", ");

                if (zb is Zivotinja)
                {
                    Zivotinja zivotinja = (Zivotinja)zb;
                    sb.Append(zivotinja.kreciSe() + ", ");

                    if (zb is Vodozemac)
                    {
                        Vodozemac vodozemac = (Vodozemac)zb;
                        sb.Append(vodozemac.plivaj() + ", ");
                    }
                    else if (zb is Ptica)
                    {
                        Ptica ptica = (Ptica)zb;
                        sb.Append(ptica.leti() + ", ");
                    }
                }
                else if (zb is Biljka)
                {
                    Biljka biljka = (Biljka)zb;
                    sb.Append(biljka.vrsiFotosintezu() + ", ");
                }

                Console.WriteLine(sb.ToString().TrimEnd(',', ' '));
            }

            Console.Write("Broj dana? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Dan #" + i);
                foreach (ZivoBice zb in zivaBica)
                {
                    Console.WriteLine(zb.zivi());
                }
                foreach (ZivoBice zb in zivaBica)
                {
                    if (zb is Cujni)
                    {
                        Cujni cujni = (Cujni)zb;
                        Console.WriteLine(cujni.oglasiSe());
                    }
                }
            }
        }
    }
}
