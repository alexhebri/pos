using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public abstract class ProdusAbstract
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public int CodIntern { get; set; }
        public int Pret { get; set; }
        public string Categorie { get; set; }

        public ProdusAbstract(int id, string denumire, int codIntern,int pret, string categorie )
        {
            ID = id;
            Denumire = denumire;
            CodIntern = codIntern;
            Pret = pret;
            Categorie = categorie;
        }

        //Metoda de afisare cu abstract
        public abstract void Afisare1();

        //Metoda de afisare cu virtual
        public virtual void Afisare2()
        {
            Console.Write(ID + " " + Denumire + " " + CodIntern + " " + Pret + " " + Categorie + " ");
        }
    }
}
