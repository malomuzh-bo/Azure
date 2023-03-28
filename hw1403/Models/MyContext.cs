using Microsoft.EntityFrameworkCore;

namespace hw1403.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().ToContainer("Categories");
			modelBuilder.Entity<Product>().ToContainer("Products");
		}
    }
}
