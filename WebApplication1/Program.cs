using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Data;
using PartyInvites.Services;

var builder = WebApplication.CreateBuilder(args);

const string connection = "User ID=postgres; Password = Poked178w; Host = localhost; Port = 5432; Database = myDataBase";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
builder.Services.AddScoped<PlayersService>();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseAuthentication();
app.UseAuthorization();

app.Run();