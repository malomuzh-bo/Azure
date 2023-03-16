using Microsoft.EntityFrameworkCore;

namespace hw1403.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
