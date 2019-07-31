using System;
using System.Collections.Generic;
using System.Text;

using MobileApp.Models;
namespace MobileApp.Services
{
    class Settings
    {
        static List<Brands> Brands;
        static List<Terminal> Terminals;
        static List<ProducedBrands> ProducedBrands;
        public static string GenerateId()
        {
            Random rnd = new Random();
            string Id = "";
            for (int i = 0; i < 10; i++)
                Id += (char)rnd.Next(65, 90);
            return Id;
        }

        public static List<Brands> GetBrands()
        {
            List<Brands> brands = new List<Brands>
            {
                new Brands("Ferari"),
                new Brands("Lada"),
                new Brands("Mercedes"),
                new Brands("Bmw"),
                new Brands("KIA")
            };
            return Brands=brands;
        }
        public static List<Terminal> GetTerminals()
        {
            List<Terminal> terminals = new List<Terminal>()
            {
                new Terminal("Terminal-A"),
                new Terminal("Terminal-B"),
                new Terminal("Terminal-C"),
                new Terminal("Terminal-D"),
                new Terminal("Terminal-E")
            };
            return Terminals=terminals;
        }
        public static List<ProducedBrands> GetProducedBrands()
        {
           
            List<ProducedBrands> producedBrands = new List<ProducedBrands>();
           for(int i=0; i<10; i++)
                producedBrands.Add(new ProducedBrands(GenerateId()));
            return ProducedBrands = producedBrands;
        }
    }
}
