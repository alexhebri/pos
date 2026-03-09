using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Angajat : Persoana
    {
        protected int Salariu { get; set; }
        public Angajat(int id, string nume, int salariu) : base(id, nume)
        {

            Salariu = salariu;
        }

        public override void Afisare()
        {
            base.Afisare();
            Console.WriteLine(" " + Salariu);
        }

        public int CalculSalariu(int salariuBaza, int bonusuri)
        {
            return salariuBaza + bonusuri;
        }

        public int CalculSalariu(int salariuBaza, int bonusuri, int retineri)
        {
            return salariuBaza + bonusuri - retineri;
        }
    }
}
