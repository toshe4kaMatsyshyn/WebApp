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
            viewModel.Brands.CollectionChanged += RefreshTheCollection;

            SearchBar.TextChanged += FilterTheList;
            Switch.Toggled += FilterTheList;
        }

        void RefreshTheCollection(object sender, NotifyCollectionChangedEventArgs e)
        {
            MyListView.ItemsSource = viewModel.Brands;
        }

        void FilterTheList(object sender, EventArgs eventArgs)
        {
            string Text = SearchBar.Text;
            if(!string.IsNullOrEmpty(Text))
            {
                if(Switch.IsToggled)
                {
                    MyListView.ItemsSource = viewModel.Brands.Where(B => B.Name.Length > 4).Where(b => b.Name.Contains(Text));
                }
                else
                {
                    MyListView.ItemsSource = viewModel.Brands.Where(b => b.Name.Contains(Text));
                }
            }
            else
            {
                if (Switch.IsToggled)
                {
                    MyListView.ItemsSource = viewModel.Brands.Where(b => b.Name.Length > 4);//Where(u => u.Name.Length > 4);
                }
                else
                {
                    MyListView.ItemsSource = viewModel.Brands;
                }
            }
        }
    }
}