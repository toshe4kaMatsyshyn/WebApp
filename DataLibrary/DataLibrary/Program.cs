using System;

namespace DataLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebAppDatabaseContext context = new WebAppDatabaseContext())
            {
                Brands lada = new Brands("Ferari");
                context.SaveChanges();
                //Console.WriteLine( context.AddNewBrand(lada));
                //Console.WriteLine(context.AddNewBrand(lada));
                foreach(Brands brands in context.Brands)
                    Console.WriteLine(brands.Name);
            }
            Console.ReadKey();
        }
    }
}
