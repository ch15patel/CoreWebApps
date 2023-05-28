using CoreEF.Models.OracleHR;
using CoreEF.Models.Repo;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CoreEF.Models.EmpModel;

namespace WebApp.OracleHRRazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            // Add ConnectionStrings
            // Add services for OracleHR DataContext
            builder.Services.AddDbContext<OracleHrContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("OracleHR")));
            builder.Services.AddScoped<IJobRepository, JobRepository>();

            var app = builder.Build();

            //builder.Services.AddTransient<IRepository<Emp>, EmpRepository>();
            //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            


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