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

        public Terminal(string Name)
        {
            this.Name = Name;
            Id = Settings.GenerateId();
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int? ProducedBrands { get; set; }

        public virtual ICollection<TerminalsAndBrands> TerminalsAndBrands { get; set; }
    }
}
