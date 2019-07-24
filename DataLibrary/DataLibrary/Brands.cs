using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class Brands
    {
        public Brands(string Name)
        {
            ProducedBrands = new HashSet<ProducedBrands>();
            this.Name = Name;
            Id = Settings.GenerateId();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProducedBrands> ProducedBrands { get; set; }
    }
}
