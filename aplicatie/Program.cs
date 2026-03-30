using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace aplicatie
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProduseManager pM = new ProduseManager();
            string DenCautat;
            
            pM.CitireProduse();
            pM.AfisareaTuturorProduselor();

            //pentru equals, ==, !=
            pM.VerificareProduseEgale1();
            pM.VerificareProduseEgale2();
            pM.VerificareProduseDiferite();

            //pentru contine(ProduseManager -> Program)
            Produs pc = new Produs(123, "", 12, "");
            if (pM.Contine(pc) == true)
            {
                Console.WriteLine("Produsul cautat se afla in lista de produse.");
            }
               
            Console.WriteLine("Ce denumire de produs cautati?");
            DenCautat = Console.ReadLine();
            if(pM.Contine(DenCautat) == true)
            {
                Console.WriteLine("Produsul cautat se afla in lista de produse.");
            }

            Console.WriteLine("Ce denumire de produs cautati?");
            DenCautat = Console.ReadLine();
            Produs[] rezultate = pM.Contine2(DenCautat);
            for(int i = 0; i < rezultate.Length; i++)
            {
                if(rezultate[i] != null)
                {
                    Console.WriteLine(rezultate[i]);
                    
                }
            }

            //pt IComparable
            pM.Sorteaza();
            Console.WriteLine("Produsele sortate dupa id sunt:");
            pM.AfisareaTuturorProduselor();

            //SERVICII
            ServiciiManager sM = new ServiciiManager();
            Serviciu ps = new Serviciu(123, "", 12, 500, 8);
            sM.CitireServicii();
            sM.AfisareaTuturorServiciilor();

            //pentru equals, ==, !=
            sM.VerificareServiciiEgale2();
            sM.VerificareServiciiDiferite();
            sM.VerificareServiciiDiferite();

            //pentru contine(ProduseManager -> Program)
            Serviciu sc = new Serviciu(123, "", 12, 500, 8);
            if (sM.Contine(sc) == true)
            {
                Console.WriteLine("Produsul cautat se afla in lista de servicii.");
            }

            Console.WriteLine("Ce denumire de serviciu cautati?");
            DenCautat = Console.ReadLine();
            if (sM.Contine(DenCautat) == true)
            {
                Console.WriteLine("Produsul cautat se afla in lista de servicii.");
            }

            Console.WriteLine("Ce denumire de serviciu cautati?");
            DenCautat = Console.ReadLine();
            Serviciu[] rezultat = sM.Contine2(DenCautat);
            for (int i = 0; i < rezultat.Length; i++)
            {
                if (rezultat[i] != null)
                {
                    Console.WriteLine(rezultat[i]);

                }
            }

        }
    }
}