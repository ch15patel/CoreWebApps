using System.Xml.Serialization;
using EFCore.Models.NorthwindModel;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAppRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            // Add ConnectionStrings
            builder.Services.AddDbContext<NorthwindContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));

            //builder.Services.AddDbContext<SchoolContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));


            WebApplication app = builder.Build();

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

            app.MapRazorPages();

            app.Run();
        }
    }
}