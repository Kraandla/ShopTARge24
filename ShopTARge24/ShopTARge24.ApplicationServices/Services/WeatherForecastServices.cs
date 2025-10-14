using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using System.Text.Json;

namespace ShopTARge24.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecast
    {
        public async Task<AccuLocationRootDto> AccuWeatherResult(AccuLocationRootDto dto)
        {
            //Tallinna linnakood 127964
            var response = $"https://dataservice.accuweather.com/locations/v1/cities/search";

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(response);
                string json = await httpResponse.Content.ReadAsStringAsync();

                List<AccuLocationRootDto> weatherData = JsonSerializer.Deserialize<List<AccuLocationRootDto>>(json);
            }

            return dto;
        }
    }
}
