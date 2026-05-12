using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace aplicatie
{
    public class ClientManager
    {
        public int i, nC, ID, Varsta;
        public string Nume;

        public Client[] vC = new Client[10];

        public void CitireClient()
        {
            Console.WriteLine("============================");
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
        }

        public void AfisareaTuturorAngajatilor()
        {
            Console.WriteLine();
            Console.WriteLine("===== CLIENTI =====");

            if (nC == 0)
            {
                Console.WriteLine("Nu exista clienti inregistrati.");
                Console.WriteLine("=============================");
                return;
            }

            for (i = 0; i < nC; i++)
            {
                Console.WriteLine("----- Client " + (i + 1) + " -----");
                vC[i].afisare();
            }

            Console.WriteLine("=============================");
        }
    }
}
