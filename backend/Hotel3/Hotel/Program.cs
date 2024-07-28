using Hotel.DAO;
using Hotel.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Leggi la stringa di connessione dal file di configurazione
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Aggiungi servizi al contenitore
builder.Services.AddControllersWithViews();
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

// Aggiungi e configura l'autenticazione
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// Aggiungi e configura le politiche di autorizzazione
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("GeneralAccessPolicy", policy =>
        policy.RequireAuthenticatedUser());
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("admin")); // Aggiunta la policy AdminPolicy se necessaria
});

// Dependency Injection
builder.Services.AddScoped<IClienteDao, ClienteDao>(provider => new ClienteDao(connectionString));
builder.Services.AddScoped<ICameraDao, CameraDao>(provider => new CameraDao(connectionString));
builder.Services.AddScoped<IPrenotazioneDao, PrenotazioneDao>(provider => new PrenotazioneDao(connectionString));
builder.Services.AddScoped<IServizioDao, ServizioDao>(provider => new ServizioDao(connectionString));
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configura la pipeline di richieste HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usa l'autenticazione e l'autorizzazione
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
