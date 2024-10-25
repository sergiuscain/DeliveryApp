using DeliveryApp.DB;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeliveryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrdersStorage _ordersStorage;
        private readonly IDistrictStorage _districtStorage;

        public HomeController(ILogger<HomeController> logger, IOrdersStorage ordersStorage, IDistrictStorage districtStorage)
        {
            _logger = logger;
            _ordersStorage = ordersStorage;
            _districtStorage = districtStorage;
        }

        public IActionResult Index()
        {
            FiltersAndOrdersModel model = new FiltersAndOrdersModel
            {
                FirstDateTime = DateTime.Now.AddDays(-7),
                LastDateTime = DateTime.Now,
                DistrictName = "All"
            };
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult Index(FiltersAndOrdersModel model)
        {
            var orders = _ordersStorage.GetOrders();
            orders = orders.Where(o => o.OrderDeliveryDate >= model.FirstDateTime && o.OrderDeliveryDate <= model.LastDateTime);
            if (model.DistrictName.ToUpper() != "ALL")
            orders = orders.Where(o => o.CityDistrict.Name == model.DistrictName).ToList();
            orders = orders.OrderBy(o => o.CityDistrict.Order.Count).ThenBy(o => o.OrderCreationDate).Reverse();
            model._orders = orders.Select(o => o.ToVM()).ToList();
            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
