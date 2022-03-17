using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }


      
        [Display(Name = "Название книги")]
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string Name { get; set; }



        [Display(Name = "Краткое описание")]
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 50 символов")]
        public string ShortDesc { get; set; }                                                                        //Краткое описание



        [Display(Name = "Длинное описание")]
        [Required(ErrorMessage = "Заполните поле")]
        [MinLength(10, ErrorMessage = "Длина строки должна быть не менее 10 символов")]
        public string LongDesc { get; set; }                                                                         //Длинное описание



        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Заполните поле")]
        public ushort Price { get; set; }



        [Display(Name = "Год издания")]
        [Required(ErrorMessage = "Заполните поле")]        
        public int Year { get; set; }



        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Выберите категорию")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }



        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Выберите автора")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }



        [Required(ErrorMessage = "Добавьте картинку")]
        public string PathImg { get; set; }



        public string NameImg { get; set; }

        
    }
}
