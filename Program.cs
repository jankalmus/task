using Application.DataAccess.Context;
using Application.DataAccess.Contracts;
using Application.DataAccess.Repositories;
using Application.DataAccess.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationConnectionString"));
});

builder.Services.AddScoped<ISessionDataRepository, SessionDataRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();

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

app.UseAuthorization();

app.MapRazorPages();

app.SeedDatabase();

app.Run();