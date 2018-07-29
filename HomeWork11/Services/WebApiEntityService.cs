using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HomeWork11.Services
{
    public class WebApiEntityService<T, T1> 
        where T : class 
        where T1 : class 
    {
        private readonly HttpClient _client;
        private const string ApiUrl = @"http://localhost:51099/api/";
        private readonly string _callUrl;
        
        public WebApiEntityService(string entityPrefix)
        {
            _client = new HttpClient();
            _callUrl = ApiUrl + entityPrefix;
        }

        public async Task<T> GetById(int id)
        {
            HttpResponseMessage response = await _client.GetAsync(_callUrl + $"/{id}");
            T entity = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                throw new AggregateException("Could not get a correct response from the server.");
            }

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            HttpResponseMessage response = await _client.GetAsync(_callUrl);
            List<T> entities = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                throw new AggregateException("Could not get a correct response from the server.");
            }

            return entities;
        }

        public async Task<int> Create(T1 createModelRequest)
        {
            StringContent contentToCreate = new StringContent(JsonConvert.SerializeObject(createModelRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(_callUrl, contentToCreate);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(json);
            }
            
            throw new AggregateException("Could not get a correct response from the server.");
        }

        public async Task<bool> Update(int id, T1 updateModelRequest)
        {
            StringContent cotentToUpdate = new StringContent(JsonConvert.SerializeObject(updateModelRequest), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync(_callUrl + $"/{id}", cotentToUpdate);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(json);
            }

            throw new AggregateException("Could not get a correct response from the server.");
        }

        public async Task<bool> Delete(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(_callUrl + $"/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(json);
            }

            throw new AggregateException("Could not get a correct response from the server.");
        }
    }
}