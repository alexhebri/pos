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
            Console.WriteLine("===== CITIRE ANGAJATI =====");
            Console.WriteLine("Cati angajati?");
            nA = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < nA; i++)
            {
                Console.WriteLine("----- Angajat " + (i + 1) + " -----");
                Console.Write("ID = ");
                ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nume: ");
                Nume = Console.ReadLine();

                Console.Write("Salariu: ");
                Salariu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                vA[i] = new Angajat(ID, Nume, Salariu);
            }

            Console.WriteLine("============================");
        }

        public void AfisareaTuturorAngajatilor()
        {
            Console.WriteLine();
            Console.WriteLine("===== LISTA DE ANGAJATI =====");

            if (nA == 0)
            {
                Console.WriteLine("Nu exista angajati inregistrati.");
                Console.WriteLine("=============================");
                return;
            }

            for (i = 0; i < nA; i++)
            {
                Console.WriteLine("----- Angajat " + (i + 1) + " -----");
                vA[i].afisare();
            }

            Console.WriteLine("=============================");
        }
    }
}
