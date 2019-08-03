using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;

using MobileApp.Models;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class ProducedBrandsViewModel:BaseViewModel,INotifyPropertyChanged
    {
        public ObservableCollection<ProducedBrands> ProducedBrand { get; private set; }

        DataLoad<ProducedBrands> dataLoad { get; set; } = new DataLoad<ProducedBrands>();

        public ProducedBrandsViewModel()
        {
            Title = "Produced Brands";
            ProducedBrand = dataLoad.Items;
            foreach(ProducedBrands producedBrands in ProducedBrand)
                if (producedBrands.Brand != null) Console.WriteLine(producedBrands.Brand);
                else Console.WriteLine("brands is null");
        }
    }
}
