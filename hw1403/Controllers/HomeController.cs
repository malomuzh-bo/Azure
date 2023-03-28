using hw1403.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace hw1403.Controllers
{
    public class HomeController : Controller
    {
        MyContext db;
        public HomeController(MyContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddCategories()
        {
			Category c1 = new Category() { CategoryName = "Category1", Id = Guid.NewGuid().ToString() };
			Category c2 = new Category() { CategoryName = "Category2", Id = Guid.NewGuid().ToString() };
			Category c3 = new Category() { CategoryName = "Category3", Id = Guid.NewGuid().ToString() };
			Category c4 = new Category() { CategoryName = "Category4", Id = Guid.NewGuid().ToString() };

			db.Add(c1);
			db.Add(c2);
			db.Add(c3);
			db.Add(c4);
			await db.SaveChangesAsync();

            return RedirectToAction("Index");
		}
        public async Task<IActionResult> AddProducts()
        {
            string id1 = db.Categories.Where(q => q.CategoryName == "Category2").First().Id;
            string id2 = db.Categories.Where(q => q.CategoryName == "Category4").First().Id;
            string id3 = db.Categories.Where(q => q.CategoryName == "Category3").First().Id;
            string id4 = db.Categories.Where(q => q.CategoryName == "Category1").First().Id;

			Product p1 = new Product() { Id = Guid.NewGuid().ToString(), Description = "Product1", Title = "Product1", CategoryId = id1 };
			Product p2 = new Product() { Id = Guid.NewGuid().ToString(), Description = "Product2", Title = "Product2", CategoryId = id2 };
			Product p3 = new Product() { Id = Guid.NewGuid().ToString(), Description = "Product3", Title = "Product3", CategoryId = id3 };
			Product p4 = new Product() { Id = Guid.NewGuid().ToString(), Description = "Product4", Title = "Product4", CategoryId = id4 };

			db.Add(p1);
			db.Add(p2);
			db.Add(p3);
			db.Add(p4);
			await db.SaveChangesAsync();

            return RedirectToAction("Index");
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}