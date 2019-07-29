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
    public partial class BrandsPage : ContentPage
    {
        BrandsViewModel viewModel;
        
        public BrandsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new BrandsViewModel();
            MyListView.ItemsSource = viewModel.Brands;

            SearchBar.TextChanged += FilterBrandsBySearchBar;
            Switch.Toggled += FilterBrandsBySwitch;
            //IsTogged
        }

        void FilterBrandsBySwitch(object sender, EventArgs eventArgs)
        {
            if(Switch.IsToggled)
            {
                MyListView.ItemsSource = new List<Models.Brands>();
            }
            else
            {
                MyListView.ItemsSource = viewModel.Brands;
            }
        }

        void FilterBrandsBySearchBar(object sender, EventArgs eventArgs)
        {
            string Text = SearchBar.Text;
            if(!string.IsNullOrEmpty(Text))
            {
                //Фильтрация выборки
            }
            else
            {
                MyListView.ItemsSource = viewModel.Brands;
            }
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