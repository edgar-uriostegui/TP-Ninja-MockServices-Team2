using ProductCatalog.EndPoints;
using ProductCatalog.Models;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.ConfigureOrderEndpoints();

app.Run();
