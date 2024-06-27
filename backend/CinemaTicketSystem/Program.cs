using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CinemaTicketSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi i servizi al contenitore.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<CinemaService>(); // Aggiungi il tuo servizio qui

var app = builder.Build();

// Configura la pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
