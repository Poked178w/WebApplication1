using Microsoft.EntityFrameworkCore;
using PartyInvites.Data;
using PartyInvites.Services;

var builder = WebApplication.CreateBuilder(args);

const string connection = "Server = (localdb)\\mssqllocaldb;Database = userstoredb;Trusted_Connection=true";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<PlayersService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();