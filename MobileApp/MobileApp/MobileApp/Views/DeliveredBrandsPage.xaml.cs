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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
