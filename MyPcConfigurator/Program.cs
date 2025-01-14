using Microsoft.EntityFrameworkCore;
using MyPcConfigurator.Abstractions;
using MyPcConfigurator.Entities;
using MyPcConfigurator.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConfiguratorDbContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("ConfiguratorDb"));
    config.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
});
builder.Services.AddRepositories();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Build}/{action=Index}/{id?}");

app.Run();
