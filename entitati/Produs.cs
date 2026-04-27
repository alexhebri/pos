using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Produs : ProdusAbstract, IComparable<Produs>
    {
        private int v;
        private string nume;
        private string codIntern;

 
        public string Producator { get; set; }

        public Produs(int id, string denumire, int codIntern,int pret, string categorie, string producator)
            : base(id, denumire, codIntern, pret, categorie)
        {
            Producator = producator;
        }
        

        public override string ToString()
        {
            return ID + " " + Denumire + " " + CodIntern + " " + Pret + " " + Categorie + " " + Producator + " ";
        }

        public override void Afisare1()
        {
            Console.WriteLine(ID + " " + Denumire + " " + CodIntern + " " + Pret + " " + Categorie  + " " + Producator);
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

        //polimorfism prin suprascrierea operatiilor/metodelor
        //Operatorul==este un operator static redefinit în clasă.
        //Implicit, pentru obiecte, compară adresele din memorie (ca și Equals), nu valorile câmpurilor.
        //Noi îl suprascriem pentru a putea scrie p1 == p2 în loc dep1.Equals(p2), obținând același rezultat, si anume compararea valorilor atributelor.
        //Important:Când redefiniți ==, trebuie redefinit și !=, altfel compilatorul dă eroare.

        public override bool Equals(object obj)
        {
            bool ok = false;

            // verificam daca obiectul NU este null si este de tip Produs
            if (obj is Produs p)
            {
                // comparam campurile ID si CodIntern
                if (ID == p.ID && CodIntern == p.CodIntern)
                    ok = true;
            }
            return ok;
        }

        public static bool operator ==(Produs p1, Produs p2)
        {
            bool ok = false;

            if (ReferenceEquals(p1, p2))
                ok = true;
            else if (p1 != null && p2 != null)
            {
                if (p1.ID == p2.ID && p1.CodIntern == p2.CodIntern)
                    ok = true;
            }

            return ok;
        }

        public static bool operator !=(Produs p1, Produs p2)
        {
            bool ok = false; // presupunem ca NU sunt diferite

            if (!(p1 == p2)) // folosim operatorul == inversat
                ok = true;

            return ok;
        }

        public int CompareTo(Produs p)
        {
            if(p == null)
                return 1; // consideram ca orice produs este mai mare decat null

            return ID.CompareTo(p.ID); // comparam ID-urile pentru a determina ordinea
        }

        public override bool canAddToPackage(Pachet pachet)
        { return true; }
    }
}
