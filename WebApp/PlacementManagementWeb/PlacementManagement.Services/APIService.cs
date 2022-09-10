using Newtonsoft.Json;
using PlacementManagement.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlacementManagement.Services
{
    /// <summary>
    /// APIService client used to make Http calls
    /// </summary>
    public class APIService : IDisposable
    {
        private HttpClient _client;

        public APIService(string baseUrl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
        }

        /// <summary>
        /// Makes GET request on provided endPoint to retrieve many resource objects. Use this to fetch many resource objects.
        /// </summary>
        /// <returns>Returns the list of resource objects</returns>
        /// <exception cref="APIException"></exception>
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

        /// <summary>
        /// Makes GET request on provided endPoint to retrieve single resource. Use this to fetch single resource.
        /// </summary>
        /// <returns>Returns a single resource object</returns>
        /// <exception cref="APIException"></exception>
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

        /// <summary>
        /// Makes POST request on provided endPoint with dataObj body. Use this to create a new resource.
        /// </summary>
        /// <returns>Returns the response object received</returns>
        /// <exception cref="APIException"></exception>
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

        /// <summary>
        /// Makes PUT request on provided endPoint with dataObj body. Use this to update an existing resource.
        /// </summary>
        /// <exception cref="APIException"></exception>
        public async Task Update<T>(string endPoint, T dataObj)
        {
            var response = await _client.PutAsync(endPoint, ObjectToStringContent(dataObj));

            if (!response.IsSuccessStatusCode)
                throw new APIException(response.StatusCode, response.ReasonPhrase);
        }

        /// <summary>
        /// Makes DELETE request on provided endPoint. Use this to delete an existing resource.
        /// </summary>
        /// <exception cref="APIException"></exception>
        public async Task Delete(string endPoint)
        {
            var response = await _client.DeleteAsync(endPoint);

            if (!response.IsSuccessStatusCode)
                throw new APIException(response.StatusCode, response.ReasonPhrase);
        }

        /// <summary>
        /// Makes POST request on provided endPoint with dataObj body. 
        /// Use this to retreive many resource objects by passing body.
        /// </summary>
        /// <returns>Returns </returns>
        /// <exception cref="APIException"></exception>
        public async Task<List<T2>> GetManyUsingPost<T, T2>(string endPoint, T dataObj)
        {
            var response = await _client.PostAsync(endPoint, ObjectToStringContent(dataObj));

            List<T2> resultList;
            if (response.IsSuccessStatusCode)
                resultList = await response.Content.ReadAsAsync<List<T2>>();
            else
                throw new APIException(response.StatusCode, response.ReasonPhrase);

            return resultList; ;
        }

        private static StringContent ObjectToStringContent<T>(T dataObj)
        {
            var jsonData = JsonConvert.SerializeObject(dataObj);
            return new StringContent(jsonData, Encoding.UTF8, "application/json");
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
}