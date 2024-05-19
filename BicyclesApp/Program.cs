using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Models;
using BicyclesApp.Service.IService;
using BicyclesApp.Service;
using Radzen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MySQL") ?? throw new InvalidOperationException("Connection string 'MySQL' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))
    ,ServiceLifetime.Transient);

builder.Services.AddIdentity<AppUser, AppRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 1;
}
)
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<ILoginBarNotifyService, LoginBarNotifyService>();
builder.Services.AddScoped<IRentalContractService, RentalContractService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddHttpClient();


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
app.UseAuthentication();
app.UseAuthorization();
await SeedDatabase();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


async Task SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        
        await db.Initialize();
    }
}