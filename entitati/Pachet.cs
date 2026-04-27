using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Pachet : ProdusAbstract
    {
        public List<IPackageable> elem_pachet = new List<IPackageable>();
        public Pachet(int id, string denumire, int codIntern,int pret, string categorie)
            : base(id, denumire, codIntern, pret, categorie)
        {

        }

        public void Adauga(IPackageable el)
        {
            elem_pachet.Add(el);
        }

        public override void Afisare1()
        {
            Console.WriteLine(ID + " " + Denumire + " " + CodIntern + " " + Pret + " " + Categorie + " ");
        }

        public override void Afisare2()
        {
            base.Afisare2();
        }

        public override bool canAddToPackage(Pachet pachet)
        {
            return true;
        }
    }
}
