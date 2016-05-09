using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekDemo.Model;

namespace BibliotekDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till biblioteket");
            using (BibliotekContext context = new BibliotekContext())
            {
                int bookCount = context.Böcker.Count();
                Console.WriteLine("Det finns {0} böcker i databasen", bookCount);

                foreach (Bok b in context.Böcker)
                {
                    Console.WriteLine("Boken med titel "
                        + b.Titel + " har "
                        + b.Genres.Count() + " genrer:");
                    foreach (Genre g in b.Genres)
                    {
                        Console.WriteLine("\t" + g.Namn);
                    }
                }
                Console.WriteLine("Genrer:");
                foreach (Genre g in context.Genrer)
                {
                    Console.WriteLine("\t{0} har {1} böcker",
                        g.Namn, g.Böcker.Count());
                    foreach (Bok b2 in g.Böcker)
                        Console.WriteLine("\t\t" + b2.Titel);
                }

                Console.WriteLine("Skriv in en bok att lägga till!");
                Console.Write("Titel: ");
                string inputBok = Console.ReadLine();
                Console.Write("Genre: ");
                string inputGenre = Console.ReadLine();

                var listaGenre = context.Genrer.Where(x => x.Namn == inputGenre);
                var listaBok = context.Böcker.Where(x => x.Titel == inputBok);
                Genre nyGenre;
                Bok nyBok;
                if (listaGenre.Count() == 0)
                    nyGenre = new Genre()
                    {
                        Namn = inputGenre,
                        Böcker = new List<Bok>()
                    };
                else
                    nyGenre = listaGenre.First();

                if (listaBok.Count() == 0)
                    nyBok = new Bok()
                    {
                        Titel = inputBok,
                        Genres = new List<Genre>()
                    }; // Ctrl K+D
                else
                    nyBok = listaBok.First();

                nyGenre.Böcker.Add(nyBok);
                nyBok.Genres.Add(nyGenre);

                if (listaBok.Count() == 0)
                    context.Böcker.Add(nyBok);
                if (listaGenre.Count() == 0)
                    context.Genrer.Add(nyGenre);
                context.SaveChanges();
            }
            Console.ReadLine();
        }


    }
}
