using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Author
    {
        [Display(Name = "№")]
        public int Id { get; set; }



        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 40 символов")]
        public string Name { get; set; }



        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 40 символов")]
        public string Surname { get; set; }



        [Display(Name = "Дата Рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }



        public ICollection<Product> Products { get; set; }
        public Author()
        {
            Products = new List<Product>();
        }
    }
}
