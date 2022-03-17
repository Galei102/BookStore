using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int Price { get; set; }
        

        public string ShopProductsId { get; set; }
    }
}
