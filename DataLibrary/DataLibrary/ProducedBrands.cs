using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public class ProducedBrands
    {
        public ProducedBrands()
        {
            DeliveredBrands = new HashSet<DeliveredBrands>();
            TerminalsAndBrands = new HashSet<TerminalsAndBrands>();
        }
        public ProducedBrands(Brands brand, int? CountOfProduced):this(brand,CountOfProduced,DateTime.Today)
        {

        }
        public ProducedBrands(Brands brand, int? CountOfProduced, DateTime? YearOfProduced)
        {
            this.Brand = brand;
            this.Brand.ProducedBrands.Add(this);
            BrandId = brand.Id;

            Id = Settings.GenerateId();
            this.CountOfProduced = CountOfProduced;
            this.YearOfProduced = YearOfProduced;

            DeliveredBrands = new HashSet<DeliveredBrands>();
            TerminalsAndBrands = new HashSet<TerminalsAndBrands>();
        }

        public string Id { get; protected set; }
        public string BrandId { get; set; }
        public DateTime? YearOfProduced { get; set; }
        public int? CountOfProduced { get; set; }

        public virtual Brands Brand { get; set; }
        public virtual ICollection<DeliveredBrands> DeliveredBrands { get; set; }
        public virtual ICollection<TerminalsAndBrands> TerminalsAndBrands { get; set; }
    }
}
