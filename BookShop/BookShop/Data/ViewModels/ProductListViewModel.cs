using BookShop.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.Data.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public SelectList Categorys { get; set; }

        public string Name { get; set; }
        

    }
}
