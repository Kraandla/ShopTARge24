using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;
using ShopTARge24.Models.Kindergarten;
using ShopTARge24.Models.Spaceships;

namespace ShopTARge24.Controllers
{
    public class KindergartenController : Controller
    {
        private readonly ShopTARge24Context _context;
        private readonly IKindergartenServices _KindergartenServices;

        public KindergartenController
            (
                ShopTARge24Context context,
                IKindergartenServices KindergartenServices
            )
        {
            _context = context;
            _KindergartenServices = KindergartenServices;
        }


        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new KindergartenIndexViewModel
                {
                    Id = x.Id,
                    KindergartenName = x.KindergartenName,
                    GroupName = x.GroupName,
                    ChildCount = x.ChildCount,
                    CreatedAt = x.CreatedAt,
                });

            return View(result);
        }
    }
}
