using hw1403.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw1403.Controllers
{
    public class ProductController : Controller
    {
        MyContext db;
        public ProductController(MyContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ViewBag.products = db.Products.ToList();
            return View();
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
    }
}
