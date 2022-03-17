using BookShop.Data.Models;

namespace BookShop.Data.Interfaces
{
    public interface IOrder
    {
        public void CreateOrder(Order order);
    }
}
