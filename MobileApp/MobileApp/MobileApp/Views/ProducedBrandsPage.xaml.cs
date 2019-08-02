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
    public partial class ProducedBrandsPage : ContentPage
    {
        ProducedBrandsViewModel viewModel;

        public ProducedBrandsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProducedBrandsViewModel();
			
			MyListView.ItemsSource = viewModel.ProducedBrand;
        }
    }
}
