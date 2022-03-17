using BookShop.Data;
using BookShop.Data.Interfaces;
using BookShop.Data.Models;
using BookShop.Data.ViewModels;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using BookShop.Data.Repository;

namespace BookShop.Controllers
{
    public class ShopProductsController : Controller
    {
        private readonly IProducts ProductsServer;
        private readonly ShopProducts _shopProducts;
        private readonly Db db;

        public ShopProductsController(IProducts _ProductsServer, ShopProducts shopProducts, Db _db)
        {
            _shopProducts = shopProducts;
            ProductsServer = _ProductsServer;
            db = _db;
        }

        public ViewResult Index()
        {
           
            var cart = _shopProducts.getShopItems();
            _shopProducts.CartList = cart;

            var obj = new ShopProductViewModel
            {
                shopProducts = _shopProducts
            };

            return View(obj);
        }

       
        


        public IActionResult DeletePage(int id)
        {
            //Получаем страницу

            Cart cart = db.Carts.Find(id);

            //Удаляем страницу

            db.Carts.Remove(cart);

            //Сохраняем изменения в базе

            db.SaveChanges();

            //Добавляем сообщение о удачном удалении страницы

            TempData["SM"] = "Вы удалили позицию";

            //Переадресовываем пользователя

            return RedirectToAction("Index");
        }


        public RedirectToActionResult addToBook(int id)
        {
            var item = ProductsServer.Products.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopProducts.AddToBook(item);
            }
            TempData["SM"] = "Вы добавили товар в корзину";
            return RedirectToAction("Index", "Products");
        }
    }
}
