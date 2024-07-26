using Hotel.DAO;
using Microsoft.Extensions.Logging;
using Hotel.Services;

namespace Hotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddLogging();

            // Dependency Injection
            builder.Services.AddScoped<IClienteDao, ClienteDao>();
            builder.Services.AddScoped<ICameraDao, CameraDao>();
            builder.Services.AddScoped<IPrenotazioneDao, PrenotazioneDao>();
            builder.Services.AddScoped<IServizioDao, ServizioDao>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
