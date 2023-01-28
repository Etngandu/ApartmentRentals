using ENB.ApartmentRentals.EF;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ENB.Mvc.ApartmentRentals;
using ENB.ApartmentRetals.Infrastructure;
using ENB.ApartmentRentals.Entities.Repositories;
using ENB.ApartmentRentals.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApartmentRentalsContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("ApartCtrs")));
builder.Services.AddAutoMapper(typeof(ApartmentRentalProfil));
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IAsyncUnitOfWorkFactory, AsyncEFUnitOfWorkFactory>();
builder.Services.AddScoped<IAsyncGuestRepository, AsyncGuestRepository>();
builder.Services.AddScoped<IAsyncApartBuildingRepository, AsyncApartBuildingRepository>();
//builder.Services.AddScoped<IAsyncUnitOfWork, AsyncEFUnitOfWork>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
