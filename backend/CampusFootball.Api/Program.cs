using CampusFootball.Api.Data;
using CampusFootball.Api.Matches;
using Microsoft.EntityFrameworkCore;

//Initialize instance of WebApplicationBuilder class - has preconfigured defaults, used to configure further
var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<CampusFootballContext> ( optionsBuilder =>
    optionsBuilder.UseNpgsql(connectionString)
);

//Build the WebApp
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapMatchEndpoints();

app.Run();
