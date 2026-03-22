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

        public Angajat(int ID, string Nume, int salariu)
            : base(ID, Nume)
        {
            Salariu = salariu;
        }

        public override void afisare()
        {
            base.afisare();
            Console.WriteLine(" " + Salariu);
        }

        public int calculSalariu(int salariu_baza, int bonusuri)
        {
            return salariu_baza + bonusuri;
        }

        public int calculSalariu(int salariu_baza, int bonusuri, int retineri)
        {
            return salariu_baza + bonusuri - retineri;
        }
    }
}
