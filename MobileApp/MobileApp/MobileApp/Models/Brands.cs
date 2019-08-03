﻿using System;
using System.Collections.Generic;

namespace MobileApp.Models
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
            //Id = Settings.GenerateId();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public int CountOfProduced { get; set; }
        public virtual ICollection<ProducedBrands> ProducedBrands { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
