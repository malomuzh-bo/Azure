using hw1403.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hw1403.Controllers
{
	public class CategoryController : Controller
	{
		MyContext db;
		List<Category> categories;
		public CategoryController(MyContext context)
		{
			db = context;
		}
		public async Task<IActionResult> Index()
		{
			categories = await db.Categories.ToListAsync();
			return View(categories);
		}
		public async Task<IActionResult> CreateCategory(string name)
		{
			if (ModelState.IsValid)
			{
				Category category = new Category();
				category.Id = Guid.NewGuid().ToString();
				category.CategoryName = name;

				await db.AddAsync(category);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Edit(string? id)
		{
			Category category = await db.Categories.FindAsync(id);
			if (category != null)
			{
				return View(category);
			}
			return View();
		}
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,CategoryName")] Category category)
		{
			if (category != null)
			{
				db.Update(category);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
            }
			return View(category);
		}
		public async Task<IActionResult> Delete(string? id)
		{
			if (id != null)
			{
				Category category = await db.Categories.FindAsync(id);
				if (category != null)
				{
					db.Categories.Remove(category);
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			}
			return NotFound();
		}
		public IActionResult Create()
		{
			return View();
		}
	}
}
