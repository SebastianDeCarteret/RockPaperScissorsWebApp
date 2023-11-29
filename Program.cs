using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Models;
using RockPaperScissorsWebApp.Data;
using RockPaperScissorsWebApp.Models; // import db models
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RockPaperScissorsWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RockPaperScissorsWebAppContext") ?? throw new InvalidOperationException("Connection string 'RockPaperScissorsWebAppContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope()) // seed db
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.Run();
