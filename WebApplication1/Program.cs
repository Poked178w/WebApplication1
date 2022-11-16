using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using PartyInvites.Data;
using PartyInvites.Services;

var builder = WebApplication.CreateBuilder(args);

const string connection = "User ID=postgres; Password = Poked178w; Host = localhost; Port = 5432; Database = myDataBase";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
builder.Services.AddScoped<PlayersService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();