using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileApp.ViewModels;
using System.Collections.Specialized;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrandsPage : ContentPage
    {
        BrandsViewModel viewModel;
        public BrandsPage()
        {
            InitializeComponent();
            viewModel = new BrandsViewModel();
            MyListView.ItemsSource = viewModel.Brands;

            SearchBar.TextChanged += FilterTheList;
            Switch.Toggled += FilterTheList;
        }

        void FilterTheList(object sender, EventArgs eventArgs)
        {
            MyListView.ItemsSource = viewModel.CollectionFilter(SearchBar.Text, Switch.IsToggled);
        }
    }
}