using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace aplicatie
{
    public class AngajatManager
    {
        public int i, nA, nC, ID, Salariu, Varsta;
        public string Nume;
        public Angajat[] vA = new Angajat[10];

        public void CitireAngajati()
        {
            Console.WriteLine("Cati angajati?");
            nA = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < nA; i++)
            {
                Console.Write("ID = ");
                ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nume: ");
                Nume = Console.ReadLine();

                Console.Write("Salariu: ");
                Salariu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                vA[i] = new Angajat(ID, Nume, Salariu);
            }
        }

        public void AfisareaTuturorAngajatilor()
        {
            Console.WriteLine();
            Console.WriteLine("***** LISTA DE ANGAJATI *****");
            for (i = 0; i < nA; i++)
            {
                vA[i].afisare();
            }
        }
    }
}
