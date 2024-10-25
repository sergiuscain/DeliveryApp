using DeliveryApp.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.DB
{
    public class OrdersDBStorage : IOrdersStorage
    {
        private readonly DeliveryAppDBContext _context;
        public OrdersDBStorage(DeliveryAppDBContext context)
        {
            _context = context;
        }
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChangesAsync();
        }
        public void RemoveOrder(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChangesAsync();
        }
        public IEnumerable<Order> GetOrders() => _context.Orders
              .Include(o => o.CityDistrict)
              .ToList();

        public IEnumerable<Order> GetByDistrict(string district) => _context.Orders
              .Include (o => o.CityDistrict)
              .Where(o => o.CityDistrict.Name == district)
              .ToList();
    }
}
