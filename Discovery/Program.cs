using Discovery.Data;
using Discovery.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Accès aux données directement dans les service de l'app
builder.Services.AddDbContext<AspNetIdentityDbContext>(opts => opts.UseSqlite(builder.Configuration["DbConnectionString"]));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AspNetIdentityDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


