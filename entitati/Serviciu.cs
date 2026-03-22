using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Serviciu : ProdusAbstract
    {
        public double Pret { get; set; }
        public int DurataReparatie { get; set; }

        public Serviciu(int id, string denumire, int codIntern, double pret, int durataReparatie)
            : base(id, denumire, codIntern)
        {
            Pret = pret;
            DurataReparatie = durataReparatie;
        }

        public override void Afisare1()
        {
            Console.WriteLine(ID + " " + Denumire + " " + CodIntern + " " + Pret + " " + DurataReparatie);
        }

        public override void Afisare2()
        {
            base.Afisare2();
            Console.WriteLine(Pret + " " + DurataReparatie);
        }

        public static int cautaServiciu(Serviciu[] v, int n, int codCautat)
        {
            int ok = 0;
            for (int i = 0; i < n; i++)
                if (codCautat == v[i].ID)
                    ok = 1;
            return ok;
        }
    }
}
