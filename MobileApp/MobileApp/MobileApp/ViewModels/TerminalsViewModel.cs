using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MobileApp.Models;
using MobileApp.Views;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class TerminalsViewModel : BaseViewModel
    {
        public List<Terminal> Terminals { get; set; }
        public Command LoadTerminalsCommand { get; set; }

        public TerminalsViewModel()
        {
            Title = "Terminals";
            Terminals = new List<Terminal>();
            LoadTerminalsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Terminals.Clear();
                Terminals = Settings.GetTerminals();
                var items = await DataStore.GetItemsAsync(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}