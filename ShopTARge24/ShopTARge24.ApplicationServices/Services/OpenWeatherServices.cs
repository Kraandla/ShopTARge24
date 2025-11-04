using Nancy;
using Newtonsoft.Json;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge24.ApplicationServices.Services
{
    public class OpenWeatherServices : IOpenWeatherServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apikey = "3723eb83d928ac0851c98596bf45078d";

        public OpenWeatherServices(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<OpenWeatherDto.Root> GetWeatherByCityName(string City) 
        {
            var apiKey = _apikey;
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={City}&appid={apiKey}";
            
            var response = await _httpClient.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();
            var weatherData = JsonConvert.DeserializeObject<OpenWeatherDto.Root>(json);

            return weatherData;
        }
    }
}
