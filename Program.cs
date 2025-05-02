using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using ShopStoreSport.database;
using ShopStoreSport.Models;

namespace ShopStoreSport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //--------------------------------
           
            builder.Services.AddDbContext<SportsstoreContext>
                (
                    options =>
                    {
                        var x = builder.Configuration["ConnectionStrings:SportsStoreConnection"];
                        options.UseSqlServer(x);
                            
                    }
                );
            builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
            //--------------------------------
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
                "pagination",
                "Products/Page{pindex}",
                new { Controller = "Home", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
