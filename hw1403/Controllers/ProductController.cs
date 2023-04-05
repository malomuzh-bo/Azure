using hw1403.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hw1403.Controllers
{
    public class ProductController : Controller
    {
        MyContext db;
        List<Product> products;
        public ProductController(MyContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.products = await db.Products.ToListAsync();
            ViewBag.сategories = await db.Categories.ToListAsync();
            products = await db.Products.ToListAsync();
            return View("Index", products);
        }
		[HttpPost]
		public async Task<IActionResult> Index(string id)
		{
			ViewBag.categories = await db.Categories.ToListAsync();
			ViewBag.products = await db.Products.ToListAsync();
			products = await db.Products.Where(g => g.CategoryId == id).ToListAsync();
			return View("Index", products);
		}

		public async Task<IActionResult> CreateProduct(string name, string desc, string c_id)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Id = Guid.NewGuid().ToString();
                product.Title = name;
                product.Description = desc;
                product.CategoryId = c_id;

                await db.AddAsync(product);
                await db.SaveChangesAsync();
                ViewBag.products = db.Products.ToList();
                return View("Index");
            }
            ViewBag.products = db.Products.ToList();
            return View("Index");
        }
        public IActionResult Create()
        {
            ViewBag.categories = db.Categories.ToList();
            return View();
        }
		public async Task<IActionResult> Edit(string id)
		{
			Product prod = await db.Products.FindAsync(id);
			//ViewBag.categories = await db.Categories.ToListAsync();
			if (prod != null)
			{
				ViewBag.categories = new SelectList(db.Categories, "Id", "CategoryName", prod.CategoryId);
				return View(prod);
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Description,CategoryId")] Product prod)
		{
			//ViewBag.categories = await db.Categories.ToListAsync();
			if (prod!= null)
			{
				db.Update(prod);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(prod);
		}
		public async Task<IActionResult> Delete(string id)
		{
			if (id != null)
			{
				Product prod = await db.Products.FindAsync(id);
				if (prod != null)
				{
					db.Products.Remove(prod);
					await db.SaveChangesAsync();
					ViewBag.categories = db.Categories.ToListAsync();
					return RedirectToAction("Index");
				}
			}
			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> SearchById(string searchStr)
		{
			ViewBag.Categories = db.Categories.ToList();
			products = await db.Products.Where(g => g.Title!.ToLower().Contains(searchStr.ToLower())).ToListAsync();
			return View("Index", products);
		}
	}
}
