using CampusFootball.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("Database")
        ?? throw new InvalidOperationException("Connection string"
        + "'Database' not found.");

builder.Services.AddDbContext<CampusFootballContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(connectionString)
);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CampusFootballContext>();
    var pendingMigrations = dbContext.Database.GetPendingMigrations(); // find unapplied migrations
    if (pendingMigrations.Any()) // if any:
    {
        dbContext.Database.Migrate(); // apply them
    }
}

app.MapGet("/", () => "Hello World!");

app.Run();