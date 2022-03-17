using BookShop.Data.Models;

namespace BookShop.Data.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> Products { get; }

        Product GetObjectBook(int productId);
    }
}
