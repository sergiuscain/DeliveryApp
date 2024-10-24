using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.DB.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Weight { get; set; } //В килограммах
        public District CityDistrict { get; set; } //Район города
        public DateTime OrderDeliveryTime { get; set; } //Дата и время доставки
        public DateTime OrderCreationDate { get; set; } //Время создания заказа
    }
}
