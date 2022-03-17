using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.Models
{
    public class ShopProducts
    {
        private readonly Db db;

        public ShopProducts(Db _db)
        {
            this.db = _db;
        }
        public string ShopProductsId { get; set; }
        public List<Cart> CartList { get; set; }
        public static ShopProducts GetBook(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<Db>();
            string shopProductsId = session.GetString("BookId") ?? Guid.NewGuid().ToString();

            session.SetString("BookId", shopProductsId);
            return new ShopProducts(context) { ShopProductsId = shopProductsId };
        }

        public void AddToBook(Product product)
        {
            db.Carts.Add(new Cart
            {
                ShopProductsId = ShopProductsId,
                product = product,
                Price = product.Price,
            });

            db.SaveChanges();
        }

        public List<Cart> getShopItems()
        {
            return db.Carts.Where(c => c.ShopProductsId == ShopProductsId).Include(s => s.product).ToList();
        }
    }
}
