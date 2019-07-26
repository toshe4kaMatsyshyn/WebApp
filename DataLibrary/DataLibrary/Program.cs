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

                //Terminal newTerminal = null;
                //foreach (Terminal terminal in context.Terminal)
                //    if (terminal.Id.StartsWith("OSYIIJTXPC")) newTerminal = terminal;

                //List<Brands> brands = context.GetAllProducedBrandsInTreminal(newTerminal);

                //foreach(Brands brand in brands)
                //    Console.WriteLine(brand.Name);

                // List<ProducedBrands> producedBrands = context.GetAllProducedBrandsInTerminal(newTerminal);
                // foreach (ProducedBrands produced in producedBrands)
                //     context.Entry(produced).Reference("Brand").Load();

                //foreach (ProducedBrands produced in producedBrands)
                //     Console.WriteLine(produced.Brand.Name+"\t"+produced.CountOfProduced);


                List<Brands> brands = context.GetBrandsByYear(1924);
                foreach(Brands brand in brands)
                    Console.WriteLine(brand.Name);

                
            }
            Console.ReadKey();
        }
    }
}
