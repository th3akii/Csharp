using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadaci1
{
   class DNK
   {
       private char[] lanac;
       private int brojKarika;
       private int maxBrojKarika;


       public DNK(int maxBrojKarika)
       {
           if (maxBrojKarika <= 0)
           {
               this.maxBrojKarika = 256;
           }
           else
           {
               this.maxBrojKarika = maxBrojKarika;
           }
           this.brojKarika = 0;
           this.lanac = new char[this.maxBrojKarika];
       }


       public DNK(string deoLanca, int maxBrojKarika) : this(maxBrojKarika)
       {


           for (int i = 0; i < deoLanca.Length; i++)
           {
               this.lanac[i] = deoLanca[i];
               brojKarika++;
           }
       }


       public bool jelValdinaKarika(char karika)
       {
           switch (karika)
           {
               case 'A':
                   return true;
               case 'C':
                   return true;
               case 'G':
                   return true;
               case 'T':
                   return true;
               default:
                   return false;
           }
       }




       public void dodaj(char karika)
       {
           if (brojKarika < maxBrojKarika && jelValdinaKarika(karika))
           {
               this.lanac[this.brojKarika++] = karika;
           }
           else
           {
               Console.WriteLine("Doslo je do greske!");
           }
       }


       public void getA()
       {
           int zbir = 0;
           for (int i = 0; i < this.lanac.Length; i++)
           {
               if (this.lanac[i] == 'A')
               {
                   zbir++;
               }
           }
           Console.WriteLine("Ima {0} A", zbir);
       }


       public void getTrenutnaDuzina()
       {
           Console.WriteLine("Trenutna duzina lanca je {0}", brojKarika);
       }


       public void getMaxDuzina()
       {
           Console.WriteLine("Maksimalna duzina lanca je {0}", maxBrojKarika);
       }


       public void getSlobodnaMesta()
       {
           Console.WriteLine("Ima {0} slobodnih mesta", maxBrojKarika - brojKarika);
       }


       public void IspisiLanac()
       {
           for (int i = 0; i < brojKarika; i++)
           {
               Console.Write(this.lanac[i]);
           }
           Console.WriteLine();
       }


       public void IspisiObrnutiLanac()
       {
           for (int i = brojKarika - 1; i >= 0; i--)
           {
               Console.Write(this.lanac[i]);
           }
           Console.WriteLine();
       }
   }


   internal class Program
   {
       static void Main(string[] args)
       {
           /*
           int n = Convert.ToInt32(Console.ReadLine());
           DNK dnk1 = new DNK(n);  DNK dnk2 = new DNK("ACCGTTTT", n);
           dnk1.dodaj('A');  dnk1.dodaj('T');  dnk1.dodaj('C');
           dnk1.getSlobodnaMesta();  dnk1.IspisiObrnutiLanac();
dnk2.getTrenutnaDuzina(); dnk2.getSlobodnaMesta();  dnk2.dodaj('A');
           dnk2.IspisiLanac();
           dnk2.getA();
           */
       }
   }
}