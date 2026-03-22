using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Produs : ProdusAbstract
    {
        public string Producator { get; set; }

        public Produs(int id, string denumire, int codIntern, string producator)
            : base(id, denumire, codIntern)
        {
            Producator = producator;
        }

        public override void Afisare1()
        {
            Console.WriteLine(ID + " " + Denumire + " " + CodIntern + " " + Producator);
        }

        public override void Afisare2()
        {
            base.Afisare2();
            Console.WriteLine(Producator);
        }

        public static int cautaProdus(Produs[] v, int n, int codCautat)
        {
            int ok = 0; //pp ca produsul nu se afla in lista
            for (int i = 0; i < n; i++)
                if (codCautat == v[i].ID)
                    ok = 1; //am gasit produsul in lista
            return ok;
        }
    }
}
