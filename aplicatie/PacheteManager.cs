using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using entitati;

namespace aplicatie
{
    public class PacheteManager
    {
        public List<Pachet> pachete = new List<Pachet>();
        public int i, nrPack, Id, CodIntern, Pret;
        public string Denumire, Categorie;
        public ProduseManager pM = new ProduseManager();
        public ServiciiManager sM = new ServiciiManager();

        public void CitirePachete()
        {
            Console.WriteLine("============================");
            Console.WriteLine("Cate pachete doriti?");
            nrPack = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < nrPack; i++)
            {
                Console.WriteLine("============================");
                Console.Write("Id pachet: ");
                Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Denumire pachet: ");
                Denumire = Console.ReadLine();
                Console.Write("Cod intern: ");
                CodIntern = Convert.ToInt32(Console.ReadLine());
                Console.Write("Pret: ");
                Pret = Convert.ToInt32(Console.ReadLine());
                Console.Write("Categorie: ");
                Categorie = Console.ReadLine();
                Pachet pk = new Pachet(Id, Denumire, CodIntern, Pret, Categorie);

                foreach (Produs p in pM.elemente)
                {
                    Console.WriteLine("Adaugati produsul " + p.Denumire + " in pachet? (da/nu)");
                    string raspuns = Console.ReadLine();
                    if(raspuns.ToLower() == "da")
                    {
                        if (p.canAddToPackage(pk))
                        {
                            pk.Adauga(p); //adauga un produs din lista numita elemente in pachet
                        }
                        else
                        {
                            Console.WriteLine("Produsul" + p.Denumire + "nu poate fi adaugat in pachet");
                        }
                    }
                }


                foreach (Serviciu s in sM.elemente)
                {
                    Console.WriteLine("Adaugati serviciul " + s.Denumire + " care are pretul" + s.Pret + "in pachet? (da/nu)");
                    string raspuns = Console.ReadLine();
                    if(raspuns.ToLower() == "da")
                    {
                        if (s.canAddToPackage(pk))
                        {
                            pk.Adauga(s); //adauga un serviciu din lista numita elemente in pachet
                        }
                        else
                        {
                            Console.WriteLine("Serviciul " + s.Denumire + "nu poate fi adaugat in pachet");
                        }
                    }

                }

                pachete.Add(pk); //lista de pachete 
            }
        }

        public void AfisarePachete()
        {
            Console.WriteLine();
            Console.WriteLine("===== PACHETE =====");

            if (pachete.Count == 0)
            {
                Console.WriteLine("Nu exista pachete.");
                Console.WriteLine("=============================");
                return;
            }

            int idx = 1;
            foreach (Pachet pk in pachete)
            {
                Console.WriteLine("----- Pachet " + idx + " -----");
                pk.Afisare1();
                idx++;
            }

            Console.WriteLine("=============================");
        }

        public void AfisarePacheteSortate()
        {
            Console.WriteLine();
            Console.WriteLine("===== PACHETE SORTATE =====");
            pachete.Sort();

            if (pachete.Count == 0)
            {
                Console.WriteLine("Nu exista pachete.");
                Console.WriteLine("=============================");
                return;
            }

            int idx = 1;
            foreach (Pachet pk in pachete)
            {
                Console.WriteLine("----- Pachet " + idx + " -----");
                pk.Afisare1();
                idx++;
            }

            Console.WriteLine("=============================");
        }

        //*********INTEROGARI LINQ = un limbaj ca sql *********
        public void interogare1()
        {
            IEnumerable<Pachet> rezultat1 =
                from elem in pachete
                where elem.Categorie == "Promotional"
                orderby elem.Denumire
                select elem;

            Console.WriteLine("============================");
            Console.WriteLine("Pachetele din categoria Promotional extrase: ");
            foreach (Pachet elem in rezultat1)
            {
                elem.Afisare1();
            }
        }

        public void interogare2()
        {
            IEnumerable<Pachet> rezultat2 =
                from elem in pachete
                where elem.Pret <= 500
                orderby elem.Categorie
                select elem;

            Console.WriteLine("============================");
            Console.WriteLine("Pachetele extrase cu pret <= 500: ");
            foreach (Pachet elem in rezultat2)
            {
                elem.Afisare1();
            }
        }

        //pachete grupate
        public void interogare3()
        {
            var interogare_linq =
                from elem in pachete
                orderby elem.Categorie
                group elem by elem.Categorie into gr
                select gr;

            Console.WriteLine("============================");
            foreach (var gr in interogare_linq)
            {
                Console.WriteLine("Categoria " + gr.Key + " :");
                foreach (Pachet elem in gr)
                {
                    elem.Afisare1();
                }
            }
        }
    } 
}
