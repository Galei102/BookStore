using BookShop.Data.Interfaces;
using BookShop.Data.Models;

namespace BookShop.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly Db db;
        private readonly ShopProducts shopProducts;

        public OrderRepository(Db _db, ShopProducts _shopProducts)
        {
            this.shopProducts = _shopProducts;
            this.db = _db;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            db.Order.Add(order);

            var items = shopProducts.CartList;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = el.product.Id,
                    orderID = order.Id,
                    Price = el.product.Price
                };
                db.OrderDetail.Add(orderDetail);
            }

            db.SaveChanges();
        }
    }
}
