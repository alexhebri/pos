using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace aplicatie
{
    public class Program
    {
        static void Main(string[] args)
        {
            int i, nA, nC, ID, Salariu, Varsta;
            string Nume;
            Angajat[] vA = new Angajat[10];
            Client[] vC = new Client[10];


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

            Console.WriteLine();
            Console.WriteLine("***** LISTA DE ANGAJATI *****");
            for (i = 0; i < nA; i++)
            {
                vA[i].afisare();
            }

            Console.WriteLine();
            Console.WriteLine("Cati clienti?");
            nC = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < nC; i++)
            {
                Console.Write("ID = ");
                ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nume: ");
                Nume = Console.ReadLine();

                Console.Write("Varsta: ");
                Varsta = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                vC[i] = new Client(ID, Nume, Varsta);
            }

            Console.WriteLine();
            Console.WriteLine("***** LISTA DE CLIENTI *****");
            for (i = 0; i < nC; i++)
            {
                vC[i].afisare();
            }
        }
    }
}
