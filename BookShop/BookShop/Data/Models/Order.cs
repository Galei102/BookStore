using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Order
    {

        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Name { get; set; }



        [Display(Name = "Фамилию")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Surname { get; set; }



        [Display(Name = "Введите адресс")]
        [Required(ErrorMessage = "Заполните поле")]
        public string Adress { get; set; }



        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Заполните поле")]
        public int Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Заполните поле")]
        public string Email { get; set; }



        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
