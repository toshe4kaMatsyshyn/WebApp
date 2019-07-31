using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileApp.Models;
using MobileApp.ViewModels;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        TerminalDetailViewModel viewModel;

        public ItemDetailPage(TerminalDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            BrandsListView.ItemsSource = viewModel.Brands;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var terminal = new Terminal
            {
                Name = "Terminal-1"
            };

            viewModel = new TerminalDetailViewModel(terminal);
            BindingContext = viewModel;
        }
    }
}