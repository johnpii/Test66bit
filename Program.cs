using Microsoft.EntityFrameworkCore;
using Test66bit.Data;
using Test66bit.Hubs;
using Test66bit.Interfaces.Repos;
using Test66bit.Interfaces.Services;
using Test66bit.Profiles;
using Test66bit.Repositories;
using Test66bit.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(FootballerAddToFootballerMappingProfile), typeof(FootballerEditToFootballerMappingProfile));
builder.Services.AddScoped<IFootballerRepository, FootballerRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IFootballerService, FootballerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddSignalR();

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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<Test66bitHub>("/Test66bitHub");

app.Run();
