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

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProducedBrands> ProducedBrands { get; set; }
    }
}
