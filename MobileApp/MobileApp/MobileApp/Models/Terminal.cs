using System;
using System.Collections.Generic;

namespace MobileApp.Models
{
    public partial class Terminal:IComparable
    {
        public Terminal()
        {

        }

        public Terminal(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int? ProducedBrands { get; set; } = 0;

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
