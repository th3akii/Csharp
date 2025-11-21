using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadaci
{
    public class Autobus
    {
        private bool[] sedista = new bool[50];
        Int16 brojSlobondnihMesta = 50;

        public Autobus()
        {
            for (int i = 0; i < 50; i++)
            {
                sedista[i] = true;
            }
        }

        public void uvesti (int n)
        {
            if (n > 50 && n < 0) {
                Console.WriteLine("Ima samo 50 sedista");
            }
            else if (sedista[n] != true)
            {
                Console.WriteLine("Sediste je zauzeto");
            }
            else
            {
                sedista[n] = false;
                brojSlobondnihMesta--;
            }
        }

        public void ImaSlobodnihMesta()
        {
            if (brojSlobondnihMesta == 0)
            {
                Console.WriteLine("Nema slobondih sedista!");
            }
            else
            {
                Console.WriteLine("Ima slobodnih mesta!");
            }
        }


        public void BrojSlobodnihMesta()
        {
            Console.WriteLine("Ima {0} slobodnih mesta!", brojSlobondnihMesta);
        }


        public void BrojZauzetihMesta()
        {
            Console.WriteLine("{0} mesta je zauzeto!", 50 - brojSlobondnihMesta);
        }


        public void toString(int n)
        {
            if (sedista[n] == true) {
                Console.WriteLine("Sedise {0} je slobodno", n+1);
            }
            else
            {
                Console.WriteLine("Sedise {0} je zauzeto", n+1);
            }
        }
    }


    public class AutobusTest
    {
        Autobus autobus = new Autobus();

        public AutobusTest()
        {
            autobus.uvesti(0);
            autobus.uvesti(19);
            autobus.uvesti(49);
        }

        public void IspisiStanje()
        {
            for (int i = 0; i < 50; i++)
            {
                autobus.toString(i);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AutobusTest test = new AutobusTest();
            test.IspisiStanje();
        }
    }
}
