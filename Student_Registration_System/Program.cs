using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure the database connection
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IDbConnection>(c => new SqlConnection(connectionString));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapGet("/", () => Results.Redirect("/Pages/Login"));

app.MapRazorPages();

//app.MapRazorPages(options =>
//{
//    options.Conventions.AddPageRoute("/Login", "");
//});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "/Pages/Login");

app.Run();

