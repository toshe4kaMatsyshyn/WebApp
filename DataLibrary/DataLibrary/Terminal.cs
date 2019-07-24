using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class Terminal
    {
        public Terminal()
        {
            TerminalsAndBrands = new HashSet<TerminalsAndBrands>();
        }

        public string Name { get; set; }
        public int? ProducedBrands { get; set; }
        public string Id { get; set; }

        public virtual ICollection<TerminalsAndBrands> TerminalsAndBrands { get; set; }
    }
}
