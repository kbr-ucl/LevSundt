using LevSundt.WebApp.Infrastructure.Contracts;
using LevSundt.WebApp.Infrastructure.Implementations;
using LevSundt.WebApp.UserContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add-Migration InitialMigration -Context WebAppUserDbContext -Project LevSundt.WebApp.UserContext.Migrations
// Update-Database -Context WebAppUserDbContext
// Docker
builder.Configuration.AddEnvironmentVariables();
Console.WriteLine(builder.Configuration.GetConnectionString("WebAppUserDbConnection"));

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