using Microsoft.AspNetCore.Mvc;
using ShopTARge24.ApplicationServices.Services;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;
using ShopTARge24.Models.RealEstate;
using ShopTARge24.Models.Spaceships;

namespace ShopTARge24.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ShopTARge24Context _context;
        private readonly IRealEstateServices _realEstateServices;

        public RealEstateController
    (
        ShopTARge24Context context,
        IRealEstateServices realEstateServices,
    )
        {
            _context = context;
            _realEstateServices = realEstateServices;
        }
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Area = x.Area,
                    Location = x.Location,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });

            return View(result);
        }
    }
}
