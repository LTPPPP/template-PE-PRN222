using WebBlazor.Components;

namespace WebBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
   //         builder.Services.AddDbContextFactory<Web_MVCContext>(options =>
   //options.UseSqlServer(builder.Configuration.GetConnectionString("Web_MVCContext") ?? throw new InvalidOperationException("Connection string 'Web_MVCContext' not found.")));

   //         builder.Services.AddQuickGridEntityFrameworkAdapter();

   //         builder.Services.AddDatabaseDeveloperPageExceptionFilter();
   //         builder.Services.AddScoped<IProductService, ProductService>();
   //         builder.Services.AddScoped<IProductRepository, ProductRepository>();
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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
