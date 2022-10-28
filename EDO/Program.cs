using EDO.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EDOContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:TestDB"]);
});

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
