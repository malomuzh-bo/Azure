using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test0314.Classes
{
	public class TestContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Book>().ToContainer("Books");
			modelBuilder.Entity<Author>().ToContainer("Authors");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseCosmos("AccountEndpoint=https://malomuzh-nosql.documents.azure.com:443/;" +
				"AccountKey=nu6UiQlebDqCjkNHSU3UQHFNHsqIP8GyB8o9jePvgmcD8iZAFFWYAfy2CL6KUujIzEVbmBYHZWZfACDb9xjkSA==;", 
				"MyDatabase");
		}
	}
}
