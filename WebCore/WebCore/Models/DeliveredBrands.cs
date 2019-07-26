using System;
using System.Collections.Generic;

namespace WebCore.Models
{
    public partial class DeliveredBrands
    {
        public DeliveredBrands()
        {

        }

        public DeliveredBrands(ProducedBrands produced, int? CountOfDelivered)
        {
            this.ProduceBrands = produced;
            ProduceBrandsId = produced.Id;

            Id = Settings.GenerateId();
            this.CountOfDelivered = CountOfDelivered;
        }

        public string ProduceBrandsId { get; set; }
        public string Id { get; set; }
        public int? CountOfDelivered { get; set; }

        public virtual ProducedBrands ProduceBrands { get; set; }
    }
}
