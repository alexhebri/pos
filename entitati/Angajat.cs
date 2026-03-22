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

        public Angajat(int ID, string Nume, int salariu)
            : base(ID, Nume)
        {
            Salariu = salariu;
        }

        {
            Console.WriteLine(" " + Salariu);
        }

        {
        }

        {
        }
    }
}
