using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test0314.Classes
{
	public class Author
	{
		public int Id { get; set; }
		public string AuthorName { get; set; }
		public string LastName { get; set; }
		public ICollection<Book> Books { get; set; }

		public Author()
		{
			Books = new List<Book>();
		}
	}
}
