using System;
using System.Collections.Generic;

namespace DataLibrary
{
    public partial class TerminalsAndBrands
    {
        public TerminalsAndBrands()
        {

        }

        public TerminalsAndBrands(ProducedBrands produced, Terminal terminal)
        {
            ProducedBrandsId = produced.Id;
            TerminalId = terminal.Id;
        }

        public string ProducedBrandsId { get; set; }
        public string TerminalId { get; set; }

        public virtual ProducedBrands ProducedBrands { get; set; }
        public virtual Terminal Terminal { get; set; }
    }
}
