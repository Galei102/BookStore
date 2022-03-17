using BookShop.Data.Interfaces;
using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.Repository
{
    public class ProductsRepository : IProducts
    {
        private readonly Db db;

        public ProductsRepository(Db _db)
        {
            this.db = _db;
        }
        public IEnumerable<Product> Products => db.Products.Include(c => c.Category);

        public Product GetObjectBook(int productId) => db.Products.FirstOrDefault(p => p.Id == productId);
    }
}
