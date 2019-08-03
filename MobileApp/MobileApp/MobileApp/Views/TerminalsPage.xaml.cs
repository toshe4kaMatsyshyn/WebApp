using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileApp.Models;
using MobileApp.Views;
using MobileApp.ViewModels;
using System.Collections.Specialized;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TerminalsPage : ContentPage
    {
        TerminalsViewModel viewModel;

        public TerminalsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TerminalsViewModel();

            TerminalsListView.ItemsSource = viewModel.Terminals;
            viewModel.Terminals.CollectionChanged += RefreshCollection;
        }

        void RefreshCollection(object sender, NotifyCollectionChangedEventArgs e)
        {
            TerminalsListView.ItemsSource = viewModel.Terminals;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var terminal = args.SelectedItem as Terminal;
            if (terminal == null)
                return;

            await Navigation.PushAsync(new TerminalDetailPage(new TerminalDetailViewModel(terminal)));

            // Manually deselect item.
            TerminalsListView.SelectedItem = null;
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Terminals.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}