using Microsoft.AspNetCore.Mvc;

namespace ShopTARge24.Controllers
{
    public class AccuWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
