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

namespace MobileApp.Services
{
    class WorkWithServer
    {
        public ObservableCollection<Brands> GetBrands()
        {
            ObservableCollection<Brands> Brands = new ObservableCollection<Brands>();
            string url = "http://192.168.1.105:2627/api/brands";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync(client.BaseAddress).Result;

                var content = response.Content.ReadAsStringAsync().Result;
                JArray jArray = JArray.Parse(content);

                Brands = JsonConvert.DeserializeObject<ObservableCollection<Brands>>(jArray.ToString());
            }
            catch (Exception exc)
            {
                
            }
            return Brands;
        }
        public ObservableCollection<Terminal> GetTerminals()
        {
            ObservableCollection<Terminal> Terminals = new ObservableCollection<Terminal>();
            string url = "http://192.168.1.105:2627/api/terminal";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync(client.BaseAddress).Result;

                var content = response.Content.ReadAsStringAsync().Result;
                JArray jArray = JArray.Parse(content);

                Terminals = JsonConvert.DeserializeObject<ObservableCollection<Terminal>>(jArray.ToString());
            }
            catch (Exception exc)
            {

            }
            return Terminals;
        }
    }
}
