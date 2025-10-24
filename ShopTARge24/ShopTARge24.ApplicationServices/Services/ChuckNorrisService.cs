using ShopTARge24.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopTARge24.ApplicationServices.Services
{
    public class ChuckNorrisService
    {
        private readonly HttpClient _httpClient;

        public ChuckNorrisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRandomChuckJoke() {
            var response = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");

            using var stream = await response.Content.ReadAsStreamAsync();
            var jokeData = await JsonSerializer.DeserializeAsync<ChuckJoke>(
                stream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return jokeData?.value;
        }
    }

    public class ChuckJoke
    {
        public string? value {  get; set; }
    }
}
