using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    [XmlRoot("ServiciuParticularizat")]
    public class Serviciu : ProdusAbstract
    {
        //public int DurataReparatie { get; set; }
        [XmlElement("ID")]
        public int Id;
        [XmlElement("Numele")]
        public String Denumire;
        [XmlElement("CodulIntern")]
        public int CodIntern;
        [XmlElement("Pret")]
        public int Pret;
        [XmlElement("Categorie")]
        public string Categorie;
        [XmlElement("DurataReparatie")]
        public int DurataReparatie;

        public Serviciu(int id, string denumire, int codIntern, int pret, string categorie, int durataReparatie)
            : base(id, denumire, codIntern, pret, categorie)
        {
            DurataReparatie = durataReparatie;
        }



        public Serviciu()
        { }

        public override void Afisare1()
        {
            Console.WriteLine(ID + " " + Denumire + " " + CodIntern + " " + Pret + " " + Categorie + " " + DurataReparatie);
        }

        public override void Afisare2()
        {
            base.Afisare2();
            Console.WriteLine(DurataReparatie);
        }

        public override string ToString()
        {
            return ID + " " + Denumire + " " + CodIntern + " " + Pret + " " + Categorie + " " + DurataReparatie;
        }

        public static int cautaServiciu(Serviciu[] v, int n, int codCautat)
        {
            int ok = 0;
            for (int i = 0; i < n; i++)
                if (codCautat == v[i].ID)
                    ok = 1;
            return ok;
        }

        public override bool Equals(object obj)
        {
            bool ok = false;

            // verificam daca obiectul NU este null si este de tip Serviciu
            if (obj is Serviciu s)
            {
                // comparam campurile ID si CodIntern
                if (ID == s.ID && CodIntern == s.CodIntern)
                    ok = true;
            }
            return ok;
        }

        //polimorfism prin suprascrierea operatiilor/metodelor
        //Operatorul==este un operator static redefinit în clasă.
        //Implicit, pentru obiecte, compară adresele din memorie (ca și Equals), nu valorile câmpurilor.
        //Noi îl suprascriem pentru a putea scrie p1 == p2 în loc dep1.Equals(p2), obținând același rezultat, si anume compararea valorilor atributelor.
        //Important:Când redefiniți ==, trebuie redefinit și !=, altfel compilatorul dă eroare.

        public static bool operator ==(Serviciu s1, Serviciu s2)
        {
            bool ok = false; 

            if (ReferenceEquals(s1, s2))
                ok = true;
            else if (s1 != null && s2 != null)
            {
                if (s1.ID == s2.ID && s1.CodIntern == s2.CodIntern)
                    ok = true;
            }

            return ok;
        }

        public static bool operator !=(Serviciu s1, Serviciu s2)
        {
            bool ok = false; // presupunem ca NU sunt diferite

            if (!(s1 == s2)) // folosim operatorul == inversat
                ok = true;

            return ok;
        }

        public int CompareTo(Serviciu s)
        {
            if (s == null)
                return 1;
            return ID.CompareTo(s.ID);
        }




    }
}
