using Microsoft.EntityFrameworkCore;
using SM.Business.DataServices;
using SM.Business.DataServices.Interfaces;
using SM.Data;

namespace SM.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework
            builder.Services.AddDbContext<ShopManagementDbContext>(
                options => options.UseSqlServer("Data Source=localhost; Database=ShopDB; Integrated Security=SSPI; TrustServerCertificate=True;"));

            // All of the Custom Configuration
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddSingleton<IShopService, ShopService>();

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
                pattern: "{controller=Shop}/{action=Index}/{id?}");

            app.Run();
        }
    }
}