using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Services.Implementation
{
    public sealed class GitHubApiService : IGitHubApiService
    {
        private readonly string _baseUrl = "https://api.github.com/";

        public async Task<List<GitHubResponseModel>> GetData(string url)
        {
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }) { BaseAddress = new Uri(_baseUrl) })
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.132 Safari/537.36");

                var response = await client.GetAsync(url);
                return await HandleResponse(response);
            }
        }

        private async Task<List<GitHubResponseModel>> HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var response_parsed = JsonConvert.DeserializeObject<List<GitHubResponseModel>>(content);
                return response_parsed;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<GitHubErrorModel>(content);
                Console.WriteLine($"{((int)response.StatusCode)}: {error.message}");
                return null;
            }
        }
    }
}
