using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models
{
    public class FiltersAndOrdersModel
    {
        public List<OrderViewModel> _orders {  get; set; }
        [Required(ErrorMessage ="Введите дату и время")]
        public DateTime FirstDateTime { get; set; }
        [Required(ErrorMessage ="Введите дату и время")]
        public DateTime LastDateTime { get; set; }
        public List<DistrictViewModel> Districts { get; set; }
        public string DistrictName { get; set; }
    }
}
