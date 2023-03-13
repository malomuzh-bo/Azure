using Npgsql;
using System.Data;

Console.WriteLine("Hello, World!");

var conn_str = new NpgsqlConnectionStringBuilder("Server=c.cluster-malomuzh.postgres.database.azure.com;Database=citus;Port=5432;User Id=citus;Password=Kaovktpx97k9k0@;Ssl Mode=Require;Pooling=true; Minimum Pool Size=0; Maximum Pool Size=50;");

conn_str.TrustServerCertificate = true;

DataTable dt = new DataTable();

using (var connection = new NpgsqlConnection(conn_str.ToString()))
{
	await connection.OpenAsync();

	/*******************Create Table***********************/
	/*NpgsqlCommand cmd = new NpgsqlCommand("create table students (id serial primary key, student_name varchar(77) not null, age int not null)", connection);
	cmd.ExecuteNonQuery();
	Console.WriteLine("Table was createded.");*/

	/*******************Fill Table*************************/
	/*NpgsqlCommand cmd = new NpgsqlCommand("insert into students (student_name, age) values (@name, @age)", connection);
	cmd.Parameters.AddWithValue("name", "Iman");
	cmd.Parameters.AddWithValue("age", 24);*/

	/*******************Get Table**************************/
	/*NpgsqlCommand cmd = new NpgsqlCommand("select * from students", connection);
	var read = await cmd.ExecuteReaderAsync();

	while (await read.ReadAsync())
	{
		Console.WriteLine(string.Format("Id {0}:\nStudent name: {1}, Age: {2}", read.GetInt32(0).ToString(), read.GetString(1), read.GetInt32(2)));
	}
	await read.CloseAsync();*/

	/*******************Update and Get Table***************/
	/*NpgsqlCommand cmd = new NpgsqlCommand("update students set student_name = @s_name where id = @s_id", connection);
	cmd.Parameters.AddWithValue("s_name", "Bohdan");
	cmd.Parameters.AddWithValue("s_id", 2);

	await cmd.ExecuteNonQueryAsync();

	NpgsqlCommand cmd2 = new NpgsqlCommand("select * from students", connection);
	var read = await cmd2.ExecuteReaderAsync();

	while (await read.ReadAsync())
	{
		Console.WriteLine(string.Format("Id {0}:\nStudent name: {1}, Age: {2}", read.GetInt32(0).ToString(), read.GetString(1), read.GetInt32(2)));
	}
	await read.CloseAsync();*/

	/*******************Delete from table******************/
	/*NpgsqlCommand cmd = new NpgsqlCommand("delete from students where student_name = @s_name", connection);
	cmd.Parameters.AddWithValue("s_name", "Bohdan");
	await cmd.ExecuteNonQueryAsync();

	NpgsqlCommand cmd2 = new NpgsqlCommand("select * from students", connection);
	var read = await cmd2.ExecuteReaderAsync();

	while (await read.ReadAsync())
	{
		Console.WriteLine(string.Format("Id {0}:\nStudent name: {1}, Age: {2}", read.GetInt32(0).ToString(), read.GetString(1), read.GetInt32(2)));
	}
	await read.CloseAsync();*/

	/*******************Unconnected mode***************/
	/*NpgsqlCommand cmd = new NpgsqlCommand("select * from students", connection);
	NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
	adp.Fill(dt);
	if (dt.Rows.Count > 0)
	{
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			for(int j = 0; j < dt.Columns.Count; j++)
			{
				Console.Write(dt.Rows[i][j] + " ");
			}
			Console.WriteLine();
		}
	}*/
	/*int q = await cmd.ExecuteNonQueryAsync();
	Console.WriteLine("Count of rows: " + q);*/
}
