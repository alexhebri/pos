using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j, nProd, nServ, CodProdus, CodServiciu, DurataReparatie;
            string DenumireP, DenumireS, Producator;
            double Pret;

            Console.Write("Cate produse?");
            nProd = Convert.ToInt32(Console.ReadLine());

            Produs[] vP = new Produs[nProd];
            j = 0;
            for (i = 0; i < nProd; i++)
            {
                Console.Write("Cod produs:");
                CodProdus = Convert.ToInt32(Console.ReadLine());

                if (Produs.CautaProdus(vP, nProd, CodProdus) == 1)
                    continue;

                Console.Write("Denumire produs:");
                DenumireP = Console.ReadLine();

                Console.Write("Producator produs:");
                Producator = Console.ReadLine();

                vP[j] = new Produs(CodProdus, DenumireP, Producator);
                j++; //cate produse cu cod diferit au fost adaugate

            }
            Console.WriteLine("****Produsele sunt:****");
            for (i = 0; i < j; i++)
            {
                vP[i].Afisare();
            }


            Console.Write("Cate servicii?");
            nServ = Convert.ToInt32(Console.ReadLine());

            Serviciu[] vS = new Serviciu[nServ];
            j = 0;
            for (i = 0; i < nServ; i++)
            {
                Console.Write("Cod serviciu:");
                CodServiciu = Convert.ToInt32(Console.ReadLine());

                if (Serviciu.CautaServiciu(vS, nServ, CodServiciu) == 1)
                    continue;

                Console.Write("Denumire serviciu:");
                DenumireS = Console.ReadLine();

                Console.Write("Pretul :");
                Pret = Convert.ToDouble(Console.ReadLine());

                Console.Write("Durata reparatie:");
                DurataReparatie = Convert.ToInt32(Console.ReadLine());

                vS[j] = new Serviciu(CodServiciu, DenumireS, Pret, DurataReparatie);
                j++; //cate produse cu cod diferit au fost adaugate

            }
            Console.WriteLine("****Serviciile sunt:****");
            for (i = 0; i < j; i++)
            {
                vS[i].Afisare();
            }
        }
    }
}
