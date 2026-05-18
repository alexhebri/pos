using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

using System.Text;

using System.Threading.Tasks;

using entitati;

namespace aplicatie

{

    public class Program

    {

        static void Main(string[] args)

        {
            


            //*************PRODUSE**************

            ProduseManager pM = new ProduseManager();
            string DenCautat;
            pM.CitireProduse();
            pM.AfisareaTuturorProduselor();

            /*pentru equals, ==, !=

            pM.VerificareProduseEgale1();
            pM.VerificareProduseEgale2();
            pM.VerificareProduseDiferite();
            */

            //pentru contine(ProduseManager -> Program)

            Produs pc = new Produs(123, "", 12, 100, "", "");

            if (pM.Contine(pc) == true)
            {
                Console.WriteLine("Produsul cautat se afla in lista de produse.");
            }

            Console.WriteLine("Ce denumire de produs cautati?");
            DenCautat = Console.ReadLine();

            if (pM.Contine(DenCautat) == true)
            {
                Console.WriteLine("\nProdusul cautat se afla in lista de produse.\n");
            }

            //Console.WriteLine("Ce denumire de produs cautati?");
            //DenCautat = Console.ReadLine();

            Produs[] rezultate = pM.Contine2(DenCautat);

            for (int i = 0; i < rezultate.Length; i++)
            {
                if (rezultate[i] != null)
                {
                    Console.WriteLine(rezultate[i]);
                }
            }

            //pt IComparable

            Console.WriteLine("\nProdusele sortate:\n");
            pM.Sorteaza();

            //Console.WriteLine("Produsele sortate dupa id sunt:");

            pM.AfisareaTuturorProduselor();

            //Pentru fisiere

            pM.CitireaDinFisier();
            pM.AfisareaPentruList();

            //***************serializare produs*****************
            Console.WriteLine("\nSerializare produs:\n");
            Produs p1 = new Produs(2, "Ecran", 2, 500, "Telefoane", "Samsung");
            p1.save2XML("produs_test");

            Console.WriteLine("Produs serializat in produs_test.xml:\n");)
            Console.WriteLine("\nContinut fisierului produs_test.xml:\n");
            Console.WriteLine(File.ReadAllText("produs_test.xml"));

            //*****************deserializare produs*****************
            Produs p2 = p1.loadFromXML("produs_test.xml");
            if (p2 != null)
            {
                Console.WriteLine("\nProdusul deserializat este:\n");
                p2.Afisare1();
            }




            //**********SERVICII**************

            ServiciiManager sM = new ServiciiManager();
            Serviciu ps = new Serviciu(123, "", 12, 100, "", 8);

            sM.CitireServicii();
            sM.AfisareaTuturorServiciilor();

            //pentru equals, ==, !=

            sM.VerificareServiciiEgale2();
            sM.VerificareServiciiDiferite();

            //pentru contine(ProduseManager -> Program)

            Serviciu sc = new Serviciu(123, "", 12, 100, "", 8);

            if (sM.Contine(sc) == true)
            {
                Console.WriteLine("Serviciul cautat se afla in lista de servicii.");
            }

            Console.WriteLine("Ce denumire de serviciu cautati?");
            DenCautat = Console.ReadLine();

            if (sM.Contine(DenCautat) == true)
            {
                Console.WriteLine("\nServiciul cautat se afla in lista de servicii.\n");
            }

            //Console.WriteLine("Ce denumire de serviciu cautati?");
            //DenCautat = Console.ReadLine();

            Serviciu[] rezultat = sM.Contine2(DenCautat);

            for (int i = 0; i < rezultat.Length; i++)
            {
                if (rezultat[i] != null)
                {
                    Console.WriteLine(rezultat[i]);
                }
            }


            //***************serializare serviciu*****************
            Console.WriteLine("\nSerializare serviciu:\n");
            Serviciu s1 = new Serviciu(1, "Reparatie ecran", 1, 350, "Telefoane", 3);
            s1.save2XML("serviciu_test");

            Console.WriteLine("\nContinut fisierului serviciu_test.xml:\n");
            Console.WriteLine(File.ReadAllText("serviciu_test.xml"));

            //*****************deserializare serviciu*****************
            Serviciu s2 = s1.loadFromXML("serviciu_test.xml");
            if(s2 != null)
            {
                Console.WriteLine("\nServiciul deserializat este:\n");
                s2.Afisare1();
            }



            //PENTRU INTEROGARI

            pM.interogare1();
            pM.interogare2();
            pM.interogare3();

            //SERVICII

            sM.CitireServiciiDinFisier();
            sM.AfisareaServiciilorList();

            sM.interogare1();
            sM.interogare2();
            sM.interogare3();

            //PENTRU ListaGen

            ListaGen<ProdusAbstract> listagenerica = new ListaGen<ProdusAbstract>();
            Produs x = new Produs(150, "Frigider", 67, 2300, "Electrocasnice", "Arctic");

            listagenerica.Add(x);

            foreach (ProdusAbstract element in listagenerica)
            {
                Console.WriteLine();
                Console.WriteLine(element + " \n");
            }
            


            //*****************PACHETE********************
            PacheteManager pkM = new PacheteManager();
            pkM.CitirePachete();
            pkM.AfisarePachete();
            pkM.interogare1();
            pkM.interogare2();
            pkM.interogare3();
            pkM.AfisarePacheteSortate();
        }
    }
}
