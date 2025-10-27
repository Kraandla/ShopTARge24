using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Models.AccuWeathers;
using ShopTARge24.Core.Dto.AccuWeather;

namespace ShopTARge24.Controllers
{
    public class AccuWeatherController : Controller
    {
        private readonly IWeatherForecast _weatherForecast;

        public AccuWeatherController
            (
                IWeatherForecast weatherForecast
            )
        {
            _weatherForecast = weatherForecast;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(AccuWeathersSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeathers", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            AccuLocationWeatherResultDto dto = new();
            dto.CityName = city;

            _weatherForecast.AccuWeatherResult(dto);

            return View(dto);
        }

    }
}
