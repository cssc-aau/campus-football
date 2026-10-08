using CampusFootball.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<CampusFootballContext> ( optionsBuilder =>
    optionsBuilder.UseNpgsql(connectionString)
);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
