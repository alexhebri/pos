using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("Cate pachete doriti?");
            nrPack = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < nrPack; i++)
            {
                Console.WriteLine("Id pachet: ");
                Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Denumire pachet: ");
                Denumire = Console.ReadLine();
                Console.WriteLine("Cod intern: ");
                CodIntern = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pret: ");
                Pret = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Categorie: ");
                Categorie = Console.ReadLine();
                Pachet pk = new Pachet(Id, Denumire, CodIntern, Pret, Categorie);

                foreach (Produs p in pM.elemente)
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


                foreach (Serviciu s in sM.elemente)
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

                pachete.Add(pk); //lista de pachete 
            }
        }

        public void AfisarePachete()
        {
            Console.WriteLine("**********Pachetele sunt***********");
            foreach (Pachet pk in pachete)
            {
                pk.Afisare1();
            }
        }


    }
}
