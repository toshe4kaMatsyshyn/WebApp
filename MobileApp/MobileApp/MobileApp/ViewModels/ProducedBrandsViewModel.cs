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
        ObservableCollection<ProducedBrands> producedBrands;
        public ObservableCollection<ProducedBrands> ProducedBrand
        {
            get
            {
                return producedBrands;
            }
            set
            {
                if(value!=null)
                {
                    producedBrands = value;
                    OnPropertyChanged("ProducedBrand");
                }
            }
        }

        DataLoad<ProducedBrands> dataLoad { get; set; } = new DataLoad<ProducedBrands>();

        public ProducedBrandsViewModel()
        {
            Title = "Produced Brands";
            ProducedBrand = dataLoad.Items;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
