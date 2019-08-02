using System;
using System.Collections.ObjectModel;
using System.Text;

using MobileApp.Models;
using MobileApp.Services;
namespace MobileApp.ViewModels
{
    class DeliveredBrandsViewModel:BaseViewModel
    {
        public ObservableCollection<DeliveredBrands> deliveredBrands { get; set; }

        DataLoad<DeliveredBrands> dataLoad { get; set; } = new DataLoad<DeliveredBrands>();

        public DeliveredBrandsViewModel()
        {
            Title = "Delivered Brands";
            deliveredBrands = dataLoad.Items;
        }
    }
}
