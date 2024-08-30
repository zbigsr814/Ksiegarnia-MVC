

using ExampleMvcProject.MVC.Entities;
using ExampleMvcProject.MVC.Service;
using Microsoft.EntityFrameworkCore;
using ExampleMvcProject.MVC.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Bookstore")));

builder.Services.AddScoped<BookstoreSeeder>();
builder.Services.AddScoped<IVariablesToController, VariablesToController>();

var app = builder.Build();

// Seedowanie danych przy starcie aplikacji
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<BookstoreSeeder>();
    seeder.Seed(); // Wywo³anie metody seeduj¹cej dane
}

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
