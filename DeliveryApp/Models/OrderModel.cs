namespace DeliveryApp.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public int Weight { get; set; } //В килограммах
        public string CityDistrict { get; set; } //Район города
        public DateTime OrderDeliveryTime  { get; set; } //Дата и время доставки
        public DateTime OrderCreationDate { get; set; } //Время создания заказа
        public OrderModel()
        {
            OrderCreationDate = DateTime.Now;
        }
    }
}
