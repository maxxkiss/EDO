using EDO.Models;
using EDO.Repositories;
using EDO.Repositories.Interfaces;
using EDO.Repository;
using EDO.Services;
using EDO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EDOContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:TestDB"]);
});

builder.Services.AddMvcCore();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

builder.Services.AddScoped<IDocumentService, DocumentService>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
