using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Models.AccuWeathers;
using System.Threading.Tasks;
using ShopTARge24.Models.OpenWeather;

namespace ShopTARge24.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        public OpenWeatherController(
            IOpenWeatherServices openWeatherServices
            )
        {
            _openWeatherServices = openWeatherServices;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(OpenWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", new { city = model.City });
            }

            return View("Index", model);
        }

        public async Task<IActionResult> City(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                ViewBag.Error = "Please provide a valid city name.";
                return View("Index");
            }

            var weatherData = await _openWeatherServices.GetWeatherByCityName(city);

            if (weatherData == null)
            {
                ViewBag.Error = "No weather data found for that city.";
                return View("Index");
            }

            var viewModel = new OpenWeatherViewModel
            {
                City = weatherData.name,
                Country = weatherData.sys.country,
                Temperature = weatherData.main.temp,
                FeelsLike = weatherData.main.feels_like,
                Description = weatherData.weather.FirstOrDefault()?.description,
                WindSpeed = weatherData.wind.speed,
                Humidity = weatherData.main.humidity
            };

            return View(viewModel);
        }
    }
}
