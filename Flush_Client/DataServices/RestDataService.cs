using Flush_Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flush_Client.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializeOptions;

        public RestDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5271" : "https://localhost:7162";
            _url = $"{_baseAddress}/api";

            _jsonSerializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }


        public async Task AddIbsCountAsync(IbsCount ibsCount)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("----- No Internet Access -----");
                return;
            }
            try
            {
                string jsonIbsCount = JsonSerializer.Serialize<IbsCount>(ibsCount, _jsonSerializeOptions);
                StringContent content = new StringContent(jsonIbsCount, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/ibs_count", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"{response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return;
        }

        public async Task<List<IbsCount>> GetIbsCountAsync()
        {
            List<IbsCount> results = new List<IbsCount>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("----- No Internet Access -----");
                return results;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/ibs_count");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    results = JsonSerializer.Deserialize<List<IbsCount>>(content, _jsonSerializeOptions);
                }
                else
                {
                    Debug.WriteLine("---- Not HTTP 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }

            return results;
        }

        public async Task UpdateIbsCountAsync(IbsCount ibsCount)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("----- No Internet Access -----");
                return;
            }
            try
            {
                string jsonIbsCount = JsonSerializer.Serialize<IbsCount>(ibsCount, _jsonSerializeOptions);
                StringContent content = new StringContent(jsonIbsCount, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/ibs_count/{ibsCount.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"{response.StatusCode}");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return;
        }

        public async Task DeleteIbsCountAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("----- No Internet Access -----");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/ibs_count/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("---- Success HTTP 2xx response");

                }
                else
                {
                    Debug.WriteLine("---- Not HTTP 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }

            return;
        }
    }
}

