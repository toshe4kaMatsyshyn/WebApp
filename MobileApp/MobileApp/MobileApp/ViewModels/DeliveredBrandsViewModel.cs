using System;
using System.Collections.Generic;
using System.Text;

using MobileApp.Models;

namespace MobileApp.ViewModels
{
    class DeliveredBrandsViewModel:BaseViewModel
    {
        public List<DeliveredBrands> deliveredBrands { get; set; }
        public DeliveredBrandsViewModel()
        {
            Title = "Delivered Brands";
            deliveredBrands = new List<DeliveredBrands>();
        }
    }
}
