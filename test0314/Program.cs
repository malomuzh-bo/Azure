using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos;
using System.Net.Security;
using test0314.Classes;

Console.WriteLine("Hello, World!");

using (var db = new TestContext())
{
    /******************Creating/Deleting DB******************/
    //await db.Database.EnsureCreatedAsync();
    //await db.Database.EnsureDeletedAsync();

    /******************Creating + add in DB******************/
    /*Author author = new Author() { Id = 1, AuthorName = "Author", LastName = "LastName1" };
	db.Add(author);
	await db.SaveChangesAsync();*/
	
	Book book = new Book() { Id = 1, Title = "Meditation", Description = "Good book", AuthorId = 1 };
	db.Add(book);
	await db.SaveChangesAsync();

    /******************Get elements******************/
    /*var authors = await db.Authors.ToListAsync();
	var books = await db.Books.ToListAsync();
	var data = books.Join(db.Authors, q => q.AuthorId, a => a.Id, (q, a) => new
	{
		id = q.Id,
		title = q.Title,
		description = q.Description,
		author = $"{a.AuthorName} {a.LastName}"
	}).ToList();

	foreach (var item in data)
	{
		Console.WriteLine($"Id: {item.id}\nTitle: {item.title}, Description: {item.description}\nAuthor: {item.author}");
	}*/

    /******************Edit element******************/
    /*var book = await db.Books.Where(q=>q.Id == 1).FirstAsync();
	Console.WriteLine(book.ToString());
	book.Title = "Updated Book";
	db.Update(book);
	await db.SaveChangesAsync();

	Console.WriteLine((await db.Books.Where(q => q.Id == 1).FirstAsync()).ToString());*/

    /******************Delete element******************/
    /*db.Books.Remove(db.Books.Where(q=>q.Id == 1).First());
	await db.SaveChangesAsync();*/

    Console.WriteLine("+++");
}