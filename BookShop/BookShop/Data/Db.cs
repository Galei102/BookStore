using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
