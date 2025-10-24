using Microsoft.AspNetCore.Mvc;
using ShopTARge24.ApplicationServices.Services;

namespace ShopTARge24.Controllers
{
    public class ChuckJokeController : Controller
    {
        private readonly ChuckNorrisService _chuckNorrisService;

        public ChuckJokeController(ChuckNorrisService chuckNorrisService)
        {
            _chuckNorrisService = chuckNorrisService;
        }

        public async Task<IActionResult> Index()
        {
            var joke = await _chuckNorrisService.GetRandomChuckJoke();
            ViewData["Joke"] = joke;
            return View();
        }
    }
}
