using System;
using System.Collections.Generic;
using System.Text;

using MobileApp.Models;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class ProducedBrandsViewModel:BaseViewModel
    {
        public List<ProducedBrands> producedBrands { get; set; }

        public ProducedBrandsViewModel()
        {
            Title = "Produced Brands";
            producedBrands = new List<ProducedBrands>();
        }
    }
}
