using DeliveryApp.DB;
using DeliveryApp.DB.Models;
using DeliveryApp.Models;

namespace DeliveryApp
{
    public static class Mapper
    {
        public static Order ToDb(this OrderViewModel viewModel)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                OrderCreationDate = DateTime.Now,
                OrderDeliveryDate = viewModel.OrderDeliveryDate,
                Weight = viewModel.Weight
            };
        }
        public static OrderViewModel ToVM(this Order order)
        {
            return new OrderViewModel
            {
                CityDistrict = order.CityDistrict.Name,
                Id = order.Id,
                OrderCreationDate = order.OrderCreationDate,
                OrderDeliveryDate = order.OrderDeliveryDate,
                Weight = order.Weight
            };
        }
        public static District ToDB(this DistrictViewModel districtViewModel)
        {
            return new District
            {
                ID = districtViewModel.ID,
                Name = districtViewModel.Name,
            };
        }
        public static DistrictViewModel ToVM(this District district)
        {
            return new DistrictViewModel
            {
                ID = district.ID,
                Name = district.Name,
            };
        }
        public static List<DeliveringOrder> ToDeliveryOrder(this List<Order> orders)
        {
            var ordersInDelivery = new List<DeliveringOrder>();
            foreach (var order in orders)
            {
                ordersInDelivery.Add(new DeliveringOrder {
                    Id = order.Id,
                    CityDistrict = order.CityDistrict.Name,
                    Weight = order.Weight,
                    OrderCreationDate= order.OrderCreationDate,
                    OrderDeliveryDate= order.OrderDeliveryDate,
                });
            }
            return ordersInDelivery;
        }
    }
}
