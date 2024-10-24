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

        public HomeController(ILogger<HomeController> logger, IOrdersStorage ordersStorage)
        {
            _logger = logger;
            _ordersStorage = ordersStorage;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(FiltersAndOrdersModel model)
        {
            var orders = _ordersStorage.GetOrders();
            orders = orders.Where(o => o.OrderDeliveryTime >= model.FirstDateTime && o.OrderDeliveryTime <= model.LastDateTime).ToList();
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
