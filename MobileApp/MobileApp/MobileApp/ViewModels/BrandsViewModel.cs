using System;
using System.Windows.Input;
using System.Collections.Generic;

using Xamarin.Forms;
using MobileApp.Models;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class BrandsViewModel : BaseViewModel
    {
        public List<Brands> Brands { get; set; }
        public BrandsViewModel()
        {
            Title = "Brands";
            Brands = Settings.GetBrands();
        }
    }
}