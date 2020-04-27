using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using MobileAIEnrichment.Models;
using MobileAIEnrichment.Helpers;

namespace MobileAIEnrichment.Services
{
    public static class AzureSearchService
    {
        private static readonly HttpClient client = CreateHttpClient();

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Constants.AzureSearchServiceURL);
            client.DefaultRequestHeaders.Add("api-key", Constants.ApiKey);
            return client;
        }

        public async static Task<AzureSearchResult> Search(string term)
        {
            try
            {
                var searchUrl = $"{Constants.AzureSearchParameters}{term}";
                var response = await client.GetAsync(searchUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var searchResult = JsonConvert.DeserializeObject<AzureSearchResult>(jsonResult);
                    return searchResult;
                }
            }
            catch (Exception ex)
            {
            }

            return new AzureSearchResult() { Value = new List<Value>() };
        }
    }
}