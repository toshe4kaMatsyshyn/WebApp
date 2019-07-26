using System;
using System.Collections.Generic;
namespace DataLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            using (WebAppDatabaseContext context = new WebAppDatabaseContext())
            {
                //ProducedBrands newProduced = null;
                //foreach (ProducedBrands produced in context.ProducedBrands)
                //    if (produced.Id.StartsWith("MPFRVCDBLH          ")) newProduced = produced;

                Terminal newTerminal = null;
                foreach (Terminal terminal in context.Terminal)
                    if (terminal.Id.StartsWith("OSYIIJTXPC")) newTerminal = terminal;

                List<Brands> brands = context.GetAllBrandsInTreminal(newTerminal);

                foreach(Brands brand in brands)
                    Console.WriteLine(brand.Name);
            }
            Console.ReadKey();
        }
    }
}
