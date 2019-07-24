using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class Brands
    {
        public Brands()
        {
            ProducedBrands = new HashSet<ProducedBrands>();
        }
        public Brands(string Name)
        {
            ProducedBrands = new HashSet<ProducedBrands>();
            this.Name = Name;
            Id = Settings.GenerateId();
        }

        public string Id { get; protected set; }
        public string Name { get; set; }

        public virtual ICollection<ProducedBrands> ProducedBrands { get; set; }
    }
}
