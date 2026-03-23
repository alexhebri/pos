using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Client : Persoana
    {
        public int Varsta { get; set; }

        public Client(int ID, string Nume, int varsta)
            : base(ID, Nume)
        {
            Varsta = varsta;
        }

        public override void afisare()
        {
            base.afisare();
            Console.WriteLine(" " + Varsta);
        }
    }
}
