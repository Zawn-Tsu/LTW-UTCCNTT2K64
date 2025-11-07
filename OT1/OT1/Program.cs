using Microsoft.EntityFrameworkCore;
using OT1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var ConnectString = builder.Configuration.GetConnectionString("OT1Connection");
builder.Services.AddDbContext<DatabaseContext>(Options => Options.UseSqlServer(ConnectString));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
