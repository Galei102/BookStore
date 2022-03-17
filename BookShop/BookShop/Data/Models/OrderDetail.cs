namespace BookShop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int orderID { get; set; }
        public int ProductId { get; set; }
        public uint Price { get; set; }
        public virtual Product product { get; set; }
        public virtual Order order { get; set; }
    }
}
