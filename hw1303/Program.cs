using Npgsql;
using System.Data;

Console.WriteLine("Hello, World!");

var conn_str = new NpgsqlConnectionStringBuilder("Server=c.cluster-mbo.postgres.database.azure.com;Database=citus;Port=5432;User Id=citus;Password=Kaovktpx97k9k0@;Ssl Mode=Require;Pooling=true; Minimum Pool Size=0; Maximum Pool Size=50;");

conn_str.TrustServerCertificate = true;

using (var connection = new NpgsqlConnection(conn_str.ToString()))
{
	await connection.OpenAsync();

    /*******************Create Tables***********************/
    /*NpgsqlCommand cmd2 = new NpgsqlCommand("create table addresses (id serial primary key, country varchar(77), city varchar(77), street varchar(77))", connection);
	await cmd2.ExecuteNonQueryAsync();
	Console.WriteLine("table \"Addresses\" created!");
	
	NpgsqlCommand cmd = new NpgsqlCommand("create table books (id serial primary key, book_name varchar(77) not null, author_name varchar(77) not null, date_of_publish varchar(77), publisher varchar(77) not null, address_id int not null, foreign key (address_id) references addresses(id))", connection);
	await cmd.ExecuteNonQueryAsync();
	Console.WriteLine("table \"Books\" created!");*/
    
	/*******************Fill Tables*************************/
    /*NpgsqlCommand cmd = new NpgsqlCommand("insert into addresses (country, city, street) values (@country1, @city1, @street1), (@country2, @city2, @street2), (@country3, @city3, @street3)", connection);
	cmd.Parameters.AddWithValue("country1", "Greece");
	cmd.Parameters.AddWithValue("country2", "Hungary");
	cmd.Parameters.AddWithValue("country3", "Greece");
	cmd.Parameters.AddWithValue("city1", "Rhodes");
	cmd.Parameters.AddWithValue("city2", "City2");
	cmd.Parameters.AddWithValue("city3", "City3");
	cmd.Parameters.AddWithValue("street1", "Terpsichoris");
	cmd.Parameters.AddWithValue("street2", "Street2");
	cmd.Parameters.AddWithValue("street3", "Street3");
	await cmd.ExecuteNonQueryAsync();

	NpgsqlCommand cmd2 = new NpgsqlCommand("insert into books (book_name, author_name, date_of_publish, publisher, address_id) values (@b1, @a1, @d1, @p1, @ai1), (@b2, @a2, @d2, @p2, @ai2), (@b3, @a3, @d3, @p3, @ai3)", connection);
	cmd2.Parameters.AddWithValue("b1", "book1");
	cmd2.Parameters.AddWithValue("b2", "book2");
	cmd2.Parameters.AddWithValue("b3", "book3");
	cmd2.Parameters.AddWithValue("a1", "author1");
	cmd2.Parameters.AddWithValue("a2", "author2");
	cmd2.Parameters.AddWithValue("a3", "author3");
	cmd2.Parameters.AddWithValue("d1", "date1");
	cmd2.Parameters.AddWithValue("d2", "date2");
	cmd2.Parameters.AddWithValue("d3", "date3");
	cmd2.Parameters.AddWithValue("p1", "publisher1");
	cmd2.Parameters.AddWithValue("p2", "publisher2");
	cmd2.Parameters.AddWithValue("p3", "publisher3");
	cmd2.Parameters.AddWithValue("ai1", 2);
	cmd2.Parameters.AddWithValue("ai2", 1);
	cmd2.Parameters.AddWithValue("ai3", 3);
	
	await cmd2.ExecuteNonQueryAsync();*/
    
    /*******************Get Tables**************************/
	NpgsqlCommand cmd = new NpgsqlCommand("select * from addresses", connection);
    var read = await cmd.ExecuteReaderAsync();

    Console.WriteLine("Addresses:");

    while (await read.ReadAsync())
    {
        Console.WriteLine(string.Format("Id {0}:\nCountry: {1}, City: {2}, Street: {3}", read.GetInt32(0).ToString(), read.GetString(1), read.GetString(2), read.GetString(3)));
    }
    await read.CloseAsync();

	NpgsqlCommand cmd2 = new NpgsqlCommand("select * from books", connection);
    var read2 = await cmd2.ExecuteReaderAsync();

    Console.WriteLine("\nBooks:");

    while (await read2.ReadAsync())
    {
        Console.WriteLine(string.Format("Id {0}:\nBook name: {1}, Author: {2}\nDate of publish: {3}, Publisher: {4}\nAddress id: {5}", read2.GetInt32(0).ToString(), read2.GetString(1), read2.GetString(2), read2.GetString(3), read2.GetString(4), read2.GetInt32(5)));
    }
    await read2.CloseAsync();

    Console.WriteLine("+++");
}