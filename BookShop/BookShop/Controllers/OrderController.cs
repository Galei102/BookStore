using BookShop.Data;
using BookShop.Data.Interfaces;
using BookShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder orders;
        private readonly ShopProducts shopProducts;
        private readonly Db db;

        public OrderController(IOrder orders, ShopProducts _shopProducts)
        {
            this.shopProducts = _shopProducts;
            this.orders = orders;
        }
        public IActionResult Checkout()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopProducts.CartList = shopProducts.getShopItems();

            if (shopProducts.CartList.Count == 0)
            {
                ModelState.AddModelError("", "У Вас должны быть товары");
            }

            if (!ModelState.IsValid)
            {
                orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
