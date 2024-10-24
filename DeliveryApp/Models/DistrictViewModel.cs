namespace DeliveryApp.Models
{
    public class DistrictViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<OrderViewModel> Orders;
    }
}
