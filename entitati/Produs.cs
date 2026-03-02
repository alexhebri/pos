using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Produs
    {
        public int CodProdus { get; set; }
        public string Denumire { get; set; }
        public string Producator { get; set; }

        public Produs(int codProdus, string denumire, string producator)
        {
            CodProdus = codProdus;
            Producator = producator;
            Denumire = denumire;
        }

        public void Afisare()
        {
            Console.WriteLine(CodProdus + " " + Denumire + " " + Producator);
        }

        public static int CautaProdus(Produs[] v, int n, int codCautat)
        {
            int ok = 0; //pp. produsul nu se afla in lista
            for(int i = 0; i < n; i++)
            {
                if (v[i].CodProdus == codCautat)
                    ok = 1; //am gasit produsul in lista
            }
            return ok;
        }

    }
}
