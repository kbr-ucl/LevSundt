using LevSundt.WebApp.Infrastructure.Contracts;
using LevSundt.WebApp.Infrastructure.Implementations;
using LevSundt.WebApp.UserContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add-Migration InitialMigration -Context WebAppUserDbContext -Project LevSundt.WebApp.UserContext.Migrations
// Update-Database -Context WebAppUserDbContext
var connectionString = builder.Configuration.GetConnectionString("WebAppUserDbConnection");
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString,
        x => x.MigrationsAssembly("LevSundt.WebApp.UserContext.Migrations")));
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<WebAppUserDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CoachPolicy", policyBuilder => policyBuilder.RequireClaim("Coach"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Bmi");
    options.Conventions.AuthorizeFolder("/Coach", "CoachPolicy");
});

builder.Services.AddHttpClient<ILevSundtService, LevSundtService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["LevSundtBaseUrl"]);
});

//// Clean Architecture
//builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
//builder.Services.AddScoped<IBmiRepository, BmiRepository>();
//builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
//builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
//builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();
//builder.Services.AddScoped<IBmiDomainService, BmiDomainService>();

//// Database
//// Add-Migration InitialMigration -Context LevSundtContext -Project LevSundt.SqlServerContext.Migrations
//// Update-Database -Context LevSundtContext
//builder.Services.AddDbContext<LevSundtContext>(
//    options => 
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LevSundtDbConnection"),
//    x=> x.MigrationsAssembly("LevSundt.SqlServerContext.Migrations")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();