using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class Brands
    {
        public Brands(string Name)
        {
            this.Name = Name;
            Id = Settings.GenerateRandomId();
        }
        
        public string Id { get; set; }
        public string Name { get; set; }

       // public virtual ProducedBrands ProducedBrands { get; set; }
    }
}
