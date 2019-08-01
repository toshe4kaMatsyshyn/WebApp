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
        public List<Terminal> Terminals { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TerminalsViewModel()
        {
            Title = "Terminals";
            Terminals = new List<Terminal>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //LoadItemsCommand.Execute(new object());
        }

        async Task ExecuteLoadItemsCommand()
        {
            string url = "https://localhost:5001/api/terminal";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                System.Threading.Thread.Sleep(1000);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"$");
                var terminals = JsonConvert.DeserializeObject<List<Terminal>>(str.ToString());

                Terminals = terminals;
                
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                
            }
        }
    }
}