using DeliveryApp.DB.Models;

namespace DeliveryApp.DB
{
    public interface IOrdersStorage
    {
        void AddOrder(Order order);
        IEnumerable<Order> GetByDistrict(string district);
        IEnumerable<Order> GetOrders();
        void RemoveOrder(Order order);
    }
}