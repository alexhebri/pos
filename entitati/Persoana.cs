using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Persoana
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public Persoana(int id, string nume)
        {
            Id = id;
            Nume = nume;
        }

        public virtual void Afisare()
        {
            Console.Write(Id + " " + Nume);
        }
    }
}
