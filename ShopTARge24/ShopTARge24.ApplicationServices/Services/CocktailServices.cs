using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.Dto.AccuWeather;
using ShopTARge24.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopTARge24.ApplicationServices.Services
{
    public class CocktailServices : ICocktailServices
    {
        private readonly HttpClient _httpClient;

        public CocktailServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Root> GetDrink(string strDrink)
        {
            var baseUrl = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=";

            var response = await _httpClient.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={strDrink}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var drinkData = JsonConvert.DeserializeObject<Root>(jsonResponse);

            return drinkData;
        }
    }
}
