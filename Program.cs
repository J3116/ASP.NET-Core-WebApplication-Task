using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppWithLogin.Data;

var builder = WebApplication.CreateBuilder(args);

// DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Identity + Roles  (one chain, no stray semicolons)
builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false; // or true if you want email confirm
    })
    .AddRoles<IdentityRole>()                                  // <-- enable roles
    .AddEntityFrameworkStores<ApplicationDbContext>();          // <-- EF store

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // <-- after UseRouting
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Electronics}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
