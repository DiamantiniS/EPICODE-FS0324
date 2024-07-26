using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Diama_sHotel.Interfaces;
using Diama_sHotel.Services;
using Microsoft.Extensions.Logging;

namespace Diama_sHotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            // Configura la stringa di connessione
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Registra i servizi
            builder.Services.AddScoped<IClienteService>(sp => new ClienteService(connectionString));
            builder.Services.AddScoped<IDipendenteService>(sp => new DipendenteService(connectionString));
            builder.Services.AddScoped<ICameraService>(sp => new CameraService(connectionString));
            builder.Services.AddScoped<IPrenotazioneService>(sp => new PrenotazioneService(connectionString));
            builder.Services.AddScoped<IServizioAggiuntivoService>(sp => new ServizioAggiuntivoService(connectionString));

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                    policy.RequireRole("Amministratore"));
                options.AddPolicy("ConciergePolicy", policy =>
                    policy.RequireRole("Concierge"));
            });

            builder.Services.AddSession();

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
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
