using System;
using System.Collections.Generic;
using MobileApp.Models;

namespace MobileApp.ViewModels
{
    public class TerminalDetailViewModel : BaseViewModel
    {
        public Terminal Terminal { get; set; }
        public List<Brands> Brands { get; set; }

        public TerminalDetailViewModel(Terminal terminal = null)
        {
            Title = terminal?.Name;
            Terminal = terminal;
            Brands = Services.Settings.GetBrands();
        }
    }
}
