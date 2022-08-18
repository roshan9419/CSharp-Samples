using Mizza.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MizzaWebApp.Repository
{
    internal class MizzaRepository
    {
        private const string BASE_URL = "https://localhost:44368/api/";
        private static readonly HttpClient _httpClient;

        static MizzaRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BASE_URL); // TODO: read from configuration
        }

        internal List<T> GetMany<T>(string endPoint)
        {
            List<T> list = new List<T>();
            
            var resTask = _httpClient.GetAsync(endPoint);
            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<T>>();
                readTask.Wait();
                list = readTask.Result;
            }

            return list;
        }

        internal T Get<T>(string endPoint)
        {
            T item = default(T);

            var resTask = _httpClient.GetAsync(endPoint);
            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<T>();
                readTask.Wait();
                item = readTask.Result;
            }

            return item;
        }

        internal void Create<T>(string endPoint, T dataObj)
        {
            var resTask = _httpClient.PostAsync(endPoint, ObjectToStringContent(dataObj));
            resTask.Wait();

            var result = resTask.Result;

            if (!result.IsSuccessStatusCode)
            {
                // handle error
            }
        }

        internal void Update<T>(string endPoint, T dataObj)
        {
            var resTask = _httpClient.PutAsync(endPoint, ObjectToStringContent(dataObj));
            resTask.Wait();

            var result = resTask.Result;

            if (!result.IsSuccessStatusCode)
            {
                // handle error
            }
        }

        internal void Delete(string endPoint)
        {
            var resTask = _httpClient.DeleteAsync(endPoint);
            resTask.Wait();

            var result = resTask.Result;

            if (!result.IsSuccessStatusCode)
            {
                // handle error
            }
        }

        private StringContent ObjectToStringContent<T>(T dataObj)
        {
            var jsonData = JsonConvert.SerializeObject(dataObj);
            return new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
        }
    }
}