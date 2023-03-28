using hw1403.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options => options.UseCosmos("AccountEndpoint=https://malomuzh-nosql.documents.azure.com:443/;" +
                "AccountKey=nu6UiQlebDqCjkNHSU3UQHFNHsqIP8GyB8o9jePvgmcD8iZAFFWYAfy2CL6KUujIzEVbmBYHZWZfACDb9xjkSA==;",
                "DbShop0327"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
