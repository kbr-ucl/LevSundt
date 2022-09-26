using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Commands.Impementation;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Queries.Impementation;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Infrastructor.Repositories;
using LevSundt.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

// Clean Architecture
builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapRazorPages();

app.Run();
