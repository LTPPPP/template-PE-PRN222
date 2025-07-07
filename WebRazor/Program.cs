using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using WebRazor.Hubs;

namespace WebRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<MainContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("MainContext") ?? throw new InvalidOperationException("Connection string 'MainContext' not found.")));

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAccountRepositories, AccountRepositories>();

            // Add SignalR
            builder.Services.AddSignalR();

            // Add CORS policy for SignalR
            var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new string[0];
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials(); // SignalR cần dòng này
                });
            });
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

            // Enable CORS for SignalR
            app.UseCors();

            app.UseAuthorization();

            app.MapRazorPages();

            // Add SignalR routing
            app.MapHub<DataSignalR>("/DataSignalRChanel");

            app.Run();
        }
    }
}
