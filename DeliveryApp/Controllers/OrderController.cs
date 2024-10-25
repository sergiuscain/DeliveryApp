using DeliveryApp.DB;
using DeliveryApp.DB.Models;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersStorage orderStorage;
        private readonly IDistrictStorage districtStorage;
        public OrderController(IOrdersStorage orderStorage, IDistrictStorage districtStorage)
        {
            this.orderStorage = orderStorage;
            this.districtStorage = districtStorage;
        }
        public IActionResult Index()
        {
            var orders = orderStorage.GetOrders(); 
            var ordersViewModel = orders.Select(o => o.ToVM()).OrderBy(o => o.OrderDeliveryDate).ToList();
            return View(ordersViewModel);
        }
        public IActionResult Order(int orderId)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel order)
        {
            if (order.OrderDeliveryDate < DateTime.Now)
            {
                ModelState.AddModelError("OrderDeliveryTime", "Дата доставки не может быть в прошлом");
                return View(order);
            }
            else if (ModelState.IsValid)
            {
                District district;
                if (districtStorage.GetAllDistricts().Where(d => d.Name == order.CityDistrict).Count() > 0)
                {
                    district = districtStorage.GetByName(order.CityDistrict);
                }
                else
                {
                    district = new District { Name = order.CityDistrict, ID = Guid.NewGuid()};
                    districtStorage.Add(district);
                }
                Order orderDB = new Order
                {
                    Id = Guid.NewGuid(),
                    OrderCreationDate = DateTime.Now,
                    OrderDeliveryDate = order.OrderDeliveryDate,
                    Weight = order.Weight,
                    CityDistrict = district
                };
                orderStorage.AddOrder(orderDB);
                return RedirectToAction("Index", order.Id);
            }
            return View(order);
        }
        public IActionResult SelectDeliveyDistrictAndStart()
        {
            List<District> districtList = districtStorage.GetAllDistricts();
            var districtVM = districtList.Select(d => d.ToVM()).ToList();
            return View(districtVM);
        }
        public IActionResult StartDelivery(string district)
        {
            var orders = orderStorage.GetByDistrict(district).ToList();
            if (orders.Count() == 0)
            {
                return RedirectToAction("NoOrdersInDistrict", new DistrictViewModel { Name = district});
            }
            var startDate = orders.Min(orders => orders.OrderDeliveryDate);
            bool test = startDate == orders[1].OrderDeliveryDate;
            var endDate = startDate.AddMinutes(30);
            bool test2 = startDate == orders[1].OrderDeliveryDate;
            orders = orders.Where(o => (o.OrderDeliveryDate == startDate) || (o.OrderDeliveryDate < endDate && o.OrderDeliveryDate > startDate)).ToList();
            var ordersVM = orders.Select(o => o.ToVM()).ToList();
            return View(ordersVM);
        }
    }
}
