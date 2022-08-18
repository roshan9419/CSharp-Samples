using Mizza.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace DemoApp.Clients
{
    internal class MizzaClient
    {
        private const string BASE_URL = "https://localhost:44332/api/";
        private static readonly HttpClient _httpClient;

        static MizzaClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BASE_URL);
        }

        internal List<MizzaSize> GetMizzaSizes()
        {
            List<MizzaSize> mizzaList = new List<MizzaSize>();
            
            var resTask = _httpClient.GetAsync("mizzasizes");
            resTask.Wait();

            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<MizzaSize>>();
                readTask.Wait();
                mizzaList = readTask.Result;
            }
            else
            {
                // handle error
            }

            return mizzaList;
        }

        internal MizzaSize GetMizzaSize(string id)
        {
            var resTask = _httpClient.GetAsync($"mizzasizes/{id}");
            resTask.Wait();

            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<MizzaSize>();
                readTask.Wait();
                return readTask.Result;
            }
            else
            {
                // handle error
                return null;
            }
        }

        internal string CreateMizzaSize(MizzaSize mizzaSize)
        {
            var jsonData = JsonConvert.SerializeObject(mizzaSize);
            var stringContent = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

            var resTask = _httpClient.PostAsync("mizzasizes", stringContent);
            resTask.Wait();

            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return mizzaSize.MizzaSizeID;
            }
            else
            {
                // handle error
                return null;
            }
        }

        internal void UpdateMizzaSize(MizzaSize mizzaSize)
        {
            var jsonData = JsonConvert.SerializeObject(mizzaSize);
            var stringContent = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");

            var resTask = _httpClient.PutAsync($"mizzasizes/{mizzaSize.MizzaSizeID}", stringContent);
            resTask.Wait();

            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                //
            }
            else
            {
                // handle error
            }
        }

        internal void DeleteMizzaSize(string id)
        {
            var resTask = _httpClient.DeleteAsync($"mizzasizes/{id}");
            resTask.Wait();

            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                //
            }
            else
            {
                // handle error
            }
        }
    }
}