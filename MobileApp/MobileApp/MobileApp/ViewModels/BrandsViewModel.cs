using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;

using Xamarin.Forms;

using MobileApp.Models;
using MobileApp.Views;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class BrandsViewModel : BaseViewModel
    {
        public ObservableCollection<Brands> Brands { get; private set; }
        DataLoad<Brands> dataLoad { get; set; } = new DataLoad<Brands>();

        public BrandsViewModel()
        {
            Title = "Brands";
            Brands = dataLoad.Items;
        }

        public ObservableCollection<Brands> CollectionFilter(string Text,bool SwitchIsToggled)
        {
            ObservableCollection<Brands> newCollection = new ObservableCollection<Brands>();

            //тестовая фильтрация
            if (!string.IsNullOrEmpty(Text))
            {
                if (SwitchIsToggled)
                {

                    //newCollection.Add(Brands.First<Brands>());
                }
                else
                {
                    //newCollection.Add(Brands.Last<Brands>());
                }
            }
            else
            {
                if (SwitchIsToggled)
                {
                    //newCollection.Add(Brands[Brands.Count - 2]);
                }
                else
                {
                    //newCollection = Brands;
                }
            }

            return newCollection;
        }
    }
}