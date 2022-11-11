using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Commands.Impementation;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Queries.Impementation;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Infrastructor.DomainServices;
using LevSundt.Bmi.Infrastructor.Repositories;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture
builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();
builder.Services.AddScoped<IBmiDomainService, BmiDomainService>();

// Docker
builder.Configuration.AddEnvironmentVariables();

Console.WriteLine(builder.Configuration.GetConnectionString("LevSundtDbConnection"));
// Database
// Add-Migration InitialMigration -Context LevSundtContext -Project LevSundt.SqlServerContext.Migrations
// Update-Database -Context LevSundtContext
// Script-Migration -Context LevSundtContext

builder.Services.AddDbContext<LevSundtContext>(
    options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("LevSundtDbConnection"),
            x=> x.MigrationsAssembly("LevSundt.SqlServerContext.Migrations")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();



}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
