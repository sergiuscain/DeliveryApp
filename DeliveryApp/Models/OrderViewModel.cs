using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Models
{
    public class OrderViewModel
    {

        public Guid Id { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage ="Введите вес заказа от 1го кг до 100кг")]
        public int Weight { get; set; } //В килограммах
        [Required(ErrorMessage ="Это обязательное поле")]
        public string CityDistrict { get; set; } //Район города
        [Required(ErrorMessage ="Это обязательное поле!")]
        public DateTime OrderDeliveryDate  { get; set; } //Дата и время доставки
        public DateTime OrderCreationDate { get; set; } //Время создания заказа

    }
}
