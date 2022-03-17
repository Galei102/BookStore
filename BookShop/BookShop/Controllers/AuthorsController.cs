#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShop.Data;
using BookShop.Data.Models;

namespace BookShop.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly Db db;

        public AuthorsController(Db _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Author.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Year")] Author author)
        {         
            if (ModelState.IsValid)
            {
                db.Add(author);
                await db.SaveChangesAsync();
                TempData["SM"] = "Вы добавили нового автора";
                return RedirectToAction(nameof(Index));
            }         
            return View(author);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await db.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Year")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(author);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SM"] = "Вы отредактировали автора.";
                return RedirectToAction(nameof(Edit));
            }
            return View(author);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await db.Author
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await db.Author
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await db.Author.FindAsync(id);
            db.Author.Remove(author);
            await db.SaveChangesAsync();
            TempData["SM"] = "Вы успешно удалили";
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return db.Author.Any(e => e.Id == id);
        }
    }
}
