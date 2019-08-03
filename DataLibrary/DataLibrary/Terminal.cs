using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class Terminal:IComparable
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
        public int? ProducedBrands { get; set; } = 0;

        public virtual ICollection<TerminalsAndBrands> TerminalsAndBrands { get; set; }

        public int CompareTo(object obj)
        {
            Terminal terminal = (Terminal)obj;
            if (ProducedBrands > terminal.ProducedBrands) return -1;
            else
                if (ProducedBrands < terminal.ProducedBrands) return 1;
            else return 0;
        }
    }
}
