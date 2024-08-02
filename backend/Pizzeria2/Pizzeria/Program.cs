using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Data;
using Pizzeria.Models;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configura la connessione al database
var connectionString = builder.Configuration.GetConnectionString("Pizzeria");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configura l'identità
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Aggiungi la configurazione della sessione
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configura la pipeline di richiesta HTTP
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

app.UseAuthentication();
app.UseAuthorization();

// Usa il middleware della sessione
app.UseSession();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Admin}/{action=ManageOrders}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        await SeedRolesAndAdminAsync(roleManager, userManager, services.GetRequiredService<ILogger<Program>>());
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating roles and admin user.");
    }
}

app.Run();

async Task SeedRolesAndAdminAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ILogger<Program> logger)
{
    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(role));
            if (roleResult.Succeeded)
            {
                logger.LogInformation("Role {Role} created successfully", role);
            }
            else
            {
                logger.LogError("Error creating role {Role}: {Errors}", role, string.Join(", ", roleResult.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            logger.LogInformation("Role {Role} already exists", role);
        }
    }

    var adminEmail = "admin@pizzeria.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
        var result = await userManager.CreateAsync(adminUser, "Admin123!");
        if (result.Succeeded)
        {
            var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
            if (addToRoleResult.Succeeded)
            {
                logger.LogInformation("Admin user created and assigned to role Admin successfully");
            }
            else
            {
                logger.LogError("Error assigning admin user to role Admin: {Errors}", string.Join(", ", addToRoleResult.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            logger.LogError("Error creating admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
    else
    {
        logger.LogInformation("Admin user already exists");
    }
}
