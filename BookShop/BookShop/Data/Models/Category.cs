using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }



        [Display(Name = "Название")]
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string Name { get; set; }


    
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
