using PoliziaMunicipale.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DAO services
builder.Services.AddScoped<VerbaleDAO>(sp => new VerbaleDAO(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AnagraficaDAO>(sp => new AnagraficaDAO(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<TipoViolazioneDAO>(sp => new TipoViolazioneDAO(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
