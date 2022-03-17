using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Db db;
        private readonly IWebHostEnvironment _host;

        public ProductsController(Db _db, IWebHostEnvironment hostEnvi)
        {
            db = _db;
            _host = hostEnvi;
        }

        [HttpGet]
        public IActionResult Index(int? category, string name)
        {
            IQueryable<Product> product = db.Products.Include(p => p.Category);
            if (category != null && category != 0)
            {
                product = product.Where(p => p.CategoryId == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                product = product.Where(p => p.Name.Contains(name));
            }

            List<Category> categories = db.Categories.ToList();

            // устанавливаем начальный элемент, который позволит выбрать всех
            categories.Insert(0, new Category { Name = "Все", Id = 0 });

            ProductListViewModel model = new ProductListViewModel
            {
                Products = product.ToList(),
                Categorys = new SelectList(categories, "Id", "Name"),
                Name = name
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList category = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Category = category;
            SelectList author = new SelectList(db.Author, "Id", "Name");
            ViewBag.Author = author;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }
            else if (db.Products.Any(x => x.Name == product.Name))
            {
                ModelState.AddModelError("Name", "Книга с таким названием уже существует");
                SelectList category = new SelectList(db.Categories, "Id", "Name");
                ViewBag.Category = category;
                SelectList author = new SelectList(db.Author, "Id", "Name");
                ViewBag.Author = author;
                return View(product);
            }

            if (uploadedFile == null)
            {
                SelectList category = new SelectList(db.Categories, "Id", "Name");
                ViewBag.Category = category;
                SelectList author = new SelectList(db.Author, "Id", "Name");
                ViewBag.Author = author;
                return View(category);
            }

            // путь к папке img
            string path = "/Img/" + uploadedFile.FileName;

            product.NameImg = uploadedFile.FileName;
            product.PathImg = path;
            db.Add(product);
            db.SaveChangesAsync();

            // сохраняем файл в папку Img в каталоге wwwroot
            using (var fileStream = new FileStream(_host.WebRootPath + path, FileMode.Create))
            {
                uploadedFile.CopyToAsync(fileStream);
            }

            TempData["SM"] = "Вы добавили новую книгу";

            return RedirectToAction(nameof(Index));
        }
    }
}
