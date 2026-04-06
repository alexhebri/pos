using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using entitati;

namespace aplicatie
{
    public class ProduseManager
    {
        public int i, j, nProd, ID, CodIntern;
        public string DenumireProd, Producator;
        public Produs pc = new Produs(123, "", 12, "");

        public Produs[] vp = new Produs[10];

        public void CitireProduse()
        {
            Console.Write("Cate produse?");
            nProd = Convert.ToInt32(Console.ReadLine());
            j = 0;
            for (i = 0; i < nProd; i++)
            {
                Console.Write("Cod produs: ");
                ID = Convert.ToInt32(Console.ReadLine());

                /*Varianta equals
                Produs pc = new Produs(ID, "", 0, "");
                int ok = 0;
                for (int k = 0; k < j; k++)
                {
                    if (vp[k].Equals(pc))
                    {
                        ok = 1;
                    }
                    if(ok == 1)
                    {
                        Console.WriteLine("Acest id exista deja");
                        i--;
                        continue;
                    }
                }
                */


                /*Varianta cu ==
                Produs pc = new Produs(ID, "", 0, "");
                int ok = 0;
                for (int k = 0; k < j; k++)
                {
                    if (vp[k] == pc)
                    {
                        ok = 1;
                    }
                    if(ok == 1)
                    {
                        Console.WriteLine("Acest id exista deja");
                        i--;
                        continue;
                    }
                }
                */

                //Varianta cu functia cautaProdus
                if (Produs.cautaProdus(vp, j, ID) == 1)
                {
                    Console.WriteLine("Acest id exista deja");
                    i--;
                    continue;
                }

                /*if (Produs.cautaProdus(vp, nProd, ID) == 1)
                    continue;

                */

                Console.Write("Denumire produs: ");
                DenumireProd = Console.ReadLine();

                Console.Write("Codul intern al produsului: ");
                CodIntern = Convert.ToInt32(Console.ReadLine());

                Console.Write("Producator produs: ");
                Producator = Console.ReadLine();

                vp[j] = new Produs(ID, DenumireProd, CodIntern, Producator);
                j++; //cate produse cu cod diferit au fost adaugate
            }
        }


        public void AfisareaTuturorProduselor()
        {
            Console.WriteLine("*****Produsele sunt:*****");
            for (i = 0; i <= j; i++)
                vp[i].Afisare2();
        }


        // cautare dupa obiect
        public bool Contine(Produs p)
        {
            bool ok = false;
            for (int i = 0; i < j; i++)
                if (vp[i] == p)   // folosim operatorul ==
                    ok = true;

            return ok;
        }


        // cautare dupa nume
        public bool Contine(string serviciuCautat)
        {
            bool ok = false;
            for (int i = 0; i < j; i++)
                if (vp[i].Denumire == serviciuCautat)
                    ok = true;

            return ok;
        }

        // cautare dupa nume (returneaza TOATE)
        public Produs[] Contine2(string numeProdus)
        {

            int k = 0;

            for (int i = 0; i < j; i++)
                if (vp[i].Denumire == numeProdus)
                {
                    k++;
                }

            Produs[] rezultate = new Produs[k];
            k = 0;
            for (int i = 0; i < j; i++)
                if (vp[i].Denumire == numeProdus)
                {
                    rezultate[k] = vp[i];
                    k++;
                }
            return rezultate;
        }

        public void Sorteaza()
        {
            Array.Sort(vp, 0, j); //sorteaza doar elementele din vector care au fost adaugate (de la 0 la j)
        }

        //*****FISIERE*****
        public List<Produs> elemente = new List<Produs>(); //elemente in loc de vp
        public void CitireaDinFisier()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Produse.xml");
            //pentru a nu se scrie calea completa, fac click dreapta pe fisierul XML din solutie, apoi Properties -> Copy to Output Directory -> Copy always
            XmlNodeList lista = doc.SelectNodes("/Produse/Produs");
            //Produse si Produs sunt numele nodurilor din fisierul XML
            foreach (XmlNode node in lista)
            {
                ID = Convert.ToInt32(node["ID"].InnerText);
                DenumireProd = node["Denumire"].InnerText;
                CodIntern = Convert.ToInt32(node["CodIntern"].InnerText);
                Producator = node["Producator"].InnerText;
                elemente.Add(new Produs(ID, DenumireProd, CodIntern, Producator));
            }
        }

        public void AfisareaPentruList()
        {
            Console.WriteLine("*****Produsele citite din fisier sunt:*****");
            foreach (Produs p in elemente) //pt fiecare produs p din lista elemente
            {
                p.Afisare2();
            }
        }

        //*********INTEROGARI LINQ = un limbaj ca sql *********
        //Interogare cu produsele de la un producator
        public void interogare1(string producatorCautat)
        {
            IEnumerable<Produs> rezultat1 = 
                from elem in elemente
                where elem.Producator == producatorCautat
                orderby elem.Denumire
                select elem;

                Console.WriteLine("Produsele extrase: ");
            foreach (Produs elem in rezultat1)
            {
                Console.WriteLine(elem.ToString());
            }
        }

        public void interogare2(string producatorCautat, int codCautat)
        {
            IEnumerable<Produs> rezultat2 =
                from elem in elemente
                where elem.Producator == producatorCautat && codCautat < 120
                orderby elem.Denumire
                select elem;
            Console.WriteLine("Produsele extrase cu id <120: ");
            foreach (Produs elem in rezultat2)
            {
                Console.WriteLine(elem.ToString());
            }
        }

        public void interogare3()
        {
            var rezultat3 =
                from elem in elemente
                orderby elem.Denumire
                group elem by elem.Denumire into gr
                select gr;
            Console.WriteLine("Produsele grupate dupa denumire: ");
            foreach (var gr  in rezultat3)
            {
                Console.WriteLine(gr.ToString());
            }
        }
    }
}
