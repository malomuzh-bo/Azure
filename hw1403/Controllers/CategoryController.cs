using hw1403.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw1403.Controllers
{
	public class CategoryController : Controller
	{
		MyContext db;
		public CategoryController(MyContext context)
		{
			db = context;
		}
		public IActionResult Index()
		{
			ViewBag.categories = db.Categories.ToList();
			return View();
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
		public IActionResult Create()
		{
			return View();
		}
	}
}
