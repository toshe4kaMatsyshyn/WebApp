using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp.ViewModels;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveredBrandsPage : ContentPage
    {
        DeliveredBrandsViewModel viewModel;

        public DeliveredBrandsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DeliveredBrandsViewModel();
			
			MyListView.ItemsSource = viewModel.deliveredBrands;
        }

        
    }
}
