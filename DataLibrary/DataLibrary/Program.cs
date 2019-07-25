using System;

namespace DataLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            using (WebAppDatabaseContext context = new WebAppDatabaseContext())
            {
                foreach (Terminal terminal in context.Terminal)
                    if (terminal.Id.StartsWith("MVHNAXHYTR")) terminal.ProducedBrands = 1;
                context.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
