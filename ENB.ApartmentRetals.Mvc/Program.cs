using ENB.ApartmentRentals.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ENB.ApartmentRentals.Mvc;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApartmentRentalsContext>(s => s.UseSqlServer(
      builder.Configuration.GetConnectionString("ApartmentCtstr")));
builder.Services.AddAutoMapper(typeof(ApartmentRentalProfil));
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddControllersWithViews();
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



app.Run();
