using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using entitati;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace aplicatie
{
    public class ProduseManager
    {
        public int i, j, nProd, ID, CodIntern, Pret;
        public string DenumireProd, Producator, Categorie;
        //public Produs pc = new Produs(123, "", 0, 0, "", "");

        public Produs[] vp = new Produs[10];

        public void CitireProduse()
        {
            Console.Write("Cate produse? ");

            nProd = Convert.ToInt32(Console.ReadLine());
            j = 0;
            for (i = 0; i < nProd; i++)
            {
                Console.WriteLine("============================");
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

                Console.Write("Pretul produsului: ");
                Pret = Convert.ToInt32(Console.ReadLine());

                Console.Write("Categoria produsului: ");
                Categorie = Console.ReadLine();

                Console.Write("Producator produs: ");
                Producator = Console.ReadLine();

                vp[j] = new Produs(ID, DenumireProd, CodIntern,Pret, Categorie, Producator);
                j++; //cate produse cu cod diferit au fost adaugate
            }
        }


        public void AfisareaTuturorProduselor()
        {
            Console.WriteLine();
            Console.WriteLine("===== PRODUSE =====");

            if (j == 0)
            {
                Console.WriteLine("Nu exista produse inregistrate.");
                Console.WriteLine("=============================");
                return;
            }

            for (i = 0; i < j; i++)
            {
                Console.WriteLine("----- Produs " + (i + 1) + " -----");
                vp[i].Afisare2();
            }

            Console.WriteLine("=============================");
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
        public List<ProdusAbstract> elemente = new List<ProdusAbstract>(); //elemente in loc de vp
        public void CitireaDinFisier()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Produse.xml");
            //pentru a nu se scrie calea completa, fac click dreapta pe fisierul XML din solutie, apoi Properties -> Copy to Output Directory -> Copy always
            XmlNodeList lista = doc.SelectNodes("/Produse/Produs");
            //Produse si Produs sunt numele nodurilor din fisierul XML
            foreach (XmlNode node in lista)
            {
                ID = Convert.ToInt32(node["id"].InnerText);
                DenumireProd = node["denumire"].InnerText;
                CodIntern = Convert.ToInt32(node["codIntern"].InnerText);
                Pret = Convert.ToInt32(node["pret"].InnerText);
                Categorie = node["categorie"].InnerText;
                Producator = node["producator"].InnerText;
                elemente.Add(new Produs(ID, DenumireProd, CodIntern,Pret, Categorie, Producator));
            }
        }

        public void AfisareaPentruList()
        {
            //Console.WriteLine("*****Produsele citite din fisier sunt:*****");
            foreach (ProdusAbstract p in elemente) //pt fiecare produs p din lista elemente
            {
                p.Afisare2();
            }
        }

        //*********INTEROGARI LINQ = un limbaj ca sql *********
        //Interogare cu produsele de la un producator
        public void interogare1()
        {
            IEnumerable<ProdusAbstract> rezultat1 =
                from elem in elemente
                where elem.Categorie == "IT"
                orderby elem.Denumire
                select elem;

            Console.WriteLine("============================");
            Console.WriteLine("Produsele din categoria IT extrase: ");
            foreach (ProdusAbstract elem in rezultat1)
            {
                Console.WriteLine(elem.ToString());
            }
        }

        public void interogare2()
        {
            IEnumerable<ProdusAbstract> rezultat2 =
                from elem in elemente
                where elem.Categorie== "IT" && Pret <= 2000
                orderby elem.Denumire
                select elem;
            Console.WriteLine("============================");
            Console.WriteLine("Produsele din categoria IT extrase cu pret <= 2000: ");
            foreach (ProdusAbstract elem in rezultat2)
            {
                Console.WriteLine(elem.ToString());
            }
        }

        public void interogare3()
        {
            var interogare_linq =
            from elem in elemente
            orderby elem.Denumire
            group elem by elem.Categorie into gr
            select gr;

            Console.WriteLine("============================");
            foreach (var gr in interogare_linq)
            {
                Console.WriteLine("Categoria " + gr.Key + " :");
                foreach (ProdusAbstract elem in gr)
                {
                    Console.WriteLine(elem.ToString());
                }
            }
        }

        public Produs loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Produs));
            FileStream fs = new FileStream(fileName + ".xml",
            FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            //deserializare cu crearea de obiect => constructor fara param
            Produs produs = (Produs)xs.Deserialize(reader);
            fs.Close();
            return produs;
        }

        public void save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Produs));
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, this);
            sw.Close();
        }
    }
}
