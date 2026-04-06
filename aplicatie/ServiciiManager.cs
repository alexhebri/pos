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
        public Serviciu ps = new Serviciu(123, "", 12, 500, 8);

        public Serviciu[] vs = new Serviciu[10];

        public void CitireServicii()
        {
            Console.Write("Cate servicii?");
            nSer = Convert.ToInt32(Console.ReadLine());
            j = 0;
            for (i = 0; i < nSer; i++)
            {
                /*Varianta equals
                   Servicii sc = new Servicii(ID, "", 0, "");
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
                Serviciu sc = new Serviciu(ID, "", 0, 0, 0);
                int ok = 0;
                for (int k = 0; k < j; k++)
                {
                    if (sc[k] == sc)
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

        //utilizam functiile de suprascriere
        public void VerificareServiciiEgale1()
        {
            for (int k = 0; k < j; k++)
            {
                if (vs[k].Equals(ps)) //metoda equals
                    Console.WriteLine("Serviciu egal");
            }
        }

        public void VerificareServiciiEgale2()
        {
            for (int k = 0; k < j; k++)
            {
                if (vs[k] == ps) //apeland operatorul == 
                    Console.WriteLine("Serviciu egal");
            }
        }

        public void VerificareServiciiDiferite()
        {
            for (int k = 0; k < j; k++)
            {
                if (vs[k] != ps)
                    Console.WriteLine("Servicii diferite");
            }
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

        // cautare dupa obiect
        public bool Contine(Serviciu s)
        {
            bool ok = false;
            for (int i = 0; i < j; i++)
                if (vs[i] == s)   // folosim operatorul ==
                    ok = true;

            return ok;
        }

        // cautare dupa nume (returneaza TOATE)
        public Serviciu[] Contine2(string numeProdus)
        {

            int k = 0;

            for (int i = 0; i < j; i++)
                if (vs[i].Denumire == numeProdus)
                {
                    k++;
                }

            Serviciu[] rezultate = new Serviciu[k];
            k = 0;
            for (int i = 0; i < j; i++)
                if (vs[i].Denumire == numeProdus)
                {
                    rezultate[k] = vs[i];
                    k++;
                }
            return rezultate;
        }
    }
}
