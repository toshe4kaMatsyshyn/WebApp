using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;

using Xamarin.Forms;

using MobileApp.Models;
using MobileApp.Views;
using MobileApp.Services;

namespace MobileApp.ViewModels
{
    public class TerminalsViewModel : BaseViewModel
    {

        public ObservableCollection<Terminal> Terminals { get; private set; }
        public Command LoadItemsCommand { get; set; }

        DataLoad<Terminal> dataLoad { get; set; } = new DataLoad<Terminal>();

        public TerminalsViewModel()
        {
            Title = "Terminals";
            Terminals = dataLoad.Items;
            LoadItemsCommand = new Command(() => LoadTerminals());
        }


        async void LoadTerminals()
        {
            string url = "http://192.168.1.105:2627/api/terminal";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                JArray jArray = JArray.Parse(content);

                Terminals = JsonConvert.DeserializeObject<ObservableCollection<Terminal>>(jArray.ToString());
                
                Console.WriteLine(Terminals.Count);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
        async Task ExecuteLoadItemsCommand()
        {
            string url = "http://192.168.1.105:2627/api/terminal";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                JArray jArray = JArray.Parse(content);
              
                var terminals = JsonConvert.DeserializeObject<List<Terminal>>(jArray.ToString());
                //Terminals = terminals;
                
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                
            }
        }
    }
}