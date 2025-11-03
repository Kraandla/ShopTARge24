using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.ServiceInterface;

namespace ShopTARge24.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailServices _cocktailServices;

        public CocktailsController
            (
                ICocktailServices cocktailServices
            )
        {
            _cocktailServices = cocktailServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string name) 
        { 
            if (string.IsNullOrEmpty(name))
                return View("Error", "Please enter a name");

            var result = await _cocktailServices.GetDrink(name);

            if (result?.drinks == null) 
                return View("Not Found");

            return View(result);
        }
    }
}
