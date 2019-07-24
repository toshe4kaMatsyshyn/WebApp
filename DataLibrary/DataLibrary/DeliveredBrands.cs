using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class DeliveredBrands
    {
        public string ProducedBrandsId { get; set; }
        public int? CountOfDelivered { get; set; }

        public virtual ProducedBrands ProducedBrands { get; set; }
    }
}
