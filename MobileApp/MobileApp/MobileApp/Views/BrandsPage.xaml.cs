using System;
using System.Collections.ObjectModel;
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

            SearchBar.SearchButtonPressed += FilterBrands;
        }

        void FilterBrands(object sender, EventArgs eventArgs)
        {
            string Text = SearchBar.Text;
            if(!string.IsNullOrEmpty(Text))
            {
                //Фильтрация выборки
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