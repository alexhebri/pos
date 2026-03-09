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

        public Client(int id, string nume, int varsta) : base(id, nume)
        {
            Varsta = varsta;
        }

        public override void Afisare()
        {
            base.Afisare();
            Console.WriteLine(" " + Varsta);
        }
    }
}
