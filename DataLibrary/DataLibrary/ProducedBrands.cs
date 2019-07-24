using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class ProducedBrands
    {
        public ProducedBrands()
        {
            DeliveredBrands = new HashSet<DeliveredBrands>();
            TerminalsAndBrands = new HashSet<TerminalsAndBrands>();
        }

        public string Id { get; set; }
        public string BrandId { get; set; }
        public DateTime? YearOfProduced { get; set; }
        public int? CountOfProduced { get; set; }

        public virtual Brands Brand { get; set; }
        public virtual ICollection<DeliveredBrands> DeliveredBrands { get; set; }
        public virtual ICollection<TerminalsAndBrands> TerminalsAndBrands { get; set; }
    }
}
