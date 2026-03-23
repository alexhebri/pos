using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace aplicatie
{
    public class ServiciiManager
    {
        public int i, j, nSer, ID, CodIntern, DurataReparatie;
        public string DenumireSer;
        public double Pret;

        public Serviciu[] vs = new Serviciu[10];

        public void CitireServicii()
        {
            Console.Write("Cate servicii?");
            nSer = Convert.ToInt32(Console.ReadLine());
            j = 0;
            for (i = 0; i < nSer; i++)
            {
                Console.Write("Cod serviciu: ");
                ID = Convert.ToInt32(Console.ReadLine());

                if (Serviciu.cautaServiciu(vs, nSer, ID) == 1)
                    continue;

                Console.Write("Denumire servicu: ");
                DenumireSer = Console.ReadLine();

                Console.Write("Codul intern al serviciului: ");
                CodIntern = Convert.ToInt32(Console.ReadLine());

                Console.Write("Pret serviciu: ");
                Pret = Convert.ToDouble(Console.ReadLine());

                Console.Write("Durata serviciu:");
                DurataReparatie = Convert.ToInt32(Console.ReadLine());

                vs[j] = new Serviciu(ID, DenumireSer, CodIntern, Pret, DurataReparatie);
                j++; //cate produse cu cod diferit au fost adaugate
            }
        }

        public void AfisareaTuturorServiciilor()
        {
            Console.WriteLine("*****Serviciile sunt:*****");

            for (i = 0; i <= j; i++)
                vs[i].Afisare2();
        }

        // cautare dupa obiect
        public bool Contine(Serviciu s)
        {
            bool ok = false;
            for (int i = 0; i < j; i++)
                if (vs[i] == s)   // folosim operatorul ==
                    ok = true;

            return ok;
        }

        // cautare dupa nume
        public bool Contine(string serviciuCautat)
        {
            bool ok = false;
            for (int i = 0; i < j; i++)
                if (vs[i].Denumire == serviciuCautat)
                    ok = true;

            return ok;
        }
    }
}
