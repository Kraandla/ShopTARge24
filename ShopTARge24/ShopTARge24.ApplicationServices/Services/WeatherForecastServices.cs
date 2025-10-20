using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using System.Text.Json;

namespace ShopTARge24.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecast
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            //Tallinna linnakood 127964
            var apiKey = "zpka_449ed6414f4b4d3385fd7f079d2de6d7_88681152";
            var response = $"https://dataservice.accuweather.com/locations/v1/cities/search?apikey={apiKey}&q={dto.CityName}";

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(response);
                string json = await httpResponse.Content.ReadAsStringAsync();

                List<AccuLocationRootDto> weatherData = 
                    JsonSerializer.Deserialize<List<AccuLocationRootDto>>(json);

                dto.CityName = weatherData[0].;
            }

            return dto;
        }
    }
}
