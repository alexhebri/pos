using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Persoana
    {
        public int ID { get; set; }
        public string Nume { get; set; }

        public Persoana(int id, string nume)
        {
            ID = id;
            Nume = nume;
        }

        public virtual void afisare()
        {
            Console.WriteLine(ID + " " + Nume);
        }
    }
}
