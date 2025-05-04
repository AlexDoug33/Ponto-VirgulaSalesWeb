using Microsoft.EntityFrameworkCore;
using Ponto_VirgulaSalesWeb.Data;
using Ponto_VirgulaSalesWeb.Models;
using Ponto_VirgulaSalesWeb.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;


var builder = WebApplication.CreateBuilder(args);

var enUS = new CultureInfo("en-US");
var localizationOption = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

builder.Services.AddDbContext<Ponto_VirgulaSalesWebContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Ponto_VirgulaSalesWebContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Ponto_VirgulaSalesWebContext")),
    builder => builder.MigrationsAssembly("Ponto&VirgulaSalesWeb")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

app.UseRequestLocalization(localizationOption);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{   
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
