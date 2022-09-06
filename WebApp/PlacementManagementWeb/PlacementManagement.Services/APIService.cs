using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.Services
{
    public class APIService : IDisposable
    {
        private HttpClient _client;

        public APIService(string baseUrl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<List<T>> GetMany<T>(string endPoint)
        {
            List<T> resultList;

            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
                resultList = await response.Content.ReadAsAsync<List<T>>();
            else
                throw new APIException(response.StatusCode, response.ReasonPhrase);

            return resultList;
        }

        public async Task<T> Get<T>(string endPoint)
        {
            T item;

            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
                item = await response.Content.ReadAsAsync<T>();
            else
                throw new APIException(response.StatusCode, response.ReasonPhrase);

            return item;
        }

        public async Task<object> Create<T>(string endPoint, T dataObj)
        {
            var response = await _client.PostAsync(endPoint, ObjectToStringContent(dataObj));
            
            object result;
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<object>();
            else
                throw new APIException(response.StatusCode, response.ReasonPhrase);

            return result;
        }

        public async Task Update<T>(string endPoint, T dataObj)
        {
            var response = await _client.PutAsync(endPoint, ObjectToStringContent(dataObj));

            if (!response.IsSuccessStatusCode)
                throw new APIException(response.StatusCode, response.ReasonPhrase);
        }

        public async Task Delete(string endPoint)
        {
            var response = await _client.DeleteAsync(endPoint);

            if (!response.IsSuccessStatusCode)
                throw new APIException(response.StatusCode, response.ReasonPhrase);
        }

        public async Task<List<T2>> GetManyUsingPost<T, T2>(string endPoint, T dataObj)
        {
            var response = await _client.PostAsync(endPoint, ObjectToStringContent(dataObj));

            List<T2> resultList;
            if (response.IsSuccessStatusCode)
                resultList = await response.Content.ReadAsAsync<List<T2>>();
            else
                throw new APIException(response.StatusCode, response.ReasonPhrase);

            return resultList;;
        }

        private static StringContent ObjectToStringContent<T>(T dataObj)
        {
            var jsonData = JsonConvert.SerializeObject(dataObj);
            return new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }
    }

    public class APIException : Exception
    {
        public APIException()
        {
        }

        public HttpStatusCode StatusCode { get; set; }

        public APIException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}