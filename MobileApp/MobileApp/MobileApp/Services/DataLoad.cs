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

namespace MobileApp.Services
{
    public class DataLoad<T> where T:new()
    {
        T itemType { get; set; } = new T();
        public ObservableCollection<T> Items { get; set; }

        public DataLoad()
        {
            LoadItems();
        }

        void LoadItems()
        {
            string url = "http://192.168.1.105:2627/api/"+itemType.GetType().Name.ToLower();
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response =  client.GetAsync(client.BaseAddress).Result;

                var content =  response.Content.ReadAsStringAsync().Result;
                JArray jArray = JArray.Parse(content);

                Items = JsonConvert.DeserializeObject<ObservableCollection<T>>(jArray.ToString());

                
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
