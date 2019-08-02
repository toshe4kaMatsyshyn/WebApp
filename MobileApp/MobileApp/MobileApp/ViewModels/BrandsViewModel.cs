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
    public class BrandsViewModel : BaseViewModel
    {
        public ObservableCollection<Brands> Brands { get; set; }
        DataLoad<Brands> dataLoad { get; set; } = new DataLoad<Brands>();

        public BrandsViewModel()
        {
            Title = "Brands";
            Brands = dataLoad.Items;
        }

        async void LoadBrands()
        {
            string url = "http://192.168.1.105:2627/api/brands";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                JArray jArray = JArray.Parse(content);

                this.Brands = JsonConvert.DeserializeObject<ObservableCollection<Brands>>(jArray.ToString());

                Console.WriteLine(Brands.Count);
                foreach (Brands brands in Brands)
                    Console.WriteLine(brands.Name);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}