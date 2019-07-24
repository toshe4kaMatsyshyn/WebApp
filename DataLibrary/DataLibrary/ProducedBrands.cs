using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class ProducedBrands
    {
        public DateTime? YearOfProduced { get; set; }
        public string BrandsId { get; set; }
        public int? CountOfProduced { get; set; }

        public virtual Brands Brands { get; set; }
        public virtual DeliveredBrands DeliveredBrands { get; set; }
    }
}
