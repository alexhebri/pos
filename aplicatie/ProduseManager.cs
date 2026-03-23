using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace aplicatie
{
    public class ProduseManager
    {
        public int i, j, nProd, ID, CodIntern;
        public string DenumireProd, Producator;

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

                if (Produs.cautaProdus(vp, nProd, ID) == 1)
                    continue;

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

        // cautare dupa nume (returneaza TOATE)
        public Produs[] Contine(string numeProdus)
        {
            Produs[] rezultate = new Produs[10];
            int k = 0;

            for (int i = 0; i < j; i++)
                if (vp[i].Denumire == numeProdus)
                {
                    rezultate[k] = vp[i];
                    k++;
                }

            return rezultate;
        }
    }
}
