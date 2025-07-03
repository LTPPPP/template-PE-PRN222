using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DAL.Data;
using BLL.Services.Interfaces;
using BLL.Services;
using DAL.Repositories.Interfaces;
using DAL.Repositories;
namespace WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MainContext") ?? throw new InvalidOperationException("Connection string 'MainContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddDbContext<Web_MVCContext>(options =>
            //   options.UseSqlServer(builder.Configuration.GetConnectionString("Web_MVCContext") ?? throw new InvalidOperationException("Connection string 'Web_MVCContext' not found.")));
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAccountRepositories, AccountRepositories>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for Accountion scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }
    }
}
