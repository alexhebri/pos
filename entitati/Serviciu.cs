using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Serviciu
    {
        public int CodServiciu { get; set; }
        public string Denumire { get; set; }
        public double Pret { get; set; }
        public int DurataReparatie { get; set; }

        public Serviciu(int codServiciu, string denumire, double pret, int durataReparatie)
        {
            CodServiciu = codServiciu;
            Denumire = denumire;
            Pret = pret;
            DurataReparatie = durataReparatie;
        }

        public void Afisare()
        {
            Console.WriteLine(CodServiciu + " " + Denumire + " " + Pret + " " + DurataReparatie);
        }

        public static int CautaServiciu(Serviciu[] v, int n, int codCautat)
        {
            int ok = 0; //pp. serviciu nu se afla in lista
            for (int i = 0; i < n; i++)
            {
                if (v[i].CodServiciu == codCautat)
                    ok = 1; //am gasit serviciul in lista
            }
            return ok;
        }
    }
}
